using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DelegatesIntro
{
    delegate void Display(int v);

    class Program
    {
        static void Main(string[] args)
        {
            Display d = new Display(Show1);

            int[] values = new int[] { 1, 2, 3, 4, 5 };

            Process(values, d);
        }

        public static void Process(int[] values, Display d)
        {
            throw new NotImplementedException();
        }

        public static void Show1(int v)
        {
            throw new NotImplementedException();
        }
    }
}
