using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NauticalCatchChallenge.Core.Contracts;
using NauticalCatchChallenge.Models;
using NauticalCatchChallenge.Models.Contracts;
using NauticalCatchChallenge.Repositories;
using NauticalCatchChallenge.Repositories.Contracts;
using NauticalCatchChallenge.Utilities.Messages;

namespace NauticalCatchChallenge.Core
{
    public class Controller : IController
    {
        private IRepository<IFish> fishes;
        private IRepository<IDiver> divers;

        public Controller()
        {
            fishes = new FishRepository();
            divers = new DiverRepository();
        }

        public string DiveIntoCompetition(string diverType, string diverName)
        {
            if (diverType != nameof(FreeDiver) && diverType != nameof(ScubaDiver))
            {
                return string.Format(OutputMessages.DiverTypeNotPresented, diverType);
            }

            if (divers.GetModel(diverName) != null)
            {
                return string.Format(OutputMessages.DiverNameDuplication, diverName, nameof(DiverRepository));
            }

            IDiver diver = null;
            if (diverType == nameof(FreeDiver))
            {
                diver = new FreeDiver(diverName);
            }
            else if (diverType == nameof(ScubaDiver))
            {
                diver = new ScubaDiver(diverName);
            }
            divers.AddModel(diver);
            return string.Format(OutputMessages.DiverRegistered, diverName, nameof(DiverRepository));
        }

        public string SwimIntoCompetition(string fishType, string fishName, double points)
        {
            if (fishType != nameof(ReefFish) && fishType != nameof(PredatoryFish) && fishType != nameof(DeepSeaFish))
            {
                return string.Format(OutputMessages.FishTypeNotPresented, fishType);
            }

            if (fishes.GetModel(fishName) != null)
            {
                return string.Format(OutputMessages.FishNameDuplication, fishName, nameof(FishRepository));
            }

            IFish fish = null;
            if (fishType == nameof(ReefFish))
            {
                fish = new ReefFish(fishName, points);
            }
            else if (fishType == nameof(PredatoryFish))
            {
                fish = new PredatoryFish(fishName, points);
            }
            else if (fishType == nameof(DeepSeaFish))
            {
                fish = new DeepSeaFish(fishName, points);
            }
            fishes.AddModel(fish);
            return string.Format(OutputMessages.FishCreated, fishName);
        }

        public string ChaseFish(string diverName, string fishName, bool isLucky)
        {
            IDiver diver = divers.GetModel(diverName);
            IFish fish = fishes.GetModel(fishName);
            if (divers.GetModel(diverName) == null)
            {
                return string.Format(OutputMessages.DiverNotFound, nameof(DiverRepository), diverName);
            }

            if (fishes.GetModel(fishName) == null)
            {
                return string.Format(OutputMessages.FishNotAllowed, fishName);
            }

            if (diver.OxygenLevel < fish.TimeToCatch)
            {
                diver.Miss(fish.TimeToCatch);
                return string.Format(OutputMessages.DiverMisses, diverName, fishName);
            }

            if (diver.OxygenLevel == fish.TimeToCatch)
            {
                if (isLucky == true)
                {
                    diver.Hit(fish);
                    return string.Format(OutputMessages.DiverHitsFish, diverName, fish.Points, fishName);
                }
                else
                {
                    diver.Miss(fish.TimeToCatch);
                    return string.Format(OutputMessages.DiverMisses, diverName, fishName);
                }
            }

            if (diver.OxygenLevel <= 0)
            {
                diver.UpdateHealthStatus();
            }

            if (diver.HasHealthIssues == true)
            {
                return string.Format(OutputMessages.DiverHealthCheck, diverName);
            }

            diver.Hit(fish);
            if (diver.OxygenLevel <= 0)
            {
                diver.UpdateHealthStatus();
            }
            return string.Format(OutputMessages.DiverHitsFish, diverName, fish.Points, fishName);
        }

        public string HealthRecovery()
        {
            List<IDiver> recoveredDivers = new List<IDiver>();
            foreach (var diver in divers.Models)
            {
                if (diver.HasHealthIssues == true || diver.OxygenLevel <= 0)
                {
                    diver.UpdateHealthStatus();
                    diver.RenewOxy();
                    recoveredDivers.Add(diver);;
                }
            }

            return string.Format(OutputMessages.DiversRecovered, recoveredDivers.Count);
        }

        public string DiverCatchReport(string diverName)
        {
            IDiver diver = divers.GetModel(diverName);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(diver.ToString());
            sb.AppendLine("Catch Report:");
            foreach (var fish in diver.Catch)
            {
                IFish currenFish = fishes.GetModel(fish);
                sb.AppendLine(currenFish.ToString());
            }
            return sb.ToString().TrimEnd();
        }

        public string CompetitionStatistics()
        {
            List<IDiver> healthyDivers = divers.Models
                .Where(diver => diver.HasHealthIssues == false)
                .OrderByDescending(diver => diver.CompetitionPoints)
                .ThenByDescending(diver => diver.Catch.Count)
                .ThenBy(diver => diver.Name)
                .ToList();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("**Nautical-Catch-Challenge**");
            foreach (var diver in healthyDivers)
            {
                sb.AppendLine(diver.ToString());
            }
            return sb.ToString().TrimEnd();
        }
    }
}
