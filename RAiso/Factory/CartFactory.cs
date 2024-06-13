using RAiso.Model;

namespace RAiso.Factory
{
    public class CartFactory
    {
        public static Cart CreateCart(int uId, int sId, int qty)
        {
            Cart cart = new Cart
            {
                UserID = uId,
                StationeryID = sId,
                Quantity = qty
            };

            return cart;
        }
    }
}