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

    public partial class Transaction_add_Cash_Memo : System.Web.UI.Page
    {
        int cid, cmid;

        protected void Page_Load(object sender, EventArgs e)
        {
            txt_cash_Memo_Date.Text = DateTime.Now.ToString("dd-MM-yyyy");
            if (Session["UserID"] == null)
            {
                Session.Abandon();
                Response.Redirect("~/Login.aspx");
            }
            if (!Page.IsPostBack)
            {

                CasmemoID();
                SetInitialRow();

                if (Request.QueryString["track"] != null && Request.QueryString["track"] == "Edit")
                {
                    cid = int.Parse(Request.QueryString["id"].ToString());
                    FillPage(cid);
                }
                else if (Request.QueryString["track"] != null && Request.QueryString["track"] == "Edit1")
                {
                    cid = int.Parse(Request.QueryString["id"].ToString());
                    FillPage1(cid);
                }


            }
            else
            {
                if (Request.QueryString["track"] != null && Request.QueryString["track"] == "Edit")
                {
                    cid = int.Parse(Request.QueryString["id"].ToString());
                }
                else
                {
                    cid = 0;
                }
            }

        }

        protected void FillPage(int id)
        {
            //string str = "Select * from MST_Customer where Customer_ID  = " + id.ToString();
            string str = "select * from dbo.Transaction_Cash_Memo c inner join Cash_Memo_GridView g on c.Cash_Memo_ID = g.Cash_Memo_ID where c.Cash_Memo_ID  = " + id.ToString();
            DataTable dts = new CommonUtil().GetData(str);
            if (dts.Rows.Count > 0)
            {


                txt_cash_Memo_Number.Text = dts.Rows[0]["Cash_Memo_Number"].ToString();
                txt_cash_Memo_Date.Text = dts.Rows[0]["Case_Memo_Date"].ToString();
                txt_customer_Code.Text = dts.Rows[0]["Customer_Code"].ToString();
                txt_company_Name.Text = dts.Rows[0]["Company_Name"].ToString();
                txt_company_Address.Text = dts.Rows[0]["Company_Address"].ToString();
                txt_contact_Person.Text = dts.Rows[0]["Contact_Person"].ToString();
                txt_contact_Details.Text = dts.Rows[0]["Contact_Details"].ToString();
                txt_Email.Text = dts.Rows[0]["Email"].ToString();
                txt_customer_Reference_Number.Text = dts.Rows[0]["Cust_Ref_Number"].ToString();
                txt_customer_Reference_Date.Text = dts.Rows[0]["Cust_Ref_Date"].ToString();
                txt_quotation_Number.Text = dts.Rows[0]["Quotation_Number"].ToString();
                


                txt_quotation_Date.Text = dts.Rows[0]["Quotation_Date"].ToString();
                txt_shipping_Handling.Text = dts.Rows[0]["Shiping_Handling"].ToString();
                txt_terms_Condition.Text = dts.Rows[0]["Terms_condition"].ToString();
                txt_delivery_Number.Text = dts.Rows[0]["Delivery_Note_Num"].ToString();
                txt_delivery_Date.Text = dts.Rows[0]["Delivery_Note_Date"].ToString();

                Gridview1.DataSource = dts;
                Gridview1.DataBind();

                ViewState["CurrentTable"] = dts;
                



            }
        }
        //--------------------------------Delivery note 2 Cash memo---------------------------------------
        protected void FillPage1(int id)
        {
            //string str = "Select * from MST_Customer where Customer_ID  = " + id.ToString();
            string str = "select d.Customer_Reference_Number,d.Customer_Reference_Date, d.Quotation_Num, d.Quotation_Date, d.Customer_Code,d.Delivery_Note_Number,d.Delivery_Note_Num_Date, d.Company_Name, d.Contact_Person, d.Contact_Details, d.Email, dg.G_D_Product_Code as Product_Code, dg.G_D_Product_Name as Product_Name, dg.G_D_Serial_Number as Serial_Number, dg.G_D_Product_Quantity as Product_Quantity, dg.G_D_Product_Warrenty as Product_Warrenty from Transaction_Delivery_Note d inner join Delivery_Note_GridView dg on d.Delivery_Note_ID = dg.Delivery_Note_ID where d.Delivery_Note_ID =  " + id.ToString();
            DataTable dts = new CommonUtil().GetData(str);
            if (dts.Rows.Count > 0)
            {


               
                txt_customer_Code.Text = dts.Rows[0]["Customer_Code"].ToString();
                txt_company_Name.Text = dts.Rows[0]["Company_Name"].ToString();
                
                txt_contact_Person.Text = dts.Rows[0]["Contact_Person"].ToString();
                txt_contact_Details.Text = dts.Rows[0]["Contact_Details"].ToString();
                txt_Email.Text = dts.Rows[0]["Email"].ToString();
                txt_delivery_Number.Text = dts.Rows[0]["Delivery_Note_Number"].ToString();
                txt_delivery_Date.Text = dts.Rows[0]["Delivery_Note_Num_Date"].ToString();

                txt_customer_Reference_Number.Text = dts.Rows[0]["Customer_Reference_Number"].ToString();
                txt_customer_Reference_Date.Text = dts.Rows[0]["Customer_Reference_Date"].ToString();
                txt_quotation_Number.Text = dts.Rows[0]["Quotation_Num"].ToString();
                txt_quotation_Date.Text = dts.Rows[0]["Quotation_Date"].ToString();

                Gridview1.DataSource = dts;
                Gridview1.DataBind();

                ViewState["CurrentTable"] = dts;




            }
        }

        //----------------------------------Calculate Net amount and Tax -----------------------------------------

        protected void txt_Product_Quantity_TextChanged(object sender, EventArgs e)
        {
            GridViewRow row = (sender as TextBox).NamingContainer as GridViewRow;
            TextBox txt_Product_Quantity = (TextBox)row.FindControl("txt_Product_Quantity");
            TextBox txt_Product_Price = (TextBox)row.FindControl("txt_Product_Price");
            TextBox txt_Total_Price = (TextBox)row.FindControl("txt_Net_Amount");
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


        public void CasmemoID()
        {
            string cs = ConfigurationManager.ConnectionStrings["ERPConnectionString"].ToString();
            SqlConnection cn = new SqlConnection(cs);
            int j = 24000;
            SqlDataAdapter sda = new SqlDataAdapter("Select (Cash_Memo_Number) from Transaction_Cash_Memo", cn);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            int i = dt.Rows.Count;

            int cnt = j + i;//Convert.ToString(i + 1);
            txt_cash_Memo_Number.Text = "MR-CM-" + cnt;


        }

        private void SetInitialRow()
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
            dt.Columns.Add(new DataColumn("Product_Code", typeof(string)));
            dt.Columns.Add(new DataColumn("Product_Name", typeof(string)));
            dt.Columns.Add(new DataColumn("Product_Price", typeof(string)));
            dt.Columns.Add(new DataColumn("Serial_Number", typeof(string)));
            dt.Columns.Add(new DataColumn("Product_Quantity", typeof(string)));
            dt.Columns.Add(new DataColumn("Product_Warrenty", typeof(string)));
            dt.Columns.Add(new DataColumn("Tax_Amount", typeof(string)));
            dt.Columns.Add(new DataColumn("Discount", typeof(string)));
            dt.Columns.Add(new DataColumn("Net_Amount", typeof(string)));

            dr = dt.NewRow();
            dr["RowNumber"] = 1;
            dr["Product_Code"] = string.Empty;
            dr["Product_Name"] = string.Empty;
            dr["Product_Price"] = string.Empty;
            dr["Serial_Number"] = string.Empty;
            dr["Product_Quantity"] = string.Empty;
            dr["Product_Warrenty"] = string.Empty;
            dr["Tax_Amount"] = string.Empty;
            dr["Discount"] = string.Empty;
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
                        TextBox box2 = (TextBox)Gridview1.Rows[rowIndex].Cells[2].FindControl("txt_Product_Name");
                        TextBox box3 = (TextBox)Gridview1.Rows[rowIndex].Cells[3].FindControl("txt_Product_Price");

                        TextBox box4 = (TextBox)Gridview1.Rows[rowIndex].Cells[4].FindControl("txt_Serial_Number");
                        TextBox box5 = (TextBox)Gridview1.Rows[rowIndex].Cells[5].FindControl("txt_Product_Quantity");
                        TextBox box6 = (TextBox)Gridview1.Rows[rowIndex].Cells[6].FindControl("txt_Product_Warrenty");
                        TextBox box7 = (TextBox)Gridview1.Rows[rowIndex].Cells[7].FindControl("txt_Tax_Amount");
                        TextBox box8 = (TextBox)Gridview1.Rows[rowIndex].Cells[8].FindControl("txt_Discount");
                        TextBox box9 = (TextBox)Gridview1.Rows[rowIndex].Cells[9].FindControl("txt_Net_Amount");

                        drCurrentRow = dtCurrentTable.NewRow();

                        drCurrentRow["RowNumber"] = i + 1;
                        drCurrentRow["Product_Code"] = box1.Text;
                        drCurrentRow["Product_Name"] = box2.Text;
                        drCurrentRow["Product_Price"] = box3.Text;

                        drCurrentRow["Serial_Number"] = box4.Text;
                        drCurrentRow["Product_Quantity"] = box5.Text;
                        drCurrentRow["Product_Warrenty"] = box6.Text;
                        drCurrentRow["Tax_Amount"] = box7.Text;
                        drCurrentRow["Discount"] = box8.Text;
                        drCurrentRow["Net_Amount"] = box9.Text;

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
                        TextBox box2 = (TextBox)Gridview1.Rows[rowIndex].Cells[2].FindControl("txt_Product_Name");
                        TextBox box3 = (TextBox)Gridview1.Rows[rowIndex].Cells[3].FindControl("txt_Product_Price");

                        TextBox box4 = (TextBox)Gridview1.Rows[rowIndex].Cells[4].FindControl("txt_Serial_Number");
                        TextBox box5 = (TextBox)Gridview1.Rows[rowIndex].Cells[5].FindControl("txt_Product_Quantity");
                        TextBox box6 = (TextBox)Gridview1.Rows[rowIndex].Cells[6].FindControl("txt_Product_Warrenty");
                        TextBox box7 = (TextBox)Gridview1.Rows[rowIndex].Cells[7].FindControl("txt_Tax_Amount");
                        TextBox box8 = (TextBox)Gridview1.Rows[rowIndex].Cells[8].FindControl("txt_Discount");
                        TextBox box9 = (TextBox)Gridview1.Rows[rowIndex].Cells[9].FindControl("txt_Net_Amount");

                        box1.Text = dt.Rows[i]["Product_Code"].ToString();
                        box2.Text = dt.Rows[i]["Product_Name"].ToString();
                        box3.Text = dt.Rows[i]["Product_Price"].ToString();

                        box4.Text = dt.Rows[i]["Serial_Number"].ToString();
                        box5.Text = dt.Rows[i]["Product_Quantity"].ToString();
                        box6.Text = dt.Rows[i]["Product_Warrenty"].ToString();
                        box7.Text = dt.Rows[i]["Tax_Amount"].ToString();
                        box8.Text = dt.Rows[i]["Discount"].ToString();
                        box9.Text = dt.Rows[i]["Net_Amount"].ToString();

                        rowIndex++;

                    }
                }
                // ViewState["CurrentTable"] = dt;

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
                        TextBox box1 = (TextBox)Gridview1.Rows[rowIndex].Cells[1].FindControl("txt_Product_Code");
                        TextBox box2 = (TextBox)Gridview1.Rows[rowIndex].Cells[2].FindControl("txt_Product_Name");
                        TextBox box3 = (TextBox)Gridview1.Rows[rowIndex].Cells[3].FindControl("txt_Product_Price");

                        TextBox box4 = (TextBox)Gridview1.Rows[rowIndex].Cells[4].FindControl("txt_Serial_Number");
                        TextBox box5 = (TextBox)Gridview1.Rows[rowIndex].Cells[5].FindControl("txt_Product_Quantity");
                        TextBox box6 = (TextBox)Gridview1.Rows[rowIndex].Cells[6].FindControl("txt_Product_Warrenty");
                        TextBox box7 = (TextBox)Gridview1.Rows[rowIndex].Cells[7].FindControl("txt_Tax_Amount");
                        TextBox box8 = (TextBox)Gridview1.Rows[rowIndex].Cells[8].FindControl("txt_Discount");
                        TextBox box9 = (TextBox)Gridview1.Rows[rowIndex].Cells[9].FindControl("txt_Net_Amount");

                        //get the values from the TextBoxes
                        //then add it to the collections with a comma "," as the delimited values
                        sc.Add(box1.Text + "|" + box2.Text + "|" + box3.Text + "|" + box4.Text + "|" + box5.Text + "|" + box6.Text + "|" + box7.Text + "|" + box8.Text + "|" + box9.Text);
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
                if (cid == 0)
                {
                    const string sqlStatement = "INSERT INTO Cash_Memo_GridView ( Cash_Memo_ID, Product_Code, Product_Name, Product_Price, Serial_Number, Product_Quantity, Product_Warrenty, Tax_Amount, Discount, Net_Amount ) VALUES";
                    if (item.Contains("|"))
                    {
                        splitItems = item.Split("|".ToCharArray());
                        sb.AppendFormat("{0}('{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}'); ", sqlStatement, id, splitItems[0], splitItems[1], splitItems[2], splitItems[3], splitItems[4], splitItems[5], splitItems[6], splitItems[7], splitItems[8]);
                    }
                }
                else
                {
                    string strParam = "";
                    const string sqlStatement = " update Cash_Memo_GridView set ";
                    if (item.Contains("|"))
                    {
                        splitItems = item.Split("|".ToCharArray());

                        strParam = strParam + "Product_Code ='" + splitItems[0] + "',Product_Name = '" + splitItems[1] + "',Product_Price ='" + splitItems[2] + "', Serial_Number = '" + splitItems[3] + "', Product_Quantity = '" + splitItems[4] + "', Product_Warrenty = '" + splitItems[5] + "', Tax_Amount = '" + splitItems[6] + "', Discount ='" + splitItems[7] + "', Net_Amount ='" + splitItems[8] + "' where Product_Code ='" + splitItems[0] + "' and Cash_Memo_ID = " + cid;
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
        protected void btn_Save_Click(object sender, EventArgs e)
        {
            if (cid == 0)
            {
                string strinsert = @"insert into Transaction_Cash_Memo(Cash_Memo_Number, Case_Memo_Date, Customer_Code, Company_Name, Company_Address, Contact_Person, Contact_Details, Email, Cust_Ref_Number, Cust_Ref_Date, Quotation_Number, Quotation_Date, Shiping_Handling, Terms_condition , Delivery_Note_Num, Delivery_Note_Date  ) 
                          values('" + txt_cash_Memo_Number.Text.ToString().Trim() + "', '" + txt_cash_Memo_Date.Text.ToString().Trim() + "', '" + txt_customer_Code.Text.ToString().Trim() + "', '" + txt_company_Name.Text.ToString().Trim() + "', '" + txt_company_Address.Text.ToString().Trim() +
                                           "', '" + txt_contact_Person.Text.ToString().Trim() + "', '" + txt_contact_Details.Text.ToString().Trim() + "', '" + txt_Email.Text.ToString().Trim() + "', '" + txt_customer_Reference_Number.Text.ToString().Trim() +
                                           "', '" + txt_customer_Reference_Date.Text.ToString().Trim() + "', '" + txt_quotation_Number.Text.ToString().Trim() + "', '" + txt_quotation_Date.Text.ToString().Trim() + "', '" + txt_shipping_Handling.Text.ToString().Trim() + "', '" + txt_terms_Condition.Text.ToString().Trim() + "', '" + txt_delivery_Number.Text.ToString().Trim() + "', '" + txt_delivery_Date.Text.ToString().Trim() + "')";
                bool res = new CommonUtil().InserUpdateQuery(strinsert);
                DataTable dt = new CommonUtil().GetData("select max(Cash_Memo_ID) from Transaction_Cash_Memo");
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
                            Response.Redirect("Cash_Memo_List.aspx");
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
                string strinsert = @"update Transaction_Cash_Memo set  Customer_Code = '" + txt_customer_Code.Text.ToString().Trim() + "',Company_Name = '" + txt_company_Name.Text.ToString().Trim() + "',Company_Address = '" + txt_company_Address.Text.ToString().Trim() +
                                           "', Contact_Person = '" + txt_contact_Person.Text.ToString().Trim() + "', Contact_Details = '" + txt_contact_Details.Text.ToString().Trim() + "', Email = '" + txt_Email.Text.ToString().Trim() + "', Cust_Ref_Number = '" + txt_customer_Reference_Number.Text.ToString().Trim() +
                                           "', Cust_Ref_Date = '" + txt_customer_Reference_Date.Text.ToString().Trim() + "', Quotation_Number = '" + txt_quotation_Number.Text.ToString().Trim() + "', Quotation_Date = '" + txt_quotation_Date.Text.ToString().Trim() + "', Shiping_Handling = '" + txt_shipping_Handling.Text.ToString().Trim() +
                                           "', Terms_condition = '" + txt_terms_Condition.Text.ToString().Trim() + "' , Delivery_Note_Num =  '" + txt_delivery_Number.Text.ToString().Trim() + "',Delivery_Note_Date = '" + txt_delivery_Date.Text.ToString().Trim() + "'  where Cash_Memo_ID = " + cid;

                bool res = new CommonUtil().InserUpdateQuery(strinsert);
                DataTable dt = new CommonUtil().GetData("select max(Cash_Memo_ID) from Transaction_Cash_Memo");
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
                            Response.Redirect("Cash_Memo_List.aspx");
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

        protected void txt_customer_Code_TextChanged(object sender, EventArgs e)
        {
            autofill();
        }

        protected void autofill()
        {
            string autof = "select  Company_Name, Address from MST_Customer where Customer_Code =  '" + txt_customer_Code.Text.ToString() + "'";
            DataTable dts = new CommonUtil().GetData(autof);
            if (dts.Rows.Count > 0)
            {

                //txt_Customer_Name.Text = dts.Rows[0]["Customer_Name"].ToString();
                txt_company_Name.Text = dts.Rows[0]["Company_Name"].ToString();
                txt_company_Address.Text = dts.Rows[0]["Address"].ToString();

            }
        }
    }
}