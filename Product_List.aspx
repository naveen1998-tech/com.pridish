<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Product_List.aspx.cs" Inherits="com.pridish.Product_List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="style1">
        <tr>
            <td>
                <asp:Button ID="Button1" runat="server" Height="67px" 
                    PostBackUrl="~/Add_Product_Master.aspx" Text="Add Product" Width="197px" />
            </td>
        </tr>
        <tr>
            <td>
                <table class="style1">
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="style11" style="width: 959px">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            <asp:TextBox ID="txt_Product_Name_Search" placeholder = "Search Product Name" 
                                runat="server" AutoPostBack="True" 
                                Height="41px" Width="215px" 
                                ontextchanged="txt_Product_Name_Search_TextChanged"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="style11" style="width: 959px">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="grdOfficeExpense" runat="server" Width="100%"  CssClass=" grdContent selectedrow"  HeaderStyle-CssClass="header"
                    AutoGenerateColumns="False" OnRowCommand="grdCustomer_command" EmptyDataText="There are no data records to display.">
                    <Columns>
                        
                        <asp:BoundField DataField="Product_Code" HeaderText="Product Code" ReadOnly="True" SortExpression="Product_Code" />
                        <asp:BoundField DataField="Product_Group" HeaderText="Product Group" ReadOnly="True" SortExpression="Product_Group" />
                        <asp:BoundField DataField="Product_Name" HeaderText="Product Name" ReadOnly="True" SortExpression="Product_Name" />
                        <asp:BoundField DataField="Product_Purchase_Price" HeaderText="Product Purchase Price" ReadOnly="True" SortExpression="Product_Purchase_Price" />
                        <asp:BoundField DataField="Product_Selling_Price" HeaderText="Product Selling Price" ReadOnly="True" SortExpression="Product_Selling_Price" 
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
    </table>
</asp:Content>
