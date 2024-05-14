using System.Security;

namespace BorderControl
{
    public class StartUp
    {
        static void Main()
        {
            string input = Console.ReadLine();
            int age = 0;
            string name = string.Empty;
            string model = string.Empty;
            string id = string.Empty;
            List<IIdentifiable>citizens = new List<IIdentifiable>();
            while (input!="End")
            {
                string[] newcommerInfo = input.Split(' ');
                if (newcommerInfo.Length == 3)
                {
                    name  = newcommerInfo[0];
                    age = int.Parse(newcommerInfo[1]);
                    id = newcommerInfo[2];
                    IIdentifiable citizen = new Citizen
                        (
                        name,
                        age,
                        id
                        );
                    citizens.Add(citizen);
                }
                else if(newcommerInfo.Length == 2)
                {
                    model = newcommerInfo[0];
                    id = newcommerInfo[1];
                    IIdentifiable robot = new Robot
                        (
                        model,
                        id
                        );
                    citizens.Add(robot);
                }
                input = Console.ReadLine();
            }
            string fakeIdNumber = Console.ReadLine();
            foreach (var item in citizens)
            {
                if (item.Id.EndsWith(fakeIdNumber))
                {
                    Console.WriteLine(item.Id);
                }
            }
        }
    }
}