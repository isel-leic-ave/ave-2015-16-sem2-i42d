using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace EmitDemo
{
    class Program
    {
        static void Main(string[] args)
        {
            AssemblyName aName = new AssemblyName("DynamicAssemblyExample");
            AssemblyBuilder ab =
                AppDomain.CurrentDomain.DefineDynamicAssembly(
                    aName,
                    AssemblyBuilderAccess.RunAndSave);

            // For a single-module assembly, the module name is usually
            // the assembly name plus an extension.
            ModuleBuilder mb =
                ab.DefineDynamicModule(aName.Name, aName.Name + ".dll");

            // define class
            TypeBuilder tb = mb.DefineType("MyEmitDemo", TypeAttributes.Public);

            // define field inside type defined by 'tb'
            FieldBuilder fb = tb.DefineField("myField", typeof(string), FieldAttributes.Private);

            // define methods inside type defined by 'tb'
            MethodBuilder addMth = tb.DefineMethod(
                "Add",
                MethodAttributes.Public | MethodAttributes.Static,
                typeof(double),
                new Type[] { typeof(double), typeof(double) }
            );

            ILGenerator addMthIL = addMth.GetILGenerator();
            addMthIL.Emit(OpCodes.Ldarg_0);
            addMthIL.Emit(OpCodes.Ldarg_1);
            addMthIL.Emit(OpCodes.Add);
            addMthIL.Emit(OpCodes.Ret);

            MethodBuilder concatMth = tb.DefineMethod(
                "ConcatField",
                MethodAttributes.Public,
                typeof(string),
                new Type[] { typeof(string) }
            );

            ILGenerator concatMthIL = concatMth.GetILGenerator();
            concatMthIL.Emit(OpCodes.Ldstr, "For now this is just a mock body");
            concatMthIL.Emit(OpCodes.Call, typeof(Console).GetMethod("WriteLine", new Type[] { typeof(String) }));
            concatMthIL.Emit(OpCodes.Ldstr, "MockValue");
            concatMthIL.Emit(OpCodes.Ret);

            // Finish the type.
            Type t = tb.CreateType();

            object demo = Activator.CreateInstance(t);


            // The following line saves the single-module assembly. You can now
            // type "ildasm DynamicAssemblyExample.dll" at the command prompt, and 
            // examine the assembly. You can also write a program that has
            // a reference to the assembly, and use the MyEmitDemo type.
            // 
            ab.Save(aName.Name + ".dll");
        }
    }
}
