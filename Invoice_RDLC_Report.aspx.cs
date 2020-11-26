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
    public partial class Invoice_RDLC_Report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private void getdata()
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ERPConnectionString"].ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("select * from Transaction_Invoice i inner join Invoice_GridView g on i.Invoice_ID = g.Invoice_ID where i.Invoice_number = '" + TextBox1.Text.ToString().Trim() + "'", con);

            DataTable dt = new DataTable("InvoiceDataTable11");
            da.Fill(dt);


            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("Invoice.rdlc");
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt));




        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            getdata();
        }
    }
}