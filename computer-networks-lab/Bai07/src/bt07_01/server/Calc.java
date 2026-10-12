/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package bt07_01.server;
import java.rmi.RemoteException;
import java.rmi.server.UnicastRemoteObject;
import bt07_01.remoteapp.InterfaceCalc;
import bt07_01.remoteapp.PhanSo;
/**
 *
 * @author HP
 */
public class Calc extends UnicastRemoteObject
        implements InterfaceCalc {

    public Calc() throws RemoteException {
        super();
    }

    @Override
    public int sum(int a, int b) throws RemoteException {
        return a + b;
    }

    @Override
    public PhanSo sum(PhanSo a, PhanSo b)
            throws RemoteException {
        return a.sum(b);
    }
}
