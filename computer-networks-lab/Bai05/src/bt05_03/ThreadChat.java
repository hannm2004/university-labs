/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package bt05_03;

import java.io.IOException;
import java.net.ServerSocket;
import java.net.Socket;
import java.util.Scanner;

/**
 *
 * @author HP
 */
public class ThreadChat implements Runnable {

    private Scanner in = null;
    private Socket socket = null;
    public frmClient chat = null;
    ServerSocket server = null;

    public ThreadChat() {
        try {
            server = new ServerSocket(1234);
        } catch (Exception e) {
            e.printStackTrace();
        }
        new Thread(this).start();
    }

    public void run() {
        try {
            while (true) {
                while ((socket = server.accept()) != null) {
                    this.in = new Scanner(this.socket.getInputStream());
                    String chuoi = in.nextLine().trim();
                    chat.Hienthi(chuoi + "\n");
                }
            }
        } catch (Exception e) {

        } finally {
            try {socket.close();} catch(IOException e){}
            }
        }
    
}
