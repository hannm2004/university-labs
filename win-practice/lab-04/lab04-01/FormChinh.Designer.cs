namespace lab04_01
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            menuStrip1 = new MenuStrip();
            tệpToolStripMenuItem = new ToolStripMenuItem();
            dữLiệuToolStripMenuItem = new ToolStripMenuItem();
            quanLyKhoaToolStripMenuItem = new ToolStripMenuItem();
            tìmKiếmToolStripMenuItem = new ToolStripMenuItem();
            grpThongTin = new GroupBox();
            btnLamMoi = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnThem = new Button();
            txtDiemTB = new TextBox();
            label4 = new Label();
            btnThemKhoa = new Button();
            cboKhoa = new ComboBox();
            label3 = new Label();
            rdoNu = new RadioButton();
            rdoNam = new RadioButton();
            label1 = new Label();
            dtpNgaySinh = new DateTimePicker();
            label2 = new Label();
            txtHoTen = new TextBox();
            lblHoTen = new Label();
            txtMaSV = new TextBox();
            lblMaSV = new Label();
            pnlDanhSach = new Panel();
            dgvSinhVien = new DataGridView();
            lblTitle = new Label();
            statusStripChinh = new StatusStrip();
            lblTrangThai = new ToolStripStatusLabel();
            lblTongSo = new ToolStripStatusLabel();
            menuStrip1.SuspendLayout();
            grpThongTin.SuspendLayout();
            pnlDanhSach.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSinhVien).BeginInit();
            statusStripChinh.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { tệpToolStripMenuItem, dữLiệuToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(984, 24);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStripChinh";
            // 
            // tệpToolStripMenuItem
            // 
            tệpToolStripMenuItem.Name = "tệpToolStripMenuItem";
            tệpToolStripMenuItem.Size = new Size(38, 20);
            tệpToolStripMenuItem.Text = "Tệp";
            // 
            // dữLiệuToolStripMenuItem
            // 
            dữLiệuToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { quanLyKhoaToolStripMenuItem, tìmKiếmToolStripMenuItem });
            dữLiệuToolStripMenuItem.Name = "dữLiệuToolStripMenuItem";
            dữLiệuToolStripMenuItem.Size = new Size(56, 20);
            dữLiệuToolStripMenuItem.Text = "Dữ liệu";
            // 
            // quanLyKhoaToolStripMenuItem
            // 
            quanLyKhoaToolStripMenuItem.Image = (Image)resources.GetObject("quanLyKhoaToolStripMenuItem.Image");
            quanLyKhoaToolStripMenuItem.Name = "quanLyKhoaToolStripMenuItem";
            quanLyKhoaToolStripMenuItem.ShortcutKeys = Keys.F1;
            quanLyKhoaToolStripMenuItem.Size = new Size(180, 22);
            quanLyKhoaToolStripMenuItem.Text = "Quản lý khoa";
            quanLyKhoaToolStripMenuItem.Click += quanLyKhoaToolStripMenuItem_Click;
            // 
            // tìmKiếmToolStripMenuItem
            // 
            tìmKiếmToolStripMenuItem.Image = (Image)resources.GetObject("tìmKiếmToolStripMenuItem.Image");
            tìmKiếmToolStripMenuItem.Name = "tìmKiếmToolStripMenuItem";
            tìmKiếmToolStripMenuItem.ShortcutKeys = Keys.Control | Keys.F;
            tìmKiếmToolStripMenuItem.Size = new Size(180, 22);
            tìmKiếmToolStripMenuItem.Text = "Tìm kiếm";
            tìmKiếmToolStripMenuItem.Click += tìmKiếmToolStripMenuItem_Click;
            // 
            // grpThongTin
            // 
            grpThongTin.Controls.Add(btnLamMoi);
            grpThongTin.Controls.Add(btnSua);
            grpThongTin.Controls.Add(btnXoa);
            grpThongTin.Controls.Add(btnThem);
            grpThongTin.Controls.Add(txtDiemTB);
            grpThongTin.Controls.Add(label4);
            grpThongTin.Controls.Add(btnThemKhoa);
            grpThongTin.Controls.Add(cboKhoa);
            grpThongTin.Controls.Add(label3);
            grpThongTin.Controls.Add(rdoNu);
            grpThongTin.Controls.Add(rdoNam);
            grpThongTin.Controls.Add(label1);
            grpThongTin.Controls.Add(dtpNgaySinh);
            grpThongTin.Controls.Add(label2);
            grpThongTin.Controls.Add(txtHoTen);
            grpThongTin.Controls.Add(lblHoTen);
            grpThongTin.Controls.Add(txtMaSV);
            grpThongTin.Controls.Add(lblMaSV);
            grpThongTin.Location = new Point(26, 110);
            grpThongTin.Name = "grpThongTin";
            grpThongTin.Size = new Size(250, 479);
            grpThongTin.TabIndex = 2;
            grpThongTin.TabStop = false;
            grpThongTin.Text = "Thông Tin Sinh Viên";
            // 
            // btnLamMoi
            // 
            btnLamMoi.BackColor = Color.DimGray;
            btnLamMoi.FlatStyle = FlatStyle.Flat;
            btnLamMoi.ForeColor = Color.White;
            btnLamMoi.Location = new Point(126, 432);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(95, 35);
            btnLamMoi.TabIndex = 21;
            btnLamMoi.Text = "↻ Làm mới";
            btnLamMoi.UseVisualStyleBackColor = false;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.DodgerBlue;
            btnSua.FlatStyle = FlatStyle.Flat;
            btnSua.ForeColor = Color.White;
            btnSua.Location = new Point(126, 382);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(95, 35);
            btnSua.TabIndex = 19;
            btnSua.Text = "✏ Sửa";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.Crimson;
            btnXoa.FlatStyle = FlatStyle.Flat;
            btnXoa.ForeColor = Color.White;
            btnXoa.Location = new Point(16, 432);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(95, 35);
            btnXoa.TabIndex = 20;
            btnXoa.Text = "✖ Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.ForestGreen;
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.ForeColor = Color.White;
            btnThem.Location = new Point(16, 382);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(95, 35);
            btnThem.TabIndex = 18;
            btnThem.Text = "➕ Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // txtDiemTB
            // 
            txtDiemTB.Location = new Point(22, 339);
            txtDiemTB.Name = "txtDiemTB";
            txtDiemTB.Size = new Size(80, 23);
            txtDiemTB.TabIndex = 17;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(22, 321);
            label4.Name = "label4";
            label4.Size = new Size(54, 15);
            label4.TabIndex = 16;
            label4.Text = "Điểm TB:";
            // 
            // btnThemKhoa
            // 
            btnThemKhoa.BackColor = Color.Gold;
            btnThemKhoa.FlatStyle = FlatStyle.Flat;
            btnThemKhoa.Location = new Point(195, 283);
            btnThemKhoa.Name = "btnThemKhoa";
            btnThemKhoa.Size = new Size(30, 25);
            btnThemKhoa.TabIndex = 15;
            btnThemKhoa.Text = "+";
            btnThemKhoa.UseVisualStyleBackColor = false;
            btnThemKhoa.Click += btnThemKhoa_Click;
            // 
            // cboKhoa
            // 
            cboKhoa.DropDownStyle = ComboBoxStyle.DropDownList;
            cboKhoa.FormattingEnabled = true;
            cboKhoa.Location = new Point(22, 283);
            cboKhoa.Name = "cboKhoa";
            cboKhoa.Size = new Size(160, 23);
            cboKhoa.TabIndex = 14;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(22, 255);
            label3.Name = "label3";
            label3.Size = new Size(37, 15);
            label3.TabIndex = 13;
            label3.Text = "Khoa:";
            // 
            // rdoNu
            // 
            rdoNu.AutoSize = true;
            rdoNu.Location = new Point(126, 223);
            rdoNu.Name = "rdoNu";
            rdoNu.Size = new Size(41, 19);
            rdoNu.TabIndex = 12;
            rdoNu.Text = "Nữ";
            rdoNu.UseVisualStyleBackColor = true;
            // 
            // rdoNam
            // 
            rdoNam.AutoSize = true;
            rdoNam.Location = new Point(26, 223);
            rdoNam.Name = "rdoNam";
            rdoNam.Size = new Size(51, 19);
            rdoNam.TabIndex = 11;
            rdoNam.Text = "Nam";
            rdoNam.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(22, 200);
            label1.Name = "label1";
            label1.Size = new Size(55, 15);
            label1.TabIndex = 10;
            label1.Text = "Giới tính:";
            // 
            // dtpNgaySinh
            // 
            dtpNgaySinh.Format = DateTimePickerFormat.Short;
            dtpNgaySinh.Location = new Point(22, 159);
            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.Size = new Size(180, 23);
            dtpNgaySinh.TabIndex = 9;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(22, 141);
            label2.Name = "label2";
            label2.Size = new Size(63, 15);
            label2.TabIndex = 8;
            label2.Text = "Ngày sinh:";
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(22, 103);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(180, 23);
            txtHoTen.TabIndex = 6;
            // 
            // lblHoTen
            // 
            lblHoTen.AutoSize = true;
            lblHoTen.Location = new Point(22, 85);
            lblHoTen.Name = "lblHoTen";
            lblHoTen.Size = new Size(47, 15);
            lblHoTen.TabIndex = 5;
            lblHoTen.Text = "Họ Tên:";
            // 
            // txtMaSV
            // 
            txtMaSV.Location = new Point(22, 47);
            txtMaSV.Name = "txtMaSV";
            txtMaSV.Size = new Size(180, 23);
            txtMaSV.TabIndex = 4;
            // 
            // lblMaSV
            // 
            lblMaSV.AutoSize = true;
            lblMaSV.Location = new Point(22, 29);
            lblMaSV.Name = "lblMaSV";
            lblMaSV.Size = new Size(59, 15);
            lblMaSV.TabIndex = 3;
            lblMaSV.Text = "Mã Số SV:";
            // 
            // pnlDanhSach
            // 
            pnlDanhSach.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            pnlDanhSach.BorderStyle = BorderStyle.FixedSingle;
            pnlDanhSach.Controls.Add(dgvSinhVien);
            pnlDanhSach.Location = new Point(270, 110);
            pnlDanhSach.Name = "pnlDanhSach";
            pnlDanhSach.Size = new Size(700, 420);
            pnlDanhSach.TabIndex = 3;
            // 
            // dgvSinhVien
            // 
            dgvSinhVien.AllowUserToAddRows = false;
            dgvSinhVien.AllowUserToDeleteRows = false;
            dgvSinhVien.AllowUserToResizeRows = false;
            dgvSinhVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSinhVien.BackgroundColor = SystemColors.ButtonHighlight;
            dgvSinhVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSinhVien.Dock = DockStyle.Fill;
            dgvSinhVien.Location = new Point(0, 0);
            dgvSinhVien.MultiSelect = false;
            dgvSinhVien.Name = "dgvSinhVien";
            dgvSinhVien.ReadOnly = true;
            dgvSinhVien.RowHeadersVisible = false;
            dgvSinhVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSinhVien.Size = new Size(698, 418);
            dgvSinhVien.TabIndex = 3;
            dgvSinhVien.CellClick += dgvSinhVien_CellClick;
            dgvSinhVien.CellContentClick += dgvSinhVien_CellContentClick;
            // 
            // lblTitle
            // 
            lblTitle.BackColor = SystemColors.GradientInactiveCaption;
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitle.ForeColor = Color.RoyalBlue;
            lblTitle.Location = new Point(0, 24);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(984, 60);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "🎓 QUẢN LÝ THÔNG TIN SINH VIÊN";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // statusStripChinh
            // 
            statusStripChinh.Items.AddRange(new ToolStripItem[] { lblTrangThai, lblTongSo });
            statusStripChinh.Location = new Point(0, 613);
            statusStripChinh.Name = "statusStripChinh";
            statusStripChinh.Size = new Size(984, 22);
            statusStripChinh.TabIndex = 4;
            statusStripChinh.Text = "statusStrip1";
            // 
            // lblTrangThai
            // 
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new Size(484, 17);
            lblTrangThai.Spring = true;
            lblTrangThai.Text = "Sẵn sàng";
            lblTrangThai.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTongSo
            // 
            lblTongSo.Name = "lblTongSo";
            lblTongSo.Size = new Size(484, 17);
            lblTongSo.Spring = true;
            lblTongSo.Text = "Tổng số sinh viên: 0";
            lblTongSo.TextAlign = ContentAlignment.MiddleRight;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(984, 635);
            Controls.Add(statusStripChinh);
            Controls.Add(lblTitle);
            Controls.Add(grpThongTin);
            Controls.Add(pnlDanhSach);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản Lý Sinh Viên";
            Load += Form1_Load;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            grpThongTin.ResumeLayout(false);
            grpThongTin.PerformLayout();
            pnlDanhSach.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dgvSinhVien).EndInit();
            statusStripChinh.ResumeLayout(false);
            statusStripChinh.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem tệpToolStripMenuItem;
        private ToolStripMenuItem dữLiệuToolStripMenuItem;
        private GroupBox grpThongTin;
        private TextBox txtMaSV;
        private Label lblMaSV;
        private RadioButton rdoNu;
        private RadioButton rdoNam;
        private Label label1;
        private DateTimePicker dtpNgaySinh;
        private Label label2;
        private TextBox txtHoTen;
        private Label lblHoTen;
        private Button btnSua;
        private Button btnThem;
        private TextBox txtDiemTB;
        private Label label4;
        private Button btnThemKhoa;
        private ComboBox cboKhoa;
        private Label label3;
        private Button btnXoa;
        private Button btnLamMoi;
        private Panel pnlDanhSach;
        private DataGridView dgvSinhVien;
        private Label lblTitle;
        private StatusStrip statusStripChinh;
        private ToolStripStatusLabel lblTrangThai;
        private ToolStripStatusLabel lblTongSo;
        private ToolStripMenuItem quanLyKhoaToolStripMenuItem;
        private ToolStripMenuItem tìmKiếmToolStripMenuItem;
    }
}
