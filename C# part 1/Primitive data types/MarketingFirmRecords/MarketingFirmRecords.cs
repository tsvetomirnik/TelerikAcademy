/*
 * Author: Tsvetomir Nikolov
 * Student number: 6001771
 * Email: cvetomir.nikolov@gmail.com
 * 
 * Task 10: A marketing firm wants to keep record of its employees. Each
 * record would have the following characteristics – first name, family
 * name, age, gender (m or f), ID number, unique employee number 
 * (27560000 to 27569999). Declare the variables needed to keep the
 * information for a single employee using appropriate data types and
 * descriptive names.
 * 
 */

namespace MarketingFirmRecords
{
	class MarketingFirmRecords
	{
		public enum Gender
		{
			Male = 0,
			Female = 1
		}

		public class Employee
		{
			public int Number { get; set; }
			public string FirstName { get; set; }
			public string LastName { get; set; }
			public byte Age { get; set; }
			public Gender Gender { get; set; }
			public string Id { get; set; }
		}

		static void Main()
		{
			Employee employee = new Employee
			{
				Number = 1,
				FirstName = "Ivan",
				LastName = "Ivanov",
				Age = 23,
				Gender = Gender.Male,
				Id = "9011013223"
			};
		}
	}
}
