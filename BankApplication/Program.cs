using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication
{
    class Program
    {
        public class Account
        {
            private decimal balance;
            public decimal Balance
            {
                get { return balance; }
                set
                {
                    if (value < 0)
                    {
                        balance = 0;
                        Console.WriteLine("Beginning balance was incorrect");
                    }
                    else
                        balance = value;
                }
            }
            public Account(decimal y)
            {
                Balance = y;
            }
            public virtual void Credit(decimal x)
            {
                balance += x;
            }
            public virtual bool Debit(decimal x)
            {
                if (balance < x)
                {
                    Console.WriteLine("Debit amount exceeded account balance.");
                    return false;
                }
                else
                {
                    balance -= x;
                    return true;
                }
            }
        }
        static void Main(string[] args)
        {
        }
    }
}