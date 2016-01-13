using System;
using System.Linq;

namespace BearSlowlySorts
{
    public class BearSlowlySorts
    {
        public int MinMoves(int[] w)
        {
            var n = w.Length;
            var count = 0;
            while (!IsSorted(w))
            {
                var s1 = w.Skip(1).Count(x => x < w[0]);
                var s2 = w.Take(n - 1).Count(x => x > w[n - 1]);

                if (s1 > s2)
                {
                    w = w.Take(n - 1).OrderBy(x => x).Union(new[] { w[n - 1] }).ToArray();
                }
                else
                {
                    w = new[] { w[0] }.Concat(w.Skip(1).OrderBy(x => x)).ToArray();
                }

                count++;
            }

            return count;
        }

        public double MinMoves2(int[] w)
        {
            var n = w.Length;

            var w1 = w.ToArray();
            var w2 = w.ToArray();
            
            var count = 0;
            while (!IsSorted(w1) && !IsSorted(w2) )
            {
                Array.Sort(w1,     count % 2, n - 1);
                Array.Sort(w2, 1 - count % 2, n - 1);
                count++;
            }

            return count;
        }

        public double MinMoves3(int[] w)
        {
            var n = w.Length;

            if (IsSorted(w))
            {
                return 0;
            }

            var minIndex = Array.IndexOf(w, w.Min());
            var maxIndex = Array.IndexOf(w, w.Max());

            if (minIndex == 0 || maxIndex == n - 1)
            {
                return 1;
            }

            if (maxIndex == 0 || minIndex == n - 1)
            {
                return 3;
            }

            return 2;
        }

        private static bool IsSorted(int[] v)
        {
            for (var i = 1; i < v.Length; i++)
            {
                if (v[i - 1] > v[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
