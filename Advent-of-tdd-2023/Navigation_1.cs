using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
using System.Reflection;
namespace AdventOfCodeTDD
{
    public class Navigation_1
    {
     
        public int calculateSteps(int[] directions ,string file = "")
        {
            var steps = 0;
            var navigations = new Dictionary<string, string[]>();
            if (directions.Length == 0)
            {
                throw new ArgumentNullException("Directions cannot be null/empty");
            }
            if (File.Exists(file))
            {
                //15871
                navigations = getFileContents(file);
                steps = getCountOfSteps(directions, navigations);
            }
            else
            {
                throw new FileNotFoundException("File not found");
            }
            return steps;
        }

        public Dictionary<string, string[]> getFileContents(string file)
        {
            string[] lines = File.ReadAllLines(file);
            var navigations = new Dictionary<string, string[]>();
            if (lines.Length == 0)
            {
                throw new InvalidDataException("File is Empty");
            }
            foreach (string ln in lines)
            {
                var currentInput = ln.Split('=')[0].Trim();
                var leftInput = ln.Split('=')[1].Trim().Split('(')[1].Trim().Split(',')[0].Trim();
                var rightInput = ln.Split('=')[1].Trim().Split('(')[1].Trim().Split(',')[1].Trim().Replace(')', ' ').Trim();
                navigations.Add(currentInput, new string[] { leftInput, rightInput });
            }
            return navigations;
        }
        public int getCountOfSteps(int[] dirs, Dictionary<string, string[]> map)
        {
            if(dirs.Length<=1 && !map.FirstOrDefault().Key.Equals("ZZZ"))
            {
                throw new ArgumentException("PRovided arguments are not correct");
            }
            if (dirs.Length <= 1 && map.FirstOrDefault().Key.Equals("ZZZ"))
            {
                return 0;
            }
            int step = 0;
            for (var node = "AAA"; node != "ZZZ"; ++step)
                node = map[node][dirs[step % dirs.Length]];
            return step;
        }
    }
}
