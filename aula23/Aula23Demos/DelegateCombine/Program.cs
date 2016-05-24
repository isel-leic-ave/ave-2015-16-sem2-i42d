using System;

namespace DelegateCombine
{
   
    class Program
    {
        
        public static void M1(int a)
        {
            Console.WriteLine("M1 {0}", a);
        }
        public static void M2(int a)
        {
            Console.WriteLine("M2 {0}", a);
        }
        static void Main(string[] args)
        {
            Action<int> m = M1;
            Action<int> a = m;
            a += M2;
            //
            // <=> 
            // a = (Action<int>) Delegate.Combine(M1, M2);
            // <=>
            // a = (Action<int>) Delegate.Combine(
            //      new Action<int>(M1), 
            //      new Action<int>(M2));
            //
            a += M1;
            a(10);  // <=> a.Invoke(10);
            Console.WriteLine("****************");
            Delegate[] invocationList =
                a.GetInvocationList();
            foreach(Delegate d in invocationList)
            {
                ((Action<int>)d).Invoke(10);
            }

            a = (Action<int>)
                Delegate.Remove(
                    a,
                    new Action<int>(M1));
            // <=>
            a -= new Action<int>(M1);
            Console.WriteLine("****************");
            a(10);
        }
    }
}
