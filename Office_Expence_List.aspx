<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Office_Expence_List.aspx.cs" Inherits="com.pridish.Office_Expence_List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="style1">
        <tr>
            <td>
                <asp:Button ID="Button1" runat="server" Height="62px" 
                    PostBackUrl="~/Add_office_Expense.aspx" Text="Add Office Expense" 
                    Width="198px" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="grdOfficeExpense" runat="server" Width="100%"  CssClass=" grdContent selectedrow"  HeaderStyle-CssClass="header"
                    AutoGenerateColumns="False"  EmptyDataText="There are no data records to display.">
                    <Columns>
                        
                        <asp:BoundField DataField="Expense_Type" HeaderText="Expense Type" ReadOnly="True" SortExpression="Expense_Type" />
                        <asp:BoundField DataField="Expense_Transaction_Details" HeaderText="Expense Transaction Details" ReadOnly="True" SortExpression="Expense_Transaction_Details" />
                        <asp:BoundField DataField="Transaction_Date" HeaderText="Transaction Date" ReadOnly="True" SortExpression="Transaction_Date" />
                        <asp:BoundField DataField="Amount" HeaderText="Amount" ReadOnly="True" SortExpression="Amount" 
                         HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" />
                      
                        

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
