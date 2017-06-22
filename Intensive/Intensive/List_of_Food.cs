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
    public partial class List_of_Food : Form
    {
        public List_of_Food()
        {
            InitializeComponent();
        }

        private void List_of_Food_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            string command = "select title as 'Название', kind as 'Тип', kkal as 'Ккал' from Food";
            ds = Methods.selectTable(command);
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = ds.Tables[0].ToString();
        }
    }
}
