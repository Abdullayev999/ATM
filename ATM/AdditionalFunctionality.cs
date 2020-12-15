using System;
using System.Collections.Generic;
using System.Threading;

namespace ATM
{
    public static class AdditionalFunctionality
    {
        public static void LoadingSuccessful()
        {
            for (int i = 0; i <= 100; i++)
            {
                Console.Write($"\rProgress: {i}%   ");
                Thread.Sleep(25);
            }

            Console.Write(" Done!          ");
            Console.ReadKey();
        }

        public static void LoadingError()
        {
            Random rand = new Random();
            for (int i = 0; i <= rand.Next(99); i++)
            {
                Console.Write($"\rProgress: {i}%   ");
                Thread.Sleep(25);
            }

            Console.Write("\aEror!          ");
            Console.ReadKey();
        }
        public static bool TransferMoney(List<User> list, string cardNumber, int index, decimal money)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i].TransferMoneyCard(cardNumber, index, money))
                {
                    return true;
                }
            }

            return false;
        }
    }
}