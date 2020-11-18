using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using Doanbaove.AllClass;
using Facebook;
using System.Configuration;
using System.Security.Policy;

namespace Doanbaove
{
    public partial class loginView : System.Web.UI.Page
    {
        
        protected void Page_Load(object sender, EventArgs e)
        {

            txt_username.Focus();

        }
        public class login
        {
            Clsconnect cls_con;
            public Boolean checkaccount(string username, string password)
            {
                Clsconnect cls_con = new Clsconnect();
                bool check = true;
                string query = "SELECT COUNT(*) FROM tbl_account where username='" + username + "' and password='" + password + "' ";
                cls_con.connect_Data();
                SqlCommand cmd = new SqlCommand(query, cls_con.con);
                int check1 = (int)cmd.ExecuteScalar();
                if (check1 == 0) check = false;
                cls_con.close_Data();
                return check;
            }
            public login()
            {
                cls_con = new Clsconnect();

            }
        }
        //private Uri RedirectUri
        //{
        //    get
        //    {
        //        var uriBuilder = new UriBuilder(Request.Url);
        //        uriBuilder.Query = null;
        //        uriBuilder.Fragment = null;
        //        uriBuilder.Path = Url.Action("FacebookCallBack");
        //        return uriBuilder.Uri;
        //    }
        //}
        //public class loginfacebook
        //{
        //    public loginfacebook()
        //    {
        //        var fb = new FacebookClient();
        //        var loginurl = fb.GetLoginUrl(new
        //        {
        //            client_id = ConfigurationManager.AppSettings["FbAppId"],
        //            client_secret = ConfigurationManager.AppSettings["FbAccessKey"],
        //            redirect_uri = RedirectUri.AbsoluteUri,
        //            response_type = "code",
        //            scope = "email",
        //        });

        //        return Redirect(loginurl.AbsoluteUri);
        //    }
        //}
        protected void btn_login_Click(object sender, EventArgs e)
        {
            login lg = new login();
            string st_ten, st_pass;
            st_ten = txt_username.Text.Trim();
            st_pass = txt_password.Text.Trim();

            if (lg.checkaccount(txt_username.Text, txt_password.Text))
            {
                Session["loginsys"] = st_ten;
                Response.Redirect("~/home.aspx?menu=home");
            }
            else
            {
                lbl_tb.Text = "Tài khoản hoặc mật khẩu sai";
                lbl_tb.Visible = true;
            }
        }

        protected void btt_add_Click(object sender, EventArgs e)
        {
            Clsconnect cls_con = new Clsconnect();
            SqlCommand sqlcm = new SqlCommand();
            string st_user, st_pass,st_sql;
            st_user = tbx_creatuser.Text;
            st_pass = tbx_creatpass.Text;
            try
            {
                cls_con.connect_Data();
                st_sql = "SELECT count(username) FROM tbl_account WHERE username='" + st_user + "'";
                sqlcm = new SqlCommand(st_sql, cls_con.con);
                int k = Convert.ToInt16(sqlcm.ExecuteScalar());
                if (k > 0)
                {
                    lbl_tb.Text = "Lỗi: Tên đăng nhập đã tồn tại trong CSDL!";
                    lbl_tb.Visible = true;

                }
                else
                {

                    int check;
                    st_sql = "INSERT INTO tbl_account (username,password) VALUES('" + st_user + "',N'" + st_pass + "');";
                    sqlcm = new SqlCommand(st_sql, cls_con.con);
                    check = sqlcm.ExecuteNonQuery();
                    if (check > 0)
                    {
                        lbl_tb.Text = "Lỗi: Thêm mới tài khoản thành công!";
                        Response.Redirect("~/loginView.aspx");
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

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            tbx_creatpass.Visible = true;
            tbx_creatuser.Visible = true;
            lbl_tb1.Visible = true;
            btt_add.Visible = true;
        }
    }
}