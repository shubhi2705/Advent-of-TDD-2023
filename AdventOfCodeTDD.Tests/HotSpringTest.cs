using AdventOfCodeTDD;
using AdventOfCodeTDD2023;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace AdventOfCodeTDD.Tests
{
    [TestFixture]
    public class HotSpringTest
    {
        [Test]
        public void calculate_scheme_for_given_input_1()
        {
            var spring = new HotSpring();
            var input = new List<string>();
            input.Add("??????.??#. 2,3");
            var data = spring.ParseInput(input);
            var result = spring.get_result_for_part1(data);
            Assert.IsNotNull(result);
            Assert.AreEqual(5, result);
        }
        [Test]
        public void calculate_scheme_for_given_input_2()
        {
            var spring = new HotSpring();
            var input = new List<string>();
            input.Add("??.?###????????? 2,4,4");
            var data = spring.ParseInput(input);
            var result = spring.get_result_for_part1(data);
            Assert.IsNotNull(result);
            Assert.AreEqual(9, result);
        }

        [Test]
        public void calculate_scheme_for_given_input_3()
        {
            var spring = new HotSpring();
            var input = new List<string>();
            input.Add("?##?????#??#???.???? 4,3,4,1,2");
            var data = spring.ParseInput(input);
            var result = spring.get_result_for_part1(data);
            Assert.IsNotNull(result);
            Assert.AreEqual(6, result);
        }

        [Test]
        public void check_exception_when_filepath_is_invalid()
        {
            var spring = new HotSpring();
            Assert.Throws<FileNotFoundException>(()=> spring.readFile("input.txt",spring));
        }
        [Test]
        public void check_exception_when_filepath_is_null()
        {
            var spring = new HotSpring();
            Assert.Throws<FileNotFoundException>(() => spring.readFile(null, spring));
        }
        [Test]
        public void check_exception_when_filepath_is_empty()
        {
            var spring = new HotSpring();
            Assert.Throws<FileNotFoundException>(() => spring.readFile("", spring));
        }
        [Test]
        public void check_exception_when_filecontent_is_empty()
        {
            var spring = new HotSpring();
            var file = @"C:\Users\Empty.txt";
            Assert.Throws<InvalidOperationException>(() => spring.readFile(file, spring));
        }

        [Test]
        public void calculate_scheme_for_given_input_1_part_2()
        {
            var spring = new HotSpring();
            var input = new List<string>();
            input.Add("??????.??#. 2,3");
            var data = spring.ParseInput(input);
            var result = spring.get_result_for_part2(data);
            Assert.IsNotNull(result);
            Assert.AreEqual(16016, result);
        }
        [Test]
        public void calculate_scheme_for_given_input_2_part2()
        {
            var spring = new HotSpring();
            var input = new List<string>();
            input.Add("??.?###????????? 2,4,4");
            var data = spring.ParseInput(input);
            var result = spring.get_result_for_part2(data);
            Assert.IsNotNull(result);
            Assert.AreEqual(3515625, result);
        }

        [Test]
        public void calculate_scheme_for_given_input_3_part3()
        {
            var spring = new HotSpring();
            var input = new List<string>();
            input.Add("?##?????#??#???.???? 4,3,4,1,2");
            var data = spring.ParseInput(input);
            var result = spring.get_result_for_part2(data);
            Assert.IsNotNull(result);
            Assert.AreEqual(124416, result);
        }
    }
}