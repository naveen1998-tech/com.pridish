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
    public partial class Add_Vendor : System.Web.UI.Page
    {
        int vid;
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
                    vid = int.Parse(Request.QueryString["id"].ToString());
                    FillPage(vid);
                }
            }
            else
            {
                if (Request.QueryString["track"] != null && Request.QueryString["track"] == "Edit")
                {
                    vid = int.Parse(Request.QueryString["id"].ToString());
                }
                else
                {
                    vid = 0;
                }
            }
        }


        protected void FillPage(int id)
        {
            //string str = "Select * from MST_Customer where Customer_ID  = " + id.ToString();
            string str = "select * from MST_Vendor v right join MST_Currency c on v.Vendor_Id = c.Currency_ID where Vendor_Id  = " + id.ToString();
            DataTable dts = new CommonUtil().GetData(str);
            if (dts.Rows.Count > 0)
            {


                txt_vendorCode.Text = dts.Rows[0]["Vendor_Code"].ToString();
                txt_companyName.Text = dts.Rows[0]["V_Company_Name"].ToString();
                txt_companyAddress.Text = dts.Rows[0]["V_Company_Address"].ToString();
                txt_contactPerson.Text = dts.Rows[0]["V_Contact_Person"].ToString();
                txt_mobile.Text = dts.Rows[0]["V_Mobile_Number"].ToString();
                txt_emailId.Text = dts.Rows[0]["V_Email_Id"].ToString();
                txt_address.Text = dts.Rows[0]["V_Notes"].ToString();
                txt_country.Text = dts.Rows[0]["V_Country"].ToString();
                txt_CreditTerms.Text = dts.Rows[0]["V_Credit_Terms"].ToString();
                ddl_currency.SelectedValue = dts.Rows[0]["V_Currency"].ToString();
                txt_creditLimit.Text = dts.Rows[0]["V_Credit_Limit"].ToString();


                txt_accountName.Text = dts.Rows[0]["B_Account_Name"].ToString();
                txt_accountNumber.Text = dts.Rows[0]["B_Account_Number"].ToString();
                txt_bankName.Text = dts.Rows[0]["B_Bank_Name"].ToString();
                txt_branchName.Text = dts.Rows[0]["B_Branch_Name"].ToString();
                txt_swiftCode.Text = dts.Rows[0]["B_Swift_Code"].ToString();
                txt_cityName.Text = dts.Rows[0]["B_City_Name"].ToString();
                txt_BankCounty.Text = dts.Rows[0]["B_Country"].ToString();
                txt_vendor.Text = dts.Rows[0]["B_Vendor"].ToString();
                ddl_accountCurrency.SelectedValue = dts.Rows[0]["B_Account_Currency"].ToString();

            }
        }

        public void DDlBound()
        {
            string str = "select Currency_ID as ID, Currency_Code as cc from MST_Currency";
            DataTable dts = new CommonUtil().GetData(str);
            new CommonUtil().BindDDL("Select Currency", ddl_currency, dts);
            new CommonUtil().BindDDL("Select Currency", ddl_accountCurrency, dts);

        }




        protected void btn_Save_Click(object sender, EventArgs e)
        {
            if (vid == 0)
            {
                string strinsert = @"insert into MST_Vendor(Vendor_Code, V_Company_Name, V_Company_Address , V_Contact_Person, V_Mobile_Number, V_Email_Id, V_Notes, V_Country, V_Currency, V_Credit_Terms, V_Credit_Limit, B_Account_Name, B_Account_Number, B_Bank_Name, B_Branch_Name, B_Swift_Code, B_City_Name, B_Country, B_Vendor, B_Account_Currency) 
                        values('" + txt_vendorCode.Text.ToString().Trim() + "','" + txt_companyName.Text.ToString().Trim() + "','" + txt_companyAddress.Text.ToString().Trim() + "','" + txt_contactPerson.Text.ToString().Trim() + "','" + txt_mobile.Text.ToString().Trim() + "','" + txt_emailId.Text.ToString().Trim() + "','" + txt_address.Text.ToString().Trim() + "','" + txt_country.Text.ToString().Trim() + "','" + ddl_currency.Text.ToString().Trim() + "', '" + txt_CreditTerms.Text.ToString().Trim() +
                                          "','" + txt_creditLimit.Text.ToString().Trim() + "', '" + txt_accountName.Text.ToString().Trim() + "','" + txt_accountNumber.Text.ToString().Trim() + "','" + txt_bankName.Text.ToString().Trim() + "','" + txt_branchName.Text.ToString().Trim() + "','" + txt_swiftCode.Text.ToString().Trim() + "','" + txt_cityName.Text.ToString().Trim() + "','" + txt_BankCounty.Text.ToString().Trim() + "','" + txt_vendor.Text.ToString().Trim() + "','" + ddl_accountCurrency.Text.ToString().Trim() + "')";
                bool res = new CommonUtil().InserUpdateQuery(strinsert);
                if (res)
                {
                    string message = "Your details have been saved successfully.";
                    string script = "window.onload = function(){ alert('";
                    script += message;
                    script += "')};";
                    Response.Redirect("Vendor_List.aspx");
                    ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);

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

                string strinsert = @"update MST_Vendor set Vendor_Code = '" + txt_vendorCode.Text.ToString().Trim() + "',V_Company_Name = '" + txt_companyName.Text.ToString().Trim() + "',V_Company_Address = '" + txt_companyAddress.Text.ToString().Trim() + "',V_Contact_Person = '" + txt_contactPerson.Text.ToString().Trim() + "',V_Mobile_Number = '" + txt_mobile.Text.ToString().Trim() + "',V_Email_Id = '" + txt_emailId.Text.ToString().Trim() + "',V_Notes ='" + txt_address.Text.ToString().Trim() + "',V_Country ='" + txt_country.Text.ToString().Trim() + "',V_Currency = '" + ddl_currency.Text.ToString().Trim() + "',V_Credit_Terms = '" + txt_CreditTerms.Text.ToString().Trim() +
                                          "',V_Credit_Limit = '" + txt_creditLimit.Text.ToString().Trim() + "',B_Account_Name = '" + txt_accountName.Text.ToString().Trim() + "',B_Account_Number = '" + txt_accountNumber.Text.ToString().Trim() + "',B_Bank_Name = '" + txt_bankName.Text.ToString().Trim() + "',B_Branch_Name = '" + txt_branchName.Text.ToString().Trim() + "',B_Swift_Code = '" + txt_swiftCode.Text.ToString().Trim() + "',B_City_Name = '" + txt_cityName.Text.ToString().Trim() + "',B_Country = '" + txt_BankCounty.Text.ToString().Trim() + "',B_Vendor = '" + txt_vendor.Text.ToString().Trim() + "',B_Account_Currency = '" + ddl_accountCurrency.Text.ToString().Trim() + "' where Vendor_Id =  "+vid;
                bool res = new CommonUtil().InserUpdateQuery(strinsert);
                Response.Redirect("Vendor_List.aspx");
            }
        }
    }
}