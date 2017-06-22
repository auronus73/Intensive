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
    public partial class Graph : Form
    {
        public Graph()
        {
            InitializeComponent();
        }

        private void Graph_Load(object sender, EventArgs e)
        {
            string min_date = "";
            string max_date = "";

            Methods.connect.Open();
            SQLiteCommand command = new SQLiteCommand("select Min(date) from Daily_consumption ", Methods.connect);
            SQLiteDataReader reader = command.ExecuteReader();
            while (reader.Read())
            { min_date = reader.GetString(0); }
            Methods.connect.Close();

            Methods.connect.Open();
            command = new SQLiteCommand("select Max(date) from Daily_consumption ", Methods.connect);
            reader = command.ExecuteReader();
            while (reader.Read())
            { max_date = reader.GetString(0); }
            Methods.connect.Close();

            dateTimePicker1.MinDate = Convert.ToDateTime(min_date);
            dateTimePicker1.MaxDate = Convert.ToDateTime(max_date);

        }

        private void dateTimePicker1_CloseUp(object sender, EventArgs e)
        {
            dateTimePicker2.Enabled = true;

            dateTimePicker2.MaxDate = dateTimePicker1.Value.AddDays(6);
            dateTimePicker2.MinDate = dateTimePicker1.Value.AddDays(1);
            dateTimePicker2.Value = dateTimePicker1.Value.AddDays(1);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (dateTimePicker1.Value > dateTimePicker2.Value)
                MessageBox.Show("Начальное значение должно быть меньше конечного!");
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            
        }
    }
}
