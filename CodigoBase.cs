using System;
using System.Collections.Generic;
using System.Linq;
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
    public Dictionary<string, object> variables = new();

// Métodos para imprimir (simulado)
    private void Imprimir(params object[] args)
    {
        Console.WriteLine(string.Join(" ", args));
    }

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
                    con = Convert.ToInt32(value);
                    break;
                case "%f":
                    con = Convert.ToSingle(value);
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

        variables[variable] = con;
        Console.WriteLine(variables[variable]);
        return null;
    }

    public override object VisitFunctionCall([NotNull] FreyaParser.FunctionCallContext context)
    {
        List<object> results = new();

        if (context.argumentList() != null)
            foreach (var arg in context.argumentList().argument())
            {
                results.Add(Visit(arg));
            }

        var functionName = context.ID()?.GetText();
        var args = context.argumentList()?.argument();

        Console.WriteLine(context.ToStringTree());

        string valorF = "";

        if (functionName == "shMsg" && args != null && args.Length > 0)
        {
            foreach (var arg in args)
            {
                var argText = arg.GetText(); // args[0].GetText();

                if ((argText.StartsWith("\"") && argText.EndsWith("\"")) ||
                    (argText.StartsWith("'") && argText.EndsWith("'")))
                {
                    var cleanText = argText.Substring(1, argText.Length - 2);
                    Args = cleanText; // Guarda el valor en la instancia de la clase
                }
                else
                {
                    var args2 = variables[argText].ToString();
                    Args = args2;
                }

                valorF += Args;
            }

            Args = valorF;
        }

        return string.Empty; // Si no es shMsg o no hay argumentos
    }
}