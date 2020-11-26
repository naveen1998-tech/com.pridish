<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Sales_Order_List.aspx.cs" Inherits="com.pridish.Sales_Order_List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="style1">
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="grdSalesList" runat="server" AutoGenerateColumns="False" 
                    CssClass="table table-striped table-bordered table-hover" 
                    EmptyDataText="There are no data records to display." 
                    OnRowCommand="grdCurrency_command" Width="100%">
                    <Columns>
                        <asp:BoundField DataField="Sales_Order_Number" HeaderText="Sales Order Number" 
                            ReadOnly="True" SortExpression="Sales_Order_Number" />
                        <asp:BoundField DataField="Sales_Order_Date" HeaderText="Sales Order Date " 
                            ReadOnly="True" SortExpression="Sales_Order_Date" />
                        <asp:BoundField DataField="Customer_Code" HeaderText="Customer Code" 
                            ReadOnly="True" SortExpression="Customer_Code" />
                        <asp:BoundField DataField="Company_Name" HeaderStyle-CssClass="visible-lg" 
                            HeaderText="Company Name" ItemStyle-CssClass="visible-lg" ReadOnly="True" 
                            SortExpression="Company_Name" />
                        <asp:TemplateField>
                            <ItemStyle CssClass="gridright" HorizontalAlign="Center" Width="5%" />
                            <HeaderStyle CssClass="gridright" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:ImageButton ID="cmdEdit" runat="server" 
                                    CommandArgument='<%# Eval("Sid") %>' CommandName="RowEdit" 
                                    ImageUrl="~/Logo/icon-edit.png" ToolTip="Edit" />
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
