namespace EnterNumbers
{
    public class StartUp
    {
        static void Main()
        {
            int start = 1;
            int end = 100;
            int[] array = new int[10];
            for (int i = 0; i < array.Length; i++)
            {

                try
                {
                    array[i] = ReadNumber(start, end);


                    if (array[i] <= start || array[i] > 100)
                    {
                        throw new ArgumentOutOfRangeException();
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid Number!");
                    i--;
                    continue;
                }
                catch (ArgumentOutOfRangeException)
                {
                    Console.WriteLine($"Your number is not in range {start} - {end}!");
                    i--;
                    continue;
                }


                start = array[i];
            }

            Console.WriteLine(string.Join(", ", array));

        }
        public static int ReadNumber(int start, int end)
        {
            string input = Console.ReadLine();
            int num;
            while (!int.TryParse(input, out num))
            {
                throw new FormatException();
            }


            return num;
        }
    }
}