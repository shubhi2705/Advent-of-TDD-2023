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

  public int CheckRank()
  {
    int sum=0;
    foreach(var game in games)
    {
      string data=game.Handvalue;
      Dictionary<char,int> alphabetCount=new Dictionary<char,int>();
      for(int i=0;i<data.Length;i++)
      {
        if(alphabetCount.ContainsKey(data[i]))
           {
             alphabetCount[data[i]]++;
           }
           else
           {
             alphabetCount[data[i]]=1;
           }   
      }

      switch(alphabetCount.Count)
      {
          case1:
          game.rank=5;
          break;
        case 2:
          if(alphabetCount.ContainsValue(4))
          { game.rank=4;}
          else
          {
            game.rank=3;
          }
          break;
          case 3:
          if(alphabetCount.ContainsValue(3))
          { game.rank=3;}
          else
          {game.rank=2;
          }
          break;
        case 4: 
          if(alphabetCount.ContainsValue(2))
          game.rank=2;
          break
          case 5:
          game.rank=1;
          break;
      }
    }
      foreach(var game in games)
      {
        sum=sum+(game.rank * game.bidAmount);
      }
    }
  
}
}
