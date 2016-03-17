using System;
using System.Reflection;
using System.Diagnostics;

namespace Exercicio_Aula5
{
    class Program
    {
        public static Stopwatch watch = new Stopwatch();
        public static int CountToObject(Type t)
        {
            int counter = 0;
            Type ot = typeof(System.Object);
            //Console.WriteLine(t);
            while (!Object.ReferenceEquals(t, ot))
            {
                t = t.BaseType;
                ++counter;
                //Console.WriteLine(t);
            }
            return counter;
        }
        static void Main(string[] args)
        {
            AClass.s(); // called a first time to consume compilation time

            watch.Start();
            AClass.s();
            watch.Stop();
            Console.WriteLine("Call in {0} ticks: ", watch.ElapsedTicks);
            
            Assembly assembly = Assembly.LoadFrom(args[0]);
            Console.WriteLine(assembly.GetName());
            Module[] modules = assembly.GetModules();
            foreach (Module ml in modules)
            {
                Type[] types = ml.GetTypes();
                foreach (Type t in types)
                {
                    ShowTypesDesc(t);
                }
            }
        }


        private static void ShowFieldsDesc(FieldInfo[] fields)
        {
            foreach (FieldInfo fi in fields)
            {
                Console.WriteLine(" \t has field '{0}'",
                    fi.Name);
            }
        }

        private static void ShowMethodsDesc(MethodInfo[] methods)
        {
            foreach (MethodInfo m in methods)
            {
                Console.WriteLine("\t has {0} method '{1}'",
                    m.IsStatic ? "static" : "instance",
                    m.Name);
                // Invoke a specific method 
                // (just to demonstrate the use of Invoke and test performance)
                if (m.IsStatic && m.GetParameters().Length == 0)
                {
                    watch.Reset();
                    watch.Start();
                    object returnValue = m.Invoke(null, null);
                    watch.Stop();
                    Console.WriteLine("\t Invoked in {0} ticks", watch.ElapsedTicks);
                    Console.WriteLine("\t Result of method {0} is {1}",
                        m.Name,
                        returnValue == null ? "<null>" : returnValue);

                }
                else if (
                  !m.IsStatic
                  &&
                  m.GetParameters().Length == 1
                  &&
                  m.GetParameters()[0].ParameterType == typeof(string))
                {
                    object _this = Activator.CreateInstance(m.DeclaringType);
                    Console.WriteLine("\t Created an instance of {0}",
                        _this.GetType().Name);
                    watch.Reset();
                    watch.Start();
                    object returnValue = m.Invoke(_this, new object[] { "ola mundo" });
                    watch.Stop();
                    Console.WriteLine("\t Invoked in {0} ticks", watch.ElapsedTicks);
                    Console.WriteLine("\t Result of method {0} is {1}",
                        m.Name,
                        returnValue == null ? "<null>" : returnValue);
                }
            }
        }

        private static void ShowTypesDesc(Type t)
        {
            if (t.IsClass)
            {
                Console.WriteLine(
                    "Class '{0}' has distance {1} from class System.Object",
                    t.Name,
                    CountToObject(t));
            }
            else
            {
                Console.WriteLine(
                    "'{0}' is an interface",
                    t.Name);
            }

            BindingFlags intanceDeclared =
                BindingFlags.Public | BindingFlags.Static |
                BindingFlags.Instance | BindingFlags.DeclaredOnly;
            MethodInfo[] methods = t.GetMethods(intanceDeclared);
            ShowMethodsDesc(methods);

            FieldInfo[] fields = t.GetFields(
                BindingFlags.DeclaredOnly |
                BindingFlags.Instance |
                BindingFlags.Public |
                BindingFlags.NonPublic);
            ShowFieldsDesc(fields);
        }
    }
}
