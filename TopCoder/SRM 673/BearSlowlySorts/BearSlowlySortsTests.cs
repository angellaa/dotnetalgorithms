using NUnit.Framework;

namespace BearSlowlySorts
{
    public class BearSlowlySortsTests
    {
        [Test, TestCaseSource(nameof(TestCases))]
        public void MinMovesTest(int[] w, int count)
        {
            Assert.AreEqual(count, new BearSlowlySorts().MinMoves(w));
        }

        [Test, TestCaseSource(nameof(TestCases))]
        public void MinMovesTest2(int[] w, int count)
        {
            Assert.AreEqual(count, new BearSlowlySorts().MinMoves2(w));
        }

        [Test, TestCaseSource(nameof(TestCases))]
        public void MinMovesTest3(int[] w, int count)
        {
            Assert.AreEqual(count, new BearSlowlySorts().MinMoves3(w));
        }

        private static readonly object[] TestCases =
        {
            new object[]
            {
                new[] {2,6,8,5}, 1
            },
            new object[]
            {
                new[] {4,3,1,6,2,5}, 2
            },
            new object[]
            {
                new[] {93,155,178,205,213,242,299,307,455,470,514,549,581,617,677}, 0
            },
            new object[]
            {
                new[] {50,20,30,40,10}, 3
            },
            new object[]
            {
                new[] {234,462,715,596,906,231,278,223,767,925,9,526,369,319,241,354,317,880,5,696}, 2
            },
        };
    }
}