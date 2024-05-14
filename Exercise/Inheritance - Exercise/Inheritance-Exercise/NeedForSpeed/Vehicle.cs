using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedForSpeed
{
    public class Vehicle
    {
        public Vehicle(int horsePower, double fuel)
        {
			HorsePower = horsePower;
			Fuel = fuel;
        }
        private int horsePower;

		public int HorsePower
		{
			get { return horsePower; }
			set { horsePower = value; }
		}
		private double fuel;

		public double Fuel
		{
			get { return fuel; }
			set { fuel = value; }
		}
		private double defaultFuelConsumption = 1.25;

		public double DefaultFuelConsumption
		{
			get { return defaultFuelConsumption; }
			set { defaultFuelConsumption = value; }
		}
		private double fuelConsumption;

		public virtual double FuelConsumption
		{
			get { return fuelConsumption; }
			set { fuelConsumption = value; }
		}
		public virtual void Drive(double kilometers)
		{
			if (FuelConsumption == default)
			{
				FuelConsumption = DefaultFuelConsumption;
			}
			this.Fuel -= kilometers * FuelConsumption;
		}
	}
}
