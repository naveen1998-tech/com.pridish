using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.pridish.Common;
using System.Data;
using Microsoft.Reporting.WebForms;
using System.Data.SqlClient;
using System.Configuration;


namespace com.pridish
{
    public partial class GRN_RDLC_Report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private void getdata()
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ERPConnectionString"].ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("select * from Transaction_GRN t inner join GRN_GridView g on t.GRN_ID = g.GRN_ID where t.GRN_Number = '" + TextBox1.Text.ToString().Trim() + "'", con);

            DataTable dt = new DataTable("GRNDataTable1");
            da.Fill(dt);
            


            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("GRN.rdlc");
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt));




        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            getdata();
        }
    }
}