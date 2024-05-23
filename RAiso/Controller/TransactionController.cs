using RAiso.Handler;
using RAiso.Model;
using System.Collections.Generic;

namespace RAiso.Controller
{
    public class TransactionController
    {
        public static List<TransactionHeader> GetAllTh(int uID)
        {
            return TransactionHandler.GetAllTh(uID);
        }

        public static TransactionDetail GetTd(int tID)
        {
            return TransactionHandler.GetTd(tID);
        }

        public static TransactionHeader GetTh(int uID, int tID)
        {
            return TransactionHandler.GetTh(uID, tID);
        }

        public static List<TransactionDetail> GetAllTd(int tID)
        {
            return TransactionHandler.GetAllTd(tID);
        }

        public static List<TransactionHeader> GetThReport()
        {
            return TransactionHandler.GetThReport();
        }

        public static int GetSubTotal(int price, int qty)
        {
            return TransactionHandler.GetSubTotal(price, qty);
        }

        public static int GetGrandTotal(int tID)
        {
            return TransactionHandler.GetGrandTotal(tID);
        }
    }
}
