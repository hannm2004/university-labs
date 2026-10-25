/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package bt07_02.server;

/**
 *
 * @author HP
 */
public class User {

    private final String name;
    private final String cccd;
    private final String stk;
    private final String password;
    private final double interestRate;   // lãi suất (%/năm)
    private double balance;

    public User(String name, String cccd, String stk, String password,
                double balance, double interestRate) {
        this.name = name;
        this.cccd = cccd;
        this.stk = stk;
        this.password = password;
        this.balance = balance;
        this.interestRate = interestRate;
    }

    public String getName() { return name; }
    public String getCccd() { return cccd; }
    public String getStk() { return stk; }
    public String getPassword() { return password; }
    public double getBalance() { return balance; }
    public double getInterestRate() { return interestRate; }
    public void setBalance(double balance) { this.balance = balance; }
}