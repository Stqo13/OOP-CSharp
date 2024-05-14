using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShortage
{
    public class Citizen : INameable, IAgeable, IBuyer
    {
        private const int FoodCount = 10;
        private string name;
        private int age;
        private int food;
        private string id;
        private string birthday;
        public Citizen(string name, int age, string id, string birthday)
        {
            this.Name = name;
            this.Age = age;
            this.Id = id;
            this.Birthday = birthday;
        }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public int Food { get; private set; }
        public string Id { get; private set; }
        public string Birthday {  get; private set; }

        public void BuyFood()
        {
            this.Food += FoodCount;
        }
    }
}
