using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inheritance_Lab
{
    public class Cat : Animal
    {
		private string color;

		public string Color
		{
			get { return color; }
			set { color = value; }
		}

	}
}
