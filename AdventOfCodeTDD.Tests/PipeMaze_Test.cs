using Microsoft.VisualStudio.TestTools.UnitTesting;
using PipeMaze;
using System;
using System.Collections.Generic;
using System.IO;

namespace PipeMazeTest
{
    [TestClass]
    public class PipeMazeTest
    {
        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void FileNotFound()
        {
            string file = @"C: \Users\Administrator\Documents\TDD\PipeMaze\InputFile\MazeInp.txt";
            var obj = new PipeMaze_Part1();
            obj.TotalSteps(file);
        }

        [TestMethod]
        public void CordinatesOfStartPosition_Test()
        {
            string file = @"C:\Users\Administrator\Documents\TDD\PipeMaze\InputFile\MazeInput.txt";
            List<string> grid = new List<string>(File.ReadAllLines(file));
            var obj = new PipeMaze_Part1();
            obj.CordinatesOfStartPosition(grid, out int sr, out int sc);
            Assert.AreEqual((sr, sc), (109, 28));
        }

        [TestMethod]
        public void CordinatesOfStartPosition_Test_False()
        {
            string file = @"C:\Users\Administrator\Documents\TDD\PipeMaze\InputFile\MazeInput.txt";
            List<string> grid = new List<string>(File.ReadAllLines(file));
            var obj = new PipeMaze_Part1();
            obj.CordinatesOfStartPosition(grid, out int sr, out int sc);
            Assert.AreNotEqual((sr, sc), (109, 18));
        }
        [TestMethod]
        public void TotalSteps_Test()
        {
            string file = @"C:\Users\Administrator\Documents\TDD\PipeMaze\InputFile\MazeInput.txt";
            var obj = new PipeMaze_Part1();
            int value = obj.TotalSteps(file);
            Assert.AreEqual(6931, value);
        }
        [TestMethod]
        public void TotalSteps__Test_False()
        {
            string file = @"C:\Users\Administrator\Documents\TDD\PipeMaze\InputFile\MazeInput.txt";
            var obj = new PipeMaze_Part1();
            int value = obj.TotalSteps(file);
            Assert.AreNotEqual(69313, value);
        }
    }
}
