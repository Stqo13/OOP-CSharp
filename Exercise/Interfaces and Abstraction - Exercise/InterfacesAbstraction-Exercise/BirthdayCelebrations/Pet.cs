using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BirthdayCelebrations
{
    public class Pet : INameable, IBirthable
    {
        private string name;
        private string birthday;
        public Pet(string name, string birthday)
        {
            this.Name = name;
            this.Birthday = birthday;
        }
        public string Name { get; set; }
        public string Birthday { get; set; }
    }
}
