using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding
{
    public class Warrior : BaseHero
    {
        public Warrior(string name , int power)
            : base(name, power)
        {
            
        }

        public override string CastAbility()
        {
            return $"Warrior - {base.Name} hit for {Power} damage";
        }
    }
}
