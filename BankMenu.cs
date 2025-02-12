using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySimpleBankSystem
{

    public class BankMenu
    {
        BankManager bankManager = new();

        public void MyMenu()
        {
            bool process = true;
            while (process)
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("MOBILE BANK");
                Console.WriteLine("");
                Console.WriteLine("1. Creat Bank Acount");
                Console.WriteLine("2. Login Bank Acount");
                Console.WriteLine("3. View All Accounts");
                Console.WriteLine("4. Exit ");
                Console.ResetColor();
                Console.Write("- Choose: ");
                int input = int.Parse(Console.ReadLine()!);
                switch (input)
                {
                    case 1:
                        bankManager.CreatAccount();
                        break;
                    case 2:
                        bankManager.Login();
                        break;
                    case 3:
                        bankManager.ViewAllAccounts();
                        break;
                    case 4:
                        process = false;
                        Console.WriteLine("Thanks For Banking With Us :)");
                        Console.WriteLine("Application Closed");
                        break;
                    default:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Invalid Expression");
                        Console.ResetColor();
                        break;

                }


            }

        }

    }

}