using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FinalK
{
    public partial class AddPrep : Form
    {
        Dictionary<string, int> typeProduct = new Dictionary<string, int>();
        Dictionary<string, int> vacationTerm = new Dictionary<string, int>();
        Dictionary<string, int> manafacturers = new Dictionary<string, int>();
        Dictionary<string, int> forms = new Dictionary<string, int>();
        Dictionary<string, int> doz = new Dictionary<string, int>();
        Dictionary<string, int> activeSubstance = new Dictionary<string, int>();
        

        public AddPrep()
        {
            InitializeComponent();
            foreach (GroupP key in DataFromDB.groupPs)
            {
                typeProduct[key.Name] = key.Id;
                comboBox1.Items.Add(key.Name);
            }
            foreach (Term key in DataFromDB.terms)
            {
                vacationTerm[key.Name] = key.Id;
                comboBox2.Items.Add(key.Name);
            }
            foreach (Manufacturer key in DataFromDB.manufacturers)
            {
                manafacturers[key.Name] = key.Id;
                comboBox3.Items.Add(key.Name);
            }
            foreach (FormP key in DataFromDB.forms)
            {
                forms[key.Name] = key.Id;
                comboBox4.Items.Add(key.Name);
            }
            foreach (Doz key in DataFromDB.doz)
            {
                doz[key.Name] = key.Id;
                comboBox5.Items.Add(key.Name);
            }
            foreach (ActiveSub key in DataFromDB.activeSubs)
            {
                activeSubstance[key.Name] = key.Id;
                comboBox6.Items.Add(key.Name);
            }
            //foreach (PostavshikLink key in post)
            //{
            //    comboBox7.Items.Add(key.Name);
            //}
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Image image = Image.FromFile(textBox3.Text);
            byte[] imageBytes;
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, ImageFormat.Jpeg); // Здесь можно указать нужный формат изображения
                imageBytes = ms.ToArray();
            }
            InputDB.AddProduct(textBox1.Text, textBox2.Text, imageBytes, decimal.Parse(textBox4.Text), decimal.Parse(textBox5.Text),
                typeProduct[comboBox1.SelectedItem.ToString()], vacationTerm[comboBox2.SelectedItem.ToString()],
               manafacturers[comboBox3.SelectedItem.ToString()],
               forms[comboBox4.SelectedItem.ToString()],
              doz[comboBox5.SelectedItem.ToString()],
              activeSubstance[comboBox6.SelectedItem.ToString()]);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Изображения (*.jpg; *.jpeg; *.png; *.gif)|*.jpg;*.jpeg;*.png;*.gif";
                openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    textBox3.Text = openFileDialog.FileName;
                }
            }
        }
    }
}
