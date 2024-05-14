using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Foods;
using Type = System.Type;

namespace WildFarm.Models.Animals
{
    public class Hen : Bird
    {
        private const double HenWeightMultiplier = 0.35;
        public Hen(string name, double weight, double wingSize) 
            : base(name, weight, wingSize)
        {
        }

        protected override double WeightMultiplier
        {
            get
            {
                return HenWeightMultiplier;
            }
        }

        protected override IReadOnlyCollection<Type> PreferredFoodTypes
        {
            get
            {
                return new HashSet<Type> { typeof(Meat), typeof(Fruit), typeof(Vegetable), typeof(Seeds) };
            }
        }
        public override string MakeNoise()
        {
            return "Cluck";
        }
    }
}
