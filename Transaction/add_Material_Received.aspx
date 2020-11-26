<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="add_Material_Received.aspx.cs" Inherits="com.pridish.Transaction_add_Material_Received" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style1">
        <tr>
            <td>
                <h4 class="card-title" 
                    style="box-sizing: border-box; outline: 0px; margin-top: 0px; margin-bottom: 10px; font-family: &quot;Nunito Sans&quot;, sans-serif; font-weight: 600; line-height: 1.2; color: rgb(62, 85, 105); font-size: 18px; position: relative; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial;">
                    Material Received Note (MRN)</h4>
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
                        <td style="width: 443px">
                            <br />
                            <asp:TextBox id="txt_MRN_Number" placeholder="MRN number" runat="server" 
                                 Height="29px" ReadOnly ="true" 
                                Width="422px"/>
                        </td>
                        <td>
                            <br />
                            <asp:TextBox id="txt_MRN_Number_Date" ReadOnly="true" placeholder="MRN Number Date" runat="server" 
                                 Height="29px"  
                                Width="422px" TextMode="SingleLine"/>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 443px">
                            <br />
                            
                            <asp:TextBox id="txt_vendor_Code" placeholder="Vendor Code" runat="server" 
                                 Height="29px"  Width="422px" ReadOnly ="true" 
                                ontextchanged="txt_vendor_Code_TextChanged" />
                        </td>
                        <td>
                            <br />
                            <asp:TextBox id="txt_vendor_Company_Address" 
                                placeholder="Vendor Company Address" runat="server" 
                                 Height="43px" ReadOnly ="true" 
                                Width="425px" style="margin-top: 0px" TextMode="MultiLine"/>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 443px">
                            <br />
                            <asp:TextBox id="txt_vendor_Contact_Details" placeholder="Vendor Contact Details " runat="server" 
                                 Height="29px" 
                                Width="422px"/>
                        </td>
                        <td>
                            <br />
                            <asp:TextBox id="txt_vendor_Ref" placeholder="Vendor Reference" runat="server" 
                                 Height="29px" 
                                Width="422px"/>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 443px">
                            <br />
                            <asp:TextBox id="txt_vendor_Name" placeholder="Vendor Name" runat="server" 
                                 Height="29px" 
                                Width="422px"/>
                        </td>
                        <td>
                            <br />
                            <asp:TextBox id="txt_Email" placeholder="Email" runat="server" 
                                 Height="29px" 
                                Width="422px"/>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 443px">
                            <br />
                            <asp:TextBox id="txt_vendor_Invoice_Number" placeholder="Vendor Invoice Number" runat="server" 
                                 Height="29px" 
                                Width="422px"/>
                        </td>
                        <td>
                            <br />
                            <asp:TextBox id="txt_vendor_Invoice_number_Date" 
                                placeholder="Vendor Invoice Number Date" runat="server" 
                                 Height="29px" 
                                Width="422px" TextMode="Date"/>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 443px">
                            <br />
                            <asp:TextBox id="txt_PO_Number" placeholder="PO Number" runat="server" 
                                 Height="29px" ReadOnly ="true"
                                Width="422px"/>
                        </td>
                        <td>
                            <br />
                            <asp:TextBox id="txt_PO_Number_Date" placeholder="PO number Date" runat="server" 
                                 Height="29px" ReadOnly ="true" 
                                Width="422px" TextMode="SingleLine"/>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 443px">
                            <br />
                            <asp:TextBox id="txt_sales_Order_Number" placeholder="Sales order Number" runat="server" 
                                 Height="29px" ReadOnly ="true" 
                                Width="422px"/>
                        </td>
                        <td>
                            <br />
                            <asp:TextBox id="txt_sales_Order_Number_Date" 
                                placeholder="Sales Order Number Date" runat="server" 
                                 Height="29px" ReadOnly ="true" 
                                Width="422px" TextMode="SingleLine"/>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 443px">
                            <br />
                            <asp:TextBox id="txt_vendor_Contact_Person" placeholder="Vendor Contact Person" runat="server" 
                                 Height="29px" ReadOnly ="true"
                                Width="422px"/>
                        </td>
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
        <tr>
            <td>
                <asp:gridview ID="Gridview1" runat="server" ShowFooter="true" CssClass ="header1"
            AutoGenerateColumns="false" onrowcreated="Gridview1_RowCreated">
            <Columns>
            <%--<asp:BoundField DataField="RowNumber" HeaderText="Row Number" />--%>
            <asp:TemplateField HeaderText=" Product Code">
                <ItemTemplate>
                    <asp:TextBox ID="txt_Product_Code" runat="server" Text ='<%# Eval("Product_Code") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText=" Product Group">
                <ItemTemplate>
                    <asp:TextBox ID="txt_Product_Group" runat="server" Text ='<%# Eval("Product_Group") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            
            
            <asp:TemplateField HeaderText=" Product Name">
                <ItemTemplate>
                    <asp:TextBox ID="txt_Product_Name" runat="server" Text ='<%# Eval("Product_Name") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText=" Purchase Invoice Number">
                <ItemTemplate>
                    <asp:TextBox ID="txt_Purchase_invoice_Number" runat="server"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText=" Purchase date">
                <ItemTemplate>
                    <asp:TextBox ID="txt_Purchase_Date" runat="server" TextMode="Date"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Product Price">
                <ItemTemplate>
                    <asp:TextBox ID="txt_Product_Price" runat="server" Text ='<%# Eval("Purchase_Price") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText=" Serial/IMEI">
                <ItemTemplate>
                    <asp:TextBox ID="txt_Serial_Number" runat="server"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText=" Product Ordered Quantity">
                <ItemTemplate>
                    <asp:TextBox ID="txt_Product_Ordered_Quantity" runat="server"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText=" Product Receiced Quntity">
                <ItemTemplate>
                    <asp:TextBox ID="txt_Product_Received_Quantity" runat="server"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText=" Product Balance">
                <ItemTemplate>
                    <asp:TextBox ID="txt_Product_Balance" runat="server"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText=" Tax Amount">
                <ItemTemplate>
                    <asp:TextBox ID="txt_Tax_Amount" runat="server" Text ='<%# Eval("Tax_Amount") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>

            
            
            
            <asp:TemplateField HeaderText="Net Amount">
                <ItemTemplate>
                     <asp:TextBox ID="txt_Total_Price" runat="server" Text ='<%# Eval("Net_Amount") %>'></asp:TextBox>
                </ItemTemplate>

                <FooterStyle HorizontalAlign="Right" />
                <FooterTemplate>
                 <%--<asp:Button ID="ButtonAdd" runat="server" Text="Add New Row" 
                        onclick="ButtonAdd_Click" />--%>
                </FooterTemplate>
            </asp:TemplateField>
                 <asp:TemplateField>
                <ItemTemplate>
                    <%--<asp:LinkButton ID="LinkButton1" runat="server" onclick="LinkButton1_Click">Remove</asp:LinkButton>--%>
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
                            <asp:TextBox id="txt_terms_Conditions" 
                    placeholder="Terms &amp; Conditions" runat="server" 
                                 Height="78px" 
                                Width="864px" TextMode="MultiLine"/>
                <br />
                        </td>
        </tr>
        <tr>
            <td>
                <br />
                            <table class="style1">
                                <tr>
                                    <td class="style13" style="width: 195px">
                            <asp:Button ID="btn_add_Row" runat="server" Text="Save" 
                    Width="163px" Height="62px" onclick="btn_add_Row_Click" />
                                    </td>
                                    <td>
                                        <asp:Button ID="Button1" runat="server" Height="58px" 
                                            PostBackUrl="~/Transaction/MRN_List.aspx" Text="Cancel" Width="190px" />
                                    </td>
                                </tr>
                </table>
                <br />
                        </td>
        </tr>
    </table>
</asp:Content>

