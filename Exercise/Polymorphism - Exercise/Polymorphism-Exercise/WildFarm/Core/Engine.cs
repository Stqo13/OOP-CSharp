using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Core.Interfaces;
using WildFarm.Factories.Interfaces;
using WildFarm.IO;
using WildFarm.IO.Interfaces;
using WildFarm.Models.Interfaces;

namespace WildFarm.Core
{
    public class Engine : IEngine
    {
        private readonly IReader reader = new ConsoleReader();
        private readonly IWriter writer = new ConsoleWriter();

        private readonly IAnimalFactory animalFactory;
        private readonly IFoodFactory foodFactory;

        private readonly ICollection<IAnimal> animals;

        public Engine(IReader reader, IWriter writer, IAnimalFactory animalFactory, IFoodFactory foodFactory)
        {
            this.reader = reader;
            this.writer = writer;
            this.animalFactory = animalFactory;
            this.foodFactory = foodFactory;
            this.animals = new List<IAnimal>();
        }

        public void Run()
        {
            string input = reader.ReadLine();
            while (input != "End")
            {
                IAnimal animal = null;
                try
                {
                    animal = CreateAnimal(input);
                    IFood food = CreateFood();
                    writer.WriteLine(animal.MakeNoise());
                    animal.Eat(food);
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch
                {
                    throw;
                }
                animals.Add(animal);
                input = reader.ReadLine();
            }

            foreach (var item in animals)
            {
                Console.WriteLine(item.ToString());
            }
        }

        private IAnimal CreateAnimal(string input)
        {
            string[] animalInfo = 
                input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            IAnimal animal = animalFactory.CreateAnimal(animalInfo);

            return animal;
        }

        private IFood CreateFood()
        {
            string[] foodInfo =
                reader.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

            IFood food = foodFactory.CreateFood(foodInfo[0], int.Parse(foodInfo[1]));

            return food;
        }
    }
}
