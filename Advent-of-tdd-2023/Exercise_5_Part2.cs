using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

class SeedLocationCalculator
{
    private readonly string almanac;
    private readonly List<long> seeds;
    private readonly List<List<string>> mappings;

    public SeedLocationCalculator(string almanac)
    {
        this.almanac = almanac;
        (seeds, mappings) = ParseInput(almanac);
    }

    public long FindLowestLocationNumber()
    {
        var seedLocations = new Dictionary<long, long>();
        foreach (var seed in seeds)
        {
            var currentNumber = seed;
            foreach (var mapData in mappings)
            {
                currentNumber = FindMappedNumber(currentNumber, mapData);
            }
            seedLocations[seed] = currentNumber;  // location of seed in the last map
        }
        return seedLocations.Values.Min();
    }

    private (List<long>, List<List<string>>) ParseInput(string inputData)
    {
        var sections = inputData.Trim().Split("\n\n");
        var seeds = sections[0].Split(": ")[1].Split().Select(long.Parse).ToList();
        var mappings = sections.Skip(1).Select(section => section.Split(":\n")[1].Split('\n').ToList()).ToList();
        return (seeds, mappings);
    }

    private long FindMappedNumber(long number, List<string> mapData)
    {
        foreach (var line in mapData)
        {
            if (!string.IsNullOrWhiteSpace(line))
            {
                var parts = line.Split().Select(long.Parse).ToArray();
                var destStart = parts[0];
                var srcStart = parts[1];
                var length = parts[2];
                if (srcStart <= number && number < srcStart + length)
                {
                    return destStart + (number - srcStart);
                }
            }
        }
        return number;
    }
}

class Program
{
    static void Main()
    {
        var almanac = File.ReadAllText("input.txt");

        var calculator = new SeedLocationCalculator(almanac);
        var lowestLocation = calculator.FindLowestLocationNumber();
        Console.WriteLine("The lowest location number is: " + lowestLocation);
    }

    static void TestFindLowestLocationNumber()
    {
        var almanac = @"seeds: 79 14 55 13

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
56 93 4";

        var calculator = new SeedLocationCalculator(almanac);
        var lowestLocation = calculator.FindLowestLocationNumber();
        Console.WriteLine("The lowest location number is: " + lowestLocation);
    }
}

