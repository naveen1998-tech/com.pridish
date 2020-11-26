<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Quotation_List.aspx.cs" Inherits="com.pridish.Quotation_List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="style1">
        <tr>
            <td>
                <asp:Button ID="Button1" runat="server" CssClass="header" Height="61px" Text="Add Quotation" 
                    Width="177px" PostBackUrl="~/Transaction/add_Quotation.aspx" />
            </td>
        </tr>
        <tr>
            <td>
                <table class="style1">
                    <tr>
                        <td style="width: 693px">
                            &nbsp;</td>
                        <td class="style3" style="width: 118px">
                            <%--<asp:Button ID="btn_Search" runat="server" Height="45px" Text="Button" 
                                Width="138px" onclick="btn_Search_Click" />--%>
                        </td>
                        <td class="style14" style="width: 207px">
                            <asp:TextBox ID="txt_SearchName" runat="server" Height="33px" Width="193px" 
                                AutoPostBack = "true" placeholder ="Search Customer Name " 
                                ontextchanged="txt_SearchName_TextChanged" ></asp:TextBox>
                                
                        </td>
                        <td>
                            <asp:TextBox ID="txt_Search" runat="server" Height="33px" Width="194px" placeholder ="Search Customer Code " 
                                AutoPostBack = "true" ontextchanged="txt_Search_TextChanged"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 693px">
                            &nbsp;</td>
                        <td class="style3" style="width: 118px">
                            &nbsp;</td>
                        <td class="style14" style="width: 207px">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                
                <asp:GridView ID="grdCurrencyList" runat="server" Width="100%" 
                     CssClass=" grdContent selectedrow"  HeaderStyle-CssClass="header"   
                    AutoGenerateColumns="False" OnRowCommand="grdCurrency_command" 
                    EmptyDataText="There are no data records to display." >
                    <Columns>
                        
                        <asp:BoundField DataField="Quotation_Number" HeaderText="Quotation Number" ReadOnly="True"  SortExpression="Quotation_Number" />
                        <asp:BoundField DataField="Quotation_Number_Date" HeaderText="Quotation Date " ReadOnly="True" SortExpression="Quotation_Number_Date" />
                        
                        <asp:BoundField DataField="Customer_Code" HeaderText="Customer Code " ReadOnly="True" SortExpression="Customer_Code" />
                        <asp:BoundField DataField="Customer_Name" HeaderText="Customer Name " ReadOnly="True" SortExpression="Customer_Name" />
                        <asp:BoundField DataField="product_Number" HeaderText="No. Of Product " ReadOnly="True" SortExpression="product_Number" />
                        <asp:BoundField DataField="Q_Net_Amount" HeaderText="Net Amount" ReadOnly="True" SortExpression="Q_Net_Amount" 
                        
                         HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" />
                      
                        <asp:TemplateField HeaderText = "Edit">
                            <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="gridright"></ItemStyle>
                            <HeaderStyle HorizontalAlign="Center" CssClass="gridright" />
                            <ItemTemplate>
                                <asp:ImageButton ID="cmdEdit" CommandName="RowEdit" runat="server" ToolTip="Edit"
                                    ImageUrl="~/Logo/icon-edit.png" CommandArgument='<%# Eval("Qid") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText ="C 2 S ">
                            <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="gridright"></ItemStyle>
                            <HeaderStyle HorizontalAlign="Center" CssClass="gridright" />
                            <ItemTemplate>
                                <asp:ImageButton ID="cmdEdit1" CommandName="ConvertQuotationToSales" runat="server" ToolTip="Edit"
                                    ImageUrl="~/Logo/icon-edit.png" CommandArgument='<%# Eval("Qid") %>' />
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
