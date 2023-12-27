namespace AdventOfCodeTDD.Tests
{
    [TestFixture]
    public class SandSlabeTest
    {
        [Test]
        public void calculate_output_for_input_1()
        {
            var input = "1,3,231~3,3,231\r\n4,5,264~4,5,265\r\n7,8,70~7,9,70\r\n6,7,173~6,9,173\r\n1,7,106~3,7,106\r\n7,6,278~7,7,278\r\n0,7,145~3,7,145\r\n4,6,116~4,7,116\r\n6,1,261~6,2,261\r\n2,7,15~2,9,15\r\n4,3,154~7,3,154\r\n5,2,110~7,2,110\r\n5,6,147~7,6,147\r\n9,5,176~9,9,176\r\n4,2,90~5,2,90";
            //var input = "1,0,1~1,2,1\r\n0,0,2~2,0,2\r\n0,2,3~2,2,3\r\n0,0,4~0,2,4\r\n2,0,5~2,2,5\r\n0,1,6~2,1,6\r\n1,1,8~1,1,9";
            var lines = input.Split("\r\n");
            var bricks = SandSlabe.ParseInput(lines);

            var (dropped, _) = SandSlabe.DropBricks(bricks);
            var supports = SandSlabe.FindSupports(dropped);
            var critical = SandSlabe.FindCriticalBricks(supports).ToList();
            var result1 = SandSlabe.calculatePart1(bricks.Count, critical.Count); 
            Assert.AreEqual(result1, 5);

        }
        [Test]
        public void calculate_output_for_input_2()
        {
            var input = "1,0,1~1,2,1\r\n0,0,2~2,0,2\r\n0,2,3~2,2,3\r\n0,0,4~0,2,4\r\n2,0,5~2,2,5\r\n0,1,6~2,1,6\r\n1,1,8~1,1,9";
            var lines = input.Split("\r\n");
            var bricks = SandSlabe.ParseInput(lines);

            var (dropped, _) = SandSlabe.DropBricks(bricks);
            var supports = SandSlabe.FindSupports(dropped);
            var critical = SandSlabe.FindCriticalBricks(supports).ToList();
            var result1 = SandSlabe.calculatePart2(critical,dropped); 
            Assert.AreEqual(result1, 7);
        }
        [Test]
        public void calculate_output_for_input_3()
        {
            var input = "1,3,231~3,3,231\r\n4,5,264~4,5,265\r\n7,8,70~7,9,70\r\n6,7,173~6,9,173\r\n1,7,106~3,7,106\r\n7,6,278~7,7,278\r\n0,7,145~3,7,145\r\n4,6,116~4,7,116\r\n6,1,261~6,2,261\r\n2,7,15~2,9,15\r\n4,3,154~7,3,154\r\n5,2,110~7,2,110\r\n5,6,147~7,6,147\r\n9,5,176~9,9,176\r\n4,2,90~5,2,90";
            var lines = input.Split("\r\n");
            var bricks = SandSlabe.ParseInput(lines);

            var (dropped, _) = SandSlabe.DropBricks(bricks);
            var supports = SandSlabe.FindSupports(dropped);
            var critical = SandSlabe.FindCriticalBricks(supports).ToList();
            var result1 = SandSlabe.calculatePart1(bricks.Count, critical.Count);
            Assert.AreNotEqual(result1, 5);
        }
        [Test]
        public void calculate_output_for_input_4()
        {
            var input = "1,3,231~3,3,231\r\n4,5,264~4,5,265\r\n7,8,70~7,9,70\r\n6,7,173~6,9,173\r\n1,7,106~3,7,106\r\n7,6,278~7,7,278\r\n0,7,145~3,7,145\r\n4,6,116~4,7,116\r\n6,1,261~6,2,261\r\n2,7,15~2,9,15\r\n4,3,154~7,3,154\r\n5,2,110~7,2,110\r\n5,6,147~7,6,147\r\n9,5,176~9,9,176\r\n4,2,90~5,2,90";
            var lines = input.Split("\r\n");
            var bricks = SandSlabe.ParseInput(lines);

            var (dropped, _) = SandSlabe.DropBricks(bricks);
            var supports = SandSlabe.FindSupports(dropped);
            var critical = SandSlabe.FindCriticalBricks(supports).ToList();
            var result1 = SandSlabe.calculatePart1(bricks.Count, critical.Count);
            Assert.AreNotEqual(result1, 5);
        }

        [Test]
        public void check_exception_when_filename_null_or_empty()
        {
            Assert.Throws<FileNotFoundException>(() => SandSlabe.ReadFiles(null));
            Assert.Throws<FileNotFoundException>(() => SandSlabe.ReadFiles(""));
        }
        [Test]
        public void check_exception_when_filecontent_empty()
        {
            var input = SandSlabe.ReadFiles(@"C:\Users\Empty.txt");
            Assert.Throws<InvalidDataException>(() => SandSlabe.ParseInput(input));
        }
    }
}