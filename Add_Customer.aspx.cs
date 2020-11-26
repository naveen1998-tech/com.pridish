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

    public partial class Add_Customer : System.Web.UI.Page
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
            else
            {
                if (Request.QueryString["track"] != null && Request.QueryString["track"] == "Edit")
                {
                    cid = int.Parse(Request.QueryString["id"].ToString());
                }
                else
                {
                    cid = 0;
                }
            }
        }

        protected void FillPage(int id)
        {
            //string str = "Select * from MST_Customer where Customer_ID  = " + id.ToString();
            string str = "select c.Address,c.Company_Name,c.Country, c.Credit_Limit, c.Credit_Terms, c.Currency,c.Customer_Code,c.Customer_ID, c.Customer_Name, c.Email_Id, c.Group_Company_Name, c.Mobile_Number,Cu.Currency_Code from MST_Customer c inner join MST_Currency  Cu on c.Currency = Cu.Currency_ID where c.Customer_ID  = " + id.ToString();
            DataTable dts = new CommonUtil().GetData(str);
            if (dts.Rows.Count > 0)
            {

                txt_CompanyName.Text = dts.Rows[0]["Company_Name"].ToString();
                txt_groupCompanyName.Text = dts.Rows[0]["Group_Company_Name"].ToString();
                txt_Customer_code.Text = dts.Rows[0]["Customer_Code"].ToString();
                txt_customerName.Text = dts.Rows[0]["Customer_Name"].ToString();
                txt_email.Text = dts.Rows[0]["Email_Id"].ToString();
                txt_mobile.Text = dts.Rows[0]["Mobile_Number"].ToString();
                txt_address.Text = dts.Rows[0]["Address"].ToString();
                txt_country.Text = dts.Rows[0]["Country"].ToString();
                ddl_Currency.SelectedValue = dts.Rows[0]["Customer_ID"].ToString();
                txt_creditLimit.Text = dts.Rows[0]["Credit_Limit"].ToString();
                txt_creditTerms.Text = dts.Rows[0]["Credit_Terms"].ToString();

            }
        }


        public void DDlBound()
        {
            string str = "select Currency_ID as ID, Currency_Code as cc from MST_Currency";
            DataTable dts = new CommonUtil().GetData(str);
            new CommonUtil().BindDDL("Select Currency", ddl_Currency, dts);

        }



        protected void btn_Save_Click(object sender, EventArgs e)
        {
            if (cid == 0)
            {
                string strinsert = @"insert into MST_Customer(Customer_Code,Company_Name, Group_Company_Name, Customer_Name, Email_Id, Mobile_Number, Address, Country, Currency, Credit_Limit, Credit_Terms  ) 
                          values('" + txt_Customer_code.Text.ToString().Trim() + "','" + txt_CompanyName.Text.ToString().Trim() + "','" + txt_groupCompanyName.Text.ToString().Trim() + "','" + txt_customerName.Text.ToString().Trim() + "','" + txt_email.Text.ToString().Trim() + "','" + txt_mobile.Text.ToString().Trim() + "','" + txt_address.Text.ToString().Trim() + "','" + txt_country.Text.ToString().Trim() + "','" + ddl_Currency.Text.ToString().Trim() + "','" + txt_creditLimit.Text.ToString().Trim() + "', '" + txt_creditTerms.Text.ToString().Trim() + "')";
                bool res = new CommonUtil().InserUpdateQuery(strinsert);
                if (res)
                {
                    string message = "Your details have been saved successfully.";
                    string script = "window.onload = function(){ alert('";
                    script += message;
                    script += "')};";
                    ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
                    Response.Redirect("List_Customer.aspx");
                    //redirect // succes message
                }
                else
                {
                    string message = "Your details have been not saved.";
                    string script = "window.onload = function(){ alert('";
                    script += message;
                    script += "')};";
                    ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
                    // failure message // page reload
                }
            }
            else 
            {
                string strinsert = "update MST_Customer set Customer_Code = '" + txt_Customer_code.Text.ToString().Trim() + "',Company_Name ='" + txt_CompanyName.Text.ToString().Trim() + "',Group_Company_Name= '" + txt_groupCompanyName.Text.ToString().Trim() + "',Customer_Name = '" + txt_customerName.Text.ToString().Trim() + "', Email_Id = '" + txt_email.Text.ToString().Trim() + "',Mobile_Number ='" + txt_mobile.Text.ToString().Trim() + "', Address= '" + txt_address.Text.ToString().Trim() + "', Country = '" + txt_country.Text.ToString().Trim() + "', Currency = '" + ddl_Currency.Text.ToString().Trim() + "', Credit_Limit = '" + txt_creditLimit.Text.ToString().Trim() + "', Credit_Terms =  '" + txt_creditTerms.Text.ToString().Trim() + "'    where Customer_ID=    " + cid;

                bool res = new CommonUtil().InserUpdateQuery(strinsert);
                if (res)
                {
                    string message = "Your details have been Updated successfully.";
                    string script = "window.onload = function(){ alert('";
                    script += message;
                    script += "')};";
                    ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
                    Response.Redirect("List_Customer.aspx");
                    //redirect // succes message
                }
            }
        }
    }
}