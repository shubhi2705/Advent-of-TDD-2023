using AdventOfCodeTDD;

namespace AdventOfCodeTDD.Tests
{
    [TestFixture]
    public class CalibrationTest
    {
        [Test]
 public void FindRightPart1Value()
 {
     var input = File.ReadAllText(@"C:\Users\MSUSERSL123\Documents\Data\testCode.txt");
     Counter counter = new Counter(input);   
     var data = counter.Part1();
     Assert.AreEqual(42, data);
 }

 [Test]
 public void FindWrongPart1Value()
 {
     var input = File.ReadAllText(@"C:\Users\MSUSERSL123\Documents\Data\testCode.txt");
     Counter counter = new Counter(input);
     var data = counter.Part1();
     Assert.AreNotEqual(40, data);
 }

 [Test]
 public void FindRightPart2Value()
 {
     var input = File.ReadAllText(@"C:\Users\MSUSERSL123\Documents\Data\testCode.txt");
     Counter counter = new Counter(input);
     var data = counter.Part2();
     Assert.AreEqual(435323968681713, data);
 }
 [Test]
 public void FindWrongPart2Value()
 {
     var input = File.ReadAllText(@"C:\Users\MSUSERSL123\Documents\Data\testCode.txt");
     Counter counter = new Counter(input);
     var data = counter.Part2();
     Assert.AreNotEqual(80000, data);
 }
    }
}
