using System;
using System.Linq;

namespace PaintingFence
{
    /// <summary>
    /// Problem on Codeforce: http://codeforces.com/problemset/problem/448/C
    /// Submittion accepted. Time: 62 ms, Memory: 3200 KB
    /// </summary>
    public class Program
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            var heights = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var min = MinStrokes(heights, 0, 0, n - 1);

            Console.WriteLine(min);
        }

        internal static int MinStrokes(int[] heights, int start, int a, int b)
        {
            if (b < a) return 0;
            if (a == b) return (heights[a] - start) > 0 ? 1 : 0;

            var minIndex = a;
            var min = heights[a];
            for (var i = a; i <= b; i++)
            {
                if (heights[i] < min)
                {
                    min = heights[i];
                    minIndex = i;
                }
            }

            var min1 = (min - start) + MinStrokes(heights, min, a, minIndex - 1) + MinStrokes(heights, min, minIndex + 1, b);
            var min2 = b - a + 1;

            return Math.Min(min1, min2);
        }
    }
}

