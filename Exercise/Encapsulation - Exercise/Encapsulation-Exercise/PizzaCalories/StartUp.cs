namespace PizzaCalories
{
    public class StartUp
    {
        static void Main(string[] args)
        {
			try
			{
				string[] pizzaInfo =
					Console.ReadLine().Split();
				
				string[] doughInfo =
					Console.ReadLine().Split();

                string doughType = doughInfo[1];
                string bakingTechnique = doughInfo[2];
				double doughWeight = double.Parse(doughInfo[3]);

                Dough dough = new Dough(doughType, bakingTechnique, doughWeight);

                string name = pizzaInfo[1];
                Pizza pizza = new Pizza(name);

                pizza.Dough = dough;

				string input = Console.ReadLine();
				while (input != "END")
				{
                    string[] toppingInfo =
                    input.Split();
                    string toppingType = toppingInfo[1];
					double toppingTypeWeight = double.Parse(toppingInfo[2]);
					Topping topping = new Topping(toppingType, toppingTypeWeight);
					pizza.AddTopping(topping);
                    input = Console.ReadLine();
                }
				Console.WriteLine(pizza);
			}
			catch (Exception ex)
			{
                Console.WriteLine(ex.Message);
            }
        }
    }
}