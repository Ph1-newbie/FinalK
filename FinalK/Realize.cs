using FinalK.enO;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FinalK
{
    public partial class Realize : Form
    {
        public Realize()
        {
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            // Создание подключения
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"SELECT Препараты.[Название] AS Название_препарата, Препараты.[Код препарата], [Склад].Поставщик, Поставщик.Название ,Склад.[Количество] AS Количество
                                FROM Склад
                                JOIN Препараты ON Склад.[Код препарата] = Препараты.[Код препарата]

                                Join Поставщик On Склад.Поставщик = Поставщик.[Код поставщика]";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            dataGridView1.Rows.Add(reader[0].ToString(), reader[1].ToString(), reader[2].ToString(), reader[3].ToString(), reader[4].ToString());

                        }
                    }
                }



            }
        }

        private void Realize_Load(object sender, EventArgs e)
        {
            
    }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int columnIndex = 1;
                int columnIndex2 = 2;
                int columnIndex3 = 4;
                int rowIndex = dataGridView1.SelectedCells[0].RowIndex; // Индекс выбранной строки
                string selectedValue3 = dataGridView1.Rows[rowIndex].Cells[columnIndex3].Value.ToString();
                string selectedValue = dataGridView1.Rows[rowIndex].Cells[columnIndex].Value.ToString();
                string selectedValue2 = dataGridView1.Rows[rowIndex].Cells[columnIndex2].Value.ToString();

                if (selectedValue != null && selectedValue2 != null)
                {

                    int text = 0;
                    try
                    {
                        text = int.Parse(textBox1.Text);
                        if (text <= int.Parse(selectedValue3))
                        {
                            InputDB.UpdateSklad(textBox1.Text, selectedValue, selectedValue2);
                        }
                        else
                        {
                            MessageBox.Show("Вы не можете реализовать большое количество товара чем находится на вашем складе");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Введите целые цифры");
                        
                    }  
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
