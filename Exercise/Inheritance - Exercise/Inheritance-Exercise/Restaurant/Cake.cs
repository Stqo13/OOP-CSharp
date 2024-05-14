using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant
{
    public class Cake : Dessert
    {
        public Cake(string name)
            :base(name, CakePrice, Grams, Calories)
        {
            
        }
        private const double Grams = 250;

        private const double Calories = 1000;

        private const decimal CakePrice = 5m;
    }
}
