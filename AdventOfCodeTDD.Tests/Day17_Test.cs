using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Day17_Test
{
    [TestClass]
    public class Day17_Test
    {
        Day17 obj = new Day17();
        string file;
        int[][] heat_map;
        int braking_duration;
        int maximum_speed;
        [TestInitialize]
        public void Initialisation()
        {
            file = @"C:\Users\Administrator\Documents\InputFile\Day17.txt";
            heat_map = obj.ProcessFile(file);
            braking_duration = 4;
            maximum_speed = 10;
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void FileNotFound()
        {
            file = @"C:\Users\Administrator\Documents\InputFile\Day_17.txt";
            obj.ProcessFile(file);
        }

        [TestMethod]
        public void GetMinHeatLoss_Part1_True()
        {
            var obj = new Day17();
            int value = obj.GetMinHeatLoss(heat_map);
            Assert.AreEqual(value, 758);
        }
        [TestMethod]
        public void GetMinHeatLoss_Part1_False()
        {
            var obj = new Day17();
            int value = obj.GetMinHeatLoss(heat_map);
            Assert.AreNotEqual(value, 755);
        }


        [TestMethod]
        public void GetMinHeatLoss_Part2_True()
        {
            var obj = new Day17();
            int value = obj.GetMinHeatLoss(heat_map, braking_duration, maximum_speed);
            Assert.AreEqual(value, 892);
        }
        [TestMethod]
        public void GetMinHeatLoss_Part2_False()
        {
            var obj = new Day17();
            int value = obj.GetMinHeatLoss(heat_map, braking_duration, maximum_speed);
            Assert.AreNotEqual(value, 755);
        }
    }
}
