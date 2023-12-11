using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

public class ScratchCards
{
    int cardNo = 0;
    List<int> cardNumbers = new List<int>();
    List<int> winningNumbers = new List<int>();
    List<int> copyFinalList = new List<int>();
    List<int> orgFinalList = new List<int>();
    List<int> finalList = new List<int>();

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
        string file = @"C:\Users\Administrator\Documents\TDD\ScratchCardInput.txt";
        var obj = new ScratchCards();
        obj.TotalScratchCards(file);
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

    //total scratch cards calulation
    public int TotalScratchCards(string file)
    {
        int totalScratchCards = 0;
        string[] lines = { };
        if (File.Exists(file))
        {
            lines = File.ReadAllLines(file);
        }

        Tuple<int, List<int>, List<int>> result = null;
        var list = new List<string[]>();
        var TotalCardNumbers = new List<string[]>();
        int val = 0;
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

                cardNo = Convert.ToInt32(Regex.Replace(list[i][0], @"\s+", " ").Split(' ').ElementAt(1));
                TotalCardNumbers.Add(list[i][1].ToString().Split('|'));
                foreach (var wn in TotalCardNumbers[i][0].Replace("  ", " ").Trim().Split(' '))
                {
                    winningNumbers.Add(int.Parse(wn));
                }
                foreach (var wn in TotalCardNumbers[i][1].Replace("  ", " ").Trim().Split(' '))
                {
                    cardNumbers.Add(int.Parse(wn));
                }
                result = findInstancesPerCard(cardNo, winningNumbers, cardNumbers);
                val = ScratchCard(result, val);
            }
        }
        totalScratchCards = SumOfAllScarchCards(totalScratchCards);
        return totalScratchCards;
    }

    private int SumOfAllScarchCards(int totalScratchCards)
    {
        foreach (var obj in finalList)
        {
            totalScratchCards++;
        }
        foreach (var obj in orgFinalList)
        {
            totalScratchCards++;
        }

        return totalScratchCards;
    }

    //Making copies
    private int ScratchCard(Tuple<int, List<int>, List<int>> result, int val)
    {
        copyFinalList.AddRange(result.Item2);
        orgFinalList.AddRange(result.Item3);
        if (val == 0)
        {
            finalList.AddRange(copyFinalList);
            val = 1;
        }
        else if (result.Item1 > 0)
        {
            int counter = finalList.Count(x => x == cardNo);
            finalList.AddRange(Enumerable.Repeat(result.Item2, counter + 1).SelectMany(t => t).ToList());
        }

        return val;
    }

    //find instances for each card
    public Tuple<int, List<int>, List<int>> findInstancesPerCard(int cardNo, List<int> winningNumbers, List<int> cardNumbers)
    {
        int matchesPerCard = 0;
        List<int> copyList = new List<int>();
        List<int> orgList = new List<int>();
        //calculating winning points
        foreach (var card in cardNumbers)
        {
            if (winningNumbers.Contains(card))
            {
                matchesPerCard++;
            }
        }
        orgList.Add(cardNo);
        for (int i = 0; i < matchesPerCard; i++)
        {
            cardNo++;
            copyList.Add(cardNo);
        }
        return new Tuple<int, List<int>, List<int>>(matchesPerCard, copyList, orgList);
    }

}
