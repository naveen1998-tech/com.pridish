<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Employee_List.aspx.cs" Inherits="com.pridish.Employee_List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table class="style1">
        <tr>
            <td>
                <asp:Button ID="Button1" runat="server" Height="57px" 
                    PostBackUrl="~/Employee_Form.aspx" Text="Add Employee" Width="169px" />
            </td>
        </tr>
        <tr>
            <td>
                <table class="style1">
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="style3" style="width: 957px">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                        <td>
                            <asp:TextBox ID="txt_Emp_Name" placeholder = " Search Employee Name" 
                                Autopostback ="True" runat="server" Height="41px" Width="215px" 
                                ontextchanged="txt_Emp_Name_TextChanged"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="style3" style="width: 957px">
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
                <asp:GridView ID="grdCurrency" runat="server" Width="100%"  CssClass=" grdContent selectedrow"  HeaderStyle-CssClass="header"
                    AutoGenerateColumns="False" OnRowCommand="grdEmp_Commond" EmptyDataText="There are no data records to display.">
                    <Columns>
                        
                        <asp:BoundField DataField="Employee_ID" HeaderText="Employee Id" ReadOnly="True" SortExpression="Employee_ID" />
                        <asp:BoundField DataField="Employee_Name" HeaderText="Employee Name" ReadOnly="True" SortExpression="Employee_Name" />
                        <asp:BoundField DataField="Branch_Name" HeaderText="Branch Name" ReadOnly="True" SortExpression="Branch_Name" />
                        <asp:BoundField DataField="Mobile_Number" HeaderText="Mobile Name" ReadOnly="True" SortExpression="Mobile_Number" />
                        <asp:BoundField DataField="Designation" HeaderText="Designation" ReadOnly="True" SortExpression="Designation" 
                         HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" />
                      <asp:TemplateField>
                            <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="gridright"></ItemStyle>
                            <HeaderStyle HorizontalAlign="Center" CssClass="gridright" />
                            <ItemTemplate>
                                <asp:ImageButton ID="cmdEdit" CommandName="RowEdit" runat="server" ToolTip="Edit"
                                    ImageUrl="~/Logo/icon-edit.png" CommandArgument='<%# Eval("Eid") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>
                        

                    </Columns>
                </asp:GridView></td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>
