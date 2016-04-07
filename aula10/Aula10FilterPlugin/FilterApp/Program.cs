using System;
using FiltersLibrary;
using MyFilters;
using System.Reflection;

namespace FilterApp
{
    class FilterAdapter : IFilter
    {
        private MethodInfo mi;
        public FilterAdapter(MethodInfo mi)
        {
            this.mi = mi;
        }
        public void Apply(int[] image)
        {
            mi.Invoke(null, new object[] { image });
        }
    }

    class Program
    {

        static void LoadFilterByMethodFromAssembly(Filters filters, string assembly)
        {
            Assembly loadedAsm = Assembly.LoadFrom(assembly);
            Type[] types = loadedAsm.GetTypes();
            foreach(Type t in types)
            {
                MethodInfo[] mis = t.GetMethods(BindingFlags.Static | BindingFlags.Public);
                foreach (MethodInfo mi in mis)
                {
                    ParameterInfo[] parameters = mi.GetParameters();
                    if(mi.ReturnType==typeof(void) && 
                        parameters.Length==1 &&
                        parameters[0].ParameterType==typeof(int[]))
                    {
                        filters.Add(new FilterAdapter(mi));
                    }
                }
            }
        }

        static void LoadFilterFromAssembly(Filters filters, string assembly)
        {
            Assembly loadedAsm = Assembly.LoadFrom(assembly);
            Type[] types = loadedAsm.GetTypes();
            Type typeIFilter = typeof(IFilter);
            foreach(Type t in types)
            {
                if (typeIFilter.IsAssignableFrom(t))
                {
                    object obj = Activator.CreateInstance(t);
                    filters.Add((IFilter)obj);
                }
            }
        }


        static void Main(string[] args)
        {
            Filters filters = new Filters();
            filters.Add(new FilterAdd1());
            filters.Add(new FilterMult2());

            LoadFilterFromAssembly(
                filters, 
                @"E:\work\ISEL\Ensino\AVE\1516v\ave-2015-16-sem2-i42d\aula10\Aula10FilterPlugin\MyFilters\bin\Debug\MyFilters.dll"
            );
            LoadFilterByMethodFromAssembly(
                filters,
                @"E:\work\ISEL\Ensino\AVE\1516v\ave-2015-16-sem2-i42d\aula10\Aula10FilterPlugin\MyFilters\bin\Debug\MyFilters.dll"
            );

            // example usage
            int[] image = { 1, 2, 3, 4, 5, 6 };
            filters.Apply(image);
            foreach(int i in image)
            {
                Console.WriteLine(i);
            }
        }
    }
}
