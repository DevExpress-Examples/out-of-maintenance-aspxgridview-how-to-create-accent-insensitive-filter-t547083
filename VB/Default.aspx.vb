Imports DevExpress.Data.Filtering
Imports System

Partial Public Class _Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Init(ByVal sender As Object, ByVal e As EventArgs)
        CriteriaOperator.RegisterCustomFunction(New RemoveDiacriticsFunction())
        If Not IsPostBack Then
            Grid.FilterExpression = "Contains([ProductName], 'Ros')"
        End If
    End Sub

    Protected Sub Grid_SubstituteFilter(ByVal sender As Object, ByVal e As DevExpress.Data.SubstituteFilterEventArgs)
        e.Filter = CriteriaVisitor.Substitute(e.Filter)
    End Sub
End Class