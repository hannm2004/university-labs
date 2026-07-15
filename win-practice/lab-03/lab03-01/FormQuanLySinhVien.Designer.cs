namespace lab03_01
{
    partial class FormQuanLySinhVien
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
            label1 = new Label();
            grpThongTin = new GroupBox();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            txtMaSV = new TextBox();
            txtHoTen = new TextBox();
            dtpNgaySinh = new DateTimePicker();
            radNam = new RadioButton();
            radNu = new RadioButton();
            txtDiemTB = new TextBox();
            cboKhoa = new ComboBox();
            btnThem = new Button();
            btnCapNhat = new Button();
            btnXoa = new Button();
            button4 = new Button();
            label8 = new Label();
            txtTimKiem = new TextBox();
            dgvSinhVien = new DataGridView();
            lblTongSV = new Label();
            grpThongTin.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSinhVien).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(21, 28);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 0;
            label1.Text = "Mã SV:";
            // 
            // grpThongTin
            // 
            grpThongTin.Controls.Add(cboKhoa);
            grpThongTin.Controls.Add(txtDiemTB);
            grpThongTin.Controls.Add(radNu);
            grpThongTin.Controls.Add(radNam);
            grpThongTin.Controls.Add(dtpNgaySinh);
            grpThongTin.Controls.Add(txtHoTen);
            grpThongTin.Controls.Add(txtMaSV);
            grpThongTin.Controls.Add(label6);
            grpThongTin.Controls.Add(label5);
            grpThongTin.Controls.Add(label4);
            grpThongTin.Controls.Add(label3);
            grpThongTin.Controls.Add(label2);
            grpThongTin.Controls.Add(label1);
            grpThongTin.Location = new Point(35, 29);
            grpThongTin.Name = "grpThongTin";
            grpThongTin.Size = new Size(805, 150);
            grpThongTin.TabIndex = 1;
            grpThongTin.TabStop = false;
            grpThongTin.Text = "Thông tin sinh viên";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(402, 28);
            label2.Name = "label2";
            label2.Size = new Size(61, 15);
            label2.TabIndex = 1;
            label2.Text = "Họ và tên:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(21, 117);
            label3.Name = "label3";
            label3.Size = new Size(37, 15);
            label3.TabIndex = 2;
            label3.Text = "Khoa:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(21, 73);
            label4.Name = "label4";
            label4.Size = new Size(63, 15);
            label4.TabIndex = 3;
            label4.Text = "Ngày sinh:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(402, 73);
            label5.Name = "label5";
            label5.Size = new Size(55, 15);
            label5.TabIndex = 4;
            label5.Text = "Giới tính:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(606, 69);
            label6.Name = "label6";
            label6.Size = new Size(54, 15);
            label6.TabIndex = 5;
            label6.Text = "Điểm TB:";
            // 
            // txtMaSV
            // 
            txtMaSV.Location = new Point(88, 25);
            txtMaSV.Name = "txtMaSV";
            txtMaSV.Size = new Size(174, 23);
            txtMaSV.TabIndex = 6;
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(470, 25);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(174, 23);
            txtHoTen.TabIndex = 7;
            // 
            // dtpNgaySinh
            // 
            dtpNgaySinh.Format = DateTimePickerFormat.Short;
            dtpNgaySinh.Location = new Point(88, 67);
            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.Size = new Size(200, 23);
            dtpNgaySinh.TabIndex = 8;
            // 
            // radNam
            // 
            radNam.AutoSize = true;
            radNam.Location = new Point(463, 69);
            radNam.Name = "radNam";
            radNam.Size = new Size(51, 19);
            radNam.TabIndex = 9;
            radNam.TabStop = true;
            radNam.Text = "Nam";
            radNam.UseVisualStyleBackColor = true;
