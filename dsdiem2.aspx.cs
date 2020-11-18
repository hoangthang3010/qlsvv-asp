using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using Doanbaove.AllClass;
using System.Web.Services;

namespace Doanbaove
{
    public partial class dsdiem2 : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {
            diem ds = new diem();
            string st_msv = Request.QueryString.Get("user").ToString();
            Clsconnect cls_con = new Clsconnect();
            SqlCommand sqlcm, sqlcm1;
            SqlDataReader re;
            string check;
            check = Request.QueryString.Get("type");
            try
            {
                if (check == null)
                {
                    lbl_tb.Text = "";
                    lbl_tb.Visible = true;
                }
                else if (check.ToString() == "update")
                {
                    lbl_tb.Text = "Cập nhật điểm thành công";
                    lbl_tb.Visible = true;
                }
                cls_con.connect_Data();
                string query1 = "Select tensv, tbl_sinhvien.Masv, tencn,tenlop from tbl_sinhvien inner join tbl_chuyennganh on chuyennganh = macn inner join tbl_addlop on tbl_addlop.MaSv = tbl_sinhvien.Masv  inner join tbl_lop on tbl_addlop.Malop=tbl_lop.malop  where tbl_sinhvien.Masv=" + st_msv;
                string tensv = "", masv1 = "", cn = "",tenlop = "";
                sqlcm1 = new SqlCommand(query1, cls_con.con);
                SqlDataReader re1 = sqlcm1.ExecuteReader();
                while (re1.Read())
                {
                    tensv = re1.GetValue(0).ToString();
                    masv1 = re1.GetValue(1).ToString();
                    cn = re1.GetValue(2).ToString();
                    tenlop = re1.GetValue(3).ToString();
                }
                re1.Close();
                lbl_tensv.Text = tensv;
                lbl_masv.Text = masv1;
                lbl_cn.Text = cn;
                lbl_lop.Text = tenlop;

                string st_kq = "";
                string query = "SELECT tbl_addmonhoc.MaMH,TenMH,DiemC,DiemB,DiemA,TongKet,TinChi FROM dbo.tbl_diem INNER JOIN dbo.tbl_addmonhoc ON tbl_addmonhoc.MaDk = tbl_diem.MaDk INNER JOIN dbo.tbl_monhoc ON tbl_monhoc.MaMH = tbl_addmonhoc.MaMH WHERE dbo.tbl_diem.MaSv =" + st_msv;
                st_kq = "<table class='w3-table w3-striped w3-bordered w3-border w3-hoverable w3-white w3-card'>";
                st_kq = st_kq + "<tr class='w3-blue w3-center'><td><b>STT</b></td><td><b>Mã môn</b></td><td><b>Tên môn học</b></td><td><b>Tín chỉ</b></td><td><b>Điểm C</b></td><td><b>Điểm B</b></td><td><b>Điểm A</b></td><td><b>Tổng Kết(10)</b></td><td><b>Tổng Kết(CH)</b></td></tr>";
                sqlcm = new SqlCommand(query, cls_con.con);
                re = sqlcm.ExecuteReader();

                byte i = 0;
                while (re.Read())
                {
                    i++;
                    string temp = re.GetValue(5).ToString();
                    string tkch = "";
                    double tkso = double.Parse(temp);
                    if (tkso < 4.0) tkch = "F";
                    else
                        if (tkso <= 4.9) tkch = "D";
                    else
                        if (tkso <= 5.4) tkch = "D+";
                    else
                        if (tkso < 6.4) tkch = "C";
                    else
                        if (tkso < 6.9) tkch = "C+";
                    else
                        if (tkso < 7.9) tkch = "B";
                    else
                        if (tkso < 8.4) tkch = "B+";
                    else tkch = "A";
                    st_kq = st_kq + "  <tr><td>" + i.ToString() + "</td><td>" + re.GetValue(0).ToString() + "</td ><td>" + re.GetValue(1).ToString() + "</td ><td>" + re.GetValue(6).ToString() + "</td ><td>" + re.GetValue(2).ToString() + "</td ><td>" + re.GetValue(3).ToString() + "</td ><td>" + re.GetValue(4).ToString() + "</td ><td>" + re.GetValue(5).ToString() + "</td ><td>" + tkch + "</td ></tr > ";

                }
                re.Close();
                st_kq = st_kq + "</table>";
                dsach.Text = st_kq;

                
                
            }
            finally
            {
                cls_con.close_Data();
            }
            Label1.Text = ds.tongket(st_msv).ToString();
            Label2.Text = ds.tongket1(st_msv).ToString();
            Label3.Text = ds.tinchi(st_msv);

        }
        public class diem
        {

