using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsInfo
{
    public class Person
    {
        public Person(string firstName, string lastName, int age, decimal salary)
        {
			this.FirstName = firstName;
			this.LastName = lastName;
			this.Age = age;
			this.Salary = salary;
        }
        private string firstName;

		public string FirstName
		{
			get { return firstName; }
			private set 
			{
				if (value.Length <3)
				{
					throw new ArgumentException("First name cannot contain fewer than 3 symbols!");
				}
				firstName = value; 
			}
		}
		private string lastName;

		public string LastName
		{
			get { return lastName; }
			private set 
			{
                if (value.Length < 3)
                {
                    throw new ArgumentException("Last name cannot contain fewer than 3 symbols!");
                }
                lastName = value; 
			}
		}
		private int age;

		public int Age
		{
			get { return age; }
			private set 
			{
				if (value<=0)
				{
					throw new ArgumentException("Age cannot be zero or a negative integer!");
				}
				age = value; 
			}
		}
		private decimal salary;

		public decimal Salary
		{
			get { return salary; }
			private set 
			{
				if (value<0)
				{
					throw new ArgumentException("Salary cannot be less than 650 leva!");
				}
				salary = value; 
			}
		}

		public void IncreaseSalary(decimal percentage)
		{
			if (this.Age>=30)
			{
				this.Salary += this.Salary * percentage/ 100;
			}
			else
			{
				this.Salary += this.Salary * percentage/ 200;
			}
		}

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} receives {this.Salary:f2} leva.";
        }
    }
}
