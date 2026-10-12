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
public interface ATMService extends Remote {

    boolean addUser(
            String name,
            String cccd,
            String stk,
            String password,
            double balance
    ) throws RemoteException;

    String getUserInfo(
            String cccd,
            String password
    ) throws RemoteException;

    List<String> getTransactions(
            String cccd,
            String password
    ) throws RemoteException;

    String performTransaction(
            String cccd,
            String password,
            String type,
            double amount
    ) throws RemoteException;
}
