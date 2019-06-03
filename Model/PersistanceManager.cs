using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace blockchain_poc.Model
{
    public class PersistenceManager
    {
        public void SaveToFile(IEnumerable<BCTransaction> transactionList, string filename)
        {
            BCTransactionProvider bc = new BCTransactionProvider();
            BCTransaction prevItem = null;

            using (StreamWriter sw = new StreamWriter($@"{filename}"))
            {
                sw.WriteLine("Transaction Id;Transaction Previous Id;Owner Id;Date Created;Transaction amount;Balance;Hash;HashCrypto;IsValid");

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
        }

        public void DebugToConsole(IEnumerable<BCTransaction> transactionList)
        {
            BCTransactionProvider bc = new BCTransactionProvider();
            BCTransaction prevItem = null;
            foreach (var item in transactionList)
            {
                bool isValid = true;
                if (prevItem != null)
                {
                    isValid = bc.IsValid(prevItem, item);
                }

                if (isValid == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }

                Console.WriteLine($"Transaction Id: {item.TransactionId}");
                Console.WriteLine($"Transaction Previous Id: {item.TransactionPreviousId}");
                Console.WriteLine($"Owner Id: {item.OwnerId}");
                Console.WriteLine($"Date Created: {item.DateCreated}");
                Console.WriteLine($"Transaction amount: {item.Amount}");
                Console.WriteLine($"Balance: {item.Balance}"); Console.WriteLine($"Transaction Hash (simple): {item.TransactionHashSimple}");
                Console.WriteLine($"Transaction Hash (crypto): {item.TransactionHashCrypto}");
                Console.WriteLine("--------------------------------------------");
                Console.ResetColor();

                prevItem = item;
            }
        }
    }


}
