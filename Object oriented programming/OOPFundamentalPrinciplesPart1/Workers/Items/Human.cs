namespace Workers.Items
{
	abstract class Human
	{
		public string FirstName { get; protected set; }

		public string LastName { get; protected set; }

		public Human(string firstName, string lastName)
		{
			FirstName = firstName;
			LastName = lastName;
		}
	}
}