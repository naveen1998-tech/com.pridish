<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Vendor_List.aspx.cs" Inherits="com.pridish.Vendor_List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="style1">
        <tr>
            <td>
                <asp:Button ID="Button1" runat="server" Height="63px" 
                    PostBackUrl="~/Add_Vendor.aspx" Text="Add Vendor" Width="170px" />
            </td>
        </tr>
        <tr>
            <td>
                <table class="style1">
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="style11" style="width: 968px">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            <asp:TextBox ID="txt_Search_Vendor_Name" placeholder = "Search Vendor Company Name" runat="server" AutoPostBack="True" 
                                Height="41px" ontextchanged="txt_Search_Vendor_Name_TextChanged" Width="215px"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="style11" style="width: 968px">
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
                <asp:GridView ID="grdVendorList" runat="server" Width="100%"  CssClass=" grdContent selectedrow"  HeaderStyle-CssClass="header"
                    AutoGenerateColumns="False" OnRowCommand="grdVendor_Commond" EmptyDataText="There are no data records to display.">
                    <Columns>
                        
                        <asp:BoundField DataField="Vendor_Code" HeaderText="Vendor code" ReadOnly="True" SortExpression="Vendor_Code" />
                        <asp:BoundField DataField="V_Company_Name" HeaderText="Vendor Company Name" ReadOnly="True" SortExpression="V_Company_Name" />
                        <asp:BoundField DataField="V_Contact_Person" HeaderText="Contact Person" ReadOnly="True" SortExpression="V_Contact_Person" />
                        <asp:BoundField DataField="V_Mobile_Number" HeaderText="Mobile Number" ReadOnly="True" SortExpression="V_Mobile_Number" />
                        <asp:BoundField DataField="V_Credit_Limit" HeaderText="Credit Limit" ReadOnly="True" SortExpression="V_Credit_Limit" 
                         HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" />
                      <asp:TemplateField HeaderText = "Edit">
                            <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="gridright"></ItemStyle>
                            <HeaderStyle HorizontalAlign="Center" CssClass="gridright" />
                            <ItemTemplate>
                                <asp:ImageButton ID="cmdEdit" CommandName="RowEdit" runat="server" ToolTip="Edit"
                                    ImageUrl="~/Logo/icon-edit.png" CommandArgument='<%# Eval("vid") %>' />
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
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
