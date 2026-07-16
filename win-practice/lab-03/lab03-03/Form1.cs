using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace lab03_03
{
    public partial class Form1 : Form
    {
        Bitmap canvasBitmap;
        Graphics g;

        bool isDrawing = false;

        Point startPoint;
        Point previousPoint;
        Point currentPoint;

        Color currentColor = Color.Black;
        int penSize = 3;

        private enum CongCuVe
        {
            ButVe,
            DuongThang,
            HinhChuNhat,
            HinhTron,
            CucTay
        }

        private CongCuVe congCuHienTai = CongCuVe.ButVe;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            canvasBitmap = new Bitmap(picCanvas.Width, picCanvas.Height);

            g = Graphics.FromImage(canvasBitmap);
            g.Clear(Color.White);
            g.SmoothingMode = SmoothingMode.AntiAlias;

            picCanvas.Image = canvasBitmap;

            pnlMauDangChon.BackColor = currentColor;
            lblDoDay.Text = "Độ dày: " + penSize;

            ChonNut(btnButVe);
        }

        //-------------------------------------------------
        // Chọn màu
        //-------------------------------------------------

        private void btnChonMau_Click(object sender, EventArgs e)
        {
            using (ColorDialog color = new ColorDialog())
            {
                if (color.ShowDialog() == DialogResult.OK)
                {
                    currentColor = color.Color;
                    pnlMauDangChon.BackColor = currentColor;
                }
            }
        }

        //-------------------------------------------------
        // Độ dày
        //-------------------------------------------------

        private void trkDoDay_Scroll(object sender, EventArgs e)
        {
            penSize = trkDoDay.Value;
            lblDoDay.Text = "Độ dày: " + penSize;
        }

        //-------------------------------------------------
        // Đổi màu nút
        //-------------------------------------------------

        private void ChonNut(Button btn)
        {
            btnButVe.BackColor = Color.White;
            btnDuongThang.BackColor = Color.White;
            btnChuNhat.BackColor = Color.White;
            btnHinhTron.BackColor = Color.White;
            btnCucTay.BackColor = Color.White;

            btn.BackColor = Color.LightBlue;
        }

        //-------------------------------------------------
        // Chọn công cụ
        //-------------------------------------------------

        private void btnButVe_Click(object sender, EventArgs e)
        {
            congCuHienTai = CongCuVe.ButVe;
            ChonNut(btnButVe);
        }

        private void btnDuongThang_Click(object sender, EventArgs e)
        {
            congCuHienTai = CongCuVe.DuongThang;
            ChonNut(btnDuongThang);
        }

        private void btnChuNhat_Click(object sender, EventArgs e)
        {
            congCuHienTai = CongCuVe.HinhChuNhat;
            ChonNut(btnChuNhat);
        }

        private void btnHinhTron_Click(object sender, EventArgs e)
        {
            congCuHienTai = CongCuVe.HinhTron;
            ChonNut(btnHinhTron);
        }

        private void btnCucTay_Click(object sender, EventArgs e)
        {
            congCuHienTai = CongCuVe.CucTay;
            ChonNut(btnCucTay);
        }

        //-------------------------------------------------
        // Mouse Down
        //-------------------------------------------------

        private void picCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            isDrawing = true;
            startPoint = e.Location;
            previousPoint = e.Location;
            currentPoint = e.Location;
        }

        //-------------------------------------------------
        // Mouse Move
        //-------------------------------------------------

        private void picCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (!isDrawing)
                return;

            currentPoint = e.Location;

            switch (congCuHienTai)
            {
                case CongCuVe.ButVe:

                    using (Pen pen = new Pen(currentColor, penSize))
                    {
                        pen.StartCap = LineCap.Round;
                        pen.EndCap = LineCap.Round;
                        pen.LineJoin = LineJoin.Round;

                        g.DrawLine(pen, previousPoint, currentPoint);
                    }

                    previousPoint = currentPoint;
                    picCanvas.Refresh();
                    break;

                case CongCuVe.CucTay:

                    using (Pen pen = new Pen(Color.White, penSize + 8))
                    {
                        pen.StartCap = LineCap.Round;
                        pen.EndCap = LineCap.Round;
                        pen.LineJoin = LineJoin.Round;

                        g.DrawLine(pen, previousPoint, currentPoint);
                    }

                    previousPoint = currentPoint;
                    picCanvas.Refresh();
                    break;

                default:
                    picCanvas.Refresh();
                    break;
            }
        }

        //-------------------------------------------------
        // Rectangle
        //-------------------------------------------------

        private Rectangle TaoRectangle(Point p1, Point p2)
        {
            return new Rectangle(
                Math.Min(p1.X, p2.X),
                Math.Min(p1.Y, p2.Y),
                Math.Abs(p1.X - p2.X),
                Math.Abs(p1.Y - p2.Y));
        }

        //-------------------------------------------------
        // Paint (xem trước)
        //-------------------------------------------------

        private void picCanvas_Paint(object sender, PaintEventArgs e)
        {
            if (!isDrawing)
                return;

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            using (Pen pen = new Pen(currentColor, penSize))
            {
                switch (congCuHienTai)
                {
                    case CongCuVe.DuongThang:
                        e.Graphics.DrawLine(pen, startPoint, currentPoint);
                        break;

                    case CongCuVe.HinhChuNhat:
                        e.Graphics.DrawRectangle(pen,
                            TaoRectangle(startPoint, currentPoint));
                        break;

                    case CongCuVe.HinhTron:
                        e.Graphics.DrawEllipse(pen,
                            TaoRectangle(startPoint, currentPoint));
                        break;
                }
            }
        }

        //-------------------------------------------------
        // Mouse Up
        //-------------------------------------------------

        private void picCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button != MouseButtons.Left)
                return;

            if (!isDrawing)
                return;

            isDrawing = false;
            currentPoint = e.Location;

            using (Pen pen = new Pen(currentColor, penSize))
            {
                Rectangle rect = TaoRectangle(startPoint, currentPoint);

                switch (congCuHienTai)
                {
                    case CongCuVe.DuongThang:
                        g.DrawLine(pen, startPoint, currentPoint);
                        break;

                    case CongCuVe.HinhChuNhat:
                        g.DrawRectangle(pen, rect);
                        break;

                    case CongCuVe.HinhTron:
                        g.DrawEllipse(pen, rect);
                        break;
                }
            }

            picCanvas.Refresh();
        }

        //-------------------------------------------------
        // Xóa
        //-------------------------------------------------

        private void btnXoa_Click(object sender, EventArgs e)
        {
            DialogResult rs = MessageBox.Show(
                "Bạn có muốn xóa toàn bộ hình?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (rs == DialogResult.Yes)
            {
                g.Clear(Color.White);
                picCanvas.Refresh();
            }
        }

        //-------------------------------------------------
        // Lưu
        //-------------------------------------------------

        private void btnLuu_Click(object sender, EventArgs e)
        {
            using (SaveFileDialog save = new SaveFileDialog())
            {
                save.Filter = "PNG Image|*.png";
                save.Title = "Lưu ảnh";

                if (save.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        canvasBitmap.Save(save.FileName);
                        MessageBox.Show("Lưu ảnh thành công!",
                                        "Thông báo",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Information);
                    }
                    catch
                    {
                        MessageBox.Show("Không thể lưu ảnh.",
                                        "Lỗi",
                                        MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    }
                }
            }
        }

        //-------------------------------------------------
        // Nếu kéo chuột ra ngoài PictureBox
        //-------------------------------------------------

        private void picCanvas_MouseLeave(object sender, EventArgs e)
        {
            isDrawing = false;
        }
    }
}