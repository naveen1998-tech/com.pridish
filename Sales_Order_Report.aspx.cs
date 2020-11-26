using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.pridish.Common;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Microsoft.Reporting.WebForms;

namespace com.pridish
{
    public partial class Sales_Order_Report : System.Web.UI.Page
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ERPConnectionString"].ConnectionString);
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void getdata()
        {


            SqlDataAdapter da = new SqlDataAdapter("select* from Transaction_sales_Order s inner join Sales_Product_GridView p on s.Sales_Order_Id = p.Sales_Order_Id where s.Sales_Order_Number = '" + txt_Sales_Report.Text.ToString().Trim() + "'", con);

            DataTable dt = new DataTable("SalesDataTable1");
            da.Fill(dt);


            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("Sales_Order.rdlc");
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt));
            // co.Connection = cn;

            



        }

        protected void txt_Sales_Report_TextChanged(object sender, EventArgs e)
        {
            getdata();
        }

    }
}