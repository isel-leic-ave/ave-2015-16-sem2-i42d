using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodDispatch
{
    class A
    {
        public virtual void M() { Console.WriteLine("A"); }
    }

    class B : A
    {
        //public override void M() { Console.WriteLine("B"); }
    }

    class C : B
    {
        public new virtual void M() { Console.WriteLine("C"); }
    }

    class FirstOverride
    {
        static void DoIt()
        {
            A a = new C();
            a.M();
            ((B)a).M();

            ((C)a).M();
        }
    }
}
