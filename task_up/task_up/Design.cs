using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace task_up
{       
    public static class Design 
    {      
        public static void clickListeler()
        {           
            showMenu(Taskup.pmenuListeler);
            Taskup.pcolor_bar.BackColor = Color.Magenta;
            Taskup.pbtnListeler.BackColor = Color.Purple;
            Taskup.pbtnAyarlar.BackColor = Color.Transparent;
            Taskup.pbtnHareketler.BackColor = Color.Transparent;
            Taskup.pcolor_bar.Location = new Point(Taskup.pcolor_bar.Location.X, Taskup.pbtnListeler.Location.Y);
        }
        
        public static void clickBasarimlar()
        {
            showMenu(Taskup.pmenuHareketler);
            Taskup.pcolor_bar.BackColor = Color.Yellow;
            Taskup.pbtnHareketler.BackColor = Color.DarkOrange;
            Taskup.pbtnListeler.BackColor = Color.Transparent;
            Taskup.pbtnAyarlar.BackColor = Color.Transparent;
            Taskup.pcolor_bar.Location = new Point(Taskup.pcolor_bar.Location.X, Taskup.pbtnHareketler.Location.Y);
        }

        public static void clickAyarlar()
        {
            showMenu(Taskup.pmenuAyarlar);
            Taskup.pcolor_bar.BackColor = Color.Blue;
            Taskup.pbtnAyarlar.BackColor = Color.SkyBlue;
            Taskup.pbtnListeler.BackColor = Color.Transparent;
            Taskup.pbtnHareketler.BackColor = Color.Transparent;
            Taskup.pcolor_bar.Location = new Point(Taskup.pcolor_bar.Location.X, Taskup.pbtnAyarlar.Location.Y);
        }
        
        public static void showMenu(Panel subMenu)
        {
            if (!subMenu.Visible) { hideMenu(); subMenu.Visible = true; }
            else { subMenu.Visible = false; }
        }

        public static void hideMenu()
        {
            if (Taskup.pmenuListeler.Visible) Taskup.pmenuListeler.Visible = false;
            if (Taskup.pmenuAyarlar.Visible) Taskup.pmenuAyarlar.Visible = false;
            if (Taskup.pmenuHareketler.Visible) Taskup.pmenuHareketler.Visible = false;
        }
    }
}
