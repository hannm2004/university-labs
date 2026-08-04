namespace QuanLyBanHang.GUI
{
    partial class FormProduct
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlHeader = new Panel();
            lblTitle = new Label();
            grpThongTin = new GroupBox();
            lblMaSP = new Label();
            txtMaSP = new TextBox();
            lblTenSP = new Label();
            txtTenSP = new TextBox();
            lblDonGia = new Label();
            txtDonGia = new TextBox();
            lblSoLuongTon = new Label();
            txtSoLuongTon = new TextBox();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            grpDanhSach = new GroupBox();
            lblTongSP = new Label();
            dgvProduct = new DataGridView();
            pnlHeader.SuspendLayout();
            grpThongTin.SuspendLayout();
            grpDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProduct).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.AliceBlue;
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1000, 70);
            pnlHeader.TabIndex = 2;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.RoyalBlue;
            lblTitle.Location = new Point(300, 18);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(254, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "QUẢN LÝ SẢN PHẨM";
            // 
            // grpThongTin
            // 
            grpThongTin.Controls.Add(lblMaSP);
            grpThongTin.Controls.Add(txtMaSP);
            grpThongTin.Controls.Add(lblTenSP);
            grpThongTin.Controls.Add(txtTenSP);
            grpThongTin.Controls.Add(lblDonGia);
            grpThongTin.Controls.Add(txtDonGia);
            grpThongTin.Controls.Add(lblSoLuongTon);
            grpThongTin.Controls.Add(txtSoLuongTon);
            grpThongTin.Controls.Add(btnThem);
            grpThongTin.Controls.Add(btnSua);
            grpThongTin.Controls.Add(btnXoa);
            grpThongTin.Controls.Add(btnLamMoi);
            grpThongTin.Location = new Point(15, 85);
            grpThongTin.Name = "grpThongTin";
            grpThongTin.Size = new Size(290, 430);
            grpThongTin.TabIndex = 1;
            grpThongTin.TabStop = false;
            grpThongTin.Text = "Thông tin sản phẩm";
            // 
            // lblMaSP
            // 
            lblMaSP.AutoSize = true;
            lblMaSP.Location = new Point(20, 35);
            lblMaSP.Name = "lblMaSP";
            lblMaSP.Size = new Size(40, 15);
            lblMaSP.TabIndex = 0;
            lblMaSP.Text = "Mã SP";
            // 
            // txtMaSP
            // 
            txtMaSP.Location = new Point(20, 55);
            txtMaSP.Name = "txtMaSP";
            txtMaSP.Size = new Size(240, 23);
            txtMaSP.TabIndex = 1;
            // 
            // lblTenSP
            // 
            lblTenSP.AutoSize = true;
            lblTenSP.Location = new Point(20, 95);
            lblTenSP.Name = "lblTenSP";
            lblTenSP.Size = new Size(80, 15);
            lblTenSP.TabIndex = 2;
            lblTenSP.Text = "Tên sản phẩm";
            // 
            // txtTenSP
            // 
            txtTenSP.Location = new Point(20, 115);
            txtTenSP.Name = "txtTenSP";
            txtTenSP.Size = new Size(240, 23);
            txtTenSP.TabIndex = 3;
            // 
            // lblDonGia
            // 
            lblDonGia.AutoSize = true;
            lblDonGia.Location = new Point(20, 155);
            lblDonGia.Name = "lblDonGia";
            lblDonGia.Size = new Size(48, 15);
            lblDonGia.TabIndex = 4;
            lblDonGia.Text = "Đơn giá";
            // 
            // txtDonGia
            // 
            txtDonGia.Location = new Point(20, 175);
            txtDonGia.Name = "txtDonGia";
            txtDonGia.Size = new Size(240, 23);
            txtDonGia.TabIndex = 5;
            // 
            // lblSoLuongTon
            // 
            lblSoLuongTon.AutoSize = true;
            lblSoLuongTon.Location = new Point(20, 215);
            lblSoLuongTon.Name = "lblSoLuongTon";
            lblSoLuongTon.Size = new Size(75, 15);
            lblSoLuongTon.TabIndex = 6;
            lblSoLuongTon.Text = "Số lượng tồn";
            // 
            // txtSoLuongTon
            // 
            txtSoLuongTon.Location = new Point(20, 235);
            txtSoLuongTon.Name = "txtSoLuongTon";
            txtSoLuongTon.Size = new Size(240, 23);
            txtSoLuongTon.TabIndex = 7;
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.LimeGreen;
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnThem.ForeColor = Color.White;
            btnThem.Location = new Point(20, 300);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(110, 40);
            btnThem.TabIndex = 8;
            btnThem.Text = "Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.DodgerBlue;
            btnSua.FlatStyle = FlatStyle.Flat;
            btnSua.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnSua.ForeColor = Color.White;
            btnSua.Location = new Point(150, 300);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(110, 40);
            btnSua.TabIndex = 9;
            btnSua.Text = "Sửa";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.Crimson;
            btnXoa.FlatStyle = FlatStyle.Flat;
            btnXoa.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnXoa.ForeColor = Color.White;
            btnXoa.Location = new Point(20, 355);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(110, 40);
            btnXoa.TabIndex = 10;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.BackColor = Color.Gray;
            btnLamMoi.FlatStyle = FlatStyle.Flat;
            btnLamMoi.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnLamMoi.ForeColor = Color.White;
            btnLamMoi.Location = new Point(150, 355);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(110, 40);
            btnLamMoi.TabIndex = 11;
            btnLamMoi.Text = "Làm mới";
            btnLamMoi.UseVisualStyleBackColor = false;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // grpDanhSach
            // 
            grpDanhSach.Controls.Add(lblTongSP);
            grpDanhSach.Controls.Add(dgvProduct);
            grpDanhSach.Location = new Point(320, 85);
            grpDanhSach.Name = "grpDanhSach";
            grpDanhSach.Size = new Size(660, 430);
            grpDanhSach.TabIndex = 0;
            grpDanhSach.TabStop = false;
            grpDanhSach.Text = "Danh sách sản phẩm";
            // 
            // lblTongSP
            // 
            lblTongSP.AutoSize = true;
            lblTongSP.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTongSP.Location = new Point(20, 30);
            lblTongSP.Name = "lblTongSP";
            lblTongSP.Size = new Size(146, 19);
            lblTongSP.TabIndex = 0;
            lblTongSP.Text = "Tổng số sản phẩm: 0";
            // 
            // dgvProduct
            // 
            dgvProduct.AllowUserToAddRows = false;
            dgvProduct.AllowUserToDeleteRows = false;
            dgvProduct.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvProduct.Location = new Point(20, 60);
            dgvProduct.MultiSelect = false;
            dgvProduct.Name = "dgvProduct";
            dgvProduct.ReadOnly = true;
            dgvProduct.RowHeadersVisible = false;
            dgvProduct.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvProduct.Size = new Size(620, 340);
            dgvProduct.TabIndex = 1;
            dgvProduct.CellClick += dgvProduct_CellClick;
            // 
            // FormProduct
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 540);
            Controls.Add(grpDanhSach);
            Controls.Add(grpThongTin);
            Controls.Add(pnlHeader);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormProduct";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý sản phẩm";
            Load += FormProduct_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            grpThongTin.ResumeLayout(false);
            grpThongTin.PerformLayout();
            grpDanhSach.ResumeLayout(false);
            grpDanhSach.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvProduct).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblTitle;

        private GroupBox grpThongTin;
        private Label lblMaSP;
        private Label lblTenSP;
        private Label lblDonGia;
        private Label lblSoLuongTon;

        private TextBox txtMaSP;
        private TextBox txtTenSP;
        private TextBox txtDonGia;
        private TextBox txtSoLuongTon;

        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;

        private GroupBox grpDanhSach;
        private Label lblTongSP;
        private DataGridView dgvProduct;

        private DataGridViewTextBoxColumn colMaSP;
        private DataGridViewTextBoxColumn colTenSP;
        private DataGridViewTextBoxColumn colDonGia;
        private DataGridViewTextBoxColumn colSoLuongTon;
    }
}