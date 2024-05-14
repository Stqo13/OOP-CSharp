using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Models.Interfaces;

namespace WildFarm.Models.Animals
{
    public abstract class Animal : IAnimal
    {
        public Animal(string name, double weight)
        {
            this.Name = name;
            this.Weight = weight;
        }
        public string Name { get; private set; }
        public double Weight { get; private set; }
        public int FoodEaten { get; private set; }
        protected abstract double WeightMultiplier { get; }
        protected abstract IReadOnlyCollection<Type> PreferredFoodTypes { get; }
        public abstract string MakeNoise();

        public void Eat(IFood food)
        {
            if (!PreferredFoodTypes.Any(pf => food.GetType().Name == pf.Name))
            {
                throw new ArgumentException($"{this.GetType().Name} does not eat {food.GetType().Name}!");
            }
            Weight += food.Quantity * WeightMultiplier;
            FoodEaten += food.Quantity;
        }

        public override string ToString()
        {
            return $"{GetType().Name} [{Name}, ";
        }
    }
}
