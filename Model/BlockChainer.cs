using System;
using System.Collections.Generic;
using System.Text;

namespace blockchain_poc.Model
{
    public static class BlockChainer
    {
        public static (string,string) GetHashedValue (string transactionPreviousId, BCTransaction bcTransaction)
        {
            string transactionHashSimple = $"{transactionPreviousId}:{bcTransaction.TransactionId}";
            string transactionHashCrypto = $"NotImplemented";

            return (transactionHashSimple,transactionHashCrypto);
        }
    }
}
