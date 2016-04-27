using System;
using System.Collections.Generic;

namespace Broken
{
    public class Program
    {
        static void Main()
        {
            Console.WriteLine(Broken3(5, "This can't be solved by brute force."));

            //for (;;)
            //{
            //    var m = int.Parse(Console.ReadLine() ?? "0");
            //    if (m == 0)
            //    {
            //        return;
            //    }

            //    var text = Console.ReadLine();

            //    Console.WriteLine(Broken3(m, text));
            //}
        }
        
        private static int Broken3(int m, string text)
        {
            var frequencyMap = new FrequencyMap();
            var n = text.Length;

            var start = 0;
            var end = 0;
            var result = 1;

            while (end < n)
            {
                frequencyMap.Add(text[end]);
                if (frequencyMap.Count <= m)
                {
                    end++;
                    continue;
                }

                result = Math.Max(result, end - start);
                frequencyMap.Remove(text[start++]);
                frequencyMap.Remove(text[end]);
            }

            return Math.Max(result, end - start);
        }
    }

    public class FrequencyMap
    {
        private Dictionary<char, int> frequency = new Dictionary<char, int>();

        public FrequencyMap()
        {
        }

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
