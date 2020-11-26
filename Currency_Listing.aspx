<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Currency_Listing.aspx.cs" Inherits="com.pridish.Currency_Listing" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style1">
        <tr>
            <td colspan="4">
                <h4 class="card-title" 
                    style="box-sizing: border-box; outline: 0px; margin-top: 0px; margin-bottom: 10px; font-family: &quot;Nunito Sans&quot;, sans-serif; font-weight: 600; line-height: 1.2; color: rgb(62, 85, 105); font-size: 18px; position: relative; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial;">
                    Currency Master</h4>
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Button ID="Button1" runat="server" Text="Add Currency" Width="187px" 
                    onclick="Button1_Click" Height="72px" />
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="width: 693px">
                <br />
                <asp:Label ID="Label1" runat="server" Text=" Base Currency : OMR"></asp:Label>
                <br />
            </td>
            <td class="style9" style="width: 77px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:GridView ID="grdCurrencyList" OnPageIndexChanging = "pageindexchange" 
                    runat="server" Width="100%" AllowPaging ="true"  
                    CssClass=" grdContent selectedrow"  HeaderStyle-CssClass="header"
                    AutoGenerateColumns="False" OnRowCommand="grdCurrency_command" 
                    EmptyDataText="There are no data records to display." BackColor="#CCCCCC">
                    <AlternatingRowStyle CssClass="altrow" />
                    <SelectedRowStyle CssClass="selected" />
                    <Columns>
                        
                        <asp:BoundField DataField="Currency_Code" HeaderText="Currency Name" ReadOnly="True" SortExpression="Currency_Code" />
                        <asp:BoundField DataField="Exchange_Rate" HeaderText="Exchange Rate" ReadOnly="True" SortExpression="Exchange_Rate" 
                         HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" />
                      
                        <asp:TemplateField>
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
    </table>
</asp:Content>

