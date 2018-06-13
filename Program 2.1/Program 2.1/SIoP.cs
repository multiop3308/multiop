using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using System.ComponentModel;
using System.Data;
using System.Drawing;

namespace Program_2._1
{
    public partial class SIoP : Form
    {
        public SIoP()
        {

            InitializeComponent();
            this.button1.Click += new System.EventHandler(this.button1_Click);

        }

        public void button1_Click(object sender, EventArgs e)
        {
           // List<Multioperation3> listg = null;
          //  List<Multioperation3> listf = null;
            Multioperation3 mop1 = new Multioperation3(textBox1.Text);
            Multioperation3 mop2 = new Multioperation3(textBox3.Text);
            if (Regex.IsMatch(textBox1.Text, "[^0-7 ]"))
            {
                textBox2.Text="Ошибка! Компоненты мультиоперации должны быть [0-7]";
                return;
            }
            if (Regex.IsMatch(textBox3.Text, "[^0-7 ]"))
            {
                textBox2.Text = "Ошибка! Компоненты мультиоперации должны быть [0-7]";
                return;
            }
            if (mop1 < mop2)
                textBox2.Text="Мультиоперации перестановочны";
            else
                textBox2.Text="Мультиоперации не перестановочны";
            /* listf = Multioperation3Utils.ReadSetFromBox(s1);
             listg = Multioperation3Utils.ReadSetFromBox(s2);
             foreach (Multioperation3 f in listf)
             {
                 foreach (Multioperation3 g in listg)
                 {    
                     textBox2.Text = textBox2.Text + "Мультиоперации  " + f + " и " + g + " ";
                     if (f < g)
                     {
                         textBox2.Text = textBox2.Text + "  перестановочны ";
                     }
                     else
                     {
                         textBox2.Text = textBox2.Text + "  не перестановочны  ";
                     };
                     textBox2.Text = textBox2.Text + "  \n \r";
                 }
             }; */
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            webBrowser1.Show();
            button5.Show();

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            List <Multioperation3> listg=null;
            List <Multioperation3> listf=null;
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(openFileDialog1.FileName);
                // MessageBox.Show(sr.ReadToEnd());
               // textBox2.Text = sr.ReadToEnd();
                 listf = Multioperation3Utils.ReadSetFromFile(openFileDialog1.FileName);
               // textBox1.Text = listf.Count().ToString();
                sr.Close();
                MessageBox.Show("Лист мультиопераций f считан. Выберите второй файл.");
            }
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(openFileDialog1.FileName);
                // MessageBox.Show(sr.ReadToEnd());
                // textBox2.Text = sr.ReadToEnd();
                 listg = Multioperation3Utils.ReadSetFromFile(openFileDialog1.FileName);
               // textBox1.Text = listg.Count().ToString();
                sr.Close();
                MessageBox.Show("Лист мультиопераций g считан. Результат выведен на экран и в файл.");
            }
            textBox2.Clear();
            System.IO.StreamWriter sw = new System.IO.StreamWriter("D:\\result.txt",true);
            foreach (Multioperation3 f in listf)
            {
                foreach (Multioperation3 g in listg)
                {
                    textBox2.Text= textBox2.Text+ "Мультиоперации  " +f+" и "+g+" ";
                    sw.Write("Мультиоперации  " + f + " и " + g + " ");
                    
                    if (f < g)
                    {
                        textBox2.Text = textBox2.Text + "  перестановочны ";
                        sw.WriteLine(" перестановочны");
                    }
                    else
                    {
                        textBox2.Text = textBox2.Text + "  не перестановочны  ";
                        sw.WriteLine("  не перестановочны");
                    };
                    textBox2.Text = textBox2.Text+ "  \n \r";
                }
            }
            sw.Close();
            
            
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
        }

        private void SIoP_Load(object sender, EventArgs e)
        {

        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            //string path = Application.StartupPath + @"C://Users/Romcheg/source/repos/Program 2.1/Program 2.1/HTMLPage1.html";
         //   webBrowser1.Navigate(path);
            //webBrowser1.Show();

           /* webBrowser1.Navigate("C://Users/Romcheg/source/repos/Program 2.1/Program 2.1/HTMLPage1.html");
            HtmlDocument doc = webBrowser1.Document;
            webBrowser1.Print();*/

        }

        private void button5_Click(object sender, EventArgs e)
        {
            webBrowser1.Hide();
            button5.Hide();

        }
    }
}
