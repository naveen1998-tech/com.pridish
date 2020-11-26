<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Product_Order_List.aspx.cs" Inherits="com.pridish.Product_Order_List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="style1">
        <tr>
            <td>
                <%--<asp:Button ID="Button1" runat="server" Height="73px" 
                    PostBackUrl="~/Transaction/Add_Purchase_Order.aspx" Text="Add Purchase Order" 
                    Width="191px" />--%>
            </td>
        </tr>
        <tr>
            <td>
                <table class="style1">
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="style11" style="width: 798px">
                            &nbsp;</td>
                        <td class="style13" style="width: 223px">
                            <asp:TextBox ID="txt_Vendor_Code" runat="server" Height="41px" Width="214px" 
                                placeholder ="Search Vendor Code" AutoPostBack="True" 
                                ontextchanged="txt_Vendor_Code_TextChanged"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txt_Vendor_Company_Name" runat="server" Height="42px" 
                                placeholder = "Search Vendor Company Name" Width="216px" AutoPostBack="True" 
                                ontextchanged="txt_Vendor_Company_Name_TextChanged"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="style11" style="width: 798px">
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
                        
                        <asp:BoundField DataField="PO_Number" HeaderText="Purchase Order Number" ReadOnly="True" SortExpression="PO_Number" />
                        <asp:BoundField DataField="PO_Date" HeaderText="Purchase Order Date " ReadOnly="True" SortExpression="PO_Date" />
                        
                        <asp:BoundField DataField="Vendor_Code" HeaderText="Vendor Code " ReadOnly="True" SortExpression="Vendor_Code" />
                        <asp:BoundField DataField="V_Company_Name" HeaderText="Vendor Company Name " ReadOnly="True" SortExpression="V_Company_Name" />
                        <asp:BoundField DataField="Product_Number" HeaderText="No. Of Product " ReadOnly="True" SortExpression="Product_Number" />
                        <asp:BoundField DataField="G_Net_Amount" HeaderText="Net Amount " ReadOnly="True" SortExpression="G_Net_Amount" 
                        
                         HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" />
                      
                        <asp:TemplateField HeaderText = "Edit">
                            <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="gridright"></ItemStyle>
                            <HeaderStyle HorizontalAlign="Center" CssClass="gridright" />
                            <ItemTemplate>
                                <asp:ImageButton ID="cmdEdit" CommandName="RowEdit" runat="server" ToolTip="Edit"
                                    ImageUrl="~/Logo/icon-edit.png" CommandArgument='<%# Eval("Pid") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText = "C 2 MRN">
                            <ItemStyle HorizontalAlign="Center" Width="10%" CssClass="gridright"></ItemStyle>
                            <HeaderStyle HorizontalAlign="Center" CssClass="gridright" />
                            <ItemTemplate>
                                <asp:ImageButton ID="cmdEdit1" CommandName="RowEdit1" runat="server" ToolTip="Edit1"
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
    </table>
</asp:Content>
