using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Management;
using System.Net;
using System.Net.NetworkInformation;

namespace CCSURAT_Server
{
    // Monitors performance of the server.
    class PerformanceMonitor
    {
        // Process
        Process curProcess;

        // CPU perf
        private PerformanceCounter totalProcessTime;

        // Network
        private PerformanceCounter bytesSent;
        private PerformanceCounter bytesReceived;
        public NetworkInterface mainNIC;

        public PerformanceMonitor()
        {
            // Get current process
            curProcess = Process.GetCurrentProcess();

            // initialize performance counters
            // CPU
            totalProcessTime = new PerformanceCounter("Process","% Processor Time", Process.GetCurrentProcess().ProcessName);

            // Network
            mainNIC = GetMainNIC();
            bytesSent = new PerformanceCounter("Network Interface", "Bytes Sent/sec", mainNIC.Description);
            bytesReceived = new PerformanceCounter("Network Interface", "Bytes Received/sec", mainNIC.Description);
        }

        // returns the current CPU usage % (the onedisplayed in task manager)
        public int GetCpuUsage()
        {
            curProcess.Refresh();
            return (int)(totalProcessTime.NextValue() / Environment.ProcessorCount);
        }

        // Get used ram in MB
        public long GetRamUsage()
        {
            GetMainNIC();
            curProcess.Refresh();
            return (curProcess.WorkingSet64 / 1024 / 1024);
        }

        public int GetUpSpeed()
        {
            return (int)(bytesSent.NextValue() / 1024);
        }

        public int GetDownSpeed()
        {
            return (int)(bytesReceived.NextValue() / 1024);
        }

        private NetworkInterface GetMainNIC()
        {
            foreach (NetworkInterface nic in NetworkInterface.GetAllNetworkInterfaces())
            {
                foreach(GatewayIPAddressInformation g in nic.GetIPProperties().GatewayAddresses)
                {
                    if (!g.Address.ToString().Equals("0.0.0.0") && nic.OperationalStatus.ToString().Equals("Up"))
                        return nic;
                }
            }
            return null;
        }
    }
}
