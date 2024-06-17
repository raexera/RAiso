using RAiso.Controller;
using RAiso.Model;
using System;

namespace RAiso.Views.Customer
{
    public partial class UpdateCartPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["user"] != null)
                {
                    String role = UserController.GetRole(Session["user"].ToString());
                    if (!role.Equals("Customer")) Response.Redirect("~/Views/HomePage.aspx");
                }
                else Response.Redirect("~/Views/HomePage.aspx");

                if (Request["sID"] == null) Response.Redirect("~/Views/HomePage.aspx");
                else
                {
                    int sId = Convert.ToInt32(Request["sID"]);
                    MsStationery s = StationeryController.GetStationery(sId);
                    Cart cart = CartController.GetCart(Convert.ToInt32(Session["user"]), sId);

                    if (cart == null) Response.Redirect("~/Views/Customer/CartPage.aspx");

                    nameTxt.Text = s.StationeryName;
                    priceTxt.Text = s.StationeryPrice.ToString();
                }
            }
        }

        protected void updateBtn_Click(object sender, EventArgs e)
        {
            successMsg.Visible = false;
            errorMsg.Text = StationeryController.ValidateAddToCart(quantityTxt.Text);
            if (errorMsg.Text.Equals(""))
            {
                Cart cart = CartController.GetCart(Convert.ToInt32(Session["user"]), Convert.ToInt32(Request["sID"]));
                CartController.UpdateCart(cart, Convert.ToInt32(quantityTxt.Text));
                successMsg.Visible = true;
                quantityTxt.Text = string.Empty;
            }
        }
    }
}