<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Payment_List.aspx.cs" Inherits="com.pridish.Payment_List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="style1">
        <tr>
            <td>
                <asp:Button ID="btn_add_payment" CssClass = "header" runat="server" Height="42px" 
                    style="font-weight: 700" Text="Add Online Payment" Width="195px" 
                    PostBackUrl="~/Payments.aspx" />
            </td>
        </tr>
        <tr>
            <td>
                <table class="style1">
                    <tr>
                        <td class="style3" style="width: 129px">
                            &nbsp;</td>
                        <td style="width: 663px">
                            &nbsp;</td>
                        <td class="style13">
                            <asp:TextBox ID="txt_Customer_Code" placeholder = "Search Customer Code" runat="server" Height="41px" Width="215px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txt_Invoice_Code" placeholder ="Search Invoice Number" runat="server" Height="41px" Width="215px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td class="style3" style="width: 129px">
                            &nbsp;</td>
                        <td style="width: 663px">
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
                <asp:GridView ID="grdCustomerList" runat="server" AutoGenerateColumns="False" 
                    CssClass=" grdContent selectedrow" 
                    EmptyDataText="There are no data records to display." 
                    HeaderStyle-CssClass="header" OnRowCommand="grdCustomer_command" 
                    Width="78%">
                    <Columns>
                        <asp:BoundField DataField="Customer_Code" HeaderText="Customer Code" 
                            ReadOnly="True" SortExpression="Customer_Code" />
                        <asp:BoundField DataField="Invoice_Code" HeaderText="Invoice No." 
                            ReadOnly="True" SortExpression="Invoice_Code" />
                        
                        <asp:BoundField DataField="Amount" HeaderText="Amount Collected" 
                            ReadOnly="True" SortExpression="Amount" />
                        <asp:TemplateField>
                            <ItemStyle CssClass="gridright" HorizontalAlign="Center" Width="5%" />
                            <HeaderStyle CssClass="gridright" HorizontalAlign="Center" />
                            <ItemTemplate>
                                <asp:ImageButton ID="cmdEdit" runat="server" 
                                    CommandArgument='<%# Eval("cid") %>' CommandName="RowEdit" 
                                    ImageUrl="~/Logo/icon-edit.png" ToolTip="Edit" />
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
