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
           EngineDetails data=new EngineDetails();
           data.ReadData("Engine.txt");
           Console.WriteLine("Sum of Valid Parts is {0}",data.SumOfEngineParts();
           Console.WriteLine("Sum of Gear Ratios is {0}",data.SumOfGearRatios();
                             
        }
    }
}
