/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package bt02_03;
import java.io.Serializable;
/**
 *
 * @author HP
 */
public class PhanSo implements Serializable {

    private int tuSo;
    private int mauSo;

    public PhanSo(boolean a) {
        tuSo = (int) (Math.random() * 100);
        do{
            mauSo = (int) (Math.random() * 90 + 1);
        } while(mauSo == 0);
    }
    
    public PhanSo() {
        tuSo = (int) (Math.random() * 100);
        do{
            mauSo = (int) (Math.random() * 90 + 1);
        } while(mauSo == 0);
    }

    public PhanSo(int tuSo, int mauSo) {
        this.tuSo = tuSo;
        if (mauSo == 0){
            this.mauSo = 1;
        } else {
        this.mauSo = mauSo;
        }
    }

    public int getMauSo() {
        return mauSo;
    }

    @Override
    public String toString() {
        return tuSo + "/" + mauSo;
    }
    
    public boolean kiemTraNguyenTo(){
        if(mauSo < 2){
            return false;
        }
        int t = (int) Math.sqrt(mauSo);
        for (int i = 2; i <= t; i++) {
            if(mauSo % i == 0){
                return false;
            }
        }
        return true;    
    }
}
