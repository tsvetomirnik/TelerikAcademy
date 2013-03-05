namespace BankSystem.Items
{
	public abstract class DepositableAccount : Account, IDepositable
	{
		protected DepositableAccount(Customer owner, decimal balance, double interestRate) 
			: base(owner, balance, interestRate)
		{
		}

		public void Deposit(decimal money)
		{
			this.Balance += money;
		}
	}
}
