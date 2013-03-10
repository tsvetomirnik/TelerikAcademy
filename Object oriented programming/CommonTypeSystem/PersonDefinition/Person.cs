using System;

namespace PersonDefinition
{
	class Person
	{
		private string _name;
		private byte? _age;

		public Person(string name)
		{
			Name = name;
		}

		public string Name
		{
			get { return _name; }
			private set
			{
				if(string.IsNullOrEmpty(value))
				{
					throw new Exception("Invalid name value.");
				}

				_name = value;
			}
		}

		public byte? Age
		{
			get { return _age; }
			set { _age = value; }
		}

		public override string ToString()
		{
			return string.Format("Person:[Name:[{0}], Age[{1}]]",
				Name,
				Age==null? "Unknown": Age.ToString());
		}
	}
}
