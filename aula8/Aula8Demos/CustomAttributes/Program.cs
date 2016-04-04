using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomAttributes
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple =true)]
    public class TesterAttribute : Attribute
    {
        //public TesterAttribute() { }
        public TesterAttribute(String dt) { 
            // TODO: use some criterion to validate 'dt'...
            this.Date = dt;
        }
        public String Name;
        public String Date;
    }

    class Program
    {
        [Tester("1-1-2016", Name = "Jose")]
        [Tester("5-1-2016", Name ="Joao")]
        static public void M()
        {

        }

        static void Main(string[] args)
        {
            Type t = typeof(Program);
            Console.WriteLine(
                Attribute.IsDefined(t.GetMethod("M"), 
                                    typeof(TesterAttribute)));
            Attribute[] attrs = Attribute.GetCustomAttributes(t.GetMethod("M"));
            for (int i=0; i<attrs.Length; ++i)
            {
                TesterAttribute testAttr = (TesterAttribute)attrs[i];
                Console.WriteLine("Tester Name = {0}, Date of test = {1}",
                    testAttr.Name,
                    testAttr.Date);
                testAttr.Name = "Manuel";
            }
        }
    }
}
