using System;
using System.Collections.Generic;
using System.Text;

namespace blockchain_poc.Model
{
    public class MockTransactionRepository : ITransactionRepository
    {
        private List<BCTransaction> _bcTransactions;

        public MockTransactionRepository()
        {
            if (_bcTransactions == null)
            {
                InitializeBCTransactions();
            }
        }

        private void InitializeBCTransactions()
        {

            _bcTransactions = new List<BCTransaction>();

            BCTransaction newBCTrans;
            BCTransactionProvider bctProvider;

            newBCTrans =
                new BCTransaction { TransactionId = "0", OwnerId = "ABC", TransactionPreviousId = "0", DateCreated = Convert.ToDateTime("2019-04-01 14:45"), Amount = 0 };

            _bcTransactions.Add(newBCTrans);
                                   

            //Create some mock transactions
            for (int i = 1; i < 5; i++)
            {
                bctProvider = new BCTransactionProvider();

                Random random = new Random();
                
                int randomNumber = random.Next(-500, 500);
                if (randomNumber==0)
                {
                    randomNumber = random.Next(10, 500);
                }

                newBCTrans = bctProvider.AddTransaction(newBCTrans.TransactionId, i.ToString(), "ABC", DateTime.Now, randomNumber, newBCTrans.Amount);
                _bcTransactions.Add(newBCTrans);
            }

        }

        public IEnumerable<BCTransaction> GetBCTransactions()
        {
            return _bcTransactions;
        }
    }
}
