using System;

namespace PersonDefinition
{
	class PersonDefinition
	{
		static void Main()
		{
			Person person = new Person("Ivan");
			Console.WriteLine(person.ToString()); //Nullable age

			person.Age = 20;
			Console.WriteLine(person.ToString()); //With setted age
		}
	}
}
