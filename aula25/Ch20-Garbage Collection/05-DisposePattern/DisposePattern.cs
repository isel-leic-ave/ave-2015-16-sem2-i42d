#define Version2
using System;
using System.IO;

public sealed class Program
{
#if Version1
   public static void Main() {
      // Create the bytes to write to the temporary file.
      Byte[] bytesToWrite = new Byte[] { 1, 2, 3, 4, 5 };

      // Create the temporary file.
      FileStream fs = new FileStream("Temp.dat", FileMode.Create);

      // Write the bytes to the temporary file.
      fs.Write(bytesToWrite, 0, bytesToWrite.Length);

      // Explicitly close the file when done writing to it.
      ((IDisposable) fs).Dispose();

      // Delete the temporary file.
      File.Delete("Temp.dat");  // This always works now
   }
#endif


#if Version2
    public static void Main()
    {
        // Create the bytes to write to the temporary file.
        Byte[] bytesToWrite = new Byte[] { 1, 2, 3, 4, 5 };

        // Create the temporary file.
        FileStream fs = new FileStream("Temp.dat", FileMode.Create);
        try
        {
            // Write the bytes to the temporary file.
            fs.Write(bytesToWrite, 0, bytesToWrite.Length);
        }
        finally
        {
            // Explicitly close the file when done writing to it.
            if (fs != null)
                ((IDisposable)fs).Dispose();
        }

        // Delete the temporary file.
        File.Delete("Temp.dat");  // This always works now.
    }
#endif
}
