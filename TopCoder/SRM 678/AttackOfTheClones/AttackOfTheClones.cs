using System;
using System.Linq;

public class AttackOfTheClones
{
    public int Count(int[] firstWeek, int[] lastWeek)
    {
        if (firstWeek.SequenceEqual(lastWeek))
        {
            return 1;
        }

        var n = firstWeek.Length;
        var lastWeekMap = firstWeek.Select(x => Array.IndexOf(lastWeek, x)).ToArray();

        for (var weeks = 2; weeks < n; weeks++)
        {
            if (IsMissionPossible(n, weeks, lastWeekMap))
            {
                return weeks;
            }
        }

        return n;
    }

    private static bool IsMissionPossible(int n, int weeks, int[] lastWeekMap)
    {
        var count = 0;
        for (var shirt = 0; shirt < n; shirt++)
        {
            var step = n - 1;
            var minLastWeekShirtIndex = shirt + step * (weeks - 1);

            var lastWeekStartIndex = n * (weeks - 1);
            var finalShirtPosition = lastWeekStartIndex + lastWeekMap[shirt];

            if (minLastWeekShirtIndex <= finalShirtPosition)
            {
                count++;
            }
        }

        return count == n;
    }

    public int Count2(int[] firstWeek, int[] lastWeek)
    {
        return firstWeek.Select((x, index) => index - Array.IndexOf(lastWeek, x) + 1).Max();
    }
}
