using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaCalories
{
    public class Dough
    {
        private const double BaseGrams = 2.0;
		private readonly Dictionary<string, double> flourTypeCalories;
        private readonly Dictionary<string, double> bakingTechniqueCalories;
        public Dough(string flourType, string bakingTechnique, double weight)
        {
            flourTypeCalories = 
                new Dictionary<string, double> { { "white", 1.5 }, { "wholegrain", 1.0 } };

            bakingTechniqueCalories =
                new Dictionary<string, double> { { "crispy", 0.9 }, { "chewy", 1.1 }, { "homemade", 1.0 } };
            
            this.FlourType = flourType;
            this.BakingTechnique = bakingTechnique;
            this.Weight = weight;
        }
        private string flourType;

        public string FlourType
        {
            get { return flourType; }
            private set 
            {
                if (!flourTypeCalories.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                flourType = value.ToLower(); 
            }
        }
        private string bakingTechnique;

        public string BakingTechnique
        {
            get { return bakingTechnique; }
            private set 
            {
                if (!bakingTechniqueCalories.ContainsKey(value.ToLower()))
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                bakingTechnique = value.ToLower(); 
            }
        }
        private double weight;

        public double Weight
        {
            get { return weight; }
            private set 
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                weight = value; 
            }
        }
        public double Calroies 
        {
            get
            {
                double flourTypeModifier = flourTypeCalories[FlourType];
                double bakingTechniquesModifier = bakingTechniqueCalories[BakingTechnique];
                return BaseGrams * this.weight * flourTypeModifier * bakingTechniquesModifier;
            }
        }
    }
}
