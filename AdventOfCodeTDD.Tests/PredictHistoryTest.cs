using AdventOfCodeTDD;

namespace AdventOfCodeTDD.Tests
{
    [TestFixture]
    public class PredictHistoryTest
    {
        [Test]
        public void predict_history_for_given_input_1()
        {
            var list = new List<int>() { 0, 3, 6, 9, 12, 15 };
            var input = new List<List<int>> { list };
            var c = new PredictHistory();
            int sum2 = 0;
            var sum1 = c.PredictHistoryByInput(input,out sum2);
            Assert.AreEqual(sum1, 18);
            Assert.AreEqual(sum2, -3);
        }
        [Test]
        public void predict_history_for_given_input_2()
        {
            var list = new List<int>() { 1, 3, 6, 10, 15, 21 };
            var input = new List<List<int>> { list };
            var c = new PredictHistory();
            int sum2 = 0;
            var sum1 = c.PredictHistoryByInput(input, out sum2);
            Assert.AreEqual(sum1, 28);
            Assert.AreEqual(sum2, 0);
        }
        [Test]
        public void predict_history_for_given_input_3()
        {
            var list = new List<int>() { 10, 13, 16, 21, 30, 45 };
            var input = new List<List<int>> { list };
            var c = new PredictHistory();
            int sum2 = 0;
            var sum1 = c.PredictHistoryByInput(input, out sum2);
            Assert.AreEqual(sum1, 68);
            Assert.AreEqual(sum2, 5);
        }

        [Test]
        public void predict_history_for_given_input_4()
        {
            var list = new List<int>() { 0, 0, 0, 0, 0, 0 };
            var input = new List<List<int>> { list };
            var c = new PredictHistory();
            int sum2 = 0;
            var sum1 = c.PredictHistoryByInput(input, out sum2);
            Assert.AreEqual(sum1, 0);
            Assert.AreEqual(sum2, 0);
        }

        [Test]
        public void predict_history_for_given_input_5()
        {
            var list = new List<int>() { -1, -4, 6, 7, -10, 11 };
            var input = new List<List<int>> { list };
            var c = new PredictHistory();
            int sum2 = 0;
            var sum1 = c.PredictHistoryByInput(input, out sum2);
            Assert.AreEqual(sum1, 243);
            Assert.AreEqual(sum2, -2);
        }

        [Test]
        public void predict_history_for_given_input_6()
        {
            var list1 = new List<int>() { 0, 3, 6, 9, 12, 15 };
            var list2 = new List<int>() { 1, 3, 6, 10, 15, 21 };
            var list3 = new List<int>() { 10, 13, 16, 21, 30, 45 };

            var input = new List<List<int>> { list1,list2,list3 };
            var c = new PredictHistory();
            int sum2 = 0;
            var sum1 = c.PredictHistoryByInput(input, out sum2);
            Assert.AreEqual(sum1, 114);
            Assert.AreEqual(sum2, 2);
        }
        [Test]
        public void check_exception_when_fileName_is_null()
        {
            var c = new PredictHistory();
            Assert.Throws<FileNotFoundException>(() => c.convertInput(null));
        }
        [Test]
        public void check_exception_when_fileName_is_empty()
        {
            var c = new PredictHistory();
            Assert.Throws<FileNotFoundException>(() => c.convertInput(""));
        }
        [Test]
        public void check_exception_when_fileName_does_not_exists()
        {
            var c = new PredictHistory();
            Assert.Throws<FileNotFoundException>(() => c.convertInput("input.txt"));
        }
        [Test]
        public void check_exception_when_file_has_empty_contents()
        {
            var c = new PredictHistory();
            Assert.Throws<InvalidDataException>(() => c.convertInput(@"C:\Users\Empty.txt"));
        }
    }
}