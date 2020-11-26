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

    public partial class Transaction_add_Grv_Form : System.Web.UI.Page
    {
        int gid;

        protected void FillPage(int id)
        {
            //string str = "Select * from MST_Customer where Customer_ID  = " + id.ToString();
            string str = "select * from dbo.Transaction_GRV g inner join GRV_GridView p on g.GRV_ID = p.GRV_ID where g.GRV_ID  = " + id.ToString();
            DataTable dts = new CommonUtil().GetData(str);
            if (dts.Rows.Count > 0)
            {


                txt_GRV_Number.Text = dts.Rows[0]["GRV_Number"].ToString();
                txt_GRV_Date.Text = dts.Rows[0]["GRV_Date"].ToString();
                txt_vendor_Code.Text = dts.Rows[0]["Vendor_Code"].ToString();
                txt_vendor_Company_Name.Text = dts.Rows[0]["Vendor_Company_Name"].ToString();
                txt_vendor_address.Text = dts.Rows[0]["Vendor_Address"].ToString();
                txt_vendor_Contact_person.Text = dts.Rows[0]["Vendor_Contact_Person"].ToString();
                txt_vendor_Contact_Details.Text = dts.Rows[0]["Vendor_Contact_Details"].ToString();
                txt_Email.Text = dts.Rows[0]["Email"].ToString();
                txt_vendor_invoice_Ref_Number.Text = dts.Rows[0]["Vendor_invoice_Fer_num"].ToString();
                txt_vendor_Invoice_Ref_Date.Text = dts.Rows[0]["Vendor_invoice_Ref_Date"].ToString();
                txt_PO_Number.Text = dts.Rows[0]["PO_Number"].ToString();



                txt_PO_Date.Text = dts.Rows[0]["PO_date"].ToString();
                txt_remark_For_Return.Text = dts.Rows[0]["Remark_For_Return"].ToString();


                Gridview1.DataSource = dts;
                Gridview1.DataBind();
                ViewState["CurrentTable"] = dts;



            }
        }

        //----------------------------------------------------MRN 2 GRV---------------------------------------------------------------------

        protected void FillPage1(int id)
        {
            //string str = "Select * from MST_Customer where Customer_ID  = " + id.ToString();
            string str = "select m.Vendor_Code, m.Email, m.PO_number,m.Vendor_Contact_Details, m.PO_Date, g.Product_Code as Product_Code, g.Product_Group as Product_Group, g.Product_Name as Product_Name, g.Product_Received_Quantity as Product_Return_Quantity, g.Purchase_Date as Purchase_Date, g.Purchase_Invoice_Number as Purchase_Invoice_Number, g.Purchase_Price as Product_Price, g.Serial_number as Serial_No, g.Tax_Amount as Tax_Amount, g.Net_Amount as Net_Amount from Transaction_MRN m inner join MRN_GridView g on m.MRN_ID = g.MRN_ID where m.MRN_ID = " + id.ToString();
            DataTable dts = new CommonUtil().GetData(str);
            if (dts.Rows.Count > 0)
            {


                
                txt_vendor_Code.Text = dts.Rows[0]["Vendor_Code"].ToString();

                txt_vendor_Contact_Details.Text = dts.Rows[0]["Vendor_Contact_Details"].ToString();
               
                txt_Email.Text = dts.Rows[0]["Email"].ToString();
                
                txt_PO_Number.Text = dts.Rows[0]["PO_Number"].ToString();

                txt_PO_Date.Text = dts.Rows[0]["PO_date"].ToString();


                Gridview1.DataSource = dts;
                Gridview1.DataBind();

                ViewState["CurrentTable"] = dts;


            }
        }



        public void GoodsReturnVendor()
        {
            string cs = ConfigurationManager.ConnectionStrings["ERPConnectionString"].ToString();
            SqlConnection cn = new SqlConnection(cs);
            int j = 26000;
            SqlDataAdapter sda = new SqlDataAdapter("Select (GRV_Number) from Transaction_GRV", cn);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            int i = dt.Rows.Count;

            int cnt = j + i;//Convert.ToString(i + 1);
            txt_GRV_Number.Text = "MR-GRV-" + cnt;


        }

        private void SetInitialRow()
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
            dt.Columns.Add(new DataColumn("Product_Code", typeof(string)));
            dt.Columns.Add(new DataColumn("Product_Group", typeof(string)));
            dt.Columns.Add(new DataColumn("Product_Name", typeof(string)));
            dt.Columns.Add(new DataColumn("Purchase_Invoice_Number", typeof(string)));
            dt.Columns.Add(new DataColumn("Purchase_Date", typeof(string)));
            dt.Columns.Add(new DataColumn("Product_Price", typeof(string)));
            dt.Columns.Add(new DataColumn("Serial_No", typeof(string)));
            dt.Columns.Add(new DataColumn("Product_Return_Quantity", typeof(string)));
            dt.Columns.Add(new DataColumn("Tax_Amount", typeof(string)));
            dt.Columns.Add(new DataColumn("Net_Amount", typeof(string)));



            dr = dt.NewRow();
            dr["RowNumber"] = 1;
            dr["Product_Code"] = string.Empty;
            dr["Product_Group"] = string.Empty;
            dr["Product_Name"] = string.Empty;
            dr["Purchase_Invoice_Number"] = string.Empty;
            dr["Purchase_Date"] = string.Empty;
            dr["Product_Price"] = string.Empty;
            dr["Serial_No"] = string.Empty;
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
                        TextBox box6 = (TextBox)Gridview1.Rows[rowIndex].Cells[6].FindControl("txt_Product_Price");
                        TextBox box7 = (TextBox)Gridview1.Rows[rowIndex].Cells[7].FindControl("txt_Serial_Number");
                        TextBox box8 = (TextBox)Gridview1.Rows[rowIndex].Cells[8].FindControl("txt_Product_Return_Quantity");
                        TextBox box9 = (TextBox)Gridview1.Rows[rowIndex].Cells[9].FindControl("txt_Tax_Amount");
                        TextBox box10 = (TextBox)Gridview1.Rows[rowIndex].Cells[10].FindControl("txt_Net_Amount");



                        drCurrentRow = dtCurrentTable.NewRow();

                        drCurrentRow["RowNumber"] = i + 1;
                        drCurrentRow["Product_Code"] = box1.Text;
                        drCurrentRow["Product_Group"] = box2.Text;
                        drCurrentRow["Product_Name"] = box3.Text;

                        drCurrentRow["Purchase_Invoice_Number"] = box4.Text;
                        drCurrentRow["Purchase_Date"] = box5.Text;
                        drCurrentRow["Product_Price"] = box6.Text;
                        drCurrentRow["Serial_No"] = box6.Text;
                        drCurrentRow["Product_Return_Quantity"] = box6.Text;
                        drCurrentRow["Tax_Amount"] = box6.Text;
                        drCurrentRow["Net_Amount"] = box6.Text;



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
                        TextBox box6 = (TextBox)Gridview1.Rows[rowIndex].Cells[6].FindControl("txt_Product_Price");
                        TextBox box7 = (TextBox)Gridview1.Rows[rowIndex].Cells[7].FindControl("txt_Serial_Number");
                        TextBox box8 = (TextBox)Gridview1.Rows[rowIndex].Cells[8].FindControl("txt_Product_Return_Quantity");
                        TextBox box9 = (TextBox)Gridview1.Rows[rowIndex].Cells[9].FindControl("txt_Tax_Amount");
                        TextBox box10 = (TextBox)Gridview1.Rows[rowIndex].Cells[10].FindControl("txt_Net_Amount");

                        box1.Text = dt.Rows[i]["Product_Code"].ToString();
                        box2.Text = dt.Rows[i]["Product_Group"].ToString();
                        box3.Text = dt.Rows[i]["Product_Name"].ToString();

                        box4.Text = dt.Rows[i]["Purchase_Invoice_Number"].ToString();
                        box5.Text = dt.Rows[i]["Purchase_Date"].ToString();
                        box6.Text = dt.Rows[i]["Product_Price"].ToString();
                        box7.Text = dt.Rows[i]["Serial_No"].ToString();
                        box8.Text = dt.Rows[i]["Product_Return_Quantity"].ToString();
                        box9.Text = dt.Rows[i]["Tax_Amount"].ToString();
                        box10.Text = dt.Rows[i]["Net_Amount"].ToString();



                        rowIndex++;

                    }
                }
                // ViewState["CurrentTable"] = dt;

            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            txt_GRV_Date.Text = DateTime.Now.ToString("dd-MM-yyyy");
            GoodsReturnVendor();

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
                //-----------------------------MRN 2 GRV----------------------------------

                else if (Request.QueryString["track"] != null && Request.QueryString["track"] == "Edit1")
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

        //-----------------------------------------------------Calculate Net amount And Tax------------------------------------------------

        protected void txt_Product_Quantity_TextChanged(object sender, EventArgs e)
        {
            GridViewRow row = (sender as TextBox).NamingContainer as GridViewRow;
            TextBox txt_Product_Quantity = (TextBox)row.FindControl("txt_Product_Return_Quantity");
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
                        TextBox box6 = (TextBox)Gridview1.Rows[rowIndex].Cells[5].FindControl("txt_Product_Price");
                        TextBox box7 = (TextBox)Gridview1.Rows[rowIndex].Cells[6].FindControl("txt_Serial_Number");
                        TextBox box8 = (TextBox)Gridview1.Rows[rowIndex].Cells[7].FindControl("txt_Product_Return_Quantity");
                        TextBox box9 = (TextBox)Gridview1.Rows[rowIndex].Cells[8].FindControl("txt_Tax_Amount");
                        TextBox box10 = (TextBox)Gridview1.Rows[rowIndex].Cells[9].FindControl("txt_Net_Amount");

                        //get the values from the TextBoxes
                        //then add it to the collections with a comma "," as the delimited values
                        sc.Add(box1.Text + "|" + box2.Text + "|" + box3.Text + "|" + box4.Text + "|" + box5.Text + "|" + box6.Text + "|" + box7.Text + "|" + box8.Text + "|" + box9.Text + "|" + box10.Text);
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

                    const string sqlStatement = "INSERT INTO GRV_GridView (GRV_ID, Product_Code, Product_Group, Product_Name, Purchase_Invoice_Number, Purchase_Date, Product_Price, Serial_No, Product_Return_Quantity, Tax_Amount, Net_Amount  ) VALUES";
                    if (item.Contains("|"))
                    {
                        splitItems = item.Split("|".ToCharArray());
                        sb.AppendFormat("{0}('{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}'); ", sqlStatement, id, splitItems[0], splitItems[1], splitItems[2], splitItems[3], splitItems[4], splitItems[5], splitItems[6], splitItems[7], splitItems[8], splitItems[9]);
                    }
                }
               
                     else
                {
                    string strParam = "";
                    const string sqlStatement = " update GRV_GridView set ";
                    if (item.Contains("|"))
                    {
                        splitItems = item.Split("|".ToCharArray());

                        strParam = strParam + "Product_Code ='" + splitItems[0] + "',Product_Group = '" + splitItems[1] + "',Product_Name ='" + splitItems[2] + "', Purchase_Invoice_Number = '" + splitItems[3] + "', Purchase_Date = '" + splitItems[4] + "', Product_Price = '" + splitItems[5] + "', Serial_No = '" + splitItems[6] + "', Product_Return_Quantity ='" + splitItems[7] + "', Tax_Amount ='" + splitItems[8] + "', Net_Amount ='" + splitItems[9] + "' where Product_Code ='" + splitItems[0] + "' and GRV_ID = " + gid;
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
            if (gid == 0)
            {
                string strinsert = @"insert into Transaction_GRV(GRV_Number, GRV_Date, Vendor_Code, Vendor_Company_Name, Vendor_Address, Vendor_Contact_Person, Vendor_Contact_Details, Email, Vendor_invoice_Fer_num, Vendor_invoice_Ref_Date, PO_Number, PO_date, Remark_For_Return ) 
                          values('" + txt_GRV_Number.Text.ToString().Trim() + "', '" + txt_GRV_Date.Text.ToString().Trim() + "', '" + txt_vendor_Code.Text.ToString().Trim() + "', '" + txt_vendor_Company_Name.Text.ToString().Trim() + "', '" + txt_vendor_address.Text.ToString().Trim() +
                                            "', '" + txt_vendor_Contact_person.Text.ToString().Trim() + "', '" + txt_vendor_Contact_Details.Text.ToString().Trim() + "', '" + txt_Email.Text.ToString().Trim() + "', '" + txt_vendor_invoice_Ref_Number.Text.ToString().Trim() + "', '" + txt_vendor_Invoice_Ref_Date.Text.ToString().Trim() +
                                            "', '" + txt_PO_Number.Text.ToString().Trim() + "', '" + txt_PO_Date.Text.ToString().Trim() + "', '" + txt_remark_For_Return.Text.ToString().Trim() + "')";
                bool res = new CommonUtil().InserUpdateQuery(strinsert);
                DataTable dt = new CommonUtil().GetData("select max(GRV_ID) from Transaction_GRV");
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
                            Response.Redirect("GRV_List.aspx");
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
                string strinsert = @"update Transaction_GRV set Vendor_Code = '" + txt_vendor_Code.Text.ToString().Trim() + "',Vendor_Company_Name  = '" + txt_vendor_Company_Name.Text.ToString().Trim() + "', Vendor_Address = '" + txt_vendor_address.Text.ToString().Trim() +
                                            "', Vendor_Contact_Person = '" + txt_vendor_Contact_person.Text.ToString().Trim() + "', Vendor_Contact_Details = '" + txt_vendor_Contact_Details.Text.ToString().Trim() + "', Email = '" + txt_Email.Text.ToString().Trim() + "', Vendor_invoice_Fer_num = '" + txt_vendor_invoice_Ref_Number.Text.ToString().Trim() + "', Vendor_invoice_Ref_Date = '" + txt_vendor_Invoice_Ref_Date.Text.ToString().Trim() +
                                            "', PO_Number = '" + txt_PO_Number.Text.ToString().Trim() + "', PO_date = '" + txt_PO_Date.Text.ToString().Trim() + "', Remark_For_Return = '" + txt_remark_For_Return.Text.ToString().Trim() + "' where GRV_ID = "+gid;
                bool res = new CommonUtil().InserUpdateQuery(strinsert);
                DataTable dt = new CommonUtil().GetData("select max(GRV_ID) from Transaction_GRV");
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
                            Response.Redirect("GRV_List.aspx");
                            //redirect // succes message
                        }
                        else
                        {
                            string message = "Your details have been not Update.";
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

        protected void txt_vendor_Code_TextChanged(object sender, EventArgs e)
        {
            autofill();

        }

        protected void autofill()
        {
            string autof = "select  V_Company_Name, V_Company_Address from MST_Vendor where Vendor_Code =  '" + txt_vendor_Code.Text.ToString() + "'";
            DataTable dts = new CommonUtil().GetData(autof);
            if (dts.Rows.Count > 0)
            {

                //txt_Customer_Name.Text = dts.Rows[0]["Customer_Name"].ToString();
                txt_vendor_Company_Name.Text = dts.Rows[0]["V_Company_Name"].ToString();
                txt_vendor_address.Text = dts.Rows[0]["V_Company_Address"].ToString();

            }
        }
    }
}