using System;
using System.Collections.Generic;
using System.Linq;

namespace SortStudentsNames
{
	class Program
	{
		static void Main()
		{
			var students = new[]
			{
				new Student { FirstName = "Aleks", LastName = "Aleksieva" },
				new Student { FirstName = "Gosho", LastName = "Goshev" },
				new Student { FirstName = "Gosho", LastName = "Ganchev" },
				new Student { FirstName = "Gosho", LastName = "Borisov" },
				new Student { FirstName = "Aleks", LastName = "Raeva" },
				new Student { FirstName = "Whitney", LastName = "Houston" },
			};

			var sortedByLambda = SortByLambda(students);
			PrintStudents("Ordered with Lambda", sortedByLambda);
			Console.WriteLine();

			var sortedByLinq = SortByLinq(students);
			PrintStudents("Ordered with Linq", sortedByLinq);
		}

		private static void PrintStudents(string title, Student[] students)
		{
			Console.WriteLine(title);
			foreach (var student in students)
			{
				Console.WriteLine("- {0} {1}", student.FirstName, student.LastName);
			}
		}

		private static Student[] SortByLambda(IEnumerable<Student> students)
		{
			return students.OrderByDescending(s => s.FirstName).ThenByDescending(s => s.LastName).ToArray();
		}

		private static Student[] SortByLinq(IEnumerable<Student> students)
		{
			var filteredStudents =
				from s in students
				orderby s.LastName descending 
				orderby s.FirstName descending 
				select s;

			return filteredStudents.ToArray();
		}
	}
}