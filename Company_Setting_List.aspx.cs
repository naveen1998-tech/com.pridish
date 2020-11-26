using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.pridish.Common;

namespace com.pridish
{
    public partial class Company_Setting_List : System.Web.UI.Page
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
            string str = " select c.Company_ID as cid , c.Comapny_Code, c.Conpany_Name, c.Email, c.Contact_Person from MST_Company_Setting_Master c ";



            System.Data.DataTable dts = new CommonUtil().GetData(str);
            grdCustomerList.DataSource = dts;
            grdCustomerList.DataBind();
        }
        protected void grdCustomer_command(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "RowEdit")
            {
                string test = e.CommandArgument.ToString();
                Response.Redirect("Company_Settings.aspx?track=Edit&id=" + test);
            }
            else if (e.CommandName == "RowView")
            {
                string[] name = new string[2];
                string test = e.CommandArgument.ToString();
                name = test.Split('*');

                Response.Redirect("Company_Settings.aspx?track=View&id=" + name[0] + "&name=" + name[1]);
            }
        }
    }
}