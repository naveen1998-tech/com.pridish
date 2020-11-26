<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Add_office_Expense.aspx.cs" Inherits="com.pridish.Add_office_Expense" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style1">
        <tr>
            <td colspan="5">
                <h4 class="card-title" 
                    style="box-sizing: border-box; outline: 0px; margin-top: 0px; margin-bottom: 10px; font-family: &quot;Nunito Sans&quot;, sans-serif; font-weight: 600; line-height: 1.2; color: rgb(62, 85, 105); font-size: 18px; position: relative; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial;">
                    Office Expense Master</h4>
            </td>
        </tr>
        <tr>
            <td colspan="5">
                &nbsp;</td>
        </tr>
        <tr>
            <td colspan="5">
                <h4 class="card-title" 
                    style="box-sizing: border-box; outline: 0px; margin-top: 0px; margin-bottom: 10px; font-family: &quot;Nunito Sans&quot;, sans-serif; font-weight: 600; line-height: 1.2; color: rgb(62, 85, 105); font-size: 18px; position: relative; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial;">
                    Add Office Expense</h4>
            </td>
        </tr>
        <tr>
            <td class="style10" style="width: 175px">
                &nbsp;</td>
            <td class="style12" style="width: 182px">
                <asp:Label ID="Label1" runat="server" Text="Expense Type"></asp:Label>
            </td>
            <td colspan="3">
                <br />
                <asp:TextBox ID="txt_expenseType" runat="server" Width="583px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style10" style="width: 175px">
                &nbsp;</td>
            <td class="style12" style="width: 182px">
                <asp:Label ID="Label2" runat="server" Text="Expense Transaction Details"></asp:Label>
            </td>
            <td colspan="3">
                <br />
                <asp:TextBox ID="txt_expenseTransaction" runat="server" Width="583px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style10" style="width: 175px">
                &nbsp;</td>
            <td class="style12" style="width: 182px">
                <asp:Label ID="Label3" runat="server" Text="Transaction Date"></asp:Label>
            </td>
            <td colspan="3">
                

                <br />
                <asp:TextBox ID="txt_transaction" runat="server" Width="583px" TextMode="Date"></asp:TextBox>
                

            </td>
        </tr>
        <tr>
            <td class="style10" style="width: 175px">
                &nbsp;</td>
            <td class="style12" style="width: 182px">
                <asp:Label ID="Label4" runat="server" Text="Amount"></asp:Label>
            </td>
            <td colspan="3">
                <br />
                <asp:TextBox ID="txt_amount" runat="server" Width="583px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style10" style="width: 175px">
                &nbsp;</td>
            <td class="style12" style="width: 182px">
                <asp:Label ID="Label5" runat="server" Text="Remarks"></asp:Label>
            </td>
            <td colspan="3">
                <br />
                <asp:TextBox ID="txt_remarks" runat="server" Width="583px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="style10" style="width: 175px">
                &nbsp;</td>
            <td class="style12" style="width: 182px">
                &nbsp;</td>
            <td colspan="3">
                &nbsp;</td>
        </tr>
        <tr>
            <td class="style10" style="width: 175px">
                &nbsp;</td>
            <td class="style12" style="width: 182px">
                &nbsp;</td>
            <td class="style10" style="width: 445px">
                &nbsp;</td>
            <td class="style3" style="width: 123px">
                <asp:Button ID="btn_save" runat="server" Text="Save" onclick="btn_save_Click" 
                    Width="101px" Height="42px" />
            </td>
            <td>
                <asp:Button ID="btn_cancel" runat="server" Text="Cancel" Width="92px" 
                    Height="40px" PostBackUrl="~/Office_Expence_List.aspx" />
            </td>
        </tr>
    </table>
</asp:Content>

