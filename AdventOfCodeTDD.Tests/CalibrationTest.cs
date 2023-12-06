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
            check.PartNumbersInRow(0,"$*..$..");
            Assert.AreEqual(0,check.parts.Count());
            
        }
        [Test]
        public void ValidNumberInFirstRow()
        {
            EngineDetails check=new EngineDetails();
            check.PartNumbersInRow(0,"$*123...*456..");
            Assert.AreEqual(2,check.parts.Count());
        }

        [Test]
        public void ValidSymbolInFirstRow()
        {
            EngineDetails check=new EngineDetails();
            check.SymbolsInRow(0,"$*123...*456..");
            Assert.AreEqual(3,check.parts.Count());
        }

        [Test]
        public void ValidPartNumberSumDueToTopSymbol()
        {
            EngineDetails check=new EngineDetails();
            check.SymbolsInRow(0,"$*123...*456..");
            check.PartNumbersInRow(0,"$*123...*456..");
            check.SymbolsInRow(1,"..123....456..");
            check.PartNumbersInRow(1,"..123....456..");
            var value=check.SumofEngineParts();
            Assert.AreEqual(1158,value);
        }

        [Test]
        public void ValidPartNumberSumDueToBottomSymbol()
        {
            EngineDetails check=new EngineDetails();
            check.SymbolsInRow(0,"..123....456..");
            check.PartNumbersInRow(0,"..123....456..");
            check.SymbolsInRow(1,".*123....456..");
            check.PartNumbersInRow(1,".*123....456..");
            var value=check.SumofEngineParts();
            Assert.AreEqual(246,value);
        
        }

        [Test]
        public void ValidPartNumberSumDueToDiagonalSymbol()
        {
            EngineDetails check=new EngineDetails();
            check.SymbolsInRow(0,"..123....456..");
            check.PartNumbersInRow(0,"..123....456..");
            check.SymbolsInRow(1,".*123....456..");
            check.PartNumbersInRow(1,".*123....456..");
            var value=check.SumofEngineParts();
            Assert.AreEqual(246,value);
        }
    
}
