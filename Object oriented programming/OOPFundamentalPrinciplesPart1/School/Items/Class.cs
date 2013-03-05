using System.Collections.Generic;

namespace School.Items
{
	public class Class : IDescriptionable
	{
		public string Id { get; private set; }

		public string Description { get; set; }

		public List<Student> Students { get; set; }

		public Class(string id)
		{
			Id = id;
			Students = new List<Student>();
		}
	}
}