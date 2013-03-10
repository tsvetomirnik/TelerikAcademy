using School.Items;

namespace School
{
	class School
	{
		static void Main()
		{
			var strudent1 = new Student("f44234", "Tsvetomir", "Nikolov");
			var strudent2 = new Student("f54930", "Gosho", "Gochev");
			var strudent3 = new Student("f48120", "Emil", "Stoilov");

			var firstAClass = new Class("123");
			firstAClass.Students.Add(strudent1);
			firstAClass.Students.Add(strudent2);
			firstAClass.Students.Add(strudent3);
			firstAClass.Description = "Worst class ever";

			var math = new Discipline("Math") { ExercisesNumber = 20, LecturesNumber = 30 };
			var literature = new Discipline("Literature") { LecturesNumber = 50 };

			var teacher = new Teacher("Strog", "Tiichyr");
			teacher.Description = "Best teacher for your child.";
			teacher.Disciplines.Add(math);
			teacher.Disciplines.Add(literature);

			var school = new Items.School("First English School");
			school.Address = "Sofia Belite Brezi 33";
			school.Students.Add(strudent1);
			school.Students.Add(strudent2);
			school.Students.Add(strudent3);
			school.Teachers.Add(teacher);
			school.Classes.Add(firstAClass);
			school.Disciplines.Add(literature);
		}
	}
}