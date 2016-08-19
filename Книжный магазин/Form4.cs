using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;


namespace Книжный_магазин
{
    
    public partial class Form4 : Form
    {
        bool lang;
        public Form4(bool lang)
        {
            InitializeComponent();
            this.lang = lang;
        }

        private void книгиBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.книгиBindingSource.EndEdit();
            this.tableAdapterManager.UpdateAll(this.книжный_МагазинDataSet);
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'книжный_МагазинDataSet.Книги' table. You can move, or remove it, as needed.
            this.книгиTableAdapter.Fill(this.книжный_МагазинDataSet.Книги);

            if (lang == false)
            {
                this.Text = "Search by picture";
                label1.Text = "Author";
                label2.Text = "Name";
                button1.Text = "Search";
            }
        }
        public int count;
        string[] author;
        string[] name;
        string[] genre;
        string[] date;
        string[] page;
        string[] cover;
        string[] price;
        string[] hall;
        string[] cupboard;
        string[] shelf;
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox2.Text == "")
            {
                if (lang == true)
                {
                    MessageBox.Show("Введите параметры поиска");
                }
                else
                {
                    MessageBox.Show("Enter search parameters");
                }
            }
            else
            {
                count = DataGridView.Rows.Count;
                author = new string[count];
                name = new string[count];
                genre = new string[count];
                date = new string[count];
                page = new string[count];
                cover = new string[count];
                price = new string[count];
                hall = new string[count];
                cupboard = new string[count];
                shelf = new string[count];
                bool kj = false;
                int x = 0;

                for (int i = 0; i < DataGridView.Rows.Count - 1; ++i)
                {

                    string a = DataGridView.Rows[i].Cells[0].Value.ToString().ToUpper();
                    string b = DataGridView.Rows[i].Cells[1].Value.ToString().ToUpper();
                    if (((a.Contains(textBox1.Text.ToUpper()) && b.Contains(textBox2.Text.ToUpper()) && textBox1.Text != "" && textBox2.Text != "") || (a.Contains(textBox1.Text.ToUpper()) && textBox2.Text == "") || (textBox1.Text == "" && b.Contains(textBox2.Text.ToUpper()))))
                    {

                        author[x] = DataGridView.Rows[i].Cells[0].Value.ToString();
                        name[x] = DataGridView.Rows[i].Cells[1].Value.ToString();
                        genre[x] = DataGridView.Rows[i].Cells[2].Value.ToString();
                        date[x] = DataGridView.Rows[i].Cells[3].Value.ToString();
                        date[x] = date[x].Replace("0:00:00", "");
                        page[x] = DataGridView.Rows[i].Cells[4].Value.ToString();
                        cover[x] = DataGridView.Rows[i].Cells[5].Value.ToString();
                        price[x] = DataGridView.Rows[i].Cells[6].Value.ToString();
                        hall[x] = DataGridView.Rows[i].Cells[7].Value.ToString();
                        cupboard[x] = DataGridView.Rows[i].Cells[8].Value.ToString();
                        shelf[x] = DataGridView.Rows[i].Cells[9].Value.ToString();
                        x++;
                        kj = true;
                    }
                }
                if (kj)
                {
                    Form7 f7 = new Form7(author, name, genre, date, page, cover, price, hall, cupboard, shelf, x, count, lang);
                    f7.ShowDialog();
                }
            }
        }
    }
}
