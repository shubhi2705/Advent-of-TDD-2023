using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
namespace AdventOfCodeTDD
{
   public class AlmanacAndGardening
    {
        public static void Main()
        {
            var al = new AlmanacAndGardening();
            al.Almanac();
        }
        public void Almanac()
        {
            var file = @"C:\Users\myfile.txt";
            var lines = File.ReadAllLines(file);
            var seedToSoilMappingList = new List<List<uint> > ();
            var soilToFertilizerMappingList = new List<List<uint>>();
            var fertilizerToWaterMappingList = new List<List<uint>>();
            var waterToLightMappingList = new List<List<uint>>();
            var lightToTemperatureMappingList = new List<List<uint >> ();
            var temperatureToHumidityMappingList = new List<List<uint>>();
            var humidityToLocationMappingList = new List<List<uint>>();
            var seedList = new List<uint> ();
            foreach (var line in lines)
            {
                if (line != "")
                {
                    if (line.Contains("seed-to-soil map:"))
                    {
                        var seedToSoilMapping = line.Split(':')[1].Trim().Split(';').ToList();
                        foreach (var mapping in seedToSoilMapping)
                        {
                            var a = mapping.Split(' ').ToArray();
                            var b = (Array.ConvertAll(a, UInt32.Parse)).ToList();
                            seedToSoilMappingList.Add(b);
                        }
                    }
                    else if (line.Contains("seed"))
                    {
                        var seed = line.Split(':')[1].Trim().Split(' ').ToArray();
                        seedList = Array.ConvertAll(seed, UInt32.Parse).ToList();
                    }
                    else if (line.Contains("soil-to-fertilizer map:"))
                    {
                        var soilToFertilizerMApping = line.Split(':')[1].Trim().Split(';').ToList();
                        foreach (var mapping in soilToFertilizerMApping)
                        {
                            var a = mapping.Split(' ').ToArray();
                            var b = (Array.ConvertAll(a, UInt32.Parse)).ToList();
                            soilToFertilizerMappingList.Add(b);
                        }
                    }
                    else if (line.Contains("fertilizer-to-water map:"))
                    {
                        var fertilizerToWaterMApping = line.Split(':')[1].Trim().Split(';').ToList();
                        foreach (var mapping in fertilizerToWaterMApping)
                        {
                            var a = mapping.Split(' ').ToArray();
                            var b = (Array.ConvertAll(a, UInt32.Parse)).ToList();
                            fertilizerToWaterMappingList.Add(b);
                        }
                    }
                    else if (line.Contains("water-to-light map:"))
                    {
                        var waterToLightMapping = line.Split(':')[1].Trim().Split(';').ToList();
                        foreach (var mapping in waterToLightMapping)
                        {
                            var a = mapping.Split(' ').ToArray();
                            var b = (Array.ConvertAll(a, UInt32.Parse)).ToList();
                            waterToLightMappingList.Add(b);
                        }
                    }
                    else if (line.Contains("light-to-temperature map:"))
                    {
                        var lightToTempMapping = line.Split(':')[1].Trim().Split(';').ToList();
                        foreach (var mapping in lightToTempMapping)
                        {
                            var a = mapping.Split(' ').ToArray();
                            var b = (Array.ConvertAll(a, UInt32.Parse)).ToList();
                            lightToTemperatureMappingList.Add(b);
                        }
                    }
                    else if (line.Contains("temperature-to-humidity map:"))
                    {
                        var tempToHumidityMapping = line.Split(':')[1].Trim().Split(';').ToList();
                        foreach (var mapping in tempToHumidityMapping)
                        {
                            var a = mapping.Split(' ').ToArray();
                            var b = (Array.ConvertAll(a, UInt32.Parse)).ToList();
                            temperatureToHumidityMappingList.Add(b);
                        }
                    }
                    else if (line.Contains("humidity-to-location map:"))
                    {
                        var humidityToLocationMApping = line.Split(':')[1].Trim().Split(';').ToList();
                        foreach (var mapping in humidityToLocationMApping)
                        {
                            var a = mapping.Split(' ').ToArray();
                            var b = (Array.ConvertAll(a, UInt32.Parse)).ToList();
                            humidityToLocationMappingList.Add(b);
                        }
                    }
                }
               
            }

            if (lines.Length != 0)
            {
                var soilList = seedToSoilMapping(seedList, seedToSoilMappingList);
                var fertilizerList = soilToFertilizerMapping(soilList, soilToFertilizerMappingList);
                var waterList = fertilizerToWaterMapping(fertilizerList, fertilizerToWaterMappingList);
                var lightList=waterToLightMapping(waterList, waterToLightMappingList);
                var temperatureList = lightToTemperatureMapping(lightList, lightToTemperatureMappingList);
                var humidityList = temperatureToHumidityMapping(temperatureList, temperatureToHumidityMappingList);
                var locationList=humidityToLocationMapping(humidityList, humidityToLocationMappingList);
                var minLocation = calculateMinLocation(locationList);

                
                
//                Seed 79, soil 81, fertilizer 81, water 81, light 74, temperature 78, humidity 78, location 82.
//Seed 14, soil 14, fertilizer 53, water 49, light 42, temperature 42, humidity 43, location 43.
//Seed 55, soil 57, fertilizer 57, water 53, light 46, temperature 82, humidity 82, location 86.
//Seed 13, soil 13, fertilizer 52, water 41, light 34, temperature 34, humidity 35, location 35.
            }
        }

        public uint calculateMinLocation(List<uint> location)
        {
            if (location.Count()>0)
            {
                return location.Min();
            }
            return 0;

        }

