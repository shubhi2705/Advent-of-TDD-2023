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
            var obj = new Calibration();
            obj.CalibrationDocument();
        }
        public void CalibrationDocument(string file="")
        {
            try
            {
                file = @"C:\Users\myfile.txt";
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
            var newVal = value.Replace("oneight", "18");
            newVal = newVal.Replace("twone", "21");
            newVal = newVal.Replace("eightwo", "82");
            newVal=newVal.Replace("one", "1");
            newVal= newVal.Replace("two", "2");
            newVal= newVal.Replace("three", "3");
            newVal= newVal.Replace("four", "4");
            newVal= newVal.Replace("five", "5");
            newVal= newVal.Replace("six", "6");
            newVal= newVal.Replace("seven", "7");
            newVal= newVal.Replace("eight", "8");
            newVal= newVal.Replace("nine", "9");
            newVal= newVal.Replace("zero", "0");

            foreach (var ch in newVal)
            {
                if(ch>='0' && ch <= '9')
                {
                    list.Add(ch);
                }
            }
            if (list.Count() == 1)
            {
                list.Add(list.FirstOrDefault());  
            }
            if (list.Count() != 0)
            {
                num = Convert.ToInt32(list.FirstOrDefault().ToString() + list.LastOrDefault().ToString());
            }
            return num;
        }


    }
}
