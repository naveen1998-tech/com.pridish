using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.pridish.Common;
using System.Data;

namespace com.pridish
{
    public partial class Quotation_List : System.Web.UI.Page
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
            string str = " select u.Quotation_ID as Qid,COUNT(p.Quotation_ID) product_Number, isnull(u.Quotation_Number,'')as Quotation_Number, isnull(u.Customer_Name,'')as Customer_Name, isnull(u.Customer_Code,'')as Customer_Code,  isnull(u.Quotation_Number_Date,'') as Quotation_Number_Date,SUM(CONVERT(int, isnull(p.Q_Net_Amount,''))) as Q_Net_Amount from  Transaction_Quotation u inner join Quotation_Product_GridView p on u.Quotation_ID = p.Quotation_ID  where isnull(u.Active,1) = 1 ";
            if (txt_Search.Text.ToString() != "" )
            {
                str += " and u.Customer_Code like '%" + txt_Search.Text.ToString().Trim() + "%'";
            }
            if (txt_SearchName.Text.ToString() != "")
            {
                str += " and u.Customer_Name like '%" + txt_SearchName.Text.ToString().Trim() + "%'";

            }
            str += "group by u.Quotation_ID, p.Quotation_ID, u.Quotation_Number, u.Quotation_Number_Date, u.Customer_Name, u.Customer_Code  ";

            System.Data.DataTable dts = new CommonUtil().GetData(str);
            grdCurrencyList.DataSource = dts;
            grdCurrencyList.DataBind();
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

                //--------------------------Convert into Quotation To Sales---------------------------------------------

            else if (e.CommandName == "ConvertQuotationToSales")
            {

                string test = e.CommandArgument.ToString();


                Response.Redirect("add_Sales_Order.aspx?track=Edit1&id=" + test);
            
            
            }
            else if (e.CommandName == "RowsView")
            {

                string[] name = new string[2];
                string test = e.CommandArgument.ToString();
                name = test.Split('*');

                Response.Redirect("add_Sales_Order.aspx?track=View&id=" + name[0] + "&name=" + name[1]);
            
            }
        }
       

        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("add_Quotation.aspx");

        }

        protected void txt_Search_TextChanged(object sender, EventArgs e)
        {

            SearchData();
        }
        

        protected void btn_Search_Click(object sender, EventArgs e)
        {

            SearchData();
        }

        protected void txt_SearchName_TextChanged(object sender, EventArgs e)
        {
            SearchData();
        }
    }
}