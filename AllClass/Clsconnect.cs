using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Doanbaove.AllClass
{
    public class Clsconnect
    {
        //lấy chuối kết nối trong web.config
        public String s_con = WebConfigurationManager.ConnectionStrings["connec_DATN"].ToString();
        //khai báo biến sqlconnection
        public SqlConnection con;
        public void connect_Data()//thủ tục mở kết nối
        {
            //if (con == null)
                con = new SqlConnection(s_con);
            //if (con.State == ConnectionState.Closed)
                con.Open();
        }
        public void close_Data()//thủ thuật đóng kết nối
        {
            if (con != null)
            {
                con.Close();
                con.Dispose();
            }
        }
    }
}