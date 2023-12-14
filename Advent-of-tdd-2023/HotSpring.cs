using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace AdventOfCodeTDD2023
{
    public class HotSpring
    {
        public static void Main(string[] args)
        {
            var fileName = @"C:\Users\HotSpring.txt";
            var hotSpring = new HotSpring();
            var data1 = hotSpring.readFile(fileName,hotSpring);
            var data2 = hotSpring.readFile(fileName, hotSpring);

            var result1 =hotSpring.get_result_for_part1(data1);
            var result2 = hotSpring.get_result_for_part2(data2);

            Console.WriteLine("Part 1 results:", result1);
            Console.WriteLine("Part 1 results:", result2);
        }
        public long get_result_for_part1((string, int[])[] data)
        {
            var result1 = data.Sum(t=>Count(t,1));
            return result1;
        }
        public long get_result_for_part2((string, int[])[] data)
        {
            var result2 = data.Sum(t => Count(t, 5));
            return result2;
        }

        private static long Count((string s, int[] lens) t, int n)
        {
            string s = string.Join('?', Enumerable.Repeat(t.s, n));
            int[] lens = Enumerable.Repeat(t.lens, n).SelectMany(v => v).ToArray();
            return Count(s, lens, new());
        }

        private static long Count(string s, int[] lens, Dictionary<int, long> counts, int key = 0)
        {
            if (counts.TryGetValue(key, out long count))
                return count;
            if (lens.Length == 0)
                return counts[key] = s.Any(c => c == '#') ? 0 : 1;
            int len = lens[0];
            int max = s.Length - lens.Length - Math.Max(len, lens.Sum() - 1);
            int k = s[..len].Count(c => c != '.');
            for (int first = 0, last = len; first <= max;)
            {
                char c = s[first++], d = s[last++];
                if (k == len && d != '#')
                    count += Count(s[last..], lens[1..], counts, key + last * 32 + 1);
                if (c == '#')
                    return counts[key] = count;
                k += (d == '.' ? 0 : 1) - (c == '.' ? 0 : 1);
            }
            if (k == len && lens.Length == 1)
                ++count;
            return counts[key] = count;
        }

        public (string, int[])[] readFile(string fileName, HotSpring hotSpring)
        {
            if (string.IsNullOrEmpty(fileName))
            {
                throw new FileNotFoundException();
            }
            var input = File.ReadLines(fileName).ToList();
            if (input == null || input.Count == 0)
            {
                throw new InvalidOperationException();
            }
            var data = hotSpring.ParseInput(input);
            return data;

        }
        public (string, int[])[] ParseInput(List<string> input)
        {
            var data = input.Select(s => s.Split(' '));
            var result= data.Select(ss=>(ss[0], ss[1].Split(',').Select(int.Parse).ToArray()));      
            return result.ToArray();
        }        
    }
}