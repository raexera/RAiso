using RAiso.Controller;
using RAiso.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace RAiso.Views.Customer
{
    public partial class CartPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["user"] != null)
                {
                    String role = UserController.GetRole(Session["user"].ToString());
                    if (!role.Equals("Customer"))
                    {
                        Response.Redirect("~/Views/HomePage.aspx");
                    }
                }
                else
                {
                    Response.Redirect("~/Views/HomePage.aspx");
                }

                if (Request["sId"] != null)
                {
                    int sId = Convert.ToInt32(Request["sId"]);
                    int userId = Convert.ToInt32(Session["user"]);
                    RAiso.Model.Cart cart = CartController.GetCart(userId, sId);
                    CartController.RemoveCart(cart);
                    Response.Redirect("~/Views/Customer/CartPage.aspx");
                }

                BindCart();
                List<RAiso.Model.Cart> carts = CartController.GetCarts(Convert.ToInt32(Session["user"]));
                if (carts.Count == 0) checkoutBtn.Visible = false;
            }
        }

        private void BindCart()
        {
            List<RAiso.Model.Cart> carts = CartController.GetCarts(Convert.ToInt32(Session["user"]));

            List<dynamic> cartDetails = new List<dynamic>();
            foreach (var cart in carts)
            {
                MsStationery stationery = StationeryController.GetStationeryById(cart.StationeryID);
                cartDetails.Add(new
                {
                    StationeryName = stationery.StationeryName,
                    StationeryPrice = stationery.StationeryPrice,
                    Quantity = cart.Quantity,
                });
            }
            cartGV.DataSource = cartDetails;
            cartGV.DataBind();
        }

        protected void updateBtn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            string name = row.Cells[0].Text;

            int sId = StationeryController.GetIdByName(name);
            Response.Redirect($"~/Views/Customer/UpdateCartPage.aspx?sID={sId}");
        }

        protected void removeBtn_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            GridViewRow row = (GridViewRow)btn.NamingContainer;
            string name = row.Cells[0].Text;

            int sId = StationeryController.GetIdByName(name);
            int userId = Convert.ToInt32(Session["user"]);
            RAiso.Model.Cart cart = CartController.GetCart(userId, sId);

            CartController.RemoveCart(cart);
            BindCart();
        }

        protected void checkoutBtn_Click(object sender, EventArgs e)
        {
            List<RAiso.Model.Cart> carts = CartController.GetCarts(Convert.ToInt32(Session["user"]));
            CartController.Checkout(carts);
            foreach (var cart in carts)
            {
                CartController.RemoveCart(cart);
            }
            Response.Redirect("~/Views/HomePage.aspx");
        }
    }
}
