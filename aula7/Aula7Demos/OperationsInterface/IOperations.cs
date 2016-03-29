using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationsInterface
{
    public class OperationAttribute : Attribute
    {

    }
    public interface IOperations
    {
        void Apply(float[] values);
    }
}
