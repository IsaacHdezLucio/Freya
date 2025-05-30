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

        return visitor.Args; //.ToString();
    }
}

public class FreyaVisitor : FreyaBaseVisitor<object>
{
    public object Args { get; set; }
    public Dictionary<string, object> Variables = new();

//  Code parser
    public override object VisitCodeParse([NotNull] FreyaParser.CodeParseContext context)
    {
        foreach (var statementContext in context.statement())
        {
            Visit(statementContext);
        }

        if (context.scriptDef() != null)
            ; //            Visit(context.scriptDef(0).); // Visit(context.scriptDef()); // Visit(context.scriptDef());
        return null;
    }

    public object Aritmetica(string value)
    {
        /*
        if (value.Contains("+") || value.Contains("-") || value.Contains("*") || value.Contains("/"))
            ;
        return value;
    */
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

    public override object VisitFunctionCall([NotNull] FreyaParser.FunctionCallContext context)
    {
        // Obtener el nombre de la función
        var functionName = context.ID()?.GetText();

        // Obtener la lista de argumentos
        var argumentList = context.argumentList();
        var arguments = argumentList?.argument() ?? Array.Empty<FreyaParser.ArgumentContext>();

        // Imprimir el árbol del contexto para depuración
        Console.WriteLine(context.ToStringTree());

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
                    valorF.Append(argText.Substring(1, argText.Length - 2));
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
            else
            {
                Console.WriteLine($@"Variable no definida: {id}");
                return null;
            }
        }
        else
        {
            return Visit(context.expression());
        }
    }

    // -------------------------
    // Arithmetical

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
        else
        {
            Console.WriteLine($@"Variable no definida: {id}");
            return 0; // Valor por defecto
        }
    }
}