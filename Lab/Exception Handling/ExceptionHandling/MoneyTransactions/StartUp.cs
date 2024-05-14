namespace MoneyTransactions
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            Dictionary<int, double>bankAccounts = new Dictionary<int, double>();
            string[] input =
                Console.ReadLine()
                    .Split(",", StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in input)
            {
                string[] bankAccountInfo =
                    item.Split('-', StringSplitOptions.RemoveEmptyEntries);
                int accountNumber = int.Parse(bankAccountInfo[0]);
                double accountBalance = double.Parse(bankAccountInfo[1]);
                if (!bankAccounts.ContainsKey(accountNumber))
                {
                    bankAccounts.Add(accountNumber, accountBalance);
                }
            }
            string[]command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            while (command[0]!="End")
            {
                try
                {
                    switch (command[0])
                    {
                        case "Deposit":
                            int firstAccountNumber = int.Parse(command[1]);
                            double firstSum = double.Parse(command[2]);
                            bankAccounts[firstAccountNumber] += firstSum;
                            Console.WriteLine($"Account {firstAccountNumber} has new balance: {bankAccounts[firstAccountNumber]:f2}");
                            break;
                        case "Withdraw":
                            int secondAccountNumber = int.Parse(command[1]);
                            double secondSum = double.Parse(command[2]);
                            if (bankAccounts[secondAccountNumber] < secondSum)
                            {
                                throw new InsufficientBalanceException();
                            }
                            else
                            {
                                bankAccounts[secondAccountNumber] -= secondSum;
                                Console.WriteLine($"Account {secondAccountNumber} has new balance: {bankAccounts[secondAccountNumber]:f2}");
                            }
                            break;
                        default:
                            throw new InvalidCommandException();
                    }
                }
                catch (InvalidCommandException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                catch (KeyNotFoundException kex)
                {
                    Console.WriteLine("Invalid account!");
                }
                catch (InsufficientBalanceException iex)
                {
                    Console.WriteLine(iex.Message);
                }
                finally
                {
                    Console.WriteLine("Enter another command");
                }
                command = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
            }
        }
    }

    public class InvalidCommandException : Exception
    {
        public InvalidCommandException()
            : base("Invalid command!")
        {

        }
        public InvalidCommandException(string message)
            : base(message)
        {

        }

        public InvalidCommandException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
    public class InsufficientBalanceException : Exception
    {
        public InsufficientBalanceException()
            : base("Insufficient balance!")
        {

        }

        public InsufficientBalanceException(string message)
            : base(message)
        {

        }

        public InsufficientBalanceException(string message, Exception innerException)
            : base(message, innerException)
        {

        }
    }
}