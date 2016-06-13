using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Events
{
    interface Observer
    {
        void OnSomeAction(int code);
    }

    class Observable
    {

        private Dictionary<String, Action<int>> supportingDelegates =
            new Dictionary<String, Action<int>>();
        
        public event Action<int> OnOperation1
        {
            add
            {
             
            }
            remove
            {

            }
        }
        public event Action<int> OnOperation2
        {
            add
            {

            }
            remove
            {

            }
        }
        public event Action<int> OnOperation3
        {
            add
            {

            }
            remove
            {

            }
        }
        public event Action<int> OnOperation4
        {
            add
            {

            }
            remove
            {

            }
        }
        public event Action<int> OnOperation5
        {
            add
            {

            }
            remove
            {

            }
        }

        public void DoOperation(int code)
        {
            /* ... faz a operação ... */
            /* ... */
            /* e notifica os listeners */
            if (OnOperation != null)
            {
                OnOperation(code);
                /* <=>
                OnOperation.Invoke(code);
                */
            }
        }
    }

    class Program
    {

        static void Main(string[] args)
        {

        }

    }
}
