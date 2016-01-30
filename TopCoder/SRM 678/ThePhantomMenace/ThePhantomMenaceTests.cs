using NUnit.Framework;

public class ThePhantomMenaceTests
{
    [TestCaseSource(nameof(TestCases))]
    public void FindTests(int[] doors, int[] droids, int expected)
    {
        Assert.AreEqual(expected, new ThePhantomMenace().Find(doors, droids));
    }

    [TestCaseSource(nameof(TestCases))]
    public void Find2Tests(int[] doors, int[] droids, int expected)
    {
        Assert.AreEqual(expected, new ThePhantomMenace().Find(doors, droids));
    }

    private static readonly object[] TestCases =
    {
        new object[]
        {
            new[] {1, 2, 3, 4}, new[] {5, 6, 7, 8}, 4
        },
        new object[]
        {
            new[] {1}, new[] {10}, 9
        },
        new object[]
        {
            new[] {2,3,5,7,11}, new[] {1,8,13}, 3
        },
        new object[]
        {
            new[] {2,1}, new[] {4,3}, 2
        }
    };
}