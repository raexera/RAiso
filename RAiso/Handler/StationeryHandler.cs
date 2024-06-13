using RAiso.Factory;
using RAiso.Model;
using RAiso.Repository;
using System;
using System.Collections.Generic;

namespace RAiso.Handler
{
    public class StationeryHandler
    {
        public static List<MsStationery> GetStationeries()
        {
            return StationeryRepository.GetAll();
        }

        public static int GetIdByName(String name)
        {
            MsStationery s = StationeryRepository.GetStationery(name);
            return s.StationeryID;
        }

        public static MsStationery GetStationery(int id)
        {
            return StationeryRepository.FindStationery(id);
        }

        public static void HandleInsert(String name, int price)
        {
            MsStationery s = StationeryFactory.CreateStationery(GenerateID(), name, price);
            StationeryRepository.InsertStationery(s);
        }

        public static void HandleDelete(int id)
        {
            MsStationery s = StationeryRepository.FindStationery(id);
            DeleteAssociatedRecords(id);
            StationeryRepository.DeleteStationery(s);
        }

        public static void HandleUpdate(String name, int price, String nameFirst)
        {
            MsStationery s = StationeryRepository.GetStationery(nameFirst);
            StationeryRepository.UpdateStationery(s, name, price);
        }

        private static void DeleteAssociatedRecords(int id)
        {
            List<Cart> carts = CartRepository.GetCartByStationery(id);
            foreach (Cart cart in carts)
            {
                CartRepository.DeleteCart(cart);
            }

            List<TransactionDetail> transactionDetails = TransactionRepository.GetTDByStationery(id);
            foreach (TransactionDetail td in transactionDetails)
            {
                TransactionRepository.DeleteTransactionDetail(td);
            }
        }

        private static int GenerateID()
        {
            int id = 0;
            MsStationery s = StationeryRepository.GetLastStationery();
            if (s == null)
            {
                id = 1;
            }
            else
            {
                id = s.StationeryID + 1;
            }
            return id;
        }
    }
}
