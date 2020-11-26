<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Company_Setting_List.aspx.cs" Inherits="com.pridish.Company_Setting_List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="style1">
        <tr>
            <td>
                &nbsp;</td>
            <td style="width: 191px">
                &nbsp;</td>
            <td style="width: 971px">
                
                <asp:GridView ID="grdCustomerList" runat="server" Width="84%" CssClass=" grdContent selectedrow"  HeaderStyle-CssClass="header"
                    AutoGenerateColumns="False" OnRowCommand="grdCustomer_command" 
                    EmptyDataText="There are no data records to display.">
                    <Columns>
                        <asp:BoundField DataField="Comapny_Code" HeaderText="Company Code" ReadOnly="True" SortExpression="Comapny_Code" />
                        <asp:BoundField DataField="Conpany_Name" HeaderText="Company Name" ReadOnly="True" SortExpression="Conpany_Name" />
                        <asp:BoundField DataField="Email" HeaderText="Email" ReadOnly="True" SortExpression="Email" />
                        <asp:BoundField DataField="Contact_Person" HeaderText="Contact Person" ReadOnly="True" SortExpression="Contact_Person" />
                        
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
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td style="width: 191px">
                &nbsp;</td>
            <td style="width: 971px">
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
