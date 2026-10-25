/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Interface.java to edit this template
 */
package bt07_02.server;

import java.rmi.Remote;
import java.rmi.RemoteException;
import java.util.List;

/**
 *
 * @author HP
 */

//Giao diện RMI định nghĩa các phương thức server cung cấp
// Giao diện RMI: các phương thức server cung cấp cho máy ATM
public interface ATMService extends Remote {

    // Thêm người dùng mới. Trả về false nếu dữ liệu không hợp lệ hoặc CCCD đã tồn tại
    boolean addUser(String name, String cccd, String stk, String password,
                    double balance, double interestRate) throws RemoteException;

    // Tìm người dùng theo tên và mật khẩu
    String getUserInfo(String name, String password) throws RemoteException;

    // Lấy lịch sử giao dịch (cần CCCD và mật khẩu)
    List<String> getTransactions(String cccd, String password) throws RemoteException;

    // Gửi/rút tiền. transactionType là "gui" hoặc "rut"
    String performTransaction(String cccd, String password,
                              String transactionType, double amount) throws RemoteException;
}
