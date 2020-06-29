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
    public partial class Listelerim : UserControl
    {
        public Listelerim()
        {
            InitializeComponent();
        }

        private void Listelerim_Load(object sender, EventArgs e)
        {
            button1.Text = DBCommands.getListNames(1);
            button2.Text = DBCommands.getListNames(2);
            button3.Text = DBCommands.getListNames(3);
            button4.Text = DBCommands.getListNames(4);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Taskup.selectedList = 1;
            List liste = new List();
            Listelerim listelerim = new Listelerim();
            Taskup.mpanel.Controls.Add(liste);
            liste.BringToFront();
            liste.Dock = DockStyle.Fill;
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Taskup.selectedList = 2;
            List liste = new List();
            Listelerim listelerim = new Listelerim();
            Taskup.mpanel.Controls.Add(liste);
            liste.BringToFront();
            liste.Dock = DockStyle.Fill;
            this.Hide();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Taskup.selectedList = 3;
            List liste = new List();
            Listelerim listelerim = new Listelerim();
            Taskup.mpanel.Controls.Add(liste);
            liste.BringToFront();
            liste.Dock = DockStyle.Fill;
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Taskup.selectedList = 4;
            List liste = new List();
            Listelerim listelerim = new Listelerim();
            Taskup.mpanel.Controls.Add(liste);
            liste.BringToFront();
            liste.Dock = DockStyle.Fill;
            this.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
