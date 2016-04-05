using System;

namespace DynamicAssemblyUsage
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing MyEmitDemo");

            Console.WriteLine(MyEmitDemo.Add(1.5, 2.5));

            MyEmitDemo demo = new MyEmitDemo();
            Console.WriteLine("Field is {0}", demo.ConcatField("the value"));
        }
    }
}
