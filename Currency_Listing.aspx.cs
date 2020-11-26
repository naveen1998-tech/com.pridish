using com.pridish.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace com.pridish
{
    public partial class Currency_Listing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Session.Abandon();
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {

                SearchData();
            }
        }

        public void SearchData()
        {
            string str = " select Currency_ID as cid,Currency_Code , Exchange_Rate from MST_Currency";



            System.Data.DataTable dts = new CommonUtil().GetData(str);
            grdCurrencyList.DataSource = dts;
            grdCurrencyList.DataBind();
        }
        protected void pageindexchange(object sender, GridViewPageEventArgs e)
        {
            grdCurrencyList.PageIndex = e.NewPageIndex;
            this.SearchData();
        }



        protected void grdCurrency_command(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "RowEdit")
            {

                string test = e.CommandArgument.ToString();


                Response.Redirect("Currency_Form.aspx?track=Edit&id=" + test);
            }
            else if (e.CommandName == "RowView")
            {
                string[] name = new string[2];
                string test = e.CommandArgument.ToString();
                name = test.Split('*');

                Response.Redirect("User.aspx?track=View&id=" + name[0] + "&name=" + name[1]);
            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Currency_Form.aspx");

        }

    }
}