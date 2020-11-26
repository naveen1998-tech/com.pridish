using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UserID"] == null)
        {
            Session.Abandon();
            Response.Redirect("Login.aspx");
        }

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        //Session.Clear();
        //Session.RemoveAll();
        //Session.Abandon();

        //System.Web.Security.FormsAuthentication.SignOut();
        
        //Response.Redirect("~/Login.aspx");
        
    }
    protected void btn_Logout_Click(object sender, EventArgs e)
    {
        Session.Clear();
        Session.RemoveAll();
        Session.Abandon();

        System.Web.Security.FormsAuthentication.SignOut();

        Response.Redirect("~/Login.aspx");

    }
}
