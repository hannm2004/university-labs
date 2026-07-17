namespace lab03_02
{
    partial class FormChiTietSinhVien
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
            txtMaSV = new TextBox();
            txtHoTen = new TextBox();
            txtDiemTB = new TextBox();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            cboKhoa = new ComboBox();
            radNam = new RadioButton();
            radNu = new RadioButton();
            dtNgaySinh = new DateTimePicker();
            btnLuu = new Button();
            btnHuy = new Button();
            SuspendLayout();
            // 
            // txtMaSV
            // 
            txtMaSV.Location = new Point(268, 46);
            txtMaSV.Name = "txtMaSV";
            txtMaSV.Size = new Size(312, 23);
            txtMaSV.TabIndex = 0;
            // 
            // txtHoTen
            // 
            txtHoTen.Location = new Point(268, 96);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(312, 23);
            txtHoTen.TabIndex = 1;
            // 
            // txtDiemTB
            // 
            txtDiemTB.Location = new Point(268, 320);
            txtDiemTB.Name = "txtDiemTB";
            txtDiemTB.Size = new Size(118, 23);
            txtDiemTB.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(69, 47);
            label1.Name = "label1";
            label1.Size = new Size(43, 15);
            label1.TabIndex = 3;
            label1.Text = "Mã SV:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(69, 104);
            label2.Name = "label2";
            label2.Size = new Size(61, 15);
            label2.TabIndex = 4;
            label2.Text = "Họ và tên:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(69, 159);
            label3.Name = "label3";
            label3.Size = new Size(63, 15);
            label3.TabIndex = 5;
            label3.Text = "Ngày sinh:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(69, 213);
            label4.Name = "label4";
            label4.Size = new Size(55, 15);
            label4.TabIndex = 6;
            label4.Text = "Giới tính:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(69, 265);
            label5.Name = "label5";
            label5.Size = new Size(37, 15);
            label5.TabIndex = 7;
            label5.Text = "Khoa:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(69, 320);
            label6.Name = "label6";
            label6.Size = new Size(54, 15);
            label6.TabIndex = 8;
            label6.Text = "Điểm TB:";
            // 
            // cboKhoa
            // 
            cboKhoa.DropDownStyle = ComboBoxStyle.DropDownList;
            cboKhoa.FormattingEnabled = true;
            cboKhoa.Location = new Point(268, 257);
            cboKhoa.Name = "cboKhoa";
            cboKhoa.Size = new Size(312, 23);
            cboKhoa.TabIndex = 9;
            // 
            // radNam
            // 
            radNam.AutoSize = true;
            radNam.Location = new Point(268, 209);
            radNam.Name = "radNam";
            radNam.Size = new Size(51, 19);
            radNam.TabIndex = 10;
            radNam.TabStop = true;
            radNam.Text = "Nam";
            radNam.UseVisualStyleBackColor = true;
            // 
            // radNu
            // 
            radNu.AutoSize = true;
            radNu.Location = new Point(404, 209);
            radNu.Name = "radNu";
            radNu.Size = new Size(41, 19);
            radNu.TabIndex = 11;
            radNu.TabStop = true;
            radNu.Text = "Nữ";
            radNu.UseVisualStyleBackColor = true;
            // 
            // dtNgaySinh
            // 
            dtNgaySinh.Format = DateTimePickerFormat.Short;
            dtNgaySinh.Location = new Point(268, 151);
            dtNgaySinh.Name = "dtNgaySinh";
            dtNgaySinh.Size = new Size(312, 23);
            dtNgaySinh.TabIndex = 12;
            // 
            // btnLuu
            // 
            btnLuu.BackColor = Color.Green;
            btnLuu.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnLuu.ForeColor = Color.White;
            btnLuu.Location = new Point(312, 374);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(120, 44);
            btnLuu.TabIndex = 13;
            btnLuu.Text = "💾 Lưu";
            btnLuu.UseVisualStyleBackColor = false;
            btnLuu.Click += btnLuu_Click;
            // 
            // btnHuy
            // 
            btnHuy.BackColor = SystemColors.ActiveBorder;
            btnHuy.Font = new Font("Segoe UI", 9.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHuy.ForeColor = Color.White;
            btnHuy.Location = new Point(460, 374);
            btnHuy.Name = "btnHuy";
            btnHuy.Size = new Size(120, 44);
            btnHuy.TabIndex = 14;
            btnHuy.Text = "❌ Hủy";
            btnHuy.UseVisualStyleBackColor = false;
            btnHuy.Click += btnHuy_Click;
            // 
            // FormChiTietSinhVien
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(644, 450);
            Controls.Add(btnHuy);
            Controls.Add(btnLuu);
            Controls.Add(dtNgaySinh);
            Controls.Add(radNu);
            Controls.Add(radNam);
            Controls.Add(cboKhoa);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(txtDiemTB);
            Controls.Add(txtHoTen);
            Controls.Add(txtMaSV);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormChiTietSinhVien";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Thông Tin Sinh Viên";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtMaSV;
        private TextBox txtHoTen;
        private TextBox txtDiemTB;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private ComboBox cboKhoa;
        private RadioButton radNam;
        private RadioButton radNu;
        private DateTimePicker dtNgaySinh;
        private Button btnLuu;
        private Button btnHuy;
    }
}