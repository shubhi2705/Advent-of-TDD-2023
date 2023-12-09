using Advent_of_tdd_2023;
using AdventOfCodeTDD;

namespace AdventOfCodeTDD.Tests
{
    [TestFixture]
    public class NavigationTest_2
    {
        [Test]
        public void calculate_steps_for_the_given_input_1()
        {
            var nav = new Navigation_2();
            var directionInput = "LR";
            var directions = directionInput.ToCharArray().Select(t => "LR".IndexOf(t)).ToArray();
            var navigations = new Dictionary<string, string[]>();
            navigations.Add("11A", new string[] { "11B", "XXX" });
            navigations.Add("11B", new string[] { "XXX", "11Z" });
            navigations.Add("11Z", new string[] { "11B", "XXX" });
            navigations.Add("22A", new string[] { "22B", "XXX" });
            navigations.Add("22B", new string[] { "22C", "22C" });
            navigations.Add("22C", new string[] { "22Z", "22Z" });
            navigations.Add("22Z", new string[] { "22B", "22B" });
            navigations.Add("XXX", new string[] { "XXX", "XXX" });
            var steps = nav.getSteps(navigations, directions);
            Assert.NotNull(steps);
            Assert.AreEqual(6, steps);
        }

        [Test]
        public void calculate_steps_for_the_given_input_2()
        {
            var nav = new Navigation_2();
            var directionInput = "LR";
            var directions = directionInput.ToCharArray().Select(t => "LR".IndexOf(t)).ToArray();
            var navigations = new Dictionary<string, string[]>();
            navigations.Add("11A", new string[] { "11B", "XXX" });
            navigations.Add("11B", new string[] { "XXX", "11Z" });
            navigations.Add("11Z", new string[] { "11B", "XXX" });
            var steps = nav.getSteps(navigations, directions);
            Assert.NotNull(steps);
            Assert.AreEqual(2, steps);
        }

        [Test]
        public void check_exception_when_directions_are_not_provided()
        {
            var nav = new Navigation_2();
            var directions = new int[] { };
            var file = "input.txt";
            Assert.Throws<ArgumentNullException>(() => nav.calculateSteps(directions, file));
        }

        [Test]
        public void check_exception_when_filepath_is_invalid()
        {
            var nav = new Navigation_2();
            var directions = new int[] { 0, 1 };
            var file = "input.txt";
            Assert.Throws<FileNotFoundException>(() => nav.calculateSteps(directions, file));
        }

        [Test]
        public void check_exception_when_file_is_empty()
        {
            var nav = new Navigation_2();
            var directions = new int[] { 0, 1 };
            var file = @"C:\Users\Empty.txt";
            Assert.Throws<InvalidDataException>(() => nav.calculateSteps(directions, file));
        }
    }
}