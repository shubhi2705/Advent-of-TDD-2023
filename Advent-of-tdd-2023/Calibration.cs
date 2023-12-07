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
           CamelGame camelgame = new CamelGame();
            camelgame.ReadData("Day7.txt");
            int finalValue = camelgame.CheckRank();
            Console.WriteLine("Final ways are {0}", finalValue);

        }
    }
}
