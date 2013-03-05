namespace School.Items
{
	public class Discipline : IDescriptionable
	{
		public string Name { get; set; }

		public string Description { get; set; }

		public int LecturesNumber { get; set; }

		public int ExercisesNumber { get; set; }

		public Discipline(string name)
		{
			Name = name;
		}
	}
}