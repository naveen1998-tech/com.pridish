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

    public partial class Transaction_add_Sales_Order : System.Web.UI.Page
    {
        int Sid,qid;

        protected void FillPage(int id)
        {
            //string str = "Select * from MST_Customer where Customer_ID  = " + id.ToString();
            string str = "select * from dbo.Transaction_sales_Order s inner join Sales_Product_GridView p on s.Sales_Order_Id = p.Sales_Order_Id where s.Sales_Order_Id = " + id.ToString();
            DataTable dts = new CommonUtil().GetData(str);
            if (dts.Rows.Count > 0)
            {


                txt_Customer_Code.Text = dts.Rows[0]["Customer_Code"].ToString();
                txt_company_Name.Text = dts.Rows[0]["Company_Name"].ToString();
                txt_company_Address.Text = dts.Rows[0]["Company_Address"].ToString();
                txt_contact_Person.Text = dts.Rows[0]["S_Contact_Person"].ToString();
                txt_contact_Details.Text = dts.Rows[0]["S_Contact_Details"].ToString();
                txt_email.Text = dts.Rows[0]["S_Email"].ToString();
                txt_Customer_Reference_Date.Text = dts.Rows[0]["S_Customer_Ref_Date"].ToString();
                txt_Customer_Reference_number.Text = dts.Rows[0]["S_Customer_Ref_Number"].ToString();
                txt_Sales_Order_Number.Text = dts.Rows[0]["Sales_Order_Number"].ToString();
                txt_Sales_Order_Date.Text = dts.Rows[0]["Sales_Order_Date"].ToString();
                txt_quotation_Number.Text = dts.Rows[0]["S_Quotation_Number"].ToString();


                txt_quotation_Date.Text = dts.Rows[0]["S_Quotation_date"].ToString();
                txt_Available_Stock.Text = dts.Rows[0]["S_Available_Stock"].ToString();
                txt_terms_Condition.Text = dts.Rows[0]["S_Terms_Condition"].ToString();

                Gridview1.DataSource = dts;
                Gridview1.DataBind();

                ViewState["CurrentTable"] = dts;
                

            }
        }

        //-------------------------------------------From Quotation To Sales Order----------------------------------------------

        protected void FillPage1(int id)
        {
            //string str = "Select * from MST_Customer where Customer_ID  = " + id.ToString();
            string str = "select q.Customer_Code,q.Cuotation_Reference_Number ,q.Customer_Reference_Date,q.Conpany_Name, q.company_Address, q.Contact_Person, q.Contact_Details, q.Email,q.Quotation_Number, q.Quotation_Number_Date, qg.Q_Product_Code as G_Product_Code, qg.Q_Product_Group as G_Product_Group, qg.Q_Product_Name as G_Product_Name,qg.Q_Quantity as G_Product_Quantity, qg.Q_Product_Price as G_Product_Price, qg.Q_Product_Warrenty, qg.Q_Tax as G_Tax, qg.Q_Net_Amount as G_Net_Amount from Transaction_Quotation q inner join Quotation_Product_GridView qg on q.Quotation_ID=qg.Quotation_ID where q.Quotation_ID = " + id.ToString();

            


            DataTable dts = new CommonUtil().GetData(str);
            if (dts.Rows.Count > 0)
            {


                txt_Customer_Code.Text = dts.Rows[0]["Customer_Code"].ToString();
                txt_company_Name.Text = dts.Rows[0]["Conpany_Name"].ToString();
                txt_company_Address.Text = dts.Rows[0]["Company_Address"].ToString();
                txt_contact_Person.Text = dts.Rows[0]["Contact_Person"].ToString();
                txt_contact_Details.Text = dts.Rows[0]["Contact_Details"].ToString();
                txt_email.Text = dts.Rows[0]["Email"].ToString();

                txt_quotation_Number.Text = dts.Rows[0]["Quotation_Number"].ToString();

                txt_quotation_Date.Text = dts.Rows[0]["Quotation_Number_Date"].ToString();
                txt_Customer_Reference_number.Text = dts.Rows[0]["Cuotation_Reference_Number"].ToString();
                txt_Customer_Reference_Date.Text = dts.Rows[0]["Customer_Reference_Date"].ToString();

                



                Gridview1.DataSource = dts;
                Gridview1.DataBind();


                ViewState["CurrentTable"] = dts;



            }
        }


       // ------------------------------------------------End----------------------------------------------------------




        public void SalesOrderID()
        {
            string cs = ConfigurationManager.ConnectionStrings["ERPConnectionString"].ToString();
            SqlConnection cn = new SqlConnection(cs);
            int j = 18000;
            SqlDataAdapter sda = new SqlDataAdapter("Select (Sales_Order_Number) from Transaction_sales_Order", cn);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            int i = dt.Rows.Count;

            int cnt = j + i;//Convert.ToString(i + 1);
            txt_Sales_Order_Number.Text = "MR-SO-" + cnt;


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
            dt.Columns.Add(new DataColumn("G_Product_Serial_Num", typeof(string)));
            dt.Columns.Add(new DataColumn("G_Product_Price", typeof(string)));
            dt.Columns.Add(new DataColumn("G_Tax", typeof(string)));
            dt.Columns.Add(new DataColumn("G_Net_Amount", typeof(string)));
            dr = dt.NewRow();
            dr["RowNumber"] = 1;
            dr["G_Product_Code"] = string.Empty;
            dr["G_Product_Group"] = string.Empty;
            dr["G_Product_Name"] = string.Empty;
            dr["G_Product_Quantity"] = string.Empty;
            dr["G_Product_Serial_Num"] = string.Empty;
            dr["G_Product_Price"] = string.Empty;
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
                        TextBox box5 = (TextBox)Gridview1.Rows[rowIndex].Cells[5].FindControl("txt_Product_Serial");
                        TextBox box6 = (TextBox)Gridview1.Rows[rowIndex].Cells[6].FindControl("txt_Product_Price");
                        TextBox box7 = (TextBox)Gridview1.Rows[rowIndex].Cells[7].FindControl("txt_Tax");
                        TextBox box8 = (TextBox)Gridview1.Rows[rowIndex].Cells[8].FindControl("txt_Total_Price");

                        drCurrentRow = dtCurrentTable.NewRow();

                        drCurrentRow["RowNumber"] = i + 1;
                        drCurrentRow["G_Product_Code"] = box1.Text;
                        drCurrentRow["G_Product_Group"] = box2.Text;
                        drCurrentRow["G_Product_Name"] = box3.Text;
                        drCurrentRow["G_Product_Quantity"] = box4.Text;
                        drCurrentRow["G_Product_Serial_Num"] = box5.Text;
                        drCurrentRow["G_Product_Price"] = box6.Text;
                        drCurrentRow["G_Tax"] = box7.Text;
                        drCurrentRow["G_Net_Amount"] = box8.Text;

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
                        TextBox box5 = (TextBox)Gridview1.Rows[rowIndex].Cells[5].FindControl("txt_Product_Serial");
                        TextBox box6 = (TextBox)Gridview1.Rows[rowIndex].Cells[6].FindControl("txt_Product_Price");
                        TextBox box7 = (TextBox)Gridview1.Rows[rowIndex].Cells[7].FindControl("txt_Tax");
                        TextBox box8 = (TextBox)Gridview1.Rows[rowIndex].Cells[8].FindControl("txt_Total_Price");

                        box1.Text = dt.Rows[i]["G_Product_Code"].ToString();
                        box2.Text = dt.Rows[i]["G_Product_Group"].ToString();
                        box3.Text = dt.Rows[i]["G_Product_Name"].ToString();
                        box4.Text = dt.Rows[i]["G_Product_Quantity"].ToString();
                        box5.Text = dt.Rows[i]["G_Product_Serial_Num"].ToString();
                        box6.Text = dt.Rows[i]["G_Product_Price"].ToString();
                        box7.Text = dt.Rows[i]["G_Tax"].ToString();
                        box8.Text = dt.Rows[i]["G_Net_Amount"].ToString();

                        rowIndex++;

                    }
                }
                // ViewState["CurrentTable"] = dt;

            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            txt_Sales_Order_Date.Text = DateTime.Now.ToString("dd-MM-yyyy");
            SalesOrderID();

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
                    Sid = int.Parse(Request.QueryString["id"].ToString());
                    FillPage(Sid);
                }
                else if (Request.QueryString["track"] != null && Request.QueryString["track"] == "Edit1")
                {
                    qid = int.Parse(Request.QueryString["id"].ToString());
                    FillPage1(qid);
                }


            }
            else
            {
                if (Request.QueryString["track"] != null && Request.QueryString["track"] == "Edit")
                {
                    Sid = int.Parse(Request.QueryString["id"].ToString());
                }
                else
                {
                    Sid = 0;
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
                        TextBox box1 = (TextBox)Gridview1.Rows[rowIndex].Cells[1].FindControl("txt_Product_Code");
                        TextBox box2 = (TextBox)Gridview1.Rows[rowIndex].Cells[2].FindControl("txt_Product_Group");
                        TextBox box3 = (TextBox)Gridview1.Rows[rowIndex].Cells[3].FindControl("txt_Product_Name");
                        TextBox box4 = (TextBox)Gridview1.Rows[rowIndex].Cells[4].FindControl("txt_Product_Quantity");
                        TextBox box5 = (TextBox)Gridview1.Rows[rowIndex].Cells[5].FindControl("txt_Product_Serial");
                        TextBox box6 = (TextBox)Gridview1.Rows[rowIndex].Cells[6].FindControl("txt_Product_Price");
                        TextBox box7 = (TextBox)Gridview1.Rows[rowIndex].Cells[7].FindControl("txt_Tax");
                        TextBox box8 = (TextBox)Gridview1.Rows[rowIndex].Cells[8].FindControl("txt_Total_Price");

                        //get the values from the TextBoxes
                        //then add it to the collections with a comma "," as the delimited values
                        sc.Add(box1.Text + "|" + box2.Text + "|" + box3.Text + "|" + box4.Text + "|" + box5.Text + "|" + box6.Text + "|" + box7.Text + "|" + box8.Text);
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
                if (Sid == 0)
                {

                    const string sqlStatement = "INSERT INTO Sales_Product_GridView (Sales_Order_Id, G_Product_Code,G_Product_Group,G_Product_Name, G_Product_Quantity, G_Product_Serial_Num, G_Product_Price, G_Tax, G_Net_Amount) VALUES";
                    if (item.Contains("|"))
                    {
                        splitItems = item.Split("|".ToCharArray());
                        sb.AppendFormat("{0}('{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}'); ", sqlStatement, id, splitItems[0], splitItems[1], splitItems[2], splitItems[3], splitItems[4], splitItems[5], splitItems[6], splitItems[7]);
                    }
                }
                else
                {
                    string strParam = "";
                    const string sqlStatement = " update Sales_Product_GridView set ";
                    if (item.Contains("|"))
                    {
                        splitItems = item.Split("|".ToCharArray());

                        strParam = strParam + "G_Product_Code ='" + splitItems[0] + "',G_Product_Group = '" + splitItems[1] + "',G_Product_Name ='" + splitItems[2] + "', G_Product_Quantity = '" + splitItems[3] + "', G_Product_Serial_Num = '" + splitItems[4] + "', G_Product_Price = '" + splitItems[5] + "', G_Tax = '" + splitItems[6] + "', G_Net_Amount ='" + splitItems[7] + "' where G_Product_Code ='" + splitItems[0] + "' and Sales_Order_Id = " + Sid;
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
            if (Sid == 0)
            {
                string strinsert = @"insert into Transaction_sales_Order( Customer_Code, Company_Name, Company_Address, S_Contact_Person, S_Contact_Details, S_Email, S_Customer_Ref_Date, S_Customer_Ref_Number, Sales_Order_Number, Sales_Order_Date, S_Quotation_Number, S_Quotation_date, S_Available_Stock, S_Terms_Condition ) 
                          values('" + txt_Customer_Code.Text.ToString().Trim() + "', '" + txt_company_Name.Text.ToString().Trim() + "', '" + txt_company_Address.Text.ToString().Trim() + "', '" + txt_contact_Person.Text.ToString().Trim() +
                                            "', '" + txt_contact_Details.Text.ToString().Trim() + "', '" + txt_email.Text.ToString().Trim() + "', '" + txt_Customer_Reference_Date.Text.ToString().Trim() + "', '" + txt_Customer_Reference_number.Text.ToString().Trim() +
                                            "', '" + txt_Sales_Order_Number.Text.ToString().Trim() + "', '" + txt_Sales_Order_Date.Text.ToString().Trim() + "', '" + txt_quotation_Number.Text.ToString().Trim() + "', '" + txt_quotation_Date.Text.ToString().Trim() + "', '" + txt_Available_Stock.Text.ToString().Trim() + "', '" + txt_terms_Condition.Text.ToString().Trim() + "')";
                bool res = new CommonUtil().InserUpdateQuery(strinsert);
                DataTable dt = new CommonUtil().GetData("select max(Sales_Order_Id) from Transaction_sales_Order");
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
                            Response.Redirect("Sales_Order_List.aspx");
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

                string strinsert = @"update Transaction_sales_Order set Customer_Code =  '" + txt_Customer_Code.Text.ToString().Trim() + "',Company_Name =  '" + txt_company_Name.Text.ToString().Trim() + "',Company_Address =  '" + txt_company_Address.Text.ToString().Trim() + "',S_Contact_Person = '" + txt_contact_Person.Text.ToString().Trim() +
                                            "',S_Contact_Details = '" + txt_contact_Details.Text.ToString().Trim() + "', S_Email ='" + txt_email.Text.ToString().Trim() + "',S_Customer_Ref_Date = '" + txt_Customer_Reference_Date.Text.ToString().Trim() + "',S_Customer_Ref_Number = '" + txt_Customer_Reference_number.Text.ToString().Trim() +
                                            "', S_Quotation_Number = '" + txt_quotation_Number.Text.ToString().Trim() + "',S_Quotation_date = '" + txt_quotation_Date.Text.ToString().Trim() + "',S_Available_Stock = '" + txt_Available_Stock.Text.ToString().Trim() + "', S_Terms_Condition = '" + txt_terms_Condition.Text.ToString().Trim() + "' where Sales_Order_Id = "+Sid;

                bool res = new CommonUtil().InserUpdateQuery(strinsert);
                DataTable dt = new CommonUtil().GetData("select max(Sales_Order_Id) from Transaction_sales_Order");
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
                            Response.Redirect("Sales_Order_List.aspx");
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

        protected void txt_Customer_Code_TextChanged(object sender, EventArgs e)
        {
            autofill();
        }

        protected void autofill()
        {
            string autof = "select  Company_Name, Address from MST_Customer where Customer_Code =  '" + txt_Customer_Code.Text.ToString() + "'";
            DataTable dts = new CommonUtil().GetData(autof);
            if (dts.Rows.Count > 0)
            {

                //txt_Customer_Name.Text = dts.Rows[0]["Customer_Name"].ToString();
                txt_company_Name.Text = dts.Rows[0]["Company_Name"].ToString();
                txt_company_Address.Text = dts.Rows[0]["Address"].ToString();

            }
        }

        protected void txt_Product_Code_TextChanged(object sender, EventArgs e)
        {
            GridViewRow row = (sender as TextBox).NamingContainer as GridViewRow;
            TextBox txt_Product_Code = (TextBox)row.FindControl("txt_Product_Code");
            TextBox txt_Product_Group = (TextBox)row.FindControl("txt_Product_Group");
            TextBox txt_Product_Name = (TextBox)row.FindControl("txt_Product_Name");
            TextBox txt_Product_Quantity = (TextBox)row.FindControl("txt_Product_Quantity");
            TextBox txt_Product_Serial = (TextBox)row.FindControl("txt_Product_Serial");
            TextBox txt_Product_Price = (TextBox)row.FindControl("txt_Product_Price");
            TextBox txt_Tax = (TextBox)row.FindControl("txt_Tax");
            TextBox txt_Total_Price = (TextBox)row.FindControl("txt_Total_Price");


            //string autof = "select  Product_Group, Product_Name, Product_Selling_Price, Tax from MST_Product where Product_Code =  '" + txt_Product_Code.Text.ToString() + "'";
            string autof = "select count(spg.G_Product_Code) as G_Product_Code  from MST_Product p inner join MST_Stock s on p.Product_Id=  s.Product_Code inner join STOCK_SERIAL_NUMBER sn on s.Stock_ID = sn.Product_Id inner join Sales_Product_GridView spg on p.Product_Code =  spg.G_Product_Code where spg.G_Product_Code ='" + txt_Product_Code.Text.ToString() + "'  ";
            DataTable dts = new CommonUtil().GetData(autof);
            if (dts.Rows.Count > 0)
            {

               // //txt_Customer_Name.Text = dts.Rows[0]["Customer_Name"].ToString();
               // txt_Product_Group.Text = dts.Rows[0]["Product_Group"].ToString();
               // txt_Product_Name.Text = dts.Rows[0]["Product_Name"].ToString();
               ////txt_Product_Quantity.Text = dts.Rows[0]["Address"].ToString();
               // //txt_Product_Serial.Text = dts.Rows[0]["Address"].ToString();
               // txt_Product_Price.Text = dts.Rows[0]["Product_Selling_Price"].ToString();
               // txt_Tax.Text = dts.Rows[0]["Tax"].ToString();
               // //txt_Total_Price.Text = dts.Rows[0]["Address"].ToString();
                txt_Product_Serial.Text = dts.Rows[0]["G_Product_Code"].ToString();

            }
            autof += " group by  spg.G_Product_Code";

        }

        protected void txt_Product_Quantity_TextChanged(object sender, EventArgs e)
        {
            GridViewRow row = (sender as TextBox).NamingContainer as GridViewRow;
            TextBox txt_Product_Quantity = (TextBox)row.FindControl("txt_Product_Quantity");
            TextBox txt_Product_Price = (TextBox)row.FindControl("txt_Product_Price");
            TextBox txt_Total_Price = (TextBox)row.FindControl("txt_Total_Price");
            TextBox txt_Tax = (TextBox)row.FindControl("txt_Tax");

            float qty = float.Parse(txt_Product_Quantity.Text);
            float rate = float.Parse(txt_Product_Price.Text);
            float tex = float.Parse(txt_Tax.Text);
            //int tot = Int32.Parse(txt_Total_Price.Text);

            float total , totaltax , addtax;
            total = rate * qty;
            txt_Total_Price.Text = total.ToString();

            totaltax = total / 100 * tex;

            addtax = total + totaltax;

            txt_Total_Price.Text = addtax.ToString();




        }

       
    }
}