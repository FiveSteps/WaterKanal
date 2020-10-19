using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace VodoKanalForms
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string connectionString = @"Data Source=DESKTOP-EE4RPR4\SQLEXPRESS;Initial Catalog=commentDB;Integrated Security=True"; //prak - имя базы данных(Поменять на свою)
            SqlConnection conn = new SqlConnection(connectionString); // Подключение к БД
            conn.Open();// Открытие Соединения
            
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Вы должны заполнить все поля!");
            } 
            else
            {
                SqlCommand command = new SqlCommand("INSERT INTO [ReviewsData] (Name, Surname, Patronymic, Rating, Review) VALUES(@Name, @Surname, @Patronymic, @Rating, @Review)", conn);// Объект вывода запросов
                command.Parameters.AddWithValue("Name", textBox2.Text);
                command.Parameters.AddWithValue("Surname", textBox3.Text);
                command.Parameters.AddWithValue("Patronymic", textBox4.Text);
                command.Parameters.AddWithValue("Rating", numericUpDown1.Value);
                command.Parameters.AddWithValue("Review", textBox1.Text);

                try
                {
                    await command.ExecuteNonQueryAsync();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
