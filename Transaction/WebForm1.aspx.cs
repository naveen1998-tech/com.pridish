using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.pridish.Common;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;


namespace com.pridish
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
            //// Method();
        }


        protected void Button1_Click(object sender, EventArgs e)
        {
             check();

        }

        public void InsertData()
        {
            string strinsert = @"insert into Test_Data(Test_Quantity, Test_Serial_No ) values('" + TextBox1.Text.ToString().Trim() + "','" + TextBox1.Text.ToString().Trim() + "')";
            bool res = new CommonUtil().InserUpdateQuery(strinsert);
            if (res)
            {
                string message = "Your details have been saved successfully.";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "')};";
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
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

        public void check()
        {
            int x = Int32.Parse(TextBox1.Text);
            //int[] intArray;
            //intArray = new int[x];

            TableRow trow;
            TableCell tcell1;

            for (int i = 0; i < x; i++)
            {
                trow = new TableRow();
                tcell1 = new TableCell();
                TextBox txt = new TextBox();
                
                txt.ID = "txt_" + (i + 1).ToString();
                tcell1.Controls.Add(txt);

                trow.Cells.Add(tcell1);

                mytbl.Rows.Add(trow);
            }
        }

        protected void btn_Save_Click(object sender, EventArgs e)
        {

            InsertData();
            TextBox tx = (TextBox)Page.FindControl("txt_1");
            string s = tx.Text;
            // InsertData();
        }

        ////public void Method()
        ////{
        ////    string cs = ConfigurationManager.ConnectionStrings["ERPConnectionString"].ToString();
        ////    SqlConnection cn = new SqlConnection(cs);
        ////    int j = 24000;
        ////    SqlDataAdapter sda = new SqlDataAdapter("Select (Test_Serial_No) from Test_Data", cn);
        ////    DataTable dt = new DataTable();
        ////    sda.Fill(dt);

        ////    int i = dt.Rows.Count;

        ////    int cnt = j + i;//Convert.ToString(i + 1);
            
        ////    TextBox1.Text = "MR-RFQ-" + cnt;


        ////}

       

    }

}