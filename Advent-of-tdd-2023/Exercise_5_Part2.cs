using System;
using System.Collections.Generic;
using System.Linq;

class AlmanacProcessor
{
    public List<int> Seeds { get; set; }
    public List<List<List<int>>> Maps { get; set; }

    public AlmanacProcessor(string almanac)
    {
        Seeds = new List<int>();
        Maps = new List<List<List<int>>>();
        ParseInput(almanac);
    }

    private void ParseInput(string almanac)
    {
        var sections = almanac.Trim().Split("\n\n").Select(block => block.Split("\n").ToList()).ToList();
        Seeds = sections[0][0].Split(" ").Skip(1).Select(int.Parse).ToList();
        Maps = sections.Skip(1).Select(block => block.Skip(1).Select(line => line.Split(" ").Select(int.Parse).ToList()).ToList()).ToList();
    }

    public List<List<int>> ProcessMaps()
    {
        var values = Seeds.Select((_, i) => new List<int> { Seeds[i], Seeds[i] + Seeds[i + 1] }).ToList();

        foreach (var map in Maps)
        {
            var nextMap = new List<List<int>>();
            foreach (var (destStart, srcStart, length) in map)
            {
                var nextRange = new List<List<int>>();
                foreach (var (valLow, valHigh) in values)
                {
                    var sortedBounds = new List<int> { valLow, valHigh, srcStart, srcStart + length }.OrderBy(x => x).ToList();
                    for (int i = 0; i < sortedBounds.Count - 1; i++)
                    {
                        var low = sortedBounds[i];
                        var high = sortedBounds[i + 1];
                        if (valLow <= low && low < high && high <= valHigh)
                        {
                            if (srcStart <= low && low < high && high <= srcStart + length)
                            {
                                nextMap.Add(new List<int> { low - srcStart + destStart, high - srcStart + destStart });
                            }
                            else
                            {
                                nextRange.Add(new List<int> { low, high });
                            }
                        }
                    }
                }
                values = nextRange;
            }
            values.AddRange(nextMap);
        }

        return values;
    }

    public int FindMinimumLocation(List<List<int>> values)
    {
        return values.Select(pair => pair[0]).Min();
    }
}

class Program
{
    static void TestFindLowestLocationNumber()
    {
        const string almanac = @"seeds: 79 14 55 13

seed-to-soil map:
50 98 2
52 50 48

soil-to-fertilizer map:
0 15 37
37 52 2
39 0 15

fertilizer-to-water map:
49 53 8
0 11 42
42 0 7
57 7 4

water-to-light map:
88 18 7
18 25 70

light-to-temperature map:
45 77 23
81 45 19
68 64 13

temperature-to-humidity map:
0 69 1
1 0 69

humidity-to-location map:
60 56 37
56 93 4
";

        var processor = new AlmanacProcessor(almanac);
        var values = processor.ProcessMaps();
        var lowestLocation = processor.FindMinimumLocation(values);
        Console.WriteLine($"Test passed successfully: {lowestLocation == 46}");
    }

    static void Main()
    {
        // Read the input file
        string almanac = System.IO.File.ReadAllText("input.txt");

        var processor = new AlmanacProcessor(almanac);
        var values = processor.ProcessMaps();
        var minLocation = processor.FindMinimumLocation(values);

        Console.WriteLine($"Minimum location number: {minLocation}");
    }
}

