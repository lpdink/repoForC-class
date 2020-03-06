using System;

namespace testforClass
{
    public class BaseClass
    {
        private int a;
        public int A { get { return a; } }
        public BaseClass(int a)
        {
            this.a = a;
        }
    }
    class kid : BaseClass
    {
        private int t = BaseClass.A;
        kid() : base(BaseClass.A) { }
    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
