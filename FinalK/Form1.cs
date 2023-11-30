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
    public partial class Form1 : Form
    {
        SqlConnection connection;
        public Form1()
        {
            try
            {
                string connectionString = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
                connection = new SqlConnection(connectionString);
                connection.Open();
                InputDB.Connection = connection;
                MessageBox.Show("Подключились к бд");
            }
            catch
            {
                MessageBox.Show("Не удалось подключиться к базе данных!");
                Close();
            }
            InitializeComponent();
            DataFromDB.selectAllData();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            Tabs tab = new Tabs();
            tab.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Sklad sklad = new Sklad();
            sklad.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Supplier sup = new Supplier(false);
            sup.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Prep prep = new Prep(false);
            prep.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            DataFromDB.selectAllData();
        }
    }
}
