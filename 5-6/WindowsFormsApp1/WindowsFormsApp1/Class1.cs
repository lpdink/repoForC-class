using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

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
   
    public class orderService
    {
        static String connetStr = "server=127.0.0.1;port=3306;user=root;password=123456; database=order_test;";
        private static MySqlConnection net = new MySqlConnection(connetStr);

        public static void addOrder(string id,int coffee_num,int milk_num,int tea_num,double sumPrice,double customerId )
        {
            using (MySqlCommand cmd = new MySqlCommand("", net))
            {
                cmd.CommandText = "insert into order_test" +
                                "(order_id,customer_id,coffee_num,milk_num,tea_num,sum_price)" +
                                "VALUES" +
                                "(@order_id,@customer_id,@coffee_num,@milk_num,@tea_num,@sum_price);";
                cmd.Parameters.AddWithValue("@order_id", id);
                cmd.Parameters.AddWithValue("@coffee_num", coffee_num);
                cmd.Parameters.AddWithValue("@milk_num", milk_num);
                cmd.Parameters.AddWithValue("@tea_num", tea_num);
                cmd.Parameters.AddWithValue("@sum_price", sumPrice);
                cmd.Parameters.AddWithValue("@customer_id", customerId);
            }
        }

        public static void DeleteOrder(string id)
        {
            using (MySqlCommand cmd = new MySqlCommand("", net))
            {
                cmd.CommandText = "delete from order_test " +
                                  " where order_id=@order_id"
                    ;
                cmd.Parameters.AddWithValue("@order_id", id);
                cmd.Prepare();
                if (cmd.ExecuteNonQuery() == 0)
                    Console.WriteLine("no this id");
            }
        }

        public static void Modify(string id, int coffee_num,int milk_num,int tea_num)
        {
            using (MySqlCommand cmd = new MySqlCommand("", net))
            {
                cmd.CommandText = "update test_order " +
                                  "set coffee_num=@coffee_num,milk_num=@milk_num,tea_num=@tea_num" +
                                  "where order_id = @order_id"
                ;
                cmd.Parameters.AddWithValue("@order_id", id);
                cmd.Parameters.AddWithValue("@coffee_num", coffee_num);
                cmd.Parameters.AddWithValue("@milk_num", milk_num);
                cmd.Parameters.AddWithValue("@tea_num", tea_num);
                cmd.Prepare();
                if (cmd.ExecuteNonQuery() == 0)
                    Console.WriteLine("not fit!!!!");
            }
        }

    }


}
