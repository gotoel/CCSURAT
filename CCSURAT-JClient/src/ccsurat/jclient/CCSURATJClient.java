package ccsurat.jclient;

import java.io.*; 
import java.net.*;
/**
 *
 * @author gotoel
 */
public class CCSURATJClient {

    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        if(args.length > 0 && args[0].equals("-form")) {
            ClientMainForm clientForm = new ClientMainForm();
            clientForm.setVisible(true);
            clientForm.Log("Client started.");
        }
        else {
            NetworkManager connection = new NetworkManager("32.212.129.249", 7777);
            new Thread(() -> connection.Start()).start();
        }
    }
}
