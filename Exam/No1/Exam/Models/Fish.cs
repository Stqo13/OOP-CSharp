using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Utilities.Messages;

namespace NauticalCatchChallenge.Models
{
    public abstract class Fish : IFish
    {
        public Fish(string name, double points, int timeToCatch)
        {
            this.Name = name;
            this.Points = points;
            this.TimeToCatch = timeToCatch;
        }
        private string name;

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.FishNameNull);
                }
                name = value;
            }
        }
        private double points;

        public double Points
        {
            get { return points; }
            private set
            {
                if (value < 1 || value > 10)
                {
                    throw new ArgumentException(ExceptionMessages.PointsNotInRange);
                }
                points = Math.Round(value, 1);
            }
        }
        private int timeToCatch;

        public int TimeToCatch
        {
            get { return timeToCatch; }
            private set { timeToCatch = value; }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"{this.GetType().Name}: {Name} [ Points: {Points}, Time to Catch: {TimeToCatch} seconds ]");
            return sb.ToString().TrimEnd();
        }
    }
}
