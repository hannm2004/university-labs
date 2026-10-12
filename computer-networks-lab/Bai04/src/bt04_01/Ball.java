/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package bt04_01;

import java.awt.*;
import javax.swing.JPanel;
import javax.swing.JOptionPane;

public class Ball {

    private JPanel box; //Bảng để vẽ quả 

    private static final int XSIZE = 30; //Chiều rộng quả bóng
    private static final int YSIZE = 30; //Chiều cao quả bóng

    private int x = 0; //Vị trí ban đầu theo trục x
    private int y = 0; //Vị trí ban đầu theo trục y

    private int dx = 2; //Hướng di chuyển theo x
    private int dy = 2; //Huớng di chuyển theo y

    //Contructor khởi tạo quả bóng với panel hiển thị
    public Ball(JPanel p) {
        box = p;
    }
    
    //Vẽ quả bóng tại vị trí hiện tại
    public void draw() {
        Graphics g = box.getGraphics();

        g.setColor(Color.RED); //Màu quả bóng
        g.fillOval(x, y, XSIZE, YSIZE); //Vẽ hình tròn tại tọa độ (x,y) với kích thước  

        g.dispose();
    }

    //Xóa quả bóng tại vị trí hiện tại
    public void clear() {
        Graphics g = box.getGraphics();

        g.setColor(box.getBackground()); //Lấy màu nền của panel để xóa
        g.fillOval(x, y, XSIZE, YSIZE); //Xóa hình oval tại tọa độ cũ

        g.dispose();
    }

    //Di chuyển bóng tới vị trí mới
    public void move() {

        // Xóa quả banh ở vị trí cũ
        clear();

        // Di chuyển
        x += dx;
        y += dy;

        //Kiểm tra va chạm biên và thay đổi hướng
        Dimension d = box.getSize();

        // Chạm cạnh trái
        if (x < 0) {
            x = 0;
            dx = -dx;
        }

        // Chạm cạnh phải
        if (x + XSIZE >= d.getWidth()) {
            x = d.width - XSIZE;
            dx = -dx;
        }

        // Chạm cạnh trên
        if (y < 0) {
            y = 0;
            dy = -dy;
        }

        // Chạm cạnh dưới
        if (y + YSIZE >= d.getHeight()) {
            y = d.height - YSIZE;
            dy = -dy;
        }

        // Vẽ lại
        draw();
    }

    //Phương thức để điều khiển bóng di chuyển nhiều lần
    public void bounce() {

        draw();//Vẽ quả bóng lần đầu

        for (int i = 0; i < 1000; i++) {//di chuyển 1000 bước

            move(); //Di chuyển đến vị trí tiếp theo

            try {
                Thread.sleep(20); //Tạm dừng 20ms để tạo hiệu ứng mượt mà
            } catch (InterruptedException ex) {

                JOptionPane.showMessageDialog(
                        null,
                        ex.toString(),
                        "Thong bao loi",
                        JOptionPane.ERROR_MESSAGE
                );
            }
        }
    }
}