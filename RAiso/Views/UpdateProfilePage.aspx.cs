using RAiso.Controller;
using RAiso.Model;
using System;

namespace RAiso.Views
{
    public partial class UpdateProfilePage : System.Web.UI.Page
    {
        static String nameFirst;
        static int Id;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["user"] == null && Request.Cookies["userCookie"] == null)
            {
                Response.Redirect("~/Views/HomePage.aspx");
            }
            else
            {
                if (!IsPostBack)
                {
                    String id = Session["user"].ToString();
                    MsUser u = UserController.GetUserById(id);

                    nameTxt.Text = u.UserName;
                    dobTxt.Text = u.UserDOB.ToString("yyyy-MM-dd");

                    if (u.UserGender.Equals("Male")) male.Checked = true;
                    else female.Checked = true;

                    addressTxt.Text = u.UserAddress;
                    passwordTxt.Attributes["value"] = u.UserPassword;
                    phoneTxt.Text = u.UserPhone;
                    nameFirst = u.UserName;
                    Id = u.UserId;
                }
            }
        }

        protected void updateBtn_Click(object sender, EventArgs e)
        {
            String name = nameTxt.Text;
            String dob = dobTxt.Text;
            String gender = (male.Checked) ? "Male" : (female.Checked) ? "Female" : "";
            String address = addressTxt.Text;
            String password = passwordTxt.Text;
            String phone = phoneTxt.Text;
            updateError.Text = UserController.ValidateUpdate(name, dob, gender, address, password, phone, nameFirst);
            if (updateError.Text.Equals("Success"))
            {
                UserController.UpdateUser(name, Convert.ToDateTime(dob), gender, address, password, phone, Id);
                updateError.Visible = false;
                updateSuccess.Visible = true;
            }
        }
    }
}