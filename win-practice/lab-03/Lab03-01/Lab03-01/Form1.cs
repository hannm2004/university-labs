using System;
using System.Windows.Forms;

namespace Lab03_01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // Sự kiện Timer: cập nhật ngày giờ mỗi giây trên StatusStrip
        private void timer1_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel1.Text = string.Format(
                "Hôm nay là ngày {0} - Bây giờ là {1}",
                DateTime.Now.ToString("dd/MM/yyyy"),
                DateTime.Now.ToString("hh:mm:ss tt"));
        }

        // SubMenu Open: mở hộp thoại chọn file media và phát
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Tạo hộp thoại mở file
            OpenFileDialog dlg = new OpenFileDialog();

            // Lọc hiển thị các loại file media
            dlg.Filter =
                "AVI file|*.avi" +
                "|MPEG File|*.mpeg" +
                "|Wav File|*.wav" +
                "|Midi File|*.midi" +
                "|Mp4 File|*.mp4" +
                "|MP3|*.mp3" +
                "|All Media Files|*.avi;*.mpeg;*.wav;*.midi;*.mp4;*.mp3";

            // Chọn mặc định hiển thị tất cả media
            dlg.FilterIndex = 7;
            dlg.Title = "Chọn file Media";

            // Hiển thị openDialog
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                // Lấy tên file cần mở và gán cho Windows Media Player
                axWindowsMediaPlayer1.URL = dlg.FileName;
            }
        }

        // SubMenu Exit: thoát ứng dụng
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
