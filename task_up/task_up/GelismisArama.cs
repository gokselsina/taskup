using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace task_up
{
    public partial class GelismisArama : UserControl
    {
        public GelismisArama()
        {
            InitializeComponent();
        }

        public static int no=1;
        String oncelik="-";
        String durum="-";
        public static DataGridView dg = new DataGridView();
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void GelismisArama_Load(object sender, EventArgs e)
        {
            radioButton1.Text = DBCommands.getListNames(1);
            radioButton2.Text = DBCommands.getListNames(2);
            radioButton3.Text = DBCommands.getListNames(3);
            radioButton4.Text = DBCommands.getListNames(4);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            SQLiteConnection con = new SQLiteConnection("Data Source=taskup.db;Version=3;");
            String cmdtext = "select * from Tasks where ListNo="; cmdtext += no.ToString();
            if (oncelik != "-") cmdtext += " AND Priority='" + oncelik+"'";
            if (durum != "-") cmdtext += " AND Info='" + durum + "'"; 
            cmdtext += " AND Date>='" + dateTimePicker1.Value.ToString("yyyy-MM-dd")+"'";
            cmdtext += " AND Date<='" + dateTimePicker2.Value.ToString("yyyy-MM-dd")+"'";
            SQLiteDataAdapter da = new SQLiteDataAdapter(cmdtext, con);
            DataSet ds = new DataSet();
            con.Open();
            da.Fill(ds, "Lists");
            con.Close();
            dataGridView1.DataSource = ds.Tables[0];
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            no = 1;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            no = 2;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            no = 3;
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            no = 4;
        }

        private void radioButton5_CheckedChanged(object sender, EventArgs e)
        {
            oncelik = "Yüksek";
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            oncelik = "Normal";
        }

        private void radioButton7_CheckedChanged(object sender, EventArgs e)
        {
            oncelik = "Düşük";
        }

        private void radioButton12_CheckedChanged(object sender, EventArgs e)
        {
            durum = "Tamamlandı";
        }

        private void radioButton11_CheckedChanged(object sender, EventArgs e)
        {
            durum = "Devam Ediyor";
        }

        private void radioButton10_CheckedChanged(object sender, EventArgs e)
        {
            durum = "-";
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void radioButton8_CheckedChanged(object sender, EventArgs e)
        {
            oncelik = "-";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow drow in dataGridView1.SelectedRows)
            {
                String txt = drow.Cells[4].Value.ToString();
                MessageBox.Show(txt);
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
        public static void refresh()
        {
            DataSet ds = DBCommands.getList("Tasks", "ListNo", no.ToString());

            dg.DataSource = ds.Tables[0];
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
    }
}
