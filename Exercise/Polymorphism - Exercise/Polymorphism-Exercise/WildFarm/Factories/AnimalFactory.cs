using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WildFarm.Factories.Interfaces;
using WildFarm.Models.Animals;
using WildFarm.Models.Interfaces;

namespace WildFarm.Factories
{
    public class AnimalFactory : IAnimalFactory
    {
        public IAnimal CreateAnimal(string[] animalInfo)
        {
            string typeOfAnimal = animalInfo[0];
            switch (typeOfAnimal)
            {
                case "Owl":
                    string owlName = animalInfo[1];
                    double owlWeight = double.Parse(animalInfo[2]);
                    double owlWingSize = double.Parse(animalInfo[3]);
                    return new Owl(owlName, owlWeight, owlWingSize);
                case "Hen":
                    string henName = animalInfo[1];
                    double henWeight = double.Parse(animalInfo[2]);
                    double henWingSize = double.Parse(animalInfo[3]);
                    return new Hen(henName, henWeight, henWingSize);
                case "Mouse":
                    string mouseName = animalInfo[1];
                    double mouseWeight = double.Parse(animalInfo[2]);
                    string mouseLivingRegion = animalInfo[3];
                    return new Mouse(mouseName, mouseWeight, mouseLivingRegion);
                case "Dog":
                    string dogName = animalInfo[1];
                    double dogWeight = double.Parse(animalInfo[2]);
                    string dogLivingRegion = animalInfo[3];
                    return new Dog(dogName, dogWeight, dogLivingRegion);
                case "Cat":
                    string catName = animalInfo[1];
                    double catWeight = double.Parse(animalInfo[2]);
                    string catLivingRegion = animalInfo[3];
                    string catBreed = animalInfo[4];
                    return new Cat(catName, catWeight, catLivingRegion, catBreed);
                case "Tiger":
                    string tigerName = animalInfo[1];
                    double tigerWeight = double.Parse(animalInfo[2]);
                    string tigerLivingRegion = animalInfo[3];
                    string tigerBreed = animalInfo[4];
                    return new Tiger(tigerName, tigerWeight, tigerLivingRegion, tigerBreed);
                default:
                    throw new ArgumentException("Ivalid animal type");
            }
        }
    }
}
