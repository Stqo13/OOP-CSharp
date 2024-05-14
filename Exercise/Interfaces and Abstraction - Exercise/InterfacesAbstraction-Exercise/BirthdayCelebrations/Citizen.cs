using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayCelebrations
{
    public class Citizen : INameable, IIdentifiable, IBirthable
    {
        private int age;
        private string name;      
        private string id;
        private string birthday;
        public Citizen(int age, string name, string id, string birthday)
        {
            this.Age = age;
            this.Name = name; 
            this.Id = id;
            this.Birthday = birthday;
        }
        public int Age { get; set; }
        public string Name { get ; set; }
        public string Id { get; set; }
        public string Birthday { get; set; }
    }
}
