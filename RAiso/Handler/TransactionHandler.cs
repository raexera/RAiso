using RAiso.Factory;
using RAiso.Model;
using RAiso.Repository;
using System;
using System.Collections.Generic;

namespace RAiso.Handler
{
    public class TransactionHandler
    {
        public static List<TransactionHeader> GetAllTh(int uID)
        {
            return TransactionRepository.GetAllTh(uID);
        }

        public static TransactionHeader GetTh(int uID, int tID)
        {
            return TransactionRepository.GetTh(uID, tID);
        }

        public static List<TransactionDetail> GetAllTd(int tID)
        {
            return TransactionRepository.GetAllTd(tID);
        }

        public static List<TransactionHeader> GetThReport()
        {
            return TransactionRepository.GetThReport();
        }

        public static TransactionDetail GetTd(int tID)
        {
            return TransactionRepository.GetTd(tID);
        }

        public static void Checkout(List<Cart> carts)
        {
            TransactionHeader th = HandleCheckoutTh(carts[0].UserID);
            TransactionRepository.InsertTransactionHeader(th);

            foreach (Cart cart in carts)
            {
                TransactionDetail td = HandleCheckoutTd(th.TransactionID, cart.StationeryID, cart.Quantity);
                TransactionRepository.InsertTransactionDetail(td);
            }
        }

        public static int GetGrandTotal(int tID)
        {
            int total = 0;
            List<TransactionDetail> tds = TransactionRepository.GetAllTd(tID);

            foreach (TransactionDetail td in tds)
            {
                MsStationery s = StationeryRepository.FindStationery(td.StationeryID);
                total += GetSubTotal(s.StationeryPrice, td.Quantity);
            }

            return total;
        }

        public static int GetSubTotal(int price, int qty)
        {
            return price * qty;
        }

        private static TransactionHeader HandleCheckoutTh(int uID)
        {
            int transactionID = GenerateID();
            return TransactionHeaderFactory.CreateTransactionHeader(transactionID, uID, DateTime.Now);
        }

        private static TransactionDetail HandleCheckoutTd(int tID, int sID, int qty)
        {
            return TransactionDetailFactory.CreateTransactionDetail(tID, sID, qty);
        }

        private static int GenerateID()
        {
            TransactionHeader lastTransaction = TransactionRepository.GetLastTransaction();
            return lastTransaction == null ? 1 : lastTransaction.TransactionID + 1;
        }
    }
}
