using System;
using System.Collections.Generic;
using System.Linq;
using Workers.Items;

namespace Workers
{
	class Workers
	{
		static void Main()
		{
			var students = new List<Student>()
			{
				new Student("Ivan", "Ivanov", 1),
				new Student("Aleks", "Sashev", 3),
				new Student("Kosta", "Kostov", 5),
				new Student("Dimityr", "Garbev", 2),
				new Student("Boris", "Borisov", 2),
				new Student("Cvetanka", "Rizova", 3),
				new Student("Maria", "Grozdeva", 7)
			};

			var orderedStudents = students.OrderBy(x => x.Grade);
			PrintTitle("Students sorted by grade");
			foreach (var orderedStudent in orderedStudents)
			{
				orderedStudent.PrintInfo();
			}

			Console.WriteLine();

			var workers = new List<Worker>()
			{
				new Worker("Hristo", "Ivanov", 200M, 5),
				new Worker("Ivelin", "Stefanov", 250M, 6),
				new Worker("Gabi", "Babeva", 250.50M, 5.5),
				new Worker("Atanas", "Ivaylov", 400, 8),
				new Worker("Stefan", "Borisov", 350, 6),
				new Worker("Cvetanka", "Mihailova", 280, 5),
				new Worker("Koceto", "Nikolov", 180, 4)
			};

			var orderedWorkers = workers.OrderBy(x => x.MoneyPerHour());
			PrintTitle("Workers sorted by hours salary");
			foreach (var orderedWorker in orderedWorkers)
			{
				orderedWorker.PrintInfo();
			}

			Console.WriteLine();

			var humans = new List<Human>();
			humans.AddRange(students);
			humans.AddRange(workers);

			var orderedHumans = humans.OrderBy(x => x.FirstName).ThenBy(x => x.LastName);
			PrintTitle("Humans sorted by name");
			foreach (var human in orderedHumans)
			{
				Console.WriteLine("{0} {1}", human.FirstName, human.LastName);
			}
		}

		private static void PrintTitle(string title)
		{
			Console.WriteLine(title);
			Console.WriteLine(new string('-', title.Length));
		}
	}
}
