using NUnit.Framework;

public class BearSongTests
{
    [Test, TestCaseSource(nameof(TestCases))]
    public void countRateNotes1(int[] notes, int rareNotes)
    {
        Assert.AreEqual(rareNotes, new BearSong().countRareNotes1(notes));
    }

    [Test, TestCaseSource(nameof(TestCases))]
    public void countRateNotes2(int[] notes, int rareNotes)
    {
        Assert.AreEqual(rareNotes, new BearSong().countRareNotes2(notes));
    }

    [Test, TestCaseSource(nameof(TestCases))]
    public void countRateNotes3(int[] notes, int rareNotes)
    {
        Assert.AreEqual(rareNotes, new BearSong().countRareNotes3(notes));
    }

    static readonly object[] TestCases =
    {
        new object[]
        {
            new[] { 9, 10, 7, 8, 9 },
            3
        },
        new object[]
        {
            new[] { 8, 8, 7, 6, 7, 3, 5, 10, 9, 3 },
            4
        },
        new object[]
        {
            new[] { 234, 462, 715, 596, 906 },
            5
        },
        new object[] 
        {
            new[] { 1000,1000,1000,1000,1000,1000,1000,1000,1000,1000,1000,1000,1000,1000,1000,1000,1000,
                    1000,1000,1000,1000,1000,1000,1000,1000,1000,1000,1000,1000,1000,1000,1000,1000,1000,
                    1000,1000,1000,1000,1000,1000,1000,1000,1000,1000,1000,1000,1000,1000,1000,1000 },
            0
        }
    };
}