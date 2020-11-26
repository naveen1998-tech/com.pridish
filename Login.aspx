<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="com.pridish.Login" %>


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        .style1
        {
            width: 100%;
            height: 209px;
        }
        }
        .style4
        {
            height: 125px;
        }
        .style2
        {
            height: 64px;
        }
        .style4
        {
            height: 125px;
        }
        .style5
        {
            height: 181px;
        }
        .style6
        {
            height: 125px;
            width: 115px;
        }
        .style7
        {
            height: 181px;
            width: 115px;
        }
        .style8
        {
            height: 64px;
            width: 115px;
        }
        .style9
        {
            height: 125px;
            width: 343px;
        }
        .style10
        {
            height: 181px;
            width: 343px;
        }
        .style11
        {
            height: 64px;
            width: 343px;
        }
        .style12
        {
            width: 114px;
        }
        .style13
        {
            width: 114px;
            height: 52px;
        }
        .style14
        {
            height: 52px;
        }
        .style15
        {
            height: 125px;
            width: 97px;
        }
        .style16
        {
            height: 181px;
            width: 97px;
        }
        .style17
        {
            height: 64px;
            width: 97px;
        }
    </style>
</head>
<body style="height: 629px">
<form id="form1" runat="server" 
    
    
    style="background-image: url('Logo/Simple-Abstract-Backgrounds.jpg'); height: 643px; clip: rect(auto, auto, auto, auto); table-layout: auto;">
    <div>
    
        <table class="style1">
            <tr>
                <td class="style4">
                </td>
                <td class="style6">
                </td>
                <td class="style9">
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                    <asp:Image ID="Image1" runat="server" Height="63px" 
                        ImageUrl="~/Logo/Transprant-3.png" Width="339px" />
                </td>
                <td class="style15">
                </td>
                <td class="style4">
                </td>
            </tr>
            <tr>
                <td class="style5">
                </td>
                <td class="style7">
                </td>
                <td class="style10" 
                    style="background-image: url('Logo/photo-1518215069569-0781b2f8cc69.jpg')">
                    <table class="style1">
                        <tr>
                            <td class="style13">
                                <asp:Label ID="Label1" runat="server" Text="User Id" ForeColor="White" 
                                    style="font-weight: 700; font-style: italic"></asp:Label>
                            </td>
                            <td class="style14">
                                <br />
                                <asp:TextBox ID="txt_UserName" runat="server" Height="27px" placeholder="Please Enter User ID " Width="192px" 
                                    ControlToValidate="txt_UserName"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                    ErrorMessage="*" ControlToValidate="txt_UserName" ForeColor="Red"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td class="style12">
                                <asp:Label ID="Label2" runat="server" Text="Password" ForeColor="White" 
                                    style="font-weight: 700; font-style: italic"></asp:Label>
                            </td>
                            <td>
                                <br />
                                <asp:TextBox ID="txt_Password" runat="server" placeholder="Please Enter Password " Height="24px" Width="189px" 
                                    TextMode="Password"></asp:TextBox>
                                
                                
                                
                                
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" 
                                    ErrorMessage="*" ControlToValidate="txt_Password" ForeColor="Red"></asp:RequiredFieldValidator>
                                
                                
                                
                                
                            </td>
                        </tr>
                        <tr>
                            <td class="style12">
                                &nbsp;</td>
                            <td>
                                <br />
                                <asp:Button ID="Button1" runat="server" onclick="Button1_Click" Text="Login" 
                                    Width="191px" Height="38px" style="font-weight: 700; font-style: italic" />
                                <br />
                                <br />
                            </td>
                        </tr>
                    </table>
                </td>
                <td class="style16">
                </td>
                <td class="style5">
                </td>
            </tr>
            <tr>
                <td class="style2">
                </td>
                <td class="style8">
                </td>
                <td class="style11">
                    <asp:Image ID="Image2" runat="server" Height="49px" 
                        ImageUrl="~/Logo/Logo-Bizz-App.png" Width="340px" />
                </td>
                <td class="style17">
                </td>
                <td class="style2">
                </td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>
