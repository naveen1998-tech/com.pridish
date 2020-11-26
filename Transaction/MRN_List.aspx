<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="MRN_List.aspx.cs" Inherits="com.pridish.MRN_List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="style1">
        <tr>
            <td>
                <%--<asp:Button ID="Button1" runat="server" Height="77px" 
                    PostBackUrl="~/Transaction/add_Material_Received.aspx" Text="Add MRN" 
                    Width="208px" />--%>
            </td>
        </tr>
        <tr>
            <td>
                <table class="style1">
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="style13" style="width: 788px">
                            &nbsp;</td>
                        <td style="width: 230px">
                            <asp:TextBox ID="txt_Vendor_Code" placeholder = "Search Vendor Code"  
                                runat="server" Height="41px" Width="215px" AutoPostBack="True" 
                                ontextchanged="txt_Vendor_Code_TextChanged" ></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txt_Vendor_Name" placeholder = "Search Vendor Name" 
                                runat="server" Height="41px" Width="215px" AutoPostBack="True" 
                                ontextchanged="txt_Vendor_Name_TextChanged" ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="style13" style="width: 788px">
                            &nbsp;</td>
                        <td style="width: 230px">
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
                        
                        <asp:BoundField DataField="MRN_Number" HeaderText=" MRN Number" ReadOnly="True" SortExpression="MRN_Number" />
                        <asp:BoundField DataField="MRN_Date" HeaderText=" MRN Date " ReadOnly="True" SortExpression="MRN_Date" />
                        
                        <asp:BoundField DataField="Vendor_Code" HeaderText="Vendor Code" ReadOnly="True" SortExpression="Vendor_Code" />
                        <asp:BoundField DataField="Vendor_Name" HeaderText="Vandor Name" ReadOnly="True" SortExpression="Vendor_Name" />
                        <asp:BoundField DataField="Product_Number" HeaderText="No. Of Product" ReadOnly="True" SortExpression="Product_Number" />
                        <asp:BoundField DataField="Net_Amount" HeaderText="Net Amount" ReadOnly="True" SortExpression="Net_Amount" 
                        
                         HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" />
                      
                        <asp:TemplateField HeaderText = "Edit">
                            <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="gridright"></ItemStyle>
                            <HeaderStyle HorizontalAlign="Center" CssClass="gridright" />
                            <ItemTemplate>
                                <asp:ImageButton ID="cmdEdit" CommandName="RowEdit" runat="server" ToolTip="Edit"
                                    ImageUrl="~/Logo/icon-edit.png" CommandArgument='<%# Eval("mid") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText = "MRN 2 GRV">
                            <ItemStyle HorizontalAlign="Center" Width="8%" CssClass="gridright"></ItemStyle>
                            <HeaderStyle HorizontalAlign="Center" CssClass="gridright" />
                            <ItemTemplate>
                                <asp:ImageButton ID="cmdEdit1" CommandName="RowEdit1" runat="server" ToolTip="Edit1"
                                    ImageUrl="~/Logo/icon-edit.png" CommandArgument='<%# Eval("mid") %>' />
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
