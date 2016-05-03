using System;

namespace DelegatesIntro
{
    public delegate void Display(int v);

    public class FirstDelegate
    {
        /*static void Main(string[] args)
        {
            Display d = new Display(Show1);

            int[] values = new int[] { 1, 2, 3, 4, 5 };

            Process(values, d);
        }*/

        public static void Process(int[] values, Display d)
        {
            throw new NotImplementedException();
        }

        public static void Show1(int v)
        {
            throw new NotImplementedException();
        }
    }
}
