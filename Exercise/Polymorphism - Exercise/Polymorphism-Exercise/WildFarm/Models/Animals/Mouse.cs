using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Mouse : Mammal
    {
        private const double MouseWeightMultiplier = 0.10;
        public Mouse(string name, double weight, string livingRegion) 
            : base(name, weight, livingRegion)
        {
        }

        protected override double WeightMultiplier
        {
            get
            {
                return MouseWeightMultiplier;
            }
        }

        protected override IReadOnlyCollection<Type> PreferredFoodTypes
        {
            get
            {
                return new HashSet<Type> { typeof(Vegetable), typeof(Fruit)};
            }
        }
        public override string MakeNoise()
        {
            return "Squeak";
        }

        public override string ToString()
        {
            return base.ToString() + $"{Weight}, {LivingRegion}, {FoodEaten}]";
        }
    }
}
