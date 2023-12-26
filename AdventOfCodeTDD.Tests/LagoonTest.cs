using AdventOfCodeTDD;

namespace AdventOfCodeTDD.Tests
{
    [TestFixture]
    public class LagoonTest
    {
        [Test]
        public void calculate_lagoon_for_give_input1()
        {
            var input = "R 6 (#70c710)\r\nD 5 (#0dc571)\r\nL 2 (#5713f0)\r\nD 2 (#d2c081)\r\nR 2 (#59c680)\r\nD 2 (#411b91)\r\nL 5 (#8ceee2)\r\nU 2 (#caa173)\r\nL 1 (#1b58a2)\r\nU 2 (#caa171)\r\nR 2 (#7807d2)\r\nU 3 (#a77fa3)\r\nL 2 (#015232)\r\nU 2 (#7a21e3)";
            var lines = input.Split("\r\n");
            var steps = Lagoon.calculateInput(lines);
            var part1 = Lagoon.calculatePart1(steps);
            Assert.IsNotNull(part1);
            Assert.AreEqual(62, part1);
        }
        [Test]
        public void calculate_lagoon_for_give_input2()
        {
            var input = "R 6 (#70c710)\r\nD 5 (#0dc571)\r\nL 2 (#5713f0)\r\n";
            var lines = input.Split("\r\n");
            var steps = Lagoon.calculateInput(lines);
            var part1 = Lagoon.calculatePart1(steps);
            Assert.IsNotNull(part1);
            Assert.AreNotEqual(62, part1);
        }
        [Test]
        public void calculate_lagoon_for_give_input3()
        {
            var input = "R 6 (#70c710)\r\nD 5 (#0dc571)\r\nL 2 (#5713f0)\r\nD 2 (#d2c081)\r\nR 2 (#59c680)\r\nD 2 (#411b91)\r\nL 5 (#8ceee2)\r\nU 2 (#caa173)\r\nL 1 (#1b58a2)\r\nU 2 (#caa171)\r\nR 2 (#7807d2)\r\nU 3 (#a77fa3)\r\nL 2 (#015232)\r\nU 2 (#7a21e3)";
            var lines = input.Split("\r\n");
            var steps = Lagoon.calculateInput(lines);
            var part2 = Lagoon.calculatePart2(steps);
            Assert.IsNotNull(part2);
            Assert.AreEqual(952408144115, part2);
        }
        [Test]
        public void calculate_lagoon_for_give_input4()
        {
            var input = "R 6 (#70c710)\r\nD 5 (#0dc571)\r\nL 2 (#5713f0)\r\n";
            var lines = input.Split("\r\n");
            var steps = Lagoon.calculateInput(lines);
            var part2 = Lagoon.calculatePart1(steps);
            Assert.IsNotNull(part2);
            Assert.AreNotEqual(62, part2);
        }
        [Test]
        public void check_exception_when_filename_null_or_empty()
        {
            Assert.Throws<FileNotFoundException>(() => Lagoon.readFile(null));
            Assert.Throws<FileNotFoundException>(() => Lagoon.readFile(""));
        }
        [Test]
        public void check_exception_when_filecontent_empty()
        {
            var contents = Lagoon.readFile(@"C:\Users\Empty.txt");
            Assert.Throws<InvalidDataException>(() => Lagoon.calculateInput(contents));
        }
    }
}