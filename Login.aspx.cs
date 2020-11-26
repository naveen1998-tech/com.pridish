using com.pridish.Common;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace com.pridish
{
    public partial class Login : System.Web.UI.Page
    {
        static string cs = ConfigurationManager.ConnectionStrings["ERPConnectionString"].ToString();
        SqlConnection cn = new SqlConnection(cs);

        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand co = new SqlCommand();
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            string str = "Select * from MST_User where User_Email_Id  = '" + txt_UserName.Text.ToString().Trim() + "' and  User_Password = '" + txt_Password.Text.ToString().Trim() + "'";
            DataTable dts = new CommonUtil().GetData(str);

            if (dts.Rows.Count > 0)
            {
                Session["UserID"] = dts.Rows[0]["User_ID"];


                Response.Redirect("Default.aspx");
            }
            else
            {
                Response.Redirect("Login.aspx");
            }
        }
    }
}