using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula16Demos
{
    class A { }
    class B : A { }
    class C : B { }
    class D : A { }

    delegate A Action(B b);

    delegate void Display<T>(T v);

    class X<T>
    {
        private T t;
        public void m()
        {
            T x = t;
        }
    }

    class VarianceInDelegates
    {
        public static void Main()
        {
            Console.WriteLine(typeof(Display<>));
            Console.WriteLine(typeof(Display<int>));
            Console.WriteLine(typeof(Display<String>));

            Console.WriteLine(
                typeof(Display<int>)==
                typeof(Display<double>));

            Console.WriteLine(
                typeof(Display<String>) ==
                typeof(Display<A>));


            Display<int> d = (v) => { Console.WriteLine(v.GetType()); };
            d(10);

            Display<String> d2 = (v) => { Console.WriteLine(v.GetType()); };
            d2("AVE");


            Action a = new Action(Op1);
            Action a1 = new Action(Op2);
            String prefix = "****";
            Action a2 = (x) => {
                Console.WriteLine(prefix + x);
                return new B();
            };

            //Action a2 = new Action(Op4);
        }

        public static A Op1(B b) {
            return new B();
        }
        public static B Op2(A a)
        {
            return new B();
        }
        public static B Op3(D s)
        {
            return new B();
        }
        public static B Op4(C s)
        {
            return new B();
        }
    }
}
