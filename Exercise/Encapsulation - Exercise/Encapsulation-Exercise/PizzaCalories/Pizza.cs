using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories
{
    public class Pizza
    {
        public Pizza(string name)
        {
            this.Name = name;
            toppings = new List<Topping>();
        }
        private string name;

		public string Name
		{
			get { return name; }
			private set 
			{
				if (value.Length < 1 || value.Length > 15)
				{
					throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
				}
				name = value; 
			}
		}
		private List<Topping> toppings;

		public IReadOnlyCollection<Topping> Toppings
		{
			get { return toppings.AsReadOnly(); }
		}

		private Dough dough;

		public Dough Dough
		{
			get { return dough; }
			set { dough = value; }
		}

		public double Calories
		{
			get
			{
				double toppingCaloriesSum = 0;
				foreach (var item in toppings)
				{
					toppingCaloriesSum += item.Calories;
				}
				return Dough.Calroies + toppingCaloriesSum;
			}
		}
		public void AddTopping(Topping topping)
		{
			if (toppings.Count < 0 || toppings.Count > 10)
			{
				throw new ArgumentException("Number of toppings should be in range [0..10].");
			}
			else
			{
				toppings.Add(topping);
			}
		}
        public override string ToString()
        {
			return $"{this.Name} - {this.Calories:f2} Calories.";
        }
    }
}
