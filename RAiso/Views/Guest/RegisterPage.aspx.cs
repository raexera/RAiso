using RAiso.Controller;
using System;

namespace RAiso.Views.Guest
{
    public partial class RegisterPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] != null || Request.Cookies["userCookie"] != null)
            {
                Response.Redirect("~/Views/HomePage.aspx");
            }
        }

        protected void registerBtn_Click(object sender, EventArgs e)
        {
            String name = nameTxt.Text;
            String dob = dobTxt.Text;
            String gender = (male.Checked) ? "Male" : (female.Checked) ? "Female" : "";
            String address = addressTxt.Text;
            String password = passwordTxt.Text;
            String phone = phoneTxt.Text;

            registerError.Text = UserController.ValidateRegister(name, dob, gender, address, password, phone);
            if (registerError.Text.Equals("Success"))
            {
                UserController.InsertUser(name, DateTime.Parse(dob), gender, address, password, phone);
                Response.Redirect("~/Views/HomePage.aspx");
            }
        }
    }
}