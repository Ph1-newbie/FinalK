using FinalK.enO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FinalK
{

    public partial class Prep : Form
    {
        public string Value { get; set; }
        public Prep(bool flag)
        {
            InitializeComponent();
            if (flag)
            {
                button1.Visible = false;
                button2.Visible = true;
            }
            else
            {
                button2.Visible = false;
                button1.Visible = true;
            }
            
            foreach(Product p in DataFromDB.products)
            {
                dataGridView1.Rows.Add(p.Id, p.Name, p.Insctruction, "Кликни, что бы открыть изображение", p.PriceB, p.PriceS, p.GroupP.Name, p.Term.Name,
                    p.Manufacturer.Name, p.FormP.Name, p.Doz.Name, p.ActiveSub.Name);
            }
        }

        private void Prep_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddPrep ap = new AddPrep();
            ap.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
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
