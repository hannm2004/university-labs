namespace QuanLyBanHang.GUI
{
    partial class FormMain
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();

            mnuHeThong = new ToolStripMenuItem();
            mnuThoat = new ToolStripMenuItem();

            mnuDanhMuc = new ToolStripMenuItem();
            mnuSanPham = new ToolStripMenuItem();
            mnuKhachHang = new ToolStripMenuItem();

            mnuDonHang = new ToolStripMenuItem();
            mnuTaoDonHang = new ToolStripMenuItem();
            mnuDanhSachDonHang = new ToolStripMenuItem();

            SuspendLayout();

            // menuStrip1
            menuStrip1.Items.AddRange(new ToolStripItem[]
            {
        mnuHeThong,
        mnuDanhMuc,
        mnuDonHang
            });

            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1000, 24);

            // Hệ thống
            mnuHeThong.Text = "Hệ thống";
            mnuHeThong.DropDownItems.Add(mnuThoat);

            mnuThoat.Text = "Thoát";

            // Danh mục
            mnuDanhMuc.Text = "Danh mục";
            mnuDanhMuc.DropDownItems.AddRange(new ToolStripItem[]
            {
        mnuSanPham,
        mnuKhachHang
            });

            mnuSanPham.Text = "Quản lý sản phẩm";
            mnuKhachHang.Text = "Quản lý khách hàng";

            // Đơn hàng
            mnuDonHang.Text = "Đơn hàng";
            mnuDonHang.DropDownItems.AddRange(new ToolStripItem[]
            {
        mnuTaoDonHang,
        mnuDanhSachDonHang
            });

            mnuTaoDonHang.Text = "Tạo đơn hàng";
            mnuDanhSachDonHang.Text = "Danh sách đơn hàng";

            // Form
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 600);
            Controls.Add(menuStrip1);

            MainMenuStrip = menuStrip1;

            Name = "FormMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "QUẢN LÝ BÁN HÀNG";

            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;

        private ToolStripMenuItem mnuHeThong;
        private ToolStripMenuItem mnuThoat;

        private ToolStripMenuItem mnuDanhMuc;
        private ToolStripMenuItem mnuSanPham;
        private ToolStripMenuItem mnuKhachHang;

        private ToolStripMenuItem mnuDonHang;
        private ToolStripMenuItem mnuTaoDonHang;
        private ToolStripMenuItem mnuDanhSachDonHang;
    }
}
