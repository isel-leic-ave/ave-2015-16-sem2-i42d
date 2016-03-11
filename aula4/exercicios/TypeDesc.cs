using System;

class Employee { }

class Manager : Employee { }

class Ancestors {
    public static void Show(Type t) {
        Type ot = typeof(System.Object);
        Console.WriteLine(t);
        while (t.Equals(ot) == false) {
            t = t.BaseType;
            Console.WriteLine(t);
        }
    }
}

class Program
{
    public static void Main()
    {
        Ancestors.Show(new Manager().GetType());
    }
}