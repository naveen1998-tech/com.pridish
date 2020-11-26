using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.pridish.Common;

namespace com.pridish
{
    public partial class MRN_List : System.Web.UI.Page
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
            string str = " select u.MRN_ID as mid,COUNT(p.MRN_ID) as Product_Number, isnull(u.MRN_Number,'')as MRN_Number,isnull(u.MRN_Date,'')as MRN_Date,isnull(u.Vendor_Code,'')as Vendor_Code, isnull(u.Vendor_Name,'')as Vendor_Name,SUM(CONVERT(int, isnull(p.Net_Amount,'0')))as Net_Amount  from  Transaction_MRN u inner join MRN_GridView p on u.MRN_ID = p.MRN_ID  where isnull(u.Active,1) = 1 ";

            if (txt_Vendor_Code.Text.ToString() != "")
            {
                str += " and u.Vendor_Code like '%" + txt_Vendor_Code.Text.ToString().Trim() + "%'";
            }
            if (txt_Vendor_Name.Text.ToString() != "")
            {
                str += " and u.Vendor_Name like '%" + txt_Vendor_Name.Text.ToString().Trim() + "%'";

            }
            str += "group by u.MRN_ID,p.MRN_ID, u.MRN_Number,u.MRN_Date,u.Vendor_Code,u.Vendor_Name";


            System.Data.DataTable dts = new CommonUtil().GetData(str);
            grdCurrencyList.DataSource = dts;
            grdCurrencyList.DataBind();
        }



        protected void grdCurrency_command(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "RowEdit")
            {

                string test = e.CommandArgument.ToString();


                Response.Redirect("add_Material_Received.aspx?track=Edit&id=" + test);
            }
            else if (e.CommandName == "RowView")
            {
                string[] name = new string[2];
                string test = e.CommandArgument.ToString();
                name = test.Split('*');

                Response.Redirect("add_Material_Received.aspx?track=View&id=" + name[0] + "&name=" + name[1]);
            }
            //-----------------------------------MRN 2 GRV-----------------------------------------------------------------------------------------------

            if (e.CommandName == "RowEdit1")
            {

                string test = e.CommandArgument.ToString();


                Response.Redirect("add_Grv_Form.aspx?track=Edit1&id=" + test);
            }
            else if (e.CommandName == "RowView")
            {
                string[] name = new string[2];
                string test = e.CommandArgument.ToString();
                name = test.Split('*');

                Response.Redirect("add_Grv_Form.aspx?track=View&id=" + name[0] + "&name=" + name[1]);
            }

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("add_Material_Received.aspx");

        }

        protected void txt_Vendor_Code_TextChanged(object sender, EventArgs e)
        {

            SearchData();
        }

        protected void txt_Vendor_Name_TextChanged(object sender, EventArgs e)
        {
            SearchData();

        }
    }
}