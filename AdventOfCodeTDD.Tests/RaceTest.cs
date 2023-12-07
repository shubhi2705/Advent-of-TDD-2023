using AdventOfCodeTDD;

namespace AdventOfCodeTDD.Tests
{
    [TestFixture]
    public class RaceTest
    {
        [Test]
        public void calculate_No_of_ways_when_distance_9_and_time_7()
        {
            var race = new Race();
            var result = race.countRecords(7,9);
            Assert.AreEqual(4,result);
        }
        [Test]
        public void calculate_No_of_ways_when_distance_40_and_time_15()
        {
            var race = new Race();
            var result = race.countRecords(15,40);
            Assert.AreEqual(8, result);
        }

        [Test]
        public void calculate_No_of_ways_when_distance_200_and_time_30()
        {
            var race = new Race();
            var result = race.countRecords(30,200);
            Assert.AreEqual(9, result);
        }

        [Test]
        public void calculate_No_of_ways_when_input_size_is_longType()
        {
            var race = new Race();
            var tracker = new Dictionary<long, long>();
            tracker.Add(56717999, 334113513502430);
            var result = race.calculateTotalWays(tracker);
            Assert.NotNull(result);
            Assert.AreEqual(43364472, result);
        }

        [Test]
        public void calculate_No_of_ways_when_input_size_is_small()
        {
            var race = new Race();
            var tracker = new Dictionary<long, long>();
            tracker.Add(7, 9);
            var result = race.calculateTotalWays(tracker);
            Assert.NotNull(result);
            Assert.AreEqual(4, result);
        }

        [Test]
        public void calculate_No_of_ways_when_input_size_is_zero()
        {
            var race = new Race();
            var tracker = new Dictionary<long, long>();
            var result = race.calculateTotalWays(tracker);
            Assert.NotNull(result);
            Assert.AreEqual(0, result);
        }

        [Test]
        public void calculate_multiply_of_No_of_ways_for_given_input()
        {
            var race = new Race();
            var tracker = new Dictionary<long, long>();
            tracker.Add(7, 9);
            tracker.Add(15, 40);
            tracker.Add(30, 200);
            var result = race.RecordTracker(tracker);
            Assert.AreEqual(288, result);
        }

        [Test]
        public void exception_when_input_is_empty()
        {
            var race = new Race();
            var tracker = new Dictionary<long, long>();
            Assert.Throws<Exception>(() => race.RecordTracker(tracker));
        }
    }
}