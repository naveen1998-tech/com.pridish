using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Reporting.WebForms;
using System.Data;

namespace com.pridish
{
    public partial class Purchase_Order_Report : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ERPConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        private void getdata()
        {

            SqlDataAdapter da = new SqlDataAdapter("select* from Transaction_Purchase_Order s inner join Purchase_Order_GridView p on s.Purchase_Order_ID = p.G_Purchase_Order_ID where s.PO_Number = '" + txt_Purchase_Report.Text.ToString().Trim() + "'", con);

            DataTable dt = new DataTable("PurchaseOrderDataTable1");
            da.Fill(dt);


            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("Purchase_Report.rdlc");
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt));
        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {


            getdata();

        }
    }
}