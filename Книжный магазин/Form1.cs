using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Книжный_магазин
{
    public partial class Form1 : Form
    {
        bool lang = true;
        public Form1()
        {
            InitializeComponent();
            radioButton2.Checked = true;
        }


        private void button4_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                Form4 f4 = new Form4(lang);
                f4.ShowDialog();
            }
            else
            {
                Form5 f5 = new Form5(lang);
                f5.ShowDialog();

            }
        }

        private void входДляАдминистратораToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(lang);
            f2.ShowDialog();
        }

        private void английскийToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lang = false;
            Form1.ActiveForm.Text = "Start page";
            groupBox1.Text = "Search";
            radioButton1.Text = "Search (Cover)";
            radioButton2.Text = "Search in the base";
            button4.Text = "Search";
            manuToolStripMenuItem.Text = "Manu";
            aboutToolStripMenuItem.Text = "About";
            exitToolStripMenuItem.Text = "Exit";
            входДляАдминистратораToolStripMenuItem.Text = "Sign in for admin";
            языкToolStripMenuItem.Text = "Language";
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox1 about = new AboutBox1();
            about.ShowDialog();
        }

        private void русскийToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            lang = true;
            Form1.ActiveForm.Text = "Начальная страница";
            groupBox1.Text = "Поиск";
            radioButton1.Text = "Поиск (Обложка)";
            radioButton2.Text = "Поиск в базе";
            button4.Text = "Поиск";
            manuToolStripMenuItem.Text = "Меню";
            aboutToolStripMenuItem.Text = "О программе";
            exitToolStripMenuItem.Text = "Выход";
            входДляАдминистратораToolStripMenuItem.Text = "Вход для администратора";
            языкToolStripMenuItem.Text = "Язык";
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        

        


        

        
    }
}
