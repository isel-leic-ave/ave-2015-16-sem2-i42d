using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomAttributes
{
    public class TesterAttribute : Attribute
    {
        //public TesterAttribute() { }
        public TesterAttribute(String dt) { // only primitive, strings and Type
            // TODO: use some criterion to validate 'dt'...
            this.dt = dt;
        }
        public String Name;
        private String dt;
    }

    class Program
    {
        [Tester("1-1-2016", Name ="Jose")]
        static void M()
        {

        }

        static void Main(string[] args)
        {
            
        }
    }
}
