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

namespace task_up
{
    public partial class Taskup : Form
     {
        public static Button pbtnListeler = new Button();
        public static Button pbtnHareketler = new Button();
        public static Button pbtnAyarlar = new Button();
        public static Panel pcolor_bar = new Panel();
        public static Panel pmenuListeler = new Panel();
        public static Panel pmenuHareketler = new Panel();
        public static Panel pmenuAyarlar = new Panel();
        public static Panel mpanel = new Panel();

        public static int selectedList;

        public Taskup()
        {
            InitializeComponent();
        }
        private void Taskup_Load(object sender, EventArgs e)
        {
            mpanel = panel;
            pbtnListeler = btnListeler;
            pbtnHareketler = btnHareketler;
            pbtnAyarlar = btnAyarlar;
            pcolor_bar = color_bar;
            pmenuListeler = menuListeler;
            pmenuHareketler = menuHareketler;
            pmenuAyarlar = menuAyarlar;
            DBCommands.dbCreate();
        }

        public void btnListeler_Click(object sender, EventArgs e)
        {
            Design.clickListeler();
        }

        private void btnHareketler_Click(object sender, EventArgs e)
        {
            Design.clickBasarimlar();
        }

        private void btnAyarlar_Click(object sender, EventArgs e)
        {
            Design.clickAyarlar();
        }

        private void pictureBox1_MouseLeave(object sender, EventArgs e)
        {
            pictureBox1.Height = 80;
        }

        private void pictureBox1_MouseEnter(object sender, EventArgs e)
        {
            pictureBox1.Height = 100;
        }

        Listelerim listelerim = new Listelerim();
        List liste = new List();
        private void btnListelerListelerim(object sender, EventArgs e)
        {
            panel.Controls.Add(listelerim);
            panel.Controls.Remove(liste);
            listelerim.BringToFront();
            listelerim.Dock = DockStyle.Fill;
            listelerim.Show();
        }

        private void panel_Paint(object sender, PaintEventArgs e)
        {

        }
        GelismisArama ga = new GelismisArama();
        private void button4_Click(object sender, EventArgs e)
        {
            panel.Controls.Clear();
            panel.Controls.Add(ga);
            ga.BringToFront();
            ga.Dock = DockStyle.Fill;
            ga.Show();
        }
        ListeDuzenle ld = new ListeDuzenle();
        private void button5_Click(object sender, EventArgs e)
        {
            panel.Controls.Clear();
            panel.Controls.Add(ld);
            ld.BringToFront();
            ld.Dock = DockStyle.Fill;
            ld.Show();
        }
        Hareketler hr = new Hareketler();
        private void button12_Click(object sender, EventArgs e)
        {
            panel.Controls.Clear();
            panel.Controls.Add(hr);
            hr.BringToFront();
            hr.Dock = DockStyle.Fill;
            hr.Show();
            Hareketler.historyView();
        }
    }
}