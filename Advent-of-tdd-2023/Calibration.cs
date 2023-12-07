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
           CamelGames camelgame=new CamelGames();
           camelgame.ReadData("Game.txt");
           int finalValue=camelgame.CheckRank();
           Console.WriteLine("Final ways are {0}",finalValue);
        }
    }
}
