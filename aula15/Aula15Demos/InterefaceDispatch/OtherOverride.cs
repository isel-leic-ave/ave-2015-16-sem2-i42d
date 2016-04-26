using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MethodDispatchExample
{
    interface I { void M(); }

    class A : I
    {
        void I.M() { Console.Write("I.A "); }
        public virtual void M() { Console.Write("A "); }
    }

    class B : A { public new virtual void M() { Console.Write("B "); } }

    class C : B { public new void M() { Console.Write("C "); } }

    public class Test
    {
        public static void Main()
        {
            C c = new C();
            A a = c; B b = c; I i = c;
            a.M(); b.M(); c.M(); i.M();
        }
    }

    /*
    Qual o output da execução de Program:

      a) para a definição dada?

      b) se o método M de C tiver o atributo override?

      c) se o método M de C tiver o atributo override e a classe B 
         for declarada como class B : A, I {...} mantendo a mesma implementação.

    */

}
