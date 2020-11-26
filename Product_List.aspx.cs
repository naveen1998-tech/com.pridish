using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.pridish.Common;

namespace com.pridish
{
    public partial class Product_List : System.Web.UI.Page
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
            string str = " select Product_Id as Pid, isnull(Product_Code,'') as Product_Code, isnull(Product_Group,'') as Product_Group, isnull(Product_Name,'') as Product_Name, isnull(Product_Purchase_Price,'') as Product_Purchase_Price, isnull(Product_Selling_Price,'') as Product_Selling_Price  from MST_Product where isnull(Active,1) = 1";
            if (txt_Product_Name_Search.Text.ToString() != "")
            {
                str += " and Product_Name like '%" + txt_Product_Name_Search.Text.ToString().Trim() + "%'";
            }


            System.Data.DataTable dts = new CommonUtil().GetData(str);
            grdOfficeExpense.DataSource = dts;
            grdOfficeExpense.DataBind();
        }
        protected void grdCustomer_command(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "RowEdit")
            {
                string test = e.CommandArgument.ToString();
                Response.Redirect("Add_Product_Master.aspx?track=Edit&id=" + test);
            }
            else if (e.CommandName == "RowView")
            {
                string[] name = new string[2];
                string test = e.CommandArgument.ToString();
                name = test.Split('*');

                Response.Redirect("Add_Product_Master.aspx?track=View&id=" + name[0] + "&name=" + name[1]);
            }
        }

        protected void txt_Product_Name_Search_TextChanged(object sender, EventArgs e)
        {
            SearchData();
        }
    }
}