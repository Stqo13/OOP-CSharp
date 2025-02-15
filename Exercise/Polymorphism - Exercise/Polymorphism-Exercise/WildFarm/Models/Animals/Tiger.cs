﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Foods;

namespace WildFarm.Models.Animals
{
    public class Tiger : Feline
    {
        private const double TigerWeightMultiplier = 1.0;
        public Tiger(string name, double weight, string livingRegion, string breed) 
            : base(name, weight, livingRegion, breed)
        {
        }

        protected override double WeightMultiplier
        {
            get
            {
                return TigerWeightMultiplier;
            }
        }

        protected override IReadOnlyCollection<Type> PreferredFoodTypes
        {
            get
            {
                return new HashSet<Type> { typeof(Meat)};
            }
        }
        public override string MakeNoise()
        {
            return "ROAR!!!";
        }
    }
}
