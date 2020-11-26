using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.pridish.Common;


namespace com.pridish
{
    public partial class Sales_Order_List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Session.Abandon();
                Response.Redirect("~/Login.aspx");
            }

            if (!IsPostBack)
            {

                SearchData();
            }
        }

        public void SearchData()
        {
            string str = " select Sales_Order_Id as Sid, Sales_Order_Number , Sales_Order_Date, Customer_Code, Company_Name from Transaction_sales_Order";



            System.Data.DataTable dts = new CommonUtil().GetData(str);
            grdSalesList.DataSource = dts;
            grdSalesList.DataBind();
        }



        protected void grdCurrency_command(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "RowEdit")
            {

                string test = e.CommandArgument.ToString();


                Response.Redirect("add_Quotation.aspx?track=Edit&id=" + test);
            }
            else if (e.CommandName == "RowView")
            {
                string[] name = new string[2];
                string test = e.CommandArgument.ToString();
                name = test.Split('*');

                Response.Redirect("add_Quotation.aspx?track=View&id=" + name[0] + "&name=" + name[1]);
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("add_Quotation.aspx");

        }
    }
}