using System;
using System.Collections.Generic;
using System.Text;

namespace blockchain_poc.Model
{
    public interface ITransactionRepository
    {
        IEnumerable<BCTransaction> GetBCTransactions(); 
    }
}
