using AdventOfCodeTDD;

namespace AdventOfCodeTDD.Tests
{
    [TestFixture]
    public class CalibrationTest
    {
        [Test]
        public void check_reflection_for_input1()
        {
            var input = "#.##..##.\r\n..#.##.#.\r\n##......#\r\n##......#\r\n..#.##.#.\r\n..##..##.\r\n#.#.##.#.\r\n\r\n#...##..#\r\n#....#..#\r\n..##..###\r\n#####.##.\r\n#####.##.\r\n..##..###\r\n#....#..#";
            var data=Calibration.calculateInput(input);
            var result = Calibration.calculate_part1(data);
            Assert.IsNotNull(result);
            Assert.AreEqual(405, result);
        }

        [Test]
        public void check_reflection_for_input2()
        {
            var input = "#..#.#........#\r\n#..######..####\r\n.##..#.#.##.#.#\r\n#..##..........\r\n######........#\r\n#..####......##\r\n.##.##.#...##.#\r\n\r\n..######.\r\n..######.\r\n....#..##\r\n##.....##\r\n##..#...#\r\n..##.....\r\n.#..#.#..\r\n.#..###..\r\n..##.....";
            var data = Calibration.calculateInput(input);
            var result = Calibration.calculate_part1(data);
            Assert.IsNotNull(result);
            Assert.AreEqual(102, result);
        }
        [Test]
        public void check_reflection_for_input3()
        {
            var input = "..#.###\r\n.###..#\r\n.###..#\r\n..#.###\r\n.#..#..\r\n.##.#.#\r\n####.##\r\n#.##.##\r\n#.#..##\r\n####.##\r\n.##.#.#\r\n.#..#..\r\n..#.###\r\n\r\n....#..#.#...\r\n.#.#..#..##..\r\n.#.#..#..##..\r\n.#..#..#.#...\r\n..####...##..\r\n..####.#.#.##\r\n.#..##..#.#..\r\n#..#..##..###\r\n.###.##.###.#\r\n.###.##.###.#\r\n#..#..##..###\r\n.#..##..#.#..\r\n..####.#.#.##";
            var data = Calibration.calculateInput(input);
            var result = Calibration.calculate_part1(data);
            Assert.IsNotNull(result);
            Assert.AreEqual(1100, result);
        }

        [Test]
        public void check_exception_when_file_not_found()
        {
            Assert.Throws<FileNotFoundException>(()=>Calibration.readFile("input.txt"));
        }
        [Test]
        public void check_exception_when_file_is_null_or_empty()
        {
            Assert.Throws<Exception>(() => Calibration.readFile(""));
            Assert.Throws<Exception>(() => Calibration.readFile(null));
        }
        [Test]
        public void check_exception_when_file_content_are_empty_or_invalid()
        {
            var input = Calibration.readFile(@"C:\Users\Empty.txt");
            Assert.Throws<InvalidDataException>(() => Calibration.calculateInput(input));
        }


        //Part_2 UTC Starts here-
        [Test]
        public void check_reflection_for_input1_part2()
        {
            var input = "#.##..##.\r\n..#.##.#.\r\n##......#\r\n##......#\r\n..#.##.#.\r\n..##..##.\r\n#.#.##.#.\r\n\r\n#...##..#\r\n#....#..#\r\n..##..###\r\n#####.##.\r\n#####.##.\r\n..##..###\r\n#....#..#";
            var data = Calibration.calculateInput(input);
            var result = Calibration.calculate_part2(data);
            Assert.IsNotNull(result);
            Assert.AreEqual(400, result);
        }

        [Test]
        public void check_reflection_for_input2_part2()
        {
            var input = "#..#.#........#\r\n#..######..####\r\n.##..#.#.##.#.#\r\n#..##..........\r\n######........#\r\n#..####......##\r\n.##.##.#...##.#\r\n\r\n..######.\r\n..######.\r\n....#..##\r\n##.....##\r\n##..#...#\r\n..##.....\r\n.#..#.#..\r\n.#..###..\r\n..##.....";
            var data = Calibration.calculateInput(input);
            var result = Calibration.calculate_part2(data);
            Assert.IsNotNull(result);
            Assert.AreEqual(710, result);
        }
        [Test]
        public void check_reflection_for_input3_part2()
        {
            var input = "..#.###\r\n.###..#\r\n.###..#\r\n..#.###\r\n.#..#..\r\n.##.#.#\r\n####.##\r\n#.##.##\r\n#.#..##\r\n####.##\r\n.##.#.#\r\n.#..#..\r\n..#.###\r\n\r\n....#..#.#...\r\n.#.#..#..##..\r\n.#.#..#..##..\r\n.#..#..#.#...\r\n..####...##..\r\n..####.#.#.##\r\n.#..##..#.#..\r\n#..#..##..###\r\n.###.##.###.#\r\n.###.##.###.#\r\n#..#..##..###\r\n.#..##..#.#..\r\n..####.#.#.##";
            var data = Calibration.calculateInput(input);
            var result = Calibration.calculate_part2(data);
            Assert.IsNotNull(result);
            Assert.AreEqual(1000, result);
        }
    }
}