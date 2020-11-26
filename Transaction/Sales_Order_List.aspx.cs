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
            string str = " select u.Sales_Order_Id as Sid,COUNT(p.Sales_Order_Id) Product_Number, isnull(u.Customer_Code,'')as Customer_Code,isnull(u.Company_Name,'')as Company_Name,isnull(u.Sales_Order_Number,'')as Sales_Order_Number, isnull(u.Sales_Order_Date,'')as Sales_Order_Date,SUM(CONVERT(int, isnull(p.G_Net_Amount,''))) as G_Net_Amount  from  Transaction_sales_Order u inner join Sales_Product_GridView p on u.Sales_Order_Id = p.Sales_Order_Id  where isnull(u.Active,1) = 1   ";

            if (txt_Cust_Code.Text.ToString() != "")
            {
                str += " and u.Customer_Code like '%" + txt_Cust_Code.Text.ToString().Trim() + "%'";
            }
            if (txt_Cust_Name.Text.ToString() != "")
            {
                str += " and u.Company_Name like '%" + txt_Cust_Name.Text.ToString().Trim() + "%'";

            }

            str += "group by u.Sales_Order_Id, u.Customer_Code, u.Company_Name,u.Sales_Order_Date, u.Sales_Order_Number ";


            System.Data.DataTable dts = new CommonUtil().GetData(str);
            grdCurrencyList.DataSource = dts;
            grdCurrencyList.DataBind();
        }



        protected void grdCurrency_command(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "RowEdit")
            {

                string test = e.CommandArgument.ToString();


                Response.Redirect("add_Sales_Order.aspx?track=Edit&id=" + test);
            }
            else if (e.CommandName == "RowView")
            {
                string[] name = new string[2];
                string test = e.CommandArgument.ToString();
                name = test.Split('*');

                Response.Redirect("add_Sales_Order.aspx?track=View&id=" + name[0] + "&name=" + name[1]);
            }

            else if (e.CommandName == "RowEdit1")
            {

                string test = e.CommandArgument.ToString();
                Response.Redirect("add_Delivery_Note.aspx?track=Edit1&id=" + test);
            
            }
            else if (e.CommandName == "RowView")
            {
                string[] name = new string[2];
                string test = e.CommandArgument.ToString();
                name = test.Split('*');

                Response.Redirect("add_Delivery_Note.aspx?track=View&id=" + name[0] + "&name=" + name[1]);
            }

            else if (e.CommandName == "RowEdit2")
            {

                string test = e.CommandArgument.ToString();
                Response.Redirect("Add_Purchase_Order.aspx?track=Edit2&id=" + test);

            }
            else if (e.CommandName == "RowView")
            {
                string[] name = new string[2];
                string test = e.CommandArgument.ToString();
                name = test.Split('*');

                Response.Redirect("Add_Purchase_Order.aspx?track=View&id=" + name[0] + "&name=" + name[1]);
            }


        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("add_Sales_Order.aspx");

        }

        protected void txt_Cust_Code_TextChanged(object sender, EventArgs e)
        {
            SearchData();
        }

        protected void txt_Cust_Name_TextChanged(object sender, EventArgs e)
        {
            SearchData();
        }
    }
}