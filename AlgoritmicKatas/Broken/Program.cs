using System;
using System.Collections.Generic;

namespace Broken
{
    public class Program
    {
        static void Main()
        {
            Console.WriteLine(Calculate1(5, "aaaaaaaaaaaaaa"));
            Console.WriteLine();
            Console.WriteLine(Calculate1(1, "Mississippi"));
            Console.WriteLine();
            Console.ReadKey();

            for (;;)
            {
                var m = int.Parse(Console.ReadLine() ?? "0");
                if (m == 0)
                {
                    return;
                }

                var text = Console.ReadLine();

                Console.WriteLine(Calculate1(m, text));
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
    }
}
