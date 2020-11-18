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
    public partial class sinhvienadd : System.Web.UI.Page
    {
        Clsconnect cls_con = new Clsconnect();
        SqlCommand sqlcm = new SqlCommand();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DateTime now = DateTime.Now;
                for (int i = now.Year; i >= 1980; i--)
                {
                    ddlnam.Items.Add(new ListItem(i.ToString(), i.ToString()));
                }

                for (byte i = 1; i <= 31; i++)
                {
                    ddlngay.Items.Add(new ListItem(i.ToString(), i.ToString()));
                }

                for (byte i = 1; i <= 12; i++)
                {
                    ddlthang.Items.Add(new ListItem(i.ToString(), i.ToString()));
                }

            }
            tbx_masv.Focus();
        }

        protected void btt_add_Click(object sender, EventArgs e)
        {
            string st_msv, st_ten, st_email, st_dt, st_dc, st_sql;
            string st_ngay, st_thang, st_nam, st_ns;
            byte by_cn, by_k, by_gt;



            st_msv = tbx_masv.Text;
            st_ten = tbx_tensv.Text;
            st_ngay = ddlngay.Text;
            st_thang = ddlthang.Text;
            st_nam = ddlnam.Text;

            st_ns = st_nam + "-" + st_thang + "-" + st_ngay;

            st_email = tbx_email.Text;
            st_dt = tbx_dienthoai.Text;
            st_dc = tbx_diachi.Text;
            if (rbt_nam.Checked == true)
            {
                by_gt = 0;
            }
            else by_gt = 1;
            by_k = Convert.ToByte(dll_khoa.SelectedValue);
            by_cn = Convert.ToByte(dllchuyennganh.SelectedValue);

            try
            {
                cls_con.connect_Data();
                st_sql = "SELECT count(masv) FROM tbl_sinhvien WHERE masv='" + st_msv + "'";
                sqlcm = new SqlCommand(st_sql, cls_con.con);
                int k = Convert.ToInt16(sqlcm.ExecuteScalar());
                if (k > 0)
                {
                    lbl_tb.Text = "Lỗi: Mã sinh viên đã có trong CSDL!";
                    lbl_tb.Visible = true;

                }
                else
                {

                    int check;
                    st_sql = "INSERT INTO tbl_sinhvien (Masv,Tensv,Namsinh,Gioitinh,Khoa,Chuyennganh,Email,Dienthoai,Diachi) VALUES('" + st_msv + "',N'" + st_ten + "','" + st_ns + "'," + by_gt + "," + by_k + "," + by_cn + ",'" + st_email + "','" + st_dt + "',N'" + st_dc + "');";
                    sqlcm = new SqlCommand(st_sql, cls_con.con);
                    check = sqlcm.ExecuteNonQuery();
                    if (check > 0)
                    {
                        Response.Redirect("~/dssinhvienView.aspx?menu=sv&type=add");
                    }
                    else
                    {
                        lbl_tb.Text = "Lỗi: Thêm mới dữ liệu không thành công!";
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
    }
}