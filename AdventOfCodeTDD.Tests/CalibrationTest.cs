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
    public void ParseGamesRight()
    {
        Game check = new Game();
        var input = File.ReadAllText(@"C:\Users\MSUSERSL123\Documents\Data\testCode.txt");
        var data = check.ParseGames(input);
        Assert.AreEqual(5, data.Count);
    }
    [Test]
    public void ParseGamesWrong()
    {
        Game check = new Game();
        var input = File.ReadAllText(@"C:\Users\MSUSERSL123\Documents\Data\testCode.txt");
        var data = check.ParseGames(input);
        Assert.AreNotEqual(3, data.Count);
    }

    [Test]
    public void FindRightPart1Value()
    {
        Game check = new Game();     
        var data = check.SolvePart1("testCode.txt");
        Assert.AreEqual(6440, data);
    }
    [Test]
    public void FindWrongPart1Value()
    {
        Game check = new Game();
        var data = check.SolvePart1("testCode.txt");
        Assert.AreNotEqual(5000, data);
    }

    [Test]
    public void FindRightPart2Value()
    {
        Game check = new Game();
        var data = check.SolvePart1("testCode.txt");
        Assert.AreEqual(6440, data);
    }
    [Test]
    public void FindWrongPart2Value()
    {
        Game check = new Game();
        var data = check.SolvePart1("testCode.txt");
        Assert.AreNotEqual(4000, data);
    }
    

    }
}
