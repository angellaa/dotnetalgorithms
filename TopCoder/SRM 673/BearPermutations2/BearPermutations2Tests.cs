using System.Runtime.Remoting;
using NUnit.Framework;

namespace BearPermutations2
{
    public class BearPermutations2Tests
    {
        [TestCaseSource(nameof(TestCases))]
        public void GetSum(int n, int mod, int sum)
        {
            Assert.AreEqual(sum, new BearPermutations2().GetSum(n, mod));
        }

        private static readonly object[] TestCases =
        {
            new object[] {0, 123, 0},
            new object[] {1, 1000003, 0},
            new object[] {3, 502739849, 4},
            new object[] {4, 973412327, 38},
            new object[] {100, 89, 49},
        };
    }
}