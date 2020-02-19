using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;





/****************************************************************************
**					SAKARYA ÜNİVERSİTESİ
**				BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
**				    BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ
**				   NESNEYE DAYALI PROGRAMLAMA DERSİ
**					2018-2019 BAHAR DÖNEMİ
**	
**				ÖDEV NUMARASI..........: 3
**				ÖĞRENCİ ADI............: KUTAY YAMAN
**				ÖĞRENCİ NUMARASI.......: B171210074
**                         DERSİN ALINDIĞI GRUP...: D
****************************************************************************/
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
