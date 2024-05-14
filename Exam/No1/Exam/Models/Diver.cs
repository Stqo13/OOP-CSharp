using NauticalCatchChallenge.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NauticalCatchChallenge.Utilities.Messages;

namespace NauticalCatchChallenge.Models
{
    public abstract class Diver : IDiver
    {
        public Diver(string name, int oxygenLevel)
        {
            this.Name = name;
            this.OxygenLevel = oxygenLevel;
            this.CompetitionPoints = 0;
            this.HasHealthIssues = false;
            catchList = new List<string>();
        }
        private string name;

        public string Name
        {
            get { return name; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(ExceptionMessages.DiversNameNull);
                }
                name = value;
            }
        }


        private int oxygenLevel;

        public int OxygenLevel
        {
            get { return oxygenLevel; }
            protected set
            {
                oxygenLevel = Math.Max(0, value);
            }
        }

        private List<string> catchList;

        public IReadOnlyCollection<string> Catch
        {
            get { return catchList.AsReadOnly(); }
        }

        private double competitionPoints;

        public double CompetitionPoints
        {
            get
            {
                return Math.Round(competitionPoints, 1);
            }
            private set
            {
                competitionPoints = value;
            }
        }


        private bool hasHealthIssues;

        public bool HasHealthIssues
        {
            get { return hasHealthIssues; }
            private set
            {
                hasHealthIssues = false;
            }
        }


        public void Hit(IFish fish)
        {
            OxygenLevel -= fish.TimeToCatch;
            catchList.Add(fish.Name);
            CompetitionPoints += fish.Points;
        }

        public abstract void Miss(int TimeToCatch);

        public abstract void RenewOxy();
     
        public void UpdateHealthStatus()
        {
            if (!HasHealthIssues)
            {
                HasHealthIssues = true;
            }
            else
            {
                HasHealthIssues = false;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine
                ($"Diver [ Name: {Name}, Oxygen left: {OxygenLevel}, Fish caught: {catchList.Count}, Points earned: {CompetitionPoints} ]");
            return sb.ToString().TrimEnd();
        }
    }
}
