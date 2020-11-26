<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Add_Customer.aspx.cs" Inherits="com.pridish.Add_Customer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style1">
    <tr>
        <td colspan="5">
            <h4 class="card-title" 
                style="box-sizing: border-box; outline: 0px; margin-top: 0px; margin-bottom: 10px; font-family: &quot;Nunito Sans&quot;, sans-serif; font-weight: 600; line-height: 1.2; color: rgb(62, 85, 105); font-size: 18px; position: relative; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial;">
                Customer Master</h4>
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
                Customer General Info</h4>
        </td>
    </tr>

    <tr>
        <td>
        </td>
        <td >
           
            <asp:Label ID="Label11" runat="server" Text="Customer Code"></asp:Label>
           
        </td>
        <td style="width: 433px">
            <asp:TextBox ID="txt_Customer_code" runat="server" Width="522px"></asp:TextBox>
        </td>
    </tr>
   


    <tr>
        <td style="width: 215px">
            &nbsp;</td>
        <td style="width: 197px; margin-left: 40px">
            <asp:Label ID="Label1" runat="server" Text="Company Name"></asp:Label>
        </td>
        <td colspan="3">
            <br />
            <asp:TextBox ID="txt_CompanyName" runat="server" Width="522px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="width: 215px">
            &nbsp;</td>
        <td style="width: 197px; margin-left: 40px">
            <asp:Label ID="Label2" runat="server" Text="Group Company Name"></asp:Label>
        </td>
        <td colspan="3">
            <br />
            <asp:TextBox ID="txt_groupCompanyName" runat="server" Width="522px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="width: 215px">
            &nbsp;</td>
        <td style="width: 197px; margin-left: 40px">
            <asp:Label ID="Label3" runat="server" Text="Customer Name"></asp:Label>
        </td>
        <td colspan="3">
            <br />
            <asp:TextBox ID="txt_customerName" runat="server" Width="522px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="width: 215px">
            &nbsp;</td>
        <td style="width: 197px; margin-left: 40px">
            <asp:Label ID="Label4" runat="server" Text="Email"></asp:Label>
        </td>
        <td colspan="3">
            <br />
            <asp:TextBox ID="txt_email" runat="server" Width="522px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="width: 215px">
            &nbsp;</td>
        <td style="width: 197px; margin-left: 40px">
            <asp:Label ID="Label5" runat="server" Text="Mobile Number"></asp:Label>
        </td>
        <td colspan="3">
            <br />
            <asp:TextBox ID="txt_mobile" runat="server" Width="522px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="width: 215px">
            &nbsp;</td>
        <td style="width: 197px; margin-left: 40px">
            <asp:Label ID="Label6" runat="server" Text="Address"></asp:Label>
        </td>
        <td colspan="3">
            <br />
            <asp:TextBox ID="txt_address" runat="server" Width="522px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="width: 215px">
            &nbsp;</td>
        <td style="width: 197px; margin-left: 40px">
            <asp:Label ID="Label7" runat="server" Text="Country"></asp:Label>
        </td>
        <td colspan="3">
            <br />
            <asp:TextBox ID="txt_country" runat="server" Width="522px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="width: 215px">
            &nbsp;</td>
        <td style="width: 197px; margin-left: 40px">
            <asp:Label ID="Label8" runat="server" Text="Currency"></asp:Label>
        </td>
        <td colspan="3">
            <br />
            <asp:DropDownList ID="ddl_Currency" runat="server" Height="29px" Width="521px" 
                DataTextField="cc" DataValueField="ID">
            </asp:DropDownList>
        </td>
    </tr>
    <tr>
        <td style="width: 215px">
            &nbsp;</td>
        <td style="width: 197px; margin-left: 40px">
            <asp:Label ID="Label9" runat="server" Text="Credit Limit"></asp:Label>
        </td>
        <td colspan="3">
            <br />
            <asp:TextBox ID="txt_creditLimit" runat="server" Width="522px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="width: 215px">
            &nbsp;</td>
        <td style="width: 197px; margin-left: 40px">
            <asp:Label ID="Label10" runat="server" Text="Credit Terms (No. Of Days)"></asp:Label>
        </td>
        <td colspan="3">
            <br />
            <asp:TextBox ID="txt_creditTerms" runat="server" Width="522px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td style="width: 215px">
            &nbsp;</td>
        <td style="width: 197px; margin-left: 40px">
            &nbsp;</td>
        <td colspan="3">
            &nbsp;</td>
    </tr>
    <tr>
        <td style="width: 215px">
            &nbsp;</td>
        <td style="width: 197px; margin-left: 40px">
            &nbsp;</td>
        <td class="style10" style="width: 433px">
        </td>
        <td class="style9" style="width: 78px">
            <asp:Button ID="btn_Save" runat="server" Text="Save" onclick="btn_Save_Click" 
                Width="79px" Height="37px" />
        </td>
        <td>
            <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" Height="35px" 
                PostBackUrl="~/List_Customer.aspx" Width="71px" />
        </td>
    </tr>
</table>
</asp:Content>

