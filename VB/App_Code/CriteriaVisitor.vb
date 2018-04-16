Imports DevExpress.Data.Filtering
Imports System
Imports System.Linq

Public Class CriteriaVisitor
    Inherits CriteriaPatcherBase

    Private Shared Function WrapIntoCustomFunction(ByVal param As CriteriaOperator) As CriteriaOperator
        Return New FunctionOperator(FunctionOperatorType.Custom, New ConstantValue("RemoveDiacritics"), CType(param, CriteriaOperator))
    End Function

    Public Shared Function Substitute(ByVal source As CriteriaOperator) As CriteriaOperator
        Dim v = source.ToString()
        Return (New CriteriaVisitor()).AcceptOperator(source)
    End Function

    Protected Overrides Function VisitFunction(ByVal theOperator As FunctionOperator) As CriteriaOperator
        If theOperator.OperatorType = FunctionOperatorType.StartsWith OrElse theOperator.OperatorType = FunctionOperatorType.EndsWith OrElse theOperator.OperatorType = FunctionOperatorType.Contains Then
            Return New FunctionOperator(theOperator.OperatorType, CriteriaVisitor.WrapIntoCustomFunction(theOperator.Operands(0)), CriteriaVisitor.WrapIntoCustomFunction(theOperator.Operands(1)))
        End If
        Return MyBase.VisitFunction(theOperator)
    End Function
End Class