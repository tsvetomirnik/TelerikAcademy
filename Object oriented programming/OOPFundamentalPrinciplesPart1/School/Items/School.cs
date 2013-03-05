using System.Collections.Generic;

namespace School.Items
{
	public class School
	{
		public string Name { get; set; }

		public string Address { get; set; }

		public List<Student> Students { get; set; }

		public List<Class> Classes { get; set; }

		public List<Teacher> Teachers { get; set; }

		public List<Discipline> Disciplines { get; set; }
	
		public School(string name)
		{
			Name = name;
			Students = new List<Student>();
			Classes = new List<Class>();
			Teachers = new List<Teacher>();
			Disciplines = new List<Discipline>();
		}
	}
}