using System;

namespace BankSystem.Items
{
	class LoanAccount : DepositableAccount
	{
		public LoanAccount(Customer owner, double interestRate) 
			: this(owner, 0, interestRate)
		{
		}

		public LoanAccount(Customer owner, decimal balance, double interestRate) 
			: base(owner, balance, interestRate)
		{
		}

		public override double GetInterestAmount(int loanMonths)
		{
			if (Owner is IndividualCustomer)
			{
				return GetInterestAmount(loanMonths - 3);
			}
			
			if (Owner is Company)
			{
				return GetInterestAmount(loanMonths - 2);
			}

			throw new Exception("Invalid customer type");
		}
	}
}
