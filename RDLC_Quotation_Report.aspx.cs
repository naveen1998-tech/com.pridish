using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Microsoft.Reporting.WebForms;

namespace com.pridish
{
    public partial class RDLC_Quotation_Report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        private void getdata()
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ERPConnectionString"].ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("select q.Customer_Code, q.Conpany_Name, q.Quotation_Number, q.Quotation_Number_Date, q.Quotation_Validity, q.Terms_Condition, qg.Q_Product_Group, qg.Q_Product_Name, qg.Q_Product_Price, qg.Q_Quantity, qg.Q_Product_Warrenty, qg.Q_Net_Amount from Transaction_Quotation q inner join Quotation_Product_GridView qg on q.Quotation_ID = qg.Quotation_ID where q.Quotation_Number = '" + TextBox1.Text.ToString().Trim() + "'", con);

            DataTable dt = new DataTable("QuotationDataTable1");
            da.Fill(dt);


            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("Quotation_Report1.rdlc");
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt));
            // co.Connection = cn;

            //string str = " select r.RFQ_Number, rg.R_Product_Name,rg.R_Product_Unit_Price, rg.R_Product_Quantity, rg.R_Product_Warrenty, rg.R_Net_Amount from Transaction_RFQ r inner join RFQ_Product_GridView rg on r.RFQ_ID = rg.RFQ_ID where r.RFQ_Number = '" + TextBox1.ToString().Trim() + "'";
            //System.Data.DataTable dts = new CommonUtil().GetData(str);



        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            getdata();
        }

    }
}