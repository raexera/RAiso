using RAiso.Model;
using System.Collections.Generic;
using System.Linq;

namespace RAiso.Repository
{
    public class CartRepository
    {
        private readonly DatabaseEntities db;

        public CartRepository(DatabaseEntities dbContext)
        {
            db = dbContext;
        }

        public List<Cart> GetAll(int uId)
        {
            return db.Carts.Where(c => c.UserID == uId).ToList();
        }

        public void AddToCart(Cart cart)
        {
            db.Carts.Add(cart);
            db.SaveChanges();
        }

        public Cart GetCart(int uId, int sId)
        {
            return db.Carts.FirstOrDefault(c => c.UserID == uId && c.StationeryID == sId);
        }

        public void UpdateCart(Cart cart, int qty)
        {
            cart.Quantity = qty;
            db.SaveChanges();
        }

        public void DeleteCart(Cart cart)
        {
            db.Carts.Remove(cart);
            db.SaveChanges();
        }

        public List<Cart> GetCartByStationery(int id)
        {
            return db.Carts.Where(c => c.StationeryID == id).ToList();
        }
    }
}
