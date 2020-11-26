using com.pridish.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace com.pridish
{

    public partial class Company_Settings : System.Web.UI.Page
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
            string str = "Select * from MST_Company_Setting_Master c inner join MST_Currency y on c.Company_ID = y.Currency_ID where Company_ID  =  " + id.ToString();
            DataTable dts = new CommonUtil().GetData(str);
            if (dts.Rows.Count > 0)
            {


                txt_CompanyCode.Text = dts.Rows[0]["Comapny_Code"].ToString();
                txt_CompanyName.Text = dts.Rows[0]["Conpany_Name"].ToString();

                txt_BrandName.Text = dts.Rows[0]["Brand_Name"].ToString();
                txt_ContactPerson.Text = dts.Rows[0]["Contact_Person"].ToString();
                txt_Email.Text = dts.Rows[0]["Email"].ToString();
                txt_MobileNumber.Text = dts.Rows[0]["Mobile_Number"].ToString();
                txt_Address.Text = dts.Rows[0]["Company_Address"].ToString();
                txt_Country.Text = dts.Rows[0]["Country"].ToString();
                ddl_Base_Currency.SelectedValue = dts.Rows[0]["Currency_ID"].ToString();
                txt_AccountNumber.Text = dts.Rows[0]["B_Account_Number"].ToString();
                txt_BankName.Text = dts.Rows[0]["B_Bank_Name"].ToString();
                txt_BranchName.Text = dts.Rows[0]["B_Branch_Name"].ToString();
                txt_SwiftCode.Text = dts.Rows[0]["B_Swift_Code"].ToString();
                txt_AccountName.Text = dts.Rows[0]["B_Account_Name"].ToString();
                txt_BankCompanyName.Text = dts.Rows[0]["B_company_Name"].ToString();
                txt_CityName.Text = dts.Rows[0]["B_city_Name"].ToString();
                txt_BankCountry.Text = dts.Rows[0]["B_Country"].ToString();
                








            }
        }

        public void DDlBound()
        {
            string str = "select Currency_ID as ID, Currency_Code as cc from MST_Currency where Currency_ID = 16 or Currency_ID = 2 or Currency_ID = 1";
            DataTable dts = new CommonUtil().GetData(str);
            new CommonUtil().BindDDL("Select Currency", ddl_Base_Currency, dts);

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            if (cid == 0)
            {
                string strinsert = @"insert into MST_Company_Setting_Master(Comapny_Code,Conpany_Name,Contact_Person,Email,Mobile_Number,Company_Address,Country,Company_Base_Currency,B_Bank_Name,B_Branch_Name,B_Swift_Code,B_Account_Name,B_Account_Number,B_company_Name,B_city_Name,B_Country,Brand_Name) values('" + txt_CompanyCode.Text.ToString().Trim() + "','" + txt_CompanyName.Text.ToString().Trim() + "','" + txt_ContactPerson.Text.ToString().Trim() + "','" + txt_Email.Text.ToString().Trim() + "','" + txt_MobileNumber.Text.ToString().Trim() + "','" + txt_Address.Text.ToString().Trim() + "','" + txt_Country.Text.ToString().Trim() + "','" + ddl_Base_Currency.Text.ToString().Trim() + "','" + txt_BankName.Text.ToString().Trim() + "','" + txt_BranchName.Text.ToString().Trim() + "','" + txt_SwiftCode.Text.ToString().Trim() + "','" + txt_AccountName.Text.ToString().Trim() + "','" + txt_AccountNumber.Text.ToString().Trim() + "','" + txt_BankCompanyName.Text.ToString().Trim() + "','" + txt_CityName.Text.ToString().Trim() + "','" + txt_BankCountry.Text.ToString().Trim() + "','" + txt_BrandName.Text.ToString().Trim() + "')";
                bool res = new CommonUtil().InserUpdateQuery(strinsert);
                if (res)
                {
                    string message = "Your details have been saved successfully.";
                    string script = "window.onload = function(){ alert('";
                    script += message;
                    script += "')};";
                    ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
                    Response.Redirect("Company_Setting_List.aspx");
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

                string strinsert = @"update MST_Company_Setting_Master set Comapny_Code = '" + txt_CompanyCode.Text.ToString().Trim() + "',Conpany_Name = '" + txt_CompanyName.Text.ToString().Trim() + "',Contact_Person = '" + txt_ContactPerson.Text.ToString().Trim() + "',Email = '" + txt_Email.Text.ToString().Trim() + "',Mobile_Number = '" + txt_MobileNumber.Text.ToString().Trim() + "',Company_Address = '" + txt_Address.Text.ToString().Trim() + "',Country = '" + txt_Country.Text.ToString().Trim() + "',Company_Base_Currency = '" + ddl_Base_Currency.Text.ToString().Trim() + "',B_Bank_Name = '" + txt_BankName.Text.ToString().Trim() + "',B_Branch_Name = '" + txt_BranchName.Text.ToString().Trim() + "',B_Swift_Code = '" + txt_SwiftCode.Text.ToString().Trim() + "',B_Account_Number = '" + txt_AccountNumber.Text.ToString().Trim() + "', B_company_Name = '" + txt_BankCompanyName.Text.ToString().Trim() + "',B_city_Name = '" + txt_CityName.Text.ToString().Trim() + "',B_Country = '" + txt_BankCountry.Text.ToString().Trim() + "',Brand_Name = '" + txt_BrandName.Text.ToString().Trim() + "' where Company_ID =  " + cid;
                bool res = new CommonUtil().InserUpdateQuery(strinsert);
                Response.Redirect("Company_Setting_List.aspx");
            }
        }
    }
}