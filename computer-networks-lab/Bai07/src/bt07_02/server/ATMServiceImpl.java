/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package bt07_02.server;

import java.rmi.RemoteException;
import java.rmi.server.UnicastRemoteObject;
import java.text.SimpleDateFormat;
import java.util.ArrayList;
import java.util.Date;
import java.util.HashMap;
import java.util.List;
import java.util.Locale;

/**
 *
 * @author HP
 */
// Lớp triển khai giao diện ATMService
public class ATMServiceImpl extends UnicastRemoteObject implements ATMService {

    // Quản lý người dùng theo CCCD
    private final HashMap<String, User> users = new HashMap<>();

    // Quản lý lịch sử giao dịch theo CCCD
    private final HashMap<String, List<String>> transactions = new HashMap<>();

    public ATMServiceImpl() throws RemoteException {
        super();
    }

    // synchronized: nhiều máy ATM có thể gọi cùng lúc, mỗi lời gọi chạy trên một luồng riêng
    @Override
    public synchronized boolean addUser(String name, String cccd, String stk, String password,
                                        double balance, double interestRate) throws RemoteException {
        if (name == null || cccd == null || stk == null || password == null) {
            return false;
        }
        name = name.trim();
        cccd = cccd.trim();
        stk = stk.trim();
        if (name.isEmpty() || cccd.isEmpty() || stk.isEmpty() || password.isEmpty()) {
            return false;
        }
        if (Double.isNaN(balance) || Double.isInfinite(balance) || balance < 0
                || Double.isNaN(interestRate) || Double.isInfinite(interestRate) || interestRate < 0) {
            return false;
        }
        if (users.containsKey(cccd)) {
            return false;   // CCCD đã tồn tại
        }

        users.put(cccd, new User(name, cccd, stk, password, balance, interestRate));
        transactions.put(cccd, new ArrayList<>());
        addHistory(cccd, "Tạo tài khoản, số dư ban đầu: " + money(balance));
        return true;
    }

    @Override
    public synchronized String getUserInfo(String name, String password) throws RemoteException {
        if (name != null && password != null) {
            for (User u : users.values()) {
                if (u.getName().equalsIgnoreCase(name.trim()) && u.getPassword().equals(password)) {
                    return "Tên: " + u.getName()
                            + ", CCCD: " + u.getCccd()
                            + ", STK: " + u.getStk()
                            + ", Số dư: " + money(u.getBalance())
                            + ", Lãi suất: " + u.getInterestRate() + "%";
                }
            }
        }
        return "Không tìm thấy người dùng hoặc sai mật khẩu!";
    }

    @Override
    public synchronized List<String> getTransactions(String cccd, String password) throws RemoteException {
        List<String> kq = new ArrayList<>();
        User u = (cccd == null) ? null : users.get(cccd.trim());
        if (u == null || password == null || !u.getPassword().equals(password)) {
            kq.add("Sai CCCD hoặc mật khẩu!");
            return kq;
        }
        kq.addAll(transactions.get(u.getCccd()));   // trả về bản sao
        return kq;
    }

    @Override
    public synchronized String performTransaction(String cccd, String password,
                                                  String transactionType, double amount)
            throws RemoteException {
        User user = (cccd == null) ? null : users.get(cccd.trim());
        if (user == null || password == null || !user.getPassword().equals(password)) {
            return "Giao dịch thất bại! Sai CCCD hoặc mật khẩu";
        }
        if (Double.isNaN(amount) || Double.isInfinite(amount) || amount <= 0) {
            return "Giao dịch thất bại! Số tiền phải lớn hơn 0";
        }
        if (transactionType == null) {
            return "Giao dịch thất bại! Loại giao dịch không hợp lệ";
        }

        if (transactionType.equalsIgnoreCase("rut")) {
            if (user.getBalance() < amount) {
                return "Số dư không đủ!";
            }
            user.setBalance(user.getBalance() - amount);
            addHistory(user.getCccd(), "Rút tiền: - " + money(amount));
        } else if (transactionType.equalsIgnoreCase("gui")) {
            user.setBalance(user.getBalance() + amount);
            addHistory(user.getCccd(), "Gửi tiền: + " + money(amount));
        } else {
            return "Giao dịch thất bại! Loại giao dịch không hợp lệ";
        }
        return "Giao dịch thành công! Số dư mới: " + money(user.getBalance());
    }

    // Ghi một dòng lịch sử: ngày giờ | nội dung
    private void addHistory(String cccd, String noiDung) {
        String ngay = new SimpleDateFormat("dd/MM/yyyy HH:mm:ss").format(new Date());
        transactions.get(cccd).add(ngay + " | " + noiDung);
    }

    // Định dạng tiền: 1,500,000.00 VND
    private String money(double v) {
        return String.format(Locale.US, "%,.2f VND", v);
    }
}
