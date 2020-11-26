using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace com.pridish.Common
{


    public class CommonUtil
    {
        static string cs = ConfigurationManager.ConnectionStrings["ERPConnectionString"].ToString();
        SqlConnection cn = new SqlConnection(cs);

        SqlDataAdapter da = new SqlDataAdapter();
        SqlCommand co = new SqlCommand();

        public DataTable GetData(string str)
        {
            DataTable dt = new DataTable();
            co.Connection = cn;
            if (cn.State != ConnectionState.Open)
                cn.Open();
            da.SelectCommand = new SqlCommand(str, cn);
            da.Fill(dt);
            cn.Close();
            return dt;
        }
        public void BindDDL(string str, DropDownList ddl, DataTable dt)
        {
            ddl.DataSource = dt;
            ddl.DataBind();
            ListItem lst = new ListItem(str, "0");
            ddl.Items.Add(lst);
            ddl.SelectedValue = "0";
        }

        public bool InserUpdateQuery(string str)
        {
            try
            {
                co.Connection = cn;
                co.CommandText = str;
                if (cn.State != ConnectionState.Open)
                    cn.Open();
                co.ExecuteNonQuery();
                cn.Close();
                return true;
            }
            catch (Exception e)
            {
                cn.Close();
                return false;
            }
        }
        public int InserQueryPK(string str)
        {
            try
            {
                co.Connection = cn;
                co.CommandText = str;
                if (cn.State != ConnectionState.Open)
                    cn.Open();
                object h = (int)co.ExecuteScalar();
                cn.Close();
                return 1;
            }
            catch (Exception e)
            {
                cn.Close();
                return 0;
            }
        }

    }
}