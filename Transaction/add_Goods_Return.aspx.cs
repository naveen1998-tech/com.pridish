using com.pridish.Common;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
namespace com.pridish
{
    public partial class Transaction_add_Goods_Return : System.Web.UI.Page
    {
        int gid;

        protected void FillPage(int id)
        {
            //string str = "Select * from MST_Customer where Customer_ID  = " + id.ToString();
            string str = "select * from dbo.Transaction_GRN  t inner join GRN_GridView g on t.GRN_ID = g.GRN_ID where t.GRN_ID  = " + id.ToString();
            DataTable dts = new CommonUtil().GetData(str);
            if (dts.Rows.Count > 0)
            {


                txt_GRN_Number.Text = dts.Rows[0]["GRN_Number"].ToString();
                txt_GRN_Date.Text = dts.Rows[0]["GRN_Date"].ToString();
                txt_cust_Code.Text = dts.Rows[0]["Customer_Code"].ToString();
                txt_company_Name.Text = dts.Rows[0]["Company_Name"].ToString();
                txt_company_Address.Text = dts.Rows[0]["Company_Address"].ToString();
                txt_contact_person.Text = dts.Rows[0]["Contact_Person"].ToString();
                txt_contact_Details.Text = dts.Rows[0]["Contact_Details"].ToString();
                txt_Email.Text = dts.Rows[0]["Email"].ToString();
                txt_cust_Ref_Number.Text = dts.Rows[0]["Cust_Ref_Num"].ToString();
                txt_date.Text = dts.Rows[0]["Cust_Ref_Date"].ToString();
                txt_delivery_Number.Text = dts.Rows[0]["Delivery_number"].ToString();



                txt_delivery_Date.Text = dts.Rows[0]["Delivery_Date"].ToString();
                txt_invoice_number.Text = dts.Rows[0]["Invoice_number"].ToString();
                txt_invoice_Date.Text = dts.Rows[0]["Invoice_Num_date"].ToString();
                txt_quotation_Number.Text = dts.Rows[0]["Quotation_number"].ToString();
                txt_quotation_Date.Text = dts.Rows[0]["Quotation_Date"].ToString();
                txt_remark_For_Return.Text = dts.Rows[0]["Remark_For_Return"].ToString();


                Gridview1.DataSource = dts;
                Gridview1.DataBind();

                ViewState["CurrentTable"] = dts;



            }
        }

        //-------------------------------------------------For DN 2 GRN----------------------------------
        protected void FillPage1(int id)
        {

            string str = "select d.Customer_Reference_Number, d.Customer_Reference_Date, d.Delivery_Note_Number, d.Delivery_Note_Num_Date , d.Quotation_Num, d.Quotation_Date,d.Customer_Code, d.Company_Name, d.Contact_Details, d.Contact_Person, d.Email, g.G_D_Product_Code as Product_Code, g.G_D_Product_Group as Product_Group, g.G_D_Product_Name as Product_Name, g.G_D_Serial_Number as Serial_number from Transaction_Delivery_Note d inner join Delivery_Note_GridView g on d.Delivery_Note_ID = g.Delivery_Note_ID where d.Delivery_Note_ID = " + id.ToString();
            DataTable dts = new CommonUtil().GetData(str);
            if (dts.Rows.Count > 0)
            {


               

                txt_cust_Code.Text = dts.Rows[0]["Customer_Code"].ToString();
                txt_company_Name.Text = dts.Rows[0]["Company_Name"].ToString();
                //txt_company_Address.Text = dts.Rows[0]["Company_Address"].ToString();
                txt_contact_person.Text = dts.Rows[0]["Contact_Person"].ToString();
                txt_contact_Details.Text = dts.Rows[0]["Contact_Details"].ToString();
                txt_Email.Text = dts.Rows[0]["Email"].ToString();

                txt_cust_Ref_Number.Text = dts.Rows[0]["Customer_Reference_Number"].ToString();
                txt_date.Text = dts.Rows[0]["Customer_Reference_Date"].ToString();
                txt_delivery_Number.Text = dts.Rows[0]["Delivery_Note_Number"].ToString();
                txt_delivery_Date.Text = dts.Rows[0]["Delivery_Note_Num_Date"].ToString();
                txt_quotation_Number.Text = dts.Rows[0]["Quotation_Num"].ToString();
                txt_quotation_Date.Text = dts.Rows[0]["Quotation_Date"].ToString();

                Gridview1.DataSource = dts;
                Gridview1.DataBind();

                ViewState["CurrentTable"] = dts;
            }
        }

