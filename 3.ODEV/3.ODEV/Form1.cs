using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;






namespace _3.ODEV
{
    public partial class Form1 : Form
    {
        Hesap hesap;
        public Form1()
        {
            InitializeComponent();
            hesap = new Hesap(textBox1,textBox2);
        }

        private void button1_Click(object sender, EventArgs e)
        {

            hesap.Hesapla();
            
        }
    }
}
