using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
namespace AdventOfCodeTDD
{
   public class Calibration
    {
        public static void Main()
        {
            CodeCheck check = new CodeCheck();
            check.ReadData("code.txt");
            var a = check.GetSum();
            Console.WriteLine($"Sum is: {a}");
            var steps = File.ReadAllText(@"C:\Users\MSUSERSL123\Documents\Data\code.txt").Trim().Split(',');
            var b = check.GetPart2Sum(steps);
            Console.WriteLine(b);
        }
    }
   public class CodeCheck
{
    public List<AsciiData> asciiDatas = new List<AsciiData>();
    public List<FinalResult> actualResult = new List<FinalResult>();
    public List<string> values = new List<string>();
    public char OP_EQUAL = '=';
    public char OP_MINUS = '-';


    public void ReadData(string fileName)
    {
        string file = @"C:\Users\MSUSERSL123\Documents\Data\" + fileName;
        if (File.Exists(file))
        {
            string[] lines = File.ReadAllLines(file);
            foreach (var line in lines)
            {
                string[] splitted = line.Split(",");
                foreach (var val in splitted)
                {
                    values.Add(val);
                }
            }
        }
        else
        {
            throw new FileNotFoundException();
        }

        GetAsciiList();
    }
    public void GetAsciiList()
    {
        for (int i = 0; i <= 127; i++)
        {
            char letter = (char)i;
            AsciiData asciiData = new AsciiData();
            asciiData.data = letter.ToString();
            asciiData.value = i;
            asciiDatas.Add(asciiData);
        }
    }

    public int GetSum()
    {
        int sum = 0;

        foreach (var item in values)
        {
            GetTheCalculatedResult(item);
        }

        sum = actualResult.Sum(x => x.calculatedValue);
        return sum;
    }


    public void GetTheCalculatedResult(string s)
    {
        int value = 0;
        for (int i = 0; i < s.Length; i++)
        {
            string lim = s[i].ToString();
            var check = asciiDatas.Where(x => x.data == lim).FirstOrDefault();
            value += Convert.ToInt32(check.value);
            value = value * 17;
            value = value % 256;
        }
        FinalResult final = new FinalResult();
        final.initalValue = s;
        final.calculatedValue = value;
        actualResult.Add(final);
    }

    public int Hash(string part) => part.Aggregate(0, (current, c) => (current + c) * 17 % 256);


    public  void UpdateBox(Dictionary<int, List<(string, int)>> boxes, string instruction)
    {
        int eq = instruction.IndexOf('=');
        if (eq > -1)
        {
            string label = instruction.Substring(0, eq);
            int box = Hash(label);
            int i = boxes[box].FindIndex(p => p.Item1 == label);
            if (i == -1)
                boxes[box].Add((label, int.Parse(instruction.Substring(eq + 1))));
            else
                boxes[box][i] = (label, int.Parse(instruction.Substring(eq + 1)));
        }
        else
        {
            string label = instruction.Substring(0, instruction.IndexOf('-'));
            int box = Hash(label);
            boxes[box].RemoveAll(p => p.Item1 == label);
        }
    }

    public int CalcFocusPower(Dictionary<int, List<(string, int)>> boxes)
    {
        int fp = 0;
        for (int j = 0; j < 256; j++)
        {
            int sum = 0;
            for (int k = 0; k < boxes[j].Count; k++)
                sum += (k + 1) * boxes[j][k].Item2;
            fp += (j + 1) * sum;
        }

        return fp;
    }

    public int GetPart2Sum()
    {

        int sum = 0;
        string file = @"C:\Users\MSUSERSL123\Documents\Data\code.txt";
        var steps = File.ReadAllText(file).Trim().Split(',');
        var boxes = new Dictionary<int, List<(string, int)>>();
        for (int j = 0; j < 256; j++)
            boxes[j] = new List<(string, int)>();

        foreach (string s in steps)
            UpdateBox(boxes, s);

        sum = CalcFocusPower(boxes);
        return sum;


    }

}


public class AsciiData
{
    public string data;
    public int value;

}

public class FinalResult
{
    public string initalValue;
    public int calculatedValue;
}

}
