using AdventOfCodeTDD;

namespace AdventOfCodeTDD.Tests
{
    [TestFixture]
    public class AplentyTest
    {
        [Test]
        public void calculate_output_for_input_1()
        {
            var input = "px{a<2006:qkq,m>2090:A,rfg}\r\npv{a>1716:R,A}\r\nlnx{m>1548:A,A}\r\nrfg{s<537:gd,x>2440:R,A}\r\nqs{s>3448:A,lnx}\r\nqkq{x<1416:A,crn}\r\ncrn{x>2662:A,R}\r\nin{s<1351:px,qqz}\r\nqqz{s>2770:qs,m<1801:hdj,R}\r\ngd{a>3333:R,R}\r\nhdj{m>838:A,pv}\r\n\r\n{x=787,m=2655,a=1222,s=2876}\r\n{x=1679,m=44,a=2067,s=496}\r\n{x=2036,m=264,a=79,s=2244}\r\n{x=2461,m=1339,a=466,s=291}\r\n{x=2127,m=1623,a=2188,s=1013}";
            var lines = input.Split("\r\n");
            var (rules,parts) = Aplenty.ParseInput(lines.ToArray());
            var part1 = Aplenty.calculatePart1(parts,rules);
            Assert.AreEqual(part1, 19114);

        }
        [Test]
        public void calculate_output_for_input_2()
        {
            var input = "px{a<2006:qkq,m>2090:A,rfg}\r\npv{a>1716:R,A}\r\nlnx{m>1548:A,A}\r\nrfg{s<537:gd,x>2440:R,A}\r\nqs{s>3448:A,lnx}\r\nqkq{x<1416:A,crn}\r\ncrn{x>2662:A,R}\r\nin{s<1351:px,qqz}\r\nqqz{s>2770:qs,m<1801:hdj,R}\r\ngd{a>3333:R,R}\r\nhdj{m>838:A,pv}\r\n\r\n{x=787,m=2655,a=1222,s=2876}\r\n{x=1679,m=44,a=2067,s=496}\r\n{x=2036,m=264,a=79,s=2244}\r\n{x=2461,m=1339,a=466,s=291}\r\n{x=2127,m=1623,a=2188,s=1013}";
            var lines = input.Split("\r\n");
            var (rules, parts) = Aplenty.ParseInput(lines.ToArray());
            var part2 = Aplenty.calculatePart2(rules);
            Assert.AreEqual(part2, 167409079868000);

        }
        [Test]
        public void calculate_output_for_input_3()
        {
            var input = "px{a<2006:qkq,m>2090:A,rfg}\r\npv{a>1716:R,A}\r\nlnx{m>1548:A,A}\r\n\r\n{x=787,m=2655,a=1222,s=2876}\r\n{x=1679,m=44,a=2067,s=496}\r\n{x=2036,m=264,a=79,s=2244}\r\n";
            var lines = input.Split("\r\n");
            Assert.Throws<System.IndexOutOfRangeException>(()=> Aplenty.ParseInput(lines.ToArray()));
        }
        [Test]
        public void check_exception_when_filename_null_or_empty()
        {
            Assert.Throws<FileNotFoundException>(() => Aplenty.ReadFile(null));
            Assert.Throws<FileNotFoundException>(() => Aplenty.ReadFile(""));
        }
        [Test]
        public void check_exception_when_filecontent_empty()
        {
            var input = Aplenty.ReadFile(@"C:\Users\Empty.txt");
            Assert.Throws<InvalidDataException>(() => Aplenty.ParseInput(input));
        }
    }
}