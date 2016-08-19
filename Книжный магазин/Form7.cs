using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;


namespace Книжный_магазин
{
    
    public partial class Form7 : Form
    {
        List<PictureBox> picBox;
        List<Label> label;
        bool lang;
        int po = 0;
        string[] author = new string[1000];
        string[] name = new string[1000];
        string[] genre = new string[1000];
        string[] date = new string[1000];
        string[] page = new string[1000];
        string[] cover = new string[1000];
        string[] price = new string[1000];
        string[] hall = new string[1000];
        string[] cupboard = new string[1000];
        string[] shelf = new string[1000];
        
        

        public Form7(string[] a, string[] b, string[] c, string[] d, string[] e, string[] f, string[] g, string[] h, string[] i, string[] j, int y,int count,bool lang)
        {
            InitializeComponent();
            this.lang = lang;
            if (lang == false)
            {
                this.Text = "Results";
            }
            picBox = new List<PictureBox>();
            label = new List<Label>();

            int Xpicbuffer = 30, Ypicbuffer = 30;
            int Xlabbuffer = 30, Ylabbuffer = 190;
            for (int m = 0; m < y; ++m)
            {
                // 
                //  PictureBox
                //
                picBox.Add(new PictureBox());
                this.Controls.Add(picBox[m]);
                if (Xpicbuffer > 590)
                {
                    Xpicbuffer = 30;
                    Ypicbuffer = Ypicbuffer + 220;
                }

                picBox[m].Location = new Point(Xpicbuffer, Ypicbuffer);
                picBox[m].Size = new Size(120, 150);
                Xpicbuffer = Xpicbuffer + 160;
                picBox[m].SizeMode = PictureBoxSizeMode.StretchImage;
                if (File.Exists(Application.StartupPath + "\\Images\\" + b[m] + ".jpg"))
                {
                    picBox[m].ImageLocation = Application.StartupPath + "\\Images\\" + b[m] + ".jpg";
                    
                    
                }
                else
                {
                    picBox[m].ImageLocation = Application.StartupPath + "\\Images\\" + "No_image" + ".png";
                }
                picBox[m].BorderStyle = BorderStyle.Fixed3D;
                picBox[m].Click += new EventHandler(Form7_Click1);
                
                Pen blackPen = new Pen(Color.WhiteSmoke, 3);
                Point point2 = new Point(500, 100);
                Point point1 = new Point(100, 100);
                
                


                //
                // Label
                //
                label.Add(new Label());
                this.Controls.Add(label[m]);
                if (Xlabbuffer > 590)
                {
                    Xlabbuffer = 30;
                    Ylabbuffer = Ylabbuffer + 220;
                }
                label[m].Location = new Point(Xlabbuffer, Ylabbuffer);
                label[m].Size = new Size(120, 30);
                label[m].Text = a[m] + " - " + b[m];
                label[m].BackColor = Color.Transparent;
                label[m].ForeColor = Color.Black;
                
                Xlabbuffer = Xlabbuffer + 160;
                
                
                label[m].Click += new EventHandler(Form7_Click);

                po++;
                author[m] = a[m];
                name[m] = b[m];
                genre[m] = c[m];
                date[m] = d[m];
                page[m] = e[m];
                cover[m] = f[m];
                price[m] = g[m];
                hall[m] = h[m];
                cupboard[m] = i[m];
                shelf[m] = j[m];
                
            }



        }

        
        
        void Form7_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < po; i++)
            {
                if (label[i].Capture == true)
                {
                    Form6 f6 = new Form6(author[i], name[i], genre[i], date[i], page[i], cover[i], price[i], hall[i], cupboard[i], shelf[i],lang);
                    f6.ShowDialog();
                }

            }
        }
        string[] text = new string[10];
        void Form7_Click1(object sender, EventArgs e)
        {
            for (int i = 0; i < po; i++)
            {
                if (picBox[i].Capture == true)
                {
                    text[0] = "Книжный магазин";
                    text[1] = "Информация о книге";
                    text[2] = "";
                    text[3] = "Автор: " + author[i];
                    text[4] = "Название: " + name[i];
                    text[5] = "Жанр: " + genre[i];
                    text[6] = "Место: ";
                    text[7] = "Зал: " + hall[i];
                    text[8] = "Шкаф: " + cupboard[i] + "  Полка: " + shelf[i];
                    File.WriteAllLines("toprint.txt",text);
                    
                    Form6 f6 = new Form6(author[i], name[i], genre[i], date[i], page[i], cover[i], price[i], hall[i], cupboard[i], shelf[i],lang);
                    f6.ShowDialog();
                }

            }
        }
    }
}
