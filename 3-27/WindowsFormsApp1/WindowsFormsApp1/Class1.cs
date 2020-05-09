using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{

    public class Order
    {
        //private double sumPrice_p;
        public const double milk_price = 12;
        public const double tea_price = 15;
        public const double coffee_price = 21;
        public string id { set; get; }
        public double customerId { set; get; }
        public double sumPrice { set; get; }
            //set { sumPrice_p = milk_num * milk_price+coffee_num*coffee_price+tea_price*tea_num; }
            //get { return sumPrice_p; } 
       // }
        public int milk_num { set; get; }
        public int coffee_num { set; get; }
        public int tea_num { set; get; }
        //public List<OrderItem> OrderItemList = new List<OrderItem>();
        public override string ToString()
        {

            return "id: " + id + "\ncustomerId: " + customerId + "\nsumPrice: " + sumPrice + "\n*********************************";
        }
        /*
        public Order(string id,int customerid,int sumPrice,int milk_num,int coffee_num,int tea_num)
        {
            this.id = id;
            this.customerId = customerid;
            this.sumPrice = sumPrice;
            this.milk_num = milk_num;
            this.coffee_num = coffee_num;
            this.tea_num = tea_num;

        }*/
    }



}
