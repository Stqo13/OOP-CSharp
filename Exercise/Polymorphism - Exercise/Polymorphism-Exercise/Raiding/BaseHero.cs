using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding
{
    public abstract class BaseHero
    {
        public BaseHero(string name, int power)
        {
            this.Name = name;
			this.Power = power;
        }
        private string name;

		public string Name
		{
			get { return name; }
			set { name = value; }
		}
		private int power;

		public int Power
		{
			get { return power; }
			set { power = value; }
		}
		public abstract string CastAbility();
		
    }
}
