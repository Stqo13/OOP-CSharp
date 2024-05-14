using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding
{
    public class Rogue : BaseHero
    {
        public Rogue(string name, int power)
            : base(name, power)
        {

        }

        public override string CastAbility()
        {
            return $"Rogue - {base.Name} hit for {Power} damage";
        }
    }
}
