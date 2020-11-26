using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.pridish.Common;

namespace com.pridish
{
    public partial class Invoice_List : System.Web.UI.Page
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
            string str = " select u.Invoice_ID as Pid,COUNT(p.Invoice_ID) Porduct_Number, isnull(u.Invoice_number,'')as Invoice_number,isnull(u.Invoice_Date,'')as Invoice_Date,isnull(u.Customer_Code,'')as Customer_Code, isnull(u.Company_Name,'')as Company_Name,SUM(CONVERT(int, isnull(p.G_Net_Amount,'')))as G_Net_Amount  from  Transaction_Invoice u inner join Invoice_GridView p on u.Invoice_ID = p.Invoice_ID  where isnull(u.Active,1) = 1 ";
            if (txt_Cust_Code.Text.ToString() != "")
            {
                str += " and u.Customer_Code like '%" + txt_Cust_Code.Text.ToString().Trim() + "%'";
            }
            if (txt_Cumpany_Name.Text.ToString() != "")
            {
                str += " and u.Company_Name like '%" + txt_Cumpany_Name.Text.ToString().Trim() + "%'";

            }
            str += "group by u.Invoice_ID,u.Invoice_number,u.Invoice_Date,u.Customer_Code,u.Company_Name";


            System.Data.DataTable dts = new CommonUtil().GetData(str);
            grdCurrencyList.DataSource = dts;
            grdCurrencyList.DataBind();
        }



        protected void grdCurrency_command(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "RowEdit")
            {

                string test = e.CommandArgument.ToString();


                Response.Redirect("add_Invoice.aspx?track=Edit&id=" + test);
            }
            else if (e.CommandName == "RowView")
            {
                string[] name = new string[2];
                string test = e.CommandArgument.ToString();
                name = test.Split('*');

                Response.Redirect("add_Invoice.aspx?track=View&id=" + name[0] + "&name=" + name[1]);
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("add_Invoice.aspx");

        }

        protected void txt_Cust_Code_TextChanged(object sender, EventArgs e)
        {

            SearchData();
        }

        protected void txt_Cumpany_Name_TextChanged(object sender, EventArgs e)
        {

            SearchData();
        }
    }
}