using System.Collections.Generic;
using System.Linq;
using NBench;
using NBench.Collection.Memory;

namespace TestingGarbageCollection
{
    public class GarbageCollectionTests
    {
        [PerfBenchmark(RunMode = RunMode.Iterations, TestMode = TestMode.Measurement)]
        [GcMeasurement(GcMetric.TotalCollections, GcGeneration.AllGc)]
        public void MeasureGarbageCollections()
        {
            RunTest();
        }

        [PerfBenchmark(RunMode = RunMode.Iterations, TestMode = TestMode.Test)]
        [GcThroughputAssertion(GcMetric.TotalCollections, GcGeneration.Gen0, MustBe.LessThan, 300)]
        [GcThroughputAssertion(GcMetric.TotalCollections, GcGeneration.Gen1, MustBe.LessThan, 150)]
        [GcThroughputAssertion(GcMetric.TotalCollections, GcGeneration.Gen2, MustBe.LessThan, 20)]
        [GcTotalAssertion(GcMetric.TotalCollections, GcGeneration.Gen2, MustBe.LessThan, 50)]
        public void TestGarbageCollections()
        {
            RunTest();
        }

        private readonly List<int[]> gen1list = new List<int[]>();

        private void RunTest()
        {
            for (var i = 0; i < 500; i++)
            {
                for (var j = 0; j < 10000; j++)
                {
                    var data = new int[100];
                    gen1list.Add(data.ToArray());
                }

                gen1list.Clear();
            }

            for (var i = 0; i < 50; i++)
            {
                var gen2array = new int[100000];
            }
        }
    }
}
