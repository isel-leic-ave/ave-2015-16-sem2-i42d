public class BClass
{
    public static void myStaticMethod() { }
}

public class AClass
{
    public int a;
    public AClass()
    {
        a = 10;
    }
    public void m(string word)
    {
        System.Console.WriteLine("@SomeClass.m(), {0} {1}", a, word);
    }
    public static void s()
    {
        System.Console.WriteLine("@SomeClass.s()");
    }
}