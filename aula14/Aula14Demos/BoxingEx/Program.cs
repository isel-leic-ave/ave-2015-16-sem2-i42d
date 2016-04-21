using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoxingEx
{
    struct V { int i; public void Inc() { ++i; } }

    class Program
    {
        public static void Main()
        {
            V v = new V();
            object o = v;
            ((V)o).Inc();
            Console.WriteLine((V)o);
        }
    }
}
