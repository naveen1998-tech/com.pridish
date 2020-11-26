<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="RFQ_List.aspx.cs" Inherits="com.pridish.RFQ_List" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">



    <table class="style1">
        <tr>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="btn_RFQPAGE" runat="server" Height="57px" 
                    PostBackUrl="~/Transaction/add_Inquiry.aspx" Text="Add RFQ" Width="171px" />
            </td>
        </tr>
        <tr>
            <td>
                <table class="style1">
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="style11" style="width: 789px">
                            &nbsp;</td>
                        <td style="width: 234px">
                            <asp:TextBox ID="txt_Cust_code" placeholder = "Search Customer Code" 
                                runat="server" Height="41px" Width="214px" AutoPostBack="True" 
                                ontextchanged="txt_Cust_code_TextChanged"></asp:TextBox>
                        </td>
                        <td>
                            <asp:TextBox ID="txt_Cust_name" placeholder = "Search Customer Name" 
                                runat="server" Height="41px" Width="214px" AutoPostBack="True" 
                                ontextchanged="txt_Cust_name_TextChanged"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;</td>
                        <td class="style11" style="width: 789px">
                            &nbsp;</td>
                        <td style="width: 234px">
                            &nbsp;</td>
                        <td>
                            &nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td>
                
                <%--<asp:GridView ID="grdCurrencyList" runat="server" Width="100%" CssClass="table table-striped table-bordered table-hover"
                    AutoGenerateColumns="False" OnRowCommand="grdCurrency_command" EmptyDataText="There are no data records to display.">
                    <Columns>
                        
                        <asp:BoundField DataField="RFQ_Number" HeaderText="RFQ Number" ReadOnly="True" SortExpression="RFQ_Number" />
                        <asp:BoundField DataField="RFQ_Date" HeaderText="RFQ Date " ReadOnly="True" SortExpression="RFQ_Date" />
                        <asp:BoundField DataField="Customer_Code" HeaderText="Customer Code " ReadOnly="True" SortExpression="Customer_Code" />
                        <asp:BoundField DataField="Customer_Name" HeaderText="Customer Name" ReadOnly="True" SortExpression="Customer_Name" />
                        <asp:BoundField DataField="Covering_Note" HeaderText="Covering Note" ReadOnly="True" SortExpression="Covering_Note" 
                         HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" />
                      
                        <asp:TemplateField>
                            <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="gridright"></ItemStyle>
                            <HeaderStyle HorizontalAlign="Center" CssClass="gridright" />
                            <ItemTemplate>
                                <asp:ImageButton ID="cmdEdit" CommandName="RowEdit" runat="server" ToolTip="Edit"
                                    ImageUrl="~/Logo/icon-edit.png" CommandArgument='<%# Eval("rfqid") %>' />
                            </ItemTemplate>
                        </asp:TemplateField>

                    </Columns>
                </asp:GridView>--%>
                <asp:GridView ID="grdCurrencyList" runat="server" Width="100%" CssClass=" grdContent selectedrow"  HeaderStyle-CssClass="header"
                    AutoGenerateColumns="False" OnRowCommand="grdCurrency_command" EmptyDataText="There are no data records to display.">
                    <Columns>
                        
                        <asp:BoundField DataField="RFQ_Number" HeaderText="RFQ Number" ReadOnly="True" SortExpression="RFQ_Number" />
                        <asp:BoundField DataField="RFQ_Date" HeaderText="RFQ Date " ReadOnly="True" SortExpression="RFQ_Date" />
                        <asp:BoundField DataField="Customer_Code" HeaderText="Customer Code " ReadOnly="True" SortExpression="Customer_Code" />
                        <asp:BoundField DataField="Customer_Name" HeaderText="Customer Name" ReadOnly="True" SortExpression="Customer_Name" />
                        <asp:BoundField DataField="product_number" HeaderText="No. Of Product" ReadOnly="True" SortExpression="product_number" />
                        
                        <asp:BoundField DataField="R_Net_Amount" HeaderText="Net Amount" ReadOnly="True" SortExpression="R_Net_Amount" 
                         HeaderStyle-CssClass="visible-lg" ItemStyle-CssClass="visible-lg" />
                      
                        <asp:TemplateField>
                            <ItemStyle HorizontalAlign="Center" Width="5%" CssClass="gridright"></ItemStyle>
                            <HeaderStyle HorizontalAlign="Center" CssClass="gridright" />
                            <ItemTemplate>
                                <asp:ImageButton ID="cmdEdit" CommandName="RowEdit" runat="server" ToolTip="Edit"
                                    ImageUrl="~/Logo/icon-edit.png" CommandArgument='<%# Eval("rfqid") %>' />
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
    </table>



</asp:Content>
