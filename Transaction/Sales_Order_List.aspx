<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Sales_Order_List.aspx.cs" Inherits="com.pridish.Sales_Order_List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="style1">
        <tr>
            <td>
                <%--<asp:Button ID="Button1" runat="server" Height="65px" 
                    PostBackUrl="~/Transaction/add_Sales_Order.aspx" Text="Add Sales Order" 
                    Width="198px" />--%>
            </td>
        </tr>
        <tr>
            <td>
                <table class="style1">
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="style4" style="width: 687px">
                            &nbsp;</td>
                        <td class="style13" style="width: 215px">
                            <asp:TextBox ID="txt_Cust_Code" runat="server" Height="39px" Width="202px" 
                                AutoPostBack = "true" placeholder = "Search Customer Code" 
                                ontextchanged="txt_Cust_Code_TextChanged"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txt_Cust_Name" runat="server" Height="39px" Width="202px" 
                                AutoPostBack ="true" placeholder = "Search Company Name" 
                                ontextchanged="txt_Cust_Name_TextChanged"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="style4" style="width: 687px">
                            &nbsp;</td>
                        <td class="style13" style="width: 215px">
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
                        
                        <asp:BoundField DataField="Sales_Order_Number" HeaderText="Sales Order Number" ReadOnly="True" SortExpression="Sales_Order_Number" />
                        <asp:BoundField DataField="Sales_Order_Date" HeaderText="Sales Order Date " ReadOnly="True" SortExpression="Sales_Order_Date" />
                       
                        <asp:BoundField DataField="Customer_Code" HeaderText="Customer Code " ReadOnly="True" SortExpression="Customer_Code" />
                        <asp:BoundField DataField="Company_Name" HeaderText="Company Name" ReadOnly="True" SortExpression="Company_Name" />
                        <asp:BoundField DataField="Product_Number" HeaderText="No. Of Product" ReadOnly="True" SortExpression="Product_Number" />
                        <asp:BoundField DataField="G_Net_Amount" HeaderText="Net Amount" ReadOnly="True" SortExpression="G_Net_Amount" 
                        
                         HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" />
                      
                        <asp:TemplateField HeaderText = "Edit">
                            <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="gridright"></ItemStyle>
                            <HeaderStyle HorizontalAlign="Center" CssClass="gridright" />
                            <ItemTemplate>
                                <asp:ImageButton ID="cmdEdit" CommandName="RowEdit" runat="server" ToolTip="Edit"
                                    ImageUrl="~/Logo/icon-edit.png" CommandArgument='<%# Eval("Sid") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText = "S 2 DN">
                            <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="gridright"></ItemStyle>
                            <HeaderStyle HorizontalAlign="Center" CssClass="gridright" />
                            <ItemTemplate>
                                <asp:ImageButton ID="cmdEdit1" CommandName="RowEdit1" runat="server" ToolTip="Edit1"
                                    ImageUrl="~/Logo/icon-edit.png" CommandArgument='<%# Eval("Sid") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText = "S 2 PO">
                            <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="gridright"></ItemStyle>
                            <HeaderStyle HorizontalAlign="Center" CssClass="gridright" />
                            <ItemTemplate>
                                <asp:ImageButton ID="cmdEdit2" CommandName="RowEdit2" runat="server" ToolTip="Edit2"
                                    ImageUrl="~/Logo/icon-edit.png" CommandArgument='<%# Eval("Sid") %>' />
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
