<!-- default file list -->
*Files to look at*:

* [CriteriaPatcherBase.cs](./CS/App_Code/CriteriaPatcherBase.cs) (VB: [CriteriaPatcherBase.vb](./VB/App_Code/CriteriaPatcherBase.vb))
* [CriteriaVisitor.cs](./CS/App_Code/CriteriaVisitor.cs) (VB: [CriteriaVisitor.vb](./VB/App_Code/CriteriaVisitor.vb))
* [RemoveDiacriticsFunction.cs](./CS/App_Code/RemoveDiacriticsFunction.cs) (VB: [RemoveDiacriticsFunction.vb](./VB/App_Code/RemoveDiacriticsFunction.vb))
* [Default.aspx](./CS/Default.aspx) (VB: [Default.aspx](./VB/Default.aspx))
* [Default.aspx.cs](./CS/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/Default.aspx.vb))
<!-- default file list end -->
# ASPxGridView - How to create Accent Insensitive filter
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/t547083/)**
<!-- run online end -->


This example demonstrates how to create a <a href="https://documentation.devexpress.com/eXpressAppFramework/113480/Concepts/Filtering/Custom-Function-Criteria-Operators">custom function criteria operator</a> that removes all diacritic symbols from the specified string value. <br>Using the <a href="https://www.devexpress.com/Support/Center/Question/Details/T320172/the-base-implementation-of-the-iclientcriteriavisitor-interface-for-the-criteriaoperator">CriteriaPatchBase's</a> class descendant expand filtering capabilities and play more complicated scenarios. The simple implementation of this class (<strong>CriteriaVisitor</strong>) is presented in this example.<br>The <a href="https://documentation.devexpress.com/#AspNet/DevExpressWebASPxGridBase_SubstituteFiltertopic">ASPxGridView.SubstituteFilter</a> event handler is used to apply accent insensitive filter.<br><br><strong>HOW TO APPLY:<br></strong>1. Add all 3 files from the App_Code folder: <em>CriteriaPatcherBase.cs</em>, <em>CriteriaVisitor.cs, </em>RemoveDiacriticsFunction.cs;<br>2. Register the custom function criteria operator when the Page's Init event is raised in the following manner:<br>


```cs
CriteriaOperator.RegisterCustomFunction(new RemoveDiacriticsFunction());
```


 3. Substitute ASPxGridView's filter in the <a href="https://documentation.devexpress.com/#AspNet/DevExpressWebASPxGridBase_SubstituteFiltertopic">ASPxGridView.SubstituteFilter</a> event handler as follows:<br>


```cs
protected void Grid_SubstituteFilter(object sender, DevExpress.Data.SubstituteFilterEventArgs e) {
        e.Filter = CriteriaVisitor.Substitute(e.Filter);
    }
```


<br><br><strong>See also:<br></strong><a href="https://www.devexpress.com/Support/Center/Example/Details/T546944/aspxgridview-how-to-apply-custom-function-filter-criteria-operator">ASPxGridView - How to apply Custom Function Filter Criteria Operator</a><br><a href="https://www.devexpress.com/Support/Center/Question/Details/T320172/the-base-implementation-of-the-iclientcriteriavisitor-interface-for-the-criteriaoperator">The base implementation of the IClientCriteriaVisitor interface for the CriteriaOperator expression patcher</a>


<h3>Description</h3>

The&nbsp;<strong>CriteriaVisitor </strong>class<strong>&nbsp;</strong>has overridden&nbsp;method&nbsp;<strong><em>VisitFunction</em></strong>&nbsp;that wraps the operands into custom function criteria operator (<strong>RemoveDiacriticsFunction</strong>) if the operator's type is comparing string operands.<br>The&nbsp;<strong>RemoveDiacriticsFunction&nbsp;</strong>class has the&nbsp;<strong><em>Evaluate</em></strong><strong>&nbsp;</strong>method which returns the string without an accent.

<br/>


