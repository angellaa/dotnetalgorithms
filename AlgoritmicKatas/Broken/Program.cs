using System;
using System.Collections.Generic;

namespace Broken
{
    public class Program
    {
        static void Main()
        {
            for (;;)
            {
                var m = int.Parse(Console.ReadLine() ?? "0");
                if (m == 0)
                {
                    return;
                }

                var text = Console.ReadLine();

                Console.WriteLine(Broken2(m, text));
            }
        }
        
        private static int Calculate1(int m, string text)
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

        private static int Broken2(int m, string text)
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

        private class FrequencyMap
        {
            private Dictionary<char, int> frequency = new Dictionary<char, int>();

            public FrequencyMap(string text)
            {
                foreach (var c in text)
                {
                    Add(c);
                }
            }

            public int Count { get; private set; }

            public void Add(char c)
            {
                if (!frequency.ContainsKey(c) || frequency[c] == 0)
                {
                    frequency[c] = 0;
                    Count++;
                }

                frequency[c]++;
            }

            public void Remove(char c)
            {
                frequency[c]--;

                if (frequency[c] == 0)
                {
                    Count--;
                }
            }
        }
    }
}
