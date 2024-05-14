using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding
{
    public class Paladin : BaseHero
    {
        public Paladin(string name, int power)
            : base(name, power)
        {

        }
        public override string CastAbility()
        {
            return $"Paladin - {base.Name} healed for {Power}";
        }
    }
}
