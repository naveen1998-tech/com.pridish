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

    public partial class Transaction_add_Delivery_Note : System.Web.UI.Page
    {
        int Did, DNid, Pid;

        protected void FillPage(int id)
        {
            //string str = "Select * from MST_Customer where Customer_ID  = " + id.ToString();
            string str = "select * from dbo.Transaction_Delivery_Note d inner join Delivery_Note_GridView g on d.Delivery_Note_ID = g.Delivery_Note_ID where d.Delivery_Note_ID  = " + id.ToString();
            DataTable dts = new CommonUtil().GetData(str);
            if (dts.Rows.Count > 0)
            {


                txt_Customer_Code.Text = dts.Rows[0]["Customer_Code"].ToString();
                txt_Customer_Name.Text = dts.Rows[0]["Customer_Name"].ToString();
                txt_company_Name.Text = dts.Rows[0]["Company_Name"].ToString();
                txt_Contacct_person.Text = dts.Rows[0]["Contact_Person"].ToString();
                txt_contact_details.Text = dts.Rows[0]["Contact_Details"].ToString();
                txt_Email.Text = dts.Rows[0]["Email"].ToString();
                txt_Customer_Reference_date.Text = dts.Rows[0]["Customer_Reference_Date"].ToString();
                txt_Customer_Reference_number.Text = dts.Rows[0]["Customer_Reference_Number"].ToString();
                txt_delivery_note_number.Text = dts.Rows[0]["Delivery_Note_Number"].ToString();
                txt_Delivery_NoteNumber_Date.Text = dts.Rows[0]["Delivery_Note_Num_Date"].ToString();
                txt_Shipped_To.Text = dts.Rows[0]["Shipped_TO"].ToString();


                txt_terms_Condition.Text = dts.Rows[0]["Terms_Condition"].ToString();
                txt_Reeived_BY.Text = dts.Rows[0]["Received_By"].ToString();
                txt_quotation_Number.Text = dts.Rows[0]["Quotation_Num"].ToString();
                txt_quotation_Date.Text = dts.Rows[0]["Quotation_Date"].ToString();

                Gridview1.DataSource = dts;
                Gridview1.DataBind();

                ViewState["CurrentTable"] = dts;


            }
        }

        protected void FillPage1(int id)
        {
            //string str = "Select * from MST_Customer where Customer_ID  = " + id.ToString();
            string str = "select s.S_Customer_Ref_Date,s.S_Customer_Ref_Number, s.Customer_Code,s.S_Quotation_Number,s.S_Quotation_date, s.Company_Name, s.S_Contact_Person, s.S_Contact_Details, s.S_Email, pg.G_Product_Code as G_D_Product_Code, pg.G_Product_Name as G_D_Product_Name, pg.G_Product_Group as G_D_Product_Group, pg.G_Product_Quantity as G_D_Product_Quantity, pg.G_Product_Serial_Num as G_D_Serial_Number from Transaction_sales_Order s inner join Sales_Product_GridView pg on s.Sales_Order_Id = pg.Sales_Order_Id where s.Sales_Order_Id =  " + id.ToString();
            DataTable dts = new CommonUtil().GetData(str);
            if (dts.Rows.Count > 0)
            {


                txt_Customer_Code.Text = dts.Rows[0]["Customer_Code"].ToString();
                
                txt_company_Name.Text = dts.Rows[0]["Company_Name"].ToString();
                txt_Contacct_person.Text = dts.Rows[0]["S_Contact_Person"].ToString();
                txt_contact_details.Text = dts.Rows[0]["S_Contact_Details"].ToString();
                txt_Email.Text = dts.Rows[0]["S_Email"].ToString();

                txt_quotation_Number.Text = dts.Rows[0]["S_Quotation_Number"].ToString();
                txt_quotation_Date.Text = dts.Rows[0]["S_Quotation_date"].ToString();
                txt_Customer_Reference_number.Text = dts.Rows[0]["S_Customer_Ref_Number"].ToString();
                txt_Customer_Reference_date.Text = dts.Rows[0]["S_Customer_Ref_Date"].ToString();

                Gridview1.DataSource = dts;
                Gridview1.DataBind();

                ViewState["CurrentTable"] = dts;
                //int rowIndex = 0;

                //TextBox box1 = (TextBox)Gridview1.Rows[rowIndex].Cells[1].FindControl("txt_Product_Code");
                //TextBox box2 = (TextBox)Gridview1.Rows[rowIndex].Cells[2].FindControl("txt_Product_Group");
                //TextBox box3 = (TextBox)Gridview1.Rows[rowIndex].Cells[3].FindControl("txt_Product_Name");
                //TextBox box4 = (TextBox)Gridview1.Rows[rowIndex].Cells[4].FindControl("txt_Product_Serial");
                //TextBox box5 = (TextBox)Gridview1.Rows[rowIndex].Cells[5].FindControl("txt_Product_Quantity");

                //box1.Text = dts.Rows[0]["G_Product_Code"].ToString();
                //box2.Text = dts.Rows[0]["G_Product_Group"].ToString();
                //box3.Text = dts.Rows[0]["G_Product_Name"].ToString();
                //box4.Text = dts.Rows[0]["G_Product_Serial_Num"].ToString();
                //box5.Text = dts.Rows[0]["G_Product_Quantity"].ToString();
                



            }
        }



        public void DeliveryNoteID()
        {
            string cs = ConfigurationManager.ConnectionStrings["ERPConnectionString"].ToString();
            SqlConnection cn = new SqlConnection(cs);
            int j = 19000;
            SqlDataAdapter sda = new SqlDataAdapter("Select (Delivery_Note_Number) from Transaction_Delivery_Note", cn);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            int i = dt.Rows.Count;

            int cnt = j + i;//Convert.ToString(i + 1);
            txt_delivery_note_number.Text = "MR-DN-" + cnt;


        }


        private void SetInitialRow()
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
            dt.Columns.Add(new DataColumn("G_D_Product_Code", typeof(string)));
            dt.Columns.Add(new DataColumn("G_D_Product_Group", typeof(string)));
            dt.Columns.Add(new DataColumn("G_D_Product_Name", typeof(string)));
            dt.Columns.Add(new DataColumn("G_D_Serial_Number", typeof(string)));
            dt.Columns.Add(new DataColumn("G_D_Product_Quantity", typeof(string)));
            dt.Columns.Add(new DataColumn("G_D_Product_Warrenty", typeof(string)));

            dr = dt.NewRow();
            dr["RowNumber"] = 1;
            dr["G_D_Product_Code"] = string.Empty;
            dr["G_D_Product_Group"] = string.Empty;
            dr["G_D_Product_Name"] = string.Empty;
            dr["G_D_Serial_Number"] = string.Empty;
            dr["G_D_Product_Quantity"] = string.Empty;
            dr["G_D_Product_Warrenty"] = string.Empty;

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
                        TextBox box4 = (TextBox)Gridview1.Rows[rowIndex].Cells[4].FindControl("txt_Product_Serial");
                        TextBox box5 = (TextBox)Gridview1.Rows[rowIndex].Cells[5].FindControl("txt_Product_Quantity");
                        TextBox box6 = (TextBox)Gridview1.Rows[rowIndex].Cells[6].FindControl("txt_Product_Warrenty");


                        drCurrentRow = dtCurrentTable.NewRow();

                        drCurrentRow["RowNumber"] = i + 1;
                        drCurrentRow["G_D_Product_Code"] = box1.Text;
                        drCurrentRow["G_D_Product_Group"] = box2.Text;
                        drCurrentRow["G_D_Product_Name"] = box3.Text;
                        drCurrentRow["G_D_Serial_Number"] = box4.Text;
                        drCurrentRow["G_D_Product_Quantity"] = box5.Text;
                        drCurrentRow["G_D_Product_Warrenty"] = box6.Text;


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
                        TextBox box4 = (TextBox)Gridview1.Rows[rowIndex].Cells[4].FindControl("txt_Product_Serial");
                        TextBox box5 = (TextBox)Gridview1.Rows[rowIndex].Cells[5].FindControl("txt_Product_Quantity");
                        TextBox box6 = (TextBox)Gridview1.Rows[rowIndex].Cells[6].FindControl("txt_Product_Warrenty");

                        box1.Text = dt.Rows[i]["G_D_Product_Code"].ToString();
                        box2.Text = dt.Rows[i]["G_D_Product_Group"].ToString();
                        box3.Text = dt.Rows[i]["G_D_Product_Name"].ToString();
                        box4.Text = dt.Rows[i]["G_D_Serial_Number"].ToString();
                        box5.Text = dt.Rows[i]["G_D_Product_Quantity"].ToString();
                        box6.Text = dt.Rows[i]["G_D_Product_Warrenty"].ToString();


                        rowIndex++;

                    }
                }
                // ViewState["CurrentTable"] = dt;

            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            txt_Delivery_NoteNumber_Date.Text = DateTime.Now.ToString("dd-MM-yyyy");
            DeliveryNoteID();

            if (!Page.IsPostBack)
            {
                

                if (Session["UserID"] == null)
                {
                    Session.Abandon();
                    Response.Redirect("~/Login.aspx");
                }
                SetInitialRow1();
                SetInitialRow();


                if (Request.QueryString["track"] != null && Request.QueryString["track"] == "Edit")
                {
                    Did = int.Parse(Request.QueryString["id"].ToString());
                    FillPage(Did);
                }
                else if (Request.QueryString["track"] != null && Request.QueryString["track"] == "Edit1")
                {
                    Did = int.Parse(Request.QueryString["id"].ToString());
                    FillPage1(Did);
                
                }
                



            }
            else
            {
                if (Request.QueryString["track"] != null && Request.QueryString["track"] == "Edit")
                {
                    Did = int.Parse(Request.QueryString["id"].ToString());
                }
                else
                {
                    Did = 0;
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
                        TextBox box4 = (TextBox)Gridview1.Rows[rowIndex].Cells[4].FindControl("txt_Product_Serial");
                        TextBox box5 = (TextBox)Gridview1.Rows[rowIndex].Cells[5].FindControl("txt_Product_Quantity");
                        TextBox box6 = (TextBox)Gridview1.Rows[rowIndex].Cells[6].FindControl("txt_Product_Warrenty");

                        //get the values from the TextBoxes
                        //then add it to the collections with a comma "," as the delimited values
                        sc.Add(box1.Text + "|" + box2.Text + "|" + box3.Text + "|" + box4.Text + "|" + box5.Text + "|" + box6.Text);
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
                if (Did == 0)
                {
                    const string sqlStatement = "INSERT INTO Delivery_Note_GridView (Delivery_Note_ID,G_D_Product_Code,G_D_Product_Group, G_D_Product_Name, G_D_Serial_Number, G_D_Product_Quantity, G_D_Product_Warrenty) VALUES";
                    if (item.Contains("|"))
                    {
                        splitItems = item.Split("|".ToCharArray());
                        sb.AppendFormat("{0}('{1}','{2}','{3}','{4}','{5}','{6}','{7}'); ", sqlStatement, id, splitItems[0], splitItems[1], splitItems[2], splitItems[3], splitItems[4], splitItems[5]);
                    }
                }
                else
                {
                    string strParam = "";
                    const string sqlStatement = " update Delivery_Note_GridView set ";
                    if (item.Contains("|"))
                    {
                        splitItems = item.Split("|".ToCharArray());

                        strParam = strParam + "G_D_Product_Code ='" + splitItems[0] + "',G_D_Product_Group = '" + splitItems[1] + "',G_D_Product_Name ='" + splitItems[2] + "', G_D_Serial_Number = '" + splitItems[3] + "', G_D_Product_Quantity = '" + splitItems[4] + "', G_D_Product_Warrenty = '" + splitItems[5] + "' where G_D_Product_Code ='" + splitItems[0] + "' and Delivery_Note_ID = " + Did;
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
            if (Did == 0)
            {
                string strinsert = @"insert into Transaction_Delivery_Note( Customer_Code, Customer_Name, Company_Name, Contact_Person,Contact_Details, Email, Customer_Reference_Date, Customer_Reference_Number, Delivery_Note_Number, Delivery_Note_Num_Date, Shipped_TO, Terms_Condition, Received_By, Quotation_Num, Quotation_Date ) 
                          values('" + txt_Customer_Code.Text.ToString().Trim() + "', '" + txt_Customer_Name.Text.ToString().Trim() + "', '" + txt_company_Name.Text.ToString().Trim() + "', '" + txt_Contacct_person.Text.ToString().Trim() + "', '" + txt_contact_details.Text.ToString().Trim() +
                                            "', '" + txt_Email.Text.ToString().Trim() + "', '" + txt_Customer_Reference_date.Text.ToString().Trim() + "', '" + txt_Customer_Reference_number.Text.ToString().Trim() +
                                            "', '" + txt_delivery_note_number.Text.ToString().Trim() + "', '" + txt_Delivery_NoteNumber_Date.Text.ToString().Trim() + "', '" + txt_Shipped_To.Text.ToString().Trim() + "', '" + txt_terms_Condition.Text.ToString().Trim() + "', '" + txt_Reeived_BY.Text.ToString().Trim() + "', '" + txt_quotation_Number.Text.ToString().Trim() + "', '" + txt_quotation_Date.Text.ToString().Trim() + "')";
                bool res = new CommonUtil().InserUpdateQuery(strinsert);
                DataTable dt = new CommonUtil().GetData("select max(Delivery_Note_ID) from Transaction_Delivery_Note");
                if (dt.Rows.Count > 0)
                {
                    int rs = int.Parse(dt.Rows[0][0].ToString());

                    if (rs > 0)
                    {
                        bool r = Button1_Click(rs);

                        //------------------------------------SerialNumber Gridview---------------------------------------
                        DataTable dt1 = new CommonUtil().GetData("select max(G_Delivery_ID) from dbo.Delivery_Note_GridView");
                        if (dt1.Rows.Count > 0)
                        {
                            int rs1 = int.Parse(dt.Rows[0][0].ToString());

                            if (rs1 > 0)
                            {
                                bool r1 = Button1_Click1(rs1);
                            }
                            


                        }
                        //-----------------------------------End Serial Number Gridview------------------------------------

                        if (r)
                        {


                            string message = "Your details have been saved successfully.";
                            string script = "window.onload = function(){ alert('";
                            script += message;
                            script += "')};";
                            ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
                            Response.Redirect("Delivery_Note_List.aspx");
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
                string strinsert = @"update Transaction_Delivery_Note set Customer_Code = '" + txt_Customer_Code.Text.ToString().Trim() + "',Customer_Name = '" + txt_Customer_Name.Text.ToString().Trim() + "', Company_Name = '" + txt_company_Name.Text.ToString().Trim() + "', Contact_Person  = '" + txt_Contacct_person.Text.ToString().Trim() + "', Contact_Details = '" + txt_contact_details.Text.ToString().Trim() +
                                            "',Email = '" + txt_Email.Text.ToString().Trim() + "', Customer_Reference_Date = '" + txt_Customer_Reference_date.Text.ToString().Trim() + "', Customer_Reference_Number = '" + txt_Customer_Reference_number.Text.ToString().Trim() +
                                            "',Delivery_Note_Number= '" + txt_delivery_note_number.Text.ToString().Trim() + "',Delivery_Note_Num_Date = '" + txt_Delivery_NoteNumber_Date.Text.ToString().Trim() + "', Shipped_TO = '" + txt_Shipped_To.Text.ToString().Trim() + "', Terms_Condition = '" + txt_terms_Condition.Text.ToString().Trim() + "', Received_By = '" + txt_Reeived_BY.Text.ToString().Trim() +
                                            "', Quotation_Num =  '" + txt_quotation_Number.Text.ToString().Trim() + "',Quotation_Date = '" + txt_quotation_Date.Text.ToString().Trim() + "' where Delivery_Note_ID = " + Did;
                bool res = new CommonUtil().InserUpdateQuery(strinsert);
                DataTable dt = new CommonUtil().GetData("select max(Delivery_Note_ID) from Transaction_Delivery_Note");
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
                            Response.Redirect("Delivery_Note_List.aspx");
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
            string autof = "select  Customer_Name, Company_Name from MST_Customer where Customer_Code =  '" + txt_Customer_Code.Text.ToString() + "'";
            DataTable dts = new CommonUtil().GetData(autof);
            if (dts.Rows.Count > 0)
            {

                txt_Customer_Name.Text = dts.Rows[0]["Customer_Name"].ToString();
                txt_company_Name.Text = dts.Rows[0]["Company_Name"].ToString();
                //txt_company_Address.Text = dts.Rows[0]["Address"].ToString();

            }
        }

        protected void txt_Customer_Code_TextChanged(object sender, EventArgs e)
        {
            autofill();
        }

        //--------------------------------------------Add SERIAL NUMBER GRIDVIEW -----------------------------------------------------------

        private void SetInitialRow1()
        {
            DataTable dt = new DataTable();
            DataRow dr = null;



            dt.Columns.Add(new DataColumn("S_Product_Code", typeof(string)));
            dt.Columns.Add(new DataColumn("S_Serial_No", typeof(string)));

            dr = dt.NewRow();
            //dr["RowNumber"] = 1;

            dr["S_Product_Code"] = string.Empty;
            dr["S_Serial_No"] = string.Empty;


            dt.Rows.Add(dr);
            dr = dt.NewRow();

            //Store the DataTable in ViewState
            ViewState["CurrentTable1"] = dt;

            Gridview2.DataSource = dt;
            Gridview2.DataBind();
        }
        private void AddNewRowToGrid1()
        {
            int rowIndex = 0;

            if (ViewState["CurrentTable1"] != null)
            {
                DataTable dtCurrentTable1 = (DataTable)ViewState["CurrentTable1"];
                DataRow drCurrentRow = null;
                if (dtCurrentTable1.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable1.Rows.Count; i++)
                    {
                        //extract the TextBox values

                        TextBox box1 = (TextBox)Gridview2.Rows[rowIndex].Cells[1].FindControl("txt_product_Code_S");
                        TextBox box2 = (TextBox)Gridview2.Rows[rowIndex].Cells[2].FindControl("txt_Serial_No_S");

                        drCurrentRow = dtCurrentTable1.NewRow();

                        drCurrentRow["S_Product_Code"] = box1.Text;
                        drCurrentRow["S_Serial_No"] = box2.Text;

                        rowIndex++;
                    }
                    dtCurrentTable1.Rows.Add(drCurrentRow);
                    ViewState["CurrentTable1"] = dtCurrentTable1;

                    Gridview2.DataSource = dtCurrentTable1;
                    Gridview2.DataBind();
                }
            }
            else
            {
                Response.Write("ViewState is null");
            }

            //Set Previous Data on Postbacks
            SetPreviousData1();
        }
        private void SetPreviousData1()
        {
            int rowIndex = 0;
            if (ViewState["CurrentTable1"] != null)
            {
                DataTable dt1 = (DataTable)ViewState["CurrentTable1"];
                if (dt1.Rows.Count > 0)
                {
                    for (int i = 1; i < dt1.Rows.Count; i++)
                    {
                        TextBox box1 = (TextBox)Gridview2.Rows[rowIndex].Cells[1].FindControl("txt_product_Code_S");
                        TextBox box2 = (TextBox)Gridview2.Rows[rowIndex].Cells[2].FindControl("txt_Serial_No_S");

                        box1.Text = dt1.Rows[i]["S_Product_Code"].ToString();
                        box2.Text = dt1.Rows[i]["S_Serial_No"].ToString();

                        rowIndex++;

                    }
                }
                // ViewState["CurrentTable"] = dt;

            }
        }

        protected void ButtonAdd_Click1(object sender, EventArgs e)
        {
            AddNewRowToGrid1();
        }
        protected bool Button1_Click1(int id)
        {
            int rowIndex = 0;
            StringCollection sc1 = new StringCollection();
            if (ViewState["CurrentTable1"] != null)
            {
                DataTable dtCurrentTable = (DataTable)ViewState["CurrentTable1"];
                if (dtCurrentTable.Rows.Count > 0)
                {
                    for (int i = 1; i <= dtCurrentTable.Rows.Count; i++)
                    {
                        //extract the TextBox values
                        TextBox box1 = (TextBox)Gridview2.Rows[rowIndex].Cells[1].FindControl("txt_product_Code_S");
                        TextBox box2 = (TextBox)Gridview2.Rows[rowIndex].Cells[2].FindControl("txt_Serial_No_S");

                        //get the values from the TextBoxes
                        //then add it to the collections with a comma "," as the delimited values
                        sc1.Add(box1.Text + "|" + box2.Text);
                        rowIndex++;
                    }
                    //Call the method for executing inserts
                    return InsertRecords1(sc1, id);
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
        private string GetConnectionString1()
        {
            //"DBConnection" is the name of the Connection String
            //that was set up from the web.config file
            return System.Configuration.ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        }
        //A method that Inserts the records to the database
        private bool InsertRecords1(StringCollection sc1, int id)
        {
            SqlConnection conn = new SqlConnection(GetConnectionString1());
            StringBuilder sb = new StringBuilder(string.Empty);
            string[] splitItems = null;
            foreach (string item in sc1)
            {
                if (Did == 0)
                {
                    const string sqlStatement = "INSERT INTO Delivery_Serial_No_grv (G_Sales_Order_ID, S_Product_Code, S_Serial_No) VALUES";
                    if (item.Contains("|"))
                    {
                        splitItems = item.Split("|".ToCharArray());
                        sb.AppendFormat("{0}('{1}','{2}','{3}'); ", sqlStatement, id, splitItems[0], splitItems[1]);
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
        protected void Gridview1_RowCreated1(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataTable dt = (DataTable)ViewState["CurrentTable1"];
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
        protected void LinkButton1_Click1(object sender, EventArgs e)
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
            SetPreviousData1();
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (TextBox1.Text.ToString() != "")
            {

                int txt = Int32.Parse(TextBox1.Text);
                for (int i = 1; i < txt; i++)
                {
                    AddNewRowToGrid1();
                }
            }
        }

        //-------------------------------------------END SERIAL NUMBER GRIDVIEW-------------------------------------------------------------

        
        
       
    }
}