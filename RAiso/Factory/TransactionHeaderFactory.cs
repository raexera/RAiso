using RAiso.Model;
using System;

namespace RAiso.Factory
{
    public class TransactionHeaderFactory
    {
        public static TransactionHeader CreateTransactionHeader(int tId, int uId, DateTime date)
        {
            TransactionHeader th = new TransactionHeader
            {
                TransactionID = tId,
                UserID = uId,
                TransactionDate = date,
            };

            return th;
        }
    }
}