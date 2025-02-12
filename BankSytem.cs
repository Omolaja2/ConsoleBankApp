using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MySimpleBankSystem
{
    public class BankSytem
    {
        public string? Username { get; set; }
        public string? PhoneNumber { get; set; }

        public string? Pin { get; set; }

        public decimal Balance { get; set; } = default;
        public DateTime CreatedAt { get; set; }

        public override string ToString()
        {
            return $"Accout Name: {Username}|| Pin: {Pin} || PhoneNumber: {PhoneNumber} || Balance: {Balance} || {CreatedAt}";

        }
    }
}