using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_tdd_2023
{
    public class EngineDetail
    {
    public List<Symbols> symbols = new List<Symbols>();
    public List<Parts> parts = new List<Parts>();

    public void ReadData(string FileName)
    {
        string file = @"C:\Users\MSUSERSL123\Documents\Data\" + FileName;
        if (File.Exists(file))
        {
            string[] allLines = File.ReadAllLines(file);
            int row = 0;
            foreach (var line in allLines)
            {
                SymbolsInRow(row, line);
                PartNumbersInRow(row, line);
                row++;
            }
        }
        else
        {
            throw new FileNotFoundException();
        }
    }

    public void PartNumbersInRow(int row, string data)
    {
        for (int i = 0; i < data.Length; i++)
        {
            if (char.IsDigit(data[i]))
            {
                for (int j = i; i < data.Length; j++)
                {
                    if (j == data.Length - 1 || !char.IsDigit(data[j + 1]))
                    {
                        var len = j - i + 1;
                        parts.Add(new Parts(i, j, row, data.Substring(i, len)));
                        i = j;
                        break;
                    }
                }
            }
        }
    }

    public void SymbolsInRow(int row, string data)
    {
        for (int i = 0; i < data.Length; i++)
        {
            if (data[i] != '.' && !char.IsDigit(data[i]))
            {
                symbols.Add(new Symbols(i, row));
            }
        }
    }

    public int SumofEngineParts()
    {
        int sum = 0;
        foreach (var part in parts)
        {
            foreach (var symbol in symbols)
            {
                if (symbol.IsValidPart(part))
                {
                    sum += part.number;
                    break;
                }
            }
        }
        return sum;
    }

    public int SumofGearRatios()
    {
        int sum = 0;
        foreach (var symbol in symbols)
        {
            if (symbol.IsGear(parts))
            {
                sum += symbol.gearRatio();
            }
        }
        return sum;

    }

}

public class Parts
{
    public int a1, a2, b;
    public int number;
    public Parts(int a, int b, int c, string number)
    {
        this.a1 = a;
        this.a2 = b;
        this.b = c;
        this.number = Convert.ToInt32(number);
    }
}

public class Symbols
{

    int a, b;
    List<Parts> adjacentParts = new List<Parts>();

    public Symbols(int a, int b)
    {
        this.a = a;
        this.b = b;
    }

    public bool IsValidPart(Parts part)
    {
        bool left = a == part.a1 - 1 && b == part.b;
        bool right = a == part.a2 + 1 && b == part.b;
        bool top = a >= part.a1 && a <= part.a2 && b == part.b - 1;
        bool bottom = a >= part.a1 && a<= part.a2 && b == part.b + 1;
        bool diagonaltopRight = a == part.a2 + 1 && b== part.b - 1;
        bool diagonalbottomRight = a == part.a2 + 1 && b == part.b + 1;
        bool diagonaltopLeft = a == part.a1 - 1 && b == part.b - 1;
        bool diagonalbottomLeft = a == part.a1 - 1 && b == part.b + 1;

        return left || right || top || bottom || diagonalbottomLeft || diagonalbottomRight || diagonaltopLeft || diagonaltopRight;
    }

    public bool IsGear(List<Parts> parts)
    {
        adjacentParts = new List<Parts>();
        foreach (var part in parts)
        {
            if (IsValidPart(part))
            {
                adjacentParts.Add(part);
            }
        }
        return adjacentParts.Count() == 2;
    }

    public int gearRatio()
    {
        if (adjacentParts.Count() != 2)
        {
            throw new Exception(" not a gear!!");
        }
        return adjacentParts[0].number * adjacentParts[1].number;
    }
    }

}
