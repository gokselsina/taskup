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
    public partial class GörevDüzenle : UserControl
    {
        public static int id;
        public GörevDüzenle()
        {
            InitializeComponent();
        }

        private void GörevDüzenle_Load(object sender, EventArgs e)
        {
            textBox1.Text = DBCommands.getData("Title", id);
            comboBox1.Text = DBCommands.getData("Priority", id);
            dateTimePicker1.Text = DBCommands.getData("Date", id);
            richTextBox1.Text = DBCommands.getData("Text", id);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string date = dateTimePicker1.Value.ToString("yyyy-MM-dd");
            DBCommands.updateTask(date,textBox1.Text,richTextBox1.Text,comboBox1.Text.ToString(),id);
            GelismisArama.refresh();
            this.Hide();
        }
    }
}
