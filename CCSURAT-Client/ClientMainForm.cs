using System;
using System.Windows.Forms;

namespace CCSURAT_Client
{
    public partial class ClientMainForm : Form
    {
        // Declare server details.
        private static string serverIP = "127.0.0.1";
        private static int serverPort = 7777;

        private NetworkManager connection;

        public ClientMainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            connection = new NetworkManager(this, serverIP, serverPort);
        }

        private void sendButton_Click(object sender, EventArgs e)
        {
            connection.Write(cmdTextbox.Text);
        }

        public void Log(string s)
        {
            // this is needed for any method on the main form called from the zombie thread.
            if (InvokeRequired)
            {
                this.Invoke(new Action<string>(Log), new object[] { s });
                return;
            }
            console.AppendText("[ " + string.Format("{0:hh:mm:ss tt}", DateTime.Now) + " ] " + s + "\n");
            console.ScrollToCaret();
        }
    }
}
