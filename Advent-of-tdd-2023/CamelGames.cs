using System.Text.RegularExpressions;

namespace AdventOfCodeTDD
{
  public class CamelGames{

    public int bidAmount;
    public int rank;
    public string HandValue;

    public List<string> hands=new List<string>();
    public List<int> bids=new List<int>();
    public List<CamelGames> hands=new List<CamelGames>();

  public void ReadData(string FileName)
    {
        string file=@"C:\Downloads\TDD\Day7\"+FileName";
        if(File.Exist(file))
        {
            string[] allLines=File.ReadAllLines(file);
            foreach(var line in allLines)
            {
              String[] splitted=line.Split(" ");
              foreach(string value in splitted)
              {
                if(!string.IsNullOrEmpty(value))
                {
                  if(!Regex.IsMatch(value,@"^[0-9]+$"))
                  {
                    hands.Add(value);
                  }
                  else
                  {
                    int i=int.Parse(value);
                    bids.Add(i);
                  }
                }
              }
            }

          for(int i=0;i<bids.Count;i++)
          {
            CamelGames game=new CamelGames();
            game.bidAmount=bids[i];
            game.Handvalue=hands[i];
            games.Add(game);
          }          
        }
        else
        {
            throw new FileNotFoundException();
        }
    }
}
}
