using System;
using BankSystem.Items;

namespace BankSystem
{
    class Program
    {
        static void Main()
        {
			var customer = new IndividualCustomer("Ivan", "Sofia");
			var bankAccount = new DepositAccount(customer, 30.4);

			bankAccount.Deposit(2000M);
	        Console.WriteLine("Current blanace: " + bankAccount.Balance);

	        Console.WriteLine("Interest amount: " + bankAccount.GetInterestAmount(23));

			bankAccount.Draw(153.03M);
	        Console.WriteLine("Current blanace: " + bankAccount.Balance);
        }
    }
}
