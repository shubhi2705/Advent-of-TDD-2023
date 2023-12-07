using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Http;
namespace AdventOfCodeTDD
{
   public class Race
    {
        public static void Main()
        {
            var race = new Race();
            var tracker = new Dictionary<long, long>();
            var recordTracker = new Dictionary<long, long>();
            tracker.Add(56, 334);
            tracker.Add(71, 1135);
            tracker.Add(79, 1350);
            tracker.Add(99, 2430);
            recordTracker.Add(56717999, 334113513502430);
            var recordCount=race.RecordTracker(tracker);
            var totalWaysCount = race.calculateTotalWays(recordTracker);        
        }
        public long RecordTracker(Dictionary<long, long> tracker)
        {
            if (tracker.Count > 0)
            {
                var recordCount = 1L;
                foreach (var key in tracker)
                {
                    var result = countRecords(key.Key, key.Value);
                    recordCount *= result;
                }
                return recordCount;
            }
            else
            {
                throw new Exception("Please provide some input");
            }         
        }

        public long countRecords(long time, long distance)
        {
            var record = 0;
            for(long i = 0; i < time; i++)
            {
                if ((i * (time - i)) > distance)
                {
                    record++;
                }
            }
            return record;
        }

        public long calculateTotalWays(Dictionary<long,long> recordTrack)
        {
            var totalWays = 0L;
            foreach(var key in recordTrack)
            {
                var result = countRecords(key.Key, key.Value);
                totalWays += result;
            }
            return totalWays;
        }
    }
}
