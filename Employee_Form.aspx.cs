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
    public partial class Employee_Form : System.Web.UI.Page
    {
        int Eid;
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
                    Eid = int.Parse(Request.QueryString["id"].ToString());
                    FillPage(Eid);
                }
            }
            else
            {
                if (Request.QueryString["track"] != null && Request.QueryString["track"] == "Edit")
                {
                    Eid = int.Parse(Request.QueryString["id"].ToString());
                }
                else
                {
                    Eid = 0;
                }
            }


        }

        protected void FillPage(int id)
        {
            string str = "Select * from MST_Employee where Emp_Table_ID  = " + id.ToString();
            DataTable dts = new CommonUtil().GetData(str);
            if (dts.Rows.Count > 0)
            {


                txt_employeeId.Text = dts.Rows[0]["Employee_ID"].ToString();
                txt_empName.Text = dts.Rows[0]["Employee_Name"].ToString();

                txt_branchName.Text = dts.Rows[0]["Branch_Name"].ToString();
                txt_mobileNo.Text = dts.Rows[0]["Mobile_Number"].ToString();
                txt_joiningDate.Text = dts.Rows[0]["Joining_Date"].ToString();
                txt_address.Text = dts.Rows[0]["Address"].ToString();
                txt_Designation.Text = dts.Rows[0]["Designation"].ToString();
                txt_companyName.Text = dts.Rows[0]["Company_Name"].ToString();
                txt_emailId.Text = dts.Rows[0]["Email_ID"].ToString();








            }
        }



        protected void btn_Save_Click(object sender, EventArgs e)
        {
            if (Eid == 0)
            {
                string strinsert = @"insert into MST_Employee(Employee_Name,Company_Name,Branch_Name,Employee_ID, Joining_Date, Mobile_Number, Email_ID,Address, Designation ) values('" + txt_empName.Text.ToString().Trim() + "','" + txt_companyName.Text.ToString().Trim() + "','" + txt_branchName.Text.ToString().Trim() + "','" + txt_employeeId.Text.ToString().Trim() + "','" + txt_joiningDate.Text.ToString().Trim() + "','" + txt_mobileNo.Text.ToString().Trim() + "','" + txt_emailId.Text.ToString().Trim() + "','" + txt_address.Text.ToString().Trim() + "','" + txt_Designation.Text.ToString().Trim() + "')";
                bool res = new CommonUtil().InserUpdateQuery(strinsert);
                if (res)
                {
                    string message = "Your details have been saved successfully.";
                    string script = "window.onload = function(){ alert('";
                    script += message;
                    script += "')};";
                    ClientScript.RegisterStartupScript(this.GetType(), "SuccessMessage", script, true);
                    Response.Redirect("Employee_List.aspx");
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

                string strinsert = @"update MST_Employee set Employee_Name = '" + txt_empName.Text.ToString().Trim() + "',Company_Name = '" + txt_companyName.Text.ToString().Trim() + "',Branch_Name = '" + txt_branchName.Text.ToString().Trim() + "',Employee_ID = '" + txt_employeeId.Text.ToString().Trim() + "', Joining_Date = '" + txt_joiningDate.Text.ToString().Trim() + "',Mobile_Number = '" + txt_mobileNo.Text.ToString().Trim() + "',Email_ID = '" + txt_emailId.Text.ToString().Trim() + "',Address = '" + txt_address.Text.ToString().Trim() + "',Designation = '" + txt_Designation.Text.ToString().Trim() + "' where Emp_Table_ID =  "+Eid;
                bool res = new CommonUtil().InserUpdateQuery(strinsert);
                Response.Redirect("Employee_List.aspx");
            }

        }

    }
}