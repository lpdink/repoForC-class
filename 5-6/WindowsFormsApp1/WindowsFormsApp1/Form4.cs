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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text;
            int milk_num = int.Parse(textBox2.Text);
            int tea_num = int.Parse(textBox3.Text);
            int coffee_num = int.Parse(textBox4.Text);
            bool find = false;
            for (int i = Form1.OrderList.Count() - 1; i >= 0; i--)
            {
                if (Form1.OrderList[i].id == id)
                {
                    find = true;
                    Form1.OrderList[i].coffee_num = coffee_num;
                    Form1.OrderList[i].milk_num = milk_num;
                    Form1.OrderList[i].tea_num = tea_num;
                    Form1.OrderList[i].sumPrice = milk_num * Order.milk_price + coffee_num * Order.coffee_price + Order.tea_price * tea_num; ;
                }
                //else MessageBox.Show("修改失败：未找到订单");
            }
            if (!find) MessageBox.Show("修改失败：未找到订单");
            orderService.Modify(id,coffee_num,milk_num,tea_num);
        }
    }
    }

