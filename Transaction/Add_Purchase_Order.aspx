<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" 
    CodeBehind="Add_Purchase_Order.aspx.cs" Inherits="com.pridish.Transaction_Add_Purchase_Order" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style1">
        <tr>
            <td>
                <h4 class="card-title" 
                    style="box-sizing: border-box; outline: 0px; margin-top: 0px; margin-bottom: 10px; font-family: &quot;Nunito Sans&quot;, sans-serif; font-weight: 600; line-height: 1.2; color: rgb(62, 85, 105); font-size: 18px; position: relative; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial;">
                    Purchase Order </h4>
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
                        <td class="style13" style="width: 483px">
                            <br />
                            <asp:TextBox id="txt_PO_Number" placeholder=" PO Number" runat="server" 
                                 Height="33px" ReadOnly ="true" 
                                Width="420px"/>
                        </td>
                        <td>
                            <br />
                            <asp:TextBox id="txt_PO_Date" ReadOnly ="true" placeholder="PO Date" runat="server" 
                                 Height="29px" 
                                Width="422px" TextMode="SingleLine"/>
                        </td>
                    </tr>
                    <tr>
                        <td class="style13" style="width: 483px">
                            <br />
                            <asp:TextBox id="txt_Vendor_Code" placeholder="Vendor Code" runat="server" 
                                 Height="29px" AutoPostBack ="true" 
                                Width="422px" ontextchanged="txt_Vendor_Code_TextChanged"/>
                        </td>
                        <td>
                            <asp:TextBox id="txt_Company_Name" placeholder="Vendor Company Name" runat="server" 
                                 Height="29px" 
                                Width="422px"/>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td class="style13" style="width: 483px">
                            <br />
                            <asp:TextBox id="txt_Vendor_Company_Address" placeholder="Vendor Company Address" runat="server" 
                                 Height="29px" 
                                Width="422px"/>
                        </td>
                        <td>
                            <asp:TextBox id="txt_Vendor_Contact_Person" placeholder="Vendor Contact Person" runat="server" 
                                 Height="29px" 
                                Width="422px"/>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td class="style13" style="width: 483px">
                            <br />
                            <asp:TextBox id="txt_Vendor_Contact_Desails" placeholder="Vendor Contact Details" runat="server" 
                                 Height="29px" 
                                Width="422px"/>
                        </td>
                        <td>
                            <br />
                            <asp:TextBox id="txt_Vendor_Email" placeholder="Vendor Email" runat="server" 
                                 Height="29px" 
                                Width="422px"/>
                        </td>
                    </tr>
                    <tr>
                        <td class="style13" style="width: 483px">
                            <br />
                            <asp:TextBox id="txt_Sales_Order_Number" placeholder="Sales Order Number" runat="server" 
                                 Height="29px" ReadOnly ="true" 
                                Width="422px"/>
                        </td>
                        <td>
                            <asp:TextBox id="txt_Sales_Order_Num_Date" placeholder="Sales Order Date" runat="server" 
                                 Height="29px" ReadOnly ="true" 
                                Width="422px" TextMode="SingleLine"/>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td class="style13" style="width: 483px">
                            <br />
                            <asp:TextBox id="txt_Vendor_Ref_Number" placeholder="Vendor Reference Number" runat="server" 
                                 Height="29px" 
                                Width="422px"/>
                        </td>
                        <td>
                            <asp:TextBox id="txt_Vendor_Ref_Date" placeholder="Vendor Reference Date" runat="server" 
                                 Height="29px" 
                                Width="422px" TextMode="Date"/>
                            <br />
                        </td>
                    </tr>

                    <tr>
                        <td class="style13" style="width: 483px">
                            <asp:TextBox id="txt_country" placeholder="Country" runat="server" 
                                 Height="29px" 
                                Width="422px"/>
                            <br />
                        </td>
                        <td>
                            <br />
                            <asp:TextBox id="txt_payment_Terms" placeholder="Payment Terms" runat="server" 
                                 Height="29px" 
                                Width="422px"/>
                        </td>
                    </tr>
                    <tr>
                        <td class="style13" style="width: 483px">
                            <br />
                            <asp:TextBox id="txt_currency" placeholder="Currency" runat="server" 
                                 Height="29px" 
                                Width="422px"/>
                        </td>
                        <td>
                            <br />
                            <asp:TextBox id="txt_ship_To_Location" placeholder="Ship To Location" runat="server" 
                                Height="29px" 
                                Width="422px"/>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <br />
                            <asp:TextBox id="txt_terms_Conditions" 
                    placeholder="Terms &amp; Conditions" runat="server" 
                                 Height="79px" 
                                Width="912px" TextMode="MultiLine"/>
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
                    <asp:TextBox ID="txt_Product_Code" runat="server" ReadOnly ="true" Text ='<%# Eval("G_Product_Code") %>'>></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText=" Product Group">
                <ItemTemplate>
                    <asp:TextBox ID="txt_Product_Group" runat="server" ReadOnly ="true" Text ='<%# Eval("G_Product_Group") %>'>></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText=" Product Name">
                <ItemTemplate>
                    <asp:TextBox ID="txt_Product_Name" runat="server" ReadOnly ="true" Text ='<%# Eval("G_Product_Name") %>'>></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Product Price">
                <ItemTemplate>
                    <asp:TextBox ID="txt_Product_Price" runat="server" ReadOnly ="true" Text ='<%# Eval("G_Product_Price") %>'> ></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Product Quantity">
                <ItemTemplate>
                    <asp:TextBox ID="txt_Product_Quantity" runat="server" ReadOnly ="true" Text ='<%# Eval("G_Product_Quantity") %>'>></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText=" Tax %">
                <ItemTemplate>
                    <asp:TextBox ID="txt_Tax" runat="server" ReadOnly ="true" Text = '<%# Eval("G_Tax") %>' ></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Net Amount">
                <ItemTemplate>
                     <asp:TextBox ID="txt_Total_Price" runat="server" ReadOnly ="true" Text = '<%# Eval("G_Net_Amount") %>'></asp:TextBox>
                </ItemTemplate>

                <FooterStyle HorizontalAlign="Right" />
                <FooterTemplate>
                 <%--<asp:Button ID="ButtonAdd" runat="server" Text="Add New Row" 
                        onclick="ButtonAdd_Click" />--%>
                </FooterTemplate>
            </asp:TemplateField>
                 <asp:TemplateField>
                <ItemTemplate>
                    <asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">Remove</asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
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
                <table class="style1">
                    <tr>
                        <td style="width: 187px" class="style13">
                            <asp:Button ID="btn_Save" runat="server" Text="Save" Width="163px" 
                                Height="58px" onclick="btn_Save_Click" />
                            <br />
                        </td>
                        <td>
                            <asp:Button ID="Button1" runat="server" Height="55px" 
                                PostBackUrl="~/Transaction/Product_Order_List.aspx" Text="Cancel" 
                                Width="159px" />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 187px" class="style13">
                            <br />
                        </td>
                        <td>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 187px" class="style13">
                            <br />
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 187px" class="style13">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