        //--------------------------------------------------------Calculate Net amount and Tax---------------------------------------------------

        protected void txt_Product_Quantity_TextChanged(object sender, EventArgs e)
        {
            GridViewRow row = (sender as TextBox).NamingContainer as GridViewRow;
            TextBox txt_Product_Quantity = (TextBox)row.FindControl("txt_Product_Unit");
            TextBox txt_Product_Price = (TextBox)row.FindControl("txt_Product_Price");
            TextBox txt_Total_Price = (TextBox)row.FindControl("txt_Total_Price");
            TextBox txt_Tax = (TextBox)row.FindControl("txt_Tax_Amount");

            if (txt_Product_Quantity.Text != "" && txt_Product_Price.Text != "" && txt_Tax.Text != "")
            {
                float qty = float.Parse(txt_Product_Quantity.Text);
                float rate = float.Parse(txt_Product_Price.Text);
                float tex = float.Parse(txt_Tax.Text);
                //int tot = Int32.Parse(txt_Total_Price.Text);

                float total, totaltax, addtax;
                total = rate * qty;
                txt_Total_Price.Text = total.ToString();

                totaltax = total / 100 * tex;

                addtax = total + totaltax;

                txt_Total_Price.Text = addtax.ToString();


            }

        }


        public void GoodsReturn()
        {
            string cs = ConfigurationManager.ConnectionStrings["ERPConnectionString"].ToString();
            SqlConnection cn = new SqlConnection(cs);
            int j = 26000;
            SqlDataAdapter sda = new SqlDataAdapter("Select (GRN_Number) from Transaction_GRN", cn);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            int i = dt.Rows.Count;

            int cnt = j + i;//Convert.ToString(i + 1);
            txt_GRN_Number.Text = "MR-GRN-" + cnt;


        }

        private void SetInitialRow()
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
            dt.Columns.Add(new DataColumn("Product_Code", typeof(string)));
            dt.Columns.Add(new DataColumn("Product_Group", typeof(string)));
            dt.Columns.Add(new DataColumn("Product_Name", typeof(string)));
            dt.Columns.Add(new DataColumn("Purchase_Invoice_Num", typeof(string)));
            dt.Columns.Add(new DataColumn("Purchase_Date", typeof(string)));
            dt.Columns.Add(new DataColumn("Product_Unit", typeof(string)));
            dt.Columns.Add(new DataColumn("Product_Price", typeof(string)));
            dt.Columns.Add(new DataColumn("Serial_number", typeof(string)));
            dt.Columns.Add(new DataColumn("Product_Return_Quantity", typeof(string)));
            dt.Columns.Add(new DataColumn("Tax_Amount", typeof(string)));
            dt.Columns.Add(new DataColumn("Net_Amount", typeof(string)));



            dr = dt.NewRow();
            dr["RowNumber"] = 1;
            dr["Product_Code"] = string.Empty;
            dr["Product_Group"] = string.Empty;
            dr["Product_Name"] = string.Empty;
            dr["Purchase_Invoice_Num"] = string.Empty;
            dr["Purchase_Date"] = string.Empty;
            dr["Product_Unit"] = string.Empty;
            dr["Product_Price"] = string.Empty;
            dr["Serial_number"] = string.Empty;
            dr["Product_Return_Quantity"] = string.Empty;
            dr["Tax_Amount"] = string.Empty;
            dr["Net_Amount"] = string.Empty;


            dt.Rows.Add(dr);
            dr = dt.NewRow();

            //Store the DataTable in ViewState
            ViewState["CurrentTable"] = dt;

