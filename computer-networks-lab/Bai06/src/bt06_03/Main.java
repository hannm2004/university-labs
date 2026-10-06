/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package bt06_03;

import java.net.DatagramPacket;
import java.net.DatagramSocket;
import javax.swing.JOptionPane;
import javax.swing.SwingUtilities;

/**
 *
 * @author HP
 */
public class Main {

    public static final int PORT = 1234;

    public static void main(String[] args) {

        // Tạo giao diện Chat
        frmChat app = new frmChat();
        app.setVisible(true);

        // Tạo luồng riêng để nhận dữ liệu
        Thread receiveThread = new Thread(() -> {

            try {
                byte[] buffer = new byte[1024];

                DatagramSocket socket = new DatagramSocket(PORT);

                boolean ktFinish = false;

                while (!ktFinish) {

                    // Tạo packet để nhận dữ liệu
                    DatagramPacket receivePacket
                            = new DatagramPacket(buffer, buffer.length);

                    // Chờ nhận tin nhắn
                    socket.receive(receivePacket);

                    // Chuyển dữ liệu từ byte -> String
                    String stReceive = new String(
                            receivePacket.getData(),
                            0,
                            receivePacket.getLength()
                    );

                    String strContent = app.getContentChat();
                    String newContent = strContent + "\nNhan : " + stReceive;

                    SwingUtilities.invokeLater(() -> {
                        app.setContentChat(newContent);
                    });

                    // Nếu nhận "end." thì kết thúc
                    if (stReceive.equals("end.")) {
                        ktFinish = true;
                    }
                }

                socket.close();

            } catch (Exception ex) {
                JOptionPane.showMessageDialog(null, ex);
            }

        });

        // Bắt đầu Thread
        receiveThread.start();
    }
}
