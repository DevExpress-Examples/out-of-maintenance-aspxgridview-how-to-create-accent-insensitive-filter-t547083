using DevExpress.Data.Filtering;
using System;

public partial class _Default : System.Web.UI.Page {
    protected void Page_Init(object sender, EventArgs e) {
        CriteriaOperator.RegisterCustomFunction(new RemoveDiacriticsFunction());
        if(!IsPostBack)
            Grid.FilterExpression = "Contains([ProductName], 'Ros')";
    }

    protected void Grid_SubstituteFilter(object sender, DevExpress.Data.SubstituteFilterEventArgs e) {
        e.Filter = CriteriaVisitor.Substitute(e.Filter);
    }
}