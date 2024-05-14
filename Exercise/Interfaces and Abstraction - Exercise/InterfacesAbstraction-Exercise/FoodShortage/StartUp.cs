namespace FoodShortage
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<IBuyer> buyers = new List<IBuyer>();
            int age = 0;
            string name = string.Empty;
            string id = string.Empty;
            string birthday = string.Empty;
            string group = string.Empty;
            for (int i = 0; i < n; i++)
            {
                string[] inputInfo = 
                    Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                if (inputInfo.Length == 4)
                {
                    name = inputInfo[0];
                    age = int.Parse(inputInfo[1]);
                    id = inputInfo[2];
                    birthday = inputInfo[3];
                    IBuyer citizen = new Citizen
                        (
                        name,
                        age,
                        id,
                        birthday
                        );
                    buyers.Add(citizen);
                }
                else if(inputInfo.Length == 3)
                {
                    name = inputInfo[0];
                    age = int.Parse(inputInfo[1]);
                    group = inputInfo[2];
                    IBuyer rebel = new Rebel
                        (
                        name,
                        age,
                        group
                        );
                    buyers.Add(rebel);
                }
            }
            string input = Console.ReadLine();
            while (input != "End")
            {
                buyers.FirstOrDefault(x => x.Name == input)?.BuyFood();
                input = Console.ReadLine();
            }
            Console.WriteLine(buyers.Sum(x=>x.Food));
        }
    }
}