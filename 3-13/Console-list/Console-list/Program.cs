/*为示例中的泛型链表类添加类似于List<T>类的
 * ForEach(Action<T> action)方法。通过调用这个方法打印链表元素，
 * 求最大值、最小值和求和（使用lambda表达式实现）*/


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericApplication
{

    // 链表节点
    public class Node<T>
    {
        public Node<T> Next { get; set; }
        public T Data { get; set; }

        public Node(T t)
        {
            Next = null;
            Data = t;
        }
    }

    //泛型链表类
    public class GenericList<T>
    {
        private Node<T> head;
        private Node<T> tail;

        public GenericList()
        {
            tail = head = null;
        }

        public Node<T> Head
        {
            get => head;
        }

        public void Add(T t)
        {
            Node<T> n = new Node<T>(t);
            if (tail == null)
            {
                head = tail = n;
            }
            else
            {
                tail.Next = n;
                tail = n;
            }
        }
        //action是一个需要传入一个泛型参数的方法.
        public  void ForEach(Action<T> action)
        {
            for(Node<T> x = head; x != null; x = x.Next)
            {
                action(x.Data);
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            /*
            void display()
            {

            }*/
            

            // 整型List
            GenericList<int> intlist = new GenericList<int>();
            for (int x = 0; x < 10; x++)
            {
                intlist.Add(x);
            }
            /*
            for (Node<int> node = intlist.Head;
                  node != null; node = node.Next)
            {
                Console.WriteLine(node.Data);
            }*/
            intlist.ForEach((x)=>Console.WriteLine(x));
            int maxnum = 0, minnum = 0, sunnum = 0;
            intlist.ForEach((x) => { if(x > maxnum )  maxnum = x; });
            intlist.ForEach((x) => { if (x < minnum) minnum = x; });
            intlist.ForEach((x) => { sunnum += x; });
            Console.WriteLine("max  " + maxnum+"  min  "+ minnum+"  sum:  "+sunnum);


            GenericList<string> strList = new GenericList<string>();
            for (int x = 0; x < 10; x++)
            {
                strList.Add("str" + x);
            }
            for (Node<string> node = strList.Head;
                    node != null; node = node.Next)
            {
                Console.WriteLine(node.Data);
            }


        }

    }
}