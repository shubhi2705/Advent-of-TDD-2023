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
        HashSet<(int, int)> TotalVisitedTiles;
        List<string> grid;
        PipeMaze_Part1 obj = new PipeMaze_Part1();
        string file;
        int sr, sc;

        [TestInitialize]
        public void Initialisation()
        {
            file = @"C:\Users\Administrator\Documents\TDD\PipeMaze\InputFile\MazeInput.txt";
            grid = new List<string>(File.ReadAllLines(file));//read each row in file
            obj.CordinatesOfStartPosition(grid, out sr, out sc);
            TotalVisitedTiles = obj.TotalVisitedCordinates(grid, sr, sc);
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void FileNotFound()
        {
            file = @"C:\Users\Administrator\Documents\TDD\PipeMaze\InputFile\MazeInputxyz.txt";
            obj.TotalSteps(file);
        }

        [TestMethod]
        public void CalculateIntersectsPonitsPart2_True()
        {
            var obj = new PipeMaze_Part1();
            int value = obj.TotalTilesEnclosed(grid, TotalVisitedTiles);
            Assert.AreEqual(value, 357);
        }
        [TestMethod]
        public void CalculateIntersectsPonitsPart2_False()
        {
            int value = obj.TotalTilesEnclosed(grid, TotalVisitedTiles);
            Assert.AreNotEqual(value, 3579);
        }

        [TestMethod]
        public void CordinatesOfStartPositionPart1_Test_False()
        {
            string file = @"C:\Users\Administrator\Documents\TDD\PipeMaze\InputFile\MazeInput.txt";
            List<string> grid = new List<string>(File.ReadAllLines(file));
            var obj = new PipeMaze_Part1();
            obj.CordinatesOfStartPosition(grid, out int sr, out int sc);
            Assert.AreNotEqual((sr, sc), (109, 18));
        }

        [TestMethod]
        public void CordinatesOfStartPositionPart1_Test_True()
        {
            obj.CordinatesOfStartPosition(grid, out int sr, out int sc);
            Assert.AreEqual((sr, sc), (109, 28));
        }

        [TestMethod]
        public void TotalSteps_Part1_Test_True()
        {
            HashSet<(int, int)> values = obj.TotalVisitedCordinates(grid, sr, sc);
            Assert.AreEqual(6931, values.Count/2);
        }
        [TestMethod]
        public void TotalStepsPart1__Test_False()
        {
            string file = @"C:\Users\Administrator\Documents\TDD\PipeMaze\InputFile\MazeInput.txt";
            var obj = new PipeMaze_Part1();
            int value = obj.TotalSteps(file);
            Assert.AreNotEqual(69313, value);
        }
    }
}
