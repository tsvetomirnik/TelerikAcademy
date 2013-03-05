using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystem.Items
{
	class MortgageAccount : DepositableAccount
	{
		public MortgageAccount(Customer owner, double interestRate) 
			: this(owner, 0, interestRate)
		{
		}

		public MortgageAccount(Customer owner, decimal balance, double interestRate) 
			: base(owner, balance, interestRate)
		{
		}

		public override double GetInterestAmount(int loanMonths)
		{
			if (this.Owner is Company)
			{
				if (loanMonths <= 12)
                {
                    return base.GetInterestAmount(loanMonths) / 2;
                }
				
				return base.GetInterestAmount(loanMonths - 12) 
					+ base.GetInterestAmount(12) / 2;
			}

			if(this.Owner is IndividualCustomer)
			{
				if(loanMonths <= 6)
				{
					return 0;
				}

				return base.GetInterestAmount(loanMonths - 6);
			}

			throw new Exception("Invalid customer type");
		}
	}
}
