using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;

namespace WindowsFormsApp1
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            XmlSerializer xmlser = new XmlSerializer(typeof(List<Order>));
            string xmlFileName = textBox1.Text;
            XmlSerialize(xmlser, xmlFileName, Form1.OrderList);

            string xml = File.ReadAllText(xmlFileName);
            Console.WriteLine(xml);

        }

        public static void XmlSerialize(XmlSerializer ser,string fileName,object obj)
        {
            FileStream fs = new FileStream(fileName, FileMode.Create);
            ser.Serialize(fs, obj);
            fs.Close();
        }
    }
}
