using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TPC
{
    abstract class A
    {
        public virtual void M1()
        {
            Console.WriteLine("A.M1");
        }
        public abstract void M2();
        public void M3()
        {
            Console.WriteLine("A.M3");
        }
    }

    class B : A
    {
        public override void M2()
        {
            Console.WriteLine("B.M2");
        }
    }

    class C : B
    {
        public override void M1()
        {
            Console.WriteLine("C.M1");
        }
    }
    class D : C
    {
        public override void M1()
        {
            Console.WriteLine("D.M1");
        }
        public override void M2()
        {
            Console.WriteLine("D.M2");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            A a = new D();
            a.M3();
            a.M1();
            a.M2();
            //((C)a).M1(); /* 1.b)*/
        }
    }
}
