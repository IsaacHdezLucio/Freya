using System;

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

    public override object VisitFunctionCall(FreyaParser.FunctionCallContext context)
    {
        var functionName = context.ID()?.GetText();
        var args = context.argumentList()?.argument();

        Console.WriteLine(context.ToStringTree());

        if (functionName == "shMsg" && args != null && args.Length > 0)
        {
            var argText = args[0].GetText();

            if ((argText.StartsWith("\"") && argText.EndsWith("\"")) ||
                (argText.StartsWith("'") && argText.EndsWith("'")))
            {
                var cleanText = argText.Substring(1, argText.Length - 2);
                Args = cleanText; // Guarda el valor en la instancia de la clase
            }
        }

        return string.Empty; // Si no es shMsg o no hay argumentos
    }
}