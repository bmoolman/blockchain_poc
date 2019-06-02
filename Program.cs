using blockchain_poc.Model;
using System;
using System.Collections.Generic;

namespace blockchain_poc
{
    class Program
    {
        static void Main(string[] args)
        {
            ITransactionRepository myRepo = new MockTransactionRepository();
            var transactionList = myRepo.GetBCTransactions();

            foreach (var item in transactionList)
            {
                Console.WriteLine($"Transaction Id: {item.TransactionId}");
                Console.WriteLine($"Transaction Previous Id: {item.TransactionPreviousId}");
                Console.WriteLine($"Owner Id: {item.OwnerId}");
                Console.WriteLine($"Date Created: {item.DateCreated}");
                Console.WriteLine($"Transaction amount: {item.Amount}");

                if (item.Balance < 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }

                Console.WriteLine($"Balance: {item.Balance}");
                Console.ResetColor();


                Console.WriteLine($"Transaction Hash (simple): {item.TransactionHashSimple}");
                Console.WriteLine($"Transaction Hash (crypto): {item.TransactionHashCrypto}");
                Console.WriteLine("--------------------------------------------");
            }
        }
    }
}
