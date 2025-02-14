using System;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using ConsoleTables;

namespace MySimpleBankSystem
{
    public class BankManager : LoggedIn
    {
        BankSytem bankSytem = new();
        public List<BankSytem> bankSytems;

        public BankManager()
        {
            bankSytems = new List<BankSytem>();
        }

        public void CreatAccount()
        {
            Console.Write("Creat New Acount  Name: ");
            string username = Console.ReadLine() ?? string.Empty;
            if (string.IsNullOrEmpty(username))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You Have Not Created Any Name");
                Console.ResetColor();
                return;
            }

            Console.Write("Enter New PhoneNumber: ");
            string phoneNumber = Console.ReadLine()! ?? string.Empty;
            if (!ValidatePhoneNumber(phoneNumber))
            {
                return;
            }
            Console.Write("Creat New Password (must be 6 characters): ");
            string password = Console.ReadLine() ?? string.Empty;
            if (!ValidatePassword(password))
            {
                return;
            }

            Console.Write("Create Your 4-Digit Pin (numeric): ");
            string pinInput = ReadPassword();
            if (!ValidatePin(pinInput))
            {
                return;
            }

            BankSytem account = new BankSytem()
            {
                Username = username,
                PhoneNumber = phoneNumber,
                Password = password,
                Pin = pinInput,
                Balance = 0.00M,
                CreatedAt = DateTime.Now
            };
            bankSytems.Add(account);
            Console.WriteLine("");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Account Created Successfully");
            Console.ResetColor();
        }


        public void Login()
        {
            Console.Write("Enter Your Account Username: ");
            string username = Console.ReadLine()!;
            var account = bankSytems.Find(a => a.Username == username);
            if (account == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Oops Account not found!");
                Console.ResetColor();
                return;
            }

            Console.Write("Enter Your 4-Digit Pin: ");
            string pin = ReadPassword();
            if (pin == account.Pin)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Login Approved");
                Console.ResetColor();

                bool run = true;
                while (run)
                {
                    Console.WriteLine("1. Deposit");
                    Console.WriteLine("2. Withraw");
                    Console.WriteLine("3. Check Balance");
                    Console.WriteLine("4. Log Out");
                    Console.Write(" Choose From The Option: ");
                    int input = int.Parse(Console.ReadLine()!);

                    switch (input)
                    {
                        case 1:
                            Deposit(account);
                            continue;
                        case 2:
                            Withraw(account);
                            continue;
                        case 3:
                            CheckBalance(account);
                            continue;
                        case 4:
                            run = false;
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("Logged Out");
                            Console.ResetColor();
                            Console.WriteLine("- Login Again");
                            Console.WriteLine("-----------------------------------------------------------");
                            Console.WriteLine("-----------------------------------------------------------");
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Invalid Input! Choose Correctly From The Above Option.");
                            Console.ResetColor();
                            break;
                    }
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Incorrect Pin");
                Console.ResetColor();
            }
        }

    
       static bool ValidatePassword(string password)
    {
        string namePattern = @"^[a-zA-Z@]+(?: [a-zA-Z@]+)*$";

        if (!Regex.IsMatch(password, namePattern))
        {
            Console.WriteLine("Password  cannot contain special characters except single whitespace between each interval of word or character and @ character!");
            return false;
            
        }

        if (password.Length != 8)
        {
            throw new Exception("Password must be at least Eight characters.");
        }
        return true;
    }
            
        
          static bool ValidatePin(string pinInput)
        {
            string passwordPattern = @"^\d+$";
            if (!Regex.IsMatch(pinInput, passwordPattern))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Cannot Contain Special Characters!");
                Console.ResetColor();
                Console.WriteLine("-----------------------------------------------------------");
                Console.WriteLine("-----------------------------------------------------------");
                return false;
            }

            if (pinInput.Length != 4)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Your Pin Must Be Atleast 4 Digit");
                Console.ResetColor();
                Console.WriteLine("-----------------------------------------------------------");
                Console.WriteLine("-----------------------------------------------------------");
                return false;
            }
            return true;
            
        }
         static bool ValidatePhoneNumber(string phoneNumber)
        {
            string passwordPattern = @"^\d+$";
            if (!Regex.IsMatch(phoneNumber, passwordPattern))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Cannot Contain Special Characters!");
                Console.ResetColor();
                Console.WriteLine("-----------------------------------------------------------");
                Console.WriteLine("-----------------------------------------------------------");
                return false;
            }

            if (phoneNumber.Length != 11)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Your Phone Number  Must Be Atleast Eleven Digits");
                Console.ResetColor();
                Console.WriteLine("-----------------------------------------------------------");
                Console.WriteLine("-----------------------------------------------------------");
                return false;
            }
            return true;
            
        }


        public void ViewAllAccounts()
        {
            var consoleTable = new ConsoleTable("Username", "PIn", "PhoneNumber","Password", "Balance", "CreatedAt");

            foreach (var account in bankSytems)
            {
                string maskedPin = "****";

                consoleTable.AddRow(account.Username, maskedPin, account.PhoneNumber,account.Password, account.Balance, account.CreatedAt);
            }

            Console.WriteLine(consoleTable.ToString());
        }

    }
}


