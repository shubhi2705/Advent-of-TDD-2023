using AdventOfCodeTDD;

namespace AdventOfCodeTDD.Tests
{
    [TestFixture]
    public class NavigationTest
    {
        [Test]
        public void calculate_steps_for_the_given_input_1()
        {
            var nav = new Navigation();
            var directionInput = "RL";
            var directions = directionInput.ToCharArray().Select(t => "LR".IndexOf(t)).ToArray();
            var navigations = new Dictionary<string, string[]>();
            navigations.Add("AAA", new string[] { "BBB", "CCC" });
            navigations.Add("BBB", new string[] { "DDD", "EEE" });
            navigations.Add("CCC", new string[] { "ZZZ", "GGG" });
            navigations.Add("DDD", new string[] { "DDD", "DDD" });
            navigations.Add("EEE", new string[] { "EEE", "EEE" });
            navigations.Add("GGG", new string[] { "GGG", "GGG" });
            navigations.Add("ZZZ", new string[] { "ZZZ", "ZZZ" });
            var steps = nav.getCountOfSteps(directions, navigations);
            Assert.NotNull(steps);
            Assert.AreEqual(2, steps);
        }
        [Test]
        public void calculate_steps_for_the_given_input_2()
        {
            var nav = new Navigation();
            var directionInput = "LLR";
            var directions = directionInput.ToCharArray().Select(t => "LR".IndexOf(t)).ToArray();
            var navigations = new Dictionary<string, string[]>();
            navigations.Add("AAA", new string[] { "BBB", "BBB" });
            navigations.Add("BBB", new string[] { "AAA", "ZZZ" });
            navigations.Add("ZZZ", new string[] { "ZZZ", "ZZZ" });
            var steps = nav.getCountOfSteps(directions, navigations);
            Assert.NotNull(steps);
            Assert.AreEqual(6, steps);
        }

        [Test]
        public void calculate_steps_for_the_given_input_3()
        {
            var nav = new Navigation();
            var directionInput = "LLR";
            var directions = directionInput.ToCharArray().Select(t => "LR".IndexOf(t)).ToArray();
            var navigations = new Dictionary<string, string[]>();
            navigations.Add("AAA", new string[] { "ZZZ", "BBB" });
            navigations.Add("ZZZ", new string[] { "ZZZ", "ZZZ" });
            var steps = nav.getCountOfSteps(directions, navigations);
            Assert.NotNull(steps);
            Assert.AreEqual(1, steps);
        }

        [Test]
        public void calculate_steps_for_the_given_input_4()
        {
            var nav = new Navigation();
            var directionInput = "L";
            var directions = directionInput.ToCharArray().Select(t => "LR".IndexOf(t)).ToArray();
            var navigations = new Dictionary<string, string[]>();
            navigations.Add("AAA", new string[] { "ZZZ", "ZZZ" });
            Assert.Throws<ArgumentException>(() => nav.getCountOfSteps(directions, navigations));
        }
        [Test]
        public void calculate_steps_for_the_given_input_5()
        {
            var nav = new Navigation();
            var directionInput = "L";
            var directions = directionInput.ToCharArray().Select(t => "LR".IndexOf(t)).ToArray();
            var navigations = new Dictionary<string, string[]>();
            navigations.Add("ZZZ", new string[] { "ZZZ", "ZZZ" });
            var steps = nav.getCountOfSteps(directions, navigations);
            Assert.Zero(steps);
        }

        [Test]
        public void check_exception_when_directions_are_not_provided()
        {
            var nav = new Navigation();
            var directions = new int[] { };
            var file = "input.txt";
            Assert.Throws<ArgumentNullException>(() => nav.calculateSteps(directions, file));
        }

        [Test]
        public void check_exception_when_filepath_is_invalid()
        {
            var nav = new Navigation();
            var directions = new int[] { 0,1};
            var file = "input.txt";
            Assert.Throws<FileNotFoundException>(() => nav.calculateSteps(directions, file));
        }

        [Test]
        public void check_exception_when_file_is_empty()
        {
            var nav = new Navigation();
            var directions = new int[] { 0, 1 };
            var file = @"C:\Users\Empty.txt";
            Assert.Throws<InvalidDataException>(() => nav.calculateSteps(directions, file));
        }
    }
}