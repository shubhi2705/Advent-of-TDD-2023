using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using static System.Runtime.InteropServices.JavaScript.JSType;
namespace AdventOfCodeTDD
{
    public class PredictHistory
    {
        public static void Main()
        {           
            var fileName = @"C:\Users\Mirage.txt";
            int sum2 = 0;
            var c = new PredictHistory();
            var input = c.convertInput(fileName);
            int sum1=c.PredictHistoryByInput(input,out sum2);
            Console.WriteLine("Part-1 Sum is:", sum1);
            Console.WriteLine("Part-2 Sum is:", sum2);
        }

        public int PredictHistoryByInput(List<List<int>> input,out int sum2)
        {
            var sum1 = 0;
            sum2 = 0;
            var c = new PredictHistory();
            foreach (var sequence in input)
            {
                var s = new List<List<int>>() { sequence };
                var list = c.getListUntillZeroes(s);
                var prediction1 = c.predictHistory_Part1(list);
                var prediction2 = c.predictHistory_Part2(list);
                sum2 += prediction2;
                sum1 += prediction1;
            }
            return sum1;
            
        }
        public List<List<int>> convertInput(string fileName)
        {
            if(string.IsNullOrEmpty(fileName) || !File.Exists(fileName))
            {
                throw new FileNotFoundException();
            }
            var lines = File.ReadLines(fileName);
            if (lines.Count() == 0)
            {
                throw new InvalidDataException();
            }
            var input = new List<List<int>>();
            foreach (var line in lines)
            {
                var seq = line.Trim().Split(' ');
                var sequence = Array.ConvertAll(seq, int.Parse);
                input.Add(sequence.ToList());
            }
            return input;
        }

        public List<List<int>> getListUntillZeroes(List<List<int>> list)
        {
            while (true)
            {
                var obj = getDifferencesUntillZero(list.LastOrDefault());
                list.Add(obj.sequence);
                if (obj.isFinal)
                {
                    return list;
                }
            }
        }
        public Sequence getDifferencesUntillZero(List<int> sequence)
        {
            var isFinal = true;
            var newSequence = new List<int>();
            for(int i = 1; i < sequence.Count; i++)
            {
                var current= sequence.ElementAt(i);
                var previous = sequence.ElementAt(i - 1);
                var delta = current - previous;
                newSequence.Add(delta);
                if (delta != 0) { isFinal = false; }

            }
            var obj = new Sequence()
            {
                sequence = newSequence,
                isFinal = isFinal
            };
            return obj;
        }
        public int predictHistory_Part1(List<List<int>> list)
        {
           // var newList = list.AddRange(0);
            for(int i=list.Count-1; i >0; i--)
            {
                var currentSeq = list.ElementAt(i - 1);
                var nextSeq = list.ElementAt(i);
                var a = currentSeq.LastOrDefault();
                var c = nextSeq.LastOrDefault();
                currentSeq.Add(a + c);
            }
            return list.FirstOrDefault().LastOrDefault();
        }

        public int predictHistory_Part2(List<List<int>> list)
        {
            // var newList = list.AddRange(0);
            for (int i = list.Count - 1; i > 0; i--)
            {
                var currentSeq = list.ElementAt(i - 1);
                var nextSeq = list.ElementAt(i);
                var a = currentSeq.FirstOrDefault();
                var c = nextSeq.FirstOrDefault();
                currentSeq.Insert(0, a - c);
            }
            return list.FirstOrDefault().FirstOrDefault();
        }
    }
    public class Sequence
    {
        public List<int> sequence;
        public bool isFinal;
    }
}

