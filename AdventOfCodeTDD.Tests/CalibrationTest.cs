using AdventOfCodeTDD;

namespace AdventOfCodeTDD.Tests
{
    [TestFixture]
    public class CalibrationTest
    {
        [Test]
        public void NoSymbolsInRow()
        {
            EngineDetails check=new EngineDetails();
            check.SymbolsInRow(0,"988..345..");
            Assert.AreEqual(0,check.symbols.Count());
            
        }
        [Test]
        public void Test2()
        {

        }
    }
}
