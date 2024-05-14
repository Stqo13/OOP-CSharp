using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class Product
    {
        public Product(string name, decimal price)
        {
            Name = name;
			Price = price;
        }
        private string name;

		public string Name
		{
			get { return name; }
			set { name = value; }
		}
		private decimal price;

		public decimal Price
		{
			get { return price; }
			set { price = value; }
		}

	}
}
