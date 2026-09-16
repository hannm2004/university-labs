/*
 * Click nbfs://nbhost/SystemFileSystem/Templates/Licenses/license-default.txt to change this license
 * Click nbfs://nbhost/SystemFileSystem/Templates/Classes/Class.java to edit this template
 */
package bt04_01;

import java.awt.*;
import javax.swing.JPanel;
import javax.swing.JOptionPane;

public class Ball {

    private JPanel box;

    private static final int XSIZE = 30;
    private static final int YSIZE = 30;

    private int x = 0;
    private int y = 0;

    private int dx = 2;
    private int dy = 2;

    public Ball(JPanel p) {
        box = p;
    }

    public void draw() {
        Graphics g = box.getGraphics();

        g.setColor(Color.RED);
        g.fillOval(x, y, XSIZE, YSIZE);

        g.dispose();
    }

    public void clear() {
        Graphics g = box.getGraphics();

        g.setColor(box.getBackground());
        g.fillOval(x, y, XSIZE, YSIZE);

        g.dispose();
    }

    public void move() {

        // Xóa quả banh ở vị trí cũ
        clear();

        // Di chuyển
        x += dx;
        y += dy;

        Dimension d = box.getSize();

        // Chạm cạnh trái
        if (x < 0) {
            x = 0;
            dx = -dx;
        }

        // Chạm cạnh phải
        if (x + XSIZE >= d.width) {
            x = d.width - XSIZE;
            dx = -dx;
        }

        // Chạm cạnh trên
        if (y < 0) {
            y = 0;
            dy = -dy;
        }

        // Chạm cạnh dưới
        if (y + YSIZE >= d.height) {
            y = d.height - YSIZE;
            dy = -dy;
        }

        // Vẽ lại
        draw();
    }

    public void bounce() {

        draw();

        for (int i = 0; i < 1000; i++) {

            move();

            try {
                Thread.sleep(1);
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