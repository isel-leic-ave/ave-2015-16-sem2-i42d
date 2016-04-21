using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Boxing
{
    public interface IAdjust
    {
        void Adjust();
    }

    public struct Point : IAdjust
    {
        public int x;
        public int y;

        public void Adjust()
        {
            x += 2; y += 2;
        }
        public override bool Equals(object o)
        {
            if (o == null || o.GetType() != typeof(Point))
                return false;
            return Equals((Point)o);
        }
        public bool Equals(Point p)
        {
            return this.x == p.x && this.y == p.y;
        }
        public override int GetHashCode()
        {
            return x + y;
        }
        
        public override string ToString()
        {
            return String.Format("x={0} y={1}", this.x, this.y);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            int x = 10;
            object o = x;
            Console.WriteLine("x={0}", o);
            Console.WriteLine("x={0}", x);
            Console.WriteLine("before unbox x={0}", x.ToString());
            x = 1024;
            Console.WriteLine("after unbox x={0}", ((int)o).ToString());

            Point p;
            p.x = 1;
            p.y = 2;

            Type t = p.GetType();
            Console.WriteLine(p.ToString());

            IAdjust iadj = p;
            iadj.Adjust();
            Console.WriteLine(p.x + ";" + p.y);
            Point punbox = (Point)iadj;
            Console.WriteLine(punbox.x + ";" + punbox.y);
        }
    }
}
