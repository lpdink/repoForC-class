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
    public partial class Form1 : Form
    {
        public int cul = 0;
        public  double n3;
        //0代表加，1代表减，2代表*，3代表除，默认为1.
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            cul = 0;
            //MessageBox.Show("hello world!");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cul = 1;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            cul = 2;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            cul = 3;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                double n1 = double.Parse(textBox1.Text);
                double n2 = double.Parse(textBox2.Text);
                switch (cul)
                {
                    case 0:
                        n3 = n1 + n2;
                        MessageBox.Show(Convert.ToString(n3));
                        break;
                    case 1:
                        n3 = n1 - n2;
                        MessageBox.Show(Convert.ToString(n3));
                        break;
                    case 2:
                        n3 = n1 * n2;
                        MessageBox.Show(Convert.ToString(n3));
                        break;
                    case 3:
                        n3 = n1 / n2;
                        MessageBox.Show(Convert.ToString(n3));
                        break;

                }
            }
            catch
            {
                MessageBox.Show("input error");
            }



        }


    }
}
