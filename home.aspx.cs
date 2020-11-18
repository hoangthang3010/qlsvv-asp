using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Doanbaove.AllClass;
using System.Data;
using System.Data.SqlClient;

namespace Doanbaove
{
    public partial class home : System.Web.UI.Page
    {
        Clsconnect cls_con = new Clsconnect();
        SqlCommand sqlm;
       
        string sql = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    cls_con.connect_Data();

                    sql = "select COUNT(masv) from tbl_sinhvien";
                    sqlm = new SqlCommand(sql, cls_con.con);
                    lbl_sumsinhvien.Text = sqlm.ExecuteScalar().ToString();

                  
                    sql = "select COUNT(magv) from tbl_giangvien";
                    sqlm = new SqlCommand(sql, cls_con.con);
                    lbl_sumgiangvien.Text = sqlm.ExecuteScalar().ToString();

                    sql = "select COUNT(malop) from Tbl_lop";
                    sqlm = new SqlCommand(sql, cls_con.con);
                    lbl_sumdoan.Text = sqlm.ExecuteScalar().ToString();

                    sql = "select COUNT(macn) from tbl_chuyennganh";
                    sqlm = new SqlCommand(sql, cls_con.con);
                    lbl_sumchuyennganh.Text = sqlm.ExecuteScalar().ToString();

                    //
                    SqlCommand sqlcm;
                    sql = "select count(masv) from tbl_sinhvien where chuyennganh=1";          
                    sqlcm = new SqlCommand(sql, cls_con.con);
                    float tinhocmo = Convert.ToInt16(sqlcm.ExecuteScalar());

                    sql = "select COUNT(masv) from tbl_sinhvien";
                    sqlcm = new SqlCommand(sql, cls_con.con);
                    float tongsinhvien = Convert.ToInt16(sqlcm.ExecuteScalar());

                    float tile = tinhocmo * 100 / tongsinhvien;
                    lbl_tinhocmo.Text = tile.ToString("n1") +"%";

                    // 
                    sql = "select count(masv) from tbl_sinhvien where chuyennganh=2";
                    sqlcm = new SqlCommand(sql, cls_con.con);
                    float thtd = Convert.ToInt16(sqlcm.ExecuteScalar());

                    float tile2 = thtd * 100 / tongsinhvien;
                    lbl_thtd.Text = tile2.ToString("n1") + "%";

                    //
                    sql = "select count(masv) from tbl_sinhvien where chuyennganh=3";
                    sqlcm = new SqlCommand(sql, cls_con.con);
                    float thkt = Convert.ToInt16(sqlcm.ExecuteScalar());

                    float tile3 = thkt * 100 / tongsinhvien;
                    lbl_thkt.Text = tile3.ToString("n1") + "%";

                    //
                    sql = "select count(masv) from tbl_sinhvien where chuyennganh=4";
                    sqlcm = new SqlCommand(sql, cls_con.con);
                    float thdc = Convert.ToInt16(sqlcm.ExecuteScalar());

                    float tile4 = thdc * 100 / tongsinhvien;
                    lbl_thdc.Text = tile4.ToString("n1") + "%";

                    //
                    sql = "select count(masv) from tbl_sinhvien where chuyennganh=5";
                    sqlcm = new SqlCommand(sql, cls_con.con);
                    float mmt = Convert.ToInt16(sqlcm.ExecuteScalar());

                    float tile5 = mmt * 100 / tongsinhvien;
                    lbl_mmt.Text = tile5.ToString("n1") + "%";

                    //
                    sql = "select count(masv) from tbl_sinhvien where chuyennganh=6";
                    sqlcm = new SqlCommand(sql, cls_con.con);
                    float cnpm = Convert.ToInt16(sqlcm.ExecuteScalar());

                    float tile6 = cnpm * 100 / tongsinhvien;
                    lbl_cnpm.Text = tile6.ToString("n1") + "%";

                    //
                    sql = "select count(masv) from tbl_sinhvien where chuyennganh=7";
                    sqlcm = new SqlCommand(sql, cls_con.con);
                    float khmt = Convert.ToInt16(sqlcm.ExecuteScalar());

                    float tile7 = khmt * 100 / tongsinhvien;
                    lbl_khmt.Text = tile7.ToString("n1") + "%";



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