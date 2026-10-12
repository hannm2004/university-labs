/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package bt07_01.remoteapp;
import java.io.Serializable;

/**
 *
 * @author HP
 */
public class PhanSo implements Serializable {

    private static final long serialVersionUID = 1L;

    private int tu;
    private int mau;

    public PhanSo() {
        tu = 0;
        mau = 1;
    }

    public PhanSo(int t, int m) {
        tu = t;
        mau = m;
    }

    public PhanSo sum(PhanSo b) {
        PhanSo c = new PhanSo();

        c.setTu(tu * b.getMau() + b.getTu() * mau);
        c.setMau(mau * b.getMau());

        return c;
    }

    public void setTu(int t) {
        tu = t;
    }

    public void setMau(int m) {
        mau = m;
    }

    public int getTu() {
        return tu;
    }

    public int getMau() {
        return mau;
    }
}
