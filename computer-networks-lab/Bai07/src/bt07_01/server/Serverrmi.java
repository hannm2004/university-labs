/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package bt07_01.server;
import java.rmi.registry.LocateRegistry;
import java.rmi.registry.Registry;
/**
 *
 * @author HP
 */
public class Serverrmi {

    public static void main(String[] args) {
        try {
            Calc c = new Calc();

            Registry r =
                LocateRegistry.createRegistry(3456);

            r.rebind("rmiCalc", c);

            System.out.println(
                "RMI Server dang chay tai cong 3456!"
            );
            System.out.println(
                "Da dang ky dich vu rmiCalc."
            );

        } catch (Exception ex) {
            ex.printStackTrace();
        }
    }
}
