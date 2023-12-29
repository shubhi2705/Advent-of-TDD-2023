using AdventOfCodeTDD;

namespace AdventOfCodeTDD.Tests
{
    [TestFixture]
    public class CalibrationTest
    {
    [Test]
    public void FileFound()
    {

        Hailstones hailstones = new Hailstones();
        hailstones.ReadData("code.txt");
        var data = hailstones.hails;
        Assert.AreEqual(5, data.Count);
    }

    [Test]
    public void FileNotFound()
    {

        Hailstones hailstones = new Hailstones();
        Assert.Throws<FileNotFoundException>(() => hailstones.ReadData("code1.txt"));
    }


    [Test]
    public void FindRightPart1Value()
    {
       
        Hailstones hailstones = new Hailstones();
        hailstones.ReadData("code.txt");
        var data = hailstones.Part1();
        Assert.AreEqual(0, data);
    }

    [Test]
    public void FindWrongPart1Value()
    {
       
        Hailstones hailstones = new Hailstones();
        hailstones.ReadData("code.txt");
        var data = hailstones.Part1();
        Assert.AreNotEqual(2, data);
    }

    [Test]
    public void FindRightPart2Value()
    {
       
        Hailstones hailstones = new Hailstones();
        hailstones.ReadData("code.txt");
        var data = hailstones.Part2();
        Assert.AreEqual(47, data);
    }
    [Test]
    public void FindWrongPart2Value()
    {
       
        Hailstones hailstones = new Hailstones();
        hailstones.ReadData("code.txt");
        var data = hailstones.Part2();
        Assert.AreNotEqual(45, data);
    }
    }
}
