using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodDispatchDemo
{
    class B
    {
        public static int x;
        public static void a() { x *= 2; }
        // método não virtual
        public void f()
        {
            Console.WriteLine("B.f()");
        }
        // método virtual
        public virtual void g()
        {
            Console.WriteLine("B.g()");
        }
    }

    class C : B
    {
        public new void f()
        {
            Console.WriteLine("C.f()");
        }
        public override void g()
        {
            Console.WriteLine("C.g()");
        }
    }

    class D : C
    {

    }

    class Program
    {
        void M(B b)
        {
            b.g();
        }
        static void Main(string[] args)
        {
            B.a();

            B b = new D();
            b.g(); // chamada virtual
            b.g(); // chamada virtual
            b.f(); // chamada não virtual
        }
    }
}
