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
    public partial class hososinhvienView : System.Web.UI.Page
    {
        Clsconnect cls_con = new Clsconnect();
        SqlCommand sqlcm = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();
        string st_sql = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            string check;
            check = Request.QueryString.Get("type");
            if (!IsPostBack)
            {
                try
                {
                    st_sql = "Select masv as 'Mã sinh viên', tensv as 'Tên sinh viên',Namsinh as 'Ngày sinh',Case Gioitinh when 1 then N'Nữ' else N'Nam' end as 'Giới tính', Khoa as 'Khóa', tencn as 'Chuyên ngành', Email, Dienthoai as 'Điện thoại', Diachi as 'Địa chỉ' from tbl_sinhvien inner join tbl_chuyennganh on Chuyennganh=macn order by Masv";
                    cls_con.connect_Data();
                    sqlcm.Connection = cls_con.con;
                    sqlcm.CommandText = st_sql;
                    sqlcm.CommandType = CommandType.Text;
                    da.SelectCommand = sqlcm;
                    da.Fill(dt);
                    GridView1.DataSource = dt;
                    GridView1.DataBind();
                    if (check.ToString() == "edit")
                    {
                        lbl_thongbao.Text = "Sửa thông tin sinh viên thành công";
                        lbl_thongbao.Visible = true;
                    }
                    else if (check.ToString() == "add")
                    {
                        lbl_thongbao.Text = "Thêm sinh viên thành công";
                        lbl_thongbao.Visible = true;
                    }
                    else
                    {
                        lbl_thongbao.Text = "";
                        lbl_thongbao.Visible = true;
                    }
                }
                catch { }
                finally
                {
                    cls_con.close_Data();
                }

            }

        }
        protected void load_sv(string st_gr)
        {

            sqlcm = new SqlCommand();
            try
            {
                cls_con.connect_Data();
                sqlcm.Connection = cls_con.con;
                sqlcm.CommandText = st_gr;
                sqlcm.CommandType = CommandType.Text;
                da.SelectCommand = sqlcm;
                da.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            catch { }
            finally
            {
                cls_con.close_Data();
            }
        }
        int stt = 1;
        public string get_stt()
        {
            return Convert.ToString(stt++);
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            int trang_thu = e.NewPageIndex;
            int so_dong = GridView1.PageSize;
            stt = trang_thu * so_dong + 1;

        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        protected void ddl_chuyennganh_SelectedIndexChanged(object sender, EventArgs e)
        {
            string st_cn;
            st_cn = ddl_chuyennganh.SelectedItem.Value;

            st_sql = "Select masv as 'Mã sinh viên', tensv as 'Tên sinh viên',Namsinh as 'Ngày sinh',Case Gioitinh when 1 then N'Nữ' else N'Nam' end as 'Giới tính', Khoa as 'Khóa', tencn as 'Chuyên ngành', Email, Dienthoai as 'Điện thoại', Diachi as 'Địa chỉ' ";
            st_sql = st_sql + "from tbl_sinhvien inner join tbl_chuyennganh on Chuyennganh=macn WHERE chuyennganh=" + st_cn + " ORDER BY masv;";
            load_sv(st_sql);

        }
        protected void btt_search_Click(object sender, EventArgs e)
        {
            string st_cn;
            st_cn = tbx_search.Text.ToUpper();

            st_sql = "Select masv as 'Mã sinh viên', tensv as 'Tên sinh viên',Namsinh as 'Ngày sinh',Case Gioitinh when 1 then N'Nữ' else N'Nam' end as 'Giới tính', Khoa as 'Khóa', tencn as 'Chuyên ngành', Email, Dienthoai as 'Điện thoại', Diachi as 'Địa chỉ' from tbl_sinhvien inner join tbl_chuyennganh on Chuyennganh=macn";
            st_sql = st_sql + "  WHERE masv Like '%" + st_cn + "%'  OR UPPER(tensv) LIKE N'%" + st_cn + "%' ORDER BY masv;";            
            load_sv(st_sql);

        }

        protected void ddl_khoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            string st_cn;
            st_cn = ddl_khoa.SelectedItem.Value;

            st_sql = "Select masv as 'Mã sinh viên', tensv as 'Tên sinh viên',Namsinh as 'Ngày sinh',Case Gioitinh when 1 then N'Nữ' else N'Nam' end as 'Giới tính', Khoa as 'Khóa', tencn as 'Chuyên ngành', Email, Dienthoai as 'Điện thoại', Diachi as 'Địa chỉ' from tbl_sinhvien inner join tbl_chuyennganh on Chuyennganh=macn WHERE khoa=" + st_cn + " ORDER BY masv;";
            load_sv(st_sql);
        }

        protected void btt_add_Click(object sender, EventArgs e)
        {

        }

        protected void btt_edit_Click(object sender, EventArgs e)
        {
            {
                string masv = tbx_del.Text.ToUpper();
                try
                {
                    string st_sql;
                    cls_con.connect_Data();
                    st_sql = "SELECT count(masv) FROM tbl_sinhvien where masv=" + masv;
                    sqlcm = new SqlCommand(st_sql, cls_con.con);
                    int k = Convert.ToInt16(sqlcm.ExecuteScalar());
                    if (k == 0)
                    {
                        lbl_thongbao.Text = "Lỗi: Không tồn tại mã sinh viên này";
                        lbl_thongbao.Visible = true;
                    }
                    else if (masv == null)
                    {
                        lbl_thongbao.Text = "Nhập vào mã sinh viên";
                        lbl_thongbao.Visible = true;
                    }
                    else
                    {
                        Response.Redirect("~/sinhvienedit.aspx?masv=" + masv);
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

        protected void btt_del_Click(object sender, EventArgs e)
        {
            string st_cn;
            st_cn =tbx_del.Text.ToUpper();
            st_sql = "delete from tbl_sinhvien where Masv =" + st_cn + "Select masv as 'Mã sinh viên', tensv as 'Tên sinh viên',Namsinh as 'Ngày sinh',Case Gioitinh when 1 then N'Nữ' else N'Nam' end as 'Giới tính', Khoa as 'Khóa', tencn as 'Chuyên ngành', Email, Dienthoai as 'Điện thoại', Diachi as 'Địa chỉ' from tbl_sinhvien inner join tbl_chuyennganh on Chuyennganh=macn order by Masv";
            load_sv(st_sql);
            lbl_thongbao.Text = "Xóa sinh viên thành công";
            lbl_thongbao.Visible = true;
        }
    }
}