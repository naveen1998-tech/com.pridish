<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Employee_Form.aspx.cs" Inherits="com.pridish.Employee_Form" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style1">
    <tr>
        <td>
            <h4 class="card-title" 
                style="box-sizing: border-box; outline: 0px; margin-top: 0px; margin-bottom: 10px; font-family: &quot;Nunito Sans&quot;, sans-serif; font-weight: 600; line-height: 1.2; color: rgb(62, 85, 105); font-size: 18px; position: relative; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial;">
                Employee Master</h4>
        </td>
    </tr>
    <tr>
        <td>
            <br />
            <br />
            <h4 class="card-title" 
                style="box-sizing: border-box; outline: 0px; margin-top: 0px; margin-bottom: 10px; font-family: &quot;Nunito Sans&quot;, sans-serif; font-weight: 600; line-height: 1.2; color: rgb(62, 85, 105); font-size: 18px; position: relative; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial;">
                Add Employee</h4>
        </td>
    </tr>
    <tr>
        <td>
            <table class="style1">
                <tr>
                    <td class="style2" style="width: 156px">
                        &nbsp;</td>
                    <td style="width: 228px; margin-left: 80px">
                        <asp:Label ID="Label1" runat="server" Text="Employee Name"></asp:Label>
                    </td>
                    <td colspan="3">
                        <br />
                        <asp:TextBox ID="txt_empName" runat="server" Width="551px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style2" style="width: 156px">
                        &nbsp;</td>
                    <td style="width: 228px">
                        <asp:Label ID="Label2" runat="server" Text="Company Name"></asp:Label>
                    </td>
                    <td colspan="3">
                        <br />
                        <asp:TextBox ID="txt_companyName" runat="server" Width="551px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style2" style="width: 156px">
                        &nbsp;</td>
                    <td style="width: 228px">
                        <asp:Label ID="Label3" runat="server" Text="Branch Name"></asp:Label>
                    </td>
                    <td colspan="3">
                        <br />
                        <asp:TextBox ID="txt_branchName" runat="server" Width="551px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style2" style="width: 156px">
                        &nbsp;</td>
                    <td style="width: 228px">
                        <asp:Label ID="Label4" runat="server" Text="Employee Id"></asp:Label>
                    </td>
                    <td colspan="3">
                        <br />
                        <asp:TextBox ID="txt_employeeId" runat="server" Width="551px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style2" style="width: 156px">
                        &nbsp;</td>
                    <td style="width: 228px">
                        <asp:Label ID="Label5" runat="server" Text="Joining Date"></asp:Label>
                    </td>
                    <td colspan="3">
                        <br />
                        <asp:TextBox ID="txt_joiningDate" runat="server" Width="551px" TextMode="Date"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style2" style="width: 156px">
                        &nbsp;</td>
                    <td style="width: 228px">
                        <asp:Label ID="Label6" runat="server" Text="Mobile No."></asp:Label>
                    </td>
                    <td colspan="3">
                        <br />
                        <asp:TextBox ID="txt_mobileNo" runat="server" Width="551px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style2" style="width: 156px">
                        &nbsp;</td>
                    <td style="width: 228px">
                        <asp:Label ID="Label7" runat="server" Text="Email Id"></asp:Label>
                    </td>
                    <td colspan="3">
                        <br />
                        <asp:TextBox ID="txt_emailId" runat="server" Width="551px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style2" style="width: 156px">
                        &nbsp;</td>
                    <td style="width: 228px">
                        <asp:Label ID="Label8" runat="server" Text="Address"></asp:Label>
                    </td>
                    <td colspan="3">
                        <br />
                        <asp:TextBox ID="txt_address" runat="server" Width="551px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style2" style="width: 156px">
                        &nbsp;</td>
                    <td style="width: 228px">
                        <asp:Label ID="Label9" runat="server" Text="Designation"></asp:Label>
                    </td>
                    <td colspan="3">
                        <br />
                        <asp:TextBox ID="txt_Designation" runat="server" Width="551px"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td class="style2" style="width: 156px">
                        &nbsp;</td>
                    <td style="width: 228px">
                        &nbsp;</td>
                    <td colspan="3">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style2" style="width: 156px">
                        &nbsp;</td>
                    <td style="width: 228px">
                        &nbsp;</td>
                    <td class="style2" style="width: 355px">
                        &nbsp;</td>
                    <td style="width: 27px">
                        <asp:Button ID="btn_Save" runat="server" Text="Save" Width="93px" 
                            onclick="btn_Save_Click" Height="34px" />
                    </td>
                    <td>
                        <asp:Button ID="Cancel" runat="server" Text="Cancel" Height="35px" 
                            PostBackUrl="~/Employee_List.aspx" Width="84px" />
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
</asp:Content>

