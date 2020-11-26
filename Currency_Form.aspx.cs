using com.pridish.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace com.pridish
{
    public partial class Currency_Form : System.Web.UI.Page
    {
        int cid;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Session.Abandon();
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                DDlBound();

                if (Request.QueryString["track"] != null && Request.QueryString["track"] == "Edit")
                {
                    cid = int.Parse(Request.QueryString["id"].ToString());
                    FillPage(cid);
                }
            }
        }

        protected void FillPage(int id)
        {
            string str = "Select * from MST_Currency where Currency_ID  = " + id.ToString();
            DataTable dts = new CommonUtil().GetData(str);
            if (dts.Rows.Count > 0)
            {

                
                txt_Exchange_Rate.Text = dts.Rows[0]["Exchange_Rate"].ToString();
                ddl_Currency1.SelectedValue = dts.Rows[0]["Currency_ID"].ToString();
               
               




            }
        }


        public void DDlBound()
        {
            string str = "select Currency_ID as ID, Currency_Code as cc from MST_Currency";
            DataTable dts = new CommonUtil().GetData(str);
            new CommonUtil().BindDDL("Select Currency", ddl_Currency1, dts);

        }


        protected void btn_Add_Currency_Click(object sender, EventArgs e)
        {
            string strinsert = @"Update MST_Currency set Exchange_Rate = " + txt_Exchange_Rate.Text.ToString().Trim() + " where Currency_ID =" + ddl_Currency1.SelectedValue.ToString().Trim();

            bool res = new CommonUtil().InserUpdateQuery(strinsert);
            if (res)
            {
                string message = "Your details have been Updated successfully.";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "')};";
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
                //redirect // succes message
            }
            else
            {
                string message = "Your details have been not Updated.";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "')};";
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
                // failure message // page reload
            }
        }
    }
}