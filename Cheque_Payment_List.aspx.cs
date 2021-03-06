﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using com.pridish.Common;

namespace com.pridish
{
    public partial class Cheque_Payment_List : System.Web.UI.Page
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
            string str = " select o.Customer_Code,o.Invoice_No,o.Cheque_Id as cid , SUM(CONVERT(int, p.Amount)) Amount from Cheque_Payment o inner join Cheque_Payment_Grv p on o.Cheque_Id =p.Cheque_Id group by o.Cheque_Id,p.Cheque_Id,o.Customer_Code,o.Invoice_No ";



            System.Data.DataTable dts = new CommonUtil().GetData(str);
            grdCustomerList.DataSource = dts;
            grdCustomerList.DataBind();
        }
        protected void grdCustomer_command(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "RowEdit")
            {
                string test = e.CommandArgument.ToString();
                Response.Redirect("Cheque_Payment.aspx?track=Edit&id=" + test);
            }
            else if (e.CommandName == "RowView")
            {
                string[] name = new string[2];
                string test = e.CommandArgument.ToString();
                name = test.Split('*');

                Response.Redirect("Cheque_Payment.aspx?track=View&id=" + name[0] + "&name=" + name[1]);
            }
        }
    }
}