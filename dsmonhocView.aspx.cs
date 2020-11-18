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
    public partial class dsmonhocView : System.Web.UI.Page
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
                    st_sql = "SELECT MaMH, tenmh,tinchi FROM tbl_monhoc ";

                    sqlcm = new SqlCommand(st_sql, cls_con.con);
                    SqlDataReader re = sqlcm.ExecuteReader();

                    string st_kq = "";
                    byte i = 0;
                    while (re.Read())
                    {
                        i++;
                        st_kq = st_kq + "  <tr><td>" + i.ToString() + "</td><td>" + re.GetValue(0).ToString() + "</td><td>" + re.GetValue(1).ToString() + "</td><td>" + re.GetValue(2).ToString() + "</td><td><span class=\"w3 - medium\"><a href=\"danhsachView.aspx?menu=mh&type=mh&MaMH=" + re.GetValue(0).ToString() + " \"><i class=\"fa fa-search w3 - medium\"></i> Danh sách</a></span> </td> </tr > ";
                    }
                    re.Close();
                    ltr_sv_mh.Text = st_kq;
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
        public class ktramasv
        {

            Clsconnect dataConnec;
            SqlCommand cmd;
            SqlDataReader re;
            public Boolean ktraMaSV(string maSV)
            {
                bool check = true;
                string query = "SELECT COUNT(MaSv) FROM dbo.tbl_sinhvien WHERE Masv = " + maSV;
                dataConnec.connect_Data();
                cmd = new SqlCommand(query, dataConnec.con);
                int check1 = (int)cmd.ExecuteScalar();
                if (check1 == 0) check = false;
                dataConnec.close_Data();
                return check;
            }
            public ktramasv()
            {
                dataConnec = new Clsconnect();

            }
        }
        protected void btt_ok_Click(object sender, EventArgs e)
        {
            ktramasv mh = new ktramasv();

            if (mh.ktraMaSV(txtMaSV.Text) == true)
            {
                string url = "~/dsmonhocsv.aspx?user=" + txtMaSV.Text;
                Response.Redirect(url);
            }
            else
            {
                Label1.Text = "Không có Mã sinh viên này";
                Label1.Visible = true;
            }
        }
    }
}