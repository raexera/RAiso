using RAiso.Controller;
using RAiso.Model;
using System;

namespace RAiso.Views.Admin
{
    public partial class UpdateStationeryPage : System.Web.UI.Page
    {
        static String nameFirst;
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
                if (Request["ID"] == null)
                {
                    Response.Redirect("~/Views/HomePage.aspx");
                }
                int id = Convert.ToInt32(Request["ID"]);
                MsStationery s = StationeryController.GetStationery(id);

                nameFirst = s.StationeryName;

                nameTxt.Text = s.StationeryName;
                priceTxt.Text = s.StationeryPrice.ToString();
            }
        }

        protected void updateBtn_Click(object sender, EventArgs e)
        {
            String name = nameTxt.Text;
            String price = priceTxt.Text;

            errorMsg.Text = StationeryController.ValidateInsert(name, price);
            if (errorMsg.Text.Equals("Success"))
            {
                StationeryController.UpdateStationery(name, Convert.ToInt32(price), nameFirst);
                Response.Redirect("~/Views/HomePage.aspx");
            }
        }
    }
}