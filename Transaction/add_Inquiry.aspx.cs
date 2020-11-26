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

    public partial class Transaction_add_Inquiry : System.Web.UI.Page
    {
        int rfqid;

        protected void Page_Load(object sender, EventArgs e)
        {
            txt_RFQ_Date.Text = DateTime.Now.ToString("dd-MM-yyyy");
            InquiryID();
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
                    rfqid = int.Parse(Request.QueryString["id"].ToString());
                    FillPage(rfqid);
                }

            }
        }

        protected void autofill()
        {
            string autof = "select Customer_Name, Address from MST_Customer where Customer_Code =  '" + txt_Customer_Code.Text.ToString() + "'";
              DataTable dts = new CommonUtil().GetData(autof);
              if (dts.Rows.Count > 0)
              {

                  txt_Customer_Name.Text = dts.Rows[0]["Customer_Name"].ToString();
                  txt_Company_Address.Text = dts.Rows[0]["Address"].ToString();
              
              }
        }
        protected void FillPage(int id)
        {
            //string str = "Select * from MST_Customer where Customer_ID  = " + id.ToString();
            string str = "select * from Transaction_RFQ r inner join RFQ_Product_GridView g on r.RFQ_ID = g.RFQ_ID where r.RFQ_ID  = " + id.ToString();
            DataTable dts = new CommonUtil().GetData(str);
            if (dts.Rows.Count > 0)
            {


                txt_RFQ_Number.Text = dts.Rows[0]["RFQ_Number"].ToString();
                txt_RFQ_Date.Text = dts.Rows[0]["RFQ_Date"].ToString();
                txt_RFQ_Closing_Date.Text = dts.Rows[0]["RFQ_Closing_Date"].ToString();
                txt_Customer_Code.Text = dts.Rows[0]["Customer_Code"].ToString();
                txt_Covering_Note.Text = dts.Rows[0]["Covering_Note"].ToString();
                txt_Customer_Name.Text = dts.Rows[0]["Customer_Name"].ToString();
                txt_Contact_Person.Text = dts.Rows[0]["Contact_Person"].ToString();
                txt_Contact_Details.Text = dts.Rows[0]["Mobile_Number"].ToString();
                txt_Email.Text = dts.Rows[0]["Email_Id"].ToString();
                txt_Terms_condition.Text = dts.Rows[0]["Terms_Condition"].ToString();
                txt_Company_Address.Text = dts.Rows[0]["Company_Address"].ToString();

                Gridview1.DataSource = dts;
                Gridview1.DataBind();

                ViewState["CurrentTable"] = dts;





                
                

            }
        }


        public void InquiryID()
        {
            string cs = ConfigurationManager.ConnectionStrings["ERPConnectionString"].ToString();
            SqlConnection cn = new SqlConnection(cs);
            int j = 24000;
            SqlDataAdapter sda = new SqlDataAdapter("Select (RFQ_Number) from Transaction_RFQ", cn);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            int i = dt.Rows.Count;

            int cnt = j + i;//Convert.ToString(i + 1);
            txt_RFQ_Number.Text = "MR-RFQ-" + cnt;


        }


        private void SetInitialRow()
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
            dt.Columns.Add(new DataColumn("R_Product_Name", typeof(string)));
            dt.Columns.Add(new DataColumn("R_Product_Unit_Price", typeof(string)));
            dt.Columns.Add(new DataColumn("R_Product_Quantity", typeof(string)));
            dt.Columns.Add(new DataColumn("R_Product_Warrenty", typeof(string)));
            dt.Columns.Add(new DataColumn("R_Net_Amount", typeof(string)));
            dr = dt.NewRow();
            dr["RowNumber"] = 1;
            dr["R_Product_Name"] = string.Empty;
            dr["R_Product_Unit_Price"] = string.Empty;
            dr["R_Product_Quantity"] = string.Empty;
            dr["R_Product_Warrenty"] = string.Empty;
            dr["R_Net_Amount"] = string.Empty;
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
                        TextBox box1 = (TextBox)Gridview1.Rows[rowIndex].Cells[1].FindControl("txt_Product_Name");
                        TextBox box2 = (TextBox)Gridview1.Rows[rowIndex].Cells[2].FindControl("txt_Unit_Price");
                        TextBox box3 = (TextBox)Gridview1.Rows[rowIndex].Cells[3].FindControl("txt_Product_Quantity");
                        TextBox box4 = (TextBox)Gridview1.Rows[rowIndex].Cells[4].FindControl("txt_Product_Warrenty");
                        TextBox box5 = (TextBox)Gridview1.Rows[rowIndex].Cells[5].FindControl("txt_Total_Price");

                        drCurrentRow = dtCurrentTable.NewRow();

                        drCurrentRow["RowNumber"] = i + 1;
                        drCurrentRow["R_Product_Name"] = box1.Text;
                        drCurrentRow["R_Product_Unit_Price"] = box2.Text;
                        drCurrentRow["R_Product_Quantity"] = box3.Text;
                        drCurrentRow["R_Product_Warrenty"] = box4.Text;
                        drCurrentRow["R_Net_Amount"] = box5.Text;

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
                        TextBox box1 = (TextBox)Gridview1.Rows[rowIndex].Cells[1].FindControl("txt_Product_Name");
                        TextBox box2 = (TextBox)Gridview1.Rows[rowIndex].Cells[2].FindControl("txt_Unit_Price");
                        TextBox box3 = (TextBox)Gridview1.Rows[rowIndex].Cells[3].FindControl("txt_Product_Quantity");
                        TextBox box4 = (TextBox)Gridview1.Rows[rowIndex].Cells[4].FindControl("txt_Product_Warrenty");
                        TextBox box5 = (TextBox)Gridview1.Rows[rowIndex].Cells[5].FindControl("txt_Total_Price");

                        box1.Text = dt.Rows[i]["R_Product_Name"].ToString();
                        box2.Text = dt.Rows[i]["R_Product_Unit_Price"].ToString();
                        box3.Text = dt.Rows[i]["R_Product_Quantity"].ToString();
                        box4.Text = dt.Rows[i]["R_Product_Warrenty"].ToString();
                        box5.Text = dt.Rows[i]["R_Net_Amount"].ToString();

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
                        TextBox box1 = (TextBox)Gridview1.Rows[rowIndex].Cells[1].FindControl("txt_Product_Name");
                        TextBox box2 = (TextBox)Gridview1.Rows[rowIndex].Cells[2].FindControl("txt_Unit_Price");
                        TextBox box3 = (TextBox)Gridview1.Rows[rowIndex].Cells[3].FindControl("txt_Product_Quantity");
                        TextBox box4 = (TextBox)Gridview1.Rows[rowIndex].Cells[4].FindControl("txt_Product_Warrenty");
                        TextBox box5 = (TextBox)Gridview1.Rows[rowIndex].Cells[5].FindControl("txt_Total_Price");

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

                const string sqlStatement = "INSERT INTO RFQ_Product_GridView (RFQ_ID,R_Product_Name,R_Product_Unit_Price,R_Product_Quantity,R_Product_Warrenty,R_Net_Amount) VALUES";
                if (item.Contains("|"))
                {
                    splitItems = item.Split('|');
                    sb.AppendFormat("{0}('{1}','{2}','{3}','{4}','{5}','{6}'); ", sqlStatement, id, splitItems[0], splitItems[1], splitItems[2], splitItems[3], splitItems[4]);
                }

            }

            try
            {
                return new CommonUtil().InserUpdateQuery(sb.ToString());

                //Page.ClientScript.RegisterClientScriptBlock(typeof(Page), "Script", "alert('Records Successfuly Saved!');", true);

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
            string strinsert = @"insert into Transaction_RFQ( RFQ_Number, RFQ_Date, RFQ_Closing_Date, Customer_Code, Covering_Note, Customer_Name, Contact_Person, Mobile_Number, Email_Id, Terms_Condition , Company_Address ) 
                          values('" + txt_RFQ_Number.Text.ToString().Trim() + "','" + txt_RFQ_Date.Text.ToString().Trim() + "','" + txt_RFQ_Closing_Date.Text.ToString().Trim() + "','" + txt_Customer_Code.Text.ToString().Trim() + "','" + txt_Covering_Note.Text.ToString().Trim() + "','" + txt_Customer_Name.Text.ToString().Trim() +
                                        "','" + txt_Contact_Person.Text.ToString().Trim() + "','" + txt_Contact_Details.Text.ToString().Trim() + "','" + txt_Email.Text.ToString().Trim() + "','" + txt_Terms_condition.Text.ToString().Trim() + "','" + txt_Company_Address.Text.ToString().Trim() + "')";
            bool res = new CommonUtil().InserUpdateQuery(strinsert);
            DataTable dt = new CommonUtil().GetData("select max(RFQ_ID) from Transaction_RFQ");
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
                        Response.Redirect("RFQ_List.aspx");
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

        protected void txt_Customer_Code_TextChanged(object sender, EventArgs e)
        {
            autofill();
        }

        protected void txt_Product_grv_Create_TextChanged(object sender, EventArgs e)
        {
            int txt = Int32.Parse(txt_Product_grv_Create.Text);
            for (int i = 1; i < txt; i++)
            {
                AddNewRowToGrid();
            
            }
        }
    }
}