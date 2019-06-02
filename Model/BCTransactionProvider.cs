using System;
using System.Collections.Generic;
using System.Text;

namespace blockchain_poc.Model
{
    public class BCTransactionProvider : ITransactionProvider
    {   

        public BCTransaction AddTransaction(string transactionPreviousId, string transactionId, string ownderId, DateTime dateCreated, decimal amount, decimal balance)
        {
            BCTransaction bCTransaction = new BCTransaction()

            {
                TransactionPreviousId = transactionPreviousId,
                TransactionId = transactionId,
                OwnerId= ownderId,
                DateCreated = dateCreated,
                Amount = amount,
                Balance = balance + amount   

                
            };

            var transHashes = BlockChainer.GetHashedValue(transactionPreviousId, bCTransaction);
            bCTransaction.TransactionHashSimple = transHashes.Item1;
            bCTransaction.TransactionHashCrypto = transHashes.Item2;
            return bCTransaction;

        }
    }
}
