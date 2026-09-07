/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package bt01;
/**
 *
 * @author HP
 */
import java.sql.*;
import javax.swing.*;

public class MyConnection {

    public Connection getConnection() {
        try {
            // Nap driver MySQL
            Class.forName("com.mysql.cj.jdbc.Driver");
            
            // Dien dung ten database la: quanlytaikhoanquan
            String URL = "jdbc:mysql://localhost:3306/quanlytaikhoanquan?user=root&password=";
            
            Connection con = DriverManager.getConnection(URL);
            return con;
        } catch (Exception ex) {
            JOptionPane.showMessageDialog(null, ex.toString(), "Lỗi kết nối", JOptionPane.ERROR_MESSAGE);
            return null;
        }
    }
}