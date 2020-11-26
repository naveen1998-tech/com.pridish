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
    public partial class Delivery_Note_RDLC_Report : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        private void getdata()
        {

            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ERPConnectionString"].ConnectionString);
            SqlDataAdapter da = new SqlDataAdapter("select d.Quotation_Num ,d.Quotation_Date,d.Delivery_Note_Number,d.Delivery_Note_Num_Date,dg.G_D_Product_Name , dg.G_D_Product_Code , sg.S_Serial_No,dg.G_D_Product_Quantity,dg.G_D_Product_Warrenty from Transaction_Delivery_Note d inner join Delivery_Note_GridView dg on d.Delivery_Note_ID = dg.Delivery_Note_ID inner join Delivery_Serial_No_grv sg on dg.G_Delivery_ID = sg.G_Sales_Order_ID where d.Delivery_Note_Number = '" + TextBox1.Text.ToString().Trim() + "'", con);

            DataTable dt = new DataTable("DeliveryNoteDataTable1");
            da.Fill(dt);


            ReportViewer1.ProcessingMode = ProcessingMode.Local;
            ReportViewer1.LocalReport.ReportPath = Server.MapPath("DeliveryNote.rdlc");
            ReportViewer1.LocalReport.DataSources.Clear();
            ReportViewer1.LocalReport.DataSources.Add(new ReportDataSource("DataSet1", dt));




        }

        protected void TextBox1_TextChanged(object sender, EventArgs e)
        {
            getdata();
        }

    }
}