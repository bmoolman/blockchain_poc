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
            ITransactionRepository myRepo = new MockTransactionRepository();
            var transactionList = myRepo.GetBCTransactions();
            var rootDir = Directory.GetCurrentDirectory();

            BCTransactionProvider bc = new BCTransactionProvider();

            using (StreamWriter sw = new StreamWriter($@"{rootDir}\blockchain.csv"))
            {
                sw.WriteLine("Transaction Id;Transaction Previous Id;Owner Id;Date Created;Transaction amount;Balance;Hash;HashCrypto;IsValid");
                BCTransaction prevItem = null;
                foreach (var item in transactionList)
                {
                    bool isValid = true;
                    if (prevItem != null)
                    {
                        isValid = bc.IsValid(prevItem, item);
                    }
                    sw.WriteLine($"{item.TransactionId};{item.TransactionPreviousId};{item.OwnerId};{item.DateCreated};{item.Amount};{item.Balance};'{item.TransactionHashSimple}';{item.TransactionHashCrypto};{isValid}");

                    prevItem = item;
                }
            }


            bool startTamper = false;
            // Test is validity of the transaction
            foreach (var item in transactionList)
            {

                if (item.TransactionId == "11")
                {
                    item.Amount += 180;
                    startTamper = true;
                }

                if (startTamper == true)
                {
                    item.Balance += 180;
                }
            }

            using (StreamWriter sw = new StreamWriter($@"{rootDir}\blockchain_tampered.csv"))
            {
                sw.WriteLine("Transaction Id;Transaction Previous Id;Owner Id;Date Created;Transaction amount;Balance;Hash;HashCrypto;IsValid");
                BCTransaction prevItem = null;
                foreach (var item in transactionList)
                {
                    bool isValid = true;
                    if (prevItem != null)
                    {
                        isValid = bc.IsValid(prevItem, item);
                    }
                    sw.WriteLine($"{item.TransactionId};{item.TransactionPreviousId};{item.OwnerId};{item.DateCreated};{item.Amount};{item.Balance};'{item.TransactionHashSimple}';{item.TransactionHashCrypto};{isValid}");

                    prevItem = item;
                }
            }

            //foreach (var item in transactionList)
            //{
            //    Console.WriteLine($"Transaction Id: {item.TransactionId}");
            //    Console.WriteLine($"Transaction Previous Id: {item.TransactionPreviousId}");
            //    Console.WriteLine($"Owner Id: {item.OwnerId}");
            //    Console.WriteLine($"Date Created: {item.DateCreated}");
            //    Console.WriteLine($"Transaction amount: {item.Amount}");

            //    if (item.Balance < 0)
            //    {
            //        Console.ForegroundColor = ConsoleColor.Red;
            //    }

            //    Console.WriteLine($"Balance: {item.Balance}");
            //    Console.ResetColor();


            //    Console.WriteLine($"Transaction Hash (simple): {item.TransactionHashSimple}");
            //    Console.WriteLine($"Transaction Hash (crypto): {item.TransactionHashCrypto}");
            //    Console.WriteLine("--------------------------------------------");
            //}
        }
    }
}
