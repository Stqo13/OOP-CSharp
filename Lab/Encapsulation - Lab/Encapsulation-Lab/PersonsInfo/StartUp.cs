namespace PersonsInfo
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Person>people = new List<Person>();
            for (int i = 0; i < n; i++)
            {
                string[] personInfo = 
                    Console.ReadLine().
                    Split(' ', StringSplitOptions.RemoveEmptyEntries);
                int age = int.Parse(personInfo[2]);
                decimal salary = decimal.Parse(personInfo[3]);
                try
                {
                    Person person = new Person(personInfo[0], personInfo[1], age, salary);
                    people.Add(person);
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            //decimal parcentage = decimal.Parse(Console.ReadLine());
            //people.ForEach(p => p.IncreaseSalary(parcentage));
            //people.ForEach(p => Console.WriteLine(p.ToString()));
            Team team = new Team("SoftUni");
            foreach (var item in people)
            {
                team.AddPlayer(item);
            }
            Console.WriteLine($"First team has {team.FirstTeam.Count} players.");
            Console.WriteLine($"Reserve team has {team.ReserveTeam.Count} players.");
        }
    }
}