using FinalK.enO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FinalK
{
    public partial class Supplier : Form
    {
        public string Value { get; set; }
        public Supplier(bool flag)
        {
            
            
            

            InitializeComponent();
            button3.Visible = flag;

            foreach (SupplierEnt p in DataFromDB.suppliers)
            {
                dataGridView1.Rows.Add(p.Id, p.Name, p.Telephone, p.Address);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            string query = $@"
                INSERT INTO Поставщик ([Название], [Телефон], [Адрес])
                        VALUES
                        ('{textBox1.Text}', '{textBox2.Text}', '{textBox3.Text}');";

            // Создание подключения к базе данных
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Создание команды с параметром
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Добавление параметра

                    // Открытие подключения
                    connection.Open();

                    // Выполнение команды удаления
                    int rowsAffected = command.ExecuteNonQuery();

                    // Проверка количества добавленных записей
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Успешное добавление");
                    }
                    else
                    {
                        MessageBox.Show("УПС, не удалось добавить запись");
                    }
                    // Закрытие подключения
                    connection.Close();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (dataGridView1.SelectedRows.Count > 0)
            {
                int columnIndex = 0; // Индекс выбранного столбца
                int rowIndex = dataGridView1.SelectedCells[0].RowIndex; // Индекс выбранной строки

                object selectedValue = dataGridView1.Rows[rowIndex].Cells[columnIndex].Value;

                if (selectedValue != null)
                {
                    string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

                    try
                    {
                        string query = $@"
                        DELETE FROM Поставщик
                         WHERE [Код поставщика] = {selectedValue}";

                        // Создание подключения к базе данных
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            // Создание команды с параметром
                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                // Добавление параметра

                                // Открытие подключения
                                connection.Open();

                                // Выполнение команды удаления
                                int rowsAffected = command.ExecuteNonQuery();

                                // Проверка количества добавленных записей
                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Успешное добавление");
                                }
                                else
                                {
                                    MessageBox.Show("УПС, не удалось добавить запись");
                                }

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
                else
                {
                    MessageBox.Show("В 1 ячейке выбранного столбца нет значения"); // Значение ячейки равно DBNull
                }
            }
            else
            {
                MessageBox.Show("Выбери поставщика в таблички");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int columnIndex = 0; // Индекс выбранного столбца
                int rowIndex = dataGridView1.SelectedCells[0].RowIndex; // Индекс выбранной строки

                string selectedValue = dataGridView1.Rows[rowIndex].Cells[columnIndex].Value.ToString();

                if (selectedValue != null)
                {
                    Value = selectedValue;
                    DialogResult = DialogResult.OK;
                    Close();
                }
                else
                {
                    MessageBox.Show("Выберите строку продукта");
                }
            }
            else
            {
                MessageBox.Show("Выберите строку продукта");
            }
        }
    }
}
