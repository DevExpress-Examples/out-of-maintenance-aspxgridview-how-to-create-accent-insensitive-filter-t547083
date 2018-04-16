<%@ Page Language="vb" AutoEventWireup="true" CodeFile="Default.aspx.vb" Inherits="_Default" %>

<%@ Register assembly="DevExpress.Web.v17.1, Version=17.1.5.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web" tagprefix="dx" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>ASPxGridView - How to create Accent Insensitive filter</title>
</head>
<body>
    <h2>ASPxGridView - How to create Accent Insensitive filter</h2>
    <form id="form1" runat="server">
        <div>
            <dx:ASPxGridView ID="Grid" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1"
                 OnSubstituteFilter="Grid_SubstituteFilter">
                <Columns>
  	  	    <dx:GridViewDataTextColumn FieldName="ProductName" Settings-AutoFilterCondition="Contains" />
                    <dx:GridViewDataTextColumn FieldName="UnitPrice" />
                    <dx:GridViewDataTextColumn FieldName="UnitsInStock" />
                    <dx:GridViewDataCheckColumn FieldName="Discontinued"  />
                </Columns>
                <Settings ShowFilterRow="true" />
            </dx:ASPxGridView>
            <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" 
                ProviderName="<%$ ConnectionStrings:ConnectionString.ProviderName %>" 
                SelectCommand="SELECT [ProductName], [UnitPrice], [UnitsInStock], [Discontinued] FROM [Products]"/>
        </div>
    </form>
</body>
</html>