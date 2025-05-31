using System;
using System.Collections.Generic;
using System.Text;
using Antlr4.Runtime;
using Antlr4.Runtime.Misc;

namespace FreyaDX;

public class CodigoBase
{
    public object AnalizarCodigo(FreyaParser parser)
    {
        var context = parser.codeParse();

        FreyaVisitor visitor = new();
        visitor.Visit(context);

        return visitor.Args;
    }
}

public class FreyaVisitor : FreyaBaseVisitor<object>
{
    public object Args { get; set; }
    public Dictionary<string, object> Variables = new();

    //  Code parser
    public override object VisitCodeParse([NotNull] FreyaParser.CodeParseContext context)
    {
        foreach (var statementContext in context.statement()) Visit(statementContext);
        // if (context.scriptDef() != null) Visit(context.scriptDef());
        return null;
    }

    #region Funciones para operaciones aritmeticas

    /// <summary>
    /// Esta función convierte un valor string a numerico y si es operación matematica realiza su calculo.  
    /// </summary>
    /// <param name="value"></param>
    /// <returns></returns>
    public object Aritmetica(string value)
    {
        try
        {
            var dt = new System.Data.DataTable();
            var result = dt.Compute(value, "");
            return result;
        }
        catch
        {
            return null; // O manejar el error como prefieras
        }
    }

    public override object VisitVariableDef([NotNull] FreyaParser.VariableDefContext context)
    {
        var variable = context.ID().GetText();
        var type = context.typeLiteral().GetText();
        var value = context.expression().GetText();

        object con;
        try
        {
            switch (type)
            {
                case "%i":
                    con = Convert.ToInt32(Aritmetica(value));
                    break;
                case "%f":
                    con = Convert.ToSingle(Aritmetica(value));
                    break;
                case "%s":
                    con = value.Substring(1, value.Length - 2);
                    break;
                default:
                    Console.WriteLine($@"Tipo no soportado: {type}");
                    return null;
            }
        }
        catch (Exception e)
        {
            Console.WriteLine($@"Error de conversión de tipo: {e.Message}");
            return null;
        }

        Variables[variable] = con;
        Console.WriteLine(Variables[variable]);
        return null;
    }

    // Override del método VisitValueExpr
    public override object VisitValueExpr([NotNull] FreyaParser.ValueExprContext context)
    {
        return Visit(context.value());
    }

    // Override del método VisitIdExpr
    public override object VisitIdExpr([NotNull] FreyaParser.IdExprContext context)
    {
        string id = context.ID().GetText();
        if (Variables.ContainsKey(id))
        {
            return Variables[id];
        }

        Console.WriteLine($@"Variable no definida: {id}");
        return 0; // Valor por defecto
    }

    #endregion

    public override object VisitFunctionCall([NotNull] FreyaParser.FunctionCallContext context)
    {
        // Obtener el nombre de la función
        var functionName = context.ID()?.GetText();

        // Obtener la lista de argumentos
        var argumentList = context.argumentList();
        var arguments = argumentList?.argument() ?? Array.Empty<FreyaParser.ArgumentContext>();

        // Imprimir el árbol del contexto para depuración
        // Console.WriteLine(context.ToStringTree());

        // Solo procesar si la función es "shMsg" y hay argumentos
        if (functionName == "shMsg" && arguments.Length > 0)
        {
            var valorF = new StringBuilder();

            foreach (var arg in arguments)
            {
                var argText = arg.GetText();

                // Verifica si el argumento es un literal de cadena (comillas simples o dobles)
                if ((argText.StartsWith("\"") && argText.EndsWith("\"")) ||
                    (argText.StartsWith("'") && argText.EndsWith("'")))
                    // Elimina las comillas y agrega al resultado
                    valorF.Append(argText.Replace("\"", "").Replace("'", "")
                        .Trim()); // valorF.Append(argText.Substring(1, argText.Length - 2));
                else if (Variables.TryGetValue(argText, out var variableValue))
                    // Si es una variable existente, agrega su valor
                    valorF.Append(variableValue?.ToString() ?? string.Empty);
                else
                    // Si no es ni literal ni variable, agrega el texto tal cual
                    valorF.Append(argText);
            }

            Args = valorF.ToString();
        }

        // Si no es shMsg o no hay argumentos, retorna string.Empty
        return string.Empty;
    }

