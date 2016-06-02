using System;
using System.Collections.Generic;

namespace FrogRiverOne
{
    public class FrogRiverOne
    {
        // NOTES

        /// Time complexity O(N*X)
        /// Space complexity O(1)
        /// Correctness 100%
        /// Performance 60%
        /// Task Score 81%
        /// https://codility.com/demo/results/trainingUHJVAX-326/
        public static int Solution1(int X, int[] A)
        {
            var t = -1;
            for (var i = 1; i <= X; i++)
            {
                var pos = Array.IndexOf(A, i);
                if (pos == -1)
                {
                    return -1;
                }

                t = Math.Max(t, pos);
            }
            return t;
        }

        /// Time complexity O(N)
        /// Space complexity O(X)
        /// Correctness 100%
        /// Performance 100%
        /// Task Score  100%
        /// https://codility.com/demo/results/training6MW9SR-8CE/
        public static int Solution2(int X, int[] A)
        {
            var leaves = new HashSet<int>();

            for (var time = 0; time < A.Length; time++)
            {
                leaves.Add(A[time]);

                if (leaves.Count == X)
                {
                    return time;
                }
            }

            return -1;
        }
    }
}