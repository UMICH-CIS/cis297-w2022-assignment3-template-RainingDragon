// Charles Simms
// CIS 297
// Assignment 3 Bank Application
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApplication
{
    class Program
    {
        public class Account // Account class that returns balance
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
            public class CheckingsAccount : Account
            {
                private decimal Fee;
                public CheckingsAccount(decimal y, decimal f) :
                    base(y)
                {
                    Fee = f;
                }
                public override bool Debit(decimal x)
                {
                    if (base.Debit(x) == true)
                    {
                        Balance -= Fee;
                        return true;
                    }
                    else
                        return false;
                }
                public override void Credit(decimal x)
                {
                    base.Credit(x);
                    Balance -= Fee;
                }
            }
            public class SavingsAccount : Account
            {
                decimal intRate;
                public SavingsAccount(decimal y, decimal rate) :
                    base(y)
                {
                    intRate = rate;
                }
                public decimal CalculateInterest()
                {
                    return intRate * Balance;
                }
            }
            static void Main(string[] args)
            {
                SavingsAccount customer1 = new SavingsAccount(50, 0.2M);
                customer1.Credit(customer1.CalculateInterest());
                Console.WriteLine("Balance after interest amount in saving account: {0}", customer1.Balance);
                CheckingsAccount customer2 = new CheckingsAccount(50, 0.50M);
                customer2.Credit(17.26M);
                Console.WriteLine("Balance after depositing checking account: {0}", customer2.Balance);
                customer2.Debit(12.24M);
                Console.WriteLine("Balance after withdrawing checking account: {0}", customer2.Balance);
                Console.WriteLine("=====================================================================");
                Console.WriteLine("Enter any number to exit: ");
                Console.WriteLine(int.Parse(Console.ReadLine()));
            }
        }
    }
}