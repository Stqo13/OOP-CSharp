using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodShortage
{
    public class Rebel :  IBuyer
    {
        private const int FoodCount = 5;
        private string name;
        private int age;
        private int food;
        private string group;
        public Rebel(string name, int age, string group)
        {
            this.Name = name;
            this.Age = age;
            this.Group = group;
        }
        public string Name { get; private set; }
        public int Age { get; private set; }
        public int Food { get; private set; }
        public string Group { get; private set; }

        public void BuyFood()
        {
            this.Food += FoodCount;
        }
    }
}
