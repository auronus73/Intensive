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
    public partial class Graph : Form
    {
        public Graph()
        {
            InitializeComponent();
        }

        private void Graph_Load(object sender, EventArgs e)
        {
        }

        private void dateTimePicker1_CloseUp(object sender, EventArgs e)
        {
            dateTimePicker2.MaxDate = dateTimePicker1.Value.AddDays(6);
            dateTimePicker2.MinDate = dateTimePicker1.Value.AddDays(1);
            dateTimePicker2.Value = dateTimePicker1.Value.AddDays(1);
        }
    }
}
