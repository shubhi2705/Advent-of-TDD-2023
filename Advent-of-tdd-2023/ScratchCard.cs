using System.Collections.Generic;
using System.IO;
using System.Linq;

public class ScratchCards
{
    int winningPoints = 0;
    int cardNo = 0;
    List<int> cardNumbers = new List<int>();
    List<int> winningNumbers = new List<int>();
    public ScratchCards()
    {

    }
    public ScratchCards(int cardNo, List<int> winningNumbers, List<int> cardNumbers)
    {
        this.cardNo = cardNo;
        this.winningNumbers = winningNumbers;
        this.cardNumbers = cardNumbers;
    }

    public static void Main()
    {
        string file = @"C:\MSDE\POC\TDD\ScratchCard.txt";
        var obj = new ScratchCards();
        obj.TotalPoints(file);
    }
    public int getTotalCards(string file = "")
    {
        if (File.Exists(file))
        {
            string[] lines = File.ReadAllLines(file);
            return cardNo = lines.Count();
        }
        else
        {
            throw new FileNotFoundException();
        }
    }

    //check if card has winner
    public bool isWinner_in_Card()
    {
        foreach (var card in cardNumbers)
        {
            if (winningNumbers.Contains(card))
            {
                return true;
            }
        }
        return false;
    }

    //Get total winning points for each card
    public int GetTotalPoints_In_EachCardNumber(List<int> winningNumbers, List<int> cardNumbers)
    {
        int result = 0;
        winningPoints = 0;
        //calculating winning points
        foreach (var card in cardNumbers)
        {
            if (winningNumbers.Contains(card))
            {
                winningPoints++;
            }
        }
        for (int i = 0; i < winningPoints; i++)
        {
            if (result == 0)
            {
                result = 1;//first match
            }
            else
            {
                result = 2;//doubling the subsequent matches
            }
        }
        return result;
    }


    //total worth winning points
    public int TotalPoints(string file)
    {
        string[] lines = { };
        if (File.Exists(file))
        {
            lines = File.ReadAllLines(file);
        }
        int finalCount = 0;
        var list = new List<string[]>();
        var TotalCardNumbers = new List<string[]>();
        foreach (var ln in lines)
        {
            list.Add(ln.Split(':'));
        }
        if (list != null && list.Count > 0)
        {
            for (int i = 0; i < list.Count; i++)
            {
                cardNumbers = new List<int>();
                winningNumbers = new List<int>();
                TotalCardNumbers.Add(list[i][1].ToString().Split('|'));
                foreach (var wn in TotalCardNumbers[i][0].Replace("  ", " ").Trim().Split(' '))
                {
                    winningNumbers.Add(int.Parse(wn));
                }
                foreach (var wn in TotalCardNumbers[i][1].Replace("  ", " ").Trim().Split(' '))
                {
                    cardNumbers.Add(int.Parse(wn));
                }
                finalCount += GetTotalPoints_In_EachCardNumber(winningNumbers, cardNumbers);
            }
        }
        return finalCount;
    }
}
