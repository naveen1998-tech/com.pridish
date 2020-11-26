<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Currency_Form.aspx.cs" Inherits="com.pridish.Currency_Form" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style1">
        <tr>
            <td style="height: 39px" colspan="6">
               <h1> Currency Master</h1></td>
        </tr>
        <tr>
            <td colspan="6">
                <br />
                <h3> Currency</h3></td>
        </tr>
        <tr>
            <td class="style4" style="width: 929px">
                &nbsp;</td>
            <td class="style2" style="width: 163px">
                <br />
                <asp:Label ID="Label1" runat="server" Text="Currency"></asp:Label>
            </td>
            <td colspan="3" style="width: 554px">
                <br />
                <asp:DropDownList ID="ddl_Currency1" runat="server" Height="56px" Width="379px"  
                    DataTextField="cc" DataValueField="ID">
                    <asp:ListItem Text="Select" Value="0" ></asp:ListItem>
                </asp:DropDownList>
                <br />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4" style="width: 929px">
                &nbsp;</td>
            <td class="style2" style="width: 163px">
                <asp:Label ID="Label2" runat="server" Text="Exchange Rate"></asp:Label>
            </td>
            <td colspan="3" style="width: 554px; margin-left: 40px">
                <asp:TextBox ID="txt_Exchange_Rate" runat="server" Width="378px" Height="29px"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style4" style="width: 929px">
                &nbsp;</td>
            <td class="style2" style="width: 163px">
                &nbsp;</td>
            <td style="width: 579px; margin-left: 40px">
                &nbsp;</td>
            <td style="width: 163px; margin-left: 40px">
                <asp:Button ID="btn_Add_Currency" runat="server" Text="Update" 
                    onclick="btn_Add_Currency_Click" Width="105px" Height="38px" />
            </td>
            <td style="width: 554px; margin-left: 40px">
                <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" Width="92px" 
                    Height="34px" PostBackUrl="~/Currency_Listing.aspx" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

