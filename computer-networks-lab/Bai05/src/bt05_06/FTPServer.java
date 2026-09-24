/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package bt05_06;
/**
 *
 * @author HP
 */

import java.io.DataInputStream;
import java.io.DataOutputStream;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.net.ServerSocket;
import java.net.Socket;

public class FTPServer {

    public static final int PORT = 10000;

    // Tài khoản mẫu
    public static final String USER = "tu";
    public static final String PASS = "tu";

    // Thư mục server
    public static final String SERVER_FOLDER = "D:/FTPServer";

    // Các lệnh
    public static final String LOGIN = "DANGNHAP";
    public static final String UPLOAD = "UPLOAD";
    public static final String DOWNLOAD = "DOWNLOAD";
    public static final String LIST = "LIST";
    public static final String EXIT = "THOAT";

    public static void main(String[] args) {

        File folder = new File(SERVER_FOLDER);

        if (!folder.exists()) {
            folder.mkdirs();
        }

        System.out.println("=================================");
        System.out.println("       FTP SERVER");
        System.out.println("=================================");
        System.out.println("Port: " + PORT);
        System.out.println("Folder: " + SERVER_FOLDER);
        System.out.println("Dang cho Client...");

        try (ServerSocket serverSocket = new ServerSocket(PORT)) {

            while (true) {

                Socket socket = serverSocket.accept();

                System.out.println("\nClient da ket noi: "
                        + socket.getInetAddress());

                xuLyClient(socket);

                socket.close();

                System.out.println("Client da ngat ket noi.");
                System.out.println("Dang cho Client tiep theo...");
            }

        } catch (IOException e) {
            System.out.println("Loi Server: " + e.getMessage());
        }
    }

    private static void xuLyClient(Socket socket) {

        try {

            DataInputStream dis =
                    new DataInputStream(socket.getInputStream());

            DataOutputStream dos =
                    new DataOutputStream(socket.getOutputStream());

            boolean login = false;

            while (true) {

                String command = dis.readUTF();

                System.out.println("Nhan lenh: " + command);

                // =========================
                // LOGIN
                // =========================
                if (command.equals(LOGIN)) {

                    String user = dis.readUTF();
                    String pass = dis.readUTF();

                    if (user.equals(USER) && pass.equals(PASS)) {

                        login = true;

                        dos.writeInt(1);
                        dos.writeUTF("Dang nhap thanh cong");

                        guiDanhSachFile(dos);

                        dos.flush();

                        System.out.println(
                                "Dang nhap thanh cong: " + user
                        );

                    } else {

                        login = false;

                        dos.writeInt(0);
                        dos.writeUTF("Dang nhap khong thanh cong");

                        dos.flush();

                        System.out.println(
                                "Dang nhap that bai: " + user
                        );
                    }
                }

                // =========================
                // LIST
                // =========================
                else if (command.equals(LIST)) {

                    if (!login) {
                        dos.writeInt(0);
                        dos.writeUTF("Chua dang nhap");
                        dos.flush();
                        continue;
                    }

                    guiDanhSachFile(dos);
                    dos.flush();
                }

                // =========================
                // UPLOAD
                // =========================
                else if (command.equals(UPLOAD)) {

                    if (!login) {
                        dos.writeInt(0);
                        dos.writeUTF("Chua dang nhap");
                        dos.flush();
                        continue;
                    }

                    String fileName = dis.readUTF();
                    long fileSize = dis.readLong();

                    File file = new File(
                            SERVER_FOLDER,
                            fileName
                    );

                    System.out.println(
                            "Dang nhan file: " + fileName
                    );

                    try (FileOutputStream fos =
                                 new FileOutputStream(file)) {

                        byte[] buffer = new byte[4096];

                        long remaining = fileSize;

                        while (remaining > 0) {

                            int read = dis.read(
                                    buffer,
                                    0,
                                    (int) Math.min(
                                            buffer.length,
                                            remaining
                                    )
                            );

                            if (read == -1) {
                                throw new IOException(
                                        "Ket noi bi ngat"
                                );
                            }

                            fos.write(buffer, 0, read);

                            remaining -= read;
                        }
                    }

                    System.out.println(
                            "Da nhan file: " + fileName
                    );

                    dos.writeInt(1);
                    dos.writeUTF("DANHAN");

                    guiDanhSachFile(dos);

                    dos.flush();
                }

                // =========================
                // DOWNLOAD
                // =========================
                else if (command.equals(DOWNLOAD)) {

                    if (!login) {
                        dos.writeInt(0);
                        dos.writeUTF("Chua dang nhap");
                        dos.flush();
                        continue;
                    }

                    String fileName = dis.readUTF();

                    File file = new File(
                            SERVER_FOLDER,
                            fileName
                    );

                    System.out.println(
                            "Client yeu cau download: "
                            + fileName
                    );

                    if (!file.exists() || !file.isFile()) {

                        dos.writeInt(0);
                        dos.writeUTF(
                                "Khong tim thay tap tin"
                        );

                        dos.flush();

                        continue;
                    }

                    dos.writeInt(1);

                    dos.writeLong(file.length());

                    try (FileInputStream fis =
                                 new FileInputStream(file)) {

                        byte[] buffer = new byte[4096];

                        int read;

                        while ((read = fis.read(buffer)) != -1) {

                            dos.write(buffer, 0, read);
                        }
                    }

                    dos.flush();

                    System.out.println(
                            "Da gui file cho Client."
                    );
                }

                // =========================
                // EXIT
                // =========================
                else if (command.equals(EXIT)) {

                    System.out.println(
                            "Client yeu cau thoat."
                    );

                    break;
                }

                else {

                    dos.writeInt(0);
                    dos.writeUTF("Lenh khong hop le");
                    dos.flush();
                }
            }

        } catch (IOException e) {

            System.out.println(
                    "Client ngat ket noi: "
                    + e.getMessage()
            );
        }
    }

    private static void guiDanhSachFile(
            DataOutputStream dos
    ) throws IOException {

        File folder = new File(SERVER_FOLDER);

        File[] files = folder.listFiles();

        if (files == null) {

            dos.writeInt(0);
            return;
        }

        dos.writeInt(files.length);

        for (File file : files) {

            dos.writeUTF(file.getName());
        }
    }
}
