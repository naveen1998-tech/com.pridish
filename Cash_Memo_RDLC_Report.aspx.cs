using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.pridish.Common;
using System.Data.SqlClient;
using System.Configuration;
using Microsoft.Reporting.WebForms;
using System.Data;

namespace com.pridish
{
    public partial class Cash_Memo_RDLC_Report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        private void getdata()
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ERPConnectionString"].ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("select * from Transaction_Cash_Memo c inner join Cash_Memo_GridView g on c.Cash_Memo_ID = g.Cash_Memo_ID where c.Cash_Memo_Number = '" + txt_CashMemo_No.Text.ToString().Trim() + "'", con);

            DataTable dt = new DataTable("CashMemoDataTable1");
            da.Fill(dt);


            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("CashMeno.rdlc");
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt));
            



        }

        protected void txt_CashMemo_No_TextChanged(object sender, EventArgs e)
        {

            getdata();
        }
    }
}