namespace BankSystem.Items
{
	public abstract class Customer
	{
		public string Name { get; private set; }
		public string Address { get; protected set; }

		protected Customer(string name, string address)
		{
			this.Name = name;
			this.Address = address;
		}
	}
}
