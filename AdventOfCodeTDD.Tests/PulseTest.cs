using AdventOfCodeTDD;

namespace AdventOfCodeTDD.Tests
{
    [TestFixture]
    public class PulseTest
    {
        [Test]
        public void calculate_output_for_input_1()
        {
            var input = "broadcaster -> a, b, c\r\n%a -> b\r\n%b -> c\r\n%c -> inv\r\n&inv -> a";
            var lines = input.Split("\r\n");
            var modules = Pulse.ParseInput(lines.ToArray());
            var part1 = Pulse.CalculatePart1(modules);
            Assert.AreEqual(part1, 32000000);

        }
        [Test]
        public void calculate_output_for_input_2()
        {
            var input = "broadcaster -> a, b, c\r\n%a -> b\r\n%b -> c\r\n%c -> inv\r\n&inv -> a";
            var lines = input.Split("\r\n");
            var modules = Pulse.ParseInput(lines.ToArray());
            Assert.Throws<InvalidOperationException>(() => Pulse.CalculatePart2(modules));
        }
        
        [Test]
        public void check_exception_when_filename_null_or_empty()
        {
            Assert.Throws<FileNotFoundException>(() => Pulse.ReadFile(null));
            Assert.Throws<FileNotFoundException>(() => Pulse.ReadFile(""));
        }
        [Test]
        public void check_exception_when_filecontent_empty()
        {
            var input = Pulse.ReadFile(@"C:\Users\Empty.txt");
            Assert.Throws<InvalidDataException>(() => Pulse.ParseInput(input));
        }
    }
}