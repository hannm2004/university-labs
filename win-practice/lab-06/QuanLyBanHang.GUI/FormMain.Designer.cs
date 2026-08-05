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
            menuFile = new ToolStripMenuItem();
            menuExit = new ToolStripMenuItem();
            menuDanhMuc = new ToolStripMenuItem();
            menuProduct = new ToolStripMenuItem();
            menuCustomer = new ToolStripMenuItem();
            menuBanHang = new ToolStripMenuItem();
            menuCreateOrder = new ToolStripMenuItem();
            menuOrderList = new ToolStripMenuItem();
            panelHeader = new Panel();
            lblTitle = new Label();
            menuStrip1.SuspendLayout();
            panelHeader.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { menuFile, menuDanhMuc, menuBanHang });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Padding = new Padding(5, 2, 0, 2);
            menuStrip1.Size = new Size(1050, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // menuFile
            // 
            menuFile.DropDownItems.AddRange(new ToolStripItem[] { menuExit });
            menuFile.Name = "menuFile";
            menuFile.Size = new Size(38, 20);
            menuFile.Text = "Tệp";
            // 
            // menuExit
            // 
            menuExit.Name = "menuExit";
            menuExit.Size = new Size(180, 22);
            menuExit.Text = "Thoát";
            menuExit.Click += mnuThoat_Click;
            // 
            // menuDanhMuc
            // 
            menuDanhMuc.DropDownItems.AddRange(new ToolStripItem[] { menuProduct, menuCustomer });
            menuDanhMuc.Name = "menuDanhMuc";
            menuDanhMuc.Size = new Size(74, 20);
            menuDanhMuc.Text = "Danh mục";
            // 
            // menuProduct
            // 
            menuProduct.Name = "menuProduct";
            menuProduct.Size = new Size(181, 22);
            menuProduct.Text = "Quản lý Sản phẩm";
            menuProduct.Click += mnuSanPham_Click;
            // 
            // menuCustomer
            // 
            menuCustomer.Name = "menuCustomer";
            menuCustomer.Size = new Size(181, 22);
            menuCustomer.Text = "Quản lý Khách hàng";
            menuCustomer.Click += mnuKhachHang_Click;
            // 
            // menuBanHang
            // 
            menuBanHang.DropDownItems.AddRange(new ToolStripItem[] { menuCreateOrder, menuOrderList });
            menuBanHang.Name = "menuBanHang";
            menuBanHang.Size = new Size(69, 20);
            menuBanHang.Text = "Bán hàng";
            // 
            // menuCreateOrder
            // 
            menuCreateOrder.Name = "menuCreateOrder";
            menuCreateOrder.Size = new Size(184, 22);
            menuCreateOrder.Text = "Tạo Đơn hàng";
            menuCreateOrder.Click += mnuTaoDonHang_Click;
            // 
            // menuOrderList
            // 
            menuOrderList.Name = "menuOrderList";
            menuOrderList.Size = new Size(184, 22);
            menuOrderList.Text = "Danh sách Đơn hàng";
            menuOrderList.Click += mnuDanhSachDonHang_Click;
            // 
            // panelHeader
            // 
            panelHeader.BackColor = Color.AliceBlue;
            panelHeader.Controls.Add(lblTitle);
            panelHeader.Dock = DockStyle.Top;
            panelHeader.Location = new Point(0, 24);
            panelHeader.Margin = new Padding(3, 2, 3, 2);
            panelHeader.Name = "panelHeader";
            panelHeader.Size = new Size(1050, 90);
            panelHeader.TabIndex = 1;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 22F, FontStyle.Bold);
            lblTitle.ForeColor = Color.RoyalBlue;
            lblTitle.Location = new Point(219, 26);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(539, 41);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "\U0001f6d2  HỆ THỐNG QUẢN LÝ BÁN HÀNG";
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1050, 525);
            Controls.Add(panelHeader);
            Controls.Add(menuStrip1);
            IsMdiContainer = true;
            MainMenuStrip = menuStrip1;
            Margin = new Padding(3, 2, 3, 2);
            Name = "FormMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản Lý Bán Hàng";
            WindowState = FormWindowState.Maximized;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panelHeader.ResumeLayout(false);
            panelHeader.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem menuFile;
        private ToolStripMenuItem menuExit;
        private ToolStripMenuItem menuDanhMuc;
        private ToolStripMenuItem menuProduct;
        private ToolStripMenuItem menuCustomer;
        private ToolStripMenuItem menuBanHang;
        private ToolStripMenuItem menuCreateOrder;
        private ToolStripMenuItem menuOrderList;
        private Panel panelHeader;
        private Label lblTitle;
    }
}
