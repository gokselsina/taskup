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
    public partial class ListeDuzenle : UserControl
    {
        public ListeDuzenle()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DBCommands.dbConnect();
            using (DBCommands.con)
            {
                using (SQLiteCommand cmd = new SQLiteCommand(DBCommands.con))
                {
                    cmd.CommandText = "update Lists set ListName='"+textBox1.Text+"' Where ListNo=1";
                    cmd.ExecuteNonQuery();
                    DBCommands.dbDisconnect();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DBCommands.dbConnect();
            using (DBCommands.con)
            {
                using (SQLiteCommand cmd = new SQLiteCommand(DBCommands.con))
                {
                    cmd.CommandText = "update Lists set ListName='" + textBox2.Text + "' Where ListNo=2";
                    cmd.ExecuteNonQuery();
                    DBCommands.dbDisconnect();
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DBCommands.dbConnect();
            using (DBCommands.con)
            {
                using (SQLiteCommand cmd = new SQLiteCommand(DBCommands.con))
                {
                    cmd.CommandText = "update Lists set ListName='" + textBox3.Text + "' Where ListNo=3";
                    cmd.ExecuteNonQuery();
                    DBCommands.dbDisconnect();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DBCommands.dbConnect();
            using (DBCommands.con)
            {
                using (SQLiteCommand cmd = new SQLiteCommand(DBCommands.con))
                {
                    cmd.CommandText = "update Lists set ListName='" + textBox4.Text + "' Where ListNo=4";
                    cmd.ExecuteNonQuery();
                    DBCommands.dbDisconnect();
                }
            }
        }

        private void ListeDuzenle_Load(object sender, EventArgs e)
        {
            textBox1.Text = DBCommands.getListNames(1);
            textBox2.Text = DBCommands.getListNames(2);
            textBox3.Text = DBCommands.getListNames(3);
            textBox4.Text = DBCommands.getListNames(4);
        }
    }
}
