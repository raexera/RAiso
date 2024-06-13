using RAiso.Model;

namespace RAiso.Factory
{
    public class TransactionDetailFactory
    {
        public static TransactionDetail CreateTransactionDetail(int tId, int sId, int qty)
        {
            TransactionDetail td = new TransactionDetail
            {
                TransactionID = tId,
                StationeryID = sId,
                Quantity = qty,
            };

            return td;
        }
    }
}