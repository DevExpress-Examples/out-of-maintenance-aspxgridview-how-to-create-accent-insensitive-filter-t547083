using DevExpress.Data.Filtering;
using System;
using System.Linq;

public class CriteriaVisitor : CriteriaPatcherBase {
    private static CriteriaOperator WrapIntoCustomFunction(CriteriaOperator param) {
        return new FunctionOperator(FunctionOperatorType.Custom,
            new ConstantValue("RemoveDiacritics"), (CriteriaOperator)param);
    }

    public static CriteriaOperator Substitute(CriteriaOperator source) {
        var v = source.ToString();
        return new CriteriaVisitor().AcceptOperator(source);
    }

    protected override CriteriaOperator VisitFunction(FunctionOperator theOperator) {
        if(theOperator.OperatorType == FunctionOperatorType.StartsWith ||
            theOperator.OperatorType == FunctionOperatorType.EndsWith ||
            theOperator.OperatorType == FunctionOperatorType.Contains)
            return new FunctionOperator(theOperator.OperatorType,
                CriteriaVisitor.WrapIntoCustomFunction(theOperator.Operands[0]),
                CriteriaVisitor.WrapIntoCustomFunction(theOperator.Operands[1]));
        return base.VisitFunction(theOperator);
    }
}