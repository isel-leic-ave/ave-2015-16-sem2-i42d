using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiltersLibrary
{
    public class Filters
    {
        private LinkedList<IFilter> filters = new LinkedList<IFilter>();

        public void Add(IFilter f)
        {
            filters.AddLast(f);
        }

        public void Apply(int[] image)
        {
            foreach(IFilter f in filters)
            {
                f.Apply(image);
            }
        }

    }
}
