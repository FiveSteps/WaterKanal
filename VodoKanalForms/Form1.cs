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

        private void button1_Click(object sender, EventArgs e)
        {
            //Вывод данных
            string table1 = "Fucker"; //Имя таблицы
            string ssql = $"SELECT  * FROM {table1} "; //ЗАпрос 

            string connectionString = @"Data Source=DESKTOP-EE4RPR4\\SQLEXPRESS;Initial Catalog=commentDB;Integrated Security=True"; //prak - имя базы данных(Поменять на свою)
            SqlConnection conn = new SqlConnection(connectionString); // Подключение к БД
            conn.Open();// Открытие Соединения

            SqlCommand command = new SqlCommand(ssql, conn);// Объект вывода запросов
            SqlDataReader reader = command.ExecuteReader(); // Выполнение запроса вывод информации

            while (reader.Read()) //В цикле вывести всю информацию из таблици
            {
                textBox1.Text += reader[0];
                textBox1.Text += reader[1];
                textBox1.Text += reader[2];
            }
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
