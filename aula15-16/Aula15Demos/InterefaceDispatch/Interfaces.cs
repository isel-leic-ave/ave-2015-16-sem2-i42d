using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MethodDispatch
{
    public interface ICommon
    {
        void DoIt();
    }

    public interface IOther
    {
        void DoIt();
    }

    public class Base : ICommon, IOther
    {
        void ICommon.DoIt() {  }
        void IOther.DoIt() { }
        public virtual void DoIt() { }
    }
    public class OtherBase : ICommon
    {
        public virtual void M1() { }
        public virtual void DoIt() { }
    }

    class Test
    {
        public void M()
        {
            Base b = new Base();
            b.DoIt();

            ICommon c = b;
            c.DoIt();

            IOther o = b;
            o.DoIt();
        }
    }
}
