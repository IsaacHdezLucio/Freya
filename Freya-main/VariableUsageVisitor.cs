using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace FreyaDX
{
    public class VariableUsageVisitor : FreyaBaseVisitor<object>
    {
        public HashSet<string> VariablesDeclaradas { get; } = new();
        public HashSet<string> VariablesUsadas { get; } = new();

        public override object VisitVariableDef(FreyaParser.VariableDefContext context)
        {
            var varName = context.ID().GetText();
            VariablesDeclaradas.Add(varName);
            return base.VisitVariableDef(context);
        }

        public override object VisitIdExpr(FreyaParser.IdExprContext context)
        {
            var varName = context.ID().GetText();
            VariablesUsadas.Add(varName);
            return base.VisitIdExpr(context);
        }
    }
}
