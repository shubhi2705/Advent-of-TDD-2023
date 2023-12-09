using AdventOfCodeTDD;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_of_tdd_2023
{
    public  class Navigation
    {
        static void Main(string[] args)
        {
            Navigation_1 nav1 = new Navigation_1();
            Navigation_2 nav2 = new Navigation_2();
            var nav_file = @"C:\Users\Navigation1.txt";
            var directionInput = "LLLLLLLRRRLRRRLRLRLRLRRLLRRRLRLLRRRLLRRLRRLRRLRLRRLRLRRRLRRLRLRRRLRRLRRLRLRRLLRLLRLRRRLRRLRLLLLRRLLLLRLRLRLRRRLRLRLLLRLRRRLRRRLRRRLRLRRLRRRLRLLLRLLRRLRRRLRRLRRLRRLRLRRRLRLRLRLLRRRLRRRLRRLRRRLLLRRLRRLRRRLRLRRRLRRRLRLRRLRRRLRLRRLRLRRLRRRLRLRRLRLLRRRLLRLRRLRRRLLLRLRRLRRRR";
            var directions = new int[] { };
            directions = directionInput.ToCharArray().Select(t => "LR".IndexOf(t)).ToArray();
            var map = nav1.getFileContents(nav_file);
            var part1_steps = nav1.calculateSteps(directions, nav_file);
            Console.WriteLine("Part-1 Solution for number of count of steps: ", part1_steps);

            var part2_steps = nav2.calculateSteps(directions, nav_file);
            Console.WriteLine("Part-2 Solution for number of count of steps: ", part2_steps);
        }
}
}
