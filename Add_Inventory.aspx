<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Add_Inventory.aspx.cs" Inherits="com.pridish.Add_Inventory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style1">
    <tr>
        <td>
            <h4 class="card-title" 
                style="box-sizing: border-box; outline: 0px; margin-top: 0px; margin-bottom: 10px; font-family: &quot;Nunito Sans&quot;, sans-serif; font-weight: 600; line-height: 1.2; color: rgb(62, 85, 105); font-size: 18px; position: relative; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial;">
                Inventory Form</h4>
        </td>
    </tr>
    <tr>
        <td>
            <br />
            <br />
            <br />
            <h4 class="card-title" 
                style="box-sizing: border-box; outline: 0px; margin-top: 0px; margin-bottom: 10px; font-family: &quot;Nunito Sans&quot;, sans-serif; font-weight: 600; line-height: 1.2; color: rgb(62, 85, 105); font-size: 18px; position: relative; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial;">
                Inventory Info</h4>
        </td>
    </tr>
    <tr>
        <td>
            <table class="style1">
                <tr>
                    <td class="style10" style="width: 162px">
                        &nbsp;</td>
                    <td class="style3" style="width: 179px">
                        <asp:Label ID="Label1" runat="server" Text="Product Group"></asp:Label>
                    </td>
                    <td colspan="3">
                        <br />
                        <asp:TextBox ID="txt_productGroup" runat="server" Width="554px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style10" style="width: 162px">
                        &nbsp;</td>
                    <td class="style3" style="width: 179px">
                        <asp:Label ID="Label2" runat="server" Text="Product Name"></asp:Label>
                    </td>
                    <td colspan="3">
                        <br />
                        <asp:TextBox ID="txt_productName" runat="server" Width="554px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style10" style="width: 162px">
                        &nbsp;</td>
                    <td class="style3" style="width: 179px">
                        <asp:Label ID="Label3" runat="server" Text="Product Size"></asp:Label>
                    </td>
                    <td colspan="3">
                        <br />
                        <asp:TextBox ID="txt_productSize" runat="server" Width="554px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style10" style="width: 162px">
                        &nbsp;</td>
                    <td class="style3" style="width: 179px">
                        <asp:Label ID="Label4" runat="server" Text="Product Unit"></asp:Label>
                    </td>
                    <td colspan="3">
                        <br />
                        <asp:TextBox ID="txt_productUnit" runat="server" Width="554px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style10" style="width: 162px">
                        &nbsp;</td>
                    <td class="style3" style="width: 179px">
                        <asp:Label ID="Label5" runat="server" Text="Barcode"></asp:Label>
                    </td>
                    <td colspan="3">
                        <br />
                        <asp:TextBox ID="txt_barcode" runat="server" Width="554px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style10" style="width: 162px">
                        &nbsp;</td>
                    <td class="style3" style="width: 179px">
                        <asp:Label ID="Label6" runat="server" Text="Inhouse Code"></asp:Label>
                    </td>
                    <td colspan="3">
                        <br />
                        <asp:TextBox ID="txt_inhouseCode" runat="server" Width="554px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style10" style="width: 162px">
                        &nbsp;</td>
                    <td class="style3" style="width: 179px">
                        <asp:Label ID="Label7" runat="server" Text="Product Purchase Price"></asp:Label>
                    </td>
                    <td colspan="3">
                        <br />
                        <asp:TextBox ID="txt_productPurchasePrice" runat="server" Width="554px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style10" style="width: 162px">
                        &nbsp;</td>
                    <td class="style3" style="width: 179px">
                        <asp:Label ID="Label8" runat="server" Text="Product Selling Price"></asp:Label>
                    </td>
                    <td colspan="3">
                        <br />
                        <asp:TextBox ID="txt_productSellingPrice" runat="server" Width="554px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style10" style="width: 162px">
                        &nbsp;</td>
                    <td class="style3" style="width: 179px">
                        <asp:Label ID="Label9" runat="server" Text="Product Quantity"></asp:Label>
                    </td>
                    <td colspan="3">
                        <br />
                        <asp:TextBox ID="txt_productQuantity" runat="server" Width="554px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style10" style="width: 162px">
                        &nbsp;</td>
                    <td class="style3" style="width: 179px">
                        <asp:Label ID="Label10" runat="server" Text="HSN Code"></asp:Label>
                    </td>
                    <td colspan="3">
                        <br />
                        <asp:TextBox ID="txt_HSNcode" runat="server" Width="554px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style10" style="width: 162px">
                        &nbsp;</td>
                    <td class="style3" style="width: 179px">
                        <asp:Label ID="Label11" runat="server" Text="Serial / IMEI Number"></asp:Label>
                    </td>
                    <td colspan="3">
                        <br />
                        <asp:TextBox ID="txt_serialNo" runat="server" Width="554px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style10" style="width: 162px">
                        &nbsp;</td>
                    <td class="style3" style="width: 179px">
                        <asp:Label ID="Label12" runat="server" Text="Stock Received"></asp:Label>
                    </td>
                    <td colspan="3">
                        <br />
                        <asp:TextBox ID="txt_StockReceived" runat="server" Width="554px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style10" style="width: 162px">
                        &nbsp;</td>
                    <td class="style3" style="width: 179px">
                        <asp:Label ID="Label13" runat="server" Text="Current Stock"></asp:Label>
                    </td>
                    <td colspan="3">
                        <br />
                        <asp:TextBox ID="txt_currentStock" runat="server" Width="554px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style10" style="width: 162px">
                        &nbsp;</td>
                    <td class="style3" style="width: 179px">
                        <asp:Label ID="Label14" runat="server" Text="Book Stock"></asp:Label>
                    </td>
                    <td colspan="3">
                        <br />
                        <asp:TextBox ID="txt_bookStock" runat="server" Width="554px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style10" style="width: 162px">
                        &nbsp;</td>
                    <td class="style3" style="width: 179px">
                        &nbsp;</td>
                    <td class="style6" style="width: 393px">
                        &nbsp;</td>
                    <td class="style9" style="width: 58px">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style10" style="width: 162px">
                        &nbsp;</td>
                    <td class="style3" style="width: 179px">
                        &nbsp;</td>
                    <td class="style6" style="width: 393px">
                        &nbsp;</td>
                    <td class="style9" style="width: 58px">
                        <asp:Button ID="Button1" runat="server" Text="Save" Width="69px" />
                    </td>
                    <td>
                        <asp:Button ID="Button2" runat="server" Text="Cancel" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
</asp:Content>

