namespace AdventOfCodeTDD
{
 
     public class Game
    {

        public const string RANKS = "23456789TJQKA";

        public enum HandType
        {
            HighCard = 0,
            Pair = 1,
            TwoPair = 2,
            ThreeOfAKind = 3,
            FullHouse = 4,
            FourOfAKind = 5,
            FiveOfAKind = 6
        }

        public record CamelGame(string hand, int score, int bet, int occurring0, int occurring1) : IComparable<CamelGame>
        {
            public HandType type =>
                occurring0 switch
                {
                    5 => HandType.FiveOfAKind,
                    4 => HandType.FourOfAKind,
                    3 => occurring1 == 2 ? HandType.FullHouse : HandType.ThreeOfAKind,
                    2 => occurring1 == 2 ? HandType.TwoPair : HandType.Pair,
                    _ => HandType.HighCard,
                };
            public int CompareTo(CamelGame other) => type == other.type ? score.CompareTo(other.score) : type.CompareTo(other.type);
        }

        public List<CamelGame> ParseGames(string input, bool jokers = false)
        {
            return input.Trim().Split("\n").Select(line =>
            {
                var parts = line.Split(" ");
                var bet = int.Parse(parts[1]);
                var hand = parts[0];

                if (jokers)
                {
                    var occuring = hand.GroupBy(c => c)
                                    .ToDictionary(group => group.Key, group => group.Count());
                    int score = hand.Aggregate(0, (acc, c) => (acc << 4) + (c == 'J' ? 0 : RANKS.IndexOf(c) + 1));
                    int jokerCount = 0;
                    if (occuring.ContainsKey('J'))
                    {
                        jokerCount = occuring['J'];
                        occuring.Remove('J');
                    }

                    if (occuring.Count == 0)
                    {
                        return new CamelGame(hand, score, bet, 5, 0);
                    }

                    var maxCount = occuring.Values.Max();
                    var maxCountKey = occuring.FirstOrDefault(x => x.Value == maxCount).Key;

                    if (jokerCount > 0)
                    {
                        occuring[maxCountKey] += jokerCount;
                        maxCount = occuring[maxCountKey];
                    }

                    var occuring1 = (occuring.Count > 1 ? occuring.OrderByDescending(x => x.Value).Skip(1).First().Value : 0);

                    return new CamelGame(hand, score, bet, maxCount, occuring1);
                }
                else
                {
                    int score = hand.Aggregate(0, (acc, c) => (acc << 4) + RANKS.IndexOf(c));
                    var occuring = hand.GroupBy(c => c)
                                        .Select(group => group.Count())
                                        .OrderByDescending(count => count).ToList();
                    var occuring1 = (occuring.Count > 1 ? occuring[1] : 0);

                    return new CamelGame(hand, score, bet, occuring[0], occuring1);
                }
            }).ToList();
        }

        public int SolvePart1(string filename)
        {
            var input = File.ReadAllText(@"C:\Users\MSUSERSL123\Documents\Data\" + filename);
            return ParseGames(input).Order().Select((game, index) => (index + 1) * game.bet).Sum();
        }
        public int SolvePart2(string filename)
        {
            var input = File.ReadAllText(@"C:\Users\MSUSERSL123\Documents\Data\" + filename);
            return ParseGames(input, true).Order().Select((game, index) => (index + 1) * game.bet).Sum();
        }


    
}
  

public static void Main(string[] args)
{
      Game game = new Game();
      int a= game.SolvePart1("Day7.txt");
      int b = game.SolvePart2("Day7.txt");
      Console.WriteLine("Part 1 {0}", a);
      Console.WriteLine("Part 2 {0}", b);
}

}

