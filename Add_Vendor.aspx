<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Add_Vendor.aspx.cs" Inherits="com.pridish.Add_Vendor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style1">
    <tr>
        <td>
            <h4 class="card-title" 
                style="box-sizing: border-box; outline: 0px; margin-top: 0px; margin-bottom: 10px; font-family: &quot;Nunito Sans&quot;, sans-serif; font-weight: 600; line-height: 1.2; color: rgb(62, 85, 105); font-size: 18px; position: relative; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial;">
                Vendor Master</h4>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            <h4 class="card-title" 
                style="box-sizing: border-box; outline: 0px; margin-top: 0px; margin-bottom: 10px; font-family: &quot;Nunito Sans&quot;, sans-serif; font-weight: 600; line-height: 1.2; color: rgb(62, 85, 105); font-size: 18px; position: relative; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial;">
                Vendor Personal Info</h4>
        </td>
    </tr>
    <tr>
        <td>
            <table class="style1">
                <tr>
                    <td class="style10" style="width: 207px">
                        &nbsp;</td>
                    <td class="style3" style="width: 134px">
                        <asp:Label ID="Label1" runat="server" Text="Vendor Code"></asp:Label>
                    </td>
                    <td>
                        <br />
                        <asp:TextBox ID="txt_vendorCode" runat="server" Width="522px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style10" style="width: 207px">
                        &nbsp;</td>
                    <td class="style3" style="width: 134px">
                        <asp:Label ID="Label2" runat="server" Text="Company Name"></asp:Label>
                    </td>
                    <td>
                        <br />
                        <asp:TextBox ID="txt_companyName" runat="server" Width="522px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style10" style="width: 207px">
                        &nbsp;</td>
                    <td class="style3" style="width: 134px">
                        <asp:Label ID="Label3" runat="server" Text="Company Address"></asp:Label>
                    </td>
                    <td>
                        <br />
                        <asp:TextBox ID="txt_companyAddress" runat="server" Width="522px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style10" style="width: 207px">
                        &nbsp;</td>
                    <td class="style3" style="width: 134px">
                        <asp:Label ID="Label4" runat="server" Text="Contact Person"></asp:Label>
                    </td>
                    <td>
                        <br />
                        <asp:TextBox ID="txt_contactPerson" runat="server" Width="522px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style10" style="width: 207px">
                        &nbsp;</td>
                    <td class="style3" style="width: 134px">
                        <asp:Label ID="Label5" runat="server" Text="Mobile"></asp:Label>
                    </td>
                    <td>
                        <br />
                        <asp:TextBox ID="txt_mobile" runat="server" Width="522px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style10" style="width: 207px">
                        &nbsp;</td>
                    <td class="style3" style="width: 134px">
                        <asp:Label ID="Label6" runat="server" Text="Email Id"></asp:Label>
                    </td>
                    <td>
                        <br />
                        <asp:TextBox ID="txt_emailId" runat="server" Width="522px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style10" style="width: 207px">
                        &nbsp;</td>
                    <td class="style3" style="width: 134px">
                        Notes</td>
                    <td>
                        <br />
                        <asp:TextBox ID="txt_address" runat="server" Width="522px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style10" style="width: 207px">
                        &nbsp;</td>
                    <td class="style3" style="width: 134px">
                        <asp:Label ID="Label8" runat="server" Text="Country"></asp:Label>
                    </td>
                    <td>
                        <br />
                        <asp:TextBox ID="txt_country" runat="server" Width="522px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style10" style="width: 207px">
                        &nbsp;</td>
                    <td class="style3" style="width: 134px">
                        <asp:Label ID="Label9" runat="server" Text="Currency"></asp:Label>
                    </td>
                    <td>
                        <br />
                        <asp:DropDownList ID="ddl_currency" runat="server" Height="22px" Width="528px" 
                            DataTextField="cc" DataValueField="ID">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td class="style10" style="width: 207px">
                        &nbsp;</td>
                    <td class="style3" style="width: 134px">
                        <asp:Label ID="Label10" runat="server" Text="Credit Terms"></asp:Label>
                    </td>
                    <td>
                        <br />
                        <asp:TextBox ID="txt_CreditTerms" runat="server" Width="522px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style10" style="width: 207px">
                        &nbsp;</td>
                    <td class="style3" style="width: 134px">
                        <asp:Label ID="Label11" runat="server" Text="Credit Limit"></asp:Label>
                    </td>
                    <td>
                        <br />
                        <asp:TextBox ID="txt_creditLimit" runat="server" Width="522px"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>
            <h4 class="card-title" 
                style="box-sizing: border-box; outline: 0px; margin-top: 0px; margin-bottom: 10px; font-family: &quot;Nunito Sans&quot;, sans-serif; font-weight: 600; line-height: 1.2; color: rgb(62, 85, 105); font-size: 18px; position: relative; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial;">
                Bank Details</h4>
        </td>
    </tr>
    <tr>
        <td>
            <table class="style1">
                <tr>
                    <td style="width: 201px">
                        &nbsp;</td>
                    <td style="width: 136px">
                        <asp:Label ID="Label12" runat="server" Text="Account Name"></asp:Label>
                    </td>
                    <td colspan="3">
                        <br />
                        <asp:TextBox ID="txt_accountName" runat="server" Width="522px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 201px">
                        &nbsp;</td>
                    <td style="width: 136px">
                        <asp:Label ID="Label13" runat="server" Text="Account Number"></asp:Label>
                    </td>
                    <td colspan="3">
                        <br />
                        <asp:TextBox ID="txt_accountNumber" runat="server" Width="522px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 201px">
                        &nbsp;</td>
                    <td style="width: 136px">
                        <asp:Label ID="Label14" runat="server" Text="Bank Name"></asp:Label>
                    </td>
                    <td colspan="3">
                        <br />
                        <asp:TextBox ID="txt_bankName" runat="server" Width="522px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 201px">
                        &nbsp;</td>
                    <td style="width: 136px">
                        <asp:Label ID="Label15" runat="server" Text="Branch Name"></asp:Label>
                    </td>
                    <td colspan="3">
                        <br />
                        <asp:TextBox ID="txt_branchName" runat="server" Width="522px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 201px">
                        &nbsp;</td>
                    <td style="width: 136px">
                        <asp:Label ID="Label16" runat="server" Text="Swift Code"></asp:Label>
                    </td>
                    <td colspan="3">
                        <br />
                        <asp:TextBox ID="txt_swiftCode" runat="server" Width="522px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 201px">
                        &nbsp;</td>
                    <td style="width: 136px">
                        <asp:Label ID="Label17" runat="server" Text="City Name"></asp:Label>
                    </td>
                    <td colspan="3">
                        <br />
                        <asp:TextBox ID="txt_cityName" runat="server" Width="522px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 201px">
                        &nbsp;</td>
                    <td style="width: 136px">
                        <asp:Label ID="Label18" runat="server" Text="Country"></asp:Label>
                    </td>
                    <td colspan="3">
                        <br />
                        <asp:TextBox ID="txt_BankCounty" runat="server" Width="522px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 201px">
                        &nbsp;</td>
                    <td style="width: 136px">
                        <asp:Label ID="Label19" runat="server" Text="Vendor"></asp:Label>
                    </td>
                    <td colspan="3">
                        <br />
                        <asp:TextBox ID="txt_vendor" runat="server" Width="522px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td style="width: 201px">
                        &nbsp;</td>
                    <td style="width: 136px">
                        <asp:Label ID="Label20" runat="server" Text="Account Currrency"></asp:Label>
                    </td>
                    <td colspan="3">
                        <br />
                        <asp:DropDownList ID="ddl_accountCurrency" runat="server" Height="22px" 
                            Width="528px" DataTextField="cc" DataValueField="ID">
                        </asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td style="width: 201px">
                        &nbsp;</td>
                    <td style="width: 136px">
                        &nbsp;</td>
                    <td colspan="3">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td style="width: 201px">
                        &nbsp;</td>
                    <td style="width: 136px">
                        &nbsp;</td>
                    <td style="width: 364px">
                        &nbsp;</td>
                    <td class="style9" style="width: 103px">
                        <asp:Button ID="btn_Save" runat="server" Text="Save" onclick="btn_Save_Click" 
                            Width="106px" Height="35px" />
                    </td>
                    <td>
                        <asp:Button ID="btn_cancel" runat="server" Text="Cancel" Width="101px" 
                            Height="33px" PostBackUrl="~/Vendor_List.aspx" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
</asp:Content>

