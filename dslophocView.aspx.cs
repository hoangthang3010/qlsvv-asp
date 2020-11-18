using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Doanbaove.AllClass;

namespace Doanbaove
{
    public partial class dslophoc : System.Web.UI.Page
    {
        Clsconnect cls_con = new Clsconnect();
        SqlCommand sqlcm;
        string st_sql = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    cls_con.connect_Data();
                    st_sql = "SELECT malop, tenlop,diachi, tengv FROM tbl_lop inner join tbl_giangvien on tbl_lop.Magv = tbl_giangvien.magv ORDER BY malop";

                    sqlcm = new SqlCommand(st_sql, cls_con.con);
                    SqlDataReader re = sqlcm.ExecuteReader();

                    string st_kq = "";
                    byte i = 0;
                    while (re.Read())
                    {
                        i++;
                        st_kq = st_kq + "  <tr><td>" + i.ToString() + "</td><td>" + re.GetValue(1).ToString() + "</td><td>" + re.GetValue(2).ToString() + "</td><td>" + re.GetValue(3).ToString() + "</td><td><span class=\"w3 - medium\"><a href=\"danhsachView.aspx?menu=lop&type=lop&Malop=" + re.GetValue(0).ToString() + " \"><i class=\"fa fa-search w3 - medium\"></i> Danh sách</a></span> </td> </tr > ";
                    }
                    re.Close();
                    ltr_sv_lop.Text = st_kq;
                }
                catch (SqlException ex)
                {
                    Response.Write(ex);
                }
                finally
                {
                    cls_con.close_Data();
                }
            }
        }
    }
}