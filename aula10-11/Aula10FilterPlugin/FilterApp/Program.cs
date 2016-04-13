using System;
using FiltersLibrary;
using MyFilters;
using System.Reflection;
using System.Reflection.Emit;
using System.Diagnostics;

namespace FilterApp
{
    class FilterAdapter : IFilter
    {
        private MethodInfo mi;
        private object obj;
        public FilterAdapter(object obj, MethodInfo mi)
        {
            this.mi = mi;
            this.obj = obj;
        }
        public void Apply(int[] image)
        {
            mi.Invoke(obj, new object[] { image });
        }
    }

    class Program
    {
        private const int ITERATIONS = 100;
        private const int WARMUP = 5;

        static void LoadFiltersByEmittingCode(Filters filters, string assembly)
        {
            Assembly loadedAsm = Assembly.LoadFrom(assembly);
            Type[] types = loadedAsm.GetTypes();
            foreach (Type t in types)
            {
                MethodInfo[] mis = t.GetMethods(
                    BindingFlags.Static |                   
                    BindingFlags.Public);
                foreach (MethodInfo mi in mis)
                {
                    ParameterInfo[] parameters = mi.GetParameters();
                    if (mi.ReturnType == typeof(void) &&
                        parameters.Length == 1 &&
                        parameters[0].ParameterType == typeof(int[]))
                    {
                        Console.WriteLine("Emitting class for {0}::{1}", mi.DeclaringType, mi.Name);
                        IFilter f = CreateFilterWithMethodInfo(mi);
                        filters.Add(f);
                    }
                }
            }
        }

        private static IFilter CreateFilterWithMethodInfo(MethodInfo mi)
        {
            AssemblyBuilder abuilder;
            AssemblyName name = new AssemblyName("Assembly" + mi.Name);
            ModuleBuilder mb = EmitUtils.CreateModuleBuilder(
                name,
                out abuilder);

            TypeBuilder tb = mb.DefineType(mi.Name + "Filter");
            tb.AddInterfaceImplementation(typeof(IFilter));

            MethodBuilder mtb = tb.DefineMethod("Apply",
                MethodAttributes.Public | MethodAttributes.Virtual,
                typeof(void),
                new Type[] { typeof(int[]) });
            ILGenerator il = mtb.GetILGenerator();
            //il.EmitWriteLine("I'm at Apply for " + mi.Name);
            il.Emit(OpCodes.Ldarg_1);
            il.Emit(OpCodes.Call, mi);
            il.Emit(OpCodes.Ret);

            Type type = tb.CreateType();
            abuilder.Save(name + ".dll");
            object obj = Activator.CreateInstance(type);
            return (IFilter)obj;
        }

        static void LoadFilterByMethodFromAssembly(Filters filters, string assembly)
        {
            Assembly loadedAsm = Assembly.LoadFrom(assembly);
            Type[] types = loadedAsm.GetTypes();
            foreach(Type t in types)
            {
                object obj = null;
                MethodInfo[] mis = t.GetMethods(
                    BindingFlags.Static |
                    BindingFlags.Instance |
                    BindingFlags.Public);
                foreach (MethodInfo mi in mis)
                {
                    ParameterInfo[] parameters = mi.GetParameters();
                    if(mi.ReturnType==typeof(void) && 
                        parameters.Length==1 &&
                        parameters[0].ParameterType==typeof(int[]))
                    {
                        Console.WriteLine("Adding adapter for {0}::{1}", mi.DeclaringType, mi.Name);
                        if (!mi.IsStatic && obj==null)
                        {
                            obj = Activator.CreateInstance(t);
                        }
                        filters.Add(new FilterAdapter(obj, mi));
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
            Filters regularFilters = new Filters();
            regularFilters.Add(new FilterMult2());
            regularFilters.Add(new FilterMult2());
            regularFilters.Add(new FilterMult2());
            regularFilters.Add(new FilterMult2());

            Filters adapterFilters = new Filters();
            LoadFilterByMethodFromAssembly(
                adapterFilters,
                @"d:\assemblies\FiltersLikeMethods.dll"
            );

            Filters emittedFilters = new Filters();
            LoadFiltersByEmittingCode(
                emittedFilters,
                @"d:\assemblies\FiltersLikeMethods.dll"
            );

            //
            // an example of a performance test methodology
            //

            // warmup to ensure compilation to native code
            warmup(regularFilters, WARMUP);
            warmup(adapterFilters, WARMUP);
            warmup(emittedFilters, WARMUP);

            // run multiple times and collect average time
            benchmark(regularFilters, "regular", ITERATIONS);
            benchmark(adapterFilters, "adatper", ITERATIONS);
            benchmark(emittedFilters, "emitted", ITERATIONS);
            
        }

        private static void benchmark(Filters filters, String type, int numberOfIterations)
        {
            Console.WriteLine("------------------------------------");
            int[] mockImage = new int[] { 1, 2, 3, 4, 5, 6 };
            Console.WriteLine("Calling {0} {1} filters took {3} Ticks (an average of {2} calls to Filters.Apply)",
                filters.Size(),
                type,
                numberOfIterations,
                measureTime(filters, mockImage, numberOfIterations));
        }

        private static double measureTime(Filters regularFilters, int[] values, int times)
        {
            Stopwatch watch = new Stopwatch(); // long start = DateTime.Now.Ticks;
            watch.Restart();
            for (int i = 0; i < times; ++i)
            {
                regularFilters.Apply(values);
            }
            watch.Stop();
            return watch.ElapsedTicks/(double)times;
            //return DateTime.Now.Ticks - start;
        }

        private static void warmup(Filters filters, int warmupRounds)
        {
            int[] image = new int[] { 1, 2, 3, 4, 5, 6 };
            for (int i = 0; i < warmupRounds; ++i)
            {
                filters.Apply(image);
            }
        }
    }
}
