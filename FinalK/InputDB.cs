using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static FinalK.DataFromDB;

namespace FinalK
{
    internal class InputDB
    {
        private static SqlConnection _connection;
        public static SqlConnection Connection
        {
            get => _connection;
            set => _connection = value;
        }

        public static void addGroup(string groupName)
        {

            // Проверка наличия записи с таким именем
            string checkQuery = "SELECT COUNT(*) FROM Группа_фарм_препарата WHERE [Группа фарм препарата] = @GroupName";
            using (SqlCommand checkCommand = new SqlCommand(checkQuery, Connection))
            {
                checkCommand.Parameters.AddWithValue("@GroupName", groupName);
                int count = (int)checkCommand.ExecuteScalar();

                if (count > 0)
                {
                    // Запись уже существует
                    MessageBox.Show("Данная запись уже существует.");
                }
                else
                {
                    // Добавление записи
                    string insertQuery = "INSERT INTO Группа_фарм_препарата ([Группа фарм препарата]) VALUES (@GroupName)";
                    using (SqlCommand insertCommand = new SqlCommand(insertQuery, Connection))
                    {
                        insertCommand.Parameters.AddWithValue("@GroupName", groupName);
                        int rowsAffected = insertCommand.ExecuteNonQuery();

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
            }
        }
        public static void AddSubstance(string substance)
        {
            string checkQuery = "SELECT COUNT(*) FROM Действующее_вещество WHERE [Действующее вещество] = @GroupName";
            using (SqlCommand checkCommand = new SqlCommand(checkQuery, Connection))
            {
                checkCommand.Parameters.AddWithValue("@GroupName", substance);
                int count = (int)checkCommand.ExecuteScalar();

                if (count > 0)
                {
                    // Запись уже существует
                    MessageBox.Show("Данная запись уже существует.");
                }
                else
                {
                    // Добавление записи
                    string insertQuery = "INSERT INTO Действующее_вещество ([Действующее вещество]) VALUES (@GroupName)";
                    using (SqlCommand insertCommand = new SqlCommand(insertQuery, Connection))
                    {
                        insertCommand.Parameters.AddWithValue("@GroupName", substance);
                        int rowsAffected = insertCommand.ExecuteNonQuery();

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
            }
        }
        public static void AddDoz(string doz)
        {
            string checkQuery = "SELECT COUNT(*) FROM Дозировка WHERE [Дозировка] = @GroupName";
            using (SqlCommand checkCommand = new SqlCommand(checkQuery, Connection))
            {
                checkCommand.Parameters.AddWithValue("@GroupName", doz);
                int count = (int)checkCommand.ExecuteScalar();

                if (count > 0)
                {
                    // Запись уже существует
                    MessageBox.Show("Данная запись уже существует.");
                }
                else
                {
                    // Добавление записи
                    string insertQuery = "INSERT INTO Дозировка ([Дозировка]) VALUES (@GroupName)";
                    using (SqlCommand insertCommand = new SqlCommand(insertQuery, Connection))
                    {
                        insertCommand.Parameters.AddWithValue("@GroupName", doz);
                        int rowsAffected = insertCommand.ExecuteNonQuery();

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

            }

        }
        public static void AddManuf(string manu)
        {
            string checkQuery = "SELECT COUNT(*) FROM Производитель WHERE [Производитель] = @GroupName";
            using (SqlCommand checkCommand = new SqlCommand(checkQuery, Connection))
            {
                checkCommand.Parameters.AddWithValue("@GroupName", manu);
                int count = (int)checkCommand.ExecuteScalar();

                if (count > 0)
                {
                    // Запись уже существует
                    MessageBox.Show("Данная запись уже существует.");
                }
                else
                {
                    // Добавление записи
                    string insertQuery = "INSERT INTO Производитель ([Производитель]) VALUES (@GroupName)";
                    using (SqlCommand insertCommand = new SqlCommand(insertQuery, Connection))
                    {
                        insertCommand.Parameters.AddWithValue("@GroupName", manu);
                        int rowsAffected = insertCommand.ExecuteNonQuery();

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
            }
        }
        public static void AddRec(string rec)
        {
            string checkQuery = "SELECT COUNT(*) FROM Условия_отпуска WHERE [Условие отпуска] = @GroupName";
            using (SqlCommand checkCommand = new SqlCommand(checkQuery, Connection))
            {
                checkCommand.Parameters.AddWithValue("@GroupName", rec);
                int count = (int)checkCommand.ExecuteScalar();

                if (count > 0)
                {
                    // Запись уже существует
                    MessageBox.Show("Данная запись уже существует.");
                }
                else
                {
                    // Добавление записи
                    string insertQuery = "INSERT INTO Условия_отпуска ([Условие отпуска]) VALUES (@GroupName)";
                    using (SqlCommand insertCommand = new SqlCommand(insertQuery, Connection))
                    {
                        insertCommand.Parameters.AddWithValue("@GroupName", rec);
                        int rowsAffected = insertCommand.ExecuteNonQuery();

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
            }
        }
        public static void AddForm(string form)
        {
            string checkQuery = "SELECT COUNT(*) FROM Форма_выпуска WHERE [Форма выпуска] = @GroupName";
            using (SqlCommand checkCommand = new SqlCommand(checkQuery, Connection))
            {
                checkCommand.Parameters.AddWithValue("@GroupName", form);
                int count = (int)checkCommand.ExecuteScalar();

                if (count > 0)
                {
                    // Запись уже существует
                    MessageBox.Show("Данная запись уже существует.");
                }
                else
                {
                    // Добавление записи
                    string insertQuery = "INSERT INTO Форма_выпуска ([Форма выпуска]) VALUES (@GroupName)";
                    using (SqlCommand insertCommand = new SqlCommand(insertQuery, Connection))
                    {
                        insertCommand.Parameters.AddWithValue("@GroupName", form);
                        insertCommand.ExecuteNonQuery();
                    }
                }
            }
        }
        public static void AddProduct(string productName, string instruction, byte[] imageBytes, decimal purchasePrice, decimal sellingPrice,
           int groupId, int conditionsId, int manufacturerId, int formId, int dosageId, int activeSubstanceId)
        {

            string query = @"
        INSERT INTO Препараты ([Название], [Инструкция], [Изображение], [Цена закупочная], [Цена отпуска],
            [Группа фарм препарата], [Условия отпуска], [Производитель], [Форма выпуска], [Дозировка], [Действующее в-во])
        VALUES (@ProductName, @Instruction, @Image, @PurchasePrice, @SellingPrice, @GroupId, @ConditionsId,
            @ManufacturerId, @FormId, @DosageId, @ActiveSubstanceId)";

            using (SqlCommand command = new SqlCommand(query, Connection))
            {
                command.Parameters.AddWithValue("@ProductName", productName);
                command.Parameters.AddWithValue("@Instruction", instruction);
                command.Parameters.AddWithValue("@Image", imageBytes);
                command.Parameters.AddWithValue("@PurchasePrice", purchasePrice);
                command.Parameters.AddWithValue("@SellingPrice", sellingPrice);
                command.Parameters.AddWithValue("@GroupId", groupId);
                command.Parameters.AddWithValue("@ConditionsId", conditionsId);
                command.Parameters.AddWithValue("@ManufacturerId", manufacturerId);
                command.Parameters.AddWithValue("@FormId", formId);
                command.Parameters.AddWithValue("@DosageId", dosageId);
                command.Parameters.AddWithValue("@ActiveSubstanceId", activeSubstanceId);

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



        public static void UpdateSklad(string новоеКоличество, string заданныйКодПрепарата, string заданныйПоставщик)
        {


            string updateQuery = "UPDATE [Склад] SET [Количество] = @НовоеКоличество " +
                                 "WHERE [Код препарата] = @ЗаданныйКодПрепарата AND [Поставщик] = @ЗаданныйПоставщик";

            using (SqlCommand command = new SqlCommand(updateQuery, Connection))
            {
                command.Parameters.AddWithValue("@НовоеКоличество", новоеКоличество);
                command.Parameters.AddWithValue("@ЗаданныйКодПрепарата", заданныйКодПрепарата);
                command.Parameters.AddWithValue("@ЗаданныйПоставщик", заданныйПоставщик);

                int rowsAffected = command.ExecuteNonQuery();
                MessageBox.Show($"Обновлено {rowsAffected} строк.");
            }
        }



    
    }
}
