using NUnit.Framework;

public class ChessMetricTests
{
    [TestCase(3, new[] { 0, 0 }, new[] { 1, 0 }, 1, 1)]
    [TestCase(3, new[] { 0, 0 }, new[] { 1, 2 }, 1, 1)]
    [TestCase(3, new[] { 0, 0 }, new[] { 2, 2 }, 1, 0)]
    [TestCase(3, new[] { 0, 0 }, new[] { 0, 0 }, 2, 5)]
    [TestCase(100, new[] { 0, 0 }, new[] { 0, 99 }, 50, 243097320072600)]
    [TestCase(8, new[] { 4, 4 }, new[] { 4, 4 }, 6, 246460)]
    [TestCase(8, new[] { 2, 3 }, new[] { 7, 7 }, 9, 69232032)]
    [TestCase(3, new[] { 0, 0 }, new[] { 2, 2 }, 20, 979171322101760)]
    [TestCase(10, new[] { 5, 5 }, new[] { 9, 9 }, 4, 133)]
    [TestCase(13, new[] { 3, 7 }, new[] { 11, 5 }, 4, 4)]
    [TestCase(13, new[] { 3, 7 }, new[] { 11, 5 }, 14, 96417727286208)]
    [TestCase(100, new[] { 0, 0 }, new[] { 50, 50 }, 35, 480451056515520)]
    [TestCase(100, new[] { 0, 0 }, new[] { 50, 50 }, 34, 485001159390)]
    [TestCase(100, new[] { 99, 99 }, new[] { 0, 0 }, 50, 0)]
    [TestCase(100, new[] { 99, 99 }, new[] { 0, 0 }, 50, 0)]
    [TestCase(100, new[] { 99, 99 }, new[] { 0, 0 }, 50, 0)]
    [TestCase(3, new[] { 0, 2 }, new[] { 2, 0 }, 1, 0)]
    [TestCase(3, new[] { 0, 0 }, new[] { 0, 0 }, 1, 0)]
    public void ChessMetricTest(int size, int[] start, int[] end, int numMoves, long expectedCount)
    {
        var cm = new ChessMetric();

        long actualCount = cm.HowMany(size, start, end, numMoves);

        Assert.AreEqual(expectedCount, actualCount);
    }
}