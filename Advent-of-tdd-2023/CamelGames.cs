namespace AdventOfCodeTDD
{
    public class CamelGames {
        public static void Main()
        {
            var cg = new CamelGames();
            var STRENGTHS = "AKQJT98765432";
            var strengths = ("abcdefghijklm").Reverse();
            var rev_strength = string.Join("", strengths);

            var highcards = new List<List<Bid>>();
            var onepairs = new List<List<Bid>>();
            var twopairs = new List<List<Bid>>();
            var threesomes = new List<List<Bid>>();
            var fullhouses = new List<List<Bid>>();
            var foursomes = new List<List<Bid>>();
            var fivesomes = new List<List<Bid>>();

            var allLists = new List<List<List<Bid>>> { highcards, onepairs, twopairs, threesomes, fullhouses, foursomes, fivesomes };

           var input= cg.processInput(STRENGTHS, rev_strength);


            foreach (var list in allLists) {

                for (int n = 0; n < STRENGTHS.Length; n++) {
                    var l = new List<Bid>() { };
                    list.Add(l);
                }; // one sublist for each label
            }

            foreach (var data in input) {

                var kind = cg.getKind(data);

                if (kind == "highcard") {
                    highcards=cg.placeData(data, highcards, STRENGTHS, rev_strength); continue;
                }
                if (kind == "onepair") { 
                    onepairs=cg.placeData(data, onepairs, STRENGTHS, rev_strength); continue; }
                if (kind == "twopairs") { 
                    twopairs= cg.placeData(data, twopairs, STRENGTHS, rev_strength); continue; }
                if (kind == "threesome") { 
                    threesomes=cg.placeData(data, threesomes, STRENGTHS, rev_strength); continue; }
                if (kind == "fullhouse") {
                    fullhouses=cg.placeData(data, fullhouses, STRENGTHS, rev_strength); continue; }
                if (kind == "foursome") { 
                    foursomes=cg.placeData(data, foursomes, STRENGTHS, rev_strength); continue; }
                if (kind == "fivesome") { 
                    fivesomes=cg.placeData(data, fivesomes, STRENGTHS, rev_strength); continue; }
            }

            var l2 = new List<List<List<Bid>>>();
            foreach (var list in allLists) {
                var l1 = new List<List<Bid>>();
                foreach (var sublist in list) {
                    var l3= cg.sort(sublist.ToArray());
                    l1.Add(l3);
                }
                l2.Add(l1);
            }
            //253905649
            //250946742
            var totalWinnings = 0;
            var rank = 0;
            foreach (var list in l2) {
                foreach (var sublist in list) {
                    foreach (var data in sublist) {

                        rank += 1;

                        totalWinnings += rank * data.bid;
                    }
                }
            }
            Console.WriteLine("Total winnings:", totalWinnings);
        }
        public new List<Bid> processInput(string STRENGTHS, string rev_strength)
        {
            var input = new List<Bid>();
            var lines = File.ReadLines(@"C:\Users\CamelGame.txt");
            foreach (var line in lines) {

                var tokens = line.Trim().Split(" ").ToList();


                var original = tokens.FirstOrDefault();
                tokens.Remove(original);
                var hand = convertHand(original, STRENGTHS, rev_strength);
                var bid = int.Parse(tokens.FirstOrDefault());
                input.Add(new Bid { hand = hand, bid = bid });
            }
            return input;
        }

        public string convertHand(string original,string STRENGTHS,string rev_strength)
        { // for a faster sorting

            var converted = "";


            foreach (var ch in original) {

                var index = STRENGTHS.IndexOf(ch);
                converted += rev_strength[index];
            }
            return converted;
        }
        public string getKind(Bid data)
        {

            var cards = new Dictionary<char,int>() ;

            foreach (var ch in data.hand) {

                if (cards.ContainsKey(ch))
                { var val = cards[ch];
                    cards[ch] = val + 1;
                }
                else
                {
                    cards.Add(ch, 1);
                }
            }

            var labels = cards.Keys.ToArray();


            if (labels.Length == 5) { return "highcard"; }

            if (labels.Length == 4) { return "onepair"; }

            if (labels.Length == 3)
            {

                if (cards[labels[0]] == 3) { return "threesome"; }
                if (cards[labels[1]] == 3) { return "threesome"; }
                if (cards[labels[2]] == 3) { return "threesome"; }

                return "twopairs";
            }

            if (labels.Length == 2)
            {

                if (cards[labels[0]] == 4) { return "foursome"; }
                if (labels.Length > 1 && cards[labels[1]] == 4) { return "foursome"; }
                if (labels.Length>2 && cards[labels[2]] == 4) { return "foursome"; }
                if (labels.Length > 3 && cards[labels[3]] == 4) { return "foursome"; }
                return "fullhouse";
            }

            return "fivesome";

        }

        public List<List<Bid>> placeData(Bid data, List<List<Bid>> list, string STRENGTHS, string rev_strength)
        {

            var index = STRENGTHS.Length - 1 - rev_strength.IndexOf(data.hand[0]);
               list[index].Add(data);
            return list;
        }

        public List<Bid> sort(Bid[] list)
        {
            var n = -1;
            while (true && list.Length>0)
            {
                n += 1;
                if (n+1 >= list.Length) break;
                var current = list[n];
                var next = list[n + 1];
                if (next==null)
                {
                    var bid=new List<Bid>();
                    break;
                }

                if (string.Compare(current.hand , next.hand)<0)
                {
                    list[n] = next;
                    list[n + 1] = current;
                    n = -1;
                }

            }
            return list.ToList();
        }
    }
    public class Bid
    {
        public string hand;
        public int bid;
    }

}

