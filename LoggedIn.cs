using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.AccessControl;
using System.Threading.Tasks;

namespace MySimpleBankSystem
{
    public class LoggedIn
    {

        BankSytem bankSytem = new();

        public void Deposit(BankSytem account)
        {
            Console.Write("Enter Amount To Deposit: ");
            decimal amount = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Input your 4-Digit Pin To Proceed: ");
            string pin = ReadPassword();
            if (pin != account.Pin)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Incorrect Password");
                Console.ResetColor();
                return;
            }

            else if (amount <= 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Oops Cant Deposit Empty Funds");
                Console.ResetColor();
                Console.WriteLine("-----------------------------------------------------------");
                Console.WriteLine("-----------------------------------------------------------");
                return;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Processing...");
                Console.ResetColor();
                bankSytem.Balance += amount;
                Console.WriteLine($"You Sucessfuly Deposited ${amount} To Your Aza!");
                Console.WriteLine("-----------------------------------------------------------");
                Console.WriteLine("-----------------------------------------------------------");
                Console.WriteLine("");

            }
        }
        public void Withraw(BankSytem account)
        {
            Console.Write("Enter Amount To Withraw: ");
            decimal amount = Convert.ToDecimal(Console.ReadLine());
            Console.Write("Input your 4 Digit  Pin To Proceed: ");
            string pin = ReadPassword();
            if (pin != account.Pin)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Incorrect Password");
                Console.ResetColor();
                return;
            }

            else if (amount > bankSytem.Balance)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Insufficient Balance");
                Console.ResetColor();
                return;
            }
            else
            {
                bankSytem.Balance -= amount;
                Console.WriteLine($"${amount} Withrawal Successfull");
                Console.WriteLine("-----------------------------------------------------------");
                Console.WriteLine("-----------------------------------------------------------");
                Console.WriteLine("");
            }

        }


        public string ReadPassword()
        {
            string pinandpassword = "";
            ConsoleKeyInfo key;

            do
            {
                key = Console.ReadKey(intercept: true);

                if (key.Key != ConsoleKey.Enter)
                {
                    if (key.Key == ConsoleKey.Backspace && pinandpassword.Length > 0)
                    {

                        pinandpassword = pinandpassword.Substring(0, pinandpassword.Length - 1);
                        Console.Write("\b \b");
                    }
                    else if (!char.IsControl(key.KeyChar))
                    {

                        pinandpassword += key.KeyChar;
                        Console.Write("*");
                    }
                }
            } while (key.Key != ConsoleKey.Enter);

            Console.WriteLine();
            return pinandpassword;
        }

        public void CheckBalance(BankSytem account)
        {
            Console.Write("Input your 4-Digit Pin:");
            string pin = ReadPassword();
            if (pin != account.Pin)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Incorrect Pin Make Sure You Input The Correct Pin");
                Console.ResetColor();
                return;
            }

            else
            {
                Console.WriteLine($"Your Acount Balance Is ${bankSytem.Balance}");
                Console.WriteLine("-----------------------------------------------------------");
                Console.WriteLine("-----------------------------------------------------------");
                return;

            }

        }
    }
}