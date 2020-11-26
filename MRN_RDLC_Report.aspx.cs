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
    public partial class MRN_RDLC_Report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private void getdata()
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ERPConnectionString"].ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("select * from Transaction_MRN m inner join MRN_GridView g on m.MRN_ID = g.MRN_ID where m.MRN_Number = '" + TextBox1.Text.ToString().Trim() + "'", con);

            DataTable dt = new DataTable("MRNDataTable1");
            da.Fill(dt);


            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("MRN.rdlc");
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt));




        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            getdata();

        }
    }
}