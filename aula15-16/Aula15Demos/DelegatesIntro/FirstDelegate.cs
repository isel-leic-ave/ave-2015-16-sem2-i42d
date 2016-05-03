using System;

namespace DelegatesIntro
{
    public delegate void Display(int v);

    class FancyShow
    {
        public String formatPrefix { get; set; }

        public void ShowWithTime(int i)
        {
            Console.WriteLine("{0}{1} {2}", formatPrefix, DateTime.Now, i);
            formatPrefix = "*-*-*-*-*-*";
        }
    }

    class FirstDelegate
    {
        
        public static Display M()
        {
            return new Display(FirstDelegate.Show1);
        }
        
        static void Main(string[] args)
        {
            Display d = new Display(Show1);

            FancyShow fs = new FancyShow();
            fs.formatPrefix = "****";
            Display d1 = new Display(fs.ShowWithTime);

            fs = new FancyShow();
            fs.formatPrefix = "####";
            Display d2 = new Display(fs.ShowWithTime);

            int[] values = new int[] { 1, 2, 3, 4, 5 };

            //DisplayAll(values, d);
            DisplayAll(values, d1);
            DisplayAll(values, d1);
            //DisplayAll(values, d2);
        }
       

        public static void DisplayAll(int[] values, Display d)
        {
            foreach(int v in values)
            {
                d(v); // <=> d.Invoke(v);
            }
        }

        private static void Show1(int v)
        {
            Console.WriteLine(v);
        }
    }
}
