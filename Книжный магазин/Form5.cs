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
    public partial class Form5 : Form
    {
        bool lang;
        public Form5(bool lang)
        {
            this.lang = lang;
            InitializeComponent();

        }

        private void книгиBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.книгиBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.книжный_МагазинDataSet);

        }

        public int c;

        private void Form5_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'книжный_МагазинDataSet.Книги' table. You can move, or remove it, as needed.
            this.книгиTableAdapter.Fill(this.книжный_МагазинDataSet.Книги);
            this.tableAdapterManager.UpdateAll(this.книжный_МагазинDataSet);
            if (lang == false)
            {
                comboBox1.Items.Add("Choose the genre...");
                comboBox4.Items.Add("Choose the cover...");
                comboBox4.Items.Add("Paperback");
                comboBox4.Items.Add("Hardcover");
            }
            else
            {
                comboBox1.Items.Add("Выберите жанр...");
                comboBox4.Items.Add("Выберите обложку...");
                comboBox4.Items.Add("Мягкая");
                comboBox4.Items.Add("Твердая");
            }

            comboBox1.Items.Add(DataGridView.Rows[0].Cells[2].Value.ToString());


            comboBox4.SelectedIndex = 0;



            for (int i = 0; i < DataGridView.Rows.Count - 1; i++)
            {

                for (int j = 0; j < i; j++)
                {
                    if (DataGridView.Rows[i + 1].Cells[2].Value.ToString() == DataGridView.Rows[j].Cells[2].Value.ToString())
                    {

                        break;
                    }
                    else
                    {
                        comboBox1.Items.Add(DataGridView.Rows[i + 1].Cells[2].Value.ToString());
                        break;
                    }
                }
            }

            radioButton1.Click += new EventHandler(radioButton1_Click);
            radioButton2.Click += new EventHandler(radioButton2_Click);
            radioButton3.Click += new EventHandler(radioButton3_Click);
            c = DataGridView.Rows.Count;
            DataGridView.Columns[3].HeaderText = "Публикация";
            DataGridView.Columns[6].HeaderText = "Стоимость";
            if (lang == false)
            {
                this.Text = "Books";
                groupBox1.Text = "Filter";
                label5.Text = "Filter";
                radioButton1.Text = "By genre";
                radioButton2.Text = "By date";
                radioButton3.Text = "By the cover";
                label3.Text = "From:";
                label4.Text = "To:";
                button2.Text = "Filter";
                groupBox2.Text = "Search";
                label1.Text = "Author";
                label2.Text = "Name";
                button3.Text = "Search";
                button1.Text = "Information";
                DataGridView.Columns[0].HeaderText = "Author";
                DataGridView.Columns[1].HeaderText = "Name";
                DataGridView.Columns[2].HeaderText = "Genre";
                DataGridView.Columns[3].HeaderText = "Publication";
                DataGridView.Columns[4].HeaderText = "Pages";
                DataGridView.Columns[5].HeaderText = "Cover";
                DataGridView.Columns[6].HeaderText = "Price";
                DataGridView.Columns[7].HeaderText = "Hall";
                DataGridView.Columns[8].HeaderText = "Locker";
                DataGridView.Columns[9].HeaderText = "Shelf";



            }

        }

        void radioButton3_Click(object sender, EventArgs e)
        {
            comboBox4.Visible = true;
            comboBox1.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            comboBox1.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
            button2.Visible = true;
        }

        void radioButton2_Click(object sender, EventArgs e)
        {
            label3.Visible = true;
            label4.Visible = true;
            textBox3.Visible = true;
            textBox4.Visible = true;
            comboBox1.Visible = false;
            comboBox4.Visible = false;
            button2.Visible = true;
            comboBox1.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
        }

        void radioButton1_Click(object sender, EventArgs e)
        {
            comboBox1.Visible = true;
            label3.Visible = false;
            label4.Visible = false;
            comboBox4.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            button2.Visible = true;
            comboBox1.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
        }

        string[] text = new string[10];

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < DataGridView.Rows.Count; i++)
            {

                if (DataGridView.Rows[i].Selected == true)
                {
                    string author = DataGridView.Rows[i].Cells[0].Value.ToString();
                    string name = DataGridView.Rows[i].Cells[1].Value.ToString();
                    string genre = DataGridView.Rows[i].Cells[2].Value.ToString();
                    string date = DataGridView.Rows[i].Cells[3].Value.ToString();
                    string page = DataGridView.Rows[i].Cells[4].Value.ToString();
                    string cover = DataGridView.Rows[i].Cells[5].Value.ToString();
                    string price = DataGridView.Rows[i].Cells[6].Value.ToString();
                    string hall = DataGridView.Rows[i].Cells[7].Value.ToString();
                    string cupboard = DataGridView.Rows[i].Cells[8].Value.ToString();
                    string shelf = DataGridView.Rows[i].Cells[9].Value.ToString();
                    text[0] = "Книжный магазин";
                    text[1] = "Информация о книге";
                    text[2] = "";
                    text[3] = "Автор: " + author;
                    text[4] = "Название: " + name;
                    text[5] = "Жанр: " + genre;
                    text[6] = "Место: ";
                    text[7] = "Зал: " + hall;
                    text[8] = "Шкаф: " + cupboard + "  Полка: " + shelf;
                    File.WriteAllLines("toprint.txt", text);
                    Form6 f6 = new Form6(author, name, genre, date, page, cover, price, hall, cupboard, shelf, lang);
                    f6.ShowDialog();

                }


            }
        }
        int k = 0;
        bool t = true;
        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                if (comboBox1.SelectedItem.ToString() == "Выберите жанр..." || comboBox1.SelectedItem.ToString() == "Choose the genre...")
                {
                    this.книгиTableAdapter.Fill(this.книжный_МагазинDataSet.Книги);
                }
                else
                {
                    this.книгиTableAdapter.Fill(this.книжный_МагазинDataSet.Книги);
                    for (int i = 0; i < DataGridView.Rows.Count; i++)
                    {
                        if (DataGridView.Rows[i].Cells[2].Value.ToString() != comboBox1.SelectedItem.ToString())
                        {
                            DataGridView.Rows.RemoveAt(i);
                            i--;
                        }
                    }
                }
                if (DataGridView.Rows.Count == 0)
                {
                    this.книгиTableAdapter.Fill(this.книжный_МагазинDataSet.Книги);
                    if (lang == true)
                    {
                        MessageBox.Show("Такой книги нет!!!");
                    }
                    else 
                    {
                        MessageBox.Show("There is not such a book!!!");
                    }
                }
            }

            if (radioButton2.Checked == true)
            {
                if (textBox3.Text != "" && textBox4.Text != "")
                {
                    if (int.TryParse(textBox3.Text, out k) == false)
                    {
                        if (lang == true)
                        {
                            MessageBox.Show("Вы ввели неправильное значение", "Ошибка");
                            textBox3.Text = "";
                            t = false;
                        }
                        else
                        {
                            MessageBox.Show("You entered an invalid value", "Error");
                            textBox3.Text = "";
                            t = false;
                        }
                    }
                    else if (int.TryParse(textBox4.Text, out k) == false)
                    {
                        if (lang == true)
                        {
                            MessageBox.Show("Вы ввели неправильное значение", "Ошибка");
                            textBox4.Text = "";
                            t = false;
                        }
                        else
                        {
                            MessageBox.Show("You entered an invalid value", "Error");
                            textBox4.Text = "";
                            t = false;
                        }
                    }
                    else if (Convert.ToInt32(textBox3.Text) > Convert.ToInt32(textBox4.Text))
                    {
                        if (lang == true)
                        {
                            MessageBox.Show("Вы ввели неправильное значение", "Ошибка");
                            textBox3.Text = "";
                            textBox4.Text = "";
                            t = false;
                        }
                        else
                        {
                            MessageBox.Show("You entered an invalid value", "Error");
                            textBox3.Text = "";
                            textBox4.Text = "";
                            t = false;
                        }
                    }
                    string[] date = new string[c];
                    int[] da = new int[100];
                    if (t)
                    {
                        this.книгиTableAdapter.Fill(this.книжный_МагазинDataSet.Книги);
                        for (int i = 0; i < DataGridView.Rows.Count; i++)
                        {

                            date[i] = DataGridView.Rows[i].Cells[3].Value.ToString();
                            date[i] = date[i].Replace(" г.", "");

                            da[i] = Convert.ToInt32(date[i]);
                            if (da[i] > Convert.ToInt32(textBox4.Text) || da[i] < Convert.ToInt32(textBox3.Text))
                            {
                                DataGridView.Rows.RemoveAt(i);
                                i--;
                            }
                        }
                    }
                }
                else if (textBox4.Text == "")
                {
                    if (int.TryParse(textBox3.Text, out k) == false)
                    {
                        if (lang == true)
                        {
                            MessageBox.Show("Вы ввели неправильное значение", "Ошибка");
                            textBox3.Text = "";
                            t = false;
                        }
                        else
                        {
                            MessageBox.Show("You entered an invalid value", "Error");
                            textBox3.Text = "";
                            t = false;
                        }
                    }
                    if (t)
                    {
                        string[] date = new string[c];
                        int[] da = new int[100];
                        this.книгиTableAdapter.Fill(this.книжный_МагазинDataSet.Книги);
                        for (int i = 0; i < DataGridView.Rows.Count; i++)
                        {

                            date[i] = DataGridView.Rows[i].Cells[3].Value.ToString();
                            date[i] = date[i].Replace(" г.", "");

                            da[i] = Convert.ToInt32(date[i]);
                            if (da[i] < Convert.ToInt32(textBox3.Text))
                            {
                                DataGridView.Rows.RemoveAt(i);
                                i--;
                            }
                        }
                    }
                }
                else if (textBox3.Text == "")
                {
                    if (int.TryParse(textBox4.Text, out k) == false)
                    {
                        if (lang == true)
                        {
                            MessageBox.Show("Вы ввели неправильное значение", "Ошибка");
                            textBox4.Text = "";
                            t = false;
                        }
                        else
                        {
                            MessageBox.Show("You entered an invalid value", "Error");
                            textBox4.Text = "";
                            t = false;
                        }
                    }
                    if (t)
                    {
                        string[] date = new string[c];
                        int[] da = new int[100];
                        this.книгиTableAdapter.Fill(this.книжный_МагазинDataSet.Книги);
                        for (int i = 0; i < DataGridView.Rows.Count; i++)
                        {

                            date[i] = DataGridView.Rows[i].Cells[3].Value.ToString();
                            date[i] = date[i].Replace(" г.", "");

                            da[i] = Convert.ToInt32(date[i]);
                            if (da[i] > Convert.ToInt32(textBox4.Text))
                            {
                                DataGridView.Rows.RemoveAt(i);
                                i--;
                            }
                        }
                    }

                }

                if (DataGridView.Rows.Count == 0)
                {
                    this.книгиTableAdapter.Fill(this.книжный_МагазинDataSet.Книги);
                    if (lang == true)
                    {
                        MessageBox.Show("Такой книги нет!!!");
                    }
                    else
                    {
                        MessageBox.Show("There is not such a book!!!");
                    }
                }
            }


            if (radioButton3.Checked == true)
            {
                if (comboBox4.SelectedItem.ToString() == "Выберите обложку..." || comboBox4.SelectedItem.ToString() == "Choose the cover...")
                {
                    this.книгиTableAdapter.Fill(this.книжный_МагазинDataSet.Книги);
                }
                else
                {
                    this.книгиTableAdapter.Fill(this.книжный_МагазинDataSet.Книги);
                    for (int i = 0; i < DataGridView.Rows.Count; i++)
                    {
                        if (DataGridView.Rows[i].Cells[5].Value.ToString() != comboBox4.SelectedItem.ToString())
                        {
                            DataGridView.Rows.RemoveAt(i);
                            i--;
                        }
                    }
                }

                if (DataGridView.Rows.Count == 0)
                {
                    this.книгиTableAdapter.Fill(this.книжный_МагазинDataSet.Книги);
                    if (lang == true)
                    {
                        MessageBox.Show("Такой книги нет!!!");
                    }
                    else
                    {
                        MessageBox.Show("There is not such a book!!!");
                    }
                }
            }

        }


        private void button3_Click(object sender, EventArgs e)
        {
            radioButton1.Checked = false;
            radioButton2.Checked = false;
            radioButton3.Checked = false;
            comboBox1.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            comboBox4.Visible = false;
            textBox3.Visible = false;
            textBox4.Visible = false;
            button2.Visible = false;
            comboBox1.SelectedIndex = 0;
            comboBox4.SelectedIndex = 0;
            if (textBox1.Text == "" && textBox2.Text == "")
            {
                if (lang == true)
                {
                    MessageBox.Show("Введити параметры поиска");
                }
                else
                {
                    MessageBox.Show("Enter search parameters");
                }
            }
            else
            {
                this.книгиTableAdapter.Fill(this.книжный_МагазинDataSet.Книги);
                for (int i = 0; i < DataGridView.Rows.Count; ++i)
                {
                    string a = DataGridView.Rows[i].Cells[0].Value.ToString().ToUpper();
                    string b = DataGridView.Rows[i].Cells[1].Value.ToString().ToUpper();
                    if (((a.Contains(textBox1.Text.ToUpper()) == false || b.Contains(textBox2.Text.ToUpper()) == false && textBox1.Text != "" && textBox2.Text != "") || (a.Contains(textBox1.Text.ToUpper()) == false && textBox2.Text == "") || (textBox1.Text == "" && b.Contains(textBox2.Text.ToUpper()) == false)))
                    {
                        DataGridView.Rows.RemoveAt(i);
                        i--;
                    }
                }

            }
            if (DataGridView.Rows.Count == 0)
            {
                this.книгиTableAdapter.Fill(this.книжный_МагазинDataSet.Книги);
                if (lang == true)
                {
                    MessageBox.Show("Такой книги нет!!!");
                }
                else
                {
                    MessageBox.Show("There is not such a book!!!");
                }
                textBox1.Text = "";
                textBox2.Text = "";
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

       

   
