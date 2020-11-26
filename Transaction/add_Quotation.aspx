<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" 
    CodeBehind="add_Quotation.aspx.cs" Inherits="com.pridish.Transaction_add_Quotation" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style1">
        <tr>
            <td>
                <h4 class="card-title" 
                    style="box-sizing: border-box; outline: 0px; margin-top: 0px; margin-bottom: 10px; font-family: &quot;Nunito Sans&quot;, sans-serif; font-weight: 600; line-height: 1.2; color: rgb(62, 85, 105); font-size: 18px; position: relative; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial;">
                    Quotation</h4>
            </td>
        </tr>
        <tr>
            <td>
                <table class="style1">
                    <tr>
                        <td style="width: 482px">
                            <br />
                            <asp:TextBox id="txt_Quotation_Number"  runat="server" 
                                placeholder=" Quotation Number"  Height="29px" 
                                Width="458px"/>


                        </td>
                        <td>
                            <br />
                            <asp:TextBox id="txt_Quotation_Date"  runat="server" 
                                placeholder="  Quotation Date" ReadOnly="true" Height="27px" 
                                Width="463px"/>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 482px">
                            <br />
                            <asp:TextBox id="txt_Customer_Code"  runat="server" 
                                placeholder=" Customer Code" Height="29px" 
                                Width="458px" ontextchanged="txt_Customer_Code_TextChanged" AutoPostBack = "true"></asp:TextBox>
                            <br />
                        </td>
                        <td>
                            <asp:TextBox id="txt_Customer_Name"  runat="server" placeholder=" Customer Name" 
                                 Height="29px" 
                                Width="463px"></asp:TextBox>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 482px">
                            <br />
                            <asp:TextBox id="txt_Company_Name"  runat="server" 
                                placeholder=" Company Name"  Height="29px" 
                                Width="458px"/>
                            <br />
                        </td>
                        <td>
                            <br />
                            <asp:TextBox id="txt_Company_address"  runat="server" 
                                placeholder=" Company Address"  Height="51px" 
                                Width="463px" TextMode="MultiLine" />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 482px">
                            <br />
                            <br />
                            <asp:TextBox id="txt_Contact_Person"  runat="server" 
                                placeholder=" Contact Person"  Height="29px" 
                                Width="458px"/>
                        </td>
                        <td>
                            <br />
                            <br />
                            <asp:TextBox id="txt_Contact_Details"  runat="server" 
                                placeholder=" Contact Details"  Height="29px" 
                                Width="463px"/>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 482px">
                            <br />
                            <br />
                            <asp:TextBox id="txt_Email"  runat="server" 
                                placeholder="  Email"  Height="27px" 
                                Width="463px"/>


                        </td>
                        <td>
                            <br />
                            <br />
                            <asp:TextBox id="txt_Payment_Terms"  runat="server" 
                                placeholder="  Payment Terms" Height="27px" 
                                Width="463px"/>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 482px">
                            <br />
                            <asp:TextBox id="txt_Customer_Reference"  runat="server" 
                                placeholder="  Customer Reference" Height="27px" 
                                Width="463px"/>


                        </td>
                        <td>
                            <br />
                            <asp:TextBox id="txt_cuotomer_Reference_Date"  runat="server" 
                                placeholder="  Customer Reference Date" Height="27px" 
                                Width="463px" TextMode="Date"/>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 482px">
                            <br />
                            

                            <asp:DropDownList ID="ddl_Quotation_Validity" runat="server" Height="41px" 
                                Width="466px" TabIndex="1">
                                <asp:ListItem>Quotation Validity</asp:ListItem>
                                <asp:ListItem>7</asp:ListItem>
                                <asp:ListItem>15</asp:ListItem>
                                <asp:ListItem>21</asp:ListItem>
                                <asp:ListItem>30</asp:ListItem>
                                <asp:ListItem>60</asp:ListItem>
                                <asp:ListItem>90</asp:ListItem>
                                <asp:ListItem>120</asp:ListItem>
                                <asp:ListItem>180</asp:ListItem>
                                <asp:ListItem>365</asp:ListItem>
                            </asp:DropDownList>
                            <br />
                        </td>
                        <td>
                            <br />
                            <asp:TextBox id="txt_Shipping_Handling_Charges"  runat="server" 
                                placeholder="  Shiping & Handling Charges"
                                Width="458px" Height="32px"/>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 482px">
                            <br />
                            <asp:TextBox id="txt_terms_Condition"  runat="server" 
                                placeholder="  Terms & Condition" Height="57px" 
                                Width="465px" TextMode="MultiLine"/>
                            <br />
                        </td>
                        <td>
                            
                            <br />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 482px; margin-left: 40px;">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 482px">
                            <asp:TextBox ID="txt_Product_Grdview_cereate" 
                                placeholder ="Enter Number Product(s) To Quote" AutoPostBack="true" 
                                runat="server" Height="40px" Width="458px" 
                                ontextchanged="txt_Product_Grdview_cereate_TextChanged" TextMode="Number"></asp:TextBox>
                            <%--<asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ErrorMessage="Please Enter Valid Number" ControlToValidate="txt_Product_Grdview_cereate" 
                                BackColor="White" BorderColor="Red" ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>--%>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 482px">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
               
                <asp:gridview ID="Gridview1" runat="server" CssClass=" header1" ShowFooter="true" 
                    AutoGenerateColumns="false" Width="926px">
        <Columns>
        <%--<asp:BoundField DataField="RowNumber" HeaderText="Row Number" />--%>
        <asp:TemplateField HeaderText="Product Code">
            <ItemTemplate>
                <asp:TextBox ID="txt_Product_Code" ontextchanged="txt_Product_Code_TextChanged" AutoPostBack ="true" runat="server" Width="200" Text = '<%# Eval("Q_Product_Code") %>'></asp:TextBox>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Product Group">
            <ItemTemplate>
                <asp:TextBox ID="txt_Product_Group" runat="server" ReadOnly ="true" Text = '<%# Eval("Q_Product_Group") %>'></asp:TextBox>
            </ItemTemplate>
        </asp:TemplateField>
         <asp:TemplateField HeaderText="Product Name">
            <ItemTemplate>
                <asp:TextBox ID="txt_Product_Name" runat="server" ReadOnly ="true" Text='<%# Eval("Q_Product_Name") %>'></asp:TextBox>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Product Quantity">
            <ItemTemplate>
                <asp:TextBox ID="txt_Product_Quantity" ontextchanged="txt_Product_Quantity_TextChanged" Text='<%# Eval("Q_Quantity") %>' AutoPostBack ="true" runat="server" ></asp:TextBox>
            </ItemTemplate>
        </asp:TemplateField>
         <asp:TemplateField HeaderText="Product Price">
            <ItemTemplate>
                <asp:TextBox ID="txt_Product_Price" runat="server" ReadOnly ="false" Text='<%# Eval("Q_Product_Price") %>'></asp:TextBox>
            </ItemTemplate>
        </asp:TemplateField>
         <asp:TemplateField HeaderText="Product Warrenty">
            <ItemTemplate>
                <asp:TextBox ID="txt_Warrenty" runat="server" Text='<%# Eval("Q_Product_Warrenty") %>'></asp:TextBox>
            </ItemTemplate>
        </asp:TemplateField>
        <asp:TemplateField HeaderText="Tax (%)">
            <ItemTemplate>
                <asp:TextBox ID="txt_Tax" runat="server" ontextchanged="txt_Product_Tax_TextChanged" AutoPostBack ="true"  Text='<%# Eval("Q_Tax") %>'></asp:TextBox>
            </ItemTemplate>
        </asp:TemplateField>
        
        <asp:TemplateField HeaderText="Net Amount">
            <ItemTemplate>
                 <asp:TextBox ID="txt_Net_Amount" ReadOnly ="true" runat="server" Text='<%# Eval("Q_Net_Amount") %>'  ></asp:TextBox>
            </ItemTemplate>
            
        <FooterStyle HorizontalAlign="Right" />
                <FooterTemplate>
                 <%--<asp:Button ID="ButtonAdd" runat="server" CssClass="header" Text="Add New Row" 
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
                <table class="style1" style="width: 100%">
                    <tr>
                        <td style="width: 374px">
                            <table class="style1">
                                
                            </table>
                        </td>
                        
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:TextBox id="txt_Remark"  runat="server" 
                                placeholder="  Remark" Height="29px" 
                                Width="458px"/>
                        </td>
                        <td style="width: 398px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <br />
                            
                        </td>
                        <td style="width: 398px">
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <table class="style1">
                                <tr>
                                    <td class="style13" style="width: 223px">
                            <asp:Button ID="btn_Save" runat="server" Height="60px" CssClass="header" onclick="btn_Save_Click" 
                                Text="Save" Width="195px" />
                                    </td>
                                    <td>
                                        <asp:Button ID="Button1" runat="server" CssClass="header" Height="56px" 
                                            PostBackUrl="~/Transaction/Quotation_List.aspx" Text="Cancel" Width="184px" />
                                    </td>
                                </tr>
                            </table>
                            <br />
                            
                        </td>
                        <td style="width: 398px">
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <br />
            </td>
        </tr>
    </table>
</asp:Content>

