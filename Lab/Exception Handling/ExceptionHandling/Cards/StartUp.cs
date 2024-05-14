namespace Cards
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string[] inputInfo = input.Split(", ", StringSplitOptions.RemoveEmptyEntries);
            List<Card> cards = new List<Card>();
            foreach (var item in inputInfo)
            {
                string[] cardsInfo = item.Split(' ', StringSplitOptions.RemoveEmptyEntries);
                string face = cardsInfo[0];
                string suit = cardsInfo[1];
                try
                {
                    Card card = new Card(face, suit);
                    cards.Add(card);;
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            foreach (var item in cards)
            {
                Console.Write($"{item.ToString()} ");
            }
        }
    }

    public class Card
    {
        private static readonly HashSet<string> Faces = new HashSet<string> { "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K", "A" };
        private static readonly Dictionary<string, string> Suits = new Dictionary<string, string>
        {
            { "S", "\u2660" },
            { "H", "\u2665" },
            { "D", "\u2666" },
            { "C", "\u2663" }
        };

        public Card(string face, string suit)
        {
            if (!Faces.Contains(face) || !Suits.ContainsKey(suit))
            {
                throw new ArgumentException("Invalid card!");
            }

            this.Face = face;
            this.Suit = suit;
        }
        private string face;

        public string Face
        {
            get { return face; }
            set { face = value; }
        }
        private string suit;

        public string Suit
        {
            get { return suit; }
            set { suit = value; }
        }

        public override string ToString()
        {
            return $"[{this.face}{Suits[this.suit]}]"; 
        }
    }
}