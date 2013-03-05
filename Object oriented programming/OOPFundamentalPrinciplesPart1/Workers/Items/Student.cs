using System;

namespace Workers.Items
{
	class Student : Human
	{
		public const int maxGrade = 12;
		private int grade;

		public Student(string firstName, string lastName, int grade)
			: base(firstName, lastName)
		{
			Grade = grade;
		}

		public int Grade
		{
			get { return grade; }
			private set
			{
				if(value < 0 || value > maxGrade)
				{
					throw new ArgumentOutOfRangeException("value", "Invalid grade value.");
				}

				grade = value;
			}
		}
	
		public void PrintInfo()
		{
			Console.WriteLine("{0} {1} is {2} grade.", FirstName, LastName, Grade);
		}
	}
}
