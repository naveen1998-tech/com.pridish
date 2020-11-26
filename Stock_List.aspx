<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Stock_List.aspx.cs" Inherits="com.pridish.Stock_List" %>
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
                <asp:Button ID="Button1" runat="server" Height="59px" style="font-weight: 700" 
                    Text="Add Stock" Width="215px" PostBackUrl="~/Add_Stock_Master.aspx" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="grdCustomerList" runat="server" Width="100%" CssClass=" grdContent selectedrow"  HeaderStyle-CssClass="header"
                    AutoGenerateColumns="False"
                    EmptyDataText="There are no data records to display.">
                    <Columns>
                        <asp:BoundField DataField="Product_Code" HeaderText="Product Code" ReadOnly="True" SortExpression="Product_Code" />
                        <asp:BoundField DataField="Product_Group" HeaderText="Product Group" ReadOnly="True" SortExpression="Product_Group" />
                        <asp:BoundField DataField="Product_Size" HeaderText="Product Size" ReadOnly="True" SortExpression="Product_Size" />
                        <asp:BoundField DataField="Product_Quantity" HeaderText="Product Quantity" ReadOnly="True" SortExpression="Product_Quantity" />
                        
                        
                    </Columns>
                </asp:GridView>
                
                </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
    </table>





</asp:Content>