            Clsconnect cls_con = new Clsconnect();
            SqlCommand sqlcm;
            SqlDataReader re;
            public double tongket(string maSV)
            {
                try
                {
                    cls_con.connect_Data();
                    double dTB = 0;
                    int tinChi = 0;
                    string query = "SELECT TongKet,TinChi FROM dbo.tbl_diem INNER JOIN dbo.tbl_addmonhoc ON tbl_addmonhoc.MaDk = tbl_diem.MaDk INNER JOIN dbo.tbl_monhoc ON tbl_monhoc.MaMH = tbl_addmonhoc.MaMH WHERE tbl_diem.MaSv = " + maSV;

                    sqlcm = new SqlCommand(query, cls_con.con);
                    re = sqlcm.ExecuteReader();

                    while (re.Read())
                    {
                        string temp = re.GetValue(0).ToString();
                        double tkso = double.Parse(temp);

                        string temp1 = re.GetValue(1).ToString();
                        int tC = int.Parse(temp1);
                        dTB = dTB + (tkso * tC);
                        tinChi = tinChi + tC;
                    }
                    re.Close();
                    return Math.Round(dTB / (double)tinChi, 2);
                }
                finally
                {
                    cls_con.close_Data();
                }
            }
            public double tongket1(string maSV)
            {
                try
                {
                    cls_con.connect_Data();
                    double dTB = 0;
                    int tinChi = 0;
                    string query = "SELECT TongKet,TinChi FROM dbo.tbl_diem INNER JOIN dbo.tbl_addmonhoc ON tbl_addmonhoc.MaDk = tbl_diem.MaDk INNER JOIN dbo.tbl_monhoc ON tbl_monhoc.MaMH = tbl_addmonhoc.MaMH WHERE tbl_diem.MaSv = " + maSV;

                    sqlcm = new SqlCommand(query, cls_con.con);
                    re = sqlcm.ExecuteReader();
                    double tkch = 0;
                    while (re.Read())
                    {
                        string temp = re.GetValue(0).ToString();
                        double tkso = double.Parse(temp);

                        if (tkso <= 2.9) tkch = 0;
                        else
                            if (tkso <= 3.9) tkch = 0.5;
                        else
                            if (tkso <= 4.9) tkch = 1;
                        else
                            if (tkso <= 5.4) tkch = 1.5;
                        else
                            if (tkso <= 6.9) tkch = 2;
                        else
                            if (tkso <= 8.4) tkch = 3;
                        else tkch = 4;
                        string temp1 = re.GetValue(1).ToString();
                        int tC = int.Parse(temp1);
                        dTB = dTB + (tkch * tC);
                        tinChi = tinChi + tC;
                    }
                    re.Close();
                    return Math.Round(dTB / (double)tinChi, 2);
                }
                finally
                {
                    cls_con.close_Data();
                }
            }
            public string tinchi(string maSV)
            {
                try
                {
                    cls_con.connect_Data();
                    string query = "SELECT TongKet,TinChi FROM dbo.tbl_diem INNER JOIN dbo.tbl_addmonhoc ON tbl_addmonhoc.MaDk = tbl_diem.MaDk INNER JOIN dbo.tbl_monhoc ON tbl_monhoc.MaMH = tbl_addmonhoc.MaMH WHERE tbl_diem.MaSv = " + maSV;
                    int tC = 0;
                    int tC1 = 0;
                    string kq = "";

                    sqlcm = new SqlCommand(query, cls_con.con);
                    re = sqlcm.ExecuteReader();
                    while (re.Read())
                    {
                        string temp = re.GetValue(0).ToString();
                        double tkso = double.Parse(temp);
                        string temp1 = re.GetValue(1).ToString();
                        int tC2 = int.Parse(temp1);
                        if (tkso >= 4) tC = tC + tC2;
                        tC1 = tC1 + tC2;
                        kq = tC.ToString() + "/" + tC1.ToString();
                    }
                    re.Close();
                    return kq;
                }
                finally
                {
                    cls_con.close_Data();
                }
            }
        }
        protected void update_Click(object sender, EventArgs e)
        {
            SqlCommand sqlcm = new SqlCommand();
            string st_diema, st_diemb, st_diemc, st_mamon, st_sql;
            string st_msv = Request.QueryString.Get("user").ToString();
            Clsconnect cls_con = new Clsconnect();
            st_diema = tbx_diema.Text;
            st_diemb = tbx_diemb.Text;
            st_diemc = tbx_diemc.Text;
            st_mamon = tbx_mamon.Text;
            double tkso = 0.6 * double.Parse(st_diema) + 0.3 * double.Parse(st_diemb) + 0.1 * double.Parse(st_diemc);
            try
            {
                cls_con.connect_Data();
                st_sql = "SELECT count(mamh) FROM tbl_diem WHERE masv='" + st_msv + "'and mamh=" + st_mamon;
                sqlcm = new SqlCommand(st_sql, cls_con.con);
                int k = Convert.ToInt16(sqlcm.ExecuteScalar());
                if (k == 0)
                {
                    lbl_tb.Text = "Lỗi: Sinh viên không học môn này!";
                    lbl_tb.Visible = true;

                }
                else
                {

                    int check;
                    st_sql = "UPDATE dbo.tbl_diem SET DiemC = " + st_diemc + ", DiemB = " + st_diemb + " , DiemA = " + st_diema + " , TongKet = " + tkso + " WHERE masv='" + st_msv + "'and mamh=" + st_mamon;
                    sqlcm = new SqlCommand(st_sql, cls_con.con);
                    check = sqlcm.ExecuteNonQuery();
                    if (check > 0)
                    {
                        Response.Redirect("~/dsdiem2.aspx?user=" + st_msv + "&type=update");
                    }
                    else
                    {
                        lbl_tb.Text = "Lỗi: Sửa dữ liệu không thành công!";
                        lbl_tb.Visible = true;
                    }
                }

            }
            finally
            {
                cls_con.close_Data();
            }
        }
    }
}