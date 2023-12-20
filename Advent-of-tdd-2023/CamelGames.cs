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

  

public static void Main(string[] args)
{
      CamelGame camelgame = new CamelGame();
camelgame.ReadData("Day7.txt");
Int64 finalValue = camelgame.CheckRank();
Console.WriteLine("Final ways are {0}", finalValue);
}

}

