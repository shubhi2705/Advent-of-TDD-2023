using Advent_of_tdd_2023;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
namespace AdventOfCodeTDD
{
   public class Program
    {
        public static void Main()
        {
            Engine data = new Engine();
            data.ReadData("engine.txt");
            Console.WriteLine("Sum of Valid Parts is {0}", data.SumofEngineParts());
            Console.WriteLine("Sum of Gear Ratios is {0}", data.SumofGearRatios());
                             
        }
    }
}
