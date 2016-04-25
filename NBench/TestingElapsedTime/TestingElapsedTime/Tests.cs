using NBench;
using System.Threading;

namespace TestingElapsedTime
{
    public class Tests
    {
        [PerfBenchmark(TestMode = TestMode.Test)]
        [ElapsedTimeAssertion(MaxTimeMilliseconds = 100)]
        public void PassingTest_WhenCodeRunsInLessThan_100_ms()
        {
            Thread.Sleep(90);
        }

        [PerfBenchmark(TestMode = TestMode.Test)]
        [ElapsedTimeAssertion(MinTimeMilliseconds = 50, MaxTimeMilliseconds = 100)]
        public void FailingTest_WhenCodeRunsInLessThan_50_ms()
        {
            Thread.Sleep(20);
        }
    }
}
