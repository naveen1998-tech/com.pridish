using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.pridish.Common;

namespace com.pridish
{
    public partial class GRN_List : System.Web.UI.Page
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
            string str = " select u.GRN_ID as gid,COUNT(p.GRN_ID) as product_Number, isnull(u.GRN_Number,'')as GRN_Number,isnull(u.GRN_Date,'')as GRN_Date,isnull(u.Customer_Code,'')as Customer_Code, isnull(u.Company_Name,'')as Company_Name,SUM( CONVERT(int, isnull(p.Net_Amount,'0')))as Net_Amount  from  Transaction_GRN u inner join GRN_GridView p on u.GRN_ID = p.GRN_ID  where isnull(u.Active,1) = 1 ";

            if (txt_Customer_Code.Text.ToString() != "")
            {
                str += " and u.Customer_Code like '%" + txt_Customer_Code.Text.ToString().Trim() + "%'";
            }
            if (txt_Company_Name.Text.ToString() != "")
            {
                str += " and u.Company_Name like '%" + txt_Company_Name.Text.ToString().Trim() + "%'";

            }
            str += "group by p.GRN_ID,u.GRN_ID,u.GRN_Number, u.GRN_Date,u.Customer_Code, u.Company_Name";


            System.Data.DataTable dts = new CommonUtil().GetData(str);
            grdCurrencyList.DataSource = dts;
            grdCurrencyList.DataBind();
        }



        protected void grdCurrency_command(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "RowEdit")
            {

                string test = e.CommandArgument.ToString();


                Response.Redirect("add_Goods_Return.aspx?track=Edit&id=" + test);
            }
            else if (e.CommandName == "RowView")
            {
                string[] name = new string[2];
                string test = e.CommandArgument.ToString();
                name = test.Split('*');

                Response.Redirect("add_Goods_Return.aspx?track=View&id=" + name[0] + "&name=" + name[1]);
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("add_Goods_Return.aspx");

        }

        protected void txt_Customer_Code_TextChanged(object sender, EventArgs e)
        {

            SearchData();
        }

        protected void txt_Company_Name_TextChanged(object sender, EventArgs e)
        {
            SearchData();

        }
    }
}