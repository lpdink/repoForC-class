/*使用事件机制，模拟实现一个闹钟功能。
 * 闹钟可以有嘀嗒（Tick）事件和响铃（Alarm）两个事件。在闹钟走时时或者响铃时，在控制台显示提示信息。*/

using System;

namespace Console_clock
{
    public delegate void clockHandler(object sender, ClockEventArgs args);
    public class ClockEventArgs { }
    public class Clock
    {
        public int H { set; get; }
        public int M { set; get; }
        public int S { set; get; }
        //走时
        public event clockHandler TimeUp;
        //响铃
        //public event clockHandler ClockRing;
        //显示时间
        public void displayTime()
        {
            ClockEventArgs args = new ClockEventArgs();
            Console.WriteLine(this.H);
            Console.WriteLine(this.M);
            Console.WriteLine(this.S);
            TimeUp(this, args);
        }
        //设置时间
        public void setTime(int h, int m, int s)
        {

            H = h;
            M = m;
            S = s;
            
        }
       

    }
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("hello!");
            Clock clock1 = new Clock();
            void getTime(object sender,ClockEventArgs args)
            {
                Console.WriteLine("getTime");
            }
            clock1.setTime(10,10,10);
            clock1.TimeUp += getTime;
            clock1.displayTime();
        }
    }
        
            
} 


    

