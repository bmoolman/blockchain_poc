using System;
using System.Collections.Generic;
using System.Text;

namespace blockchain_poc.Model
{
    public class BCTransaction
    {
        public string TransactionId { get; set; }
        public string TransactionPreviousId { get; set; }
        public string OwnerId { get; set; }
        public DateTime DateCreated { get; set; }
        public decimal Amount { get; set; }
        //public decimal AmountPrevious { get; set; }
        public decimal Balance { get; set; }
        public string TransactionHashSimple { get; set; } = "Genesis";
        public string TransactionHashCrypto { get; set; } = "CryptoGenesis";
   
    }
}
