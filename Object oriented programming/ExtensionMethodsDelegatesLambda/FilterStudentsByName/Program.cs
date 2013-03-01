using System;
using System.Linq;

namespace FilterStudentsByName
{
	class Program
	{
		static void Main()
		{
			var students = new[]
			{
				new { FirstName = "Ganio", LastName = "Goshev" },
				new { FirstName = "Gosho", LastName = "Ganchev" },
				new { FirstName = "Aleks", LastName = "Raeva" },
				new { FirstName = "Whitney", LastName = "Houston" },
			};

			var filteredStudents =
				from s in students
				where s.FirstName.CompareTo(s.LastName) == -1
				select s;

			Console.WriteLine("Searching students with first alphabetically before last name...");
			Console.WriteLine("{0} students founded:",
				filteredStudents.Count());
			
			foreach (var student in filteredStudents)
			{
				Console.WriteLine("- {0} {1}", student.FirstName, student.LastName);
			}
		}
	}
}