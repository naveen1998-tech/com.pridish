using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.pridish.Common;

namespace com.pridish
{
    public partial class Cash_Memo_List : System.Web.UI.Page
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
            string str = " select u.Cash_Memo_ID as cid,COUNT(p.Cash_Memo_ID) Product_Number, isnull(u.Cash_Memo_Number,'')as Cash_Memo_Number,isnull(u.Case_Memo_Date,'')as Case_Memo_Date,isnull(u.Customer_Code,'')as Customer_Code, isnull(u.Company_Name,'')as Company_Name,SUM(CONVERT( int, isnull(p.Net_Amount,'0')))as Net_Amount  from  Transaction_Cash_Memo u inner join Cash_Memo_GridView p on u.Cash_Memo_ID = p.Cash_Memo_ID  where isnull(u.Active,1) = 1 ";

            if (txt_Cust_Code.Text.ToString() != "")
            {
                str += " and u.Customer_Code like '%" + txt_Cust_Code.Text.ToString().Trim() + "%'";
            }
            if (txt_Company_Name.Text.ToString() != "")
            {
                str += " and u.Company_Name like '%" + txt_Company_Name.Text.ToString().Trim() + "%'";

            }
            str += "group by u.Cash_Memo_ID,u.Cash_Memo_Number,u.Case_Memo_Date,u.Customer_Code,u.Company_Name";


            System.Data.DataTable dts = new CommonUtil().GetData(str);
            grdCurrencyList.DataSource = dts;
            grdCurrencyList.DataBind();
        }



        protected void grdCurrency_command(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "RowEdit")
            {

                string test = e.CommandArgument.ToString();


                Response.Redirect("add_Cash_Memo.aspx?track=Edit&id=" + test);
            }
            else if (e.CommandName == "RowView")
            {
                string[] name = new string[2];
                string test = e.CommandArgument.ToString();
                name = test.Split('*');

                Response.Redirect("add_Cash_Memo.aspx?track=View&id=" + name[0] + "&name=" + name[1]);
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("add_Cash_Memo.aspx");

        }

        protected void txt_Cust_Code_TextChanged(object sender, EventArgs e)
        {

            SearchData();
        }

        protected void txt_Company_Name_TextChanged(object sender, EventArgs e)
        {
            SearchData();

        }
    }
}