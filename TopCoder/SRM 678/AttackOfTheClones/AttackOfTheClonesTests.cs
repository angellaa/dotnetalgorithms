using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

public class AttackOfTheClonesTests
{
    [TestCaseSource(typeof(AttackOfTheClonesTests), nameof(TestCases))]
    public int CountTests(int[] firstWeek, int[] lastWeek)
    {
        return new AttackOfTheClones().Count(firstWeek, lastWeek);
    }

    [TestCaseSource(typeof(AttackOfTheClonesTests), nameof(TestCases))]
    public int Count2Tests(int[] firstWeek, int[] lastWeek)
    {
        return new AttackOfTheClones().Count2(firstWeek, lastWeek);
    }

    private static IEnumerable<TestCaseData> TestCases()
    {
        yield return new TestCaseData(new[] {1, 2, 3, 4}, new  [] {4, 3, 2, 1}).Returns(4);
        yield return new TestCaseData(new[] { 1, 2, 3, 4 }, new[] { 1, 2, 3, 4 }).Returns(1);
        yield return new TestCaseData(new[] { 8, 4, 5, 1, 7, 6, 2, 3 }, 
                                      new[] { 2, 4, 6, 8, 1, 3, 5, 7 }).Returns(7);

        var largestFirstWeek = Enumerable.Range(0, 2500).ToArray();
        var largestLastWeek = largestFirstWeek.Reverse().ToArray();
        
        yield return new TestCaseData(largestFirstWeek, largestLastWeek).Returns(2500);
    }

}