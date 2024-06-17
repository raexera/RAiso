using RAiso.Controller;
using RAiso.Model;
using System;
using System.Web;

namespace RAiso.Views.Guest
{
    public partial class LoginPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null || Request.Cookies["userCookie"] != null)
            {
                Response.Redirect("~/Views/HomePage.aspx");
            }
        }

        protected void loginBtn_Click(object sender, EventArgs e)
        {
            String name = nameTxt.Text;
            String password = passwordTxt.Text;

            loginError.Text = UserController.ValidateLogin(name, password);
            if (loginError.Text.Equals("Success"))
            {
                MsUser u = UserController.GetUserByName(name);
                Session["user"] = u.UserId;
                if (rememberCB.Checked)
                {
                    HttpCookie cookie = new HttpCookie("userCookie");
                    cookie.Value = u.UserId.ToString();
                    cookie.Expires = DateTime.Now.AddHours(1);

                    Response.Cookies.Add(cookie);
                }
                Response.Redirect("~/Views/HomePage.aspx");
            }
        }
    }
}