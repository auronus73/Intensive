using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Intensive
{
    public partial class Add_eat : Form
    {
        public int k = 0;
        public int k1 = 0;
        int kkal = 0;
        double kkal_product = 0;
        
        public Add_eat()
        {
            InitializeComponent();
            this.Size = new Size(300, 120);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            k++;
            if (k == 1)
            {
                this.Size = new Size(300, 180);
                label3.Visible = true;
                comboBox2.Visible = true;
            }

            comboBox2.Items.Clear();
            try
            {
                List<string> list = Methods.Insert_Title(comboBox1.Text);
                foreach (string title in list)
                {
                    comboBox2.Items.Add(title);
                }
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }

            switch (comboBox1.Text)
            {
                case "Напитки": label1.Text = "мл"; break;
                case "Еда": label1.Text = "гр"; break;
            }
           
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            k1++;
            if (k1 == 1)
            {
                this.Size = new Size(300, 250);
                label1.Visible = true;
                label4.Visible = true;
                textBox1.Visible = true;
            }

            try
            {
                Methods.connect.Open();
                SQLiteCommand command = new SQLiteCommand(String.Format("select kkal from food where title='{0}'", comboBox2.Text), Methods.connect);
                SQLiteDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    kkal = reader.GetInt32(0);
                }
                Methods.connect.Close();
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }
        
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar <= 47 || e.KeyChar >= 58) && e.KeyChar != 8)
                e.Handled = true;
        }

        private void Add_eat_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            { MessageBox.Show("Заполните поле"); }
            else
            {
                Main.temp_for_progress += Convert.ToInt32(kkal_product);
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                kkal_product = (Convert.ToDouble(textBox1.Text.ToString())/100) * kkal;
                label5.Text = kkal_product.ToString();
            }
        }

    }
}
