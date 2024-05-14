namespace ShoppingSpree
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            List<Person>people = new List<Person>();
            List<Product>products = new List<Product>();
            try
            {
                string[] nameAndMoneyPairs =
                    Console.ReadLine()
                    .Split(';', StringSplitOptions.RemoveEmptyEntries);
                foreach (var nameMoney in nameAndMoneyPairs)
                {
                    string[] nameAndMoney = nameMoney
                        .Split('=', StringSplitOptions.RemoveEmptyEntries);
                    Person person = new Person(nameAndMoney[0], decimal.Parse(nameAndMoney[1]));
                    people.Add(person);
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            try
            {
                string[] productCostPairs =
                    Console.ReadLine()
                    .Split(";", StringSplitOptions.RemoveEmptyEntries);

                foreach (var productCost in productCostPairs)
                {
                    string[] productAndCost = productCost
                        .Split("=", StringSplitOptions.RemoveEmptyEntries);
                    Product product = new Product(productAndCost[0], decimal.Parse(productAndCost[1]));
                    products.Add(product);
                }
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                return;
            }
            string input = Console.ReadLine();
            while (input != "END")
            {
                string[] inputInfo = input
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string personName = inputInfo[0];
                string productName = inputInfo[1];
                Person person = people.FirstOrDefault(p => p.Name == personName);
                Product product = products.FirstOrDefault(p => p.Name == productName);
                if (person != null && product != null)
                {
                    person.AddItem(product);
                }
                input = Console.ReadLine();
            }
            Console.WriteLine(string.Join(Environment.NewLine, people));
        }
    }
}