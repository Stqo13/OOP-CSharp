using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Person
{
    public class Person
    {
        public Person(string name, int age)
        {
			Name = name;
			Age = age;
        }
        private string name;

		public string Name
		{
			get { return name; }
			set { name = value; }
		}
		private int age;

		public int Age
		{
			get { return age; }
			set { age = value; }
		}
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append($"Name: {this.Name}, Age: {this.Age}");
            //stringbuilder.append(string.format("name: {0}, age: {1}",
            //             this.name,
            //             this.age));
            return stringBuilder.ToString();

        }
    }
}
