<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Cash_Memo_List.aspx.cs" Inherits="com.pridish.Cash_Memo_List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <table class="style1">
        <tr>
            <td>
                <%--<asp:Button ID="Button1" runat="server" Height="74px" 
                    PostBackUrl="~/Transaction/add_Cash_Memo.aspx" Text="Add Cash Memo" 
                    Width="281px" />--%>
            </td>
        </tr>
        <tr>
            <td>
                <table class="style1">
                    <tr>
                        <td style="width: 99px">
                            &nbsp;</td>
                        <td class="style14" style="width: 671px">
                            &nbsp;</td>
                        <td class="style13" style="width: 223px">
                            <asp:TextBox ID="txt_Cust_Code" placeholder ="Search Company Name " 
                                AutoPostBack ="true" runat="server" Height="41px" Width="215px" 
                                ontextchanged="txt_Cust_Code_TextChanged"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txt_Company_Name" placeholder ="Search Company Name " 
                                AutoPostBack ="true" runat="server" Height="41px" Width="215px" 
                                ontextchanged="txt_Company_Name_TextChanged"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 99px">
                            &nbsp;</td>
                        <td class="style14" style="width: 671px">
                            &nbsp;</td>
                        <td class="style13" style="width: 223px">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                
                <asp:GridView ID="grdCurrencyList" runat="server" Width="100%"  CssClass=" grdContent selectedrow"  HeaderStyle-CssClass="header"
                    AutoGenerateColumns="False" OnRowCommand="grdCurrency_command" EmptyDataText="There are no data records to display.">
                    <Columns>
                        
                        <asp:BoundField DataField="Cash_Memo_Number" HeaderText="Cash Memo Number" ReadOnly="True" SortExpression="Cash_Memo_Number" />
                        <asp:BoundField DataField="Case_Memo_Date" HeaderText="Cash Memo Date " ReadOnly="True" SortExpression="Case_Memo_Date" />
                        
                        <asp:BoundField DataField="Customer_Code" HeaderText="Customer Code" ReadOnly="True" SortExpression="Customer_Code" />
                        <asp:BoundField DataField="Company_Name" HeaderText="Company Name" ReadOnly="True" SortExpression="Company_Name" />
                        <asp:BoundField DataField="Product_Number" HeaderText="No. Of Product" ReadOnly="True" SortExpression="Product_Number" />
                        
                        
                        <asp:BoundField DataField="Net_Amount" HeaderText="Net Amount" ReadOnly="True" SortExpression="Net_Amount" 
                        
                         HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" />
                      
                        <asp:TemplateField HeaderText ="Edit">
                            <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="gridright"></ItemStyle>
                            <HeaderStyle HorizontalAlign="Center" CssClass="gridright" />
                            <ItemTemplate>
                                <asp:ImageButton ID="cmdEdit" CommandName="RowEdit" runat="server" ToolTip="Edit"
                                    ImageUrl="~/Logo/icon-edit.png" CommandArgument='<%# Eval("cid") %>' />
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
