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
    public partial class sinhvienedit : System.Web.UI.Page
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
        }

        protected void btt_edit_Click(object sender, EventArgs e)
        {
            string st_msv, st_ten, st_email, st_dt, st_dc, st_sql;
            string st_ngay, st_thang, st_nam, st_ns;
            byte by_cn, by_k, by_gt;



            st_msv = Request.QueryString["masv"].ToString();
            //st_msv = dll_masv.SelectedItem.Value;
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
                if (k == 0)
                {
                    lbl_tb.Text = "Lỗi: Không có sinh viên này trong CSDL!";
                    lbl_tb.Visible = true;

                }
                else
                {
                    int check;
                    st_sql = "UPDATE tbl_sinhvien SET Tensv = N'" + st_ten + "',Namsinh = '" + st_ns + "',Gioitinh = " + by_gt + ",Khoa = " + by_k + ",Chuyennganh = " + by_cn + ",Email = N'" + st_email + "',Dienthoai = " + st_dt + ",Diachi = N'" + st_dc + "' WHERE Masv=" + st_msv;
                    sqlcm = new SqlCommand(st_sql, cls_con.con);
                    check = sqlcm.ExecuteNonQuery();
                    if (check > 0)
                    {
                        Response.Redirect("~/dssinhvienView.aspx?menu=sv&type=edit");
                    }
                    else
                    {
                        lbl_tb.Text = "Lỗi: Sửa dữ liệu không thành công!";
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