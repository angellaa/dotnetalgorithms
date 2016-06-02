
using System;

class KingdomAndTrees
{
    public int MinLevel(int[] heights)
    {
        var left = 0;
        var right = 1000000000;
        var minX = -1;

        while (left <= right)
        {
            var x = (left + right) / 2;

            if (CanOrderTrees(heights, x))
            {
                minX = x;
                right = x - 1;
            }
            else
            {
                left = x + 1;
            }
        }

        return minX;
    }

    private bool CanOrderTrees(int[] heights, int x)
    {
        var previousHeight = 0;

        foreach (var height in heights)
        {
            if (height + x <= previousHeight)
            {
                return false;
            }

            previousHeight = Math.Max(previousHeight + 1, height - x);
        }

        return true;
    }
}