using System.Xml.Linq;

namespace SumIOfIntegers
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] inputInfo = input.Split();

            int sum = 0;
            foreach (var item in inputInfo)
            {
                int number = 0;
                try
                {
                    number = int.Parse(item);
                    sum += number;
                }
                catch (FormatException fex)
                {
                    Console.WriteLine($"The element '{item}' is in wrong format!");
                }
                catch (OverflowException oex)
                {
                    Console.WriteLine($"The element '{item}' is out of range!");
                }
                finally
                {
                    Console.WriteLine($"Element '{item}' processed - current sum: {sum}");
                }
            }
            Console.WriteLine($"The total sum of all integers is: {sum}");
            //string[] input = Console.ReadLine().Split();
            //int sum = 0;
            //foreach (string line in input)
            //{
            //    int currentItemInt = 0;
            //    try
            //    {
            //        currentItemInt = int.Parse(line);
            //        sum += currentItemInt;
            //    }
            //    catch (FormatException ex)
            //    {
            //        Console.WriteLine($"The element '{line}' is in wrong format!");
            //    }
            //    catch (OverflowException ex1)
            //    {
            //        Console.WriteLine($"The element '{line}' is out of range!");
            //    }
            //    finally { Console.WriteLine($"Element '{line}' processed - current sum: {sum}"); }
            //}
            //Console.WriteLine($"The total sum of all integers is: {sum}");
        }
    }
}