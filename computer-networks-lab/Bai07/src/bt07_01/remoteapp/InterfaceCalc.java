package bt07_01.remoteapp;
import java.rmi.Remote;
import java.rmi.RemoteException;
/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Interface.java to edit this template
 */

/**
 *
 * @author HP
 */
public interface InterfaceCalc extends Remote {

    int sum(int a, int b) throws RemoteException;

    PhanSo sum(PhanSo a, PhanSo b)
            throws RemoteException;
}
