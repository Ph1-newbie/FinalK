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
using static FinalK.DataFromDB;

namespace FinalK
{
    public partial class Sklad : Form
    {
        public Sklad()
        {
            InitializeComponent();
            foreach (DataFromDB.sprep key in DataFromDB.skladQuant.Keys)
            {
                dataGridView1.Rows.Add(key.id,key.name, DataFromDB.skladQuant[key]);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
                if (e.RowIndex >= 0) // Убедитесь, что клик был выполнен по строке (а не по заголовку столбца)
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    string value = row.Cells[0].Value.ToString(); // Получаем значение из первого столбца
                    List<string> val = DataFromDB.GetPrepSkladDesc(value);
                    string final = "";
                    foreach(string v in val)
                    {
                    final += v +"\n";
                    }
                    MessageBox.Show(final);
                }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Prep prep = new Prep(true);
            prep.ShowDialog();
            if (prep.DialogResult == DialogResult.OK)
            {
                textBox1.Text = prep.Value;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Supplier sup = new Supplier(true);
            sup.ShowDialog();
            if (sup.DialogResult == DialogResult.OK)
            {
                textBox2.Text = sup.Value;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            // Создание подключения
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();

                    // Создание команды SQL для вставки записи
                    string query = "INSERT INTO Склад ([Код препарата], [Количество], [Поставщик]) VALUES (@КодПрепарата, @Количество, @Поставщик)";

                    // Создание команды с параметрами
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Задание значений параметров
                        command.Parameters.AddWithValue("@КодПрепарата", textBox1.Text); // Замените 1 на реальное значение кода препарата
                        command.Parameters.AddWithValue("@Количество", textBox3.Text); // Замените 10 на реальное значение количества
                        command.Parameters.AddWithValue("@Поставщик", textBox2.Text); // Замените 1 на реальное значение кода поставщика

                        // Выполнение команды
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
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка: " + ex.Message);
                }
            }

        
        }
    }
    
}
