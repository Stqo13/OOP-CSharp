namespace Raiding
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int powerSum = 0;
            int counter = 0;
            List<BaseHero>heroes = new List<BaseHero>();
            while(counter != n)
            {
                string heroName = Console.ReadLine();
                string heroType = Console.ReadLine();
                if (heroType != "Druid" && heroType != "Paladin" && heroType != "Rogue" && heroType != "Warrior")
                {
                    Console.WriteLine("Invalid hero!");
                }
                else
                {
                    counter++;
                    switch (heroType)
                    {
                        case "Druid":
                            BaseHero druid = new Druid(heroName, 80);
                            heroes.Add(druid);
                            break;
                        case "Paladin":
                            BaseHero paladin = new Paladin(heroName, 100);
                            heroes.Add(paladin);
                            break;
                        case "Rogue":
                            BaseHero rogue = new Rogue(heroName, 80);
                            heroes.Add(rogue);
                            break;
                        case "Warrior":
                            BaseHero warrior = new Warrior(heroName, 100);
                            heroes.Add(warrior);
                            break;
                    }
                }
            }
            int enemyPower = int.Parse(Console.ReadLine());
            foreach (var item in heroes)
            {
                Console.WriteLine(item.CastAbility());
                powerSum += item.Power;
            }
            if (powerSum >= enemyPower)
            {
                Console.WriteLine("Victory!");
            }
            else
            {
                Console.WriteLine("Defeat...");
            }
        }
    }
}