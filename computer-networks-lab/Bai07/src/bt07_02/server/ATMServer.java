/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package bt07_02.server;
import java.rmi.registry.LocateRegistry;
import java.rmi.registry.Registry;
/**
 *
 * @author HP
 */
public class ATMServer {

    public static final int PORT = 3457;
    public static final String SERVICE_NAME = "ATMService";

    public static void main(String[] args) {
        try {
            Registry registry =
                    LocateRegistry.createRegistry(PORT);

            ATMService service = new ATMServiceImpl();

            registry.rebind(SERVICE_NAME, service);

            System.out.println(
                    "ATM Server đang chạy tại cổng " + PORT
            );

            System.out.println(
                    "Tên dịch vụ: " + SERVICE_NAME
            );

            System.out.println(
                    "Tài khoản mẫu: CCCD=123456789, mật khẩu=123"
            );

        } catch (Exception ex) {
            System.err.println(
                    "Không thể khởi động ATM Server: "
                            + ex.getMessage()
            );

            ex.printStackTrace();
        }
    }
}
