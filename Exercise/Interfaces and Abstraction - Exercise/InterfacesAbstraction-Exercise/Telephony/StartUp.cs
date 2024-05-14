namespace Telephony
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<string> phoneNumbers =
                Console.ReadLine()
                .Split()
                .ToList();
            List<string> urls =
                Console.ReadLine()
                .Split()
                .ToList();
            Smartphone smartphone = new Smartphone();
            StationaryPhone stationaryPhone = new StationaryPhone();
            foreach (var item in phoneNumbers)
            {
                try
                {
                    if (item.Length == 10)
                    {
                        Console.WriteLine(smartphone.Call(item));
                    }
                    else
                    {
                        Console.WriteLine(stationaryPhone.Call(item));
                    }
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            foreach (var item in urls)
            {
                try
                {
                    Console.WriteLine(smartphone.BrowsNet(item));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }
    }
}