            Gridview1.DataSource = dt;
            Gridview1.DataBind();
        }
        private void AddNewRowToGrid()
        {
            int rowIndex = 0;

            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        //extract the TextBox values
                        TextBox box1 = (TextBox)Gridview1.Rows[rowIndex].Cells[1].FindControl("txt_Product_Code");
                        TextBox box2 = (TextBox)Gridview1.Rows[rowIndex].Cells[2].FindControl("txt_Product_Group");
                        TextBox box3 = (TextBox)Gridview1.Rows[rowIndex].Cells[3].FindControl("txt_Product_Name");

                        TextBox box4 = (TextBox)Gridview1.Rows[rowIndex].Cells[4].FindControl("txt_Purchase_invoice_Number");
                        TextBox box5 = (TextBox)Gridview1.Rows[rowIndex].Cells[5].FindControl("txt_Purchase_Date");
                        TextBox box6 = (TextBox)Gridview1.Rows[rowIndex].Cells[6].FindControl("txt_Product_Unit");
                        TextBox box7 = (TextBox)Gridview1.Rows[rowIndex].Cells[7].FindControl("txt_Product_Price");
                        TextBox box8 = (TextBox)Gridview1.Rows[rowIndex].Cells[8].FindControl("txt_Serial_Number");
                        TextBox box9 = (TextBox)Gridview1.Rows[rowIndex].Cells[9].FindControl("txt_Product_Return_Quantity");
                        TextBox box10 = (TextBox)Gridview1.Rows[rowIndex].Cells[10].FindControl("txt_Tax_Amount");
                        TextBox box11 = (TextBox)Gridview1.Rows[rowIndex].Cells[11].FindControl("txt_Total_Price");


                        drCurrentRow = dtCurrentTable.NewRow();

                        drCurrentRow["RowNumber"] = i + 1;
                        drCurrentRow["Product_Code"] = box1.Text;
                        drCurrentRow["Product_Group"] = box2.Text;
                        drCurrentRow["Product_Name"] = box3.Text;

                        drCurrentRow["Purchase_Invoice_Num"] = box4.Text;
                        drCurrentRow["Purchase_Date"] = box5.Text;
                        drCurrentRow["Product_Unit"] = box6.Text;
                        drCurrentRow["Product_Price"] = box7.Text;
                        drCurrentRow["Serial_number"] = box8.Text;
                        drCurrentRow["Product_Return_Quantity"] = box9.Text;
                        drCurrentRow["Tax_Amount"] = box10.Text;
                        drCurrentRow["Net_Amount"] = box11.Text;


                        rowIndex++;
                    }
                    dtCurrentTable.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable"] = dtCurrentTable;

