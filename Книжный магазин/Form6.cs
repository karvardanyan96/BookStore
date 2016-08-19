using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
namespace Книжный_магазин
{
    public partial class Form6 : Form
    {
        bool lang;
        public Form6(string a, string b, string c, string d, string e, string f, string g, string h, string i, string j,bool lang)
        {
            InitializeComponent();
            this.lang = lang;
            if (File.Exists(Application.StartupPath + "\\Images\\" + b + ".jpg"))
            {
                pictureBox1.ImageLocation = Application.StartupPath + "\\Images\\" + b + ".jpg";
            }
            else
            {
                pictureBox1.ImageLocation = Application.StartupPath + "\\Images\\" + "No_image" + ".png";
            }

            label2.Text = a;
            label4.Text = b;
            label6.Text = c;
            label8.Text = d;
            label10.Text = e;
            label12.Text = f;
            label14.Text = g;
            if (lang == false)
            {
                label1.Text = "Author";
                label3.Text = "Name";
                label5.Text = "Genre";
                label7.Text = "Publication";
                label9.Text = "Pages";
                label11.Text = "Cover";
                label13.Text = "Price";
                button1.Text = "Print";
                this.Text = "Information";
            }
            
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ProcessStartInfo info2 = new ProcessStartInfo("toprint.txt");
            info2.Verb = "Print";
            info2.CreateNoWindow = true;
            info2.WindowStyle = ProcessWindowStyle.Hidden;
            Process.Start(info2);
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        
    }
}
