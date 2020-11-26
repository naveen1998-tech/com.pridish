using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.pridish.Common;

namespace com.pridish
{
    public partial class Delivery_Note_List : System.Web.UI.Page
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
            string str = " select u.Delivery_Note_ID as Did,COUNT(p.Delivery_Note_ID) Product_Number, isnull(u.Delivery_Note_Num_Date,'')as Delivery_Note_Num_Date,isnull(u.Customer_Code,'')as Customer_Code,isnull(u.Customer_Name,'')as Customer_Name, isnull(u.Delivery_Note_Number,'')as Delivery_Note_Number  from  Transaction_Delivery_Note u inner join Delivery_Note_GridView p on u.Delivery_Note_ID = p.Delivery_Note_ID  where isnull(u.Active,1) = 1";
            if (txt_Customer_Code.Text.ToString() != "")
            {
                str += " and u.Customer_Code like '%" + txt_Customer_Code.Text.ToString().Trim() + "%'";
            }
            if (txt_Customer_Name.Text.ToString() != "")
            {
                str += " and u.Customer_Name like '%" + txt_Customer_Name.Text.ToString().Trim() + "%'";

            }
            str += "group by u.Delivery_Note_ID,u.Delivery_Note_Num_Date,u.Customer_Code,u.Customer_Name,u.Delivery_Note_Number";


            System.Data.DataTable dts = new CommonUtil().GetData(str);
            grdCurrencyList.DataSource = dts;
            grdCurrencyList.DataBind();
        }



        protected void grdCurrency_command(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "RowEdit")
            {

                string test = e.CommandArgument.ToString();


                Response.Redirect("add_Delivery_Note.aspx?track=Edit&id=" + test);
            }
            else if (e.CommandName == "RowView")
            {
                string[] name = new string[2];
                string test = e.CommandArgument.ToString();
                name = test.Split('*');

                Response.Redirect("add_Delivery_Note.aspx?track=View&id=" + name[0] + "&name=" + name[1]);
            }
                //-------------------------for cash memo---------------------------------------
            else if (e.CommandName == "RowEdit1")
            {

                string test = e.CommandArgument.ToString();


                Response.Redirect("add_Cash_Memo.aspx?track=Edit1&id=" + test);
            }
            else if (e.CommandName == "RowView")
            {
                string[] name = new string[2];
                string test = e.CommandArgument.ToString();
                name = test.Split('*');

                Response.Redirect("add_Cash_Memo.aspx?track=View&id=" + name[0] + "&name=" + name[1]);
            }
            //-------------------------------for Invoice-------------------------------------
            else if (e.CommandName == "RowEdit2")
            {

                string test = e.CommandArgument.ToString();


                Response.Redirect("add_Invoice.aspx?track=Edit2&id=" + test);
            }
            else if (e.CommandName == "RowView")
            {
                string[] name = new string[2];
                string test = e.CommandArgument.ToString();
                name = test.Split('*');

                Response.Redirect("add_Invoice.aspx?track=View&id=" + name[0] + "&name=" + name[1]);
            }

            //-------------------------------for GRN-------------------------------------
            else if (e.CommandName == "RowEdit3")
            {

                string test = e.CommandArgument.ToString();


                Response.Redirect("add_Goods_Return.aspx?track=Edit3&id=" + test);
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
            Response.Redirect("add_Delivery_Note.aspx");

        }

        protected void txt_Customer_Code_TextChanged(object sender, EventArgs e)
        {
            SearchData();
        }

        protected void txt_Customer_Name_TextChanged(object sender, EventArgs e)
        {
            SearchData();
        }
    }
}