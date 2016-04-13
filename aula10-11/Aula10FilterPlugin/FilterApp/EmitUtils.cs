using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace FilterApp
{
    class EmitUtils
    {
        public static ModuleBuilder CreateModuleBuilder(
            AssemblyName aName, 
            out AssemblyBuilder ab)
        {
            ab = AppDomain.CurrentDomain.DefineDynamicAssembly(
                    aName,
                    AssemblyBuilderAccess.RunAndSave);
            ModuleBuilder mb = ab.DefineDynamicModule(aName.Name, aName.Name + ".dll");
            return mb;
        }
    }
}
