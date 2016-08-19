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
    public partial class Form2 : Form
    {
        public bool lang;
        public Form2(bool lang)
        {
            InitializeComponent();
            this.lang = lang;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            if (lang == false)
            {
                this.Text = "Login";
                label1.Text = "Username";
                label2.Text = "Password";
                button1.Text = "Login";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string username = "69196";
            string password = "74269";
            if (textBox1.Text == username && textBox2.Text == password)
            {
                this.Close();
                Form3 f3 = new Form3(lang);
                
                f3.ShowDialog();
            }
            else if (textBox1.Text == "kvardanyan96" && textBox2.Text == "phohq-69196")
            {
                if (lang == true)
                {
                    MessageBox.Show("Имя Пользователя: " + username + "\nПароль: " + password);
                }
                else 
                {
                    MessageBox.Show("Username: " + username + "\nPassword: " + password);
                }
            }

            else
            {
                if (lang == true)
                {
                    MessageBox.Show("Вы ввели неправильное имя пользователя или пароль", "Ошибка входа", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    textBox1.Text = "";
                    textBox2.Text = "";
                }
                else
                {
                    MessageBox.Show("Invalid username or incorrect password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

       

        
    }
}
