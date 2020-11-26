using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.pridish.Common;

namespace com.pridish
{
    public partial class Vendor_List : System.Web.UI.Page
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
            string str = " select Vendor_Id as vid, isnull(Vendor_Code,'') as Vendor_Code, isnull(V_Company_Name,'') as V_Company_Name,isnull(V_Contact_Person,'') as V_Contact_Person, isnull(V_Mobile_Number,'') as V_Mobile_Number, isnull(V_Credit_Limit,'') as V_Credit_Limit from MST_Vendor where isnull(Active,1) = 1";

            if (txt_Search_Vendor_Name.Text.ToString() != "")
            {

                str += "and V_Company_Name like '%" + txt_Search_Vendor_Name.Text.ToString() + "%'";
            
            }



            System.Data.DataTable dts = new CommonUtil().GetData(str);
            grdVendorList.DataSource = dts;
            grdVendorList.DataBind();
        }

        protected void grdVendor_Commond(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "RowEdit")
            {
                string test = e.CommandArgument.ToString();
                Response.Redirect("Add_Vendor.aspx?track=Edit&id=" + test);
            }
            else if (e.CommandName == "RowView")
            {
                string[] name = new string[2];
                string test = e.CommandArgument.ToString();
                name = test.Split('*');

                Response.Redirect("Add_Vendor.aspx?track=View&id=" + name[0] + "&name=" + name[1]);
            }
        }

        protected void txt_Search_Vendor_Name_TextChanged(object sender, EventArgs e)
        {
            SearchData();
        }
    }
}