using System;

interface I { }

class Employee { }

class Manager : Employee { }

class Ancestors {
    public static void Show(Type t) {
        Type ot = typeof(System.Object);
        Console.WriteLine(t);
        while (!Object.ReferenceEquals(t,ot)) {
            t = t.BaseType;
            Console.WriteLine(t);
        }
    }
}

class Program
{
    public void aMEthod() { }

    public static void Main()
    {
        Ancestors.Show(new Manager().GetType());

        Manager m = new Manager();
        Employee e = new Employee();

        Type t1 = typeof(Manager);
        Type t2 = typeof(Employee);

        RuntimeTypeHandle rtth = t1.TypeHandle;
        Type tt = Type.GetTypeFromHandle(rtth);

        Console.WriteLine(t1.IsSubclassOf(t2));
        Console.WriteLine(t2.IsSubclassOf(t1));
        Console.WriteLine(t2.IsAssignableFrom(t1));
    }
}