using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance_Lab
{
    public class Animal
    {
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
		public void DoThings()
		{
            Console.WriteLine("I am doing animal things");
        }
	}
}
