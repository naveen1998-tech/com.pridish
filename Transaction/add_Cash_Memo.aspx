<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="add_Cash_Memo.aspx.cs" Inherits="com.pridish.Transaction_add_Cash_Memo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style1">
        <tr>
            <td>
                <h4 class="card-title" 
                    style="box-sizing: border-box; outline: 0px; margin-top: 0px; margin-bottom: 10px; font-family: &quot;Nunito Sans&quot;, sans-serif; font-weight: 600; line-height: 1.2; color: rgb(62, 85, 105); font-size: 18px; position: relative; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial;">
                    Cash Memo</h4>
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
                        <td style="width: 445px">
                            <br />
                            <asp:TextBox id="txt_cash_Memo_Number" placeholder="Cash Memo number" runat="server" 
                                 Height="29px" ReadOnly ="true" 
                                Width="422px"/>
                        </td>
                        <td>
                            <br />
                            <asp:TextBox id="txt_cash_Memo_Date" placeholder="Cash Memo Date" runat="server" 
                                 Height="29px" ReadOnly ="true" 
                                Width="422px" TextMode ="SingleLine"/>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 445px">
                            <br />
                            <asp:TextBox id="txt_customer_Code" placeholder="Customer Code" runat="server" 
                                 Height="29px" ReadOnly ="true"
                                Width="422px" ontextchanged="txt_customer_Code_TextChanged"/>
                            <br />
                        </td>
                        <td>
                            <br />
                            <asp:TextBox id="txt_company_Name" placeholder="Company Name" runat="server" 
                                 Height="29px" ReadOnly ="true" 
                                Width="422px"/>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 445px">
                            <br />
                            <asp:TextBox id="txt_company_Address" placeholder="Company Address" runat="server" 
                                 Height="29px" 
                                Width="422px"/>
                        </td>
                        <td>
                            <br />
                            <asp:TextBox id="txt_contact_Person" placeholder="Contact Person" runat="server" 
                                 Height="29px" ReadOnly ="true" 
                                Width="422px"/>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 445px">
                            <br />
                            <asp:TextBox id="txt_contact_Details" placeholder="Contact Details" runat="server" 
                                 Height="29px" ReadOnly ="true" 
                                Width="422px"/>
                            <br />
                        </td>
                        <td>
                            <br />
                            <asp:TextBox id="txt_Email" placeholder="Email" runat="server" 
                                 Height="29px" ReadOnly ="true" 
                                Width="422px" TextMode="Email"/>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 445px">
                            <br />
                            <asp:TextBox id="txt_customer_Reference_Number" 
                                placeholder="Customer Reference number" runat="server" 
                                 Height="29px" ReadOnly ="true" 
                                Width="422px"/>


                            <br />
                        </td>
                        <td>
                            <br />
                            


                                <asp:TextBox id="txt_customer_Reference_Date" 
                                placeholder="Customer Reference date" runat="server" 
                                 Height="29px" ReadOnly ="true" 
                                Width="422px" TextMode="SingleLine"/>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 445px">
                            <br />
                            <asp:TextBox id="txt_quotation_Number" placeholder="Quotation Number" runat="server" 
                                 Height="29px" ReadOnly ="true" 
                                Width="422px"/>
                        </td>
                        <td>
                            <br />
                            <asp:TextBox id="txt_quotation_Date" placeholder="Quotation Date" runat="server" 
                                 Height="29px"  ReadOnly ="true"
                                Width="422px" TextMode="SingleLine"/>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 438px">
                            <br />
                            <asp:TextBox id="txt_delivery_Number" placeholder="Delivery Number" runat="server" 
                                 Height="29px" ReadOnly ="true" 
                                Width="422px"/>
                        </td>
                        <td>
                            <br />
                            <asp:TextBox id="txt_delivery_Date" placeholder="Delivery Date" runat="server" 
                                 Height="29px" ReadOnly ="true" 
                                Width="422px" TextMode="SingleLine" />
                        </td>
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
               <asp:gridview ID="Gridview1" runat="server" ShowFooter="true"  CssClass ="header1"
            AutoGenerateColumns="false" onrowcreated="Gridview1_RowCreated">
            <Columns>
            <%--<asp:BoundField DataField="RowNumber" HeaderText="Row Number" />--%>
            <asp:TemplateField HeaderText=" Product Code">
                <ItemTemplate>
                    <asp:TextBox ID="txt_Product_Code" runat="server" Text ='<%# Eval("Product_Code") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            
            
            <asp:TemplateField HeaderText=" Product Name">
                <ItemTemplate>
                    <asp:TextBox ID="txt_Product_Name" runat="server" ReadOnly ="true" Text ='<%# Eval("Product_Name") %>'>></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Product Price">
                <ItemTemplate>
                    <asp:TextBox ID="txt_Product_Price" runat="server" ></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText=" Serial/IMEI">
                <ItemTemplate>
                    <asp:TextBox ID="txt_Serial_Number" runat="server" Text ='<%# Eval("Serial_Number") %>'>></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Product Quantity">
                <ItemTemplate>
                    <asp:TextBox ID="txt_Product_Quantity" runat="server" ontextchanged="txt_Product_Quantity_TextChanged" AutoPostBack ="true" Text ='<%# Eval("Product_Quantity") %>'>></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Product Warrenty">
                <ItemTemplate>
                    <asp:TextBox ID="txt_Product_Warrenty" runat="server" Text ='<%# Eval("Product_Warrenty") %>'>></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Tax Amount">
                <ItemTemplate>
                    <asp:TextBox ID="txt_Tax_Amount" runat="server" ></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Discount">
                <ItemTemplate>
                    <asp:TextBox ID="txt_Discount" runat="server" ></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Net Amount">
                <ItemTemplate>
                     <asp:TextBox ID="txt_Net_Amount" runat="server" ></asp:TextBox>
                </ItemTemplate>

                <FooterStyle HorizontalAlign="Right" />
                <FooterTemplate>
                <%-- <asp:Button ID="ButtonAdd" runat="server" Text="Add New Row" 
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
                
                <table class="style1">
                    
                </table>
                
            </td>
        </tr>
        <tr>
            <td>
                
                <br />
                            <asp:TextBox id="txt_terms_Condition" placeholder="Terms &amp; Conditions" runat="server" 
                                 Height="83px" 
                                Width="872px" TextMode="MultiLine"/>
                
            </td>
        </tr>
        <tr>
            <td>
                
                <table class="style1">
                    <tr>
                        <td style="width: 441px">
                            <br />
                            
                           
                            
                            <asp:TextBox id="txt_shipping_Handling" placeholder="Shipping &amp; Handling" runat="server" 
                                 Height="29px" 
                                Width="422px"/>
                            <br />
                            
                           
                            
                        </td>
                        <td>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 441px">
                            <br />
                            <table class="style1">
                                <tr>
                                    <td class="style13" style="width: 191px">
                <asp:Button ID="btn_Save" runat="server" Text="Save" Width="169px" Height="57px" 
                                onclick="btn_Save_Click" />
                                        <br />
                                    </td>
                                    <td>
                                        <asp:Button ID="Button1" runat="server" Height="56px" 
                                            PostBackUrl="~/Transaction/Cash_Memo_List.aspx" Text="Cancel" Width="183px" />
                                        <br />
                                    </td>
                                </tr>
                            </table>
                            <br />
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
                
            </td>
        </tr>
    </table>
</asp:Content>

