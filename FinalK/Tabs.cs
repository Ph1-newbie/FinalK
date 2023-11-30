using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalK
{
    public partial class Tabs : Form
    {
        
        public Tabs()
        {
            InitializeComponent();
            foreach (GroupP p in DataFromDB.groupPs)
            {
                comboBox1.Items.Add(p.Name);
            }
            foreach (ActiveSub p in DataFromDB.activeSubs)
            {
                comboBox2.Items.Add(p.Name);
            }
            foreach (Doz p in DataFromDB.doz)
            {
                comboBox3.Items.Add(p.Name);
            }
            foreach (Term p in DataFromDB.terms)
            {
                comboBox6.Items.Add(p.Name);
            }
            foreach (FormP p in DataFromDB.forms)
            {
                comboBox4.Items.Add(p.Name);
            }
            foreach (Manufacturer p in DataFromDB.manufacturers)
            {
                comboBox5.Items.Add(p.Name);
            }

        }

        private void Tabs_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (group.Text != "")
            {
                InputDB.addGroup(group.Text);
            }
            else
            {
                MessageBox.Show("Введите значение поля");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (activeS.Text != "")
            {
                InputDB.AddSubstance(activeS.Text);
            }
            else
            {
                MessageBox.Show("Введите значение поля");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (doz.Text != "") InputDB.AddDoz(doz.Text);
            else
            {
                MessageBox.Show("Введите значение поля");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (term.Text != "") InputDB.AddRec(term.Text);
            else
            {
                MessageBox.Show("Введите значение поля");
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (form.Text != "") InputDB.AddForm(form.Text);
            else
            {
                MessageBox.Show("Введите значение поля");
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (manuf.Text != "") InputDB.AddManuf(manuf.Text);
            else
            {
                MessageBox.Show("Введите значение поля");
            }
        }

        private void button9_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            try
            {
                // Создание SQL-запроса на удаление
                string query = "DELETE FROM Дозировка WHERE [Дозировка] = @Название";

                // Создание подключения к базе данных
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Создание команды с параметром
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Добавление параметра
                        command.Parameters.AddWithValue("@Название", comboBox3.SelectedItem);

                        // Открытие подключения
                        connection.Open();

                        // Выполнение команды удаления
                        command.ExecuteNonQuery();

                        // Закрытие подключения
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            try
            {
                // Создание SQL-запроса на удаление
                string query = "DELETE FROM [Группа_фарм_препарата] WHERE [Группа фарм препарата] = @Название";

                // Создание подключения к базе данных
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Создание команды с параметром
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Добавление параметра
                        command.Parameters.AddWithValue("@Название", comboBox1.SelectedItem);

                        // Открытие подключения
                        connection.Open();

                        // Выполнение команды удаления
                        command.ExecuteNonQuery();

                        // Закрытие подключения
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            try
            {
                // Создание SQL-запроса на удаление
                string query = "DELETE FROM [Действующее_вещество] WHERE [Действующее вещество] = @Название";

                // Создание подключения к базе данных
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Создание команды с параметром
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Добавление параметра
                        command.Parameters.AddWithValue("@Название", comboBox2.SelectedItem);

                        // Открытие подключения
                        connection.Open();

                        // Выполнение команды удаления
                        command.ExecuteNonQuery();

                        // Закрытие подключения
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            try
            {
                // Создание SQL-запроса на удаление
                string query = "DELETE FROM Условия_отпуска WHERE [Условие отпуска] = @Название";

                // Создание подключения к базе данных
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Создание команды с параметром
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Добавление параметра
                        command.Parameters.AddWithValue("@Название", comboBox6.SelectedItem);

                        // Открытие подключения
                        connection.Open();

                        // Выполнение команды удаления
                        command.ExecuteNonQuery();

                        // Закрытие подключения
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }

        }

        private void button11_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            try
            {
                // Создание SQL-запроса на удаление
                string query = "DELETE FROM [Форма_выпуска] WHERE [Форма выпуска] = @Название";

                // Создание подключения к базе данных
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Создание команды с параметром
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Добавление параметра
                        command.Parameters.AddWithValue("@Название", comboBox4.SelectedItem);

                        // Открытие подключения
                        connection.Open();

                        // Выполнение команды удаления
                        command.ExecuteNonQuery();

                        // Закрытие подключения
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }

        private void button12_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            try
            {
                // Создание SQL-запроса на удаление
                string query = "DELETE FROM [Производитель] WHERE [Производитель] = @Название";

                // Создание подключения к базе данных
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Создание команды с параметром
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Добавление параметра
                        command.Parameters.AddWithValue("@Название", comboBox5.SelectedItem);

                        // Открытие подключения
                        connection.Open();

                        // Выполнение команды удаления
                        command.ExecuteNonQuery();

                        // Закрытие подключения
                        connection.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
        }
    }
}
