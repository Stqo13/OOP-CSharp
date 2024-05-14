using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public class Truck : Vehicle
    {
        private const double AdditionFuelConsumption = 1.6;
        private const double LeakFuelQuantity = 0.95;
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity)
        :base(fuelQuantity, fuelConsumption + AdditionFuelConsumption, tankCapacity)
        {
            
        }

        public override void Refuel(double amount)
        {
            if (amount<=0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            else if (this.FuelQuantity + amount > this.TankCapacity)
            {
                Console.WriteLine($"Cannot fit {amount} fuel in the tank");
                if (this.FuelQuantity > this.TankCapacity)
                {
                    this.FuelQuantity = 0;
                }
            }
            else
            {
                this.FuelQuantity += (amount * LeakFuelQuantity);
            }
        }
    }
}
