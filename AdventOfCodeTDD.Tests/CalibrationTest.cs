using AdventOfCodeTDD;

namespace AdventOfCodeTDD.Tests
{
    [TestFixture]
    public class CalibrationTest
    {
 
        [SetUp]
        public void Setup()
        {
           
        }


        [Test]
        public void FileFound()
        {
            CodeCheck check = new CodeCheck();
            check.ReadData("testCode.txt");
            Assert.Pass();
        }
        [Test]
        public void FindRightHashValue()
        {
            CodeCheck check = new CodeCheck();
            int data = check.Hash("rn=1");
            Assert.AreEqual(30, data);
        }
        [Test]
        public void FindWrongHashValue()
        {
            CodeCheck check = new CodeCheck();
            int data = check.Hash("rn=1");
            Assert.AreNotEqual(45, data);
        }

        [Test]
        public void FindRightSumValue()
        {
            CodeCheck check = new CodeCheck();
            check.ReadData("testCode.txt");
            int data = check.GetSum();
            Assert.AreEqual(327, data);
        }
        [Test]
        public void FindWrongSumValue()
        {
            CodeCheck check = new CodeCheck();
            check.ReadData("testCode.txt");
            int data = check.GetSum();
            Assert.AreNotEqual(320, data);
        }
        [Test]
        public void GetFocusCorrectValue()
        {
            string data = " vjx = 2,nvc = 5,xvcn = 4,hf -,ggsh = 6";
            string[] value = data.Trim().Split(",");
            CodeCheck check = new CodeCheck();         
            int a = check.GetPart2Sum(value);
            Assert.AreEqual(1590, a);

           
        }

        [Test]
        public void GetFocusWrongValue()
        {

            string data = " vjx = 2,nvc = 5,xvcn = 4,hf -,ggsh = 6";
            string[] value = data.Trim().Split(",");
            CodeCheck check = new CodeCheck();
            int a = check.GetPart2Sum(value);
            Assert.AreNotEqual(1500, a);
        }
    }
}
