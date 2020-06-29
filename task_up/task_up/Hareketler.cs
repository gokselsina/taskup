using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task_up
{
    public partial class Hareketler : UserControl
    {
        public Hareketler()
        {
            InitializeComponent();
        }

        private void Hareketler_LocationChanged(object sender, EventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public static DataGridView da = new DataGridView();
        public static void historyView()
        {
            DataSet ds = new DataSet();
            ds = DBCommands.getList("History");
            da.DataSource = ds.Tables[0];
        }
        private void Hareketler_Load(object sender, EventArgs e)
        {
            da = dataGridView1;
            historyView();
        }
    }
}
