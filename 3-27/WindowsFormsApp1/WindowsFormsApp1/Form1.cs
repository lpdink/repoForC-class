using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public static List<Order> OrderList = new List<Order>();
        public string KeyWord { get; set; }
        //XmlSerializer xmlser = new XmlSerializer(typeof(List<Order>));
        public Form1()
        {
            InitializeComponent();
            orderBindingSource.DataSource = typeof(List<Order>);
            orderBindingSource.DataSource = OrderList;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
            orderBindingSource.DataSource = typeof(List<Order>);
            orderBindingSource.DataSource = OrderList;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            orderBindingSource.DataSource = typeof(List<Order>);
            orderBindingSource.DataSource = OrderList;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.ShowDialog();
            orderBindingSource.DataSource = typeof(List<Order>);
            orderBindingSource.DataSource = OrderList;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.ShowDialog();
            orderBindingSource.DataSource = typeof(List<Order>);
            orderBindingSource.DataSource = OrderList;
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form5 form5 = new Form5();
            form5.ShowDialog();
            orderBindingSource.DataSource = typeof(List<Order>);
            orderBindingSource.DataSource = OrderList;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Title="请选择xml文件";
            string fileName = "";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                fileName = dialog.FileName;
                Console.WriteLine(fileName);
            }
            XmlSerializer xmlser = new XmlSerializer(typeof(List<Order>));
            List<Order> OrderList2 = XmlDeserialize(xmlser,fileName) as List<Order>;
            OrderList.Clear();
            OrderList = OrderList2;
            orderBindingSource.DataSource = typeof(List<Order>);
            orderBindingSource.DataSource = OrderList;
        }
        public static object XmlDeserialize(XmlSerializer formatter,string fileName)
        {
            FileStream fs = new FileStream(fileName, FileMode.Open);
            object obj = formatter.Deserialize(fs);
            fs.Close();
            return obj;
        }
    }
}
