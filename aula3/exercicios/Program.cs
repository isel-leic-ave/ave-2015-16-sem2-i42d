namespace AVEMain
{

    public class Program
    {
        public static void M()
        {
            AVELibrary.A a = new AVELibrary.A();
            a.W(null);
        }

        public static void Main()
        {
            System.Console.WriteLine("*1* @ before Program.M");
            System.Console.ReadLine();
            M();
            System.Console.WriteLine("*2* @ after Program.M");
            System.Console.ReadLine();
        }
    }
}