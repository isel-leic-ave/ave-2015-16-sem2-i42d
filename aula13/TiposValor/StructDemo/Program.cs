using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StructDemo
{

    interface IChange
    {
        void Add(int offset);
    }

    public struct Point : IChange
    {
        public int x;
        public int y;

        public Point(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
        public void Add(int offset)
        {
            this.x += offset;
            y += offset;
        }
        public static void Display(Point p)
        {
            Console.WriteLine("x={0} y={1}", p.x, p.y);
            p.x = -100;
        }

        public static void Display(ref Point p)
        {
            Console.WriteLine("x={0} y={1}", p.x, p.y);
            p.x = -1;
        }
    }

    class A
    {
        int x = 10;
    }

    class Program
    {
        static void Main(string[] args)
        {
            Point first = new Point(2,4);

            Point p;                // variável local com espaço para dois inteiros (x e y)
            p.x = 10;
            p.y = 20;
            Point.Display(p);  

            Point p2 = new Point(); // usa initobj para iniciar os campos com valor por omissão
            Point.Display(p2);

            // call to instance method
            p2.Add(3);

            // copy
            Point other = p2;
            Point.Display(other);

            A a1 = new A(), a2 = new A();
            if (a1.Equals(a2)) // compara equivalencia
            {

            }

            if (Object.ReferenceEquals(a1, a2)) 
                // compara o valor das referencias, ou seja,
                // identidade
            {

            }

            if (p.Equals(p2))
            {

            }
            
           
            //call by ref
            Point.Display(ref p);
            
            // call by copy
            Point.Display(p);
            
            /*
            Console.WriteLine(p1.Equals(other));
            Console.WriteLine(p1.Equals(p));
            //Console.WriteLine(p1 == other);
            */
        }
    }
}
