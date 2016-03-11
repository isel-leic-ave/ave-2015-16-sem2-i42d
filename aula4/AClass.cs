namespace Aula4
{
    public class A
    {
        private int f1;

        public A(int f1)
        {
            this.f1 = f1;
        }

        public void m()
        {
            System.Console.WriteLine("@A ");
        }

        public static void Main()
        {
            B b = new B(30,10);

            A a = b;
            // calls A.m
            a.m();
            // call B.m
            b.m();

            // casting operations
            if (a is B)
            {

            }
            a = new C(10);
            // the next instruction throws InvalidCastException
            // B other1 = (B) a;
            B other2 = a as B;
            if (other2 == null)
            {
                System.Console.WriteLine("'a' is not a B");
            } else
            {
                System.Console.WriteLine("'a' is a B");
            }

            // inspect object Type
            TesteA(a);
        }

        public static void TesteA(A b) {
            System.Type t = b.GetType();
            System.Console.WriteLine(t);
        }
    }

    public class C : A
    {
        public C(int a) : base(a) { }

    }

    public interface I
    {
        void w();
    }

    public class B : A, I
    {
        private int b;
        public B(int b, int a) : base(a)
        {
            this.b = b;
        }
        public new void m()
        {
            System.Console.WriteLine("@B {0}", b);
            base.m();
        }
        public void w() { }
    }

}