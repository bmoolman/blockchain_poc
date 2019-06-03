using blockchain_poc.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace blockchain_poc
{
    class Program
    {
       
        static void Main(string[] args)
        {
            ITransactionRepository myRepo = new MockTransactionRepository(50);
            var transactionList = myRepo.GetBCTransactions();
            var rootDir = Directory.GetCurrentDirectory();
            var fileName = $"{rootDir}/blockchain.csv";

            PersistenceManager pm = new PersistenceManager();
            pm.SaveToFile(transactionList, fileName);
            
            BlockChainTamperer.TamperWithBlockChain(transactionList, "48", 150);
            
            fileName = $"{rootDir}/blockchain_tampered.csv";
            pm.SaveToFile(transactionList, fileName);

            pm.DebugToConsole(transactionList);

        }
    }
}
