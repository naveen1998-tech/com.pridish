using com.pridish.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Collections.Specialized;
using System.Text;
using System.Data.SqlClient;

namespace com.pridish
{


    public partial class Add_Stock_Master : System.Web.UI.Page
    {




        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Session.Abandon();
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                DDlBound();
                SetInitialRow();

           //table col select from db--------------------------------------------------------

                //string constr = System.Configuration.ConfigurationManager.ConnectionStrings["ERPConnectionString"].ConnectionString;
                //using (System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(constr))
                //{
                //    using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand("SELECT * FROM nagaraju61"))
                //    {
                //        using (System.Data.SqlClient.SqlDataAdapter sda = new System.Data.SqlClient.SqlDataAdapter())
                //        {
                //            cmd.Connection = con;//nagaraju61
                //            sda.SelectCommand = cmd;
                //            using (DataTable dt = new DataTable())
                //            {
                //                sda.Fill(dt);
                //                gvRecords.DataSource = dt;
                //                gvRecords.DataBind();
                //            }
                //        }
                //    }
                //}
            }



        }
        //-----------------------------add gridview ------------------------
        private void SetInitialRow()
        {
            DataTable dt = new DataTable();
            DataRow dr = null;
            dt.Columns.Add(new DataColumn("RowNumber", typeof(string)));
            
            dt.Columns.Add(new DataColumn("Barcode", typeof(string)));
            dt.Columns.Add(new DataColumn("InhouseNumber", typeof(string)));
            dt.Columns.Add(new DataColumn("Serial_Number", typeof(string)));
            dt.Columns.Add(new DataColumn("Status", typeof(string)));
            

            dr = dt.NewRow();
            dr["RowNumber"] = 1;
            
            dr["Barcode"] = string.Empty;
            dr["InhouseNumber"] = string.Empty;
            dr["Serial_Number"] = string.Empty;
            dr["Status"] = string.Empty;
            

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
                        TextBox box1 = (TextBox)Gridview1.Rows[rowIndex].Cells[1].FindControl("txt_Barcode");
                        TextBox box2 = (TextBox)Gridview1.Rows[rowIndex].Cells[2].FindControl("txt_InhouseNumber");
                        TextBox box3 = (TextBox)Gridview1.Rows[rowIndex].Cells[3].FindControl("txt_Serial_Number");
                        TextBox box4 = (TextBox)Gridview1.Rows[rowIndex].Cells[4].FindControl("txt_Status");
                        


                        drCurrentRow = dtCurrentTable.NewRow();

                        drCurrentRow["RowNumber"] = i + 1;
                        drCurrentRow["Barcode"] = box1.Text;
                        drCurrentRow["InhouseNumber"] = box2.Text;
                        drCurrentRow["Serial_Number"] = box3.Text;
                        drCurrentRow["Status"] = box4.Text;
                       


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
                        TextBox box1 = (TextBox)Gridview1.Rows[rowIndex].Cells[1].FindControl("txt_Barcode");
                        TextBox box2 = (TextBox)Gridview1.Rows[rowIndex].Cells[2].FindControl("txt_InhouseNumber");
                        TextBox box3 = (TextBox)Gridview1.Rows[rowIndex].Cells[3].FindControl("txt_Serial_Number");
                        TextBox box4 = (TextBox)Gridview1.Rows[rowIndex].Cells[4].FindControl("txt_Status");
                        

                        box1.Text = dt.Rows[i]["Barcode"].ToString();
                        box2.Text = dt.Rows[i]["InhouseNumber"].ToString();
                        box3.Text = dt.Rows[i]["Serial_Number"].ToString();
                        box4.Text = dt.Rows[i]["Status"].ToString();
                        


                        rowIndex++;

                    }
                }
                // ViewState["CurrentTable"] = dt;

            }
        }

        protected void txt_Product_Quantity_TextChanged(object sender, EventArgs e)
        {
            if (txt_Product_Quantity.Text != "")
            {
                int txt = Int32.Parse(txt_Product_Quantity.Text);
                for (int i = 1; i < txt; i++)
                {
                    AddNewRowToGrid();
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
                        TextBox box1 = (TextBox)Gridview1.Rows[rowIndex].Cells[1].FindControl("txt_Barcode");
                        TextBox box2 = (TextBox)Gridview1.Rows[rowIndex].Cells[2].FindControl("txt_InhouseNumber");
                        TextBox box3 = (TextBox)Gridview1.Rows[rowIndex].Cells[3].FindControl("txt_Serial_Number");
                        TextBox box4 = (TextBox)Gridview1.Rows[rowIndex].Cells[4].FindControl("txt_Status");

                        //get the values from the TextBoxes
                        //then add it to the collections with a comma "," as the delimited values
                        sc.Add(box1.Text + "|" + box2.Text + "|" + box3.Text + "|" + box4.Text );
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

                const string sqlStatement = "INSERT INTO STOCK_SERIAL_NUMBER (Product_Id, Barcode, InhouseNumber, Serial_Number, Status) VALUES";
                if (item.Contains("|"))
                {
                    splitItems = item.Split("|".ToCharArray());
                    sb.AppendFormat("{0}('{1}','{2}','{3}','{4}','{5}'); ", sqlStatement, id, splitItems[0], splitItems[1], splitItems[2], splitItems[3]);
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
       
        //-------------------------------end GridView----------------------------

         //--------------------------Dynamically Textbox code Start-----------------------------------------------
        //protected void GenerateGridView(object sender, EventArgs e)
        //{
        //    gvData.Columns.Clear();
        //    DataTable dt = new DataTable();
        //    int cols = 5;
        //    int rows = Convert.ToInt32(txt_Product_Quantity.Text.Trim());
        //    for (int i = 0; i < cols; i++)
        //    {
        //        TemplateField field = new TemplateField();

        //        if (i == 0)
        //        {
        //            field.HeaderText = " Barcode ";
        //            field.ItemTemplate = new GridViewTemplate("Barcode" + (i + 1).ToString(), (i + 1).ToString());
        //        }

        //        if (i == 1)
        //        {
        //            field.HeaderText = " In-House Code ";
        //            field.ItemTemplate = new GridViewTemplate("In-House Code" + (i + 1).ToString(), (i + 1).ToString());
        //        }

        //        if (i == 2)
        //        {
        //            field.HeaderText = " Serial Number ";
        //            field.ItemTemplate = new GridViewTemplate("Serial Number" + (i + 1).ToString(), (i + 1).ToString());
        //        }
        //        if (i == 3)
        //        {
        //            field.HeaderText = " product code ";
        //            field.ItemTemplate = new GridViewTemplate("Product Code" + (i + 1).ToString(), (i + 1).ToString());

        //        }
        //        if (i == 4)
        //        {
        //            field.HeaderText = " Status  ";
        //            field.ItemTemplate = new GridViewTemplate("Product Code" + (i + 1).ToString(), (i + 1).ToString());

        //        }
        //        gvData.Columns.Add(field);
        //    }


        //    for (int i = 0; i < rows; i++)
        //    {
        //        dt.Rows.Add();
        //    }
        //    gvData.DataSource = dt;
        //    gvData.DataBind();
        //}

        //public class GridViewTemplate : ITemplate
        //{
        //    private string columnNameBinding;

        //    public GridViewTemplate(string colname, string colNameBinding)
        //    {
        //        columnNameBinding = colNameBinding;
        //    }

        //    public void InstantiateIn(System.Web.UI.Control container)
        //    {
        //        TextBox tb = new TextBox();
        //        tb.ID = "txtDynamic" + columnNameBinding;
        //        container.Controls.Add(tb);
        //    }
        //}

        //[System.Web.Services.WebMethod]
        //public static void InsertCustomers(string query)
        //{
        //    string constr = System.Configuration.ConfigurationManager.ConnectionStrings["ERPConnectionString"].ConnectionString;
        //    using (System.Data.SqlClient.SqlConnection con = new System.Data.SqlClient.SqlConnection(constr))
        //    {
        //        using (System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand(query))
        //        {
        //            cmd.Connection = con;
        //            con.Open();
        //            cmd.ExecuteNonQuery();
        //            con.Close();
        //        }
        //    }
        //}



       //------------------------------Dynamically Textbox code END--------------------------------------------------



        public void DDlBound()
        {
            string str = "select Product_Id as ID, Product_Code as cc from MST_Product";
            DataTable dts = new CommonUtil().GetData(str);
            new CommonUtil().BindDDL("Select Product Code", ddl_Product_Code, dts);

        }


        protected void btn_Save_Click(object sender, EventArgs e)
        {

            string strinsert = @"insert into MST_Stock(Product_Code, Product_Group, Product_Size, Product_Quantity  ) 
                         values('" + ddl_Product_Code.Text.ToString().Trim() + "','" + txt_Product_Group.Text.ToString().Trim() +
                          "','" + txt_Product_Size.Text.ToString().Trim() + "','" + txt_Product_Quantity.Text.ToString().Trim() + "')";
            bool res = new CommonUtil().InserUpdateQuery(strinsert);
            DataTable dt = new CommonUtil().GetData("select max(Stock_ID) from dbo.MST_Stock");
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
                        Response.Redirect("Stock_List.aspx");
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

        protected void ddl_Product_Code_SelectedIndexChanged(object sender, EventArgs e)
        {


            autofill();
        }


        protected void autofill()
        {
            string autof = "select  Product_Group, Product_Size from MST_Product where Product_Id =  '" + ddl_Product_Code.Text.ToString() + "'";
            DataTable dts = new CommonUtil().GetData(autof);
            if (dts.Rows.Count > 0)
            {

                txt_Product_Group.Text = dts.Rows[0]["Product_Group"].ToString();
                txt_Product_Size.Text = dts.Rows[0]["Product_Size"].ToString();
                //txt_company_Address.Text = dts.Rows[0]["Address"].ToString();


            }
        }

       


    }
       

       

    
}