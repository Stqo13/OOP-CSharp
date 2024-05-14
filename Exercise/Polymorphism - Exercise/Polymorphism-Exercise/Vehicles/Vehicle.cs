using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Vehicles
{
    public abstract class Vehicle
    {
        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            if (fuelQuantity > tankCapacity)
            {
                this.FuelQuantity = 0;
            }
            else
            {
                this.FuelQuantity = fuelQuantity;
            }
            this.FuelConsumption = fuelConsumption;
            this.TankCapacity = tankCapacity;
        }
        private double fuelQuantity;

        public double FuelQuantity
        {
            get { return fuelQuantity; }
            set 
            {
                this.fuelQuantity = value;
            }
        }
        private double fuelConsumption;

        public double FuelConsumption
        {
            get { return fuelConsumption; }
            set { fuelConsumption = value; }
        }
        private double tankCapacity;

        public double TankCapacity
        {
            get { return tankCapacity; }
            set { tankCapacity = value; }
        }

        public virtual string Drive(double distance)
        {
            if (distance * this.FuelConsumption > this.FuelQuantity)
            {
                return $"{this.GetType().Name} needs refueling";
            }
            this.FuelQuantity -= this.FuelConsumption * distance;
            return $"{this.GetType().Name} travelled {distance} km";
        }

        public virtual void Refuel(double amount)
        {
            if (amount <= 0)
            {
                Console.WriteLine("Fuel must be a positive number");
            }
            else if (this.FuelQuantity + amount > this.TankCapacity)
            {
                Console.WriteLine($"Cannot fit {amount} fuel in the tank");
            }
            else
            {
                this.FuelQuantity += amount;
            }
        }
        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}