//            radNam.CheckedChanged += radioButton1_CheckedChanged;
            // 
            // radNu
            // 
            radNu.AutoSize = true;
            radNu.Location = new Point(520, 69);
            radNu.Name = "radNu";
            radNu.Size = new Size(41, 19);
            radNu.TabIndex = 10;
            radNu.TabStop = true;
            radNu.Text = "Nữ";
            radNu.UseVisualStyleBackColor = true;
            // 
            // txtDiemTB
            // 
            txtDiemTB.Location = new Point(663, 61);
            txtDiemTB.Name = "txtDiemTB";
            txtDiemTB.Size = new Size(70, 23);
            txtDiemTB.TabIndex = 11;
            // 
            // cboKhoa
            // 
            cboKhoa.FormattingEnabled = true;
            cboKhoa.Items.AddRange(new object[] { "Công nghệ thông tin", "Quản trị kinh doanh", "Marketing", "Ngôn ngữ Anh", "Kế toán" });
            cboKhoa.Location = new Point(87, 114);
            cboKhoa.Name = "cboKhoa";
            cboKhoa.Size = new Size(405, 23);
            cboKhoa.TabIndex = 12;
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.Green;
            btnThem.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnThem.ForeColor = Color.White;
            btnThem.Location = new Point(35, 196);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(120, 50);
            btnThem.TabIndex = 2;
            btnThem.Text = "+ Thêm";
            btnThem.UseVisualStyleBackColor = false;
            // 
            // btnCapNhat
            // 
            btnCapNhat.BackColor = Color.DodgerBlue;
            btnCapNhat.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCapNhat.ForeColor = Color.White;
            btnCapNhat.Location = new Point(177, 196);
            btnCapNhat.Name = "btnCapNhat";
            btnCapNhat.Size = new Size(120, 50);
            btnCapNhat.TabIndex = 3;
            btnCapNhat.Text = "Cập nhật";
            btnCapNhat.UseVisualStyleBackColor = false;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.Red;
            btnXoa.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnXoa.ForeColor = Color.White;
            btnXoa.Location = new Point(317, 196);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(120, 50);
            btnXoa.TabIndex = 4;
            btnXoa.Text = "Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            button4.BackColor = SystemColors.ControlDark;
            button4.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.ForeColor = Color.White;
            button4.Location = new Point(458, 196);
            button4.Name = "button4";
            button4.Size = new Size(120, 50);
            button4.TabIndex = 5;
            button4.Text = "Làm mới";
            button4.UseVisualStyleBackColor = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(36, 264);
            label8.Name = "label8";
            label8.Size = new Size(74, 15);
            label8.TabIndex = 7;
            label8.Text = "🔍 Tìm kiếm:";
            // 
            // txtTimKiem
            // 
            txtTimKiem.Location = new Point(116, 261);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(391, 23);
            txtTimKiem.TabIndex = 8;
            // 
            // dgvSinhVien
            // 
            dgvSinhVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSinhVien.Location = new Point(36, 300);
            dgvSinhVien.Name = "dgvSinhVien";
            dgvSinhVien.Size = new Size(804, 214);
            dgvSinhVien.TabIndex = 9;
            // 
            // lblTongSV
            // 
            lblTongSV.AutoSize = true;
            lblTongSV.BackColor = SystemColors.Control;
            lblTongSV.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTongSV.ForeColor = Color.Blue;
            lblTongSV.Location = new Point(45, 529);
            lblTongSV.Name = "lblTongSV";
            lblTongSV.Size = new Size(115, 15);
            lblTongSV.TabIndex = 10;
            lblTongSV.Text = "Tổng số sinh viên: 0";
            // 
            // FormQuanLySinhVien
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 561);
            Controls.Add(lblTongSV);
            Controls.Add(dgvSinhVien);
            Controls.Add(txtTimKiem);
            Controls.Add(label8);
            Controls.Add(button4);
            Controls.Add(btnXoa);
            Controls.Add(btnCapNhat);
            Controls.Add(btnThem);
            Controls.Add(grpThongTin);
            Name = "FormQuanLySinhVien";
            Text = "Quản Lý Sinh Viên";
            grpThongTin.ResumeLayout(false);
            grpThongTin.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvSinhVien).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private GroupBox grpThongTin;
        private TextBox txtHoTen;
        private TextBox txtMaSV;
        private Label label6;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private RadioButton radNam;
        private DateTimePicker dtpNgaySinh;
        private RadioButton radNu;
        private ComboBox cboKhoa;
        private TextBox txtDiemTB;
        private Button btnThem;
        private Button btnCapNhat;
        private Button btnXoa;
        private Button button4;
        private Label label8;
        private TextBox txtTimKiem;
        private DataGridView dgvSinhVien;
        private Label lblTongSV;
    }
}