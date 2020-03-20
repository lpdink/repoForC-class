using System;
using System.Collections.Generic;
using System.Linq;
/*写一个订单管理的控制台程序，能够实现添加订单、删除订单、修改订单、查询订单
 * （按照订单号、商品名称、客户等字段进行查询）功能。
提示：主要的类有Order（订单）、OrderItem（订单明细项），OrderService（订单服务），
订单数据可以保存在OrderService中一个List中。在Program里面可以调用OrderService的方法完成各种订单操作。
要求：
（1）使用LINQ语言实现各种查询功能，查询结果按照订单总金额排序返回。
（2）在订单删除、修改失败时，能够产生异常并显示给客户错误信息。
（3）作业的订单和订单明细类需要重写Equals方法，确保添加的订单不重复，每个订单的订单明细不重复。
（4）订单、订单明细、客户、货物等类添加ToString方法，用来显示订单信息。
（5）OrderService提供排序方法对保存的订单进行排序。默认按照订单号排序，也可以使用Lambda表达式进行自定义排序。
*/

/*
 构思这样的场景：不预先设定商品名称，他需要填写一些信息，之后他的订单会被保存。
 他提交订单后，可以查看当前的订单。可以选择根据订单号，来删除已有订单，或者修改已有订单。
 订单包括：id-num-SM(SumMoney)
 订单明细包括：id name num PM(per money) SM CN(customerName)
 订单存储在订单服务的订单数组中，以对象的方式存储。
 */
namespace Console_OrderService
{
    class Milk
    {
        public const double price=12;
        public const string name = "milk"; 
    }
    class Tea
    {
        public const double price = 15;
        public const string name = "tea";
    }
    class Coffee
    {
        public const double price = 21;
        public const string name = "coffee";
    }
    class Order
    {
        public string id { set; get; }
        public double customerId { set; get; }
        public double sumPrice { set; get; }
        public List<OrderItem> OrderItemList = new  List<OrderItem>();
        public override string ToString()
        {
            
            return "id: "+id+"\ncustomerId: "+customerId+"\nsumPrice: "+sumPrice+"\n*********************************";
        }
    }
    class OrderItem
    {
        public string objectName { set; get; }//商品名
        public int objectNum { set; get; }//数量
        public double objectPrice { set; get; }//单价
        public double perSumPrice { set; get; }//单一商品总价
        public override string ToString()
        {
            return "-Name: " + objectName + "\n-Num: " + objectNum + "\n-perPrice: " + objectPrice +
                "\n-sumPrice: " + perSumPrice + "\n******************************";
        }
    }
    class OrderService
    {
        public static List<Order> OrderList = new List<Order>();
        public static void addOrder()
        {

            Order order = new Order();
            OrderList.Add(order);
            Console.WriteLine("please input the customerId");
            double customerId =double.Parse( Console.ReadLine());
            order.customerId = customerId;
            while (true)
            {//输入y以继续，输入n以退出
                Console.WriteLine("add order? input 'N' to exit, 'Y' to continue  ");
                string yOrN =Console.ReadLine();
                if (yOrN == "N"||yOrN=="n")
                {
                    break;
                }
                else
                {
                    int times = order.OrderItemList.Count();
                    Console.WriteLine("what do you want to buy ? \n-milk\n-coffee\n-tea  ");
                    string objectName = Console.ReadLine();
                    Console.WriteLine("how many do you need ? \n-int  ");
                    int objectNum = int.Parse(Console.ReadLine());
                    double objectPrice;
                    double perSumPrice;
                    switch (objectName)
                    {
                        case Milk.name:
                            objectPrice = Milk.price;
                            perSumPrice = objectPrice * objectNum;
                            //Console.WriteLine("-----1");
                            break;
                        case Coffee.name:
                            objectPrice = Coffee.price;
                            perSumPrice = objectPrice * objectNum;
                            break;
                        case Tea.name:
                            objectPrice = Tea.price;
                            perSumPrice = objectPrice * objectNum;
                            break;
                        default:
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine("Error input: please check the object list and try again  ");
                            continue;
                    }
                    //Console.WriteLine(times);
                    OrderItem orderItem = new OrderItem();
                    order.OrderItemList.Add(orderItem);
                    order.OrderItemList[times].objectName = objectName;
                    order.OrderItemList[times].objectNum = objectNum;
                    order.OrderItemList[times].objectPrice = objectPrice;
                    order.OrderItemList[times].perSumPrice = perSumPrice;
                    //Console.WriteLine("this is count");
                    //Console.WriteLine(OrderList.Count());
                    //viewOrder();
                    //Console.WriteLine(order.ToString());
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(orderItem.ToString());
                }

                
            }
            DateTime date = DateTime.Now;
            order.sumPrice = 0;
            foreach( OrderItem item in order.OrderItemList)
            {
                order.sumPrice += item.perSumPrice;
            }
            order.id = date.ToString()+" "+order.customerId;

        }
        public static void changeOrder()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("please input the orderId you want to change  ");
            string orderId = Console.ReadLine();
            var orders = from order in OrderList
                         where order.id == orderId
                         select order;
            
            foreach( Order order in orders){
                //Console.WriteLine("which item do you want to change ?  ");
                //showOrderItem()
                //string changeItem = Console.ReadLine();
                foreach (OrderItem item in order.OrderItemList) {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("which item do you want to change ?  ");
                    //showOrderItem()
                    Console.WriteLine(item.ToString());
                    string changeItem = Console.ReadLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("how many do you want to change to ?  ");
                    int newNum = int.Parse(Console.ReadLine());
                    if (item.objectName == changeItem)
                    {
                        order.sumPrice = order.sumPrice - item.perSumPrice + newNum * item.objectPrice;
                        item.objectNum = newNum;
                        item.perSumPrice = newNum * item.objectPrice;
                    }
                }
            }
            viewOrder();
        }
        public static void deleteOrder()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("please input the orderId you want to delete  ");
            string orderId = Console.ReadLine();
            for(int i = OrderList.Count()-1; i >= 0; i--)
            {
                if (OrderList[i].id == orderId) OrderList.Remove(OrderList[i]);
            }
            //showOrder()
            viewOrder();
        }
        public static void viewOrder()
        {
            //Console.WriteLine("-----2");
            //Console.WriteLine(OrderList.Count());
            foreach(Order order in OrderList)
            {
                //Console.WriteLine("-----4");
                string myout = order.ToString();
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(order.ToString());
                //Console.WriteLine("--------3");
                //Console.WriteLine("myout:  " + myout);
                foreach(OrderItem orderItem in order.OrderItemList)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(orderItem.ToString());
                }
            }
        }
       
    }

    class Program
    {
        static void Main(string[] args)
        {
            Order[] OrderList = new Order[100];
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("what do you want ? input \n-1 for add, \n-2 for delete" +
                    "\n-3 for change,\n-4 for view");
                Console.WriteLine("input 'q' to exit system");
                
                string x =Console.ReadLine();
                if (x == "q") break;
                //这里需要修改为input
                switch (int.Parse(x)){
                    case 1:
                        OrderService.addOrder();
                        break;
                    case 2:
                        OrderService.deleteOrder();
                        break;
                    case 3:
                        OrderService.changeOrder();
                        break;
                    case 4:
                        OrderService.viewOrder();
                        break;
                }
                    
                  
            }
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.WriteLine("Thanks for your using.\n Have a good day!");
        }
    }
}
