using System;
using System.Threading;

public sealed class Program {
   public static void Main() {
      // Create a Timer object that knows to call our TimerCallback 
      // method once every 2000 milliseconds.
      Timer t = new Timer(TimerCallback, null, 0, 2000);

      // Wait for the user to hit <Enter>
      Console.ReadLine();

      // Refer to t after ReadLine (this gets optimized away)
      //t = null;

      // Refer to t after ReadLine (t will survive GCs until Dispose returns)
      //t.Dispose();
   }

   private static void TimerCallback(Object o) {
      // Display the date/time when this method got called.
      Console.WriteLine("In TimerCallback: " + DateTime.Now);

      // Force a garbage collection to occur for this demo.
      GC.Collect();
   }
}
