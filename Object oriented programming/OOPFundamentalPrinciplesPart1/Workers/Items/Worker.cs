using System;

namespace Workers.Items
{
	class Worker : Human
	{
		public double workHoursPerDay;
		public decimal weekSalary;

		public Worker(string firstName, string lastName, decimal weekSalary, double workHoursPerDay)
			: base(firstName, lastName)
		{
			WeekSalary = weekSalary;
			WorkHoursPerDay = workHoursPerDay;
		}

		public double WorkHoursPerDay 
		{ 
			get { return workHoursPerDay; } 
			set
			{
				if(value < 0)
				{
					throw new ArgumentOutOfRangeException("value", "Working hours cannot be a negative value.");
				}

				workHoursPerDay = value;
			}
		}

		public decimal WeekSalary 
		{
			get { return weekSalary; } 
			set
			{
				if(value < 0)
				{
					throw new ArgumentOutOfRangeException("value", "Week salary cannot be a negative value.");
				}

				weekSalary = value;
			}
		}

		public decimal MoneyPerHour()
		{
			return WeekSalary/(decimal) (7*WorkHoursPerDay);
		}

		public void PrintInfo()
		{
			Console.WriteLine("{0} {1} has ${2} salary.", FirstName, LastName, MoneyPerHour());
		}
	}
}
