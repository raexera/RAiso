using RAiso.Handler;
using RAiso.Model;
using System.Collections.Generic;
using System.Linq;

namespace RAiso.Repository
{
    public class CartRepository
    {
        private static DatabaseEntities db = DatabaseSingleton.GetInstance();

        public static List<Cart> GetAll(int uId)
        {
            return QueryCarts().Where(c => c.UserID == uId).ToList();
        }

        public static void AddToCart(Cart cart)
        {
            db.Carts.Add(cart);
            SaveChanges();
        }

        public static Cart GetCart(int uId, int sId)
        {
            return QueryCarts().FirstOrDefault(c => c.UserID == uId && c.StationeryID == sId);
        }

        public static void UpdateCart(Cart cart, int qty)
        {
            cart.Quantity = qty;
            SaveChanges();
        }

        public static void DeleteCart(Cart cart)
        {
            db.Carts.Remove(cart);
            SaveChanges();
        }

        public static List<Cart> GetCartByStationery(int id)
        {
            return QueryCarts().Where(c => c.StationeryID == id).ToList();
        }

        private static IQueryable<Cart> QueryCarts()
        {
            return db.Carts;
        }

        private static void SaveChanges()
        {
            db.SaveChanges();
        }
    }
}
