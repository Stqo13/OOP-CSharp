using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingSpree
{
    public class Person
    {
        public Person(string name, decimal money)
        {
            this.Name = name;
			this.Money = money;
			bagOfProducts = new List<Product>();
        }
        private string name;

		public string Name
		{
			get { return name; }
			private set 
			{
				if (string.IsNullOrWhiteSpace(value))
				{
					throw new ArgumentException("Name cannot be empty");
				}
				name = value; 
			}
		}
		private decimal money;

		public decimal Money
		{
			get { return money; }
			private set 
			{
				if (value<0)
				{
					throw new ArgumentException("Money cannot be negative");
				}
				money = value; 
			}
		}
		private List<Product> bagOfProducts;

		public IReadOnlyCollection<Product> BagOgProducts
		{ 
			get { return bagOfProducts.AsReadOnly(); } 
		}
		public void AddItem(Product product)
		{
			if (this.Money < product.Cost)
			{
                Console.WriteLine($"{this.Name} can't afford {product.Name}");
				return;
            }
            bagOfProducts.Add(product);
            Console.WriteLine($"{this.Name} bought {product.Name}");
            this.Money -= product.Cost;
        }
        public override string ToString()
        {
			string productsString = string.Empty;
			if (bagOfProducts.Any())
			{
				productsString = string.Join(", ", bagOfProducts);
			}
			else
			{
				productsString = "Nothing bought";
            }
			return $"{this.Name} - {productsString}";
        }
    }
}
