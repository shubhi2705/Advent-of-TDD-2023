using AdventOfCodeTDD;

namespace AdventOfCodeTDD.Tests
{
    [TestFixture]
    public class CalibrationTest
    {
         private List<string, int> lst;

 [SetUp]
 public void Setup()
 {
     lst = new List<string, int>();
     lst.Add("pld", 1);
     lst.Add("bhv", 7);
 }


 [Test]
 public void FileFound()
 {
     CodeCheck check = new CodeCheck();
     check.ReadData("code.txt");
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
 public void GetFocusCorrectValue()
 {

     CodeCheck check = new CodeCheck();
     Dictionary<int, List<(string, int)>> boxes = new Dictionary<int, List<(string, int)>>();
     int a = check.CalcFocusPower(boxes.Add(0, lst));
     Assert.AreEqual(15, a);
 }

 [Test]
 public void GetFocusWrongValue()
 {

     CodeCheck check = new CodeCheck();
     Dictionary<int, List<(string, int)>> boxes = new Dictionary<int, List<(string, int)>>();
     int a = check.CalcFocusPower(boxes.Add(0, lst));
     Assert.AreEqual(17, a);
 }
    }
}
