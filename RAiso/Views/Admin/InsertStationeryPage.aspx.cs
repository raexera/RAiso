using RAiso.Controller;
using System;

namespace RAiso.Views.Admin
{
    public partial class InsertStationeryPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["user"] != null)
                {
                    String role = UserController.GetRole(Session["user"].ToString());
                    if (!role.Equals("Admin"))
                    {
                        Response.Redirect("~/Views/HomePage.aspx");
                    }
                }
                else
                {
                    Response.Redirect("~/Views/HomePage.aspx");
                }
            }
        }

        protected void insertBtn_Click(object sender, EventArgs e)
        {
            String name = nameTxt.Text;
            String price = priceTxt.Text;
            successMsg.Visible = false;

            errorMsg.Text = StationeryController.ValidateInsert(name, price);
            if (errorMsg.Text.Equals("Success"))
            {
                StationeryController.InsertStationery(name, Convert.ToInt32(price));
                errorMsg.Visible = false;
                successMsg.Visible = true;
                nameTxt.Text = "";
                priceTxt.Text = "";
            }
        }
    }
}