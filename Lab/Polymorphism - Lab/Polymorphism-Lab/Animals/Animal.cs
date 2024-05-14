using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Animals
{
    public class Animal
    {
        public Animal(string name, string favouriteFood)
        {
            this.Name = name;
			this.FavouriteFood = favouriteFood;
        }
		private string name;

		public string Name
		{
			get { return name; }
			private set { name = value; }
		}
		private string favouriteFood;

		public string FavouriteFood
		{
			get { return favouriteFood; }
			private set{ favouriteFood = value; }
		}

        public virtual string ExplainSelf()
        {
            return $"I am {this.Name} and my fovourite food is {this.FavouriteFood}";
        }
	}
}
