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
    Parabolic check = new Parabolic();
    check.FetchInput("testCode.txt");
    Assert.Pass();
}
[Test]
public void FindRightPart1Value()
{
    Parabolic check = new Parabolic();     
    var data = check.PartOne("testCode.txt");
    Assert.AreEqual(136, data);
}
[Test]
public void FindWrongPart1Value()
{
    Parabolic check = new Parabolic();
    var data = check.PartOne("testCode.txt");
    Assert.AreNotEqual(45, data);
}

[Test]
public void FindRightPart2Value()
{
    Parabolic check = new Parabolic();
    var data = check.PartTwo("testCode.txt");
    Assert.AreEqual(64, data);
}
[Test]
public void FindWrongPart2Value()
{
    Parabolic check = new Parabolic();
    var data = check.PartTwo("testCode.txt");
    Assert.AreNotEqual(320, data);
}
        
    }
}
