using AdventOfCodeTDD;

namespace AdventOfCodeTDD.Tests
{
    [TestFixture]
    public class Test
    {
        [Test]
        public void calculate_output_for_input_1()
        {
            var input = ".|...\\....\r\n|.-.\\.....\r\n.....|-...\r\n........|.\r\n..........\r\n.........\\\r\n..../.\\\\..\r\n.-.-/..|..\r\n.|....-|.\\\r\n..//.|....";
            var lines = input.Split("\r\n");
            var map = Lava.processInput(lines.ToArray());
            var part1 = Lava.calculatePart1(map);
            Assert.AreEqual(part1, 46);

        }
        [Test]
        public void calculate_output_for_input_2()
        {
            var input = ".|...\\....\r\n|.-.\\.....\r\n.....|-...\r\n........|.\r\n..........\r\n.........\\\r\n..../.\\\\..\r\n.-.-/..|..\r\n.|....-|.\\\r\n..//.|....";
            var lines = input.Split("\r\n");
            var map = Lava.processInput(lines.ToArray());
            var part2 = Lava.calculatePart2(map);
            Assert.AreEqual(part2, 51);

        }
        [Test]
        public void calculate_output_for_input_3()
        {
            var input = ".|...\\....\r\n|.-.\\.....\r\n.....|-...\r\n........|.\r\n..........\r\n.........\\\r\n";
            var lines = input.Split("\r\n");
            var map = Lava.processInput(lines.ToArray());
            var part2 = Lava.calculatePart1(map);
            Assert.AreNotEqual(part2, 46);

        }
        [Test]
        public void calculate_output_for_input_4()
        {
            var input = ".|...\\....\r\n|.-.\\.....\r\n.....|-...\r\n........|.\r\n..........\r\n.........\\\r\n";
            var lines = input.Split("\r\n");
            var map = Lava.processInput(lines.ToArray());
            var part2 = Lava.calculatePart2(map);
            Assert.AreNotEqual(part2, 51);

        }
        [Test]
        public void check_exception_when_filename_null_or_empty()
        {
            Assert.Throws<FileNotFoundException>(() => Lava.ReadFile(null));
            Assert.Throws<FileNotFoundException>(() => Lava.ReadFile(""));
        }
        [Test]
        public void check_exception_when_filecontent_empty()
        {
            Assert.Throws<FileNotFoundException>(() => Lava.ReadFile(null));
            Assert.Throws<FileNotFoundException>(() => Lava.ReadFile(""));
        }
    }
}