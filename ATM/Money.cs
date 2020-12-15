using System;
using System.ComponentModel.Design;
using Microsoft.VisualBasic.FileIO;

namespace ATM
{
    [Serializable]
    public class Money
    {
        public static decimal DollarToManatKurs { get; set; } = 1.701m;
        public static decimal AvroToManatKurs { get; set; } = 2.01m;

        public decimal azn=0;

        public decimal Azn
        {
            get { return azn; }
            set
            {
                azn = value;
                // to round the value to 0,00
                azn = Math.Round(Azn, 2); 
            }
        }


        public void AddAzn(decimal manat)
        {
            Azn += manat;
        }

        public void AddAvro(decimal avro)
        {
            Azn += avro * AvroToManatKurs;
        }

        public void addDollar(decimal dollar)
        {
            Azn += (dollar * DollarToManatKurs);
        }
        public bool SubtractAzn(decimal manat)
        {
            if (Azn<manat) return false;
            Azn -= manat;
            return true;

        }
        public bool SubtractAvro(decimal avro)
        {
            if (Azn < (avro *= AvroToManatKurs)) return false;
            Azn -= avro;
            return true;

        }
        public bool SubtractDollar(decimal dollar)
        {
            if (Azn < (dollar*=DollarToManatKurs)) return false;
            Azn -= dollar;
            return true;
        }
        public override string ToString()
        {
            return $"{Azn} Azn ( {Math.Round(Azn / DollarToManatKurs, 2)} $ \\ {Math.Round(Azn / AvroToManatKurs, 2)} Avro )";
        }
    }
}