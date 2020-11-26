using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.pridish.Common;

namespace com.pridish
{
    public partial class Product_Order_List : System.Web.UI.Page
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
            string str = " select u.Purchase_Order_ID as Pid,COUNT(u.Purchase_Order_ID)Product_Number, isnull(u.PO_Number,'')as PO_Number,isnull(u.PO_Date,'')as PO_Date,isnull(u.Vendor_Code,'')as Vendor_Code, isnull(u.V_Company_Name,'')as V_Company_Name,SUM(CONVERT(int, isnull(p.G_Net_Amount,''))) as G_Net_Amount   from  Transaction_Purchase_Order u inner join Purchase_Order_GridView p on u.Purchase_Order_ID = p.Purchase_Order_ID  where isnull(u.Active,1) = 1 ";

            if (txt_Vendor_Code.Text.ToString() != "")
            {
                str += " and u.Vendor_Code like '%" + txt_Vendor_Code.Text.ToString().Trim() + "%'";
            }
            if (txt_Vendor_Company_Name.Text.ToString() != "")
            {
                str += " and u.V_Company_Name like '%" + txt_Vendor_Company_Name.Text.ToString().Trim() + "%'";

            }
            str += "group by u.Purchase_Order_ID,u.PO_Number,u.PO_Date,u.Vendor_Code,u.V_Company_Name";


            System.Data.DataTable dts = new CommonUtil().GetData(str);
            grdCurrencyList.DataSource = dts;
            grdCurrencyList.DataBind();
        }



        protected void grdCurrency_command(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "RowEdit")
            {

                string test = e.CommandArgument.ToString();


                Response.Redirect("Add_Purchase_Order.aspx?track=Edit&id=" + test);
            }
            else if (e.CommandName == "RowView")
            {
                string[] name = new string[2];
                string test = e.CommandArgument.ToString();
                name = test.Split('*');

                Response.Redirect("Add_Purchase_Order.aspx?track=View&id=" + name[0] + "&name=" + name[1]);
            }
            else if (e.CommandName == "RowEdit1")
            {

                string test = e.CommandArgument.ToString();


                Response.Redirect("add_Material_Received.aspx?track=Edit1&id=" + test);
            }
            else if (e.CommandName == "RowView")
            {
                string[] name = new string[2];
                string test = e.CommandArgument.ToString();
                name = test.Split('*');

                Response.Redirect("add_Material_Received.aspx?track=View&id=" + name[0] + "&name=" + name[1]);
            }

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Add_Purchase_Order.aspx");

        }

        protected void txt_Vendor_Company_Name_TextChanged(object sender, EventArgs e)
        {
            SearchData();
        }

        protected void txt_Vendor_Code_TextChanged(object sender, EventArgs e)
        {
            SearchData();
        }
    }
}