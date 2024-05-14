using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raiding
{
    public class Druid : BaseHero
    {

        public Druid(string name, int power)
            : base(name, power)
        {

        }

        public override string CastAbility()
        {
            return $"Druid - {base.Name} healed for {Power}";
        }
    }
}