                    Gridview1.DataSource = dtCurrentTable;
                    Gridview1.DataBind();
                }
            }
            else
            {
                Response.Write("ViewState is null");
            }

            //Set Previous Data on Postbacks
            SetPreviousData();
        }
        private void SetPreviousData()
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 0)
                {
                    for (int i = 1; i < dt.Rows.Count; i++)
                    {
                        TextBox box1 = (TextBox)Gridview1.Rows[rowIndex].Cells[1].FindControl("txt_Product_Code");
                        TextBox box2 = (TextBox)Gridview1.Rows[rowIndex].Cells[2].FindControl("txt_Product_Group");
                        TextBox box3 = (TextBox)Gridview1.Rows[rowIndex].Cells[3].FindControl("txt_Product_Name");

                        TextBox box4 = (TextBox)Gridview1.Rows[rowIndex].Cells[4].FindControl("txt_Purchase_invoice_Number");
                        TextBox box5 = (TextBox)Gridview1.Rows[rowIndex].Cells[5].FindControl("txt_Purchase_Date");
                        TextBox box6 = (TextBox)Gridview1.Rows[rowIndex].Cells[6].FindControl("txt_Product_Unit");
                        TextBox box7 = (TextBox)Gridview1.Rows[rowIndex].Cells[7].FindControl("txt_Product_Price");
                        TextBox box8 = (TextBox)Gridview1.Rows[rowIndex].Cells[8].FindControl("txt_Serial_Number");
                        TextBox box9 = (TextBox)Gridview1.Rows[rowIndex].Cells[9].FindControl("txt_Product_Return_Quantity");
                        TextBox box10 = (TextBox)Gridview1.Rows[rowIndex].Cells[10].FindControl("txt_Tax_Amount");
                        TextBox box11 = (TextBox)Gridview1.Rows[rowIndex].Cells[11].FindControl("txt_Total_Price");

                        box1.Text = dt.Rows[i]["Product_Code"].ToString();
                        box2.Text = dt.Rows[i]["Product_Group"].ToString();
                        box3.Text = dt.Rows[i]["Product_Name"].ToString();

                        box4.Text = dt.Rows[i]["Purchase_Invoice_Num"].ToString();
                        box5.Text = dt.Rows[i]["Purchase_Date"].ToString();
                        box6.Text = dt.Rows[i]["Product_Unit"].ToString();
                        box7.Text = dt.Rows[i]["Product_Price"].ToString();
                        box8.Text = dt.Rows[i]["Serial_number"].ToString();
                        box9.Text = dt.Rows[i]["Product_Return_Quantity "].ToString();
                        box10.Text = dt.Rows[i]["Tax_Amount"].ToString();
                        box11.Text = dt.Rows[i]["Net_Amount"].ToString();


                        rowIndex++;

                    }
                }
                // ViewState["CurrentTable"] = dt;

            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            txt_GRN_Date.Text = DateTime.Now.ToString("dd-MM-yyyy");
            GoodsReturn();

            if (Session["UserID"] == null)
            {
                Session.Abandon();
                Response.Redirect("~/Login.aspx");
            }

            if (!Page.IsPostBack)
            {
                SetInitialRow();


                if (Request.QueryString["track"] != null && Request.QueryString["track"] == "Edit")
                {
                    gid = int.Parse(Request.QueryString["id"].ToString());
                    FillPage(gid);
                }
                //----------------------------------for DN 2 GRN-----------------------
                else if (Request.QueryString["track"] != null && Request.QueryString["track"] == "Edit3")
                {
                    gid = int.Parse(Request.QueryString["id"].ToString());
                    FillPage1(gid);
                }

            }
            else
            {
                if (Request.QueryString["track"] != null && Request.QueryString["track"] == "Edit")
                {
                    gid = int.Parse(Request.QueryString["id"].ToString());
                }
                else
                {
                    gid = 0;
                }
            }
        }

        protected void ButtonAdd_Click(object sender, EventArgs e)
        {
            AddNewRowToGrid();
        }
        protected bool Button1_Click(int id)
        {
            int rowIndex = 0;
            StringCollection sc = new StringCollection();
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable"];
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        //extract the TextBox values
                        TextBox box1 = (TextBox)Gridview1.Rows[rowIndex].Cells[0].FindControl("txt_Product_Code");
                        TextBox box2 = (TextBox)Gridview1.Rows[rowIndex].Cells[1].FindControl("txt_Product_Group");
                        TextBox box3 = (TextBox)Gridview1.Rows[rowIndex].Cells[2].FindControl("txt_Product_Name");

                        TextBox box4 = (TextBox)Gridview1.Rows[rowIndex].Cells[3].FindControl("txt_Purchase_invoice_Number");
                        TextBox box5 = (TextBox)Gridview1.Rows[rowIndex].Cells[4].FindControl("txt_Purchase_Date");
                        TextBox box6 = (TextBox)Gridview1.Rows[rowIndex].Cells[5].FindControl("txt_Product_Unit");
                        TextBox box7 = (TextBox)Gridview1.Rows[rowIndex].Cells[6].FindControl("txt_Product_Price");
                        TextBox box8 = (TextBox)Gridview1.Rows[rowIndex].Cells[7].FindControl("txt_Serial_Number");
                        TextBox box9 = (TextBox)Gridview1.Rows[rowIndex].Cells[8].FindControl("txt_Product_Return_Quantity");
                        TextBox box10 = (TextBox)Gridview1.Rows[rowIndex].Cells[9].FindControl("txt_Tax_Amount");
                        TextBox box11 = (TextBox)Gridview1.Rows[rowIndex].Cells[10].FindControl("txt_Total_Price");

                        //get the values from the TextBoxes
                        //then add it to the collections with a comma "," as the delimited values
                        sc.Add(box1.Text + "|" + box2.Text + "|" + box3.Text + "|" + box4.Text + "|" + box5.Text + "|" + box6.Text + "|" + box7.Text + "|" + box8.Text + "|" + box9.Text + "|" + box10.Text+ "|" + box11.Text);
                       
                        rowIndex++;
                    }
                    //Call the method for executing inserts
                    return InsertRecords(sc, id);
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        //A method that returns a string which calls the connection string from the web.config
        private string GetConnectionString()
        {
            //"DBConnection" is the name of the Connection String
            //that was set up from the web.config file
            return System.Configuration.ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        }
        //A method that Inserts the records to the database
        private bool InsertRecords(StringCollection sc, int id)
        {
            SqlConnection conn = new SqlConnection(GetConnectionString());
            StringBuilder sb = new StringBuilder(string.Empty);
            string[] splitItems = null;
            foreach (string item in sc)
            {
                if (gid == 0)
                {
                    const string sqlStatement = "INSERT INTO GRN_GridView (GRN_ID, Product_Code, Product_Group, Product_Name, Purchase_Invoice_Num, Purchase_Date, Product_Unit, Product_Price, Serial_number, Product_Return_Quantity, Tax_Amount, Net_Amount  ) VALUES";
                    if (item.Contains("|"))
                    {
                        splitItems = item.Split("|".ToCharArray());
                        sb.AppendFormat("{0}('{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}'); ", sqlStatement, id, splitItems[0], splitItems[1], splitItems[2], splitItems[3], splitItems[4], splitItems[5], splitItems[6], splitItems[7], splitItems[8], splitItems[9], splitItems[10]);
                    }
                }
                else
                {
                    string strParam = "";
                    const string sqlStatement = " update GRN_GridView set ";
                    if (item.Contains("|"))
                    {
                        splitItems = item.Split("|".ToCharArray());

                        strParam = strParam + "Product_Code ='" + splitItems[0] + "',Product_Group = '" + splitItems[1] + "',Product_Name ='" + splitItems[2] + "', Purchase_Invoice_Num = '" + splitItems[3] + "', Purchase_Date = '" + splitItems[4] + "', Product_Unit = '" + splitItems[5] + "', Product_Price = '" + splitItems[6] + "', Serial_number ='" + splitItems[7] + "', Product_Return_Quantity ='" + splitItems[8] + "', Tax_Amount ='" + splitItems[9] + "', Net_Amount ='" + splitItems[10] + "' where Product_Code ='" + splitItems[0] + "' and GRN_ID = " + gid;
                        sb.AppendFormat("{0}{1}", sqlStatement, strParam);
                    }


                }

            }

            try
            {
                return new CommonUtil().InserUpdateQuery(sb.ToString());

                // Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "Script", "alert('Records Successfuly Saved!');", true);

            }
            catch (System.Data.SqlClient.SqlException ex)
            {
                return false;

            }

        }
        // Hide the Remove Button at the last row of the GridView
        protected void Gridview1_RowCreated(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                LinkButton lb = (LinkButton)e.Row.FindControl("LinkButton1");
                if (lb != null)
                {
                    if (dt.Rows.Count > 1)
                    {
                        if (e.Row.RowIndex == dt.Rows.Count - 1)
                        {
                            lb.Visible = false;
                        }
                    }
                    else
                    {
                        lb.Visible = false;
                    }
                }
            }
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            LinkButton lb = (LinkButton)sender;
            GridViewRow gvRow = (GridViewRow)lb.NamingContainer;
            int rowID = gvRow.RowIndex + 1;
            if (ViewState["CurrentTable"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable"];
                if (dt.Rows.Count > 1)
                {
                    if (gvRow.RowIndex < dt.Rows.Count - 1)
                    {
                        //Remove the Selected Row data
                        dt.Rows.Remove(dt.Rows[rowID]);
                    }
                }
                //Store the current data in ViewState for future reference
                ViewState["CurrentTable"] = dt;
                //Re bind the GridView for the updated data
                Gridview1.DataSource = dt;
                Gridview1.DataBind();
            }

            //Set Previous Data on Postbacks
            SetPreviousData();
        }

        protected void btn_save_Click(object sender, EventArgs e)
        {
            if (gid == 0)
            {
                string strinsert = @"insert into Transaction_GRN( GRN_Number, GRN_Date, Customer_Code, Company_Name, Company_Address, Contact_Person, Contact_Details, Email, Cust_Ref_Num, Cust_Ref_Date, Delivery_number, Delivery_Date, Invoice_number, Invoice_Num_date, Quotation_number, Quotation_Date, Remark_For_Return  ) 
                          values('" + txt_GRN_Number.Text.ToString().Trim() + "', '" + txt_GRN_Date.Text.ToString().Trim() + "', '" + txt_cust_Code.Text.ToString().Trim() + "', '" + txt_company_Name.Text.ToString().Trim() + "', '" + txt_company_Address.Text.ToString().Trim() +
                                            "', '" + txt_contact_person.Text.ToString().Trim() + "', '" + txt_contact_Details.Text.ToString().Trim() + "', '" + txt_Email.Text.ToString().Trim() + "', '" + txt_cust_Ref_Number.Text.ToString().Trim() +
                                            "', '" + txt_date.Text.ToString().Trim() + "', '" + txt_delivery_Number.Text.ToString().Trim() + "', '" + txt_delivery_Date.Text.ToString().Trim() + "', '" + txt_invoice_number.Text.ToString().Trim() + "', '" + txt_invoice_Date.Text.ToString().Trim() + "', '" + txt_quotation_Number.Text.ToString().Trim() + "', '" + txt_quotation_Date.Text.ToString().Trim() + "', '" + txt_remark_For_Return.Text.ToString().Trim() + "')";
                bool res = new CommonUtil().InserUpdateQuery(strinsert);
                DataTable dt = new CommonUtil().GetData("select max(GRN_ID) from Transaction_GRN");
                if (dt.Rows.Count > 0)
                {
                    int rs = int.Parse(dt.Rows[0][0].ToString());

                    if (rs > 0)
                    {
                        bool r = Button1_Click(rs);
                        if (r)
                        {


                            string message = "Your details have been saved successfully.";
                            string script = "window.onload = function(){ alert('";
                            script += message;
                            script += "')};";
                            ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
                            Response.Redirect("GRN_List.aspx");
                            //redirect // succes message
                        }
                        else
                        {
                            string message = "Your details have been not saved.";
                            string script = "window.onload = function(){ alert('";
                            script += message;
                            script += "')};";
                            ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);

                            // failure message // page reload
                        }
                    }
                }
                else
                {
                    string message = "Your details have been not saved.";
                    string script = "window.onload = function(){ alert('";
                    script += message;
                    script += "')};";
                    ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
                    // failure message // page reload
                }
            }
            else
            {
                string strinsert = @"update Transaction_GRN set Customer_Code = '" + txt_cust_Code.Text.ToString().Trim() + "', Company_Name = '" + txt_company_Name.Text.ToString().Trim() + "', Company_Address = '" + txt_company_Address.Text.ToString().Trim() +
                                            "', Contact_Person = '" + txt_contact_person.Text.ToString().Trim() + "', Contact_Details = '" + txt_contact_Details.Text.ToString().Trim() + "', Email = '" + txt_Email.Text.ToString().Trim() + "', Cust_Ref_Num = '" + txt_cust_Ref_Number.Text.ToString().Trim() +
                                            "', Cust_Ref_Date = '" + txt_date.Text.ToString().Trim() + "', Delivery_number = '" + txt_delivery_Number.Text.ToString().Trim() + "', Delivery_Date = '" + txt_delivery_Date.Text.ToString().Trim() + "', Invoice_number = '" + txt_invoice_number.Text.ToString().Trim() + "', Invoice_Num_date = '" + txt_invoice_Date.Text.ToString().Trim() + "', Quotation_number = '" + txt_quotation_Number.Text.ToString().Trim() + "', Quotation_Date = '" + txt_quotation_Date.Text.ToString().Trim() + "', Remark_For_Return ='" + txt_remark_For_Return.Text.ToString().Trim() + "' where GRN_ID = "+gid;


                bool res = new CommonUtil().InserUpdateQuery(strinsert);
                DataTable dt = new CommonUtil().GetData("select max(GRN_ID) from Transaction_GRN");
                if (dt.Rows.Count > 0)
                {
                    int rs = int.Parse(dt.Rows[0][0].ToString());

                    if (rs > 0)
                    {
                        bool r = Button1_Click(rs);
                        if (r)
                        {


                            string message = "Your details have been Updated successfully.";
                            string script = "window.onload = function(){ alert('";
                            script += message;
                            script += "')};";
                            ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
                            Response.Redirect("GRN_List.aspx");
                            //redirect // succes message
                        }
                        else
                        {
                            string message = "Your details have been not Updated.";
                            string script = "window.onload = function(){ alert('";
                            script += message;
                            script += "')};";
                            ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);

                            // failure message // page reload
                        }
                    }
                }
            
            }
        }

        protected void autofill()
        {
            string autof = "select Company_Name, Address from MST_Customer where Customer_Code =  '" + txt_cust_Code.Text.ToString() + "'";
            DataTable dts = new CommonUtil().GetData(autof);
            if (dts.Rows.Count > 0)
            {

                txt_company_Name.Text = dts.Rows[0]["Company_Name"].ToString();
                txt_company_Address.Text = dts.Rows[0]["Address"].ToString();

            }
        }

        protected void txt_cust_Code_TextChanged(object sender, EventArgs e)
        {
            autofill();
        }
    }
}