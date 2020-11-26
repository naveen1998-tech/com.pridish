<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Payments.aspx.cs" Inherits="com.pridish.Payments" %>
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
                        <td class="style3" style="width: 121px">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style3" style="width: 121px">
                            &nbsp;</td>
                        <td>
                            <table class="style1">
                                <tr>
                                    <td class="style2" style="width: 113px">
                                        <strong>
                                        <br />
                                        Customer Code</strong></td>
                                    <td class="style2" style="width: 206px">
                                        <strong><br />
                                        </strong>
                            <asp:DropDownList ID="ddl_Cust_Code" runat="server" Height="41px" Width="166px" 
                                DataTextField="cc" DataValueField="ID" AutoPostBack ="true" 
                                            onselectedindexchanged="ddl_Cust_Code_SelectedIndexChanged">
                            </asp:DropDownList>
                                    </td>
                                    <td class="style3" style="width: 86px">
                                        <br />
                                        <strong>Invoice No.</strong><br />
                                    </td>
                                    <td>
                                        <br />
                                        <asp:DropDownList ID="ddl_Invoice_No" runat="server" Height="41px" 
                                            Width="171px" DataTextField="cc" DataValueField="ID">
                                        </asp:DropDownList>
                                    </td>

                                </tr>
                                <tr>
                                    <td class="style2" style="width: 113px">
                                        &nbsp;</td>
                                    <td class="style2" style="width: 206px">
                                        &nbsp;</td>
                                    <td class="style3" style="width: 86px">
                                        &nbsp;</td>
                                    <td>
                                        <table class="style1">
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td class="style15" style="width: 424px">
                                                    &nbsp;</td>
                                                <td class="style9" style="width: 90px">
                                                    <%--<strong>Grand Total</strong>--%></td>
                                                <td>
                                                    <%--<asp:TextBox ID="txt_GrandTotal" runat="server" Height="41px" Width="206px"></asp:TextBox>--%>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    &nbsp;</td>
                                                <td class="style15" style="width: 424px">
                                                    &nbsp;</td>
                                                <td class="style9" style="width: 90px">
                                                    &nbsp;</td>
                                                <td>
                                                    &nbsp;</td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                            </table>
                        </td>
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
                                <%--<asp:TextBox ID="txt_Barcode" runat="server"></asp:TextBox>--%>
                                <asp:DropDownList ID="ddl_Payment_Type" AppendDataBoundItems ="true" SelectedValue='<%# Eval("Payment_Type") %>' runat="server" Height="23px" Width="127px"> 
                                <asp:ListItem> </asp:ListItem>
                                <asp:ListItem >Partial </asp:ListItem>
                                <asp:ListItem> Full</asp:ListItem>
                                 </asp:DropDownList>
                                
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText=" Transfer Date">
                            <ItemTemplate>
                                <asp:TextBox ID="txt_Transfer_Date" Text ='<%# Eval("Transfer_Date") %>' runat="server"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText=" Bank Name">
                            <ItemTemplate>
                                <asp:TextBox ID="txt_Bank_Name" Text ='<%# Eval("Bank_Name") %>' runat="server"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText=" Reference No.">
                            <ItemTemplate>
                                <asp:TextBox ID="txt_Reference_No" Text ='<%# Eval("Reference_Number") %>' runat="server"></asp:TextBox>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Amount">
                            <ItemTemplate>
                                <asp:TextBox ID="txt_Amount" Text ='<%# Eval("Amount") %>' runat="server" ></asp:TextBox>
                            </ItemTemplate>
                            <FooterStyle HorizontalAlign="Right" />
                            <FooterTemplate>
                 <asp:Button ID="ButtonAdd" CssClass = "header" runat="server" Text="Add New Row" 
                        onclick="ButtonAdd_Click" />
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
                        <td class="style14">
                            <asp:Button ID="btn_Save" CssClass ="header" runat="server" Height="46px" Text="Save" 
                                Width="215px" onclick="btn_Save_Click" style="font-weight: 700" />
                        </td>
                        <td>
                            <asp:Button ID="btn_Cancel" CssClass ="header" runat="server" Height="41px" style="font-weight: 700" 
                                Text="Cancel" Width="215px" PostBackUrl="~/Payment_List.aspx" />
                        </td>
                        <td>
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
