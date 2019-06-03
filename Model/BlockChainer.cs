using blockchain_poc.Crypto;
using System;
using System.Collections.Generic;
using System.Text;

namespace blockchain_poc.Model
{
    public static class BlockChainer
    {
        public static (string,string) GetHashedValue (string transactionPreviousId,string transactionPreviousHashId, BCTransaction bcTransaction)
        {
            string transactionHashSimple = $"{transactionPreviousId}:{bcTransaction.TransactionId}";

            string data = transactionPreviousHashId + bcTransaction.TransactionId + bcTransaction.DateCreated.ToString("yyyyMMddHHmmss") + bcTransaction.Amount.ToString() + bcTransaction.OwnerId;

            string transactionHashCrypto = CryptoSha256.ComputeHash(data);
            return (transactionHashSimple,transactionHashCrypto);
        }
    }
}
