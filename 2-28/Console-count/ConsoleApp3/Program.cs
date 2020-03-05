using System;

namespace ConsoleApp3
{
    class Program
    {
        public static double getSum(double[] array,int n)
        {
            double thesum = 0;
            for(int i = 0; i < n; i++)
            {
                thesum += array[i];
            }
            return thesum;
        }
        public static double getMax(double[] array,int n)
        {
            double themax = array[0];
            for(int i = 0; i < n; i++)
            {
                if (themax < array[i]) themax = array[i];
            }
            return themax;
        }
        public static double getMin(double[] array,int n)
        {
            double themin = array[0];
            for(int i = 0; i < n; i++)
            {
                if (themin > array[i]) themin = array[i];

            }
            return themin;
        }
        public static double getAve(double[] array,int n)
        {
            double thesum = getSum(array, n);
            return thesum / n;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
