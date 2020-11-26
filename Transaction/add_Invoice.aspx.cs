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

    public partial class Transaction_add_Invoice : System.Web.UI.Page
    {
        int Pid;
        protected void Page_Load(object sender, EventArgs e)
        {
            txt_invoice_Date.Text = DateTime.Now.ToString("dd-MM-yyyy");
            InvoiceID();

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
                    Pid = int.Parse(Request.QueryString["id"].ToString());
                    FillPage(Pid);
                }
                else if (Request.QueryString["track"] != null && Request.QueryString["track"] == "Edit2")
                {
                    Pid = int.Parse(Request.QueryString["id"].ToString());
                    FillPage1(Pid);
                }

            }
            else
            {
                if (Request.QueryString["track"] != null && Request.QueryString["track"] == "Edit")
                {
                    Pid = int.Parse(Request.QueryString["id"].ToString());
                }
                else
                {
                    Pid = 0;
                }
            }
        }


        protected void FillPage(int id)
        {
            //string str = "Select * from MST_Customer where Customer_ID  = " + id.ToString();
            string str = "select * from dbo.Transaction_Invoice i inner join Invoice_GridView g on i.Invoice_ID = g.Invoice_ID where i.Invoice_ID  = " + id.ToString();
            DataTable dts = new CommonUtil().GetData(str);
            if (dts.Rows.Count > 0)
            {


                txt_customer_Code.Text = dts.Rows[0]["Customer_Code"].ToString();
                txt_company_Name.Text = dts.Rows[0]["Company_Name"].ToString();
                txt_company_Address.Text = dts.Rows[0]["Company_Address"].ToString();
                txt_contact_Person.Text = dts.Rows[0]["Contact_Person"].ToString();
                txt_contact_Details.Text = dts.Rows[0]["Contact_Details"].ToString();
                txt_Email.Text = dts.Rows[0]["Email"].ToString();
                txt_cust_Ref_Date.Text = dts.Rows[0]["Cust_Ref_Date"].ToString();
                txt_cust_Ref_Num.Text = dts.Rows[0]["Cust_Ref_num"].ToString();
                txt_invoice_Number.Text = dts.Rows[0]["Invoice_number"].ToString();
                txt_invoice_Date.Text = dts.Rows[0]["Invoice_Date"].ToString();
                txt_delivery_Number.Text = dts.Rows[0]["Delivery_Number"].ToString();


                txt_delivery_Date.Text = dts.Rows[0]["Delivery_Date"].ToString();
                txt_quotation_Number.Text = dts.Rows[0]["Quotation_Number"].ToString();
                txt_quotation_Date.Text = dts.Rows[0]["Quatation_Date"].ToString();
                txt_payment_Terms.Text = dts.Rows[0]["Payment_Terms"].ToString();
                txt_payment_Due_Date.Text = dts.Rows[0]["Payment_Due_date"].ToString();
                txt_terms_Conditions.Text = dts.Rows[0]["Terms_Condition"].ToString();
                txt_shipping_Handling_Charges.Text = dts.Rows[0]["Shiping_Handling_Charges"].ToString();

                Gridview1.DataSource = dts;
                Gridview1.DataBind();

                ViewState["CurrentTable"] = dts;

            }
        }
        protected void FillPage1(int id)
        {
            //string str = "Select * from MST_Customer where Customer_ID  = " + id.ToString();
            string str = "select d.Customer_Code, d.Company_Name, d.Contact_Person, d.Contact_Details, d.Email, dg.G_D_Product_Code as G_Product_Code, dg.G_D_Product_Name as G_Product_Name,dg.G_D_Product_Group as G_Product_Group, dg.G_D_Serial_Number as Serial_Number, dg.G_D_Product_Quantity as G_Product_Quantity, dg.G_D_Product_Warrenty as G_Product_Warrenty from Transaction_Delivery_Note d inner join Delivery_Note_GridView dg on d.Delivery_Note_ID = dg.Delivery_Note_ID where d.Delivery_Note_ID =  " + id.ToString();
            DataTable dts = new CommonUtil().GetData(str);
            if (dts.Rows.Count > 0)
            {


                txt_customer_Code.Text = dts.Rows[0]["Customer_Code"].ToString();
                txt_company_Name.Text = dts.Rows[0]["Company_Name"].ToString();
                
                txt_contact_Person.Text = dts.Rows[0]["Contact_Person"].ToString();
                txt_contact_Details.Text = dts.Rows[0]["Contact_Details"].ToString();
                txt_Email.Text = dts.Rows[0]["Email"].ToString();
                

                Gridview1.DataSource = dts;
                Gridview1.DataBind();

                ViewState["CurrentTable"] = dts;


            }
        }

        //----------------------------------------------Calculate Net Amount And Tax ------------------------------------------------------

        protected void txt_Product_Quantity_TextChanged(object sender, EventArgs e)
        {
            GridViewRow row = (sender as TextBox).NamingContainer as GridViewRow;
            TextBox txt_Product_Quantity = (TextBox)row.FindControl("txt_Product_Quantity");
            TextBox txt_Product_Price = (TextBox)row.FindControl("txt_Product_Price");
            TextBox txt_Total_Price = (TextBox)row.FindControl("txt_Total_Price");
            TextBox txt_Tax = (TextBox)row.FindControl("txt_Tax");
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



        public void InvoiceID()
        {
            string cs = ConfigurationManager.ConnectionStrings["ERPConnectionString"].ToString();
            SqlConnection cn = new SqlConnection(cs);
            int j = 20000;
            SqlDataAdapter sda = new SqlDataAdapter("Select (Invoice_number) from Transaction_Invoice", cn);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            int i = dt.Rows.Count;

            int cnt = j + i;//Convert.ToString(i + 1);
            txt_invoice_Number.Text = "MR-IN-" + cnt;


        }


        private void SetInitialRow()
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
            dt.Columns.Add(new DataColumn("G_Product_Code", typeof(string)));
            dt.Columns.Add(new DataColumn("G_Product_Group", typeof(string)));
            dt.Columns.Add(new DataColumn("G_Product_Name", typeof(string)));
            dt.Columns.Add(new DataColumn("G_Product_Quantity", typeof(string)));
            dt.Columns.Add(new DataColumn("G_Product_Price", typeof(string)));
            dt.Columns.Add(new DataColumn("G_Product_Warrenty", typeof(string)));
            dt.Columns.Add(new DataColumn("G_Product_Discount", typeof(string)));
            dt.Columns.Add(new DataColumn("G_Tax", typeof(string)));
            dt.Columns.Add(new DataColumn("G_Net_Amount", typeof(string)));

            dr = dt.NewRow();
            dr["RowNumber"] = 1;
            dr["G_Product_Code"] = string.Empty;
            dr["G_Product_Group"] = string.Empty;
            dr["G_Product_Name"] = string.Empty;
            dr["G_Product_Quantity"] = string.Empty;
            dr["G_Product_Price"] = string.Empty;
            dr["G_Product_Warrenty"] = string.Empty;
            dr["G_Product_Discount"] = string.Empty;
            dr["G_Tax"] = string.Empty;
            dr["G_Net_Amount"] = string.Empty;

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

                        TextBox box4 = (TextBox)Gridview1.Rows[rowIndex].Cells[4].FindControl("txt_Product_Quantity");
                        TextBox box5 = (TextBox)Gridview1.Rows[rowIndex].Cells[5].FindControl("txt_Product_Price");
                        TextBox box6 = (TextBox)Gridview1.Rows[rowIndex].Cells[6].FindControl("txt_Product_Warrenty");
                        TextBox box7 = (TextBox)Gridview1.Rows[rowIndex].Cells[7].FindControl("txt_Discount");
                        TextBox box8 = (TextBox)Gridview1.Rows[rowIndex].Cells[8].FindControl("txt_Tax");
                        TextBox box9 = (TextBox)Gridview1.Rows[rowIndex].Cells[9].FindControl("txt_Total_Price");

                        drCurrentRow = dtCurrentTable.NewRow();

                        drCurrentRow["RowNumber"] = i + 1;
                        drCurrentRow["G_Product_Code"] = box1.Text;
                        drCurrentRow["G_Product_Group"] = box2.Text;
                        drCurrentRow["G_Product_Name"] = box3.Text;

                        drCurrentRow["G_Product_Quantity"] = box4.Text;
                        drCurrentRow["G_Product_Price"] = box5.Text;
                        drCurrentRow["G_Product_Warrenty"] = box6.Text;
                        drCurrentRow["G_Product_Discount"] = box7.Text;
                        drCurrentRow["G_Tax"] = box8.Text;
                        drCurrentRow["G_Net_Amount"] = box9.Text;

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

                        TextBox box4 = (TextBox)Gridview1.Rows[rowIndex].Cells[4].FindControl("txt_Product_Quantity");
                        TextBox box5 = (TextBox)Gridview1.Rows[rowIndex].Cells[5].FindControl("txt_Product_Price");
                        TextBox box6 = (TextBox)Gridview1.Rows[rowIndex].Cells[6].FindControl("txt_Product_Warrenty");
                        TextBox box7 = (TextBox)Gridview1.Rows[rowIndex].Cells[7].FindControl("txt_Discount");
                        TextBox box8 = (TextBox)Gridview1.Rows[rowIndex].Cells[8].FindControl("txt_Tax");
                        TextBox box9 = (TextBox)Gridview1.Rows[rowIndex].Cells[9].FindControl("txt_Total_Price");

                        box1.Text = dt.Rows[i]["G_Product_Code"].ToString();
                        box2.Text = dt.Rows[i]["G_Product_Group"].ToString();
                        box3.Text = dt.Rows[i]["G_Product_Name"].ToString();

                        box4.Text = dt.Rows[i]["G_Product_Quantity"].ToString();
                        box5.Text = dt.Rows[i]["G_Product_Price"].ToString();
                        box6.Text = dt.Rows[i]["G_Product_Warrenty"].ToString();
                        box7.Text = dt.Rows[i]["G_Product_Discount"].ToString();
                        box8.Text = dt.Rows[i]["G_Tax"].ToString();
                        box9.Text = dt.Rows[i]["G_Net_Amount"].ToString();

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
                        TextBox box2 = (TextBox)Gridview1.Rows[rowIndex].Cells[2].FindControl("txt_Product_Group");
                        TextBox box3 = (TextBox)Gridview1.Rows[rowIndex].Cells[3].FindControl("txt_Product_Name");

                        TextBox box4 = (TextBox)Gridview1.Rows[rowIndex].Cells[4].FindControl("txt_Product_Quantity");
                        TextBox box5 = (TextBox)Gridview1.Rows[rowIndex].Cells[5].FindControl("txt_Product_Price");
                        TextBox box6 = (TextBox)Gridview1.Rows[rowIndex].Cells[6].FindControl("txt_Product_Warrenty");
                        TextBox box7 = (TextBox)Gridview1.Rows[rowIndex].Cells[7].FindControl("txt_Discount");
                        TextBox box8 = (TextBox)Gridview1.Rows[rowIndex].Cells[8].FindControl("txt_Tax");
                        TextBox box9 = (TextBox)Gridview1.Rows[rowIndex].Cells[9].FindControl("txt_Total_Price");

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
                if (Pid == 0)
                {
                    const string sqlStatement = "INSERT INTO Invoice_GridView (Invoice_ID,G_Product_Code,G_Product_Group, G_Product_Name, G_Product_Price, G_Product_Quantity, G_Product_Warrenty,G_Product_Discount, G_Tax, G_Net_Amount) VALUES";
                    if (item.Contains("|"))
                    {
                        splitItems = item.Split("|".ToCharArray());
                        sb.AppendFormat("{0}('{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}'); ", sqlStatement, id, splitItems[0], splitItems[1], splitItems[2], splitItems[3], splitItems[4], splitItems[5], splitItems[6], splitItems[7], splitItems[8]);
                    }
                }
                else
                {
                    string strParam = "";
                    const string sqlStatement = " update Invoice_GridView set ";
                    if (item.Contains("|"))
                    {
                        splitItems = item.Split("|".ToCharArray());

                        strParam = strParam + "G_Product_Code ='" + splitItems[0] + "',G_Product_Group = '" + splitItems[1] + "',G_Product_Name ='" + splitItems[2] + "',G_Product_Quantity  = '" + splitItems[3] + "', G_Product_Price = '" + splitItems[4] + "', G_Product_Warrenty = '" + splitItems[5] + "', G_Product_Discount = '" + splitItems[6] + "', G_Tax = '" + splitItems[7] + "', G_Net_Amount = '" + splitItems[8] + "' where G_Product_Code ='" + splitItems[0] + "' and Invoice_ID = " + Pid;
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
            if (Pid == 0)
            {

                string strinsert = @"insert into Transaction_Invoice(Customer_Code, Company_Name, Company_Address, Contact_Person, Contact_Details, Email, Cust_Ref_Date, Cust_Ref_num, Invoice_number, Invoice_Date, Delivery_Number, Delivery_Date, Quotation_Number, Quatation_Date, Payment_Terms, Payment_Due_date, Terms_Condition, Shiping_Handling_Charges  ) 
                          values('" + txt_customer_Code.Text.ToString().Trim() + "', '" + txt_company_Name.Text.ToString().Trim() + "', '" + txt_company_Address.Text.ToString().Trim() + "', '" + txt_contact_Person.Text.ToString().Trim() + "', '" + txt_contact_Details.Text.ToString().Trim() +
                                            "', '" + txt_Email.Text.ToString().Trim() + "', '" + txt_cust_Ref_Date.Text.ToString().Trim() + "', '" + txt_cust_Ref_Num.Text.ToString().Trim() + "', '" + txt_invoice_Number.Text.ToString().Trim() + "', '" + txt_invoice_Date.Text.ToString().Trim() +
                                            "', '" + txt_delivery_Number.Text.ToString().Trim() + "', '" + txt_delivery_Date.Text.ToString().Trim() + "', '" + txt_quotation_Number.Text.ToString().Trim() + "', '" + txt_quotation_Date.Text.ToString().Trim() + "', '" + txt_payment_Terms.Text.ToString().Trim() + "', '" + txt_payment_Due_Date.Text.ToString().Trim() + "', '" + txt_terms_Conditions.Text.ToString().Trim() + "', '" + txt_shipping_Handling_Charges.Text.ToString().Trim() + "')";
                bool res = new CommonUtil().InserUpdateQuery(strinsert);
                DataTable dt = new CommonUtil().GetData("select max(Invoice_ID) from Transaction_Invoice");
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

                            Response.Redirect("Invoice_List.aspx");
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

                string strinsert = @"update Transaction_Invoice set Customer_Code = '" + txt_customer_Code.Text.ToString().Trim() + "',Company_Name = '" + txt_company_Name.Text.ToString().Trim() + "', Company_Address = '" + txt_company_Address.Text.ToString().Trim() + "', Contact_Person = '" + txt_contact_Person.Text.ToString().Trim() + "', Contact_Details ='" + txt_contact_Details.Text.ToString().Trim() +
                                            "', Email = '" + txt_Email.Text.ToString().Trim() + "', Cust_Ref_Date = '" + txt_cust_Ref_Date.Text.ToString().Trim() + "',  Cust_Ref_num = '" + txt_cust_Ref_Num.Text.ToString().Trim() + "', Invoice_number = '" + txt_invoice_Number.Text.ToString().Trim() + "', Invoice_Date = '" + txt_invoice_Date.Text.ToString().Trim() +
                                            "', Delivery_Number=  '" + txt_delivery_Number.Text.ToString().Trim() + "',Delivery_Date = '" + txt_delivery_Date.Text.ToString().Trim() + "', Quotation_Number = '" + txt_quotation_Number.Text.ToString().Trim() + "', Quatation_Date = '" + txt_quotation_Date.Text.ToString().Trim() + "', Payment_Terms = '" + txt_payment_Terms.Text.ToString().Trim() + "', Payment_Due_date = '" + txt_payment_Due_Date.Text.ToString().Trim() + "', Terms_Condition = '" + txt_terms_Conditions.Text.ToString().Trim() + "',Shiping_Handling_Charges = '" + txt_shipping_Handling_Charges.Text.ToString().Trim() + "' where Invoice_ID = "+Pid;


                bool res = new CommonUtil().InserUpdateQuery(strinsert);
                DataTable dt = new CommonUtil().GetData("select max(Invoice_ID) from Transaction_Invoice");
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

                            Response.Redirect("Invoice_List.aspx");
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