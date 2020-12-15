using System;
using System.IO;
using System.Text;
using System.Threading.Channels;

namespace ATM
{
    [Serializable]
    public class User
    {
        public string Name { get; set; }
        public string Surname { get;  set; }
        public Card Card { get; set; }
        public User(string name, string surname)
        {
            Card=new Card(surname);
            Name = name;
            Surname = surname;
        }
        
        public bool TransferMoneyCard(string number,int indexOperation, decimal money)
        {
            if (string.Equals(Card.Number, number))
            {
                         if (indexOperation == 1) Card.Money.AddAzn(money);
                    else if (indexOperation == 2) Card.Money.addDollar(money);
                    else if (indexOperation == 3) Card.Money.AddAvro(money);

                    return true;
            }
            return false;
        }

        public void GetSalary()  // random salary distribution
        {
            Random rand=new Random();
            int num;
            decimal money = 1000;
                num = rand.Next(0, 3);

                     if (num == 0) Card.Money.addDollar(money); // 1700 azn
                else if (num == 1) Card.Money.AddAvro(money);   // 2000 azn
            else if (num == 2) Card.Money.AddAzn(money);        // 1000 azn
        }
       
        public override string ToString()
        {
            return $" {Name} {Surname}";
        }
    }
}