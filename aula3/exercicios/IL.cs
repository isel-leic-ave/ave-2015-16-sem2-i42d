public class IL
{
    public static int Operations(int a)
    {
        int b = 2, c = 3;
        b += a + c;
        return b;
    }

    public static void Main()
    {
        System.Console.WriteLine(Operations(5));
    }

}