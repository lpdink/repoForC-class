using System;

namespace ConsoleApp2
{
    class Program
    {
       /* public static bool judge(int n)
        {
            bool num = false;
            int i;
            for (i = 2; i <= n / 2; i++)
            {
                if (n % i == 0)
                {
                    num = true;
                    return num;
                }
            }
            return num;
        }
        public static void solution(int n)
        {
            Console.WriteLine("begin");
            int i=2;
            while (i <= n)
            {
                if ((n % i == 0))
                {
                    Console.WriteLine(i);
                    //n = n / i;
                    //continue;
                }
                i++;
            }
        }*/
        public static void solution(int n)
        {
            if (n <= 0)
            {
                Console.WriteLine("input must be +");
                return;
            }
            int i = 2;
            while (i <= n)
            {
                if (n % i == 0)
                {
                    Console.WriteLine(i);
                    n = n / i;
                    continue;
                }
                else
                {
                    i++;
                }
            }
        }
        static void Main(string[] args)
        {
            try
            {
                int n = int.Parse(Console.ReadLine());
                solution(n);
            }
            catch
            {
                Console.WriteLine("input error!");
            }
        }
    }
}
