<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Invoice_List.aspx.cs" Inherits="com.pridish.Invoice_List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="style1">
        <tr>
            <td>
                <%--<asp:Button ID="Button1" runat="server" Height="74px" 
                    PostBackUrl="~/Transaction/add_Invoice.aspx" Text="Add Invoice" Width="202px" />--%>
            </td>
        </tr>
        <tr>
            <td>
                <table class="style1">
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="style4" style="width: 795px">
                            &nbsp;</td>
                        <td class="style13">
                            <asp:TextBox ID="txt_Cust_Code" placeholder = "Search Customer Code" 
                                runat="server" Height="40px" Width="215px" 
                                ontextchanged="txt_Cust_Code_TextChanged" AutoPostBack="True"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txt_Cumpany_Name" placeholder = "Search Company Name" 
                                runat="server" Height="40px" Width="215px"  
                                ontextchanged="txt_Cumpany_Name_TextChanged" AutoPostBack="True"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="style4" style="width: 795px">
                            &nbsp;</td>
                        <td class="style13">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                
                <asp:GridView ID="grdCurrencyList" runat="server" Width="100%" CssClass=" grdContent selectedrow"  HeaderStyle-CssClass="header"
                    AutoGenerateColumns="False" OnRowCommand="grdCurrency_command" EmptyDataText="There are no data records to display.">
                    <Columns>
                        
                        <asp:BoundField DataField="Invoice_number" HeaderText="Invoice Number" ReadOnly="True" SortExpression="Invoice_number" />
                        <asp:BoundField DataField="Invoice_Date" HeaderText="Invoice Date " ReadOnly="True" SortExpression="Invoice_Date" />
                        
                        <asp:BoundField DataField="Customer_Code" HeaderText="Customer Code" ReadOnly="True" SortExpression="Customer_Code" />
                        <asp:BoundField DataField="Company_Name" HeaderText="Company Name" ReadOnly="True" SortExpression="Company_Name" />
                        <asp:BoundField DataField="Porduct_Number" HeaderText="No. Of Product" ReadOnly="True" SortExpression="Porduct_Number" />
                        
                        
                        <asp:BoundField DataField="G_Net_Amount" HeaderText=" Net Amount" ReadOnly="True" SortExpression="G_Net_Amount" 
                        
                         HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" />
                      
                        <asp:TemplateField>
                            <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="gridright"></ItemStyle>
                            <HeaderStyle HorizontalAlign="Center" CssClass="gridright" />
                            <ItemTemplate>
                                <asp:ImageButton ID="cmdEdit" CommandName="RowEdit" runat="server" ToolTip="Edit"
                                    ImageUrl="~/Logo/icon-edit.png" CommandArgument='<%# Eval("Pid") %>' />
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
        <tr>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
