using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyFilters
{ 
    public class FilterAdd1 : IFilter
    {
        public void Apply(int[] image)
        {
            image[0] = 1;
        }
    }

    public class FilterMult2 : IFilter
    {
        public void Apply(int[] image)
        {
            image[0] = 3;
        }
    }

}
