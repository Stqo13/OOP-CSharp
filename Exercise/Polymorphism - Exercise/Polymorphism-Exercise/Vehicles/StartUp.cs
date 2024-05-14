namespace Vehicles
{
    public class StartUp
    {
        static void Main()
        {
            string[] carInfo = Console.ReadLine().Split(' ');
            string[] truckInfo = Console.ReadLine().Split(' ');
            string[] busInfo = Console.ReadLine().Split(' ');
            Vehicle car = new Car
                (double.Parse(carInfo[1]), double.Parse(carInfo[2]), double.Parse(carInfo[3]));
            Vehicle truck = new Truck
                (double.Parse(truckInfo[1]), double.Parse(truckInfo[2]), double.Parse(truckInfo[3]));
            Vehicle bus = new Bus
                (double.Parse(busInfo[1]), double.Parse(busInfo[2]), double.Parse(busInfo[3]));
            int n = int.Parse(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                string[] driveInfo = Console.ReadLine().Split(' ');
                if (driveInfo[0] == "Drive")
                {

                    switch (driveInfo[1])
                    {
                        case "Car":
                            Console.WriteLine(car.Drive(double.Parse(driveInfo[2])));
                            break;
                        case "Truck":
                            Console.WriteLine(truck.Drive(double.Parse(driveInfo[2])));
                            break;
                        case "Bus":
                            Console.WriteLine(bus.Drive(double.Parse(driveInfo[2])));
                            break;
                    }
                }
                else if (driveInfo[0] == "Refuel")
                {
                    switch (driveInfo[1])
                    {
                        case "Car":
                            car.Refuel(double.Parse(driveInfo[2]));
                            break;
                        case "Truck":
                            truck.Refuel(double.Parse(driveInfo[2]));
                            break;
                        case "Bus":
                            bus.Refuel(double.Parse(driveInfo[2]));
                            break;
                    }
                }
                else if (driveInfo[0] == "DriveEmpty")
                {
                    if (bus is Bus)
                    {
                        Console.WriteLine((bus as Bus).DriveEmpty(double.Parse(driveInfo[2])));
                    }
                }
            }
            Console.WriteLine(car.ToString());
            Console.WriteLine(truck.ToString());
            Console.WriteLine(bus.ToString());
        }
    }
}