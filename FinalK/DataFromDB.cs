using FinalK.enO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalK
{
    internal class DataFromDB
    {
        const string connectionString = "Data Source=DESKTOP-ERCN2KO\\SQLEXPRESS;Initial Catalog=DataAptekaK;Integrated Security=True;";
        public static List<Product> products;
        public static List<GroupP> groupPs;
        public static List<ActiveSub> activeSubs;
        public static List<Doz> doz;
        public static List<Manufacturer> manufacturers;
        public static List<Term> terms;
        public static List<FormP> forms;
        public static List<SupplierEnt> suppliers;

        public struct sprep
        {
            public string name;
            public int id;
        }
        
        public static Dictionary<sprep, int> skladQuant;


        public static void selectAllData()
        {
            getPrep();
            getGroupPs();
            getActiveSub();
            getDoz();
            geManufacturer();
            getTerm();
            getForms();
            getSupplier();
            GetPrepQuant();
        }
        public static void getPrep()
        {
            products = new List<Product>();
            string sqlQuery = @"SELECT Препараты.*,
                                       Группа_фарм_препарата.[Группа фарм препарата] AS Группа_фарм_препарата_Название,
                                       Условия_отпуска.[Условие отпуска] AS Условия_отпуска_Название,
                                       Производитель.Производитель AS Производитель_Название,
                                       Форма_выпуска.[Форма выпуска] AS Форма_выпуска_Название,
                                       Дозировка.Дозировка AS Дозировка_Название,
                                       Действующее_вещество.[Действующее вещество] AS Действующее_вещество_Название
                                FROM Препараты
                                LEFT JOIN Группа_фарм_препарата ON Препараты.[Группа фарм препарата] = Группа_фарм_препарата.ID
                                LEFT JOIN Условия_отпуска ON Препараты.[Условия отпуска] = Условия_отпуска.ID
                                LEFT JOIN Производитель ON Препараты.[Производитель] = Производитель.ID
                                LEFT JOIN Форма_выпуска ON Препараты.[Форма выпуска] = Форма_выпуска.ID
                                LEFT JOIN Дозировка ON Препараты.[Дозировка] = Дозировка.ID
                                LEFT JOIN Действующее_вещество ON Препараты.[Действующее в-во] = Действующее_вещество.ID";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Создание объекта SqlCommand с SQL-запросом и подключением
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    // Создание объекта SqlDataReader для чтения результатов запроса
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        // Чтение данных из результата запроса
                        while (reader.Read())
                        {
                            Image image = null;
                            if (!reader.IsDBNull(3))
                            {
                                byte[] imageData = (byte[])reader[3];
                                using (MemoryStream stream = new MemoryStream(imageData))
                                {

                                    image = Image.FromStream(stream);


                                }
                            }
                            products.Add(new Product(
                                (int)reader[0],
                                reader[1].ToString(),
                                reader[2].ToString(),
                                image,
                                (decimal)reader[4],
                                (decimal)reader[5],
                                new GroupP((int)reader[6], reader[12].ToString()),
                                new Term((int)reader[7], reader[13].ToString()),
                                new Manufacturer((int)reader[8], reader[14].ToString()),
                                new FormP((int)reader[9], reader[15].ToString()),
                                new Doz((int)reader[10], reader[16].ToString()),
                                new ActiveSub((int)reader[11], reader[17].ToString())
                                )); ;
                            
                        }
                    }
                }
                connection.Close();
            }
        }

        public static void getGroupPs()
        {
            groupPs = new List<GroupP>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Группа_фарм_препарата";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            groupPs.Add(new GroupP((int)reader[0], reader[1].ToString())); 
                           
                        }
                    }
                }
                connection.Close();
            }

        }
        public static void getActiveSub()
        {
            activeSubs = new List<ActiveSub>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Действующее_вещество";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            activeSubs.Add(new ActiveSub((int)reader[0], reader[1].ToString()));

                        }
                    }
                }
                connection.Close();
            }

        }
        public static void getDoz()
        {
            doz = new List<Doz>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Дозировка";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            doz.Add(new Doz((int)reader[0], reader[1].ToString()));

                        }
                    }
                }
                connection.Close();
            }
            
        }
        public static void geManufacturer()
        {
            manufacturers = new List<Manufacturer>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Производитель";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            manufacturers.Add(new Manufacturer((int)reader[0], reader[1].ToString()));

                        }
                    }
                }
                connection.Close();
            }

        }
        public static void getTerm()
        {
            terms = new List<Term>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Условия_отпуска";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            terms.Add(new Term((int)reader[0], reader[1].ToString()));

                        }
                    }
                }
                connection.Close();
            }

        }
        public static void getForms()
        {
            forms = new List<FormP>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Форма_выпуска";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            forms.Add(new FormP((int)reader[0], reader[1].ToString()));

                        }
                    }
                }
                connection.Close();
            }

        }

        public static void getSupplier()
        {
            suppliers = new List<SupplierEnt>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT * FROM Поставщик";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            suppliers.Add(new SupplierEnt(
                                                (int)reader[0],
                                                reader[1].ToString(),
                                                reader[2].ToString(),
                                                reader[3].ToString()
                                                ));

                        }
                    }
                }
                connection.Close();
            }
        }

        public static void GetPrepQuant()
        {
           skladQuant = new Dictionary<sprep, int>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = @"SELECT Препараты.[Название] AS Название_препарата, Препараты.[Код препарата], SUM(Склад.[Количество]) AS Общее_количество
                                FROM Склад
                                JOIN Препараты ON Склад.[Код препарата] = Препараты.[Код препарата]
                                GROUP BY Препараты.[Название],Препараты.[Код препарата];";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            sprep s = new sprep();
                            s.name = reader[0].ToString();
                            s.id = (int)reader[1];
                            skladQuant[s] = (int)reader[2];

                        }
                    }
                }
                connection.Close();
            }
        }



        public static List<string> GetPrepSkladDesc(string id)
        {
            List<string> s = new List<string>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = $@"SELECT Препараты.Название AS Название_препарата, Склад.Количество AS Количество, Склад.Поставщик AS Код_поставщика
                                FROM Склад
                                JOIN Препараты ON Склад.[Код препарата] = Препараты.[Код препарата]
                                WHERE Препараты.[Код препарата] = {id}";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            s.Add($"{reader[0]} в количестве {reader[1]} от поставщика {reader[2]}");
                        }
                    }
                }
                connection.Close();
                return s;
            }
        }
    }
}
