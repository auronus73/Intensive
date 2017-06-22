using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Intensive
{
    public partial class Main : Form
    {
        public static int temp_for_progress = 0;
        public static int minimum_eat = 2000;
        public Main()
        {
            InitializeComponent();

        }

        public static int  Eat(int value){
            if (value < minimum_eat)
            {
                return (minimum_eat - value);
            }
            else
            {
                return value;
            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            Add_eat f = new Add_eat();
            f.Location = Cursor.Position;
            f.ShowDialog();

            if ((progressBar1.Value + temp_for_progress) < progressBar1.Maximum)
            {
                progressBar1.Increment(temp_for_progress);
                label5.Text = (Eat(progressBar1.Value)).ToString();
                temp_for_progress = 0;
            }
            else
            {
                MessageBox.Show("Кажется вы съели лишнего. Прекращайте");
                progressBar1.Maximum += 2000;
                progressBar1.Increment(temp_for_progress);
                label5.Text = (Eat(progressBar1.Value)).ToString();
                label3.Text = progressBar1.Maximum.ToString();
                temp_for_progress = 0;
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            Graph f = new Graph();
            f.Location = Cursor.Position;
            f.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            List_of_Food f = new List_of_Food();
            f.Location = Cursor.Position;
            f.ShowDialog();
        }
    }
}
