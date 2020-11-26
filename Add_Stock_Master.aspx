<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeBehind="Add_Stock_Master.aspx.cs" Inherits="com.pridish.Add_Stock_Master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <table class="style1" style="height: 317px">
    <tr>
        <td class="style2" style="width: 153px">
            <h4 class="card-title" 
                style="box-sizing: border-box; outline: 0px; margin-top: 0px; margin-bottom: 10px; font-family: &quot; Nunito: Sans&quot; sans-serif; font-weight: 600; line-height: 1.2; color: rgb(62, 85, 105); font-size: 18px; position: relative; font-style: normal; font-variant-ligatures: normal; font-variant-caps: normal; letter-spacing: normal; orphans: 2; text-align: left; text-indent: 0px; text-transform: none; white-space: normal; widows: 2; word-spacing: 0px; -webkit-text-stroke-width: 0px; background-color: rgb(255, 255, 255); text-decoration-style: initial; text-decoration-color: initial;">
                Stock Master</h4>
        </td>
        <td class="style3" style="width: 154px">
            &nbsp;</td>
        <td colspan="4">
            &nbsp;</td>
    </tr>
    <tr>
        <td class="style2" style="width: 153px">
            &nbsp;</td>
        <td class="style3" style="width: 154px">
            <asp:Label ID="Label1" runat="server" Text="Product Code"></asp:Label>
        </td>
        <td colspan="4">
            <br />
            <asp:DropDownList ID="ddl_Product_Code" runat="server" DataTextField="cc" 
                DataValueField="ID" Height="43px" Width="595px" AutoPostBack="true"
                onselectedindexchanged="ddl_Product_Code_SelectedIndexChanged">
            </asp:DropDownList>
            <br />
        </td>
    </tr>
    <tr>
        <td class="style2" style="width: 153px">
            &nbsp;</td>
        <td class="style3" style="width: 154px">
            <asp:Label ID="Label2" runat="server" Text="product group"></asp:Label>
        </td>
        <td colspan="4">
            <br />
            <asp:TextBox ID="txt_Product_Group" runat="server" Height="29px" Width="597px"></asp:TextBox>
        </td>
    </tr>
    
    <tr>
        <td class="style2" style="width: 153px">
            &nbsp;</td>
        <td class="style3" style="width: 154px">
            <asp:Label ID="Label4" runat="server" Text="product size"></asp:Label>
        </td>
        <td colspan="4">
            <br />
            <asp:TextBox ID="txt_Product_Size" runat="server" Height="29px" Width="597px"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td class="style2" style="width: 153px">
            &nbsp;</td>
        <td class="style3" style="width: 154px">
            Product Quantity</td>
        <td colspan="4">
            <br />
            <asp:TextBox ID="txt_Product_Quantity" Text="1" runat="server" Height="29px" 
                Width="597px" ontextchanged="txt_Product_Quantity_TextChanged" 
                AutoPostBack ="true" TextMode="Number"></asp:TextBox>
            <br />
        </td>
    </tr>



     <%--<tr>
        <td class="style2" style="width: 153px">
            &nbsp;</td>
        <td class="style3" style="width: 154px">
            
            </td>
        <td colspan="4">
                <asp:Button ID="btnSubmit" OnClick="GenerateGridView" Text="Submit" 
                runat="server" Width="107px" />
            <br />
            <br />

            <div>
    
    <table border="0" cellpadding="0" cellspacing="0">
       
        
        <tr>
            <td colspan="2">
    <asp:GridView ID="gvData" runat="server" />
            </td>
        </tr>
    </table>
    <br />
    <input type="hidden" name="hfInsertQuery" id="hfInsertQuery" />
    <br />
    <asp:Button Text="Save" runat="server" ID="btnSave" Width="113px"  />
    <br />
    <br />
    <asp:GridView ID="gvRecords" runat="server" EmptyDataText="No record present" />




    </div>
    <div>
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.8.3/jquery.min.js"></script>
    <script type="text/javascript">
        $(function () {
            $('#ContentPlaceHolder1_btnSave').on("click", function () {
                debugger;
                var query = "";
                var columnQuery = "INSERT INTO nagaraju61(";
                var trs = $('#ContentPlaceHolder1_gvData').find('tr:has(:not(th))');
                var columnCount = $($(trs)[0]).find('td').length;
                for (var i = 1; i <= columnCount; i++) {
                    columnQuery += "[" + i + "],";
                }
                columnQuery = columnQuery.substring(0, columnQuery.length - 1);
                columnQuery += ") VALUES (";

                for (var i = 0; i < $(trs).length; i++) {
                    var tds = $(trs)[i];
                    var valueQuery = "";
                    $(tds).find('td').each(function () {
                        valueQuery += "'" + $(this).find('[id*=txtDynamic]').val() + "',";
                    });
                    valueQuery = valueQuery.substring(0, valueQuery.length - 1);
                    query += columnQuery + valueQuery + ") \n";
                }
                $.ajax({
                    type: "POST",
                    url: "Add_Stock_Master.aspx/InsertCustomers",
                    data: '{query: "' + query + '" }',
                    contentType: "application/json; charset=utf-8",
                    dataType: "json",
                    success: function (response) {
                        window.location.href = window.location.href;
                    }
                });
                return false;
            });
        });
    </script>
</div>
        </td>
    </tr>--%>
    
        
    
    
    <tr>
        <td class="style2" style="width: 153px">
            &nbsp;</td>
        <td class="style3" style="width: 154px">
            &nbsp;</td>
        <td class="style11" style="width: 441px">
            <asp:gridview ID="Gridview1" runat="server" ShowFooter="true" CssClass ="header1" 
            AutoGenerateColumns="false" onrowcreated="Gridview1_RowCreated">
            <Columns>
            <%--<asp:BoundField DataField="RowNumber" HeaderText="Row Number" />--%>
            <asp:TemplateField HeaderText=" Barcode">
                <ItemTemplate>
                    <asp:TextBox ID="txt_Barcode" runat="server" ></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText=" Inhouse Number">
                <ItemTemplate>
                    <asp:TextBox ID="txt_InhouseNumber" runat="server" ></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:TemplateField HeaderText=" Serial Number">
                <ItemTemplate>
                    <asp:TextBox ID="txt_Serial_Number" runat="server" ></asp:TextBox>
                </ItemTemplate>
            </asp:TemplateField>
          
            <asp:TemplateField HeaderText="Status">
                <ItemTemplate>
                     <asp:TextBox ID="txt_Status" runat="server" Text = "Instock" ReadOnly="True"></asp:TextBox>
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
        <td>
            &nbsp;</td>
        <td class="style9" style="width: 87px">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    
        
    
    
    <tr>
        <td class="style2" style="width: 153px">
            &nbsp;</td>
        <td class="style3" style="width: 154px">
            &nbsp;</td>
        <td class="style11" style="width: 441px">
            <table class="style1">
                <tr>
                    <td class="style14" style="width: 180px">
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="style14" style="width: 180px">
            <asp:Button ID="btn_Save" runat="server" onclick="btn_Save_Click" Text="Save" 
                Width="140px" Height="44px" />
                    </td>
                    <td>
            <asp:Button ID="btn_Cancel" runat="server" Text="Cancel" Width="136px" Height="41px" 
                            PostBackUrl="~/Stock_List.aspx" />
                    </td>
                    <td>
                        &nbsp;</td>
                </tr>
            </table>
        </td>
        <td>
            &nbsp;</td>
        <td class="style9" style="width: 87px">
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
</table>
    <hr />
    <br />
    <br />
&nbsp;
    </asp:Content>


