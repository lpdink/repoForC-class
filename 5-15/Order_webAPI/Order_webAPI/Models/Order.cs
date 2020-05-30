using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Order_webAPI.Models
{
    public class Order
    {
        public long Id { get; set; }
        public string customerId { get; set; }

        public int coffee_num { get; set; }
        public int milk_num { set; get; }
        public int tea_num { set; get; }
        public double sum_price { set; get; }
    }
}
