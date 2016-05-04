using System;
using System.Collections.Generic;

namespace yield
{
    class Program
    {
        static IEnumerable<int> Count123()
        {
            yield return 1;
            yield return 2;
            yield return 3;
        }

        static IEnumerable<int> Count1ToN(int n)
        {
            for (int i = 1; i < n; ++i)
            {
                yield return i;
            }
        }

        static void Main(string[] args)
        {
            foreach(int n in Count123())
            {
                Console.WriteLine(n);
            }
        }
    }
}
