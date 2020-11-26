<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Delivery_Note_List.aspx.cs" Inherits="com.pridish.Delivery_Note_List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="style1">
        <tr>
            <td>
                <%--<asp:Button ID="Button1" runat="server" Height="74px" 
                    PostBackUrl="~/Transaction/add_Delivery_Note.aspx" Text="Add Delivery Note" 
                    Width="246px" />--%>
            </td>
        </tr>
        <tr>
            <td>
                <table class="style1">
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="style4" style="width: 782px">
                            &nbsp;</td>
                        <td class="style13">
                            <asp:TextBox ID="txt_Customer_Code" runat="server" 
                                placeholder = "Search Customer Code"  Height="41px" Width="216px" 
                                AutoPostBack="True" ontextchanged="txt_Customer_Code_TextChanged"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txt_Customer_Name" runat="server" 
                                placeholder = "Search Customer Name" Height="41px" Width="216px" 
                                AutoPostBack="True" ontextchanged="txt_Customer_Name_TextChanged"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="style4" style="width: 782px">
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
                        
                        <asp:BoundField DataField="Delivery_Note_Number" HeaderText="Delivery Note Number" ReadOnly="True" SortExpression="Delivery_Note_Number" />
                        <asp:BoundField DataField="Delivery_Note_Num_Date" HeaderText="Delivery Note Date " ReadOnly="True" SortExpression="Delivery_Note_Num_Date" />
                        
                        <asp:BoundField DataField="Customer_Code" HeaderText="Customer Code " ReadOnly="True" SortExpression="Customer_Code" />
                        
                        <asp:BoundField DataField="Customer_Name" HeaderText="Customer Name" ReadOnly="True" SortExpression="Customer_Name" 
                        
                         HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" />
                         <asp:BoundField DataField="Product_Number" HeaderText="No. Of Product " ReadOnly="True" SortExpression="Product_Number" />
                      
                        <asp:TemplateField HeaderText = "Edit">
                            <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="gridright"></ItemStyle>
                            <HeaderStyle HorizontalAlign="Center" CssClass="gridright" />
                            <ItemTemplate>
                                <asp:ImageButton ID="cmdEdit" CommandName="RowEdit" runat="server" ToolTip="Edit"
                                    ImageUrl="~/Logo/icon-edit.png" CommandArgument='<%# Eval("Did") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText = "DN 2 CM">
                            <ItemStyle HorizontalAlign="Center" Width="8%" CssClass="gridright"></ItemStyle>
                            <HeaderStyle HorizontalAlign="Center" CssClass="gridright" />
                            <ItemTemplate>
                                <asp:ImageButton ID="cmdEdit1" CommandName="RowEdit1" runat="server" ToolTip="Edit1"
                                    ImageUrl="~/Logo/icon-edit.png" CommandArgument='<%# Eval("Did") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText ="DN 2 IN">
                            <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="gridright"></ItemStyle>
                            <HeaderStyle HorizontalAlign="Center" CssClass="gridright" />
                            <ItemTemplate>
                                <asp:ImageButton ID="cmdEdit2" CommandName="RowEdit2" runat="server" ToolTip="Edit2"
                                    ImageUrl="~/Logo/icon-edit.png" CommandArgument='<%# Eval("Did") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:TemplateField HeaderText ="DN 2 GRN">
                            <ItemStyle HorizontalAlign="Center" Width="7%" CssClass="gridright"></ItemStyle>
                            <HeaderStyle HorizontalAlign="Center" CssClass="gridright" />
                            <ItemTemplate>
                                <asp:ImageButton ID="cmdEdit3" CommandName="RowEdit3" runat="server" ToolTip="Edit3"
                                    ImageUrl="~/Logo/icon-edit.png" CommandArgument='<%# Eval("Did") %>' />
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
