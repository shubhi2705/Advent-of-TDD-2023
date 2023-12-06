using AdventOfCodeTDD;

namespace AdventOfCodeTDD.Tests
{
    [TestFixture]
    public class CalibrationTest
    {
        [Test]
        public void FileNotFoundException()
        {
            EngineDetails check=new EngineDetails();
            Assert.Throws<FileNotFoundException>(()=>check.Readdata("abc.txt"));       
        }
        [Test]
        public void NoSymbolsInRow()
        {
            EngineDetails check=new EngineDetails();
            check.SymbolsInRow(0,"988..345..");
            Assert.AreEqual(0,check.symbols.Count());
            
        }

        [Test]
        public void NoNumbersInRow()
        {
            EngineDetails check=new EngineDetails();
            check.NumbersInRow(0,"$*..$..");
            Assert.AreEqual(0,check.parts.Count());
            
        }
        [Test]
        public void Test2()
        {

        }
    }
}
