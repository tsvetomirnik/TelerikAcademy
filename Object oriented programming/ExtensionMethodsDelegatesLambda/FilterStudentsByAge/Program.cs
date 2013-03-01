using System;
using System.Linq;

namespace FilterStudentsByAge
{
	class Program
	{
		static void Main()
		{
			var students = new[]
			{
				new { FirstName = "Ganio", Age = 11 },
				new { FirstName = "Gosho", Age = 18 },
				new { FirstName = "Aleks", Age = 31 },
				new { FirstName = "Whitney", Age = 23 },
			};

			var filteredStudents =
				from s in students
				where s.Age >= 18 && s.Age <= 24
				select s;

			Console.WriteLine("Searching students with age between 18 and 24...");
			Console.WriteLine("{0} students founded:",
				filteredStudents.Count());
			
			foreach (var student in filteredStudents)
			{
				Console.WriteLine("- {0} - {1} years old", student.FirstName, student.Age);
			}
		}
	}
}
