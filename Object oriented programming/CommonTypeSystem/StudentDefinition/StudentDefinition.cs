using System;
using StudentDefinition.Items;

namespace StudentDefinition
{
	internal class StudentDefinition
	{
		private static void Main(string[] args)
		{
			var student1 = new Student("Ivan", "Ivanov", "902381111");

			//Equals of same objects different references
			var student1Same = new Student("Ivan", "Ivanov", "902381111");
			Console.WriteLine("Different objects with same properties are equals -> " + student1.Equals(student1Same));
			Console.WriteLine();

			//Deep clone example
			Student student1Copy = student1.Clone();
			Console.WriteLine("Clone objectand the original are equals -> " + student1.Equals(student1Copy));
			Console.WriteLine("Clone objectand reference the original -> " + ReferenceEquals(student1, student1Copy));
			Console.WriteLine();

			//Compare objects
			var student2 = new Student("Ivan", "Ivanov", "902389999");
			var student3 = new Student("Ivan", "Yankov", "883123143");
			CompareStudents(student1, student2);
			CompareStudents(student1, student3);
			CompareStudents(student2, student3);
			Console.WriteLine();

			//ToString method
			Console.WriteLine(student1.ToString());
			Console.WriteLine();

			//ToString method for object with more setted properties
			student1.MiddleName = "Georgiev";
			student1.MobilePhone = "0889332244";
			student1.Faculty = Faculty.Bachalor;
			student1.University = University.MassachusettsInstituteOfTechnology;
			Console.WriteLine(student1.ToString());
			Console.WriteLine();
		}

		private static void CompareStudents(Student student1, Student student2)
		{
			Console.WriteLine("Compare: \r\n\t{0} and \r\n\t{1} \r\n\t=> {2}", student1, student2,
			                  GetCompareString(student1.CompareTo(student2)));
		}

		private static string GetCompareString(int compareResult)
		{
			switch (compareResult)
			{
				case -1:
					return "First object is before the second one.";
				case 0:
					return "Objects are equal.";
				case 1:
					return "Second object before the first one.";
				default:
					return "Unknown order.";
			}
		}
	}
}