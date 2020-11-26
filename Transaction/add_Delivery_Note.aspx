<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="add_Delivery_Note.aspx.cs" Inherits="com.pridish.Transaction_add_Delivery_Note" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style1">
        <tr>
            <td>
                <h4 class="card-title" 
                    style="box-sizing: border-box; outline: 0px; margin-top: 0px; margin-bottom: 10px; font-family: &quot;Nunito Sans&quot;, sans-serif; font-weight: 600; line-height: 1.2; color: rgb(62, 85, 105); font-size: 18px; position: relative; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial;">
                    Delivery Note </h4>
            </td>
        </tr>
        <tr>
            <td>
                <table class="style1">

                <tr>
                        <td style="width: 442px">
                            <br />
                            <asp:TextBox id="txt_delivery_note_number"  runat="server" 
                                placeholder="Delivery Note Number" Height="29px" 
                                Width="422px" ReadOnly ="true"/>
                        </td>
                        <td>
                            <br />
                            <asp:TextBox id="txt_Delivery_NoteNumber_Date" ReadOnly ="true" placeholder="Delivery Note Number Date" runat="server" 
                                 Height="29px" 
                                Width="422px" TextMode ="SingleLine"/>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 442px">
                            <br />
                            <asp:TextBox id="txt_Customer_Code"  runat="server" 
                                placeholder="Customer Code " Height="29px" ReadOnly ="true" 
                                Width="422px" ontextchanged="txt_Customer_Code_TextChanged"/>
                        </td>
                        <td>
                            <br />
                            <asp:TextBox id="txt_Customer_Name"  runat="server" 
                                placeholder=" Customer Name" Height="29px" 
                                Width="422px"/>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 442px">
                            <br />
                            <asp:TextBox id="txt_company_Name"  runat="server" 
                                placeholder="Company Name" Height="31px" ReadOnly ="true" 
                                Width="419px"/>
                        </td>
                        <td>
                            <br />
                            <asp:TextBox id="txt_Contacct_person"  runat="server" 
                                placeholder="Contact Person" Height="29px" ReadOnly = "true"
                                Width="422px"/>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 442px">
                            <br />
                            <asp:TextBox id="txt_contact_details"  runat="server" 
                                placeholder="Contact Details" Height="29px" ReadOnly ="true" 
                                Width="422px"/>
                        </td>
                        <td>
                            <br />
                            <asp:TextBox id="txt_Email"  runat="server" 
                                placeholder="Email" Height="29px" 
                                Width="422px" ReadOnly = "true"/>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 442px">
                            <br />
                            <asp:TextBox id="txt_Customer_Reference_number"  runat="server" 
                                placeholder="Customer Reference number" Height="29px" 
                                Width="422px" ReadOnly ="true"/>
                            
                        </td>
                        <td>
                            <br />
                            
                                <asp:TextBox id="txt_Customer_Reference_date" placeholder="Customer Reference Date" runat="server" 
                                 Height="29px" 
                                Width="422px" TextMode="SingleLine" ReadOnly ="true"/>
                        </td>
                    </tr>
                    <tr>
                        <td class="style4" style="width: 455px">
                            <br />
                            <asp:TextBox id="txt_quotation_Number"  runat="server" 
                                placeholder="  Quotation number" Height="29px" 
                                Width="422px" ReadOnly ="true"/>
                        </td>
                        <td>
                            <br />
                            <asp:TextBox id="txt_quotation_Date"  runat="server" 
                                placeholder="  Quotation Date" Height="29px" 
                                Width="422px" TextMode="SingleLine" ReadOnly ="true"/>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 442px">
                            <br />
                            
                            <br />
                        </td>
                        <td>
                            <br />
                            
                        </td>
                    </tr>
                    
                </table>
            </td>
        </tr>
        <tr>
            <td>
                            <br />
                            <asp:TextBox id="txt_Shipped_To"  runat="server" 
                                placeholder="Shipped To" Height="88px" 
                                Width="870px" TextMode="MultiLine"/>
                <br />
                        </td>
        </tr>
        <tr>
            <td>
                <br />
                            <asp:TextBox id="txt_terms_Condition" placeholder="Terms &amp; Conditions" runat="server" 
                                 Height="76px" 
                                Width="882px" TextMode="MultiLine"/>
                <br />
            </td>
        </tr>
        <tr>
            <td>
                
                <asp:gridview ID="Gridview1" runat="server" ShowFooter="true" CssClass ="header1" 
            AutoGenerateColumns="false" onrowcreated="Gridview1_RowCreated">
            <Columns>
            <%--<asp:BoundField DataField="RowNumber" HeaderText="Row Number" />--%>
            <asp:TemplateField HeaderText=" Product Code">
                <ItemTemplate>
                    <asp:TextBox ID="txt_Product_Code" runat="server" Text='<%# Eval("G_D_Product_Code") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText=" Product Group">
                <ItemTemplate>
                    <asp:TextBox ID="txt_Product_Group" runat="server" Text='<%# Eval("G_D_Product_Group") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText=" Product Name">
                <ItemTemplate>
                    <asp:TextBox ID="txt_Product_Name" runat="server" Text='<%# Eval("G_D_Product_Name") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText=" Serial/IEMI ">
                <ItemTemplate>
                    <asp:TextBox ID="txt_Product_Serial" runat="server" Text='<%# Eval("G_D_Serial_Number") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Product Quantity">
                <ItemTemplate>
                    <asp:TextBox ID="txt_Product_Quantity" runat="server" Text='<%# Eval("G_D_Product_Quantity") %>'></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            
            <asp:TemplateField HeaderText="Product Warrenty">
                <ItemTemplate>
                     <asp:TextBox ID="txt_Product_Warrenty" runat="server" ></asp:TextBox>
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
                <br />
                            <asp:TextBox id="TextBox1" placeholder="Quantity Of Serial No." AutoPostBack ="true" runat="server" 
                                 Height="37px" 
                                Width="270px" TextMode="Number" 
                    ontextchanged="TextBox1_TextChanged"/>
                <br />
            </td>
        </tr>
        <tr>
            <td>
                <table class="style1">
                    <tr>
                        <td class="style2" style="width: 134px">
                            <asp:gridview ID="Gridview2" runat="server" ShowFooter="true" CssClass ="header1" 
            AutoGenerateColumns="false" onrowcreated="Gridview1_RowCreated1" Height="173px">
            <Columns>
            <%--<asp:BoundField DataField="RowNumber" HeaderText="Row Number" />--%>
            
            
            <asp:TemplateField HeaderText=" Product Code">
                <ItemTemplate>
                    <asp:TextBox ID="txt_product_Code_S" runat="server" ></asp:TextBox>
                   
                </ItemTemplate>
            </asp:TemplateField>
          
            <asp:TemplateField HeaderText="Serial No.">
                <ItemTemplate>
                     <asp:TextBox ID="txt_Serial_No_S" runat="server"  ></asp:TextBox>
                    
                </ItemTemplate>

                <FooterStyle HorizontalAlign="Right" />
                <FooterTemplate>
                <%-- <asp:Button ID="ButtonAdd1" runat="server" Text="Add New Row" 
                        onclick="ButtonAdd_Click1" />--%>
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
                        <td>
                            <table class="style1">
                                <tr>
                                    <td style="width: 174px">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                                <tr>
                                    <td style="width: 174px">
                                        &nbsp;</td>
                                    <td>
                                        &nbsp;</td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
            <td>
                            <br />
                            <asp:TextBox id="txt_Reeived_BY"  runat="server" 
                                placeholder="Received By" Height="36px" 
                                Width="480px"/>
                <br />
                            <br />
                        </td>
        </tr>
                    <tr>
                        <td class="style2" style="width: 134px">
                            <table class="style1" style="width: 240%">
                                <tr>
                                    <td class="style13" style="width: 216px">
                            <asp:Button ID="btn_Save" runat="server" Text="Save" Width="161px" 
                                Height="50px" onclick="btn_Save_Click" />
                                    </td>
                                    <td style="width: 90px">
                                        <asp:Button ID="Button1" runat="server" Height="43px" 
                                            PostBackUrl="~/Transaction/Delivery_Note_List.aspx" Text="Cancel" 
                                            Width="152px" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style2" style="width: 134px">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

