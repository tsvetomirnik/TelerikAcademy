using School.Items;

namespace School
{
	public class Student : IPerson, IDescriptionable
	{
		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string ClassNumber { get; private set; }

		public string Description { get; set; }

		public Student(string classNumber, string firstName, string lastName)
		{
			FirstName = firstName;
			LastName = lastName;
			ClassNumber = classNumber;
		}
	}
}