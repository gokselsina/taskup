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
    public partial class List : UserControl
    {
        public List()
        {
            InitializeComponent();
        }
        public static DataGridView dg;
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            YeniGörev yeni = new YeniGörev();
            Taskup.mpanel.Controls.Add(yeni);
            yeni.BringToFront();
            yeni.Dock = DockStyle.Fill;
        }
        
        private void List_Load(object sender, EventArgs e)
        {
            dg = dataGridView1;
            DataSet ds = DBCommands.getList("Tasks", "ListNo", Taskup.selectedList.ToString());
            dataGridView1.DataSource = ds.Tables[0];
            button5.Text = DBCommands.getListNames(Taskup.selectedList);
        }

        public static void refresh()
        {
            DataSet ds = DBCommands.getList("Tasks", "ListNo", Taskup.selectedList.ToString());
            dg.DataSource = ds.Tables[0];
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow drow in dataGridView1.SelectedRows)
            {
                int id = Convert.ToInt32(drow.Cells[0].Value);
                DBCommands.deleteTask(id.ToString());
                refresh();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow drow in dataGridView1.SelectedRows)
            {
                int id = Convert.ToInt32(drow.Cells[0].Value);
                DBCommands.compTask(id.ToString());               
                DBCommands.historyWrite(id);
                refresh();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow drow in dataGridView1.SelectedRows)
            {
                int id = Convert.ToInt32(drow.Cells[0].Value);
                GörevDüzenle gd = new GörevDüzenle();
                GörevDüzenle.id = id;
                Taskup.mpanel.Controls.Add(gd);
                gd.BringToFront();
                gd.Dock = DockStyle.Fill;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow drow in dataGridView1.SelectedRows)
            {
                String txt = drow.Cells[3].Value.ToString();
                MessageBox.Show(txt);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {

        }
    }
}
