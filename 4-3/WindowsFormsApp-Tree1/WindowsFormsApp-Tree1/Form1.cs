using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp_Tree1
{
    public partial class Form1 : Form
    {
        int n=10;
        double length =100 ;
        double th1 = 30 * Math.PI / 180;
        double th2 = 20 * Math.PI / 180;
        double per1 = 0.6;
        double per2 = 0.7;
        string color="green";

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (graphics == null) graphics = this.CreateGraphics();
            drawCayleyTree(n,200, 310, length,- Math.PI / 2);
        }

        private Graphics graphics;
        
        
        void drawCayleyTree(int n,double x0,double y0,double leng,double th)
        {
            if (n == 0) return;

            double x1 = x0 + leng * Math.Cos(th);
            double y1 = y0 + leng * Math.Sin(th);

            drawLine(x0, y0, x1, y1,color);

            drawCayleyTree(n - 1, x1, y1, per1 * leng, th + th1);
            drawCayleyTree(n - 1, x1, y1, per2 * leng, th - th2);

        }
        void drawLine(double x0,double y0,double x1,double y1,string color)
        {
            switch (color)
            {
                case "green":
                    graphics.DrawLine(Pens.Green, (int)x0, (int)y0, (int)x1, (int)y1);
                    break;
                case "red":
                    graphics.DrawLine(Pens.Red, (int)x0, (int)y0, (int)x1, (int)y1);
                    break;
                case "black":
                    graphics.DrawLine(Pens.Black, (int)x0, (int)y0, (int)x1, (int)y1);
                    break;
                default:
                    graphics.DrawLine(Pens.Blue, (int)x0, (int)y0, (int)x1, (int)y1);
                    break;

            }
            //graphics.DrawLine(Pens.Green, (int)x0, (int)y0, (int)x1, (int)y1);
            
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int.TryParse(textBox1.Text,out n);
            //MessageBox.Show(this.Text.ToString());
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            double.TryParse(textBox2.Text,out length);
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            double.TryParse(textBox3.Text,out per1);
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            double.TryParse(textBox4.Text,out per2);
        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            double.TryParse(textBox7.Text,out th2);
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            double.TryParse(textBox6.Text,out th1);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            color = comboBox1.SelectedItem.ToString();
        }
    }
}
