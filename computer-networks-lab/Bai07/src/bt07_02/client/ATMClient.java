package bt07_02.client;

/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
import bt07_02.server.ATMService;
import java.rmi.Naming;
import java.util.List;
import java.util.Scanner;

/**
 *
 * @author HP
 */
public class ATMClient {

    private static final Scanner scanner = new Scanner(System.in);

    public static void main(String[] args) {
        System.out.print("Địa chỉ server (Enter = localhost): ");
        String host = scanner.nextLine().trim();
        if (host.isEmpty()) {
            host = "localhost";
        }

        // Kết nối tới dịch vụ RMI trên server
        ATMService atmService;
        try {
            atmService = (ATMService) Naming.lookup("rmi://" + host + "/ATMService");
        } catch (Exception e) {
            System.out.println("Không kết nối được tới server: " + e.getMessage());
            return;
        }

        while (true) {
            System.out.println();
            System.out.println("===== ATM =====");
            System.out.println("1. Thêm người dùng");
            System.out.println("2. Xem thông tin người dùng");
            System.out.println("3. Gửi/Rút tiền");
            System.out.println("4. Xem lịch sử giao dịch");
            System.out.println("5. Thoát");
            int choice = docSoNguyen("Chọn: ");

            try {
                switch (choice) {
                    case 1:
                        themNguoiDung(atmService);
                        break;
                    case 2:
                        xemThongTin(atmService);
                        break;
                    case 3:
                        giaoDich(atmService);
                        break;
                    case 4:
                        xemLichSu(atmService);
                        break;
                    case 5:
                        System.out.println("Tạm biệt!");
                        return;
                    default:
                        System.out.println("Lựa chọn không hợp lệ!");
                }
            } catch (Exception e) {
                // Mất kết nối, server tắt... : báo lỗi nhưng không thoát chương trình
                System.out.println("Lỗi: " + e.getMessage());
            }
        }
    }

    private static void themNguoiDung(ATMService s) throws Exception {
        String name = docDong("Tên: ");
        String cccd = docDong("CCCD: ");
        String stk = docDong("STK: ");
        String password = docDong("Mật khẩu: ");
        double balance = docSo("Số dư ban đầu: ");
        double lai = docSo("Lãi suất (%/năm): ");

        if (s.addUser(name, cccd, stk, password, balance, lai)) {
            System.out.println("Thêm người dùng thành công");
        } else {
            System.out.println("Thêm thất bại: dữ liệu rỗng/không hợp lệ hoặc CCCD đã tồn tại!");
        }
    }

    private static void xemThongTin(ATMService s) throws Exception {
        String name = docDong("Tên: ");
        String password = docDong("Mật khẩu: ");
        System.out.println(s.getUserInfo(name, password));
    }

    private static void giaoDich(ATMService s) throws Exception {
        String cccd = docDong("CCCD: ");
        String password = docDong("Mật khẩu: ");
        String loai = docDong("Loại giao dịch (gui/rut): ");
        double soTien = docSo("Số tiền: ");
        System.out.println(s.performTransaction(cccd, password, loai, soTien));
    }

    private static void xemLichSu(ATMService s) throws Exception {
        String cccd = docDong("CCCD: ");
        String password = docDong("Mật khẩu: ");
        List<String> ds = s.getTransactions(cccd, password);
        if (ds.isEmpty()) {
            System.out.println("Chưa có giao dịch nào");
        }
        for (String dong : ds) {
            System.out.println(dong);
        }
    }

    // Luôn đọc cả dòng bằng nextLine() để tránh lỗi "nextInt() để lại ký tự xuống dòng"
    private static String docDong(String prompt) {
        System.out.print(prompt);
        return scanner.nextLine().trim();
    }

    private static double docSo(String prompt) {
        while (true) {
            try {
                return Double.parseDouble(docDong(prompt));
            } catch (NumberFormatException e) {
                System.out.println("Vui lòng nhập một số hợp lệ!");
            }
        }
    }

    private static int docSoNguyen(String prompt) {
        try {
            return Integer.parseInt(docDong(prompt));
        } catch (NumberFormatException e) {
            return -1;   // rơi vào "Lựa chọn không hợp lệ"
        }
    }
}
