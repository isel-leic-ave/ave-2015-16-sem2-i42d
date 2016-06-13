#define Version2
using System;
using System.IO;


internal sealed class GCBeep
{
    // This is the Finalize method
    ~GCBeep()
    {
        // We're being finalized, beep.
        Console.Beep();
        Console.WriteLine(GC.GetGeneration(this));

        // If the AppDomain isn't unloading and if the process isn’t
        // shutting down, create a new object that will get finalized 
        // at the next collection.
        if (!Environment.HasShutdownStarted)
            new GCBeep();
    }
}

public sealed class Program
{
    public static void Main()
    {
        // Constructing a single GCBeep object causes a beep to
        // occur every time a garbage collection starts.
        new GCBeep();

        // Construct a lot of 100-byte objects.
        for (Int32 x = 0; x < 10000; x++)
        {
            Console.WriteLine(x);
            Byte[] b = new Byte[100];
            Byte[] b1 = new Byte[100];
            Byte[] b2 = new Byte[100];
            Byte[] b3 = new Byte[100];
        }
    }
}

internal sealed class TempFile
{
    private String m_filename = null;
    private FileStream m_fs;

#if Version1
   public TempFile(String filename) {
      // The following line might throw an exception.
      m_fs = new FileStream(filename, FileMode.Create);

      // Save the name of this file.
      m_filename = filename;
   }

   // This is the Finalize method
   ~TempFile() {
      // The right thing to do here is to test filename
      // against null because you can't be sure that 
      // filename was initialized in the constructor.
      if (m_filename != null)
         File.Delete(m_filename);
   }
#endif

#if Version2
    public TempFile(String filename)
    {
        try
        {
            // The following line might throw an exception.
            m_fs = new FileStream(filename, FileMode.Create);

            // Save the name of this file.
            m_filename = filename;
        }
        catch
        {
            // If anything goes wrong, tell the garbage collector
            // not to call the Finalize method. I’ll discuss
            // SuppressFinalize later in this chapter.
            GC.SuppressFinalize(this);

            // Let the caller know something failed.
            throw;
        }
    }

    // This is the Finalize method
    ~TempFile()
    {
        // No if statement is necessary now because this code
        // executes only if the constructor ran successfully.
        File.Delete(m_filename);
    }
#endif
}
