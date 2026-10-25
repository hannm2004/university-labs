/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package bt07_02.server;

import java.rmi.registry.LocateRegistry;
import java.rmi.Naming;

/**
 *
 * @author HP
 */
public class ATMServer {

    public static void main(String[] args) {
        try {
            // Nếu test giữa nhiều máy trong LAN, bỏ comment dòng dưới và điền IP của máy server:
            // System.setProperty("java.rmi.server.hostname", "192.168.1.10");

            // Tạo RMI Registry trên cổng 1099
            LocateRegistry.createRegistry(1099);
            // Tạo đối tượng triển khai
            ATMService atmService = new ATMServiceImpl();
            // Đăng ký đối tượng vào RMI Registry với tên "ATMService"
            Naming.rebind("rmi://localhost/ATMService", atmService);
            System.out.println("ATM is running...");
        } catch (Exception e) {
            e.printStackTrace();
        }
    }
}
