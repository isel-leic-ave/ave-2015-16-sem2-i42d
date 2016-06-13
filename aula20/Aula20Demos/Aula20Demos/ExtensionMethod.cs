using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula20Demos
{

    class A<T>
    {
        public A() {
            int a = 1;
        }
    }

    static class IEnuemrableUtils
    {
        
    }

    static class ExtensionsMethods
    {
        public static IEnumerable<T> 
            WhereEx<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach (T t in source)
            {
                if (predicate(t))
                    yield return t;
            }
        }

        public static IEnumerable<T> SkipEx<T>(this IEnumerable<T> source, int n)
        {
            int c = 0;
            foreach (T t in source)
            {
                if (c < n)
                {
                    c++;
                    continue;
                }
                yield return t;
            }
        }

        public static T FirstEx<T>(this IEnumerable<T> source)
        {
            IEnumerator<T> it = source.GetEnumerator();
            it.MoveNext();
            return it.Current;
            /*
            return it.MoveNext() ? it.Current : null;
            */
        }

    }

    class Program
    {
        static IEnumerable<T> Where<T>(IEnumerable<T> source, Func<T, bool> predicate)
        {
            foreach(T t in source)
            {
                if (predicate(t))
                    yield return t;
            }
        }

        static IEnumerable<T> Skip<T>(IEnumerable<T> source, int n)
        {
            int c = 0;
            foreach(T t in source)
            {
                if (c < n)
                {
                    c++;
                    continue;
                }
                yield return t;
            }
        }

        static T First<T>(IEnumerable<T> source)
        {
            IEnumerator<T> it = source.GetEnumerator();
            it.MoveNext();
            return it.Current;
            /*
            return it.MoveNext() ? it.Current : null;
            */
        }

        public static void Main(String[] args)
        {
            List<Student> list = new List<Student>();
            list.Add(new Student { Name = "joao", Number = 1234, CurrAverage = 12.5 });
            list.Add(new Student { Name = "maria", Number = 1023, CurrAverage = 18.1 });
            list.Add(new Student { Name = "ana", Number = 1223, CurrAverage = 17.3 });
            list.Add(new Student { Name = "rui", Number = 1123, CurrAverage = 15.1 });
            list.Add(new Student { Name = "pedro", Number = 3222, CurrAverage = 11 });
            list.Add(new Student { Name = "rute", Number = 5543, CurrAverage = 12 });
            list.Add(new Student { Name = "gil", Number = 4332, CurrAverage = 16 });
            list.Add(new Student { Name = "antonio", Number = 9282, CurrAverage = 10 });

            // where X = ?
            // skip 3
            // first
            IEnumerable<Student> seq = 
                Where(list, s => { return s.Number > 1200; });
            seq = Skip(seq, 3);
            Student st = First(seq);
            Console.WriteLine(st);

            Student sd = list.WhereEx(s => { return s.Number > 1200; })
                             .SkipEx(3)
                             .FirstEx();

            IEnumerable<String> students =
                 list.Where(s => s.CurrAverage > 12)
                .Select(s => s.Name);

            IEnumerable<String> studentsNames =
                from s in list
                where s.CurrAverage > 12
                select s.Name;

        }
    }
}
