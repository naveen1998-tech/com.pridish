<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="CashMemo_Payment_List.aspx.cs" Inherits="com.pridish.CashMemo_Payment_List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="style1">
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <table class="style1">
                    <tr>
                        <td style="width: 237px">
                <asp:Button ID="btn_add_Cheque_payment" CssClass = "header" runat="server" Height="42px" 
                    style="font-weight: 700" Text="Add Cash Memo Payment" Width="220px" 
                    PostBackUrl="~/CashMemo_payment.aspx" />
                        </td>
                        <td class="style2" style="width: 489px">
                            &nbsp;</td>
                        <td style="width: 30px">
                            &nbsp;</td>
                        <td>
                            <asp:TextBox ID="txt_Customer_Code" placeholder = "Search Customer Code" runat="server" Height="41px" Width="215px"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txt_Invoice_Code" placeholder ="Search Invoice Number" runat="server" Height="41px" Width="215px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 237px">
                            &nbsp;</td>
                        <td class="style2" style="width: 489px">
                            &nbsp;</td>
                        <td style="width: 30px">
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
                <asp:GridView ID="grdCustomerList" runat="server" AutoGenerateColumns="False" 
                    CssClass=" grdContent selectedrow" 
                    EmptyDataText="There are no data records to display." 
                    HeaderStyle-CssClass="header" OnRowCommand="grdCustomer_command" 
                    Width="78%">
                    <Columns>
                        <asp:BoundField DataField="Customer_Code" HeaderText="Customer Code" 
                            ReadOnly="True" SortExpression="Customer_Code" />
                        <asp:BoundField DataField="CashMemo_No" HeaderText="Cash Memo No." 
                            ReadOnly="True" SortExpression="CashMemo_No" />
                        
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
