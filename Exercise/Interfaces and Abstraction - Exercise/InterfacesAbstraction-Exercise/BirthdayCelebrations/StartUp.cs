namespace BirthdayCelebrations
{
    public class StartUp
    {
        static void Main()
        {
            string input = Console.ReadLine();
            List<IBirthable> birthables = new List<IBirthable>();
            int age = 0;
            string name = string.Empty;
            string id = string.Empty;
            string model = string.Empty;
            string birthday = string.Empty;
            while (input!="End")
            {
                string[] inputInfo = input.Split(' ');
                switch (inputInfo[0])
                {
                    case "Citizen":
                        name = inputInfo[1];
                        age = int.Parse(inputInfo[2]);
                        id = inputInfo[3];
                        birthday = inputInfo[4];
                        IBirthable citizen = new Citizen
                            (
                            age,
                            name,
                            id,
                            birthday
                            );
                        birthables.Add(citizen);
                        break;
                    case "Pet":
                        name = inputInfo[1];
                        birthday = inputInfo[2];
                        IBirthable pet = new Pet
                            (
                            name,
                            birthday
                            );
                        birthables.Add(pet);
                        break;
                }
                input = Console.ReadLine();
            }
            string yearToFind = Console.ReadLine();
            foreach (var item in birthables)
            {
                if (item.Birthday.EndsWith(yearToFind))
                {
                    Console.WriteLine(item.Birthday);
                }
            }
        }
    }
}