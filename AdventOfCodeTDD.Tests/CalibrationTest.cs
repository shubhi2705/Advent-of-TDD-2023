using AdventOfCodeTDD;

namespace AdventOfCodeTDD.Tests
{
    [TestFixture]
    public class CalibrationTest
    {
       [Test]
public void GetCoordinatesRight()
{
    Destination check = new Destination();
    var data = @"...#......
                .......#..";
    var a = check.ParseGalaxyCoords(data);
    Assert.AreEqual(2,a.Count());
}

[Test]
public void GetCoordinatesWrong()
{
    Destination check = new Destination();
    var data = @"...#......
                .......#..
                ...#...#..";
    var a = check.ParseGalaxyCoords(data);
    Assert.AreNotEqual(3, a.Count());
}

[Test]
public void SolvePart1Right()
{
    Destination check = new Destination();
    var data = @"...#......
                .......#..";
    var a = check.SolvePart1(data);
    Assert.AreEqual(56, a);
}

[Test]
public void SolvePart1Wrong()
{
    Destination check = new Destination();
    var data = @"...#......
                .......#..
                ...#...#..";
    var a = check.SolvePart1(data);
    Assert.AreNotEqual(170, a);
}

[Test]
public void SolvePart2Right()
{
    Destination check = new Destination();
    var data = @"...#......
                .......#..";
    var a = check.SolvePart2(data);
    Assert.AreEqual(27000002, a);
}

[Test]
public void SolvePart2Wrong()
{
    Destination check = new Destination();
    var data = @"...#......
                .......#..
                ...#...#..";
    var a = check.SolvePart2(data);
    Assert.AreNotEqual(81000012, a);
}

    }
}
