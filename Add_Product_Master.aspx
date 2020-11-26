<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Add_Product_Master.aspx.cs" Inherits="com.pridish.Add_Product_Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style1">
    <tr>
        <td style="height: 26px; width: 196px">
            <h4 class="card-title" 
                style="box-sizing: border-box; outline: 0px; margin-top: 0px; margin-bottom: 10px; font-family: &quot;Nunito Sans&quot;, sans-serif; font-weight: 600; line-height: 1.2; color: rgb(62, 85, 105); font-size: 18px; position: relative; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial;">
                Product Master</h4>
        </td>
        <td style="height: 26px; width: 161px">
        </td>
        <td colspan="4" style="height: 26px">
        </td>
    </tr>
    <tr>
        <td class="style11" style="width: 196px">
            &nbsp;</td>
        <td class="style2" style="width: 161px">
            <asp:Label ID="Label1" runat="server" Text="Product code"></asp:Label>
        </td>
        <td colspan="4">
            <br />
            <asp:TextBox ID="txt_product_Code" runat="server" Height="26px" Width="553px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style11" style="width: 196px">
            &nbsp;</td>
        <td class="style2" style="width: 161px">
            <asp:Label ID="Label2" runat="server" Text="Product group"></asp:Label>
        </td>
        <td colspan="4">
            <br />
            <asp:TextBox ID="product_group" runat="server" Height="26px" Width="553px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style11" style="width: 196px">
            &nbsp;</td>
        <td class="style2" style="width: 161px">
            <asp:Label ID="Label3" runat="server" Text="Product Name"></asp:Label>
        </td>
        <td colspan="4">
            <br />
            <asp:TextBox ID="txt_product_name" runat="server" Height="26px" Width="553px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style11" style="width: 196px">
            &nbsp;</td>
        <td class="style2" style="width: 161px">
            <asp:Label ID="Label4" runat="server" Text="Product Size"></asp:Label>
        </td>
        <td colspan="4">
            <br />
            <asp:TextBox ID="txt_product_size" runat="server" Height="26px" Width="553px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style11" style="width: 196px">
            &nbsp;</td>
        <td class="style2" style="width: 161px">
            <asp:Label ID="Label5" runat="server" Text="Product Unit"></asp:Label>
        </td>
        <td colspan="4">
            <br />
            <asp:TextBox ID="txt_product_unit" runat="server" Height="26px" Width="553px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style11" style="width: 196px">
            &nbsp;</td>
        <td class="style2" style="width: 161px">
            <asp:Label ID="Label6" runat="server" Text="Product Purchase Price"></asp:Label>
        </td>
        <td colspan="4">
            <br />
            <asp:TextBox ID="txt_product_purchase_price" runat="server" Height="26px" 
                Width="553px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style11" style="width: 196px">
            &nbsp;</td>
        <td class="style2" style="width: 161px">
            <asp:Label ID="Label7" runat="server" Text="Product Selling Price"></asp:Label>
        </td>
        <td colspan="4">
            <br />
            <asp:TextBox ID="txt_product_selling_price" runat="server" Height="26px" 
                Width="553px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style11" style="width: 196px">
            &nbsp;</td>
        <td class="style2" style="width: 161px">
            <asp:Label ID="Label8" runat="server" Text="HSN Code"></asp:Label>
        </td>
        <td colspan="4">
            <br />
            <asp:TextBox ID="txt_HSN_code" runat="server" Height="26px" Width="553px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style11" style="width: 196px">
            &nbsp;</td>
        <td class="style2" style="width: 161px">
            <br />
            Tax %<br />
        </td>
        <td colspan="4">
            <br />
            <asp:TextBox ID="txt_Tax" runat="server" Height="26px" Width="553px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style11" style="width: 196px">
            &nbsp;</td>
        <td class="style2" style="width: 161px">
            <br />
            Warranty<br />
        </td>
        <td colspan="4">
            <br />
            <asp:TextBox ID="txt_Warrenty" runat="server" Height="26px" Width="553px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style11" style="width: 196px">
            &nbsp;</td>
        <td class="style2" style="width: 161px">
            &nbsp;</td>
        <td class="style3" style="width: 129px">
            &nbsp;</td>
        <td class="style12" style="width: 324px">
            <br />
            <br />
        </td>
        <td>
            <asp:Button ID="btn_save" runat="server" Text="Save" Width="106px" 
                onclick="btn_save_Click" Height="38px" />
        </td>
        <td>
            <asp:Button ID="btn_cancel" runat="server" Text="Cancel" Height="33px" 
                Width="95px" PostBackUrl="~/Product_List.aspx" />
        </td>
    </tr>
</table>
</asp:Content>

