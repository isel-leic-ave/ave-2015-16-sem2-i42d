using System;

namespace _10_WeakReferences
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create a strong reference to a new object.
            Object o = new Object();
            // Create a strong reference to a short WeakReference object.
            // The WeakReference object tracks the Object's lifetime.
            WeakReference wr = new WeakReference(o);
            o = null; // Remove the strong reference to the object.
            o = wr.Target;
            if (o == null)
            {
                // A garbage collection occurred and Object's was reclaimed
            }
            else {
                // A garbage collection did not occur and I can successfully access
                // the object using o.
            }
        }
    }
}
