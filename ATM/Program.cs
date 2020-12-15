using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading;


namespace ATM
{
    enum MainMenu
    {
        ATM = 1, BANK, EXIT
    }
    enum AtmMenu
    {
        EXIT, SUBTRACT, PUT_ON, SEND, PRINT_CARD, BACK
    }

    enum BankMenu
    {
        EXIT, ADD, DELETE, ALL_PRINT_WITH_CARD, UPLOAD_SALARY, PRINT_ALL_CLIENT, PRINT_CARD, BACK
    }
    class Program
    {
        static void Main(string[] args)
        {
            int frequency = 1000,   // for sound
                 duration = 600,    // for sound
                 userIndex = 0,     // for enter in ATM , ( index of array )
                 action,            // to make a choice
                 count;             // for size Card number

          string name,              // for registration User
                 surname;           // for registration User

         decimal money;             // for Send,Put,Subtract money
            bool data,              // chek data
                 salary;            // check for salary

            StringBuilder number,   // for enter card number
                           pass;    // for enter card password

            List<User> list = new List<User>();
            User tmp;

            MainMenu main_action;
            AtmMenu atm_action;
            BankMenu bank_action;

            try
            {
                using (FileStream fs = new FileStream("people.bin", FileMode.Open))
                {
                    BinaryFormatter binaryFormatter = new BinaryFormatter();
                    list = binaryFormatter.Deserialize(fs) as List<User>;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }



            do
            {
                Console.BackgroundColor = ConsoleColor.Black;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Yellow;

                Console.WriteLine(DateTime.Now.ToString("F"));
                Console.WriteLine("1 - ATM\n" +
                                  "2 - Bank\n" +
                                  "3 - Exit\n");
                main_action = (MainMenu)Enum.Parse(typeof(MainMenu), Console.ReadLine());

                Console.Clear();
                if (main_action == MainMenu.ATM)
                {
                   
                    Console.BackgroundColor = ConsoleColor.Blue;
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.White;


                    Console.Write(" _____________________________________\n" +
                                      "|                                     |\n" +
                                      "|                 ATM                 |\n" +
                                      "|_____________________________________|\n" +
                                      "|                                     |\n" +
                                      $"|    {DateTime.Now.ToString("F").PadRight(20)}     |\n" +
                                      $"|                                     |\n" +
                                      $"| Enter number : ");


                    number = new StringBuilder();
                    count = 0;

                    while (true)
                    {
                        ConsoleKeyInfo key = Console.ReadKey(true);
                        Console.Beep(frequency, duration);

                        if (key.Key == ConsoleKey.Enter)
                        {
                            break;
                        }
                        else if (key.Key == ConsoleKey.Backspace)
                        {
                            if (number.Length!=0)
                            {
                                if (count == 6 || count == 11 || count == 16)
                                {
                                    Console.Write("\b \b\b \b");
                                    number = number.Remove(number.Length - 1, 1);
                                    number = number.Remove(number.Length - 1, 1);
                                    count -= 2;
                                }
                                else
                                {
                                    Console.Write("\b \b");
                                    number = number.Remove((number.Length - 1), 1);
                                    count--;
                                }
                            }
                        }
                        else
                        {
                            if (count == 4 || count == 9 || count == 14)
                            {
                                number = number.Append(" ");
                                count++;
                            }

                            count++;
                            number = number.Append(key.KeyChar);
                        }

                        for (int i = 0; i < number.Length; i++) Console.Write("\b \b");
                        Console.Clear();
                        Console.WriteLine(" _____________________________________\n" +
                                          "|                                     |\n" +
                                          "|                 ATM                 |\n" +
                                          "|_____________________________________|\n" +
                                          "|                                     |\n" +
                                          $"|    {DateTime.Now.ToString("F").PadRight(20)}     |\n" +
                                          $"|                                     |\n" +
                                          $"| Enter number : {number.ToString().PadRight(20)} |\n" +
                                          $"|                                     |\n" +
                                          $"|                                     |\n" +
                                          $"|                                     |\n" +
                                          $" ------------------------------------- \n");

                    }


                    Console.Clear();
                        Console.Write(" _____________________________________\n" +
                                      "|                                     |\n" +
                                      "|                 ATM                 |\n" +
                                      "|_____________________________________|\n" +
                                      "|                                     |\n" +
                                      $"|    {DateTime.Now.ToString("F").PadRight(20)}     |\n" +
                                      $"|                                     |\n" +
                                      $"| Enter number : {number.ToString().PadRight(20)} |\n" +
                                      $"|                                     |\n" +
                                      $"| Enter pin    : ");
                    pass = new StringBuilder();
                    StringBuilder vizualPin=new StringBuilder();
                    while (true)
                    {
                        ConsoleKeyInfo key = Console.ReadKey(true);
                        Console.Beep(frequency, duration);
                        if (key.Key == ConsoleKey.Enter)
                        {
                            break;
                        }
                        else if (key.Key == ConsoleKey.Backspace)
                        {

                            if (pass.Length!=0)
                            {
                                vizualPin.Remove(vizualPin.Length - 1, 1);
                                pass.Remove((pass.Length - 1), 1);
                                Console.Clear();
                                Console.WriteLine(" _____________________________________\n" +
                                                  "|                                     |\n" +
                                                  "|                 ATM                 |\n" +
                                                  "|_____________________________________|\n" +
                                                  "|                                     |\n" +
                                                  $"|    {DateTime.Now.ToString("F").PadRight(20)}     |\n" +
                                                  $"|                                     |\n" +
                                                  $"| Enter number : {number.ToString().PadRight(20)} |\n" +
                                                  $"|                                     |\n" +
                                                  $"| Enter pin    : {vizualPin.ToString().PadRight(10)}           |\n" +
                                                  $"|                                     |\n" +
                                                  $" ------------------------------------- \n");
                            }
                        }
                        else
                        {
                            pass.Append(key.KeyChar);
                            vizualPin.Append("*");
                            Console.Clear();
                            Console.WriteLine(" _____________________________________\n" +
                                              "|                                     |\n" +
                                              "|                 ATM                 |\n" +
                                              "|_____________________________________|\n" +
                                              "|                                     |\n" +
                                              $"|    {DateTime.Now.ToString("F").PadRight(20)}     |\n" +
                                              $"|                                     |\n" +
                                              $"| Enter number : {number.ToString().PadRight(20)} |\n" +
                                              $"|                                     |\n" +
                                              $"| Enter pin    : {vizualPin.ToString().PadRight(10)}           |\n" +
                                              $"|                                     |\n" +
                                              $" ------------------------------------- \n");
                        
                        }
                    }

                    data = false;

                    if (number.Length == 19)
                    {
                        number = number.Remove(14, 1);
                        number = number.Remove(9, 1);
                        number = number.Remove(4, 1);
                    }

                    for (int i = 0; i < list.Count; i++)
                        if (string.Equals(list[i].Card.Number, number.ToString()))
                        {
                            if (list[i].Card.Pin == int.Parse(pass.ToString()))
                            {
                                data = true;
                                userIndex = i;
                            }
                        }

                    if (data)
                    {
                        AdditionalFunctionality.LoadingSuccessful();
                        Console.Clear();
                        Console.WriteLine("\nWelcome\n");

                        do
                        {

                            Console.WriteLine(DateTime.Now.ToString("F") +
                                              $"\nYour balance  {list[userIndex].Card.Money}\n" +
                                              "All operations can be performed with currencies( azn / dollar / avro )\n\n" +
                                              "0 - Exit\n" +
                                              "1 - Subtract money from the card \n" +
                                              "2 - Put money out of the card\n" +
                                              "3 - Send money\n" +
                                              "4 - My card \n" +
                                              "5 - Come back\n");

                            atm_action = (AtmMenu) Enum.Parse(typeof(AtmMenu), Console.ReadLine());

                            Console.Clear();

                            if (atm_action == AtmMenu.SUBTRACT)
                            {
                                Console.WriteLine($"Your balance  {list[userIndex].Card.Money}\n" +
                                                  "Please select  currency\n\n" +
                                                  "1 - Azn\n" +
                                                  $"2 - Dollar ( kurs : {Money.DollarToManatKurs} )\n" +
                                                  $"3 - Avro   ( kurs : {Money.AvroToManatKurs} )\n");

                                action = Convert.ToInt32(Console.ReadLine());
                                Console.Clear();

                                if (action == 1)
                                {
                                    do
                                    {
                                        Console.WriteLine($"Your balance  {list[userIndex].Card.Money}\n" +
                                                          "You select Azn\n" +
                                                          "\n-1 come back\nEnter sum : ");

                                        money = Convert.ToDecimal(Console.ReadLine());
                                        Console.Clear();

                                        if (Convert.ToInt32(money) == -1)
                                        {
                                            break;
                                        }
                                        else if (list[userIndex].Card.Money.SubtractAzn(money))
                                        {
                                            Console.WriteLine($"You  pulled out card {Convert.ToInt32(money)} AZN\n");
                                            break;
                                        }
                                        else Console.WriteLine("Not enough money, enter a smaller amount");

                                    } while (true);
                                }
                                else if (action == 2)
                                {
                                    do
                                    {
                                        Console.WriteLine(
                                            $"\nYour balance  {list[userIndex].Card.Money.Azn} Azn\n" +
                                            "You select Dollar\n" +
                                            "\n-1 come back\nEnter sum : ");

                                        money = Convert.ToDecimal(Console.ReadLine());
                                        Console.Clear();

                                        if (Convert.ToInt32(money) == -1)
                                        {
                                            break;
                                        }
                                        else if (list[userIndex].Card.Money.SubtractDollar(money))
                                        {
                                            Console.WriteLine($"You  pulled out card {Convert.ToInt32(money)} $\n");
                                            break;
                                        }
                                        else Console.WriteLine("Not enough money, enter a smaller amount");

                                    } while (true);
                                }
                                else if (action == 3)
                                {
                                    do
                                    {
                                        Console.WriteLine(
                                            $"\nYour balance  {list[userIndex].Card.Money.Azn} Azn\n" +
                                            "You select Avro\n" +
                                            "\n-1 come back\nEnter sum : ");

                                        money = Convert.ToDecimal(Console.ReadLine());
                                        Console.Clear();

                                        if (Convert.ToInt32(money) == -1)
                                        {
                                            break;
                                        }
                                        else if (list[userIndex].Card.Money.SubtractAvro(money))
                                        {
                                            Console.WriteLine($"You  pulled out card {Convert.ToInt32(money)} Avro\n");
                                            break;
                                        }
                                        else Console.WriteLine("Not enough money, enter a smaller amount");

                                    } while (true);
                                }
                                else Console.WriteLine("Incorrect choice");
                            }
                            else if (atm_action == AtmMenu.PUT_ON)
                            {
                                Console.WriteLine(
                                    $"\nYour balance  {list[userIndex].Card.Money.Azn} Azn\n" +
                                    "Please select  currency\n\n" +
                                    "1 - Azn\n" +
                                    $"2 - Dollar ( kurs : {Money.DollarToManatKurs} )\n" +
                                    $"3 - Avro   ( kurs : {Money.AvroToManatKurs} )\n");

                                action = Convert.ToInt32(Console.ReadLine());
                                Console.Clear();

                                if (action == 1)
                                {
                                    Console.WriteLine(
                                        $"\nYour balance  {list[userIndex].Card.Money}\n" +
                                        "You select Azn\n" +
                                        "\nEnter sum : ");

                                    money = Convert.ToDecimal(Console.ReadLine());
                                    list[userIndex].Card.Money.AddAzn(money);

                                    Console.WriteLine($"You  put on card {Convert.ToInt32(money)} AZN\n");
                                }
                                else if (action == 2)
                                {
                                    Console.WriteLine(
                                        $"\nYour balance  {list[userIndex].Card.Money}\n" +
                                        "You select $\n" +
                                        "\nEnter sum : ");

                                    money = Convert.ToDecimal(Console.ReadLine());
                                    Console.Clear();

                                    list[userIndex].Card.Money.addDollar(money);
                                    Console.WriteLine($"You  put on card {Convert.ToInt32(money)} $\n");
                                }
                                else if (action == 3)
                                {
                                    Console.WriteLine(
                                        $"\nYour balance  {list[userIndex].Card.Money}\n" +
                                        "You select Avro\n" +
                                        "\nEnter sum : ");

                                    money = Convert.ToDecimal(Console.ReadLine());
                                    Console.Clear();

                                    list[userIndex].Card.Money.AddAvro(money);
                                    Console.WriteLine($"You  put on card {Convert.ToInt32(money)} Avro\n");
                                }
                                else Console.WriteLine("Incorrect choice");
                            }
                            else if (atm_action == AtmMenu.SEND)
                            {
                                Console.WriteLine(
                                    $"\nYour balance  {list[userIndex].Card.Money}\n" +
                                    "Please select  currency\n\n" +
                                    "1 - Azn\n" +
                                    $"2 - Dollar ( kurs : {Money.DollarToManatKurs} )\n" +
                                    $"3 - Avro   ( kurs : {Money.AvroToManatKurs} )\n");

                                action = Convert.ToInt32(Console.ReadLine());
                                Console.Clear();

                                if (action == 1)
                                {
                                    Console.WriteLine($"\nYour balance  {list[userIndex].Card.Money}\n" +
                                                       "You select Azn\n" +
                                                       "\nEnter sum for send: ");

                                    money = Convert.ToDecimal(Console.ReadLine());

                                    if (list[userIndex].Card.Money.Azn >= money)
                                    {
                                        Console.WriteLine("Please enter the card number to whom you want to send money ");
                                        number = new StringBuilder();
                                        count = 0;

                                        while (true)
                                        {
                                            ConsoleKeyInfo key = Console.ReadKey(true);
                                            Console.Beep(frequency, duration);

                                            if (key.Key == ConsoleKey.Enter)
                                            {
                                                if (number.Length == 19)
                                                {
                                                    number = number.Remove(14, 1);
                                                    number = number.Remove(9, 1);
                                                    number = number.Remove(4, 1);
                                                }
                                                break;
                                            }
                                            else if (key.Key == ConsoleKey.Backspace)
                                            {
                                                if (count == 6 || count == 11 || count == 16)
                                                {
                                                    Console.Write("\b \b\b \b");
                                                    number = number.Remove(number.Length - 1, 1);
                                                    number = number.Remove(number.Length - 1, 1);
                                                    count -= 2;
                                                }
                                                else
                                                {
                                                    Console.Write("\b \b");
                                                    number = number.Remove((number.Length - 1), 1);
                                                    count--;
                                                }
                                            }
                                            else
                                            {
                                                if (count == 4 || count == 9 || count == 14)
                                                {
                                                    number = number.Append(" ");
                                                    count++;
                                                }

                                                count++;
                                                number = number.Append(key.KeyChar);
                                            }

                                            for (int i = 0; i < number.Length; i++) Console.Write("\b \b");
                                            Console.Write(number);

                                        }

                                        if (AdditionalFunctionality.TransferMoney(list, number.ToString(), 1, money))
                                        {
                                            list[userIndex].Card.Money.SubtractAzn(money);
                                            Console.WriteLine("\nMoney sent successfully!!!\n");
                                        }
                                        else Console.WriteLine("Entered data wrong!!\n");
                                    }
                                    else Console.WriteLine("There is not enough money in the card\n");
                                }
                                else if (action == 2)
                                {
                                    Console.WriteLine(
                                        $"\nYour balance  {list[userIndex].Card.Money}\n" +
                                        "You select $\n" +
                                        "\nEnter sum for send: ");

                                    money = Convert.ToDecimal(Console.ReadLine());
                                    if (list[userIndex].Card.Money.Azn >= money)
                                    {
                                        Console.WriteLine("Please enter the card number to whom you want to send money ");
                                        number = new StringBuilder();
                                        count = 0;
                                        while (true)
                                        {
                                            ConsoleKeyInfo key = Console.ReadKey(true);
                                            Console.Beep(frequency, duration);

                                            if (key.Key == ConsoleKey.Enter)
                                            {
                                                if (number.Length == 19)
                                                {
                                                    number = number.Remove(14, 1);
                                                    number = number.Remove(9, 1);
                                                    number = number.Remove(4, 1);
                                                }
                                                break;
                                            }
                                            else if (key.Key == ConsoleKey.Backspace)
                                            {
                                                if (count == 6 || count == 11 || count == 16)
                                                {
                                                    Console.Write("\b \b\b \b");
                                                    number = number.Remove(number.Length - 1, 1);
                                                    number = number.Remove(number.Length - 1, 1);
                                                    count -= 2;
                                                }
                                                else
                                                {
                                                    Console.Write("\b \b");
                                                    number = number.Remove((number.Length - 1), 1);
                                                    count--;
                                                }
                                            }
                                            else
                                            {
                                                if (count == 4 || count == 9 || count == 14)
                                                {
                                                    number = number.Append(" ");
                                                    count++;
                                                }

                                                count++;
                                                number = number.Append(key.KeyChar);
                                            }

                                            for (int i = 0; i < number.Length; i++) Console.Write("\b \b");
                                            Console.Write(number);

                                        }

                                        if (AdditionalFunctionality.TransferMoney(list, number.ToString(), 2, money))
                                        {
                                            list[userIndex].Card.Money.SubtractDollar(money);
                                            Console.WriteLine("\nMoney sent successfully!!!\n");
                                        }
                                        else Console.WriteLine("Entered data wrong!!\n");

                                    }
                                    else Console.WriteLine("There is not enough money in the card\n");

                                }
                                else if (action == 3)
                                {
                                    Console.WriteLine(
                                        $"\nYour balance  {list[userIndex].Card.Money}\n" +
                                        "You select Avro\n" +
                                        "\nEnter sum for send: ");
                                    money = Convert.ToDecimal(Console.ReadLine());

                                    if (list[userIndex].Card.Money.Azn >= money)
                                    {
                                        Console.WriteLine("Please enter the card number to whom you want to send money ");
                                        number = new StringBuilder();
                                        count = 0;
                                        while (true)
                                        {

                                            ConsoleKeyInfo key = Console.ReadKey(true);
                                            Console.Beep(frequency, duration);

                                            if (key.Key == ConsoleKey.Enter)
                                            {
                                                if (number.Length == 19)
                                                {
                                                    number = number.Remove(14, 1);
                                                    number = number.Remove(9, 1);
                                                    number = number.Remove(4, 1);
                                                }
                                                break;
                                            }
                                            else if (key.Key == ConsoleKey.Backspace)
                                            {
                                                if (count == 6 || count == 11 || count == 16)
                                                {
                                                    Console.Write("\b \b\b \b");
                                                    number = number.Remove(number.Length - 1, 1);
                                                    number = number.Remove(number.Length - 1, 1);
                                                    count -= 2;
                                                }
                                                else
                                                {
                                                    Console.Write("\b \b");
                                                    number = number.Remove((number.Length - 1), 1);
                                                    count--;
                                                }
                                            }
                                            else
                                            {
                                                if (count == 4 || count == 9 || count == 14)
                                                {
                                                    number = number.Append(" ");
                                                    count++;
                                                }
                                                count++;
                                                number = number.Append(key.KeyChar);
                                            }

                                            for (int i = 0; i < number.Length; i++) Console.Write("\b \b");
                                            Console.Write(number);

                                        }

                                        if (AdditionalFunctionality.TransferMoney(list, number.ToString(), 3, money))
                                        {
                                            list[userIndex].Card.Money.SubtractAvro(money);
                                            Console.WriteLine("\nMoney sent successfully!!!\n");
                                        }
                                        else Console.WriteLine("Entered data wrong!!\n");

                                    }
                                    else Console.WriteLine("There is not enough money in the card\n");

                                }
                                else Console.WriteLine("Incorrect choice");
                            }
                            else if (atm_action == AtmMenu.PRINT_CARD)
                            {
                                Console.WriteLine($"Your card : \n\n{list[userIndex].Card}");
                            }
                            else if (atm_action == AtmMenu.BACK)
                            {
                                Console.WriteLine("You come back");

                                break;
                            }
                            else if (atm_action == AtmMenu.EXIT)
                            {
                                Console.Write("You left the program");
                                return;
                            }
                            else Console.WriteLine("Incorrect choice");

                        } while (true);
                    }
                    else
                    {
                        AdditionalFunctionality.LoadingError();
                        Console.ReadKey();
                        Console.WriteLine("\nWrong data!!!\n");
                    }
                }
                else if (main_action == MainMenu.BANK)
                {

                    do
                    {
                         Console.WriteLine(DateTime.Now.ToString("F") +
                                          "\n0 - Exit\n" +
                                          "1 - Add client\n" +
                                          "2 - Delete client\n" +
                                          "3 - All client with card print\n" +
                                          "4 - Upload salary\n" +
                                          "5 - Print All client\n" +
                                          "6 - Print Card\n" +
                                          "7 - Come back\n\n");

                         bank_action = (BankMenu) Enum.Parse(typeof(BankMenu), Console.ReadLine());

                        Console.Clear();

                        if (bank_action == BankMenu.ADD)
                        {
                            Console.Write("Enter name    : ");
                            name = Console.ReadLine();
                            Console.Write("Enter surname : ");
                            surname = Console.ReadLine();
                            tmp = new User(name, surname);

                            list.Add(tmp);
                        }
                        else if (bank_action == BankMenu.DELETE)
                        {
                            if (list.Count > 0)
                            {
                                Console.WriteLine("Enter the number for delete");
                                for (int i = 0; i < list.Count; i++)
                                    Console.WriteLine($"{i}.  {list[i]}");


                                action = Convert.ToInt32(Console.ReadLine());

                                if (list.Count > action)list.Remove(list[action]);
                                
                            }
                            else Console.WriteLine("Not client\n");
                            
                        }
                        else if (bank_action == BankMenu.ALL_PRINT_WITH_CARD)
                        {
                            if (list.Count == 0)
                            {
                                Console.WriteLine("Not User!!\n");
                            }
                            else
                            {
                                for (int i = 0; i < list.Count; i++) Console.WriteLine($"{i}. {list[i]} \n  {list[i].Card}");

                                Console.WriteLine();
                            }

                        }
                        else if (bank_action == BankMenu.EXIT)
                        {
                            Console.Write("You left the program");
                            main_action = MainMenu.EXIT;
                            break;
                        }
                        else if (bank_action == BankMenu.BACK)
                        {
                            break;
                        }
                        else if (bank_action == BankMenu.PRINT_CARD)
                        {
                            if (list.Count > 0)
                            {
                                Console.WriteLine("Whose cards to present to you?");
                                for (int i = 0; i < list.Count; i++)
                                    Console.WriteLine($"{i}.  {list[i]}");

                                action = Convert.ToInt32(Console.ReadLine());

                                if (action >= list.Count) Console.WriteLine("Incorrect choice\n");
                                else Console.WriteLine(list[action].Card.ToString());
                                
                            }
                            else  Console.WriteLine("Not client\n");
                        }
                        else if (bank_action == BankMenu.UPLOAD_SALARY)
                        {
                            if (list.Count <= 0) Console.WriteLine("Not client\n");
                            else
                            {
                                salary = false;
                                for (int j = 0; j < list.Count; j++)
                                {
                                    list[j].GetSalary();
                                    salary = true;
                                }

                                if (salary) Console.WriteLine("Salary issued\n");
                                else Console.WriteLine("Not card for issue salary\n");

                            }

                        }
                        else if (bank_action == BankMenu.PRINT_ALL_CLIENT)
                        {
                            if (list.Count > 0)
                            {
                                Console.WriteLine("Print all client\n");
                                for (int i = 0; i < list.Count; i++)
                                    Console.WriteLine($"{i}.  {list[i]}");
                                Console.WriteLine();
                            }
                            else Console.WriteLine("Not client\n");

                        }
                        else Console.WriteLine("Incorrect choice\n");

                    } while (true);
                }
                else if (main_action == MainMenu.EXIT)
                {
                    break;
                }
                else Console.WriteLine("Incorrect choice\n");

            } while (main_action != MainMenu.EXIT);



            using (FileStream fs = new FileStream("people.bin", FileMode.Create))
            {
                BinaryFormatter binaryFormatter = new BinaryFormatter();
                binaryFormatter.Serialize(fs, list);
            }

        }
    }
}

