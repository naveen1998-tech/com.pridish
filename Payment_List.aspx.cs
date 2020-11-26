using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.pridish.Common;

namespace com.pridish
{
    public partial class Payment_List : System.Web.UI.Page
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
            string str = " select o.Customer_Code,o.Invoice_Code,o.Online_Pay_ID as cid , SUM(CONVERT(int, p.Amount)) Amount from Online_Payment o inner join Online_Payment_Grv p on o.Online_Pay_ID =p.Online_Pay_ID group by o.Online_Pay_ID,p.Online_Pay_ID,o.Customer_Code,o.Invoice_Code ";



            System.Data.DataTable dts = new CommonUtil().GetData(str);
            grdCustomerList.DataSource = dts;
            grdCustomerList.DataBind();
        }
        protected void grdCustomer_command(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "RowEdit")
            {
                string test = e.CommandArgument.ToString();
                Response.Redirect("Payments.aspx?track=Edit&id=" + test);
            }
            else if (e.CommandName == "RowView")
            {
                string[] name = new string[2];
                string test = e.CommandArgument.ToString();
                name = test.Split('*');

                Response.Redirect("Payments.aspx?track=View&id=" + name[0] + "&name=" + name[1]);
            }
        }
    }
}