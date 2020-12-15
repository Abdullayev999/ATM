using System;
using System.Runtime.CompilerServices;
using System.Text;

namespace ATM
{
    [Serializable]
    public class Card
    {
        public string Own { get; set; }
        public string BankName { get; set; }
        public string Number { get; set; }
        public int Pin { get; set; }
        public string Data { get; set; }
        public Money Money { get; set; }
        public int Amount { get; set; }
        private void GenerationCardData()
        {
            Random rand = new Random();
            StringBuilder result = new StringBuilder();

            result.Append(rand.Next(1, 10));
            result.Append(@"\");
            result.Append(rand.Next(10, 31));

            Data = result.ToString();
        }
        private void GenerationCardNumber()
        {
            Random rand = new Random();
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < 16; i++)
            {
                result.Append(rand.Next(10));
            }
            Number = result.ToString();
        }
        private void GenerationCardPin()
        {
            Random rand = new Random();
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < 4; i++) result.Append(rand.Next(1,10));

            Pin = Int32.Parse(result.ToString());
        }
        private void GenerationCardAmount()
        {
            Random rand = new Random();
            StringBuilder result = new StringBuilder();

            for (int i = 0; i < 3; i++) result.Append(rand.Next(1, 10));

            Amount = Int32.Parse(result.ToString());
        }
        private void GenerationCardName()
        {
            int size = 10;
            string[] arr = new string[size];
            arr[0] = "Capital  Bank  "; arr[1] = "Pasha  Bank    "; arr[2] = "Bank  of  Baku ";
            arr[3] = "Demir  Bank    "; arr[4] = "Zamin  Bank    "; arr[5] = "Naxcivan  Bank ";
            arr[6] = "Mugam  Bank    "; arr[7] = "Access  Bank   "; arr[7] = "Beynalxalq Bank";
            arr[8] = "Ziraat  Bank   "; arr[8] = "Azer Turk Bank "; arr[9] = "Bank Respublika";

            Random rand = new Random();
            string result = arr[rand.Next(size)];

            BankName = result;
        }
        private void GenerationAll()  // random creation of a bank card
        {
            GenerationCardNumber();
            GenerationCardPin();
            GenerationCardName();
            GenerationCardData();
            GenerationCardAmount();
        }


        public Card(string cardOwn)
        {
            Money=new Money();
            Own = cardOwn;
            GenerationAll();
        }

        public override string ToString()
        {
            // for create frame
            StringBuilder tmp=new StringBuilder();
            tmp.Append(Own.ToUpper());
            int size = 20 - Own.Length;
            while (size--!=0) tmp.Append("*");
            string num = Number;

            num = num.Insert(4, " ");
            num = num.Insert(9, " ");
            num = num.Insert(14, " ");
            return $"  Pin : {Pin}\n  -----------------------------\n" +
                       $" |  {BankName}            |\n" +
                       $" |  {Data}                  ---- |\n" +
                       $" |  ###############{Amount}   |@@@@||\n" +
                       $" |                        ---- |\n" +
                       $" |  {num}        |\n" +
                       $" |  *******{tmp}|\n" +
                       $"  -----------------------------\n";
        }
    }
}