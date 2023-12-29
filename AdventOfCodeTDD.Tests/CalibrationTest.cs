using AdventOfCodeTDD;

namespace AdventOfCodeTDD.Tests
{
    [TestFixture]
    public class CalibrationTest
    {
        [Test]
public void FindRightPart1Value()
{
    var input = @"19, 13, 30 @ -2,  1, -2
                18, 19, 22 @ -1, -1, -2
                20, 25, 34 @ -2, -2, -4
                12, 31, 28 @ -1, -2, -1
                20, 19, 15 @  1, -5, -3";
    Hailstones counter = new Hailstones(input);   
    var data = counter.Part1();
    Assert.AreEqual(0, data);
}
       
[Test]
public void FindWrongPart1Value()
{
    var input = @"19, 13, 30 @ -2,  1, -2
                18, 19, 22 @ -1, -1, -2
                20, 25, 34 @ -2, -2, -4
                12, 31, 28 @ -1, -2, -1
                20, 19, 15 @  1, -5, -3";
    Hailstones counter = new Hailstones(input);
    var data = counter.Part1();
    Assert.AreNotEqual(2, data);
}

[Test]
public void FindRightPart2Value()
{
    var input = @"19, 13, 30 @ -2,  1, -2
                18, 19, 22 @ -1, -1, -2
                20, 25, 34 @ -2, -2, -4
                12, 31, 28 @ -1, -2, -1
                20, 19, 15 @  1, -5, -3";
    Hailstones counter = new Hailstones(input);
    var data = counter.Part2();
    Assert.AreEqual(47, data);
}
[Test]
public void FindWrongPart2Value()
{
    var input = @"19, 13, 30 @ -2,  1, -2
                18, 19, 22 @ -1, -1, -2
                20, 25, 34 @ -2, -2, -4
                12, 31, 28 @ -1, -2, -1
                20, 19, 15 @  1, -5, -3";
    Hailstones counter = new Hailstones(input);
    var data = counter.Part2();
    Assert.AreNotEqual(45, data);
}
    }
}
