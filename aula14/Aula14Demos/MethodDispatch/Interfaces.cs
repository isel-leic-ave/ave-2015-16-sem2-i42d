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

    public class Base : ICommon
    {
        void ICommon.DoIt() {  }
        public virtual void DoIt() { }
    }
}
