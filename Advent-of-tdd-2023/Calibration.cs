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
        }
        public void CalibrationDocument()
        {
            try
            {
                string file = @"C:\Users\myfile1.txt";
                if (File.Exists(file))
                {
                    // Store each line in array of strings 
                    string[] lines = File.ReadAllLines(file);
                    var sum = 0;
                    foreach (string ln in lines)
                    {
                        var num= calculate_CalibrationValue(ln);
                        sum += num;
                    }
                    var a = sum;
                }
                else
                {
                    throw new FileNotFoundException("File not found");
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
            }
            
        }
        public int calculate_CalibrationValue(string value)
        {
            var list = new List<char>();
            var num= 0;
            foreach (var s in value)
            {
                if (s >= '0' && s <= '9')
                {
                    list.Add(s);
                }
            }
            if (list.Count == 1)
            {
                list.Add(list.FirstOrDefault());
            }
            if (list.Count != 0)
            {
                num = Convert.ToInt32(list.FirstOrDefault().ToString() + list.LastOrDefault().ToString());
            }

            return num;
        }
    }
}
