using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Net;
using System.IO;
using System.Web.Script.Serialization;
//using System.Net.HttpWebRequest;
//using System.Web.Http;

namespace Doanbaove
{
    public partial class loginfb : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string app_id = "594051934729967";
            string app_secret = "a2a509e2d3f8ee04fea1696432a48465";
            string redirectUri = @"https://localhost:44342/loginfb.aspx";
            string code = Request["code"];

            string requestUri = @"https://graph.facebook.com/oauth/access_token?client_id=" + app_id + "&redirect_uri=" + redirectUri + "&client_secret=" + app_secret + "&code=" + code;
           
 //"https://graph.facebook.com/v5.0/me?fields=id%2Cname%2Cfirst_name%2Clast_name%2Clocation%2Cbirthday&access_token=EAAIcSX6MNu8BAD67ZBqaFZAosw66LHPzmyooHmZCql1rcTtreetawbDdAd76kVhOHI1S41wJhG7E7QsIl4k2lvfQlB0FPHkGCyRWVIjf7PWWTe1N8XSj6ImoGsAuTToRpwXPjikhYA7tNnoeSO93L1ZCDYMjmzZB2lLFDZA5lS5vq5RKhaehvLZB4FIu93FwAsZD"
            string str = getResponseFromUrl(requestUri);
            //int index1 = str.IndexOf("&");
            //str = str.Remove(index1, str.Length - index1);
            string str1 = str.Substring(17, str.Length - 62);
            string accessToken = str1.Replace("access_token=", "");
            //lblAccessToken.Text = accessToken;

            requestUri = @"https://graph.facebook.com/v5.0/me?fields=id%2Cname%2Cfirst_name%2Clast_name%2Clocation%2Cbirthday&access_token=" + accessToken;

            string data = getResponseFromUrl(requestUri);

            var json = new JavaScriptSerializer();
            var user = json.Deserialize<User>(data);
            //Console.WriteLine(user.name);
            Session["loginsys1"] = user.name;
            Session["loginsys2"] = user.first_name;
            Session["loginsys3"] = user.last_name;
        }

        public string getResponseFromUrl(string url)
        {
            WebRequest wr = WebRequest.Create(url);
            WebResponse ws = wr.GetResponse();
            Stream st = ws.GetResponseStream();
            StreamReader sr = new StreamReader(st);
            string str = sr.ReadToEnd();
            return str;
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
    public class User
    {
        public Int64 id { get; set; }
        public string name { get; set; }
        public string first_name { get; set; }   
        public string last_name { get; set; }
        public string username { get; set; }
    }
}