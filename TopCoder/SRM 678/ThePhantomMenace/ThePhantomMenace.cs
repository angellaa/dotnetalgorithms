using System;
using System.Linq;

public class ThePhantomMenace
{
    public int Find(int[] doors, int[] droids)
    {
        var maxSafetyLevel = 0;

        foreach (var door in doors)
        {
            var safetyLevel = droids.Select(x => Math.Abs(door - x)).Min();
            maxSafetyLevel = Math.Max(maxSafetyLevel, safetyLevel);
        }

        return maxSafetyLevel;
    }

    public int Find2(int[] doors, int[] droids)
    {
        var safetyLevels = doors.Select(door => droids.Select(x => Math.Abs(door - x)).Min());

        return safetyLevels.Max();
    }
}
