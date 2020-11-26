using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.pridish.Common;

namespace com.pridish
{
    public partial class Employee_List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                SearchData();
            }
        }
        public void SearchData()
        {
            string str = " select Emp_Table_ID as Eid, isnull(Employee_ID,'') as Employee_ID, isnull(Employee_Name,'') as Employee_Name,isnull(Branch_Name,'') Branch_Name, isnull(Mobile_Number,'') Mobile_Number, isnull(Designation,'') as Designation  from MST_Employee where isnull(Active,1)=1 ";

            if (txt_Emp_Name.Text.ToString() != "")
            {
                str += " and Employee_Name like '%" + txt_Emp_Name.Text.ToString().Trim() + "%'";
            }


            System.Data.DataTable dts = new CommonUtil().GetData(str);
            grdCurrency.DataSource = dts;
            grdCurrency.DataBind();
        }
        protected void grdEmp_Commond(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "RowEdit")
            {
                string test = e.CommandArgument.ToString();
                Response.Redirect("Employee_Form.aspx?track=Edit&id=" + test);
            }
            else if (e.CommandName == "RowView")
            {
                string[] name = new string[2];
                string test = e.CommandArgument.ToString();
                name = test.Split('*');

                Response.Redirect("Employee_Form.aspx?track=View&id=" + name[0] + "&name=" + name[1]);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void txt_Emp_Name_TextChanged(object sender, EventArgs e)
        {

            SearchData();
        }
        
    }
}