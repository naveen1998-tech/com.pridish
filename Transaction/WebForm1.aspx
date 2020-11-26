<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="com.pridish.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <table class="style1">
        <tr>
            <td>
                <asp:TextBox ID="TextBox1"  runat="server" Width="270px"></asp:TextBox>
                <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Button" />
                <asp:Button ID="btn_Save" runat="server" onclick="btn_Save_Click" Text="save" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
            <asp:Table ID="mytbl" runat="server" Width="1068px">
    </asp:Table>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
    </table>


</asp:Content>
