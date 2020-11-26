<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="add_Inquiry.aspx.cs" Inherits="com.pridish.Transaction_add_Inquiry" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    
    <table class="style1">
        <tr>
            <td>
                <table class="style1">
                    <tr>
                        <td class="style14" style="width: 485px">
                            <h4 class="card-title" 
                                style="box-sizing: border-box; outline: 0px; margin-top: 0px; margin-bottom: 10px; font-family: &quot;Nunito Sans&quot;, sans-serif; font-weight: 600; line-height: 1.2; color: rgb(62, 85, 105); font-size: 18px; position: relative; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial;">
                                Request For Quotation</h4>
                        </td>
                        <td>
                            &nbsp;</td>
                    </tr>
                    <tr>
                        <td class="style14" style="width: 485px">
                            <br />
                            <asp:TextBox id="txt_RFQ_Number"  runat="server" 
                                placeholder="  RFQ Number" Height="29px" 
                                Width="460px"/>
                        </td>
                        <td>
                            <br />
                            <asp:TextBox id="txt_RFQ_Date"  runat="server" ReadOnly ="true" 
                                placeholder="  RFQ Date" Height="29px" 
                                Width="460px" TextMode="SingleLine"/>
                        </td>
                    </tr>
                    <tr>
                        <td class="style14" style="width: 485px">
                            <br />
                            <asp:TextBox id="txt_Customer_Code"  runat="server" 
                                placeholder="  Customer Code" Height="29px" 
                                Width="464px" AutoPostBack ="true" ontextchanged="txt_Customer_Code_TextChanged"/>
                        </td>
                        <td>
                            <br />
                            <asp:TextBox id="txt_Customer_Name"  runat="server" 
                                placeholder="Customer Name" Height="29px" 
                                Width="460px"/>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td class="style14" style="width: 485px">
                            <br />
                            <asp:TextBox id="txt_Company_Address"  runat="server" 
                                placeholder="  Company Address" Height="29px" 
                                Width="460px"/>
                        </td>
                        <td>
                            <br />
                            <asp:TextBox id="txt_Contact_Person"  runat="server" 
                                placeholder="  Contact Person" Height="29px" 
                                Width="460px"/>
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td class="style14" style="width: 485px">
                            <asp:TextBox id="txt_Contact_Details"  runat="server" 
                                placeholder="  Contact Details" Height="29px" 
                                Width="461px"/>
                            <br />
                        </td>
                        <td>
                            <br />
                            <asp:TextBox id="txt_Email"  runat="server" 
                               placeholder="  Email" Height="29px" 
                                Width="460px"/>
                            <br />
                        </td>
                    </tr>
                    
                    <tr>
                        <td class="style14" style="width: 485px">
                            <br />
                            <asp:TextBox id="txt_Covering_Note"  runat="server" 
                                placeholder="  Covering Note" Height="29px" 
                                Width="460px"/>
                        </td>
                        <td style="margin-left: 40px">
                            <br />
                            <asp:TextBox id="txt_RFQ_Closing_Date"  runat="server" 
                                placeholder="  RFQ Closing Date" Height="29px" 
                                Width="460px" TextMode="Date">Closing Date</asp:TextBox>
                            <br />
                        </td>
                    </tr>
                    
                    <tr>
                        <td class="style14" style="width: 485px">
                            <br />
                            <asp:TextBox ID="txt_Product_grv_Create" Text ="1" placeholder ="Enter Product Quantity" 
                                AutoPostBack ="true" runat="server" Height="33px" Width="457px" 
                                ontextchanged="txt_Product_grv_Create_TextChanged"></asp:TextBox>

                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" 
                                ErrorMessage="*" ControlToValidate="txt_Product_grv_Create" 
                                  ForeColor="Red" SetFocusOnError="True"></asp:RequiredFieldValidator>
                        </td>
                        <td style="margin-left: 40px">
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                
               
                <asp:gridview ID="Gridview1" runat="server" ShowFooter="true" CssClass = "header1" 
            AutoGenerateColumns="false" onrowcreated="Gridview1_RowCreated">
            <Columns>
            <%--<asp:BoundField DataField="RowNumber" HeaderText="Row Number" />--%>
            
            <asp:TemplateField HeaderText=" Product Name">
                <ItemTemplate>
                    <asp:TextBox ID="txt_Product_Name" Text ='<%# Eval("R_Product_Name") %>' runat="server"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Unit Price">
                <ItemTemplate>
                    <asp:TextBox ID="txt_Unit_Price" Text = '<%# Eval("R_Product_Unit_Price") %>' runat="server"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Product Quantity">
                <ItemTemplate>
                    <asp:TextBox ID="txt_Product_Quantity" Text = '<%# Eval("R_Product_Quantity") %>' runat="server"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText=" Product Warrenty">
                <ItemTemplate>
                    <asp:TextBox ID="txt_Product_Warrenty" Text ='<%# Eval("R_Product_Warrenty") %>' runat="server"></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText="Net Amount ">
                <ItemTemplate>
                     <asp:TextBox ID="txt_Total_Price" Text = '<%# Eval("R_Net_Amount") %>' runat="server"></asp:TextBox>
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
                
            </td>
        </tr>
        <tr>
            <td>
                <br />
                            <asp:TextBox id="txt_Terms_condition"  runat="server" 
                                placeholder="  Terms & Conditions" Height="65px" 
                                Width="801px" TextMode="MultiLine"/>
                        </td>
        </tr>
        <tr>
            <td>
                <br />
                <table class="style1">
                    <tr>
                        <td class="style13" style="width: 194px">
                <asp:Button ID="btn_Save" runat="server" Height="58px" onclick="btn_Save_Click" 
                    style="margin-bottom: 1px" Text="Save" Width="164px" />
                        </td>
                        <td>
                            <asp:Button ID="Button1" runat="server" Height="52px" 
                                PostBackUrl="~/Transaction/RFQ_List.aspx" Text="Cancel" Width="156px" />
                        </td>
                    </tr>
                </table>
                <br />
                <br />
                        </td>
        </tr>
    </table>
    
</asp:Content>