        //comments
        public List<uint> seedToSoilMapping(List<uint> seedList, List<List<uint>> seedToSoilMappingList)
        {
            var soilDict = new Dictionary<uint, uint>();
            var seedToSoilList = new List<uint>();
            Parallel.ForEach(seedToSoilMappingList, map =>
            {
                var list = map.ToArray();
                var start = list[1];
                var end = list[0];
                var range = list[2];
                while (range > 0)
                {
                    soilDict.Add(start, end);
                    start++;
                    end++;
                    range--;
                }
            });
            foreach(var seed in seedList)
            {
                if (soilDict.ContainsKey(seed))
                {
                    seedToSoilList.Add(soilDict[seed]);
                }
                else
                {
                    seedToSoilList.Add(seed);
                }
            }
            return seedToSoilList;
        }

        public List<uint> soilToFertilizerMapping(List<uint> soilList, List<List<uint>> soilToFertilizerMappingList)
        {
            var soilDict = new Dictionary<uint, uint>();
            var soilToFertilizerList = new List<uint>();
            foreach (var map in soilToFertilizerMappingList)
            {
                var list = map.ToArray();
                var start = list[1];
                var end = list[0];
                var range = list[2];
                while (range > 0)
                {
                    soilDict.Add(start, end);
                    start++;
                    end++;
                    range--;
                }
            }
            foreach (var seed in soilList)
            {
                if (soilDict.ContainsKey(seed))
                {
                    soilToFertilizerList.Add(soilDict[seed]);
                }
                else
                {
                    soilToFertilizerList.Add(seed);
                }
            }
            return soilToFertilizerList;
        }

        public List<uint> fertilizerToWaterMapping(List<uint> fertilizerList, List<List<uint>> fertilizerToWaterMappingList)
        {
            var soilDict = new Dictionary<uint, uint>();
            var fertilizerToWaterList = new List<uint>();
            foreach (var map in fertilizerToWaterMappingList)
            {
                var list = map.ToArray();
                var start = list[1];
                var end = list[0];
                var range = list[2];
                while (range > 0)
                {
                    soilDict.Add(start, end);
                    start++;
                    end++;
                    range--;
                }
            }
            foreach (var seed in fertilizerList)
            {
                if (soilDict.ContainsKey(seed))
                {
                    fertilizerToWaterList.Add(soilDict[seed]);
                }
                else
                {
                    fertilizerToWaterList.Add(seed);
                }
            }
            return fertilizerToWaterList;
        }

        public List<uint> waterToLightMapping(List<uint> waterList, List<List<uint>> waterToLightMappingList)
        {
            var soilDict = new Dictionary<uint, uint>();
            var waterToLightList = new List<uint>();
            foreach (var map in waterToLightMappingList)
            {
                var list = map.ToArray();
                var start = list[1];
                var end = list[0];
                var range = list[2];
                while (range > 0)
                {
                    soilDict.Add(start, end);
                    start++;
                    end++;
                    range--;
                }
            }
            foreach (var seed in waterList)
            {
                if (soilDict.ContainsKey(seed))
                {
                    waterToLightList.Add(soilDict[seed]);
                }
                else
                {
                    waterToLightList.Add(seed);
                }
            }
            return waterToLightList;
        }

        public List<uint> lightToTemperatureMapping(List<uint> lightList, List<List<uint>> lightToTemperatureMappingList)
        {
            var soilDict = new Dictionary<uint, uint>();
            var lightToTemperatureList = new List<uint>();
            foreach (var map in lightToTemperatureMappingList)
            {
                var list = map.ToArray();
                var start = list[1];
                var end = list[0];
                var range = list[2];
                while (range > 0)
                {
                    soilDict.Add(start, end);
                    start++;
                    end++;
                    range--;
                }
            }
            foreach (var seed in lightList)
            {
                if (soilDict.ContainsKey(seed))
                {
                    lightToTemperatureList.Add(soilDict[seed]);
                }
                else
                {
                    lightToTemperatureList.Add(seed);
                }
            }
            return lightToTemperatureList;
        }

        public List<uint> temperatureToHumidityMapping(List<uint> tempList, List<List<uint>> temperatureToHumidityMappingList)
        {
            var soilDict = new Dictionary<uint, uint>();
            var temperatureToHumidityList = new List<uint>();
            foreach (var map in temperatureToHumidityMappingList)
            {
                var list = map.ToArray();
                var start = list[1];
                var end = list[0];
                var range = list[2];
                while (range > 0)
                {
                    soilDict.Add(start, end);
                    start++;
                    end++;
                    range--;
                }
            }
            foreach (var seed in tempList)
            {
                if (soilDict.ContainsKey(seed))
                {
                    temperatureToHumidityList.Add(soilDict[seed]);
                }
                else
                {
                    temperatureToHumidityList.Add(seed);
                }
            }
            return temperatureToHumidityList;
        }

        public List<uint> humidityToLocationMapping(List<uint> humidityList, List<List<uint>> humidityToLocationMappingList)
        {
            var soilDict = new Dictionary<uint, uint>();
            var humidityToLocationList = new List<uint>();
            foreach (var map in humidityToLocationMappingList)
            {
                var list = map.ToArray();
                var start = list[1];
                var end = list[0];
                var range = list[2];
                while (range > 0)
                {
                    soilDict.Add(start, end);
                    start++;
                    end++;
                    range--;
                }
            }
            foreach (var seed in humidityList)
            {
                if (soilDict.ContainsKey(seed))
                {
                    humidityToLocationList.Add(soilDict[seed]);
                }
                else
                {
                    humidityToLocationList.Add(seed);
                }
            }
            return humidityToLocationList;
        }
    }
}
