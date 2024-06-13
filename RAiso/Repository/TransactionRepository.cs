using RAiso.Model;
using System.Collections.Generic;
using System.Linq;

namespace RAiso.Repository
{
    public class TransactionRepository
    {
        private readonly DatabaseEntities db;

        public TransactionRepository(DatabaseEntities databaseEntities)
        {
            db = databaseEntities;
        }

        public TransactionHeader GetLastTransaction()
        {
            return db.TransactionHeaders.ToList().LastOrDefault();
        }

        public void InsertTransactionHeader(TransactionHeader th)
        {
            db.TransactionHeaders.Add(th);
            db.SaveChanges();
        }

        public void InsertTransactionDetail(TransactionDetail td)
        {
            db.TransactionDetails.Add(td);
            db.SaveChanges();
        }

        public List<TransactionHeader> GetAllTh(int uID)
        {
            return db.TransactionHeaders.Where(th => th.UserID == uID).ToList();
        }

        public List<TransactionDetail> GetAllTd(int tID)
        {
            return db.TransactionDetails.Where(td => td.TransactionID == tID).ToList();
        }

        public TransactionDetail GetTd(int tID)
        {
            return db.TransactionDetails.FirstOrDefault(td => td.TransactionID == tID);
        }

        public TransactionHeader GetTh(int uID, int tID)
        {
            return db.TransactionHeaders.FirstOrDefault(th => th.UserID == uID && th.TransactionID == tID);
        }

        public List<TransactionDetail> GetTDByStationery(int id)
        {
            return db.TransactionDetails.Where(td => td.StationeryID == id).ToList();
        }

        public void DeleteTransactionHeader(int id)
        {
            TransactionHeader th = db.TransactionHeaders.Find(id);
            if (th != null)
            {
                db.TransactionHeaders.Remove(th);
                db.SaveChanges();
            }
        }

        public void DeleteTransactionDetail(TransactionDetail td)
        {
            db.TransactionDetails.Remove(td);
            db.SaveChanges();
            if (!FindTdById(td.TransactionID))
            {
                DeleteTransactionHeader(td.TransactionID);
            }
            db.SaveChanges();
        }

        public List<TransactionHeader> GetThReport()
        {
            return db.TransactionHeaders.ToList();
        }

        private bool FindTdById(int tID)
        {
            return db.TransactionDetails.Any(td => td.TransactionID == tID);
        }
    }
}
