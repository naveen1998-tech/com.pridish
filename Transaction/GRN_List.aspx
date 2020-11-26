<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="GRN_List.aspx.cs" Inherits="com.pridish.GRN_List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="style1">
        <tr>
            <td>
                <%--<asp:Button ID="Button1" runat="server" Height="78px" 
                    PostBackUrl="~/Transaction/add_Goods_Return.aspx" Text="Add GRN" 
                    Width="223px" />--%>
            </td>
        </tr>
        <tr>
            <td>
                <table class="style1">
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="style11" style="width: 795px">
                            &nbsp;</td>
                        <td class="style13" style="width: 223px">
                            <asp:TextBox ID="txt_Customer_Code" placeholder ="Search Customer Code" 
                                runat="server" Height="41px" Width="215px" AutoPostBack="True" 
                                ontextchanged="txt_Customer_Code_TextChanged"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txt_Company_Name" placeholder ="Search Company Name" 
                                runat="server" Height="41px" Width="215px" AutoPostBack="True" 
                                ontextchanged="txt_Company_Name_TextChanged"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="style11" style="width: 795px">
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
                
                <asp:GridView ID="grdCurrencyList" runat="server" Width="100%" CssClass=" grdContent selectedrow"  HeaderStyle-CssClass="header"
                    AutoGenerateColumns="False" OnRowCommand="grdCurrency_command" EmptyDataText="There are no data records to display.">
                    <Columns>
                        
                        <asp:BoundField DataField="GRN_Number" HeaderText=" GRN Number" ReadOnly="True" SortExpression="GRN_Number" />
                        <asp:BoundField DataField="GRN_Date" HeaderText=" GRN Date " ReadOnly="True" SortExpression="GRN_Date" />
                        
                        <asp:BoundField DataField="Customer_Code" HeaderText="Customer Code" ReadOnly="True" SortExpression="Customer_Code" />
                       
                        <asp:BoundField DataField="Company_Name" HeaderText="Company Name" ReadOnly="True" SortExpression="Company_Name" />
                        <asp:BoundField DataField="product_Number" HeaderText="No. Of Product" ReadOnly="True" SortExpression="product_Number" />
                        <asp:BoundField DataField="Net_Amount" HeaderText="Net Amount" ReadOnly="True" SortExpression="Net_Amount" 
                        
                         HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" />
                      
                        <asp:TemplateField HeaderText = "Edit">
                            <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="gridright"></ItemStyle>
                            <HeaderStyle HorizontalAlign="Center" CssClass="gridright" />
                            <ItemTemplate>
                                <asp:ImageButton ID="cmdEdit" CommandName="RowEdit" runat="server" ToolTip="Edit"
                                    ImageUrl="~/Logo/icon-edit.png" CommandArgument='<%# Eval("gid") %>' />
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
