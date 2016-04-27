using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Broken
{
    class Broken2
    {
        public static int Solve(int m, string text)
        {
            int result;
            Broken2Internal(m, text.ToCharArray(), 0, text.Length - 1, out result);

            return result;
        }

        private static Tuple<int, int> Broken2Internal(int m, char[] text, int start, int end, out int result)
        {
            if (start >= end)
            {
                result = 0;
                return Tuple.Create(0, 0);
            }

            var substring = new string(text).Substring(start, end - start + 1);
            var frequencyMap = new FrequencyMap(substring);

            //Console.WriteLine($"Count: {frequencyMap.Count}\tLength: {end - start + 1}\t'{substring}'");

            if (frequencyMap.Count <= m)
            {
                result = end - start + 1;
                return Tuple.Create(start, end);
            }

            int mid = (start + end) / 2;

            int length1;
            int length2;
            int length3;

            var result1 = Broken2Internal(m, text, start, mid, out length1);
            var result2 = Broken2Internal(m, text, mid + 1, end, out length2);
            var result3 = Broken2Internal(m, text, result1.Item2 + 1, result2.Item1 - 1, out length3);

            var max = Math.Max(length1, Math.Max(length2, length3));

            result = max;
            return length1 == max ? result1 : (length2 == max ? result2 : result3);
        }
    }
}
