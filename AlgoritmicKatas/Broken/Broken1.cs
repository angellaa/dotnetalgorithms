using System;
using System.Collections.Generic;

namespace Broken
{
    public class Broken1
    {
        private static int Solve(int m, string text)
        {
            if (string.IsNullOrEmpty(text))
            {
                return 0;
            }

            var start = 0;
            var nextStart = -1;
            var set = new HashSet<char>();
            var max = 0;

            for (var i = 0; i < text.Length; i++)
            {
                var c = text[i];

                if (set.Contains(c))
                {
                    continue;
                }

                if (set.Count == 1)
                {
                    nextStart = i;
                }

                if (set.Count == m)
                {
                    max = Math.Max(max, i - start);
                    set.Clear();
                    start = nextStart;
                    i = start - 1;
                    continue;
                }

                set.Add(c);
            }

            return max == 0 ? text.Length : max;
        }
    }
}
