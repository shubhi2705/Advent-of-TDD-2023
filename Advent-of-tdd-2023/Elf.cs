using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Net.Http;
namespace AdventOfCodeTDD
{
   public class Elf
    {
        public static void Main()
        {
            var elf = new Elf();
            elf.ElfAndCubes();
        }
        public int ElfAndCubes(string file = "")
        {
            file = @"C:\Users\myfile.txt";
            if (File.Exists(file))
            {
                // Store each line in array of strings 
                string[] lines = File.ReadAllLines(file);
                var sum= calculateSumForValidGames(lines); // Part-1 of day2
                var powerSum = calculatePowerSum(lines);
                return sum;
            }
            else
            {
                throw new FileNotFoundException();
            }
        }

        //Part-1 of the 2nd day exercise
        public int calculateSumForValidGames(string[] gamesInput)
        {
            try
            {
                var resultForValidSum = 0;
                foreach (var games in gamesInput)
                {
                    String[] game = games.Split(":");
                    var sets = game[1].Split(";");
                    var gameId = Convert.ToInt32(game[0].Split(" ")[1]);
                    bool isSetValid = checkValidity(sets);
                    int resultForPowerSum = 0;
                    if (isSetValid)
                    {
                        resultForValidSum += gameId;
                    }

                }
                return resultForValidSum;
            }
            catch(Exception e)
            {
                throw new IndexOutOfRangeException();

            }


        }
        //Part-2 of 2nd day exercise
        public int calculatePowerSum(string[] gamesInput)
        {
            try
            {
                int resultForPowerSum = 0;
                foreach (var games in gamesInput)
                {
                    String[] game = games.Split(":");
                    var sets = game[1].Split(";");
                    var gameId = Convert.ToInt32(game[0].Split(" ")[1]);
                    int powerSum = checkMinCubes(sets);
                    resultForPowerSum += powerSum;

                }
                return resultForPowerSum;
            }
            catch (Exception ex)
            {
                throw new IndexOutOfRangeException();
            }
           
        }
        public bool checkValidity(string[] sets)
        {
            foreach (var set in sets)
            {
                var cubesWithdrawn = set.Split(",").ToList();
                foreach (var item in cubesWithdrawn)
                {
                    var trimmedItem = item.Trim();
                    var countOfCubes = Convert.ToInt32(trimmedItem.Split(" ")[0]);
                    var cubeType = trimmedItem.Split(" ")[1];
                    if (cubeType.Equals("red") && countOfCubes>12)
                    {
                        return false;
                    }
                    if (cubeType.Equals("green") && countOfCubes>13)
                    {
                        return false;
                    }
                    if (cubeType.Equals("blue") && countOfCubes>14)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
        public int checkMinCubes(string[] sets)
        {
            var minRed = 0;
            var minBlue = 0;
            var minGreen = 0;
            foreach(var set in sets)
            {
                var items = set.Split(",");
                foreach (var item  in items)
                {
                    var color = item.Trim().Split(" ")[1];
                    var colorCount = Convert.ToInt32(item.Trim().Split(" ")[0]);
                    if (color.Equals("red"))
                    {
                        if (colorCount > minRed)
                            minRed = colorCount;
                    }
                    if (color.Equals("blue"))
                    {
                        if (colorCount > minBlue)
                            minBlue = colorCount;
                    }
                    if (color.Equals("green"))
                    {
                        if (colorCount > minGreen)
                            minGreen = colorCount;
                    }
                }
               
            }
            var powerSum = minGreen * minRed * minBlue;
            return powerSum;
        }
    }
    
}
