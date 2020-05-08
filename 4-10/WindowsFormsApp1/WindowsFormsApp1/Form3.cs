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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string id = textBox1.Text;
            bool find = false;
            for(int i = Form1.OrderList.Count() - 1; i >= 0; i--)
            {
                if (Form1.OrderList[i].id == id) { Form1.OrderList.Remove(Form1.OrderList[i]); find = true; }
                //else MessageBox.Show("删除失败：未找到订单");
            }
            if (!find) MessageBox.Show("删除失败：未找到订单");
        }
    }
}
