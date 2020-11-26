using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.pridish.Common;
namespace com.pridish
{
    public partial class RFQ_List : System.Web.UI.Page
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
            string str = " select r.RFQ_ID as rfqid, COUNT(g.RFQ_ID)product_number,ISNULL(r.Customer_Code,'')Customer_Code,ISNULL(r.Customer_Name,'')Customer_Name, ISNULL( r.RFQ_Number,'')RFQ_Number,ISNULL( r.RFQ_Date,'')RFQ_Date,SUM(CONVERT(int, ISNULL( g.R_Net_Amount,'')))R_Net_Amount from Transaction_RFQ as r inner join RFQ_Product_GridView as g on r.RFQ_ID=g.RFQ_ID where ISNULL( r.Active,1) = 1  ";
            if (txt_Cust_code.Text.ToString() != "")
            {
                str += " and r.Customer_Code like '%" + txt_Cust_code.Text.ToString() + "%' ";
            
            }
            if (txt_Cust_name.Text.ToString() !="")
            {
                str += "and r.Customer_Name like '%" + txt_Cust_name .Text.ToString()+ "%' ";
            
            }
            str += "group by r.RFQ_ID, g.RFQ_ID,r.Customer_Code, r.Customer_Name, r.RFQ_Number, r.RFQ_Date ";



            System.Data.DataTable dts = new CommonUtil().GetData(str);
            grdCurrencyList.DataSource = dts;
            grdCurrencyList.DataBind();
        }

        


        protected void grdCurrency_command(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "RowEdit")
            {

                string test = e.CommandArgument.ToString();


                Response.Redirect("add_Inquiry.aspx?track=Edit&id=" + test);
            }
            else if (e.CommandName == "RowView")
            {
                string[] name = new string[2];
                string test = e.CommandArgument.ToString();
                name = test.Split('*');

                Response.Redirect("add_Inquiry.aspx?track=View&id=" + name[0] + "&name=" + name[1]);
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("add_Inquiry.aspx");

        }

        protected void txt_Cust_code_TextChanged(object sender, EventArgs e)
        {
           //SearchData1();
            SearchData();
        }

        protected void txt_Cust_name_TextChanged(object sender, EventArgs e)
        {
           // SearchData1();
            SearchData();
        }
    }
}