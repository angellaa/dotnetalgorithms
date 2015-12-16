using System.Collections.Generic;
using System.Linq;

public class BearSong
{
    public int countRareNotes1(int[] notes)
    {
        return notes.Where(x => notes.Count(y => y == x) == 1).Count();
    }

    public int countRareNotes2(int[] notes)
    {
        int rareNotes = 0;
        foreach (var x in notes)
        {
            int occurrences = 0;

            foreach (var y in notes)
            {
                if (y == x)
                {
                    occurrences++;
                }
            }

            if (occurrences == 1)
            {
                rareNotes++;
            }
        }

        return rareNotes;
    }

    public int countRareNotes3(int[] notes)
    {
        var counters = new Dictionary<int, int>();

        foreach (var note in notes)
        {
            if (counters.ContainsKey(note))
            {
                counters[note]++;
            }
            else
            {
                counters[note] = 1;
            }
        }

        return counters.Count(x => x.Value == 1);
    }
}