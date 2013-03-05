using System;
using System.Collections.Generic;

namespace School.Items
{
	public class Teacher : IPerson, IDescriptionable
	{
		public string FirstName { get; set; }

		public string LastName { get; set; }

		public string Description { get; set; }

		public List<Discipline> Disciplines { get; set; }

		public Teacher(string firstName, string lastName)
		{
			FirstName = firstName;
			LastName = lastName;
			Disciplines = new List<Discipline>();
		}

		public void Teach(Class target, Discipline discipline)
		{
			if (!Disciplines.Contains(discipline))
			{
				throw new Exception("Unable to teach discipline not in current instance discipline range.");
			}

			throw new NotImplementedException("Not implemeneted Teach method.");
		}
	}
}