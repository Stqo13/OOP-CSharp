namespace ClassBoxData
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            double length = double.Parse(Console.ReadLine());
            double width = double.Parse(Console.ReadLine());
            double height = double.Parse(Console.ReadLine());
            try
            {
                Box box = new Box(length, width, height);
                double area = box.SurfaceArea();
                double lateralArea = box.LateralSurfaceArea();
                double volume = box.Volume();
                Console.WriteLine($"Surface Area - {area:f2}");
                Console.WriteLine($"Lateral Surface Area - {lateralArea:f2}");
                Console.WriteLine($"Volume - {volume:f2}");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}