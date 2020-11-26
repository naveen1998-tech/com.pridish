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


    public partial class Add_Product_Master : System.Web.UI.Page
    {
        int Pid;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Session.Abandon();
                Response.Redirect("Login.aspx");
            }

            if (!IsPostBack)
            {
                


                if (Request.QueryString["track"] != null && Request.QueryString["track"] == "Edit")
                {
                    Pid = int.Parse(Request.QueryString["id"].ToString());
                    FillPage(Pid);
                }
            }
            else
            {
                if (Request.QueryString["track"] != null && Request.QueryString["track"] == "Edit")
                {
                    Pid = int.Parse(Request.QueryString["id"].ToString());
                }
                else
                {
                    Pid = 0;
                }
            }

        }


        protected void FillPage(int id)
        {
            //string str = "Select * from MST_Customer where Customer_ID  = " + id.ToString();
            string str = "select * from MST_Product where Product_Id  = " + id.ToString();
            DataTable dts = new CommonUtil().GetData(str);
            if (dts.Rows.Count > 0)
            {


                txt_product_Code.Text = dts.Rows[0]["Product_Code"].ToString();
                product_group.Text = dts.Rows[0]["Product_Group"].ToString();
                txt_product_name.Text = dts.Rows[0]["Product_Name"].ToString();
                txt_product_size.Text = dts.Rows[0]["Product_Size"].ToString();
                txt_product_unit.Text = dts.Rows[0]["Product_Unit"].ToString();
                txt_product_purchase_price.Text = dts.Rows[0]["Product_Purchase_Price"].ToString();
                txt_product_selling_price.Text = dts.Rows[0]["Product_Selling_Price"].ToString();
                txt_HSN_code.Text = dts.Rows[0]["HSN_Code"].ToString();
                txt_Tax.Text = dts.Rows[0]["Tax"].ToString();
                txt_Warrenty.Text = dts.Rows[0]["Warrenty"].ToString();


               
                

            }
        }


        protected void btn_save_Click(object sender, EventArgs e)
        {
            if (Pid == 0)
            {
                string strinsert = @"insert into MST_Product(Product_Code, Product_Group, Product_Name , Product_Size, Product_Unit, Product_Purchase_Price, Product_Selling_Price, HSN_Code, Tax, Warrenty ) 
                        values('" + txt_product_Code.Text.ToString().Trim() + "','" + product_group.Text.ToString().Trim() + "','" + txt_product_name.Text.ToString().Trim() + "','" + txt_product_size.Text.ToString().Trim() +
                                          "','" + txt_product_unit.Text.ToString().Trim() + "','" + txt_product_purchase_price.Text.ToString().Trim() + "','" + txt_product_selling_price.Text.ToString().Trim() + "','" + txt_HSN_code.Text.ToString().Trim() + "','" + txt_Tax.Text.ToString().Trim() + "','" + txt_Warrenty.Text.ToString().Trim() + "')";
                bool res = new CommonUtil().InserUpdateQuery(strinsert);
                if (res)
                {
                    string message = "Your details have been saved successfully.";
                    string script = "window.onload = function(){ alert('";
                    script += message;
                    script += "')};";
                    ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);

                    Response.Redirect("Product_List.aspx");
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

                string strinsert = @"update MST_Product set Product_Group = '" + product_group.Text.ToString().Trim() + "',Product_Name= '" + txt_product_name.Text.ToString().Trim() + "',Product_Size='" + txt_product_size.Text.ToString().Trim() +
                    "',Product_Unit = '" + txt_product_unit.Text.ToString().Trim() + "',Product_Purchase_Price = '" + txt_product_purchase_price.Text.ToString().Trim() + "',Product_Selling_Price = '" + txt_product_selling_price.Text.ToString().Trim() + "',HSN_Code = '" + txt_HSN_code.Text.ToString().Trim() + "', Tax = '" + txt_Tax.Text.ToString().Trim() + "',Warrenty = '" + txt_Warrenty.Text.ToString().Trim() + "'";
                bool res = new CommonUtil().InserUpdateQuery(strinsert);
                Response.Redirect("Product_List.aspx");
            
            }
        }
    }
}