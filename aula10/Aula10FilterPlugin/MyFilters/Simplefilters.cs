using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFilters
{
    public class TwoFilters
    {
        public static void F1(int[] a)
        {
            Console.WriteLine("At TwoFilters.F1");
        }
        public static void F2(int[] a)
        {
            Console.WriteLine("At TwoFilters.F2");
        }
    }


    public class FilterAdd1 : IFilter
    {
        public void Apply(int[] image)
        {
            for (int i = 0; i < image.Length; ++i)
            {
                image[i] += 1;
            }
        }
    }

    public class FilterMult2 : IFilter
    {
        public void Apply(int[] image)
        {
            for (int i = 0; i < image.Length; ++i)
            {
                image[i] *= 2;
            }
        }
    }
}
