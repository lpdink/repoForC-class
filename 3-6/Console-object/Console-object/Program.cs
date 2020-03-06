using System;


namespace Console_object
{
    abstract class AbstractShape
    {
        public abstract double S { get; }
    }
    class Rectangle : AbstractShape
    {
        private double length;
        private double width;
        public override double S
        {
            get => length * width;
        }
        public double Length
        {
            get { return length; }
            set
            {
                if (value >= 0) { length = value; }
                else { Console.WriteLine("input error for length! it must be +"); }

            }
        }
        public double Width
        {
            get { return width; }
            set
            {
                if (value >= 0) { width = value; }
                else { Console.WriteLine("input error for width! it must be +"); }

            }
        }
        public Rectangle(double length,double width)
        {
            this.Length = length;
            this.Width = width;
        }
    }
    class Square : AbstractShape
     {
        private double length;
        public override double S
        {
            get => length * length;
        }
        public double Length
        {
            get { return length; }
            set
            {
                if (value >= 0) { length = value; }
                else { Console.WriteLine("input error for length! it must be +"); }

            }
        }
        public Square(double length)
        {
            this.Length = length;
        }
    }
    class Triangle : AbstractShape
    {
        private double a, b, c,p;
        public override double S { get => Math.Sqrt((0.5*(a+b+c) * (0.5*(a+b+c) - a) * (0.5 * (a + b + c) - b) * (0.5 * (a + b + c) - c))); }
        public double A { get { return a; } }
        public double B { get { return b; } }
        public double C { get { return c; } }
        public Triangle(double a,double b,double c)
        {
            if (a + b > c && a + c > b && b + c > a)
            {
                this.a = a;
                this.b = b;
                this.c = c;
                p = 0.5 * (a + b + c);
            }
            else
            {
                this.a = 0;
                this.b = 0;
                this.c = 0;
                Console.WriteLine("triangle create error:wrong a/b/c");
            }

        }
    }
    class ShapFactory
    {
        public static AbstractShape createShape()
        {
            Random ra=new Random();
            int n = ra.Next(0, 3);
            
            
         if(n==0){ Rectangle rectangle = new Rectangle(ra.Next(1,10),ra.Next(1,10));  return rectangle; }
         if(n==1){ Square square = new Square(ra.Next(1,10));return square; }
         else{ Triangle triangle = new Triangle(ra.Next(1,10), ra.Next(1,10), ra.Next(1,10));return triangle;  }
        }
            
    }
    class Program
    {
        static void Main(string[] args)
        {
            double sSum=0;
            for(int i = 0; i < 10; i++)
            {
                AbstractShape shape = ShapFactory.createShape();
                sSum += shape.S;
                Console.WriteLine(sSum);
            }
            Console.WriteLine(sSum);
            //Console.WriteLine("Hello World!");
        }
    }
}
