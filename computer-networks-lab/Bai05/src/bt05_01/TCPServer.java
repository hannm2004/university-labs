/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package bt05_01;

import java.net.ServerSocket;
import java.net.Socket;

/**
 *
 * @author HP
 */
public class TCPServer {
    static final int PORT = 1234; //Cổng mà server sẽ lắng nghe kết nối 
    private ServerSocket server = null; //ServerSocket để quản lý từng client

    //Contructor khởi tạo server
    public TCPServer() {
        try {
            server = new ServerSocket(PORT); //Khởi tạo serversocket trên cổng 123
        } catch (Exception e) {
            e.printStackTrace(); //in lỗi ra màn hình nếu serversocket không thể khởi tạo
        }
    }

    //Phương thức hành động lắng nghe và tạo luồng cho mỗi client
    public void action() {
        Socket socket = null; //Biến để lưu kết nối từ client
        int i = 0; //Biến đếm số kết nối
        System.out.println("Serverlistening...");
        try {
            //Vòng lặp chờ kết nối từ Client
            while ((socket = server.accept()) != null) {
                new ServerThread(socket, "Client#" + i);
                System.out.printf("Thread for Client#%d generating...\n", i++);
            }
        } catch (Exception e) {
            e.printStackTrace(); //Xử lí lỗi khi lắng nghe hoặc tạo kết nối
        }
    }

    public static void main(String[] args) {
        new TCPServer().action();
    }
}