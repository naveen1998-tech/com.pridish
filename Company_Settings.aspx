<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Company_Settings.aspx.cs" Inherits="com.pridish.Company_Settings" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style1">
        <tr>
            <td>
               <h1> Company Setting Master</h1></td>
        </tr>
        <tr>
            <td>
                <table class="style1">
                    <tr>
                        <td style="width: 160px">
                            <h3>Edit Person info</h3></td>
                        <td class="style2" style="width: 178px">
                            &nbsp;</td>
                        <td class="style4" style="width: 640px">
                            &nbsp;</td>

                    </tr>
                    <tr>
                        <td style="width: 160px">
                            <h3>&nbsp;</h3></td>
                        <td class="style2" style="width: 178px">
                            <asp:Label ID="Label17" runat="server" Text="Company Code"></asp:Label>
                        </td>
                        <td class="style4" style="width: 640px">
                            <br />
                            <asp:TextBox ID="txt_CompanyCode" runat="server" Width="678px"></asp:TextBox>
                        </td>

                    </tr>
                    <tr>
                        <td style="width: 160px">
                            &nbsp;</td>
                        <td style="margin-left: 40px; width: 178px;">
                            <asp:Label ID="Label2" runat="server" Text="Company Name"></asp:Label>
                        </td>
                        <td class="style4" style="width: 640px">
                            <br />
                            <asp:TextBox ID="txt_CompanyName" runat="server" Width="678px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 160px">
                            &nbsp;</td>
                        <td style="margin-left: 40px; width: 178px;">
                            <asp:Label ID="Label3" runat="server" Text="Brand Name"></asp:Label>
                        </td>
                        <td class="style4" style="width: 640px">
                            <br />
                            <asp:TextBox ID="txt_BrandName" runat="server" Width="678px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 160px">
                            &nbsp;</td>
                        <td style="margin-left: 40px; width: 178px;">
                            <asp:Label ID="Label4" runat="server" Text="Contact Person"></asp:Label>
                        </td>
                        <td class="style4" style="width: 640px">
                            <br />
                            <asp:TextBox ID="txt_ContactPerson" runat="server" Width="678px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 160px">
                            &nbsp;</td>
                        <td style="margin-left: 40px; width: 178px;">
                            <asp:Label ID="Label5" runat="server" Text="Email"></asp:Label>
                        </td>
                        <td class="style4" style="width: 640px">
                            <br />
                            <asp:TextBox ID="txt_Email" runat="server" Width="678px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 160px">
                            &nbsp;</td>
                        <td style="margin-left: 40px; width: 178px;">
                            <asp:Label ID="Label6" runat="server" Text="Mobile Number"></asp:Label>
                        </td>
                        <td class="style4" style="width: 640px">
                            <br />
                            <asp:TextBox ID="txt_MobileNumber" runat="server" Width="678px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 160px">
                            &nbsp;</td>
                        <td style="margin-left: 40px; width: 178px;">
                            <asp:Label ID="Label7" runat="server" Text="Address"></asp:Label>
                        </td>
                        <td class="style4" style="width: 640px">
                            <br />
                            <asp:TextBox ID="txt_Address" runat="server" Width="678px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 160px">
                            &nbsp;</td>
                        <td style="margin-left: 40px; width: 178px;">
                            <asp:Label ID="Label8" runat="server" Text="Country"></asp:Label>
                        </td>
                        <td class="style4" style="width: 640px">
                            <br />
                            <asp:TextBox ID="txt_Country" runat="server" Width="678px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 160px">
                            &nbsp;</td>
                        <td style="margin-left: 40px; width: 178px;">
                            <asp:Label ID="Label1" runat="server" Text="Company Base Currency"></asp:Label>
                        </td>
                        <td class="style4" style="width: 640px">
                            <br />
                            <asp:DropDownList ID="ddl_Base_Currency" runat="server" Height="42px" 
                                Width="676px" DataTextField="cc" DataValueField="ID">
                            </asp:DropDownList>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 160px">
                            <h3>Bank Details</h3></td>
                        <td style="margin-left: 40px; width: 178px;">
                            &nbsp;</td>
                        <td class="style4" style="width: 640px">
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 160px">
                            &nbsp;</td>
                        <td style="margin-left: 40px; width: 178px;">
                            <asp:Label ID="Label13" runat="server" Text="Account Number"></asp:Label>
                        </td>
                        <td class="style4" style="width: 640px">
                            <asp:TextBox ID="txt_AccountNumber" runat="server" Width="678px"></asp:TextBox>
                            <br />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 160px">
                            &nbsp;</td>
                        <td style="margin-left: 40px; width: 178px;">
                            <asp:Label ID="Label9" runat="server" Text="Bank Name"></asp:Label>
                        </td>
                        <td class="style4" style="width: 640px">
                            <asp:TextBox ID="txt_BankName" runat="server" Width="678px"></asp:TextBox>
                            <br />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 160px">
                            &nbsp;</td>
                        <td style="margin-left: 40px; width: 178px;">
                            <asp:Label ID="Label10" runat="server" Text="Branch Name"></asp:Label>
                        </td>
                        <td class="style4" style="width: 640px">
                            <asp:TextBox ID="txt_BranchName" runat="server" Width="678px"></asp:TextBox>
                            <br />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 160px">
                            &nbsp;</td>
                        <td style="margin-left: 40px; width: 178px;">
                            <asp:Label ID="Label11" runat="server" Text="Swift Code"></asp:Label>
                        </td>
                        <td class="style4" style="width: 640px">
                            <asp:TextBox ID="txt_SwiftCode" runat="server" Width="678px"></asp:TextBox>
                            <br />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 160px">
                            &nbsp;</td>
                        <td style="margin-left: 40px; width: 178px;">
                            <asp:Label ID="Label12" runat="server" Text="Account Name"></asp:Label>
                        </td>
                        <td class="style4" style="width: 640px">
                            <asp:TextBox ID="txt_AccountName" runat="server" Width="678px"></asp:TextBox>
                            <br />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 160px">
                            &nbsp;</td>
                        <td style="margin-left: 40px; width: 178px;">
                            <asp:Label ID="Label14" runat="server" Text="Company Name"></asp:Label>
                        </td>
                        <td class="style4" style="width: 640px">
                            <br />
                            <asp:TextBox ID="txt_BankCompanyName" runat="server" Width="678px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 160px">
                            &nbsp;</td>
                        <td style="margin-left: 40px; width: 178px;">
                            <asp:Label ID="Label15" runat="server" Text="City Name"></asp:Label>
                        </td>
                        <td class="style4" style="width: 640px">
                            <br />
                            <asp:TextBox ID="txt_CityName" runat="server" Width="678px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 160px">
                            &nbsp;</td>
                        <td style="margin-left: 40px; width: 178px;">
                            <asp:Label ID="Label16" runat="server" Text="Country"></asp:Label>
                        </td>
                        <td class="style4" style="width: 640px">
                            <br />
                            <asp:TextBox ID="txt_BankCountry" runat="server" Width="678px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 160px">
                            &nbsp;</td>
                        <td style="margin-left: 40px; width: 178px;">
                            &nbsp;</td>
                        <td class="style4" style="width: 640px">
                        

                            <table class="style1" style="width: 102%">
                                <tr>
                                    <td>
                                        &nbsp;</td>
                                    <td class="style10" style="width: 438px">
                                        &nbsp;</td>
                                    <td style="width: 58px">
                                        <asp:Button ID="Button1" runat="server" Text="Save" onclick="Button1_Click" />
                                    </td>
                                    <td class="style3" style="width: 126px">
                                        <asp:Button ID="Button2" runat="server" Text="Cancel" 
                                            style="margin-left: 0px" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                           
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

