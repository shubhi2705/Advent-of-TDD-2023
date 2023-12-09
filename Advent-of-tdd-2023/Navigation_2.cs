using AdventOfCodeTDD;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Advent_of_tdd_2023
{
    public class Navigation_2
    {
        public int calculateSteps(int[] directions, string file = "")
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
                steps = getSteps(navigations, directions);   
            }
            else
            {
                throw new FileNotFoundException("File not found");
            }
            return steps;
        }

        public int getSteps(Dictionary<string, string[]> navigations, int[] directions)
        {
            var stepCountforNode = new List<int>();
            foreach (var node in navigations.Keys)
            {
                if (node.EndsWith('A'))
                {
                    stepCountforNode.Add(getCountOfSteps(node, navigations, directions));
                }
            }
            var steps = lowestCommonMultiple(stepCountforNode.ToArray());
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
        public int getCountOfSteps(string node, Dictionary<string, string[]> navigations, int[] dirs)
        {
            var navigation = navigations.Where(n => n.Key.Equals(node)).FirstOrDefault();
            int step = 0;
            for (step = 0; ; ++step)
            {
                if (node.EndsWith('Z'))
                    return step;
                else
                    node = navigations[node][dirs[step % dirs.Length]];
            }
            return step;
        }


        public int lowestCommonMultiple(int[] stepRoutes)
        {
            var multiple = stepRoutes[0];
            for (int i = 1; i < stepRoutes.Length; i++)
            {
                multiple = LCM(multiple, stepRoutes[i]);
            }
            return multiple;

        }
        public int LCM(int a, int b)
        {
            int num1 = a > b ? a : b;
            int num2= a > b ? b : a;
            for (int i = 1; i <= num2; i++)
            {
                if ((num1 * i) % num2 == 0)
                {
                    return i * num1;
                }
            }
            return num2;
        }
    }

}

