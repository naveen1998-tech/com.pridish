<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="CashMemo_payment.aspx.cs" Inherits="com.pridish.CashMemo_payment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="style1">
    <tr>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            <table class="style1">
                <tr>
                    <td class="style9" style="width: 265px">
                        &nbsp;</td>
                    <td class="style9" style="width: 116px">
                        <strong>Customer Code</strong></td>
                    <td class="style13" style="width: 206px">
                        <asp:DropDownList ID="ddl_Cust_Code" runat="server" AutoPostBack="true" 
                            DataTextField="cc" DataValueField="ID" Height="41px" 
                            onselectedindexchanged="ddl_Cust_Code_SelectedIndexChanged" Width="166px">
                        </asp:DropDownList>
                    </td>
                    <td class="style3" style="width: 124px">
                        <strong>Cash Memo No.</strong></td>
                    <td>
                        <asp:DropDownList ID="ddl_Invoice_No" runat="server" DataTextField="cc" 
                            DataValueField="ID" Height="41px" Width="171px" > 
                        </asp:DropDownList>
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style9" style="width: 265px">
                        &nbsp;</td>
                    <td class="style9" style="width: 116px">
                        &nbsp;</td>
                    <td class="style13" style="width: 206px">
                        &nbsp;</td>
                    <td class="style3" style="width: 124px">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>
            <asp:GridView ID="Gridview1" runat="server" AutoGenerateColumns="false" 
                CssClass="header1" onrowcreated="Gridview1_RowCreated" ShowFooter="true">
                <Columns>
            <%--<asp:BoundField DataField="RowNumber" HeaderText="Row Number" />--%>
                        <asp:TemplateField HeaderText=" Payment Type">
                            <ItemTemplate>
                                
                                <asp:DropDownList ID="ddl_Payment_Type" runat="server" 
                                     Height="23px"  Width="127px" AppendDataBoundItems ="true" SelectedValue='<%# Eval("Payment_Type") %>'>
                                    
                                    <asp:ListItem> </asp:ListItem>
                                    <asp:ListItem>Partial </asp:ListItem>
                                    <asp:ListItem> Full</asp:ListItem>
                                </asp:DropDownList>
                            </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText=" Date">
                        <ItemTemplate>
                            <asp:TextBox ID="txt_Transfer_Date" runat="server" Text ='<%# Eval("Date") %>' ></asp:TextBox>
                                
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="Amount">
                        <ItemTemplate>
                            <asp:TextBox ID="txt_Amount" runat="server"  Text ='<%# Eval("Amount") %>' ></asp:TextBox>
                        </ItemTemplate>
                        <FooterStyle HorizontalAlign="Right" />
                        <FooterTemplate>
                            <asp:Button ID="ButtonAdd" runat="server" CssClass="header" 
                                onclick="ButtonAdd_Click" Text="Add New Row" />
                        </FooterTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField>
                        <ItemTemplate>
                    <%--<asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">Remove</asp:LinkButton>--%>
                            </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            <table class="style1">
                <tr>
                    <td class="style15" style="width: 229px">
                            <asp:Button ID="btn_Save" CssClass ="header" runat="server" Height="46px" Text="Save" 
                                Width="215px" onclick="btn_Save_Click" style="font-weight: 700" />
                        </td>
                    <td>
                            <asp:Button ID="btn_Cancel" CssClass ="header" runat="server" Height="41px" style="font-weight: 700" 
                                Text="Cancel" Width="215px" PostBackUrl="~/CashMemo_Payment_List.aspx"  />
                        </td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
        </td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
    </tr>
</table>
</asp:Content>
