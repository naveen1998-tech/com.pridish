using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.pridish.Common;
using System.Data;
using System.Collections.Specialized;
using System.Data.SqlClient;
using System.Text;

namespace com.pridish
{
    public partial class Payments : System.Web.UI.Page
    {
        int cid;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                SetInitialRow();
                DDlBound();

                if (Request.QueryString["track"] != null && Request.QueryString["track"] == "Edit")
                {
                    cid = int.Parse(Request.QueryString["id"].ToString());
                    FillPage(cid);
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
            string str = "select * from Online_Payment o inner join Online_Payment_Grv g on o.Online_Pay_ID = g.Online_Pay_ID where o.Online_Pay_ID =" + id.ToString();
            DataTable dts = new CommonUtil().GetData(str);
            if (dts.Rows.Count > 0)
            {


                ddl_Cust_Code.SelectedItem.Text = dts.Rows[0]["Customer_Code"].ToString();
                ddl_Invoice_No.Text = dts.Rows[0]["Invoice_Code"].ToString();

                Gridview1.DataSource = dts;
                Gridview1.DataBind();


                ViewState["CurrentTable"] = dts;
                


            }
        }

        public void DDlBound()
        {
            string str = "select c.Customer_ID as ID , c.Customer_Code as cc from MST_Customer c";
            DataTable dts = new CommonUtil().GetData(str);
            new CommonUtil().BindDDL("Select Customer Code", ddl_Cust_Code, dts);

        }

        protected void ddl_Cust_Code_SelectedIndexChanged(object sender, EventArgs e)
        {
            string str = "select i.Invoice_ID as ID,i.Invoice_number as cc from Transaction_Invoice i where i.Customer_Code ='" + ddl_Cust_Code.SelectedItem +"'";
            DataTable dts = new CommonUtil().GetData(str);
            new CommonUtil().BindDDL("Select Invoice Number", ddl_Invoice_No, dts);

        }




        //-----------------------------add gridview ------------------------
        private void SetInitialRow()
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            //dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));

            dt.Columns.Add(new DataColumn("Payment_Type", typeof(string)));
            dt.Columns.Add(new DataColumn("Transfer_Date", typeof(string)));
            dt.Columns.Add(new DataColumn("Bank_Name", typeof(string)));
            dt.Columns.Add(new DataColumn("Reference_Number", typeof(string)));
            dt.Columns.Add(new DataColumn("Amount", typeof(string)));


            dr = dt.NewRow();
            //dr["RowNumber"] = 1;

            dr["Payment_Type"] = string.Empty;
            dr["Transfer_Date"] = string.Empty;
            dr["Bank_Name"] = string.Empty;
            dr["Reference_Number"] = string.Empty;
            dr["Amount"] = string.Empty;


            dt.Rows.Add(dr);
            dr = dt.NewRow();

            //Store the DataTable in ViewState
            ViewState["CurrentTable"] = dt;

            Gridview1.DataSource = dt;
            Gridview1.DataBind();

            ViewState["CurrentTable"] = dt;
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
                        DropDownList box1 = (DropDownList)Gridview1.Rows[rowIndex].Cells[1].FindControl("ddl_Payment_Type");
                        TextBox box2 = (TextBox)Gridview1.Rows[rowIndex].Cells[2].FindControl("txt_Transfer_Date");
                        TextBox box3 = (TextBox)Gridview1.Rows[rowIndex].Cells[3].FindControl("txt_Bank_Name");
                        TextBox box4 = (TextBox)Gridview1.Rows[rowIndex].Cells[4].FindControl("txt_Reference_No");
                        TextBox box5 = (TextBox)Gridview1.Rows[rowIndex].Cells[5].FindControl("txt_Amount");



                        drCurrentRow = dtCurrentTable.NewRow();