    // Override del método VisitArgument
    public override object VisitArgument([NotNull] FreyaParser.ArgumentContext context)
    {
        if (context.ID() != null)
        {
            string id = context.ID().GetText();
            if (Variables.ContainsKey(id))
                return Variables[id];
            Console.WriteLine($@"Variable no definida: {id}");
            return null;
        }

        return Visit(context.expression());
    }
}

// Intermedio
public class FreyaIntermediateCodeVisitor : FreyaBaseVisitor<string>
{
    private int tempCount;
    private List<string> instructions = new();

    // Generar nuevo temporal
    private string NewTemp()
    {
        tempCount++;
        return $"t{tempCount}";
    }

    // Obtener el código generado
    public List<string> GetInstructions()
    {
        return instructions;
    }

    // Visit variableDef: genera código para la expresión y asigna a variable
    public override string VisitVariableDef([NotNull] FreyaParser.VariableDefContext context)
    {
        string varName = context.ID().GetText();
        string exprTemp = Visit(context.expression());

        // Generar instrucción de asignación
        instructions.Add($"{varName} = {exprTemp}");
        return varName;
    }

    // Visit functionCall: genera código para argumentos y llamada
    public override string VisitFunctionCall([NotNull] FreyaParser.FunctionCallContext context)
    {
        string funcName = context.ID().GetText();
        List<string> argTemps = new List<string>();

        if (context.argumentList() != null)
        {
            foreach (var arg in context.argumentList().argument())
            {
                argTemps.Add(Visit(arg));
            }
        }

        // Generar instrucción de llamada a función
        string argsStr = string.Join(", ", argTemps);
        instructions.Add($"{funcName}({argsStr})");
        return null; // No devuelve valor
    }

    // Visit argument: puede ser expresión o ID
    public override string VisitArgument([NotNull] FreyaParser.ArgumentContext context)
    {
        if (context.ID() != null)
            return context.ID().GetText();

        return Visit(context.expression());
    }

    // Visit expression: manejar operaciones con temporales
    public override string VisitAddSubExpr([NotNull] FreyaParser.AddSubExprContext context)
    {
        string left = Visit(context.expression(0));
        string right = Visit(context.expression(1));
        string temp = NewTemp();

        string op = context.op.Type == FreyaLexer.PLUS ? "+" : "-";
        instructions.Add($"{temp} = {left} {op} {right}");
        return temp;
    }

    public override string VisitMulDivExpr([NotNull] FreyaParser.MulDivExprContext context)
    {
        string left = Visit(context.expression(0));
        string right = Visit(context.expression(1));
        string temp = NewTemp();

        string op = context.op.Type == FreyaLexer.MULT ? "*" : "/";
        instructions.Add($"{temp} = {left} {op} {right}");
        return temp;
    }

    #region Visitors de variables y tipos de datos

    public override string VisitParenExpr([NotNull] FreyaParser.ParenExprContext context)
    {
        return Visit(context.expression());
    }

    public override string VisitIdExpr([NotNull] FreyaParser.IdExprContext context)
    {
        return context.ID().GetText();
    }

    public override string VisitValueExpr([NotNull] FreyaParser.ValueExprContext context)
    {
        return Visit(context.value());
    }

    public override string VisitIntValue([NotNull] FreyaParser.IntValueContext context)
    {
        return context.DIGITS().GetText();
    }

    public override string VisitFloatValue([NotNull] FreyaParser.FloatValueContext context)
    {
        return context.FLOAT_NUMBER().GetText();
    }

    public override string VisitStringDoubleValue([NotNull] FreyaParser.StringDoubleValueContext context)
    {
        return context.STRING_DOUBLE().GetText();
    }

    public override string VisitStringSingleValue([NotNull] FreyaParser.StringSingleValueContext context)
    {
        return context.STRING_SINGLE().GetText();
    }

    #endregion

    // Puedes agregar más overrides para otras reglas según tu gramática
}