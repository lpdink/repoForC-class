using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    //public static List<Order> OrderList = new List<Order>();
    public partial class Form2 : Form
    {
        //public static List<Order> OrderList = new List<Order>();
        public Form2()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            Order order = new Order();
            //Form1.OrderList.Add(order);
            double customerId = double.Parse(custom_box.Text);
            order.customerId = customerId;

            DateTime date = DateTime.Now;
            order.id = date.ToString() + "  " + customerId;

            order.coffee_num = int.Parse(coffee_box.Text);
            order.milk_num = int.Parse(milk_box.Text);
            order.tea_num = int.Parse(tea_box.Text);

            order.sumPrice= order.milk_num * Order.milk_price + order.coffee_num * Order.coffee_price + Order.tea_price * order.tea_num;
            Form1.OrderList.Add(order);

        }
    }
}
