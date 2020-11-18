using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace Doanbaove
{
    public partial class trangchu : System.Web.UI.MasterPage
    {
        public string mn = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            mn = Request.QueryString.Get("menu");
            DateTime now = DateTime.Now;
            lbl_time.Text = now.ToShortTimeString();
            lbl_day.Text = now.Day.ToString();
            lbl_month.Text = now.Month.ToString();
            lbl_year.Text = now.Year.ToString();

            //if (Session["loginsys"] == null)
            //{
            //    Response.Redirect("~/loginView.aspx");

            //}
            //else
            //{
            //    lbl_login.Text = Session["loginsys"].ToString();
            //    lbl_user.Text = Session["loginsys"].ToString();
            //}

            if (Session["loginsys1"] != null && Session["loginsys2"] != null)
            {
                lbl_login.Text = Session["loginsys2"].ToString();
                lbl_user.Text = Session["loginsys1"].ToString();
            }
            else if (Session["loginsys1"] != null && Session["loginsys3"] != null)
            {
                lbl_login.Text = Session["loginsys3"].ToString();
                lbl_user.Text = Session["loginsys1"].ToString();
            }
            else if (Session["loginsys"] != null)
            {
                lbl_login.Text = Session["loginsys"].ToString();
                lbl_user.Text = Session["loginsys"].ToString();
            }
            else
            {
                Response.Redirect("~/loginView.aspx");
            }
        }
        protected void btn_logout_Click(object sender, EventArgs e)
        {
            Session["loginsys"] = null;
            Session["loginsys1"] = null;
            Session["loginsys2"] = null;
            Response.Redirect("~/loginView.aspx");
        }
    }
}