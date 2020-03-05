using System;

namespace ConsoleApp4
{
    class Program
    {
        public static void solution()
        {
            //初始化一个存储1-100的整数数组；
            int[] array=new int[100];
            for(int k = 1; k <= 100; k++)
            {
                array[k-1] = k;
            }
            //对于每个小于50的数，作为被除数
            int i = 2;
            while (i <= 10)
            {
                for(int r = 0; r < 100; r++)
                {
                    //当数组中元素被（被除数）整除，且不为自身，将数组元素修改为0，表示“抛弃”
                    if (array[r] % i==0&&array[r]!=i)
                    {
                        array[r] = 0;
                    }
                }
                i++;
            }
            for(int m = 1; m < 100; m++)
            {
                if (array[m] != 0)
                {
                    Console.WriteLine(array[m]);
                }
            }
        }
        static void Main(string[] args)
        {
           // Console.WriteLine("Hello World!");
            solution();
        }
    }
}
