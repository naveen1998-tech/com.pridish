<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="GRV_List.aspx.cs" Inherits="com.pridish.GRV_List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="style1">
        <tr>
            <td>
                <%--<asp:Button ID="Button1" runat="server" Height="75px" 
                    PostBackUrl="~/Transaction/add_Grv_Form.aspx" Text="Add GRV" Width="228px" />--%>
            </td>
        </tr>
        <tr>
            <td>
                <table class="style1">
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="style11" style="width: 803px">
                            &nbsp;</td>
                        <td class="style13" style="width: 222px">
                            <asp:TextBox ID="txt_Vendor_Code" placeholder ="Search Vendor Code" 
                                AutoPostBack = "true" runat="server" Height="41px" Width="215px" 
                                ontextchanged="txt_Vendor_Code_TextChanged"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txt_Vendor_Company_Name" 
                                placeholder = "Search Vendor Company " AutoPostBack = "true" runat="server" 
                                Height="41px" Width="215px" ontextchanged="txt_Vendor_Company_Name_TextChanged"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="style11" style="width: 803px">
                            &nbsp;</td>
                        <td class="style13" style="width: 222px">
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
                        
                        <asp:BoundField DataField="GRV_Number" HeaderText=" GRV Number" ReadOnly="True" SortExpression="GRV_Number" />
                        <asp:BoundField DataField="GRV_Date" HeaderText=" GRV Date " ReadOnly="True" SortExpression="GRV_Date" />
                        
                        <asp:BoundField DataField="Vendor_Code" HeaderText="Vendor Code" ReadOnly="True" SortExpression="Vendor_Code" />
                       
                        <asp:BoundField DataField="Vendor_Company_Name" HeaderText="Vendor Company Name" ReadOnly="True" SortExpression="Vendor_Company_Name" />
                        <asp:BoundField DataField="product_Number" HeaderText="No. Of Product" ReadOnly="True" SortExpression="product_Number" />
                        <asp:BoundField DataField="Net_Amount" HeaderText="Net Amount" ReadOnly="True" SortExpression="Net_Amount" 
                        
                         HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" />
                      
                        <asp:TemplateField>
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
        <tr>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
