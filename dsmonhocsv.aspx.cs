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
    public partial class dsmonhocsv : System.Web.UI.Page
    {
        Clsconnect cls_con = new Clsconnect();
        SqlCommand sqlcm, sqlcm1;
        protected void Page_Load(object sender, EventArgs e)
        {
            string check;
            check = Request.QueryString.Get("type");
            string masv = Request.QueryString["user"].ToString();
            try
            {
                cls_con.connect_Data();
                string query1 = "Select tensv, masv, tencn from tbl_sinhvien inner join tbl_chuyennganh on chuyennganh = macn where masv=" + masv;
                string tensv = "", masv1 = "", cn = "";
                sqlcm1 = new SqlCommand(query1, cls_con.con);
                SqlDataReader re1 = sqlcm1.ExecuteReader();
                while (re1.Read())
                {
                    tensv = re1.GetValue(0).ToString();
                    masv1 = re1.GetValue(1).ToString();
                    cn = re1.GetValue(2).ToString();
                }
                re1.Close();
                lbl_tensv.Text = tensv;
                lbl_masv.Text = masv1;
                lbl_cn.Text = cn;

                if (check == null)
                {
                    lbl_tb.Text = "";
                    lbl_tb.Visible = true;
                }
                else if (check.ToString() == "delete")
                {
                    lbl_tb.Text = "Xóa môn học thành công";
                    lbl_tb.Visible = true;
                }
                else if (check.ToString() == "add")
                {
                    
                    lbl_tb.Text = "Thêm môn học thành công";
                    lbl_tb.Visible = true;
                }

                cls_con.connect_Data();
                string st_sql = "SELECT tbl_monhoc.MaMH, tenmh,tinchi FROM tbl_monhoc inner join tbl_addmonhoc on tbl_monhoc.mamh = tbl_addmonhoc.mamh inner join tbl_sinhvien on tbl_sinhvien.masv = tbl_addmonhoc.masv where tbl_sinhvien.masv=" + masv;

                sqlcm = new SqlCommand(st_sql, cls_con.con);
                SqlDataReader re = sqlcm.ExecuteReader();

                string st_kq = "";
                byte i = 0;
                while (re.Read())
                {
                    i++;
                    st_kq = st_kq + "  <tr><td>" + i.ToString() + "</td><td>" + re.GetValue(0).ToString() + "</td><td>" + re.GetValue(1).ToString() + "</td><td>" + re.GetValue(2).ToString() + "</td></tr > ";
                }
                re.Close();
                st_kq = st_kq + "</table>";
                dsach.Text = st_kq;

                
                
            }
            finally
            {
                cls_con.close_Data();
            }
        }

        protected void btt_del_Click(object sender, EventArgs e)
        {
            string masv = Request.QueryString["user"].ToString();
            try
            {
                string st_mmh, st_sql;
                st_mmh = tbx_mamh.Text.ToUpper();
                cls_con.connect_Data();
                st_sql = "SELECT count(mamh) FROM tbl_addmonhoc WHERE mamh='" + st_mmh + "' and masv=" + masv;
                sqlcm = new SqlCommand(st_sql, cls_con.con);
                int k = Convert.ToInt16(sqlcm.ExecuteScalar());
                if (k == 0)
                {
                    lbl_tb.Text = "Lỗi: Sinh viên không học môn này";
                    lbl_tb.Visible = true;

                }
                else
                {

                    int check, check1;
                    st_sql = "delete from tbl_diem where mamh=" + st_mmh + " and masv=" + masv;
                    sqlcm = new SqlCommand(st_sql, cls_con.con);
                    check = sqlcm.ExecuteNonQuery();
                    st_sql = "delete from tbl_addmonhoc where mamh=" + st_mmh + " and masv=" + masv;
                    sqlcm = new SqlCommand(st_sql, cls_con.con);
                    check1 = sqlcm.ExecuteNonQuery();
                    if (check == 1 && check1 == 1)
                    {
                        Response.Redirect("~/dsmonhocsv.aspx?user=" + masv + "&type=delete");
                        //lbl_tb.Text = "Xóa sinh viên thành công!";
                        //lbl_tb.Visible = true;
                    }
                    else
                    {
                        lbl_tb.Text = "Lỗi: Xóa sinh viên không thành công!";
                        lbl_tb.Visible = true;
                    }
                }
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

        protected void btt_add_Click(object sender, EventArgs e)
        {
            string st_msv = Request.QueryString["user"].ToString();
            try
            {
                string st_sql;
                int st_mdk = 0;
                string st_mamh = tbx_mamh.Text.ToUpper();
                cls_con.connect_Data();
                for (int i = 0; i < 10000; i++)
                {
                    st_sql = "SELECT count(madk) FROM tbl_addmonhoc WHERE madk='" + i + "'";
                    sqlcm = new SqlCommand(st_sql, cls_con.con);
                    int k = Convert.ToInt16(sqlcm.ExecuteScalar());
                    if (k == 0)
                    {
                        st_mdk = i;
                        break;
                    }
                }
                st_sql = "SELECT count(masv) FROM tbl_addmonhoc WHERE mamh='" + st_mamh + "' and masv ='" + st_msv + "'";
                sqlcm = new SqlCommand(st_sql, cls_con.con);
                int l = Convert.ToInt16(sqlcm.ExecuteScalar());
                if (l > 0)
                {
                    lbl_tb.Text = "Lỗi: Mã sinh viên đã có trong môn học này!";
                    lbl_tb.Visible = true;
                }
                else
                {

                    int check, check1;
                    st_sql = "INSERT INTO dbo.tbl_diem VALUES (" + st_mdk + ",'" + st_msv + "','" + st_mamh + "',0,0,0,0)";
                    sqlcm = new SqlCommand(st_sql, cls_con.con);
                    check1 = sqlcm.ExecuteNonQuery();
                    st_sql = "INSERT INTO tbl_addmonhoc (Masv,mamh, madk) VALUES('" + st_msv + "','" + st_mamh + "','" + st_mdk + "');";
                    sqlcm = new SqlCommand(st_sql, cls_con.con);
                    check = sqlcm.ExecuteNonQuery();
                    if (check > 0 && check1 > 0)
                    {
                        Response.Redirect("~/dsmonhocsv.aspx?user=" + st_msv + "&type=add");
                        //lbl_tb.Text = "Thêm sinh viên thành công!";
                        //lbl_tb.Visible = true;
                    }
                    else
                    {
                        lbl_tb.Text = "Lỗi: Thêm sinh viên vào môn học không thành công!";
                        lbl_tb.Visible = true;
                    }
                }
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
        protected void tbx_mamh_TextChanged(object sender, EventArgs e)
        {

        }

        protected void tbx_del_TextChanged(object sender, EventArgs e)
        {

        }
    }
}