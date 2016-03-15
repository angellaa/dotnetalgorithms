using System.Collections.Generic;
using NBench;

namespace NUnitPerformanceTesting
{
    public class DictionaryMemoryTests : PerformanceTestStuite<DictionaryMemoryTests>
    {
        private const int NumberOfAdds = 1000000;
        private const int DictionaryEntrySize = 24;
        private const int MaxExpectedMemory = NumberOfAdds * DictionaryEntrySize;

        [PerfBenchmark(RunMode = RunMode.Iterations, TestMode = TestMode.Measurement)]
        [MemoryMeasurement(MemoryMetric.TotalBytesAllocated)]
        public void AddMemoryMeasurement()
        {
            var dictionary = new Dictionary<int, int>();

            Populate(dictionary, NumberOfAdds);
        }

        [PerfBenchmark(RunMode = RunMode.Iterations, TestMode = TestMode.Test, Description = "Dictionary without capacity, add memory test.")]
        [MemoryAssertion(MemoryMetric.TotalBytesAllocated, MustBe.LessThan, MaxExpectedMemory)]
        public void AddMemory_FailingTest()
        {
            var dictionary = new Dictionary<int, int>();

            Populate(dictionary, NumberOfAdds);
        }

        [PerfBenchmark(RunMode = RunMode.Iterations, TestMode = TestMode.Test)]
        [MemoryAssertion(MemoryMetric.TotalBytesAllocated, MustBe.LessThan, MaxExpectedMemory)]
        public void AddMemory_PassingTest()
        {
            var dictionary = new Dictionary<int, int>(NumberOfAdds);

            Populate(dictionary, NumberOfAdds);
        }

        public void Populate(Dictionary<int, int> dictionary, int n)
        {
            for (var i = 0; i < n; i++)
            {
                dictionary.Add(i, i);
            }
        }
    }
}