                        drCurrentRow["Payment_Type"] = box1.SelectedItem.Text;
                        drCurrentRow["Transfer_Date"] = box2.Text;
                        drCurrentRow["Bank_Name"] = box3.Text;
                        drCurrentRow["Reference_Number"] = box4.Text;
                        drCurrentRow["Amount"] = box5.Text;
                       
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
                        DropDownList box1 = (DropDownList)Gridview1.Rows[rowIndex].Cells[1].FindControl("ddl_Payment_Type");
                        TextBox box2 = (TextBox)Gridview1.Rows[rowIndex].Cells[2].FindControl("txt_Transfer_Date");
                        TextBox box3 = (TextBox)Gridview1.Rows[rowIndex].Cells[3].FindControl("txt_Bank_Name");
                        TextBox box4 = (TextBox)Gridview1.Rows[rowIndex].Cells[4].FindControl("txt_Reference_No");
                        TextBox box5 = (TextBox)Gridview1.Rows[rowIndex].Cells[5].FindControl("txt_Amount");


                        box1.Items.FindByText(dt.Rows[i]["Payment_Type"].ToString()).Selected = true;
                        box2.Text = dt.Rows[i]["Transfer_Date"].ToString();
                        box3.Text = dt.Rows[i]["Bank_Name"].ToString();
                        box4.Text = dt.Rows[i]["Reference_Number"].ToString();
                        box5.Text = dt.Rows[i]["Amount"].ToString();



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
                        DropDownList box1 = (DropDownList)Gridview1.Rows[rowIndex].Cells[1].FindControl("ddl_Payment_Type");
                        TextBox box2 = (TextBox)Gridview1.Rows[rowIndex].Cells[2].FindControl("txt_Transfer_Date");
                        TextBox box3 = (TextBox)Gridview1.Rows[rowIndex].Cells[3].FindControl("txt_Bank_Name");
                        TextBox box4 = (TextBox)Gridview1.Rows[rowIndex].Cells[4].FindControl("txt_Reference_No");
                        TextBox box5 = (TextBox)Gridview1.Rows[rowIndex].Cells[5].FindControl("txt_Amount");

                        //get the values from the TextBoxes
                        //then add it to the collections with a comma "," as the delimited values
                        sc.Add(box1.Text + "|" + box2.Text + "|" + box3.Text + "|" + box4.Text + "|" + box5.Text);
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
                    const string sqlStatement = "INSERT INTO Online_Payment_Grv (Online_Pay_ID, Payment_Type, Transfer_Date, Bank_Name, Reference_Number, Amount) VALUES";
                    if (item.Contains("|"))
                    {
                        splitItems = item.Split("|".ToCharArray());
                        sb.AppendFormat("{0}('{1}','{2}','{3}','{4}','{5}','{6}'); ", sqlStatement, id, splitItems[0], splitItems[1], splitItems[2], splitItems[3], splitItems[4]);
                    }
                }
                else
                {
                    string strParam = "";
                    const string sqlStatement = " update Online_Payment_Grv set ";
                    if (item.Contains("|"))
                    {
                        splitItems = item.Split("|".ToCharArray());

                        strParam = strParam + "Payment_Type ='" + splitItems[0] + "',Transfer_Date = '" + splitItems[1] + "',Bank_Name ='" + splitItems[2] + "', Reference_Number = '" + splitItems[3] + "', Amount = '" + splitItems[4] + "' where Online_Pay_ID =" + cid;
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
                string strinsert = @"insert into Online_Payment(Customer_Code, Invoice_Code ) 
                         values('" + ddl_Cust_Code.SelectedItem.ToString().Trim() + "','" + ddl_Invoice_No.SelectedItem.ToString().Trim() + "')";

                bool res = new CommonUtil().InserUpdateQuery(strinsert);
                DataTable dt = new CommonUtil().GetData("select max(Online_Pay_ID) from Online_Payment");
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
                            //Response.Redirect("Stock_List.aspx");
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

                string strinsert = @"update Online_Payment set Customer_Code = '" + ddl_Cust_Code.SelectedItem.ToString().Trim() + "'where Online_Pay_ID = "+cid;
                bool res = new CommonUtil().InserUpdateQuery(strinsert);
                DataTable dt = new CommonUtil().GetData("select max(Online_Pay_ID) from Online_Payment");
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
                            Response.Redirect("Payment_List.aspx");
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
            
            }
        }

        //-------------------------------end GridView----------------------------

    }
}