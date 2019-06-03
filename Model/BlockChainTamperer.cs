using System;
using System.Collections.Generic;
using System.Text;

namespace blockchain_poc.Model
{
    public static class BlockChainTamperer
    {           
        public static void TamperWithBlockChain (IEnumerable<BCTransaction> transactionList, string transactionIdToTamperWith, decimal tamperAmount)
        {
            bool startTamper = false;

            // Test is validity of the transaction
            foreach (var item in transactionList)
            {

                if (item.TransactionId == transactionIdToTamperWith)
                {
                    item.Amount += tamperAmount;
                    item.TransactionHashCrypto = "NewTamperedCryptoHash";
                    startTamper = true;
                }

                if (startTamper == true)
                {
                    item.Balance += tamperAmount;
                    item.TransactionHashCrypto = "NewTamperedCryptoHash";
                }
            }
        }
    }
}
