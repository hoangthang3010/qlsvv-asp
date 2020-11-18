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
    public partial class dsdiem : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public class diem
        {
            
            Clsconnect cls_con;
            public Boolean checkmsv(string masv)
            {
                bool check = true;
                string query = "SELECT COUNT(MaSv) FROM dbo.tbl_sinhvien WHERE Masv = " + masv;
                cls_con.connect_Data();
                SqlCommand cmd = new SqlCommand(query, cls_con.con);
                int check1 = (int)cmd.ExecuteScalar();
                if (check1 == 0) check = false;
                cls_con.close_Data();
                return check;
            }
            public diem()
            {
                cls_con = new Clsconnect();

            }
        }
        protected void Button1_Click(object sender, EventArgs e)
        {
            diem mh = new diem();

            if (mh.checkmsv(txt_masv.Text) == true)
            {
                string url = "~/dsdiem2.aspx?user=" + txt_masv.Text;
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