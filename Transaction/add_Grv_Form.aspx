<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="add_Grv_Form.aspx.cs" Inherits="com.pridish.Transaction_add_Grv_Form" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style1">
        <tr>
            <td>
                <h4 class="card-title" 
                    style="box-sizing: border-box; outline: 0px; margin-top: 0px; margin-bottom: 10px; font-family: &quot;Nunito Sans&quot;, sans-serif; font-weight: 600; line-height: 1.2; color: rgb(62, 85, 105); font-size: 18px; position: relative; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial;">
                    Goods Return Voucher - Vendor</h4>
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
                        <td style="width: 444px">
                            <br />
                            <asp:TextBox id="txt_GRV_Number" placeholder="GRV Number " runat="server" 
                                 Height="29px" ReadOnly ="true" 
                                Width="422px"/>
                        </td>
                        <td>
                            <br />
                            <asp:TextBox id="txt_GRV_Date" ReadOnly ="true" placeholder="GRV Date" runat="server" 
                                 Height="29px" 
                                Width="422px" TextMode="SingleLine"/>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 444px">
                            <br />
                            <asp:TextBox id="txt_vendor_Code" placeholder="Vendor Code" runat="server" 
                                 Height="29px" ReadOnly ="true" 
                                Width="422px" ontextchanged="txt_vendor_Code_TextChanged"/>
                        </td>
                        <td>
                            <asp:TextBox id="txt_vendor_Company_Name" placeholder="Vendor Company Name" runat="server" 
                                 Height="29px" 
                                Width="422px"/>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 444px">
                            <asp:TextBox id="txt_vendor_address" placeholder="Vendor Address" runat="server" 
                                 Height="47px" 
                                Width="422px" TextMode="MultiLine"/>
                            <br />
                        </td>
                        <td>
                            <asp:TextBox id="txt_vendor_Contact_person" placeholder="Vendor Contact Person" runat="server" 
                                 Height="29px" 
                                Width="422px"/>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 444px">
                            <asp:TextBox id="txt_vendor_Contact_Details" placeholder="Vendor Contact Details" runat="server" 
                                 Height="29px" ReadOnly ="true" 
                                Width="422px"/>
                            <br />
                        </td>
                        <td>
                            <asp:TextBox id="txt_Email" placeholder="Email" runat="server" 
                                 Height="29px" ReadOnly ="true" 
                                Width="422px" TextMode="Email"/>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 444px">
                            <br />
                            <asp:TextBox id="txt_vendor_invoice_Ref_Number" 
                                placeholder="Vendor Invoice Reference  Number" runat="server" 
                                 Height="29px" 
                                Width="422px"/>
                        </td>
                        <td>
                            <br />
                            <asp:TextBox id="txt_vendor_Invoice_Ref_Date" 
                                placeholder="Vendor Invoice Reference Date" runat="server" 
                                 Height="29px" 
                                Width="422px" TextMode="Date"/>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 444px">
                            <br />
                            <asp:TextBox id="txt_PO_Number" placeholder="PO Number" runat="server" 
                                 Height="29px" ReadOnly ="true" 
                                Width="422px"/>
                        </td>
                        <td>
                            <br />
                            <asp:TextBox id="txt_PO_Date" placeholder="PO Date" runat="server" 
                                 Height="29px" ReadOnly ="true" 
                                Width="422px" TextMode="SingleLine"/>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <br />
                            <asp:TextBox id="txt_remark_For_Return" placeholder="Remark For Return" runat="server" 
                                 Height="54px" 
                                Width="878px" TextMode="MultiLine"/>
                        </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:gridview ID="Gridview1" runat="server" ShowFooter="true" CssClass ="header1" 
            AutoGenerateColumns="false" onrowcreated="Gridview1_RowCreated">
            <Columns>
            <%--<asp:BoundField DataField="RowNumber" HeaderText="Row Number" />--%>
            <asp:TemplateField HeaderText=" Product Code">
                <ItemTemplate>
                    <asp:TextBox ID="txt_Product_Code" runat="server" Text = '<%# Eval("Product_Code") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText=" Product Group">
                <ItemTemplate>
                    <asp:TextBox ID="txt_Product_Group" runat="server" Text = '<%# Eval("Product_Group") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            
            
            <asp:TemplateField HeaderText=" Product Name">
                <ItemTemplate>
                    <asp:TextBox ID="txt_Product_Name" runat="server" Text = '<%# Eval("Product_Name") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText=" Purchase Invoice Number">
                <ItemTemplate>
                    <asp:TextBox ID="txt_Purchase_invoice_Number" runat="server" Text = '<%# Eval("Purchase_Invoice_Number") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText=" Purchase date">
                <ItemTemplate>
                    <asp:TextBox ID="txt_Purchase_Date" runat="server" Text = '<%# Eval("Purchase_Date") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>

            
            
            <asp:TemplateField HeaderText="Product Price">
                <ItemTemplate>
                    <asp:TextBox ID="txt_Product_Price" runat="server" Text = '<%# Eval("Product_Price") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText=" Serial/IMEI">
                <ItemTemplate>
                    <asp:TextBox ID="txt_Serial_Number" runat="server" Text = '<%# Eval("Serial_No") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText=" Product Return Quantity">
                <ItemTemplate>
                    <asp:TextBox ID="txt_Product_Return_Quantity" runat="server" ontextchanged="txt_Product_Quantity_TextChanged" AutoPostBack ="true" Text = '<%# Eval("Product_Return_Quantity") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText=" Tax Amount">
                <ItemTemplate>
                    <asp:TextBox ID="txt_Tax_Amount" runat="server" Text = '<%# Eval("Tax_Amount") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>

            
            <asp:TemplateField HeaderText="Net Amount">
                <ItemTemplate>
                     <asp:TextBox ID="txt_Net_Amount" runat="server" Text = '<%# Eval("Net_Amount") %>'></asp:TextBox>
                </ItemTemplate>

                <FooterStyle HorizontalAlign="Right" />
                <FooterTemplate>
                 <%--<asp:Button ID="ButtonAdd" runat="server" Text="Add New Row" 
                        onclick="ButtonAdd_Click" />--%>
                </FooterTemplate>
            </asp:TemplateField>
                 <%--<asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">Remove</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>--%>
            </Columns>
        </asp:gridview>
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                
                            
                
            </td>
        </tr>
        <tr>
            <td>
                <br />
                        <br />
            </td>
        </tr>
        <tr>
            <td>
                            <table class="style1">
                                <tr>
                                    <td class="style13" style="width: 198px">
                            <asp:Button ID="btn_Save" runat="server" Text="Save" Width="174px" 
                                Height="64px" onclick="btn_Save_Click" />
                                    </td>
                                    <td>
                                        <asp:Button ID="Button1" runat="server" Height="55px" 
                                            PostBackUrl="~/Transaction/GRV_List.aspx" Text="Cancel" Width="164px" />
                                    </td>
                                </tr>
                            </table>
                        </td>
        </tr>
    </table>
</asp:Content>

