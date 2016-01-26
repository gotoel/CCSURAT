using System;
using Microsoft.Win32;
using System.Management;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CCSURAT_Client
{
    // this class is used to retrieve/store information on the client PC
    // this will also be where command functions are written.
    static class SystemUtils
    {
        public static string SystemInfo()
        { 
            string info = "";
            info += Application.ProductVersion + "|*|";
            info += Environment.MachineName + "|*|";
            info += Environment.UserName + "|*|";
            info += GetOS() + "|*|";
            info += GetCPU();
            return info;
        }

        // Get OS version from registry, other way would be translating it from Environment class
        public static string GetOS()
        {
            RegistryKey reg = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion");
            string OS = (string)reg.GetValue("ProductName");
            return OS;
        }

        public static string GetCPU()
        {
            ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT Name FROM Win32_Processor");
            string CPU = "";
            foreach (ManagementObject m in searcher.Get())
            {

            }
            return CPU;
        }
    }
}
