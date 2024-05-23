using RAiso.Handler;
using RAiso.Model;
using System;
using System.Collections.Generic;

namespace RAiso.Controller
{
    public class StationeryController
    {
        public static List<MsStationery> GetStationeries()
        {
            return StationeryHandler.GetStationeries();
        }

        public static MsStationery GetStationery(int id)
        {
            return StationeryHandler.GetStationery(id);
        }

        public static string ValidateAddToCart(string inp)
        {
            if (string.IsNullOrWhiteSpace(inp))
                return "Quantity must be filled";

            if (!int.TryParse(inp, out int quantity) || quantity <= 0)
                return "Quantity must be more than 0";

            return string.Empty;
        }

        public static string CheckName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return "Name must be filled";

            if (name.Length < 3 || name.Length > 50)
                return "Name must be between 3-50 characters";

            return string.Empty;
        }

        public static string CheckPrice(string price)
        {
            if (string.IsNullOrWhiteSpace(price))
                return "Price must be filled";

            if (!int.TryParse(price, out int priceValue) || priceValue < 2000)
                return "Price must be greater than or equal to 2000";

            return string.Empty;
        }

        public static string ValidateInsert(string name, string price)
        {
            string nameCheck = CheckName(name);
            if (!string.IsNullOrWhiteSpace(nameCheck))
                return nameCheck;

            string priceCheck = CheckPrice(price);
            if (!string.IsNullOrWhiteSpace(priceCheck))
                return priceCheck;

            return "Success";
        }

        public static void InsertStationery(string name, int price)
        {
            StationeryHandler.HandleInsert(name, price);
        }

        public static void UpdateStationery(string name, int price, string nameFirst)
        {
            StationeryHandler.HandleUpdate(name, price, nameFirst);
        }

        public static MsStationery GetStationeryById(int id)
        {
            return StationeryHandler.GetStationery(id);
        }

        public static int GetIdByName(string name)
        {
            return StationeryHandler.GetIdByName(name);
        }

        public static void DeleteStationery(int id)
        {
            StationeryHandler.HandleDelete(id);
        }
    }
}
