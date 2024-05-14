namespace PlayCatch
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int[] array =
                Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            int counter = 0;
            while (counter < 3)
            {
                string[] command = 
                    Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                try
                {
                    switch (command[0])
                    {
                        case "Replace":
                            int firstIndex = int.Parse(command[1]);
                            int firstElement = int.Parse(command[2]);
                            array[firstIndex] = firstElement;
                            break;
                        case "Print":
                            int startIndex = int.Parse(command[1]);
                            int endIndex = int.Parse(command[2]);
                            List<int> numbers = new List<int>();
                            for (int i = startIndex; i <= endIndex; i++)
                            {
                                numbers.Add(array[i]);
                            }
                            Console.WriteLine(string.Join(", ", numbers));
                            break;
                        case "Show":
                            int secondIndex = int.Parse(command[1]);
                            Console.WriteLine(array[secondIndex]);
                            break;
                    }
                }
                catch (IndexOutOfRangeException iex)
                {
                    counter++;
                    Console.WriteLine("The index does not exist!");
                }
                catch (FormatException fex)
                {
                    Console.WriteLine("The variable is not in the correct format!");
                    counter++;
                }
            }
            Console.WriteLine(string.Join(", ", array));
        }
    }
}