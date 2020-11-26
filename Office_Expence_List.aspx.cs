using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.pridish.Common;

namespace com.pridish
{
    public partial class Office_Expence_List : System.Web.UI.Page
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
            string str = " select Expense_Type, Expense_Transaction_Details, Transaction_Date, Amount  from MST_Office_Expense";



            System.Data.DataTable dts = new CommonUtil().GetData(str);
            grdOfficeExpense.DataSource = dts;
            grdOfficeExpense.DataBind();
        }
    }
}