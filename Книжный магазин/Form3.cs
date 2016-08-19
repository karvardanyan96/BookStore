using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace Книжный_магазин
{
    public partial class Form3 : Form
    {
        bool lang;
        OleDbConnection connection;
        public Form3(bool lang)
        {
            InitializeComponent();
            this.lang = lang;
        }

        private void книгиBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();
            this.книгиBindingSource.EndEdit();
            

        }

        private void Form3_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'книжный_МагазинDataSet.Книги' table. You can move, or remove it, as needed.
            this.книгиTableAdapter.Fill(this.книжный_МагазинDataSet.Книги);
            if (lang == false)
            {
                this.Text = "Administrator";
                label1.Text = "Author";
                label2.Text = "Name";
                label3.Text = "Genre";
                label4.Text = "Publication";
                label5.Text = "Pages";
                label6.Text = "Cover";
                label7.Text = "Price";
                label8.Text = "Hall";
                label9.Text = "Locker";
                label10.Text = "Shelf";
                button1.Text = "Add";
                groupBox1.Text = "Book adding";
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
                button2.Text = "Delete";
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            bool lk = true;
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || textBox7.Text == "" || textBox8.Text == "" || textBox9.Text == "" || textBox10.Text == "")
            {
                MessageBox.Show("Вы ввели не все данные");
                lk = false;
            }
            else
            {
                try
                {
                    connection = new OleDbConnection();
                    connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Курсовая\Книжный магазин\Книжный магазин\Книжный Магазин.accdb;Persist Security Info=True";
                    connection.Open();
                    OleDbCommand command1 = connection.CreateCommand();
                    command1.CommandText = "insert into Книги(Автор,Название,Жанр,Страниц,Обложка,Сумма,Зал,Шкаф,Полка,Год_издания) values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox5.Text + "','" + textBox6.Text + "','" + textBox7.Text + "','" + textBox8.Text + "','" + textBox9.Text + "','" + textBox10.Text + "','" + textBox4.Text + "')";
                    command1.ExecuteNonQuery();
                    int a = DataGridView.Rows.Count;
                    bindingNavigatorAddNewItem.PerformClick();
                    DataGridView.Rows[a].Cells[0].Value = textBox1.Text;
                    DataGridView.Rows[a].Cells[1].Value = textBox2.Text;
                    DataGridView.Rows[a].Cells[2].Value = textBox3.Text;
                    DataGridView.Rows[a].Cells[3].Value = textBox4.Text;
                    DataGridView.Rows[a].Cells[4].Value = textBox5.Text;
                    DataGridView.Rows[a].Cells[5].Value = textBox6.Text;
                    DataGridView.Rows[a].Cells[6].Value = textBox7.Text;
                    DataGridView.Rows[a].Cells[7].Value = textBox8.Text;
                    DataGridView.Rows[a].Cells[8].Value = textBox9.Text;
                    DataGridView.Rows[a].Cells[9].Value = textBox10.Text;
                    книгиBindingNavigatorSaveItem.PerformClick();
                    this.tableAdapterManager.UpdateAll(this.книжный_МагазинDataSet);
                    книжный_МагазинDataSet.AcceptChanges();
                    connection.Close();
                    книжный_МагазинDataSet.AcceptChanges();
                }
                catch (Exception poo)
                {
                    MessageBox.Show(poo.Message);
                    lk = false;
                }
            }

            if(lk)
            {
                textBox1.Text = "";
                textBox2.Text = "";
                textBox3.Text = "";
                textBox4.Text = "";
                textBox5.Text = "";
                textBox6.Text = "";
                textBox7.Text = "";
                textBox8.Text = "";
                textBox9.Text = "";
                textBox10.Text = "";
                if (lang == true)
                {
                    MessageBox.Show("Данные добавлены!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Data are added!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            
        }
        string author;
        string name;
        int pppppp;
        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult;
            if (lang == true)
            {
                dialogResult = MessageBox.Show("Вы действительно хотите удалить выбранные таблицы \nиз базы данных без возможности восстановления?", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
            else
            {
                dialogResult = MessageBox.Show("Are you sure you want to permanently delete \nthe selected tables from your database?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            }
            if (dialogResult == DialogResult.Yes)
            {
                try
                {
                    connection = new OleDbConnection();
                    connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Курсовая\Книжный магазин\Книжный магазин\Книжный Магазин.accdb;Persist Security Info=True";
                    connection.Open();
                    OleDbCommand command2 = connection.CreateCommand();
                    
                    for (int i = 0; i < DataGridView.Rows.Count; i++)
                    {

                        if (DataGridView.Rows[i].Selected == true)
                        {
                            author = DataGridView.Rows[i].Cells[0].Value.ToString();
                            name = DataGridView.Rows[i].Cells[1].Value.ToString();
                            pppppp = i;
                        }
                    }

                    command2.CommandText = "DELETE FROM Книги WHERE Автор = '" + author + "' AND Название = '" + name + "'";
                    command2.ExecuteNonQuery();
                    книжный_МагазинDataSet.AcceptChanges();

                    connection.Close();
                    connection = new OleDbConnection();
                    connection.ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\Курсовая\Книжный магазин\Книжный магазин\bin\Debug\Книжный Магазин.accdb;Persist Security Info=True";
                    connection.Open();
                    OleDbCommand command3 = connection.CreateCommand();

                    for (int i = 0; i < DataGridView.Rows.Count; i++)
                    {

                        if (DataGridView.Rows[i].Selected == true)
                        {
                            author = DataGridView.Rows[i].Cells[0].Value.ToString();
                            name = DataGridView.Rows[i].Cells[1].Value.ToString();
                            pppppp = i;
                        }
                    }

                    command3.CommandText = "DELETE FROM Книги WHERE Автор = '" + author + "' AND Название = '" + name + "'";
                    command3.ExecuteNonQuery();
                    книжный_МагазинDataSet.AcceptChanges();

                    connection.Close();
                   
                    this.книгиTableAdapter.Fill(this.книжный_МагазинDataSet.Книги);
                    книжный_МагазинDataSet.AcceptChanges();
                    

                    if (lang == true)
                    {
                        MessageBox.Show("Данные удалены!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("The data is deleted!!!", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    книжный_МагазинDataSet.AcceptChanges();
                }
                catch (Exception ppp)
                {
                    MessageBox.Show(ppp.Message);
                }
            }
            
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
