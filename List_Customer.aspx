<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="List_Customer.aspx.cs" Inherits="com.pridish.List_Customer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style1">
        <tr>
            <td>
                <h4 class="card-title" 
                    style="box-sizing: border-box; outline: 0px; margin-top: 0px; margin-bottom: 10px; font-family: &quot;Nunito Sans&quot;, sans-serif; font-weight: 600; line-height: 1.2; color: rgb(62, 85, 105); font-size: 18px; position: relative; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial;">
                    Customer Master</h4>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Add_Customer" runat="server" Text="Add Customer" 
                    Width="192px" onclick="Add_Customer_Click" Height="67px" />
            </td>
        </tr>
        <tr>
            <td>
                <table class="style1">
                    <tr>
                        <td style="width: 1303px">
                            &nbsp;</td>
                        <td class="style2" style="width: 1404px">
                            &nbsp;</td>
                        <td class="style2" style="width: 164px">
                            <asp:Button ID="btn_Search" runat="server" onclick="btn_Search_Click" 
                                Text="Search" Width="114px" Height="42px" />
                        </td>
                        <td>
                            <asp:TextBox ID="txt_Search" runat="server" Placeholder = "Search Customer Name" AutoPostBack ="true" style="margin-left: 0px" 
                                Width="215px" ontextchanged="txt_Search_TextChanged" Height="41px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 1303px">
                            &nbsp;</td>
                        <td class="style2" style="width: 1404px">
                            &nbsp;</td>
                        <td class="style2" style="width: 164px">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="grdCustomerList" runat="server" Width="100%"  CssClass=" grdContent selectedrow"  HeaderStyle-CssClass="header"
                    AutoGenerateColumns="False" OnRowCommand="grdCustomer_command" EmptyDataText="There are no data records to display.">
                    <Columns>
                        <asp:BoundField DataField="Customer_Code" HeaderText="Customer Code" ReadOnly="True" SortExpression="Customer_Code" />
                        <asp:BoundField DataField="Customer_Name" HeaderText="Customer Name" ReadOnly="True" SortExpression="Customer_Name" />
                        <asp:BoundField DataField="Email_Id" HeaderText="Email" ReadOnly="True" SortExpression="Email_Id" />
                        <asp:BoundField DataField="Mobile_Number" HeaderText="Mobile" ReadOnly="True" SortExpression="Mobile_Number" />
                        <asp:BoundField DataField="Credit_Limit" HeaderText="Credit Limit" ReadOnly="True" SortExpression="Credit_Limit" />
                        <asp:BoundField DataField="Credit_Terms" HeaderText="Credit Term" ReadOnly="True" SortExpression="Credit_Terms" 
                        
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
