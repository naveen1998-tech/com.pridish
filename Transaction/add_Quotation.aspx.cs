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

    public partial class Transaction_add_Quotation : System.Web.UI.Page
    {
        int Qid;

        protected void Page_Load(object sender, EventArgs e)
        {
            txt_Quotation_Date.Text = DateTime.Now.ToString("dd-MM-yyyy");
            QuotationNumberID();

            if (!Page.IsPostBack)
            {
                if (Session["UserID"] == null)
                {
                    Session.Abandon();
                    Response.Redirect("~/Login.aspx");
                }

                SetInitialRow();


                if (Request.QueryString["track"] != null && Request.QueryString["track"] == "Edit")
                {
                    Qid = int.Parse(Request.QueryString["id"].ToString());
                    FillPage(Qid);
                }
            }
            else
            {
                if (Request.QueryString["track"] != null && Request.QueryString["track"] == "Edit")
                {
                    Qid = int.Parse(Request.QueryString["id"].ToString());
                }
                else
                {
                    Qid = 0;
                }
            }

        }

        //-----------------------Auto populated product fields---------------------------------------------

        protected void txt_Product_Code_TextChanged(object sender, EventArgs e)
        {
            GridViewRow row = (sender as TextBox).NamingContainer as GridViewRow;
            TextBox txt_Product_Code = (TextBox)row.FindControl("txt_Product_Code");
            TextBox txt_Product_Group = (TextBox)row.FindControl("txt_Product_Group");
            TextBox txt_Product_Name = (TextBox)row.FindControl("txt_Product_Name");
            TextBox txt_Product_Quantity = (TextBox)row.FindControl("txt_Product_Quantity");
            TextBox txt_Product_Price = (TextBox)row.FindControl("txt_Product_Price");
            TextBox txt_Warrenty = (TextBox)row.FindControl("txt_Warrenty");
            TextBox txt_Tax = (TextBox)row.FindControl("txt_Tax");
            TextBox txt_Net_Amount = (TextBox)row.FindControl("txt_Net_Amount");


            string autof = "select Product_Code as Q_Product_Code , Product_Group as Q_Product_Group, Product_Name as Q_Product_Name, Product_Selling_Price as Q_Product_Price, Tax as Q_Tax, Warrenty as Q_Product_Warrenty , Product_Unit as Q_Quantity from MST_Product where Product_Code =  '" + txt_Product_Code.Text.ToString() + "'";
            DataTable dts = new CommonUtil().GetData(autof);
            if (dts.Rows.Count > 0)
            {

                //txt_Customer_Name.Text = dts.Rows[0]["Customer_Name"].ToString();
                txt_Product_Group.Text = dts.Rows[0]["Q_Product_Group"].ToString();
                txt_Product_Name.Text = dts.Rows[0]["Q_Product_Name"].ToString();
                //txt_Product_Quantity.Text = dts.Rows[0]["Address"].ToString();
                txt_Warrenty.Text = dts.Rows[0]["Q_Product_Warrenty"].ToString();
                txt_Product_Price.Text = dts.Rows[0]["Q_Product_Price"].ToString();
                txt_Tax.Text = dts.Rows[0]["Q_Tax"].ToString();
                //txt_Total_Price.Text = dts.Rows[0]["Address"].ToString();
                

            }

        }

        //-------------------Total amount and tax calculation-----------------------------------------------


        protected void txt_Product_Quantity_TextChanged(object sender, EventArgs e)
        {
           
            GridViewRow row = (sender as TextBox).NamingContainer as GridViewRow;
            TextBox txt_Product_Quantity = (TextBox)row.FindControl("txt_Product_Quantity");
            TextBox txt_Product_Price = (TextBox)row.FindControl("txt_Product_Price");
            TextBox txt_Total_Price = (TextBox)row.FindControl("txt_Net_Amount");
            TextBox txt_Tax = (TextBox)row.FindControl("txt_Tax");

            float qty = float.Parse(txt_Product_Quantity.Text);
            float rate = float.Parse(txt_Product_Price.Text);
           //float tex = float.Parse(txt_Tax.Text);
            
            //int tot = Int32.Parse(txt_Total_Price.Text);

            float total, totaltax, addtax;
            total = rate * qty;
            txt_Total_Price.Text = total.ToString();

            //totaltax = total / 100 * tex;

            //addtax = total + totaltax;

            //txt_Total_Price.Text = addtax.ToString();




        }



        protected void txt_Product_Tax_TextChanged(object sender, EventArgs e)
        {
           
            GridViewRow row = (sender as TextBox).NamingContainer as GridViewRow;
            TextBox txt_Product_Quantity = (TextBox)row.FindControl("txt_Product_Quantity");
            TextBox txt_Product_Price = (TextBox)row.FindControl("txt_Product_Price");
            TextBox txt_Total_Price = (TextBox)row.FindControl("txt_Net_Amount");
            TextBox txt_Tax = (TextBox)row.FindControl("txt_Tax");

            float qty = float.Parse(txt_Product_Quantity.Text);
            float rate = float.Parse(txt_Product_Price.Text);
            float tex = float.Parse(txt_Tax.Text);
            
            //float tot = Int32.Parse(txt_Total_Price.Text);

            float total, totaltax, addtax;
            total = rate * qty;
            txt_Total_Price.Text = total.ToString();

            totaltax = total / 100 * tex;

            addtax = total + totaltax;

            txt_Total_Price.Text = addtax.ToString();




        }

        protected void FillPage(int id)
        {
            //string str = "Select * from MST_Customer where Customer_ID  = " + id.ToString();
            string str = "select t.Conpany_Name, t.Contact_Details, t.Contact_Person, t.Cuotation_Reference_Number, t.Customer_Code, t.Customer_Name , t.Customer_Reference_Date, t.Email, t.Payment_Terms , t.Quotation_Number, t.Quotation_Number_Date, t.Quotation_Validity, t.Remark, t.Shipping_Handling_Charges, t.Terms_Condition, t.company_Address, g.Q_Net_Amount, g.Q_Product_Code,g.Q_Product_Group, g.Q_Product_Name , g.Q_Product_Price , g.Q_Product_Warrenty, g.Q_Quantity as Q_Quantity , g.Q_Tax, g.Q_Net_Amount as Q_Net_Amount  from Transaction_Quotation t inner join Quotation_Product_GridView g on t.Quotation_ID = g.Quotation_ID where t.Quotation_ID = " + id.ToString();
            DataTable dts = new CommonUtil().GetData(str);
            if (dts.Rows.Count > 0)
            {


                txt_Customer_Code.Text = dts.Rows[0]["Customer_Code"].ToString();
                txt_Customer_Name.Text = dts.Rows[0]["Customer_Name"].ToString();
                txt_Company_Name.Text = dts.Rows[0]["Conpany_Name"].ToString();
                txt_Company_address.Text = dts.Rows[0]["company_Address"].ToString();
                txt_Contact_Person.Text = dts.Rows[0]["Contact_Person"].ToString();
                txt_Contact_Details.Text = dts.Rows[0]["Contact_Details"].ToString();
                txt_Email.Text = dts.Rows[0]["Email"].ToString();
                txt_Quotation_Number.Text = dts.Rows[0]["Quotation_Number"].ToString();
                txt_Quotation_Date.Text = dts.Rows[0]["Quotation_Number_Date"].ToString();
                ddl_Quotation_Validity.SelectedValue = dts.Rows[0]["Quotation_Validity"].ToString();
                txt_Payment_Terms.Text = dts.Rows[0]["Payment_Terms"].ToString();


                txt_Customer_Reference.Text = dts.Rows[0]["Cuotation_Reference_Number"].ToString();
                txt_cuotomer_Reference_Date.Text = dts.Rows[0]["Customer_Reference_Date"].ToString();
                txt_terms_Condition.Text = dts.Rows[0]["Terms_Condition"].ToString();
                txt_Shipping_Handling_Charges.Text = dts.Rows[0]["Shipping_Handling_Charges"].ToString();
                txt_Remark.Text = dts.Rows[0]["Remark"].ToString();

                Gridview1.DataSource = dts;
                Gridview1.DataBind();

                ViewState["CurrentTable"] = dts;
                
            }
        }

        public void QuotationNumberID()
        {
            string cs = ConfigurationManager.ConnectionStrings["ERPConnectionString"].ToString();
            SqlConnection cn = new SqlConnection(cs);
            int j = 18000;
            SqlDataAdapter sda = new SqlDataAdapter("Select (Quotation_Number) from Transaction_Quotation", cn);
            DataTable dt = new DataTable();
            sda.Fill(dt);

            int i = dt.Rows.Count;

            int cnt = j + i;//Convert.ToString(i + 1);
            txt_Quotation_Number.Text = "MR-QT-" + cnt;


        }

        private void SetInitialRow()
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            //dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
            dt.Columns.Add(new DataColumn("Q_Product_Code", typeof(string)));
            dt.Columns.Add(new DataColumn("Q_Product_Group", typeof(string)));
            dt.Columns.Add(new DataColumn("Q_Product_Name", typeof(string)));
            dt.Columns.Add(new DataColumn("Q_Quantity", typeof(string)));
            dt.Columns.Add(new DataColumn("Q_Product_Price", typeof(string)));
            dt.Columns.Add(new DataColumn("Q_Product_Warrenty", typeof(string)));
            dt.Columns.Add(new DataColumn("Q_Tax", typeof(string)));
            dt.Columns.Add(new DataColumn("Q_Net_Amount", typeof(string)));
            dr = dt.NewRow();
           // dr["RowNumber"] = 1;
            dr["Q_Product_Code"] = string.Empty;
            dr["Q_Product_Group"] = string.Empty;
            dr["Q_Product_Name"] = string.Empty;
            dr["Q_Quantity"] = string.Empty;
            dr["Q_Product_Price"] = string.Empty;
            dr["Q_Product_Warrenty"] = string.Empty;
            dr["Q_Tax"] = string.Empty;
            dr["Q_Net_Amount"] = string.Empty;
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
                        TextBox box6 = (TextBox)Gridview1.Rows[rowIndex].Cells[6].FindControl("txt_Warrenty");
                        TextBox box7 = (TextBox)Gridview1.Rows[rowIndex].Cells[7].FindControl("txt_Tax");
                        TextBox box8 = (TextBox)Gridview1.Rows[rowIndex].Cells[8].FindControl("txt_Net_Amount");

                        drCurrentRow = dtCurrentTable.NewRow();

                        //drCurrentRow["RowNumber"] = i + 1;
                        drCurrentRow["Q_Product_Code"] = box1.Text;
                        drCurrentRow["Q_Product_Group"] = box2.Text;
                        drCurrentRow["Q_Product_Name"] = box3.Text;
                        drCurrentRow["Q_Quantity"] = box4.Text;
                        drCurrentRow["Q_Product_Price"] = box5.Text;
                        drCurrentRow["Q_Product_Warrenty"] = box6.Text;
                        drCurrentRow["Q_Tax"] = box7.Text;
                        drCurrentRow["Q_Net_Amount"] = box8.Text;

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
                        TextBox box6 = (TextBox)Gridview1.Rows[rowIndex].Cells[6].FindControl("txt_Warrenty");
                        TextBox box7 = (TextBox)Gridview1.Rows[rowIndex].Cells[7].FindControl("txt_Tax");
                        TextBox box8 = (TextBox)Gridview1.Rows[rowIndex].Cells[8].FindControl("txt_Net_Amount");

                        box1.Text = dt.Rows[i]["Q_Product_Code"].ToString();
                        box2.Text = dt.Rows[i]["Q_Product_Group"].ToString();
                        box3.Text = dt.Rows[i]["Q_Product_Name"].ToString();
                        box4.Text = dt.Rows[i]["Q_Quantity"].ToString();
                        box5.Text = dt.Rows[i]["Q_Product_Price"].ToString();
                        box6.Text = dt.Rows[i]["Q_Product_Warrenty"].ToString();
                        box7.Text = dt.Rows[i]["Q_Tax"].ToString();
                        box8.Text = dt.Rows[i]["Q_Net_Amount"].ToString();

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
                        TextBox box6 = (TextBox)Gridview1.Rows[rowIndex].Cells[6].FindControl("txt_Warrenty");
                        TextBox box7 = (TextBox)Gridview1.Rows[rowIndex].Cells[7].FindControl("txt_Tax");
                        TextBox box8 = (TextBox)Gridview1.Rows[rowIndex].Cells[8].FindControl("txt_Net_Amount");
                        
                        

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
                if (Qid == 0)
                {
                    const string sqlStatement = "INSERT INTO Quotation_Product_GridView (Quotation_ID, Q_Product_Code,Q_Product_Group,Q_Product_Name, Q_Quantity, Q_Product_Price, Q_Product_Warrenty,Q_Tax, Q_Net_Amount) VALUES";
                    if (item.Contains("|"))
                    {
                        splitItems = item.Split("|".ToCharArray());
                        sb.AppendFormat("{0}('{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}'); ", sqlStatement, id, splitItems[0], splitItems[1], splitItems[2], splitItems[3], splitItems[4], splitItems[5], splitItems[6], splitItems[7]);
                    }
                }
                else
                {
                    string strParam = "";
                    const string sqlStatement = "update Quotation_Product_GridView set ";
                      
                    if (item.Contains("|"))
                    {
                        splitItems = item.Split("|".ToCharArray());

                        strParam = strParam + "Q_Product_Code='" + splitItems[0] + "',Q_Product_Group='" + splitItems[1] + "', Q_Product_Name='" + splitItems[2] + "',Q_Quantity ='" + splitItems[3] + "', Q_Product_Price ='" + splitItems[4] + "', Q_Product_Warrenty ='" + splitItems[5] + "',Q_Tax ='" + splitItems[6] + "', Q_Net_Amount ='" + splitItems[7] + "' where Q_Product_Code ='" + splitItems[0] + "' and Quotation_ID=" + Qid;
                        //sb.AppendFormat("{0}('{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}'); ", sqlStatement, id, splitItems[0], splitItems[1], splitItems[2], splitItems[3], splitItems[4], splitItems[5], splitItems[6], splitItems[7]);
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
            if (Qid == 0)
            {
                string strinsert = @"insert into Transaction_Quotation(Customer_Code, Customer_Name, Conpany_Name, company_Address, Contact_Person, Contact_Details, Email, Quotation_Number, Quotation_Number_Date, Quotation_Validity, Payment_Terms, Cuotation_Reference_Number, Customer_Reference_Date, Terms_Condition, Shipping_Handling_Charges, Remark  ) 
                          values('" + txt_Customer_Code.Text.ToString().Trim() + "','" + txt_Customer_Name.Text.ToString().Trim() + "','" + txt_Company_Name.Text.ToString().Trim() + "','" + txt_Company_address.Text.ToString().Trim() +
                                            "','" + txt_Contact_Person.Text.ToString().Trim() + "','" + txt_Contact_Details.Text.ToString().Trim() + "','" + txt_Email.Text.ToString().Trim() +
                                            "','" + txt_Quotation_Number.Text.ToString().Trim() + "','" + txt_Quotation_Date.Text.ToString().Trim() + "','" + ddl_Quotation_Validity.Text.ToString().Trim() + "','" + txt_Payment_Terms.Text.ToString().Trim() +
                                            "','" + txt_Customer_Reference.Text.ToString().Trim() + "','" + txt_cuotomer_Reference_Date.Text.ToString().Trim() + "','" + txt_terms_Condition.Text.ToString().Trim() + "','" + txt_Shipping_Handling_Charges.Text.ToString().Trim() + "','" + txt_Remark.Text.ToString().Trim() + "')";
                bool res = new CommonUtil().InserUpdateQuery(strinsert);
                DataTable dt = new CommonUtil().GetData("select max(Quotation_ID) from Transaction_Quotation");
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
                            Response.Redirect("Quotation_List.aspx");
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
                string strinsert = @"update Transaction_Quotation set Customer_Code = '" + txt_Customer_Code.Text.ToString().Trim() + "',Customer_Name= '" + txt_Customer_Name.Text.ToString().Trim() + "',Conpany_Name ='" + txt_Company_Name.Text.ToString().Trim() + "',company_Address ='" + txt_Company_address.Text.ToString().Trim() + 
                    "',Contact_Person = '" + txt_Contact_Person.Text.ToString().Trim() + "', Contact_Details = '" + txt_Contact_Details.Text.ToString().Trim() + "', Email ='" + txt_Email.Text.ToString().Trim() +
                   "',Quotation_Validity = '" + ddl_Quotation_Validity.Text.ToString().Trim() + "',Payment_Terms ='" + txt_Payment_Terms.Text.ToString().Trim() +
                  "',Cuotation_Reference_Number ='" + txt_Customer_Reference.Text.ToString().Trim() + "',Customer_Reference_Date = '" + txt_cuotomer_Reference_Date.Text.ToString().Trim() + "',Terms_Condition = '" + txt_terms_Condition.Text.ToString().Trim() + "',Shipping_Handling_Charges = '" + txt_Shipping_Handling_Charges.Text.ToString().Trim() + "',Remark = '" + txt_Remark.Text.ToString().Trim() + "'where Quotation_ID = "+Qid;
//                        
                bool res = new CommonUtil().InserUpdateQuery(strinsert);


                DataTable dt = new CommonUtil().GetData("select max(Quotation_ID) from Transaction_Quotation");
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
                            Response.Redirect("Quotation_List.aspx");
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

        protected void txt_Customer_Code_TextChanged(object sender, EventArgs e)
        {
            autofill();
        
        }
            protected void autofill()
        {
            string autof = "select Customer_Name, Company_Name, Address from MST_Customer where Customer_Code =  '"+ txt_Customer_Code.Text.ToString()+"'";
              DataTable dts = new CommonUtil().GetData(autof);
              if (dts.Rows.Count > 0)
              {

                  txt_Customer_Name.Text = dts.Rows[0]["Customer_Name"].ToString();
                  txt_Company_Name.Text = dts.Rows[0]["Company_Name"].ToString();
                  txt_Company_address.Text = dts.Rows[0]["Address"].ToString();
              
              }
        }

            protected void txt_Product_Grdview_cereate_TextChanged(object sender, EventArgs e)
            {
                if (txt_Product_Grdview_cereate.Text != "")
                {
                    int txt = Int32.Parse(txt_Product_Grdview_cereate.Text);

                    for (int i = 1; i < txt; i++)
                    {
                        AddNewRowToGrid();
                    }
                }
                    
               else
                {
                    txt_Product_Grdview_cereate.Text = "Please Enter Valid Number";
                }
                
                    
            }
        
    }
}