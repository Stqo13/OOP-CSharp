using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NauticalCatchChallenge.Models
{
    public class PredatoryFish : Fish
    {
        private const int TIME_TO_CATCH = 60;
        public PredatoryFish(string name, double points)
            : base(name, points, TIME_TO_CATCH)
        {
        }
    }
}
