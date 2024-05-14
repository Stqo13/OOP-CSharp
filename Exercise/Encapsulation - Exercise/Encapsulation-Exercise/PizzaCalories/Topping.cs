using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories
{
    public class Topping
    {
        private const double BaseGrams = 2.0;
        private readonly Dictionary<string, double> toppingTypeCalories;
        public Topping(string toppingType, double weight)
        {
            toppingTypeCalories =
               new Dictionary<string, double> 
               { 
                   { "meat", 1.2 }, 
                   { "veggies", 0.8 }, 
                   { "cheese", 1.1 }, 
                   { "sauce", 0.9 } 
               };
            this.ToppingType = toppingType;
            this.Weight = weight;
        }
        private string toppingType;

        public string ToppingType
        {
            get { return toppingType; }
            private set 
            {
                if (!toppingTypeCalories.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                toppingType = value; 
            }
        }
        private double weight;

        public double Weight
        {
            get { return weight; }
            private set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{this.ToppingType} weight should be in the range [1..50].");
                }
                weight = value;
            }
        }
        public double Calories 
        {
            get
            {
                double toppingTypesModifier = toppingTypeCalories[ToppingType.ToLower()];
                return BaseGrams * this.Weight * toppingTypesModifier;
            }
        }
    }
}
