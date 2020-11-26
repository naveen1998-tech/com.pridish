<%@ Page Title="Sales_Order" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" 
    CodeBehind="add_Sales_Order.aspx.cs" Inherits="com.pridish.Transaction_add_Sales_Order" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style1">
        <tr>
            <td>
                <h4 class="card-title" 
                    style="box-sizing: border-box; outline: 0px; margin-top: 0px; margin-bottom: 10px; font-family: &quot;Nunito Sans&quot;, sans-serif; font-weight: 600; line-height: 1.2; color: rgb(62, 85, 105); font-size: 18px; position: relative; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial;">
                    Sales Order</h4>
            </td>
        </tr>
        <tr>
            <td>
                <table class="style1">
                    <tr>
                        <td class="style4" style="width: 455px">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style4" style="width: 455px">
                            <asp:TextBox id="txt_Sales_Order_Number"  runat="server" 
                                placeholder="  Sales Order Number" Height="29px" 
                                Width="422px" ReadOnly ="true"/>
                        </td>
                        <td>
                            <asp:TextBox id="txt_Sales_Order_Date" ReadOnly ="true"  runat="server" 
                                placeholder="  Sales Order date" Height="29px" 
                                Width="422px" TextMode="SingleLine"/>
                        </td>
                    </tr>
                    <tr>
                        <td class="style4" style="width: 455px">
                            <br />
                            <asp:TextBox id="txt_Customer_Code"  AutoPostBack="true" runat="server" 
                                placeholder="  Customer Code" Height="29px" 
                                Width="421px" ontextchanged="txt_Customer_Code_TextChanged" ReadOnly ="true"/>
                        </td>
                        <td>
                            <asp:TextBox id="txt_company_Name" runat="server" 
                                placeholder=" Company Name" Height="29px" 
                                Width="422px" ReadOnly = "true"/>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td class="style4" style="width: 455px">
                            <br />
                            <asp:TextBox id="txt_company_Address"  runat="server" 
                                placeholder="  Company Address" Height="29px" 
                                Width="422px" ReadOnly ="true"/>
                        </td>
                        <td>
                            <asp:TextBox id="txt_contact_Person"  runat="server" 
                                placeholder="  Contact Person" Height="29px" 
                                Width="422px" ReadOnly ="true"/>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td class="style4" style="width: 455px">
                            <br />
                            <asp:TextBox id="txt_contact_Details"  runat="server" 
                                placeholder="  Contact Details" Height="29px" 
                                Width="422px" ReadOnly ="true"/>
                        </td>
                        <td>
                            <asp:TextBox id="txt_email"  runat="server" 
                                placeholder="  Email" Height="29px" 
                                Width="422px" ReadOnly ="true"/>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td class="style4" style="width: 455px">
                            <br />
                            <asp:TextBox id="txt_Customer_Reference_number" 
                                 runat="server" 
                                placeholder="  Customer Reference Number" Height="29px" 
                                Width="422px" ReadOnly ="true"/>
                        </td>
                        <td>
                            <br />
                            <asp:TextBox id="txt_Customer_Reference_Date"  runat="server" 
                                placeholder="  Customer Reference Date" Height="29px" 
                                Width="422px" TextMode="SingleLine" ReadOnly ="true"/>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td class="style4" style="width: 455px">
                            <br />
                            <asp:TextBox id="txt_quotation_Number"  runat="server" 
                                placeholder="  Quotation number" Height="29px" 
                                Width="422px"/>
                        </td>
                        <td>
                            <br />
                            <asp:TextBox id="txt_quotation_Date"  runat="server" 
                                placeholder="  Quotation Date" Height="29px" 
                                Width="422px" TextMode="SingleLine" ReadOnly ="true"/>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                <br />
            </td>
        </tr>
        <tr>
            <td>
                <br />
                <br />
                <br />
                <br />
                <br />
                <br />
                <asp:gridview ID="Gridview1" runat="server" ShowFooter="true" CssClass = "header1" 
            AutoGenerateColumns="false" onrowcreated="Gridview1_RowCreated" >
                    
            <Columns>
           <%-- <asp:BoundField DataField="RowNumber" HeaderText="Row Number" />--%>
            <asp:TemplateField HeaderText=" Product Code">
                <ItemTemplate>
                    <asp:TextBox ID="txt_Product_Code" runat="server" ontextchanged="txt_Product_Code_TextChanged" Text='<%# Eval("G_Product_Code") %>' AutoPostBack="true"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText=" Product Group">
                <ItemTemplate>
                    <asp:TextBox ID="txt_Product_Group" runat="server" ReadOnly ="true" Text='<%# Eval("G_Product_Group") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText=" Product Name">
                <ItemTemplate>
                    <asp:TextBox ID="txt_Product_Name" runat="server" ReadOnly ="true" Text='<%# Eval("G_Product_Name") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Product Quantity">
                <ItemTemplate>
                    <asp:TextBox ID="txt_Product_Quantity" ontextchanged="txt_Product_Quantity_TextChanged" AutoPostBack ="true" runat="server" Text='<%# Eval("G_Product_Quantity") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText=" Serial/IEMI ">
                <ItemTemplate>
                    <asp:TextBox ID="txt_Product_Serial" runat="server" ></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>

            <asp:TemplateField HeaderText="Product Price">
                <ItemTemplate>
                    <asp:TextBox ID="txt_Product_Price" runat="server" ReadOnly ="true" Text='<%# Eval("G_Product_Price") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Tax">
                <ItemTemplate>
                    <asp:TextBox ID="txt_Tax" runat="server" Text='<%# Eval("G_Tax") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Net Amount">
                <ItemTemplate>
                     <asp:TextBox ID="txt_Total_Price" runat="server" Text='<%# Eval("G_Net_Amount") %>' ></asp:TextBox>
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
                <table class="style1">
                    <tr>
                        <td class="style2" style="width: 110px">
                            &nbsp;</td>
                        <td>


                            
                            </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                            <asp:TextBox id="txt_Available_Stock"  runat="server" 
                                placeholder="  Available Stock Of Selected Product" Height="29px" 
                                Width="422px"/>
                        </td>
        </tr>
        <tr>
            <td>
                <br />
                            <asp:TextBox id="txt_terms_Condition"  runat="server" 
                                placeholder="  Terms & Condition" Height="56px" 
                                Width="928px" TextMode="MultiLine"/>
                        </td>
        </tr>
        <tr>
            <td>
                            <table class="style1">
                                <tr>
                                    <td class="style11" style="width: 205px">
                            <asp:Button ID="btn_Save" runat="server" Text="Save" Width="178px" 
                    Height="63px" onclick="btn_Save_Click" />
                                    </td>
                                    <td>
                                        <asp:Button ID="Button1" runat="server" Height="57px" 
                                            PostBackUrl="~/Transaction/Sales_Order_List.aspx" Text="Cancel" Width="183px" />
                                    </td>
                                </tr>
                            </table>
                        </td>
        </tr>
    </table>
</asp:Content>

