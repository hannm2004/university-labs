/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package bt07_02.server;
import java.rmi.RemoteException;
import java.rmi.server.UnicastRemoteObject;
import java.time.LocalDateTime;
import java.time.format.DateTimeFormatter;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;
/**
 *
 * @author HP
 */
public class ATMServiceImpl
        extends UnicastRemoteObject
        implements ATMService {

    private final Map<String, User> users = new HashMap<>();

    private final Map<String, List<String>> transactions =
            new HashMap<>();

    private final DateTimeFormatter formatter =
            DateTimeFormatter.ofPattern("dd/MM/yyyy HH:mm:ss");

    public ATMServiceImpl() throws RemoteException {
        super();

        // Tài khoản mẫu
        users.put(
                "123456789",
                new User(
                        "Nguyen Van A",
                        "123456789",
                        "100001",
                        "123",
                        1_000_000
                )
        );

        transactions.put("123456789", new ArrayList<>());
    }

    @Override
    public synchronized boolean addUser(
            String name,
            String cccd,
            String stk,
            String password,
            double balance
    ) throws RemoteException {

        if (name == null || name.trim().isEmpty()
                || cccd == null || cccd.trim().isEmpty()
                || stk == null || stk.trim().isEmpty()
                || password == null || password.isEmpty()) {
            throw new RemoteException(
                    "Vui lòng nhập đầy đủ thông tin."
            );
        }

        if (!Double.isFinite(balance) || balance < 0) {
            throw new RemoteException(
                    "Số dư ban đầu không hợp lệ."
            );
        }

        if (users.containsKey(cccd.trim())) {
            throw new RemoteException(
                    "CCCD đã tồn tại."
            );
        }

        for (User user : users.values()) {
            if (user.getStk().equals(stk.trim())) {
                throw new RemoteException(
                        "Số tài khoản đã tồn tại."
                );
            }
        }

        users.put(
                cccd.trim(),
                new User(
                        name.trim(),
                        cccd.trim(),
                        stk.trim(),
                        password,
                        balance
                )
        );

        transactions.put(
                cccd.trim(),
                new ArrayList<>()
        );

        addHistory(
                cccd.trim(),
                "Tạo tài khoản, số dư ban đầu: "
                        + money(balance)
        );

        return true;
    }

    @Override
    public synchronized String getUserInfo(
            String cccd,
            String password
    ) throws RemoteException {

        User user = authenticate(cccd, password);

        return user.toString();
    }

    @Override
    public synchronized List<String> getTransactions(
            String cccd,
            String password
    ) throws RemoteException {

        authenticate(cccd, password);

        return new ArrayList<>(
                transactions.getOrDefault(
                        cccd.trim(),
                        new ArrayList<>()
                )
        );
    }

    @Override
    public synchronized String performTransaction(
            String cccd,
            String password,
            String type,
            double amount
    ) throws RemoteException {

        User user = authenticate(cccd, password);

        if (!Double.isFinite(amount) || amount <= 0) {
            throw new RemoteException(
                    "Số tiền phải lớn hơn 0."
            );
        }

        String normalizedType =
                type == null
                        ? ""
                        : type.trim().toLowerCase();

        if (normalizedType.equals("deposit")
                || normalizedType.equals("gui")
                || normalizedType.equals("gửi")) {

            user.setBalance(user.getBalance() + amount);

            addHistory(
                    cccd.trim(),
                    "Gửi tiền: +" + money(amount)
                            + " | Số dư: "
                            + money(user.getBalance())
            );

            return "Gửi tiền thành công.\nSố dư mới: "
                    + money(user.getBalance());
        }

        if (normalizedType.equals("withdraw")
                || normalizedType.equals("rut")
                || normalizedType.equals("rút")) {

            if (amount > user.getBalance()) {
                throw new RemoteException(
                        "Số dư không đủ để rút tiền."
                );
            }

            user.setBalance(user.getBalance() - amount);

            addHistory(
                    cccd.trim(),
                    "Rút tiền: -" + money(amount)
                            + " | Số dư: "
                            + money(user.getBalance())
            );

            return "Rút tiền thành công.\nSố dư mới: "
                    + money(user.getBalance());
        }

        throw new RemoteException(
                "Loại giao dịch không hợp lệ."
        );
    }

    private User authenticate(
            String cccd,
            String password
    ) throws RemoteException {

        String key = cccd == null ? "" : cccd.trim();
        User user = users.get(key);

        if (user == null
                || password == null
                || !user.getPassword().equals(password)) {
            throw new RemoteException(
                    "CCCD hoặc mật khẩu không đúng."
            );
        }

        return user;
    }

    private void addHistory(
            String cccd,
            String description
    ) {
        String time =
                LocalDateTime.now().format(formatter);

        transactions.computeIfAbsent(
                cccd,
                key -> new ArrayList<>()
        ).add(time + " | " + description);
    }

    private String money(double amount) {
        return String.format("%,.0f VNĐ", amount);
    }
}
