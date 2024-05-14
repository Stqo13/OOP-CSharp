namespace SuqareRoot
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            try
            {
                Console.WriteLine(NumberSqrt(number));
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                Console.WriteLine("Goodbye.");
            }
        }
        static double NumberSqrt(double number)
        {
            if (number < 0)
            {
                throw new ArgumentException("Invalid number.");
            }
            return Math.Sqrt(number);
        }
    }
}