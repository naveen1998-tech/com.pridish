using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.pridish.Common;

namespace com.pridish
{
    public partial class CashMemo_Payment_List : System.Web.UI.Page
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
            string str = " select o.Customer_Code,o.CashMemo_No,o.CashMemoPayment_Id as cid , SUM(CONVERT(int, p.Amount)) Amount from CashMemo_Payment o inner join CashMemoPayment_grv p on o.CashMemoPayment_Id =p.CashMemoPayment_Id group by o.CashMemoPayment_Id,p.CashMemoPayment_Id,o.Customer_Code,o.CashMemo_No ";



            System.Data.DataTable dts = new CommonUtil().GetData(str);
            grdCustomerList.DataSource = dts;
            grdCustomerList.DataBind();
        }
        protected void grdCustomer_command(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "RowEdit")
            {
                string test = e.CommandArgument.ToString();
                Response.Redirect("CashMemo_payment.aspx?track=Edit&id=" + test);
            }
            else if (e.CommandName == "RowView")
            {
                string[] name = new string[2];
                string test = e.CommandArgument.ToString();
                name = test.Split('*');

                Response.Redirect("CashMemo_payment.aspx?track=View&id=" + name[0] + "&name=" + name[1]);
            }
        }
    }
}