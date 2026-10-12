/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package bt07_02.server;
import java.io.Serializable;
/**
 *
 * @author HP
 */
public class User implements Serializable {

    private static final long serialVersionUID = 1L;

    private final String name;
    private final String cccd;
    private final String stk;
    private final String password;
    private double balance;

    public User(String name, String cccd, String stk,
                String password, double balance) {
        this.name = name;
        this.cccd = cccd;
        this.stk = stk;
        this.password = password;
        this.balance = balance;
    }

    public String getName() {
        return name;
    }

    public String getCccd() {
        return cccd;
    }

    public String getStk() {
        return stk;
    }

    public String getPassword() {
        return password;
    }

    public double getBalance() {
        return balance;
    }

    public void setBalance(double balance) {
        this.balance = balance;
    }

    @Override
    public String toString() {
        return "Họ tên: " + name
                + "\nCCCD: " + cccd
                + "\nSố tài khoản: " + stk
                + "\nSố dư: "
                + String.format("%,.0f VNĐ", balance);
    }
}
