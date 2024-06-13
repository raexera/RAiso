using RAiso.Model;
using System.Collections.Generic;
using System.Linq;

namespace RAiso.Repository
{
    public class TransactionRepository
    {
        private static readonly DatabaseEntities db = DatabaseSingleton.GetInstance();

        public static TransactionHeader GetLastTransaction()
        {
            return db.TransactionHeaders.OrderByDescending(t => t.TransactionID).FirstOrDefault();
        }

        public static void InsertTransactionHeader(TransactionHeader th)
        {
            db.TransactionHeaders.Add(th);
            db.SaveChanges();
        }

        public static void InsertTransactionDetail(TransactionDetail td)
        {
            db.TransactionDetails.Add(td);
            db.SaveChanges();
        }

        public static List<TransactionHeader> GetAllTh(int uID)
        {
            return db.TransactionHeaders.Where(th => th.UserID == uID).ToList();
        }

        public static List<TransactionDetail> GetAllTd(int tID)
        {
            return db.TransactionDetails.Where(td => td.TransactionID == tID).ToList();
        }

        public static TransactionDetail GetTd(int tID)
        {
            return db.TransactionDetails.FirstOrDefault(td => td.TransactionID == tID);
        }

        public static TransactionHeader GetTh(int uID, int tID)
        {
            return db.TransactionHeaders.FirstOrDefault(th => th.UserID == uID && th.TransactionID == tID);
        }

        public static List<TransactionDetail> GetTDByStationery(int id)
        {
            return db.TransactionDetails.Where(td => td.StationeryID == id).ToList();
        }

        public static void DeleteTransactionHeader(int id)
        {
            TransactionHeader th = db.TransactionHeaders.Find(id);
            if (th != null)
            {
                db.TransactionHeaders.Remove(th);
                db.SaveChanges();
            }
        }

        public static void DeleteTransactionDetail(TransactionDetail td)
        {
            db.TransactionDetails.Remove(td);
            db.SaveChanges();

            if (!FindTdById(td.TransactionID))
            {
                DeleteTransactionHeader(td.TransactionID);
            }
        }

        public static List<TransactionHeader> GetThReport()
        {
            return db.TransactionHeaders.ToList();
        }

        private static bool FindTdById(int tID)
        {
            return db.TransactionDetails.Any(td => td.TransactionID == tID);
        }
    }
}
