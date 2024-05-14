using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public class Bus : Vehicle
    {
        private const double AdditionFuelConsumption = 1.4;
        public Bus(double fuelQuantity, double fuelConsumption, double tankCapacity)
            : base(fuelQuantity, fuelConsumption, tankCapacity)

        {

        }
        public override string Drive(double distance)
        {
            if (distance * (this.FuelConsumption + AdditionFuelConsumption) > this.FuelQuantity)
            {
                return $"{this.GetType().Name} needs refueling";
            }
            else
            {
                this.FuelQuantity -= (this.FuelConsumption + AdditionFuelConsumption) * distance;
                return $"{this.GetType().Name} travelled {distance} km";
            }
        }
        public string DriveEmpty(double distance)
        {
            if (distance * this.FuelConsumption > this.FuelQuantity)
            {
                return $"{this.GetType().Name} needs refueling";
            }
            else
            {
                this.FuelQuantity -= this.FuelConsumption * distance;
                return $"{this.GetType().Name} travelled {distance} km";
            }
        }
    }
}
