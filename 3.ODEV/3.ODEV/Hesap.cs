using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _3.ODEV
{
    class Hesap
    {
        TextBox textBox1;
        TextBox textBox2;

        public Hesap(TextBox textBox1,TextBox textBox2)
        {
            this.textBox1 = textBox1;
            this.textBox2 = textBox2;
        }

        public void Hesapla()
        {
            try
          {
            string diziGirilen = textBox1.Text; //textbox'a girilenleri string olarak aldım
            List<char> girilen = new List<char>(); //textbox'tan aldıklarımı liste halinda burda tutucam
            for (int i = 0; i < diziGirilen.Length; i++) //textboxtan aldıklarımı for kullanarak listeye atadım
            {
                girilen.Add(Convert.ToChar(diziGirilen[i]));
            }

            List<string> sayilar = new List<string>(); //girilen sayıları bu listede tutucam
            List<string> operatorler = new List<string>();//girilen operatorleri bu listede tutucam
            int elemanSayilar = 0; //girilen sayi sayısını tutucam
            int elemanOperatorler = 0; // girilen operator sayısını tutucam
            int sonuc = 0;
            string bos = "";
            sayilar.Add(""); // listede yer açıyorum
            operatorler.Add(""); //listede yer açıyorum
            for (int i = 0; i < diziGirilen.Length; i++) //girilen isimli listedeki elemanların operator mu sayı mı olduguna tek tek bakıcam
            {

                if (girilen[i] != '+' && girilen[i] != '-' && girilen[i] != '/' && girilen[i] != '*') //eger girilenler operator degilse
                {
                    bos += girilen[i].ToString(); //operatore kadar olan karakterleri tek tek alıp bos isimli stringe ekliyorum
                    sayilar[elemanSayilar] = bos; //sayilari tuttugum listeye o sayıyı ekliyorum
                }
                else //eger operatore denk geldiyse buraya gelecek 
                {
                    sayilar.Add(""); //sayilar listesinde 1 elemanlık daha yer acıyorum
                    elemanSayilar++; //operatorden sonra sayi gelecegi icin sayilarin eleman sayisini tutan degiskeni 1 arttırıyorum
                    bos = ""; // bos isimli degiskeni bosaltıyorum tekrardan
                    operatorler[elemanOperatorler] = girilen[i].ToString(); //operatoru operatorleri tuttugum listeye ekliyorum
                    elemanOperatorler++; //operator sayısını 1 arttırıyorum
                    operatorler.Add(""); //operatorler listesinde 1 elemanlık daha yer acıyorum
                }
            }

            List<int> silincekİndexler = new List<int>(); //ilk önce çarpma ve bölme operatörlerinin işini yapıcam ve
                                                          //sonrasında bu operatörleri listeden silicem bunların indexini
                                                          //tutmak için liste olusturdum
            for (int i = 0; i < elemanOperatorler; i++)
            {
                if (operatorler[i] == "*")
                {
                    int ekle = Convert.ToInt32(sayilar[i]) * Convert.ToInt32(sayilar[i + 1]); //operatorun solundaki ve sagındakı degerleri carpıyorum
                    sayilar[i + 1] = ekle.ToString(); //sagındakı degerin yerine carpma sonucunu atıyorum
                    silincekİndexler.Add(i);//degeri sagdaki sayıya yani i+1' atadım böylelikle i. sayıyı ve i. operatoru silicem
                    sonuc = ekle;
                }
                if (operatorler[i] == "/")
                {
                    int ekle = Convert.ToInt32(sayilar[i]) / Convert.ToInt32(sayilar[i + 1]);
                    sayilar[i + 1] = ekle.ToString();
                    silincekİndexler.Add(i);
                    sonuc = ekle;
                }

            }

            for (int i = 0; i < silincekİndexler.Count; i++) //silincek indexlerdeki sayı ve operatorlerı siliyorum isleri bitti
            {
                sayilar.RemoveAt(silincekİndexler[i] - i); //silincekİndexler[i]-i çünkü bir eleman silince eleman sayısı azalacak ve 
                                                           //elemanlar bir birim sola kayacak 
                operatorler.RemoveAt(silincekİndexler[i] - i);
            }

            for (int i = 0; i < operatorler.Count; i++)//carpma ve bolme islemlerinden sonra toplama ve cikarma islemlerini yapicam
                                                       //operatorler listesinden zaten carpma ve bolme operatorlerini yukarda cikartmistim
            {
                if (operatorler[i] == "+")
                {
                    int ekle = Convert.ToInt32(sayilar[i]) + Convert.ToInt32(sayilar[i + 1]); //operatorun sagındakı ve solundakı degerleri topluyorum
                    sayilar[i + 1] = ekle.ToString(); //sonucu operatorun sagındakı sayının yerıne yazıyorum

                    sonuc = ekle; //toplama veya cıkartma sonucunu hep (i+1). elemanın yerine yazdığım için
                                  // ve bu (i+1). elemana zaten ekle sonucunu koydugum icin en son ekle'yi sonuc olarak
                                  // döndürsem bir sorun olmaz ama isteseydim direkt (i+1). elemanıda sonuca esitleyebilirdim
                                  // hocam biraz karışık duruyo ama kağıda çizip düşündüm ben ozaman daha anlaşılır oluyo.
                }
                if (operatorler[i] == "-")
                {
                    int ekle = Convert.ToInt32(sayilar[i]) - Convert.ToInt32(sayilar[i + 1]);
                    sayilar[i + 1] = ekle.ToString();

                    sonuc = ekle;
                }

            }

            textBox2.Text = sonuc.ToString();
        }
            catch(DivideByZeroException)
            {
                textBox2.Text = "0 ile BÖLME HATASI";
            }
            catch (FormatException)
            {
                textBox2.Text = "SADECE SAYILARLA ISLEM YAPILABILIR";
            }
            catch(OverflowException e)
            {
                textBox2.Text = e.Message;
            }
            catch(NullReferenceException e)
            {
                textBox2.Text = e.Message;
            }
            catch(StackOverflowException e)
            {
                textBox2.Text = e.Message;
            }
        }
    }
}
