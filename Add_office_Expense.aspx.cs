using com.pridish.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Threading;

namespace com.pridish
{

    public partial class Add_office_Expense : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] == null)
            {
                Session.Abandon();
                Response.Redirect("Login.aspx");
            }

        }
        protected void btn_save_Click(object sender, EventArgs e)
        {
            string strinsert = @"insert into MST_Office_Expense(Expense_Type, Expense_Transaction_Details, Transaction_Date, Amount, Remark  ) 
                        values('" + txt_expenseType.Text.ToString().Trim() + "','" + txt_expenseTransaction.Text.ToString().Trim() + "','" + txt_transaction.Text.ToString().Trim() + "','" + txt_amount.Text.ToString().Trim() + "','" + txt_remarks.Text.ToString().Trim() + "')";
            bool res = new CommonUtil().InserUpdateQuery(strinsert);
            if (res)
            {
               
                string message = "Your details have been saved successfully.";
                string script = "window.onload = function(){ alert('";
                script += message;
                script += "')};";
                ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
                
                Response.Redirect("Office_Expence_List.aspx");
                
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
    }
}