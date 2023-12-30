using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;

namespace Day25_Test
{
    [TestClass]
    public class UnitTest1
    {
        Day25 obj = new Day25();
        string file;
        List<string> allLines;

        [TestInitialize]
        public void Initialisation()
        {
            file = @"C:\Users\Administrator\Documents\InputFile\Day_25.txt";
            obj.ProcessInputFile(file);
            obj.buildGraph();
        }

        [TestMethod]
        [ExpectedException(typeof(FileNotFoundException))]
        public void FileNotFound()
        {
            file = @"C:\Users\Administrator\Documents\InputFile\Day25.txt";
            obj.ProcessInputFile(file);
        }

        [TestMethod]
        public void snowerLoad_Pass()
        {
            var obj = new Day25();
            int value = obj.snowerLoad();
            Assert.AreEqual(value, 572000);
        }
        [TestMethod]
        public void snowerLoad_False()
        {
            var obj = new Day25();
            int value = obj.snowerLoad();
            Assert.AreNotEqual(value, 755);
        }
    }
}

