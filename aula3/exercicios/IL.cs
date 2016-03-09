public class IL
{
    public static int Operations()
    {
        int a = 1, b = 2, c = 3;
        a += b + c;
        return a;
    }

    public static void Main()
    {
        System.Console.WriteLine(Operations());
    }

}