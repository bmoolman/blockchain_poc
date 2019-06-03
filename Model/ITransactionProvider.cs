using System;
using System.Collections.Generic;
using System.Text;

namespace blockchain_poc.Model
{
    public interface ITransactionProvider
    {
        BCTransaction AddTransaction(string transactionPreviousId, string transactionPreviousHashId,  string transactionId, string ownderId, DateTime dateCreated, decimal amount, decimal balance); 
    }


}
