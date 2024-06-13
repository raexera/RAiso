using RAiso.Handler;
using RAiso.Model;
using System.Collections.Generic;

namespace RAiso.Controller
{
    public class CartController
    {
        public static List<Cart> GetCarts(int uId)
        {
            return CartHandler.GetCarts(uId);
        }

        public static void AddToCart(int uId, int sId, int qty)
        {
            CartHandler.HandleAddToCart(uId, sId, qty);
        }

        public static Cart GetCart(int uId, int sId)
        {
            return CartHandler.GetCart(uId, sId);
        }

        public static void UpdateCart(Cart cart, int qty)
        {
            CartHandler.HandleUpdate(cart, qty);
        }

        public static void RemoveCart(Cart cart)
        {
            CartHandler.HandleDelete(cart);
        }

        public static void Checkout(List<Cart> carts)
        {
            TransactionHandler.Checkout(carts);
        }
    }
}
