using System.Text.RegularExpressions;

namespace AdventOfCodeTDD
{
 enum CardValues
 {
     FiveofAkind,
     FourofAkind,
     FullHouse,
     ThreeofAkind,
     twoPair,
     OnePair,
     HighCard

 }
 public class CamelGame
 {

     public int bidAmount;
     public int rank;
     public string cardFaceValue;
     public string HandValue;

     public List<string> hands = new List<string>();
     public List<int> bids = new List<int>();
     public List<CamelGame> games = new List<CamelGame>();

     public void ReadData(string FileName)
     {
         string file = @"C:\Users\MSUSERSL123\Documents\Data\" + FileName;
         if (File.Exists(file))
         {
             string[] allLines = File.ReadAllLines(file);
             foreach (var line in allLines)
             {
                 String[] splitted = line.Split(" ");
                 foreach (string value in splitted)
                 {
                     if (!string.IsNullOrEmpty(value))
                     {
                         if (!Regex.IsMatch(value, @"^[0-9]+$"))
                         {
                             hands.Add(value);
                         }
                         else
                         {
                             int i = int.Parse(value);
                             bids.Add(i);
                         }
                     }
                 }
             }

             for (int i = 0; i < bids.Count; i++)
             {
                 CamelGame game = new CamelGame();
                 game.bidAmount = bids[i];
                 game.HandValue = hands[i];
                 games.Add(game);
             }
         }
         else
         {
             throw new FileNotFoundException();
         }
     }

     public int CheckRank()
     {
         int sum = 0;
         foreach (var game in games)
         {
             string cardValue = GetCardValue(game);
             game.cardFaceValue = cardValue;
         }

         var highCardList = games.Where(x => x.cardFaceValue == CardValues.HighCard.ToString()).ToList();
         findRanks (highCardList);
         var onePairsList = games.Where(x => x.cardFaceValue == CardValues.OnePair.ToString()).ToList();
         findRanks(onePairsList);
         var twoPairsList = games.Where(x => x.cardFaceValue == CardValues.twoPair.ToString()).ToList();
         findRanks(twoPairsList);
         var threeOfList = games.Where(x => x.cardFaceValue == CardValues.ThreeofAkind.ToString()).ToList();
         findRanks(threeOfList);
         var fullHouseList = games.Where(x => x.cardFaceValue == CardValues.FullHouse.ToString()).ToList();
         findRanks(fullHouseList);
         var fourOfList = games.Where(x => x.cardFaceValue == CardValues.FourofAkind.ToString()).ToList();
         findRanks(fourOfList);
         var fiveOfList = games.Where(x => x.cardFaceValue == CardValues.FiveofAkind.ToString()).ToList();
         findRanks(fiveOfList);

         foreach (var game in games)
         {
             sum = sum + (game.rank * game.bidAmount);
         }
         return sum;
     }

     public void findRanks(List<CamelGame> pairsList)
 {
     int maxRank = games.Max(x => x.rank);
     var alphabetList = pairsList.Where(s => char.IsLetter(s.HandValue.FirstOrDefault())).ToList();
     var numberList = pairsList.Where(s => char.IsDigit(s.HandValue.FirstOrDefault())).ToList();

     var formednumList =numberList.OrderBy(x => x.HandValue).ToList();
     var formedalphaList = alphabetList.OrderByDescending(x => x.HandValue).ToList();
     foreach (var item in formednumList)
     {
         item.rank = maxRank + 1;
         maxRank++;
     }
     foreach (var item in formedalphaList)
     {
         item.rank = maxRank + 1;
         maxRank++;
     }

 }
     public string GetCardValue(CamelGame game)
     {
         string type = string.Empty;
         string data = game.HandValue;
         Dictionary<char, int> alphabetCount = new Dictionary<char, int>();
         for (int i = 0; i < data.Length; i++)
         {
             if (alphabetCount.ContainsKey(data[i]))
             {
                 alphabetCount[data[i]]++;
             }
             else
             {
                 alphabetCount[data[i]] = 1;
             }
         }


         switch (alphabetCount.Count)
         {
             case 1:
                 type = CardValues.FiveofAkind.ToString();
                 break;
             case 2:
                 if (alphabetCount.ContainsValue(4))
                 { type = CardValues.FourofAkind.ToString(); }
                 else
                 {
                     type = CardValues.FullHouse.ToString();
                 }
                 break;
             case 3:
                 if (alphabetCount.ContainsValue(3))
                 { type = CardValues.ThreeofAkind.ToString(); }
                 else
                 {
                     type = CardValues.twoPair.ToString();
                 }
                 break;
             case 4:
                 type = CardValues.OnePair.ToString();
                 break;
             case 5:
                 type = CardValues.HighCard.ToString();
                 break;
         }

         return type;
     }

 }
}
