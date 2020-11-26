using com.pridish.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace com.pridish
{
    public partial class List_Customer : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            { 
                SearchData();
            }
        }


        public void SearchData()
        {
            string str = "select u.Customer_ID as cid, isnull(u.Customer_Code,'')as Customer_Code,  isnull(u.Customer_Name,'') as Customer_Name, isnull(u.Email_Id,'') as Email_Id,  isnull(u.Mobile_Number,'') as Mobile_Number,isnull(u.Credit_Limit,'')as Credit_Limit,isnull(u.Credit_Terms,'') as Credit_Terms from  MST_Customer u  where isnull(u.Active,1) = 1  ";

            if (txt_Search.Text.ToString() != "")
                str += " and u.Customer_Name like '%" + txt_Search.Text.ToString().Trim() + "%'";

            System.Data.DataTable dts = new CommonUtil().GetData(str);
            grdCustomerList.DataSource = dts;
            grdCustomerList.DataBind();
        }



        protected void grdCustomer_command(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "RowEdit")
            { 
                string test = e.CommandArgument.ToString(); 
                Response.Redirect("Add_Customer.aspx?track=Edit&id=" + test);
            }
            else if (e.CommandName == "RowView")
            {
                string[] name = new string[2];
                string test = e.CommandArgument.ToString();
                name = test.Split('*');

                Response.Redirect("Add_Customer.aspx?track=View&id=" + name[0] + "&name=" + name[1]);
            }
        }
        protected void Add_Customer_Click(object sender, EventArgs e)
        {

            Response.Redirect("Add_Customer.aspx");
        }

        protected void btn_Search_Click(object sender, EventArgs e)
        {
            SearchData();
        }

        protected void txt_Search_TextChanged(object sender, EventArgs e)
        {

            SearchData();

        }
    }
}