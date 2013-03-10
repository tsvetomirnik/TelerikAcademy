using System;
using System.Text;
using System.Text.RegularExpressions;

namespace StudentDefinition.Items
{
	internal class Student : ICloneable, IComparable<Student>
	{
		private string _SSN;
		private string _email;
		private string _firstName;
		private string _lastName;
		private string _middleName;
		private string _mobilePhone;
		private string _permanentAddress;

		public Student(string firstName, string lastName, string ssn)
		{
			FirstName = firstName;
			LastName = lastName;
			SSN = ssn;
		}

		public string FirstName
		{
			get { return _firstName; }
			set
			{
				if (string.IsNullOrEmpty(value.Trim()))
				{
					throw new ArgumentException("Invalid or empty value.");
				}

				_firstName = value;
			}
		}

		public string MiddleName
		{
			get { return _middleName; }
			set
			{
				if (string.IsNullOrEmpty(value.Trim()))
				{
					throw new ArgumentException("Invalid or empty value.");
				}

				_middleName = value;
			}
		}

		public string LastName
		{
			get { return _lastName; }
			set
			{
				if (string.IsNullOrEmpty(value.Trim()))
				{
					throw new ArgumentException("Invalid or empty value.");
				}

				_lastName = value;
			}
		}

		public string SSN
		{
			get { return _SSN; }
			private set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}

				//SSN is 9 gidit number
				if (value.Length != 9)
				{
					throw new ArgumentException("Invalid SSN length");
				}

				foreach (char symbol in value)
				{
					if (!char.IsDigit(symbol))
					{
						throw new ArgumentException("Invalid symbols in SSN value.");
					}
				}

				_SSN = value;
			}
		}

		public string PermanentAddress
		{
			get { return _permanentAddress; }
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}

				_permanentAddress = value;
			}
		}

		public string MobilePhone
		{
			get { return _mobilePhone; }
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}

				foreach (char symbol in value)
				{
					if (!char.IsDigit(symbol))
					{
						throw new ArgumentException("Invalid symbols in phone number.");
					}
				}

				_mobilePhone = value;
			}
		}

		public string Email
		{
			get { return _email; }
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}

				var emailValidation = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
				Match match = emailValidation.Match(value);
				if (match.Success == false)
				{
					throw new FormatException("Invalid email format");
				}

				_email = value;
			}
		}

		public ushort? Course { get; set; }

		public Specialty? Specialty { get; set; }

		public University? University { get; set; }

		public Faculty? Faculty { get; set; }

		object ICloneable.Clone()
		{
			return Clone();
		}

		public int CompareTo(Student other)
		{
			string firstStudentEntireName = (FirstName + MiddleName + LastName).Replace(" ", string.Empty);
			string secondStudentEntireName = (other.FirstName + other.MiddleName + other.LastName).Replace(" ", string.Empty);
			if (firstStudentEntireName != secondStudentEntireName)
			{
				return String.Compare(firstStudentEntireName, secondStudentEntireName, StringComparison.InvariantCulture);
			}

			return String.Compare(SSN, other.SSN, StringComparison.InvariantCulture);
		}

		public override bool Equals(object obj)
		{
			var secondStudent = obj as Student;
			if (secondStudent == null)
			{
				return false;
			}

			if (FirstName.Equals(secondStudent.FirstName) &&
			    LastName.Equals(secondStudent.LastName) &&
			    SSN.Equals(secondStudent.SSN))
			{
				return true;
			}

			return false;
		}

		public static bool operator ==(Student student1, Student student2)
		{
			return Equals(student1, student2);
		}

		public static bool operator !=(Student student1, Student student2)
		{
			return !Equals(student1, student2);
		}

		public override int GetHashCode()
		{
			return SSN.GetHashCode();
		}

		public Student Clone()
		{
			return (Student) MemberwiseClone();
		}

		public override string ToString()
		{
			var result = new StringBuilder("Student:[");
			result.Append(string.Format("FirstName:[{0}]", FirstName));

			if (!string.IsNullOrEmpty(MiddleName))
				result.Append(string.Format(" MiddleName:[{0}]", MiddleName));

			result.Append(string.Format(" LastName:[{0}]", LastName));
			result.Append(string.Format(" SSN:[{0}]", SSN));

			if (!string.IsNullOrEmpty(PermanentAddress))
				result.Append(string.Format(" PermanentAddress:[{0}]", PermanentAddress));

			if (!string.IsNullOrEmpty(MobilePhone))
				result.Append(string.Format(" MobilePhone:[{0}]", MobilePhone));

			if (!string.IsNullOrEmpty(Email))
				result.Append(string.Format(" Email:[{0}]", Email));

			if (Course != null)
				result.Append(string.Format(" Course:[{0}]", Course));

			if (Specialty != null)
				result.Append(string.Format(" Specialty:[{0}]", Specialty));

			if (University != null)
				result.Append(string.Format(" University:[{0}]", University));

			if (Faculty != null)
				result.Append(string.Format(" Faculty:[{0}]", Faculty));

			result.Append("]");
			return result.ToString();
		}
	}
}