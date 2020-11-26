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

    public partial class Transaction_Add_Purchase_Order : System.Web.UI.Page
    {
        int Pid, Poid;

        protected void FillPage(int id)
        {
            //string str = "Select * from MST_Customer where Customer_ID  = " + id.ToString();
            string str = "select * from Transaction_Purchase_Order t inner join Purchase_Order_GridView p on t.Purchase_Order_ID= p.Purchase_Order_ID where t.Purchase_Order_ID = " + id.ToString();
            DataTable dts = new CommonUtil().GetData(str);
            if (dts.Rows.Count > 0)
            {


                txt_Vendor_Code.Text = dts.Rows[0]["Vendor_Code"].ToString();
                txt_Company_Name.Text = dts.Rows[0]["V_Company_Name"].ToString();
                txt_Vendor_Company_Address.Text = dts.Rows[0]["V_Company_Address"].ToString();
                txt_Vendor_Contact_Person.Text = dts.Rows[0]["V_Contact_Person"].ToString();
                txt_Vendor_Contact_Desails.Text = dts.Rows[0]["V_Mobile_Number"].ToString();
                txt_Vendor_Email.Text = dts.Rows[0]["V_Email_Id"].ToString();
                txt_Sales_Order_Number.Text = dts.Rows[0]["Sales_Order_num"].ToString();
                txt_Sales_Order_Num_Date.Text = dts.Rows[0]["Sales_Order_Date"].ToString();
                txt_PO_Number.Text = dts.Rows[0]["PO_Number"].ToString();
                txt_PO_Date.Text = dts.Rows[0]["PO_Date"].ToString();
                txt_Vendor_Ref_Number.Text = dts.Rows[0]["Vendor_Ref_Num"].ToString();
                txt_Vendor_Ref_Date.Text = dts.Rows[0]["Vendor_Ref_Date"].ToString();
                txt_country.Text = dts.Rows[0]["Country"].ToString();
                txt_payment_Terms.Text = dts.Rows[0]["Payment_Terms"].ToString();
                txt_currency.Text = dts.Rows[0]["Currency"].ToString();
                txt_ship_To_Location.Text = dts.Rows[0]["Ship_To_Location"].ToString();
                txt_terms_Conditions.Text = dts.Rows[0]["Terms_Condition"].ToString();

                Gridview1.DataSource = dts;
                Gridview1.DataBind();

                ViewState["CurrentTable"] = dts;



                //txt_Product_Code.Text = dts.Rows[0]["G_Product_Code"].ToString();
                //txt_Product_Group.Text = dts.Rows[0]["G_Product_Group"].ToString();
                //txt_bankName.Text = dts.Rows[0]["G_Product_Name"].ToString();
                //txt_branchName.Text = dts.Rows[0]["G_Product_Price"].ToString();
                //txt_swiftCode.Text = dts.Rows[0]["G_Product_Quantity"].ToString();
                //txt_cityName.Text = dts.Rows[0]["G_Tax"].ToString();
                //txt_BankCounty.Text = dts.Rows[0]["G_Net_Amount"].ToString();
                

            }
        }

        protected void FillPage2(int id)
        {
            //string str = "Select * from MST_Customer where Customer_ID  = " + id.ToString();
            string str = "select po.Sales_Order_Number, po.Sales_Order_Date, pg.G_Product_Code, pg.G_Product_Group, pg.G_Product_Name, pg.G_Product_Price, pg.G_Product_Quantity, pg.G_Tax, pg.G_Net_Amount from Transaction_sales_Order po inner join Sales_Product_GridView pg on po.Sales_Order_Id = pg.Sales_Order_Id where po.Sales_Order_Id =  " + id.ToString();
            DataTable dts = new CommonUtil().GetData(str);
            if (dts.Rows.Count > 0)
            {



                txt_Sales_Order_Number.Text = dts.Rows[0]["Sales_Order_Number"].ToString();
                txt_Sales_Order_Num_Date.Text = dts.Rows[0]["Sales_Order_Date"].ToString();

                Gridview1.DataSource = dts;
                Gridview1.DataBind();

                ViewState["CurrentTable"] = dts;
                
               


            }
        }



        public void PurchaseOrderID()
        {
            string cs = ConfigurationManager.ConnectionStrings["ERPConnectionString"].ToString();
            SqlConnection cn = new SqlConnection(cs);
            int j = 22000;
            SqlDataAdapter sda = new SqlDataAdapter("Select (PO_Number) from Transaction_Purchase_Order", cn);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            int i = dt.Rows.Count;

            int cnt = j + i;//Convert.ToString(i + 1);
            txt_PO_Number.Text = "MR-PO-" + cnt;


        }

        private void SetInitialRow()
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
            dt.Columns.Add(new DataColumn("G_Product_Code", typeof(string)));
            dt.Columns.Add(new DataColumn("G_Product_Group", typeof(string)));
            dt.Columns.Add(new DataColumn("G_Product_Name", typeof(string)));
            dt.Columns.Add(new DataColumn("G_Product_Price", typeof(string)));
            dt.Columns.Add(new DataColumn("G_Product_Quantity", typeof(string)));
            dt.Columns.Add(new DataColumn("G_Tax", typeof(string)));
            dt.Columns.Add(new DataColumn("G_Net_Amount", typeof(string)));

            dr = dt.NewRow();
            dr["RowNumber"] = 1;
            dr["G_Product_Code"] = string.Empty;
            dr["G_Product_Group"] = string.Empty;
            dr["G_Product_Name"] = string.Empty;
            dr["G_Product_Price"] = string.Empty;
            dr["G_Product_Quantity"] = string.Empty;
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

                        TextBox box4 = (TextBox)Gridview1.Rows[rowIndex].Cells[4].FindControl("txt_Product_Price");
                        TextBox box5 = (TextBox)Gridview1.Rows[rowIndex].Cells[5].FindControl("txt_Product_Quantity");
                        TextBox box6 = (TextBox)Gridview1.Rows[rowIndex].Cells[6].FindControl("txt_Tax");
                        TextBox box7 = (TextBox)Gridview1.Rows[rowIndex].Cells[7].FindControl("txt_Total_Price");

                        drCurrentRow = dtCurrentTable.NewRow();

                        drCurrentRow["RowNumber"] = i + 1;
                        drCurrentRow["G_Product_Code"] = box1.Text;
                        drCurrentRow["G_Product_Group"] = box2.Text;
                        drCurrentRow["G_Product_Name"] = box3.Text;

                        drCurrentRow["G_Product_Price"] = box4.Text;
                        drCurrentRow["G_Product_Quantity"] = box5.Text;
                        drCurrentRow["G_Tax"] = box6.Text;
                        drCurrentRow["G_Net_Amount"] = box7.Text;

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

                        TextBox box4 = (TextBox)Gridview1.Rows[rowIndex].Cells[4].FindControl("txt_Product_Price");
                        TextBox box5 = (TextBox)Gridview1.Rows[rowIndex].Cells[5].FindControl("txt_Product_Quantity");
                        TextBox box6 = (TextBox)Gridview1.Rows[rowIndex].Cells[6].FindControl("txt_Tax");
                        TextBox box7 = (TextBox)Gridview1.Rows[rowIndex].Cells[7].FindControl("txt_Total_Price");

                        box1.Text = dt.Rows[i]["G_Product_Code"].ToString();
                        box2.Text = dt.Rows[i]["G_Product_Group"].ToString();
                        box3.Text = dt.Rows[i]["G_Product_Name"].ToString();

                        box4.Text = dt.Rows[i]["G_Product_Price"].ToString();
                        box5.Text = dt.Rows[i]["G_Product_Quantity"].ToString();
                        box6.Text = dt.Rows[i]["G_Tax"].ToString();
                        box7.Text = dt.Rows[i]["G_Net_Amount"].ToString();

                        rowIndex++;

                    }
                }
                // ViewState["CurrentTable"] = dt;

            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            txt_PO_Date.Text = DateTime.Now.ToString("dd-MM-yyyy");
            PurchaseOrderID();

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
                    Poid = int.Parse(Request.QueryString["id"].ToString());
                    FillPage2(Poid);

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

                        TextBox box4 = (TextBox)Gridview1.Rows[rowIndex].Cells[4].FindControl("txt_Product_Price");
                        TextBox box5 = (TextBox)Gridview1.Rows[rowIndex].Cells[5].FindControl("txt_Product_Quantity");
                        TextBox box6 = (TextBox)Gridview1.Rows[rowIndex].Cells[6].FindControl("txt_Tax");
                        TextBox box7 = (TextBox)Gridview1.Rows[rowIndex].Cells[7].FindControl("txt_Total_Price");

                        //get the values from the TextBoxes
                        //then add it to the collections with a comma "," as the delimited values
                        sc.Add(box1.Text + "|" + box2.Text + "|" + box3.Text + "|" + box4.Text + "|" + box5.Text + "|" + box6.Text + "|" + box7.Text);
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
                    const string sqlStatement = "INSERT INTO Purchase_Order_GridView (Purchase_Order_ID,G_Product_Code,G_Product_Group, G_Product_Name, G_Product_Price, G_Product_Quantity, G_Tax, G_Net_Amount) VALUES";
                    if (item.Contains("|"))
                    {
                        splitItems = item.Split("|".ToCharArray());
                        sb.AppendFormat("{0}('{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}'); ", sqlStatement, id, splitItems[0], splitItems[1], splitItems[2], splitItems[3], splitItems[4], splitItems[5], splitItems[6]);
                    }
                }
                else
                {
                    string strParam = "";
                    const string sqlStatement = " update Purchase_Order_GridView set ";
                    if (item.Contains("|"))
                    {
                        splitItems = item.Split("|".ToCharArray());

                        strParam = strParam + "G_Product_Code ='" + splitItems[0] + "',G_Product_Group = '" + splitItems[1] + "',G_Product_Name ='" + splitItems[2] + "', G_Product_Price = '" + splitItems[3] + "', G_Product_Quantity = '" + splitItems[4] + "', G_Tax = '" + splitItems[5] + "', G_Net_Amount = '" + splitItems[6] + "' where G_Product_Code ='" + splitItems[0] + "' and Purchase_Order_ID = " + Pid;
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
                string strinsert = @"insert into Transaction_Purchase_Order(Vendor_Code, V_Company_Name, V_Company_Address, V_Contact_Person, V_Mobile_Number,Sales_Order_num,Sales_Order_Date,V_Email_Id, PO_Number, PO_Date, Country, Payment_Terms, Currency, Ship_To_Location, Terms_Condition, Vendor_Ref_Num, Vendor_Ref_Date  ) 
                          values('" + txt_Vendor_Code.Text.ToString().Trim() + "','" + txt_Company_Name.Text.ToString().Trim() + "','" + txt_Vendor_Company_Address.Text.ToString().Trim() + "','" + txt_Vendor_Contact_Person.Text.ToString().Trim() + "','" + txt_Vendor_Contact_Desails.Text.ToString().Trim() + "','" + txt_Sales_Order_Number.Text.ToString().Trim() + "','" + txt_Sales_Order_Num_Date.Text.ToString().Trim() + "','" + txt_Vendor_Email.Text.ToString().Trim() +
                                            "','" + txt_PO_Number.Text.ToString().Trim() + "','" + txt_PO_Date.Text.ToString().Trim() + "','" + txt_country.Text.ToString().Trim() + "','" + txt_payment_Terms.Text.ToString().Trim() + "','" + txt_currency.Text.ToString().Trim() + "','" + txt_ship_To_Location.Text.ToString().Trim() +
                                            "','" + txt_terms_Conditions.Text.ToString().Trim() + "','" + txt_Vendor_Ref_Number.Text.ToString().Trim() + "','" + txt_Vendor_Ref_Date.Text.ToString().Trim() + "')";
                bool res = new CommonUtil().InserUpdateQuery(strinsert);
                DataTable dt = new CommonUtil().GetData("select max(Purchase_Order_ID) from Transaction_Purchase_Order");
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
                            Response.Redirect("Product_Order_List.aspx");
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
                string strinsert = @"update Transaction_Purchase_Order set Vendor_Code ='" + txt_Vendor_Code.Text.ToString().Trim() + "',V_Company_Name = '" + txt_Company_Name.Text.ToString().Trim() + "',V_Company_Address = '" + txt_Vendor_Company_Address.Text.ToString().Trim() + "', V_Contact_Person = '" + txt_Vendor_Contact_Person.Text.ToString().Trim() + "',V_Mobile_Number = '" + txt_Vendor_Contact_Desails.Text.ToString().Trim() + "', Sales_Order_num = '" + txt_Sales_Order_Number.Text.ToString().Trim() + "', Sales_Order_Date = '" + txt_Sales_Order_Num_Date.Text.ToString().Trim() + "',V_Email_Id = '" + txt_Vendor_Email.Text.ToString().Trim() +
                                            "',PO_Number = '" + txt_PO_Number.Text.ToString().Trim() + "',PO_Date = '" + txt_PO_Date.Text.ToString().Trim() + "', Country = '" + txt_country.Text.ToString().Trim() + "',Payment_Terms = '" + txt_payment_Terms.Text.ToString().Trim() + "', Currency = '" + txt_currency.Text.ToString().Trim() + "', Ship_To_Location = '" + txt_ship_To_Location.Text.ToString().Trim() +
                                            "',Terms_Condition = '" + txt_terms_Conditions.Text.ToString().Trim() + "',Vendor_Ref_Num = '" + txt_Vendor_Ref_Number.Text.ToString().Trim() + "', Vendor_Ref_Date ='" + txt_Vendor_Ref_Date.Text.ToString().Trim() + "' where Purchase_Order_ID = "+Pid;
                bool res = new CommonUtil().InserUpdateQuery(strinsert);
                DataTable dt = new CommonUtil().GetData("select max(Purchase_Order_ID) from Transaction_Purchase_Order");
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
                            Response.Redirect("Product_Order_List.aspx");
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
            string autof = "select  V_Company_Name, V_Company_Address from MST_Vendor where Vendor_Code =  '" + txt_Vendor_Code.Text.ToString() + "'";
            DataTable dts = new CommonUtil().GetData(autof);
            if (dts.Rows.Count > 0)
            {

                //txt_Customer_Name.Text = dts.Rows[0]["Customer_Name"].ToString();
                txt_Company_Name.Text = dts.Rows[0]["V_Company_Name"].ToString();
                txt_Vendor_Company_Address.Text = dts.Rows[0]["V_Company_Address"].ToString();

            }
        }

        protected void txt_Vendor_Code_TextChanged(object sender, EventArgs e)
        {
            autofill();
        }

    }
}