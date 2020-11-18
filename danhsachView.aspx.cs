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
    public partial class danhsachView : System.Web.UI.Page
    {
        Clsconnect cls_con = new Clsconnect();
        SqlCommand sqlcm,sqlcm1;
        SqlDataAdapter da = new SqlDataAdapter();
        protected void Page_Load(object sender, EventArgs e)
        {
            string check;
            check = Request.QueryString.Get("type1");
            string st_type = Request.QueryString.Get("type").ToString();
            if (!IsPostBack)
            {
                cls_con.connect_Data();
                string st_kq, st_sql, st_mamh, st_sqltenmh, st_tenmh, st_sqltenlop, st_tenlop;
                if (st_type == "mh")
                {
                    //btt_search.Visible = true;
                    btt_add.Visible = true;
                    btt_del.Visible = true;
                    //tbx_del.Visible = true;
                    dll_masv.Visible = true;
                    lbl_tb.Visible = true;
                    lbl_ma.Visible = true;
                    //lbl_mdk.Visible = true;
                    lbl_sv.Visible = true;
                    //lbl_note1.Visible = true;

                    //lbl_note2.Visible = false;
                    lbl_msv.Visible = false;
                    lbl_lop.Visible = false;
                    dll_lop.Visible = false;
                    btt_add1.Visible = false;
                    btt_del1.Visible = false;
                    tbx_del1.Visible = false;

                    if (check == null)
                    {
                        lbl_tb.Text = "";
                        lbl_tb.Visible = true;
                    }
                    else if (check.ToString() == "delete")
                    {
                        lbl_tb.Text = "Xóa sinh viên thành công";
                        lbl_tb.Visible = true;
                    }
                    else if (check.ToString() == "add")
                    {

                        lbl_tb.Text = "Thêm sinh viên thành công";
                        lbl_tb.Visible = true;
                    }

                    st_mamh = Request.QueryString.Get("MaMH").ToString();
                    st_sqltenmh = "Select tenmh from tbl_monhoc where mamh=" + st_mamh;
                    st_tenmh = "Danh sách sinh viên theo môn học: ";
                    sqlcm1 = new SqlCommand(st_sqltenmh, cls_con.con);
                    SqlDataReader re1 = sqlcm1.ExecuteReader();
                    while (re1.Read())
                    {
                        st_tenmh = st_tenmh + re1.GetValue(0).ToString();
                    }
                    re1.Close();
                    lbl_tieude.Text = st_tenmh;

                    st_sql = "Select madk,tbl_sinhvien.masv, tensv, Case Gioitinh when 1 then N'Nữ' else N'Nam' end, Khoa, tenmh from tbl_sinhvien inner join tbl_addmonhoc on tbl_addmonhoc.MaSv = tbl_sinhvien.Masv  inner join tbl_monhoc on tbl_addmonhoc.MaMH=tbl_monhoc.MaMH Where tbl_monhoc.MaMH =" + st_mamh + " order by Khoa";               
                    st_kq = "<table class='w3-table w3-striped w3-bordered w3-border w3-hoverable w3-white w3-card'>";
                    st_kq = st_kq + "<tr class='w3-blue w3-center'><td><b>STT</b></td><td><b>Mã điều kiện</b></td><td><b>Mã sinh viên</b></td><td><b>Tên sinh viên</b></td><td><b>Giới tính</b></td><td><b>Khóa</b></td><td><b>Tên môn học</b></td></tr>";                    
                    sqlcm = new SqlCommand(st_sql, cls_con.con);
                    SqlDataReader re = sqlcm.ExecuteReader();
                    
                    
                    int dem = 0;
                    while (re.Read())
                    {
                        dem++;
                        st_kq = st_kq + "<tr><td>" + dem + "</td><td>" + re.GetValue(0).ToString() + "</td><td>" + re.GetValue(1).ToString() + "</td><td>" + re.GetValue(2).ToString() + "</td><td>" + re.GetValue(3).ToString() + "</td><td>" + re.GetValue(4).ToString() + "</td><td>" + re.GetValue(5).ToString() + "</td></tr>";
                        
                    }
                    re.Close();

                    st_kq = st_kq + "</table>";
                    
                    lit_kq.Text = st_kq;
                }
                else if (st_type == "lop")
                {
                    //btt_search.Visible = true;
                    btt_add1.Visible = true;
                    btt_del1.Visible = true;
                    tbx_del1.Visible = true;
                    lbl_tb.Visible = true;
                    lbl_ma.Visible = true;
                    dll_lop.Visible = true;
                    lbl_msv.Visible = true;
                    lbl_lop.Visible = true;
                    //lbl_note2.Visible = true;

                    //lbl_note1.Visible = false;
                    //lbl_mdk.Visible = false;
                    lbl_sv.Visible = false;
                    btt_add.Visible = false;
                    btt_del.Visible = false;
                    //tbx_del.Visible = false;
                    dll_masv.Visible = false;

                    if (check == null)
                    {
                        lbl_tb.Text = "";
                        lbl_tb.Visible = true;
                    }
                    else if (check.ToString() == "delete1")
                    {
                        lbl_tb.Text = "Xóa sinh viên thành công";
                        lbl_tb.Visible = true;
                    }
                    else if (check.ToString() == "add1")
                    {

                        lbl_tb.Text = "Thêm sinh viên thành công";
                        lbl_tb.Visible = true;
                    }

                    string st_malop = Request.QueryString.Get("malop").ToString();
                    //lbl_tieude.Text = "Danh sách sinh viên theo lớp: " + st_malop;
                    //SELECT malop, tenlop, diachi, tengv FROM tbl_lop inner join tbl_giangvien on tbl_lop.Magv = tbl_giangvien.magv
                    st_sqltenlop = "Select tenlop,diachi from tbl_lop inner join tbl_giangvien on tbl_lop.Magv = tbl_giangvien.magv where malop=" + st_malop;
                    st_tenlop = "Danh sách sinh viên theo lớp: ";
                    sqlcm1 = new SqlCommand(st_sqltenlop, cls_con.con);
                    SqlDataReader re1 = sqlcm1.ExecuteReader();
                    while (re1.Read())
                    {
                        st_tenlop = st_tenlop + re1.GetValue(0).ToString() + " - " + re1.GetValue(1).ToString();
                    }
                    re1.Close();
                    lbl_tieude.Text = st_tenlop;

                    st_sql = "Select tbl_sinhvien.masv, tensv, Case tbl_sinhvien.Gioitinh when 1 then N'Nữ' else N'Nam' end,khoa, tencn, tengv from tbl_sinhvien inner join tbl_addlop on tbl_addlop.MaSv = tbl_sinhvien.Masv  inner join tbl_lop on tbl_addlop.Malop=tbl_lop.malop inner join tbl_giangvien on tbl_lop.Magv = tbl_giangvien.Magv inner join tbl_chuyennganh on tbl_sinhvien.chuyennganh = tbl_chuyennganh.macn Where tbl_lop.Malop =" + st_malop + " order by Khoa";
                    st_kq = "<table class='w3-table w3-striped w3-bordered w3-border w3-hoverable w3-white w3-card'>";
                    st_kq = st_kq + "<tr class='w3-blue w3-center'><td><b>STT</b></td><td><b>Mã sinh viên</b></td><td><b>Tên sinh viên</b></td><td><b>Giới tính</b></td><td><b>Khóa</b></td><td><b>Chuyên ngành</b></td><td><b>Tên giảng viên</b></td></tr>";
                    sqlcm = new SqlCommand(st_sql, cls_con.con);
                    SqlDataReader re = sqlcm.ExecuteReader();


                    int dem = 0;
                    while (re.Read())
                    {
                        dem++;
                        st_kq = st_kq + "<tr><td>" + dem + "</td><td>" + re.GetValue(0).ToString() + "</td><td>" + re.GetValue(1).ToString() + "</td><td>" + re.GetValue(2).ToString() + "</td><td>" + re.GetValue(3).ToString() + "</td><td>" + re.GetValue(4).ToString() + "</td><td>" + re.GetValue(5).ToString() + "</td></tr>";

                    }
                    re.Close();

                    st_kq = st_kq + "</table>";

                    lit_kq.Text = st_kq;
                }
            }
        }
        protected void btt_add_Click(object sender, EventArgs e)
        {
            try
            {
                string st_msv, st_sql;
                int st_mdk = 0;
                st_msv = dll_masv.SelectedItem.Value;
                string st_mamh = Request.QueryString.Get("MaMH").ToString();
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
                        Response.Redirect("danhsachView.aspx?menu=mh&type=mh&MaMH=" + st_mamh + "&type1=add");
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
        protected void btt_del_Click(object sender, EventArgs e)
        {
            try
            {
                string st_msv, st_sql;
                st_msv = dll_masv.SelectedItem.Value;
                string st_mamh = Request.QueryString.Get("MaMH").ToString();
                cls_con.connect_Data();

                st_sql = "SELECT count(masv) FROM tbl_addmonhoc WHERE mamh='" + st_mamh + "' and masv ='" + st_msv + "'";
                sqlcm = new SqlCommand(st_sql, cls_con.con);
                int l = Convert.ToInt16(sqlcm.ExecuteScalar());
                if (l == 0)
                {
                    lbl_tb.Text = "Lỗi: Sinh viên không môn học này!";
                    lbl_tb.Visible = true;

                }
                else
                {

                    int check,check1;
                    st_sql = "delete from tbl_diem where mamh='" + st_mamh + "' and masv ='" + st_msv + "'";
                    sqlcm = new SqlCommand(st_sql, cls_con.con);
                    check = sqlcm.ExecuteNonQuery();
                    st_sql = "delete from tbl_addmonhoc where mamh='" + st_mamh + "' and masv ='" + st_msv + "'";
                    sqlcm = new SqlCommand(st_sql, cls_con.con);
                    check1 = sqlcm.ExecuteNonQuery();
                    if (check == 1 && check1 == 1)
                    {
                        Response.Redirect("danhsachView.aspx?menu=mh&type=mh&MaMH=" + st_mamh + "&type1=delete");
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
        protected void tbx_search_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btt_del1_Click(object sender, EventArgs e)
        {
            try
            {
                string st_sql, st_del1;
                st_del1 = tbx_del1.Text.ToUpper();
                string st_malop = Request.QueryString.Get("malop").ToString();
                cls_con.connect_Data();
                st_sql = "SELECT count(masv) FROM tbl_addlop WHERE masv='" + st_del1 + "'";
                sqlcm = new SqlCommand(st_sql, cls_con.con);
                int k = Convert.ToInt16(sqlcm.ExecuteScalar());
                if (k == 0)
                {
                    lbl_tb.Text = "Lỗi: Sinh viên không có trong lớp này!";
                    lbl_tb.Visible = true;

                }
                else
                {

                    int check;
                    st_sql = "delete from tbl_addlop where masv=" + st_del1;
                    sqlcm = new SqlCommand(st_sql, cls_con.con);
                    check = sqlcm.ExecuteNonQuery();
                    if (check == 1)
                    {
                        Response.Redirect("danhsachView.aspx?menu=lop&type=lop&Malop=" + st_malop + "&type1=delete1");
                        lbl_tb.Text = "Xóa sinh viên thành công!";
                        lbl_tb.Visible = true;
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

        protected void tbx_del1_TextChanged(object sender, EventArgs e)
        {
            
        }

        protected void btt_add1_Click(object sender, EventArgs e)
        {
            try
            {
                string st_msv, st_sql;
                st_msv = dll_lop.SelectedItem.Value;
                string st_malop = Request.QueryString.Get("malop").ToString();
                cls_con.connect_Data();
                st_sql = "SELECT count(masv) FROM tbl_addlop WHERE masv='" + st_msv + "'";
                sqlcm = new SqlCommand(st_sql, cls_con.con);
                int k = Convert.ToInt16(sqlcm.ExecuteScalar());
                if (k>0)
                {
                    lbl_tb.Text = "Lỗi: Sinh viên đã có lớp!";
                    lbl_tb.Visible = true;

                }
                else
                {

                    int check;
                    st_sql = "INSERT INTO tbl_addlop (Masv,malop) VALUES('" + st_msv + "','" + st_malop + "');";
                    sqlcm = new SqlCommand(st_sql, cls_con.con);
                    check = sqlcm.ExecuteNonQuery();
                    if (check > 0)
                    {
                        Response.Redirect("danhsachView.aspx?menu=lop&type=lop&Malop=" + st_malop + "&type1=add1");
                        //lbl_tb.Text = "Thêm sinh viên vào lớp thành công!";
                        //lbl_tb.Visible = true;
                    }
                    else
                    {
                        lbl_tb.Text = "Lỗi: Thêm sinh viên vào lớp không thành công!";
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