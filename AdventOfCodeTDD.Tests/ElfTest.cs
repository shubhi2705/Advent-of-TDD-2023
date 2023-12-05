using AdventOfCodeTDD;

namespace AdventOfCodeTDD.Tests
{
    [TestFixture]
    public class ElfTest
    {
        [Test]
        public void FileNotFoundException_When_File_does_not_exists()
        {
            var elf = new Elf();
            Assert.Throws<FileNotFoundException>(()=>elf.ElfAndCubes("input.txt"));
        }
        [Test]
        public void check_whether_game_is_valid_when_3Red_5Blue_6Green_10Red_6Blue_were_drawn_for_game1()
        {
            var elf = new Elf();
            var sets = new String[]{ "3 red, 5 blue, 6 green", "10 red, 6 blue" };

            var result=elf.checkValidity(sets);
            Assert.AreEqual(true, result);       
        }

        [Test]
        public void check_whether_game_is_valid_when_13Red_5Blue_6Green_10Red_6Blue_were_drawn_for_game1()
        {
            var elf = new Elf();
            var sets = new String[] { "13 red, 5 blue, 6 green", "10 red, 6 blue" };

            var result = elf.checkValidity(sets);
            Assert.False(result);
        }

        [Test]
        public void check_whether_sum_is_equal_to_3_for_given_input()
        {
            var elf = new Elf();
            var gamesInput = new String[] { "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green",
                                            "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue",
                                            "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red" };
            var result = elf.calculateSumForValidGames(gamesInput);
            Assert.AreEqual(3, result);
        }

        [Test]
        public void check_whether_sum_is_equal_to_8_for_given_input()
        {
            var elf = new Elf();
            var gamesInput = new String[] { "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green",
                                            "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue",
                                            "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red",
                                            "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red",
                                            "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green"
           };
            var result = elf.calculateSumForValidGames(gamesInput);
            Assert.AreEqual(8, result);
        }

        [Test]
        public void check_whether_sum_is_0_when_file_is_empty()
        {
            var elf = new Elf();
            string file = @"C:\\Users\\Empty.txt";
            var result = elf.ElfAndCubes(file);
            Assert.Zero(result);
        }

        [Test]
        public void check_whether_exception_thrown_for_invalid_input_format_for_power_sum()
        {
            var elf = new Elf();
            var input = new String[] { "3 red, 5 blue, 6 green", "1 red, 6 blue" };
            Assert.Throws<IndexOutOfRangeException>(() => elf.calculatePowerSum(input));
        }

        [Test]
        public void check_whether_exception_thrown_for_invalid_input_format_for_valid_sum()
        {
            var elf = new Elf();
            var input = new String[] { "3 red, 5 blue, 6 green", "1 red, 6 blue" };
            Assert.Throws<IndexOutOfRangeException>(() => elf.calculateSumForValidGames(input));
        }

        [Test]
        public void check_whether_power_sum_is_48_for_provided_input()
        {
            var elf = new Elf();
            var input = new String[] { "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green" };
            var result = elf.calculatePowerSum(input);
            Assert.Equals(48, result);
        }

        [Test]
        public void check_whether_power_sum_is_2286_for_provided_input()
        {
            var elf = new Elf();
            var input = new String[] {
                "Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green",
             "Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue",
            "Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red",
            "Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red",
            "Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green"
            };
            var result = elf.calculatePowerSum(input);
            Assert.AreEqual(2286, result);
        }

        [Test]
        public void check_whether_power_sum_is_0_for_provided_input()
        {
            var elf = new Elf();
            var input = new String[] { "Game 1: 1 blue; 1 red" };
            var result = elf.calculatePowerSum(input);
            Assert.AreEqual(0, result);
        }
    }
}