namespace QuanLySinhVien.GUI
{
    partial class FormTraCuuSinhVien
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
            pnlTitle = new Panel();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            txtTuKhoa = new TextBox();
            cboChuyenNganh = new ComboBox();
            nudTu = new NumericUpDown();
            nudDen = new NumericUpDown();
            label5 = new Label();
            chkBaoGomChuaCoDiem = new CheckBox();
            btnXoaBoLoc = new Button();
            lblKetQua = new Label();
            dgvSinhVien = new DataGridView();
            pnlTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudTu).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudDen).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvSinhVien).BeginInit();
            SuspendLayout();
            // 
            // pnlTitle
            // 
            pnlTitle.BackColor = Color.AliceBlue;
            pnlTitle.Controls.Add(label1);
            pnlTitle.Dock = DockStyle.Top;
            pnlTitle.Location = new Point(0, 0);
            pnlTitle.Name = "pnlTitle";
            pnlTitle.Size = new Size(884, 70);
            pnlTitle.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.AliceBlue;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.RoyalBlue;
            label1.Location = new Point(250, 20);
            label1.Name = "label1";
            label1.Size = new Size(288, 32);
            label1.TabIndex = 0;
            label1.Text = "🔍 TRA CỨU SINH VIÊN";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(39, 87);
            label2.Name = "label2";
            label2.Size = new Size(90, 15);
            label2.TabIndex = 1;
            label2.Text = "Mã SV / Họ tên:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(39, 119);
            label3.Name = "label3";
            label3.Size = new Size(37, 15);
            label3.TabIndex = 2;
            label3.Text = "Khoa:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(42, 152);
            label4.Name = "label4";
            label4.Size = new Size(68, 15);
            label4.TabIndex = 3;
            label4.Text = "Điểm TB từ:";
            // 
            // txtTuKhoa
            // 
            txtTuKhoa.Location = new Point(171, 79);
            txtTuKhoa.Name = "txtTuKhoa";
            txtTuKhoa.PlaceholderText = "Nhập Mã SV hoặc Họ tên...";
            txtTuKhoa.Size = new Size(250, 23);
            txtTuKhoa.TabIndex = 4;
            txtTuKhoa.TextChanged += txtTuKhoa_TextChanged;
            // 
            // cboChuyenNganh
            // 
            cboChuyenNganh.DropDownStyle = ComboBoxStyle.DropDownList;
            cboChuyenNganh.FormattingEnabled = true;
            cboChuyenNganh.Items.AddRange(new object[] { "-- Tất cả Khoa --" });
            cboChuyenNganh.Location = new Point(171, 111);
            cboChuyenNganh.Name = "cboChuyenNganh";
            cboChuyenNganh.Size = new Size(250, 23);
            cboChuyenNganh.TabIndex = 5;
            cboChuyenNganh.SelectedIndexChanged += cboChuyenNganh_SelectedIndexChanged;
            // 
            // nudTu
            // 
            nudTu.DecimalPlaces = 1;
            nudTu.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            nudTu.Location = new Point(171, 144);
            nudTu.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nudTu.Name = "nudTu";
            nudTu.Size = new Size(84, 23);
            nudTu.TabIndex = 6;
            nudTu.ValueChanged += nudTu_ValueChanged;
            // 
            // nudDen
            // 
            nudDen.DecimalPlaces = 1;
            nudDen.Increment = new decimal(new int[] { 5, 0, 0, 65536 });
            nudDen.Location = new Point(324, 144);
            nudDen.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nudDen.Name = "nudDen";
            nudDen.Size = new Size(84, 23);
            nudDen.TabIndex = 7;
            nudDen.ValueChanged += nudDen_ValueChanged;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(275, 152);
            label5.Name = "label5";
            label5.Size = new Size(30, 15);
            label5.TabIndex = 8;
            label5.Text = "đến:";
            // 
            // chkBaoGomChuaCoDiem
            // 
            chkBaoGomChuaCoDiem.AutoSize = true;
            chkBaoGomChuaCoDiem.Checked = true;
            chkBaoGomChuaCoDiem.CheckState = CheckState.Checked;
            chkBaoGomChuaCoDiem.Location = new Point(42, 190);
            chkBaoGomChuaCoDiem.Name = "chkBaoGomChuaCoDiem";
            chkBaoGomChuaCoDiem.Size = new Size(165, 19);
            chkBaoGomChuaCoDiem.TabIndex = 9;
            chkBaoGomChuaCoDiem.Text = "Bao gồm SV chưa có điểm";
            chkBaoGomChuaCoDiem.UseVisualStyleBackColor = true;
            chkBaoGomChuaCoDiem.CheckedChanged += chkBaoGomChuaCoDiem_CheckedChanged;
            // 
            // btnXoaBoLoc
            // 
            btnXoaBoLoc.BackColor = Color.SlateGray;
            btnXoaBoLoc.FlatStyle = FlatStyle.Flat;
            btnXoaBoLoc.ForeColor = Color.White;
            btnXoaBoLoc.Location = new Point(250, 190);
            btnXoaBoLoc.Name = "btnXoaBoLoc";
            btnXoaBoLoc.Size = new Size(110, 40);
            btnXoaBoLoc.TabIndex = 10;
            btnXoaBoLoc.Text = "↺ Xóa bộ lọc";
            btnXoaBoLoc.UseVisualStyleBackColor = false;
            btnXoaBoLoc.Click += btnXoaBoLoc_Click;
            // 
            // lblKetQua
            // 
            lblKetQua.AutoSize = true;
            lblKetQua.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblKetQua.ForeColor = Color.RoyalBlue;
            lblKetQua.Location = new Point(39, 224);
            lblKetQua.Name = "lblKetQua";
            lblKetQua.Size = new Size(120, 15);
            lblKetQua.TabIndex = 11;
            lblKetQua.Text = "Tìm thấy: 0 sinh viên";
            // 
            // dgvSinhVien
            // 
            dgvSinhVien.AllowUserToAddRows = false;
            dgvSinhVien.AllowUserToDeleteRows = false;
            dgvSinhVien.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSinhVien.BackgroundColor = Color.White;
            dgvSinhVien.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSinhVien.Dock = DockStyle.Bottom;
            dgvSinhVien.Location = new Point(0, 251);
            dgvSinhVien.MultiSelect = false;
            dgvSinhVien.Name = "dgvSinhVien";
            dgvSinhVien.ReadOnly = true;
            dgvSinhVien.RowHeadersVisible = false;
            dgvSinhVien.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvSinhVien.Size = new Size(884, 330);
            dgvSinhVien.TabIndex = 12;
            // 
            // FormTraCuuSinhVien
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 581);
            Controls.Add(dgvSinhVien);
            Controls.Add(lblKetQua);
            Controls.Add(btnXoaBoLoc);
            Controls.Add(chkBaoGomChuaCoDiem);
            Controls.Add(label5);
            Controls.Add(nudDen);
            Controls.Add(nudTu);
            Controls.Add(cboChuyenNganh);
            Controls.Add(txtTuKhoa);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(pnlTitle);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            KeyPreview = true;
            MaximizeBox = false;
            Name = "FormTraCuuSinhVien";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tra cứu Sinh viên";
            Load += FormTraCuuSinhVien_Load;
            pnlTitle.ResumeLayout(false);
            pnlTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudTu).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudDen).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvSinhVien).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlTitle;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private TextBox txtTuKhoa;
        private ComboBox cboChuyenNganh;
        private NumericUpDown nudTu;
        private NumericUpDown nudDen;
        private Label label5;
        private CheckBox chkBaoGomChuaCoDiem;
        private Button btnXoaBoLoc;
        private Label lblKetQua;
        private DataGridView dgvSinhVien;
    }
}