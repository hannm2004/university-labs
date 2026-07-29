namespace QuanLySinhVien.GUI
{
    partial class FormDangKyChuyenNganh
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && components != null)
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblTitle = new Label();
            lblSinhVien = new Label();
            cboSinhVien = new ComboBox();
            lblKhoa = new Label();
            cboKhoa = new ComboBox();
            lblChuyenNganh = new Label();
            cboChuyenNganh = new ComboBox();
            lblCurrent = new Label();
            lblCurrentValue = new Label();
            btnDangKy = new Button();
            btnDong = new Button();
            SuspendLayout();
            // 
            // lblTitle
            // 
            lblTitle.BackColor = Color.FromArgb(230, 240, 255);
            lblTitle.Dock = DockStyle.Top;
            lblTitle.Font = new Font("Segoe UI", 14F, FontStyle.Bold);
            lblTitle.ForeColor = Color.RoyalBlue;
            lblTitle.Location = new Point(0, 0);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(500, 60);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "📋 ĐĂNG KÝ CHUYÊN NGÀNH CHO SINH VIÊN";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // lblSinhVien
            // 
            lblSinhVien.AutoSize = true;
            lblSinhVien.Location = new Point(30, 85);
            lblSinhVien.Name = "lblSinhVien";
            lblSinhVien.Size = new Size(89, 15);
            lblSinhVien.TabIndex = 1;
            lblSinhVien.Text = "Chọn sinh viên:";
            // 
            // cboSinhVien
            // 
            cboSinhVien.DropDownStyle = ComboBoxStyle.DropDownList;
            cboSinhVien.Location = new Point(30, 105);
            cboSinhVien.Name = "cboSinhVien";
            cboSinhVien.Size = new Size(430, 23);
            cboSinhVien.TabIndex = 2;
            cboSinhVien.SelectedIndexChanged += cboSinhVien_SelectedIndexChanged;
            // 
            // lblKhoa
            // 
            lblKhoa.AutoSize = true;
            lblKhoa.Location = new Point(30, 145);
            lblKhoa.Name = "lblKhoa";
            lblKhoa.Size = new Size(37, 15);
            lblKhoa.TabIndex = 3;
            lblKhoa.Text = "Khoa:";
            // 
            // cboKhoa
            // 
            cboKhoa.DropDownStyle = ComboBoxStyle.DropDownList;
            cboKhoa.Location = new Point(30, 165);
            cboKhoa.Name = "cboKhoa";
            cboKhoa.Size = new Size(430, 23);
            cboKhoa.TabIndex = 4;
            cboKhoa.SelectedIndexChanged += cboKhoa_SelectedIndexChanged;
            // 
            // lblChuyenNganh
            // 
            lblChuyenNganh.AutoSize = true;
            lblChuyenNganh.Location = new Point(30, 205);
            lblChuyenNganh.Name = "lblChuyenNganh";
            lblChuyenNganh.Size = new Size(88, 15);
            lblChuyenNganh.TabIndex = 5;
            lblChuyenNganh.Text = "Chuyên ngành:";
            // 
            // cboChuyenNganh
            // 
            cboChuyenNganh.DropDownStyle = ComboBoxStyle.DropDownList;
            cboChuyenNganh.Location = new Point(30, 225);
            cboChuyenNganh.Name = "cboChuyenNganh";
            cboChuyenNganh.Size = new Size(430, 23);
            cboChuyenNganh.TabIndex = 6;
            cboChuyenNganh.SelectedIndexChanged += cboChuyenNganh_SelectedIndexChanged;
            // 
            // lblCurrent
            // 
            lblCurrent.AutoSize = true;
            lblCurrent.Font = new Font("Segoe UI", 9F, FontStyle.Italic);
            lblCurrent.ForeColor = Color.Gray;
            lblCurrent.Location = new Point(30, 270);
            lblCurrent.Name = "lblCurrent";
            lblCurrent.Size = new Size(132, 15);
            lblCurrent.TabIndex = 7;
            lblCurrent.Text = "Chuyên ngành hiện tại:";
            // 
            // lblCurrentValue
            // 
            lblCurrentValue.AutoSize = true;
            lblCurrentValue.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic);
            lblCurrentValue.ForeColor = Color.RoyalBlue;
            lblCurrentValue.Location = new Point(165, 270);
            lblCurrentValue.Name = "lblCurrentValue";
            lblCurrentValue.Size = new Size(84, 15);
            lblCurrentValue.TabIndex = 8;
            lblCurrentValue.Text = "Chưa đăng ký";
            // 
            // btnDangKy
            // 
            btnDangKy.BackColor = Color.SeaGreen;
            btnDangKy.FlatStyle = FlatStyle.Flat;
            btnDangKy.ForeColor = Color.White;
            btnDangKy.Location = new Point(135, 320);
            btnDangKy.Name = "btnDangKy";
            btnDangKy.Size = new Size(110, 40);
            btnDangKy.TabIndex = 9;
            btnDangKy.Text = "💾 Đăng ký";
            btnDangKy.UseVisualStyleBackColor = false;
            btnDangKy.Click += btnDangKy_Click;
            // 
            // btnDong
            // 
            btnDong.BackColor = Color.DimGray;
            btnDong.FlatStyle = FlatStyle.Flat;
            btnDong.ForeColor = Color.White;
            btnDong.Location = new Point(255, 320);
            btnDong.Name = "btnDong";
            btnDong.Size = new Size(110, 40);
            btnDong.TabIndex = 10;
            btnDong.Text = "✖ Đóng";
            btnDong.UseVisualStyleBackColor = false;
            btnDong.Click += btnDong_Click;
            // 
            // FormDangKyChuyenNganh
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(500, 410);
            Controls.Add(lblTitle);
            Controls.Add(lblSinhVien);
            Controls.Add(cboSinhVien);
            Controls.Add(lblKhoa);
            Controls.Add(cboKhoa);
            Controls.Add(lblChuyenNganh);
            Controls.Add(cboChuyenNganh);
            Controls.Add(lblCurrent);
            Controls.Add(lblCurrentValue);
            Controls.Add(btnDangKy);
            Controls.Add(btnDong);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormDangKyChuyenNganh";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Đăng ký Chuyên ngành";
            Load += FormDangKyChuyenNganh_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitle;

        private Label lblSinhVien;
        private ComboBox cboSinhVien;

        private Label lblKhoa;
        private ComboBox cboKhoa;

        private Label lblChuyenNganh;
        private ComboBox cboChuyenNganh;

        private Label lblCurrent;
        private Label lblCurrentValue;

        private Button btnDangKy;
        private Button btnDong;
    }
}