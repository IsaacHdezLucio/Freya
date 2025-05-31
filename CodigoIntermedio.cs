using System.Collections.Generic;
using Antlr4.Runtime.Misc;

namespace FreyaDX;

// Intermedio
public class FreyaIntermediateCodeVisitor : FreyaBaseVisitor<string>
{
    private int _tempCount;
    private readonly List<string> _instructions = new();

    // Generar nuevo temporal
    private string NewTemp()
    {
        _tempCount++;
        return $"t{_tempCount}";
    }

    // Obtener el código generado
    public List<string> GetInstructions()
    {
        return _instructions;
    }

    // Visit variableDef: genera código para la expresión y asigna a variable
    public override string VisitVariableDef([NotNull] FreyaParser.VariableDefContext context)
    {
        string varName = context.ID().GetText();
        string exprTemp = Visit(context.expression());

        // Generar instrucción de asignación
        _instructions.Add($"{varName} = {exprTemp}");
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
        _instructions.Add($"{funcName}({argsStr})");
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
        _instructions.Add($"{temp} = {left} {op} {right}");
        return temp;
    }

    public override string VisitMulDivExpr([NotNull] FreyaParser.MulDivExprContext context)
    {
        string left = Visit(context.expression(0));
        string right = Visit(context.expression(1));
        string temp = NewTemp();

        string op = context.op.Type == FreyaLexer.MULT ? "*" : "/";
        _instructions.Add($"{temp} = {left} {op} {right}");
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