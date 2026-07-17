namespace lab03_01
{
    partial class FormQuanLyKhoaHoc
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
            label2 = new Label();
            label3 = new Label();
            txtMaKhoaHoc = new TextBox();
            txtTenKhoaHoc = new TextBox();
            nudSoTinChi = new NumericUpDown();
            btnThem = new Button();
            label4 = new Label();
            lstKhoaHoc = new ListBox();
            ((System.ComponentModel.ISupportInitialize)nudSoTinChi).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(40, 55);
            label1.Name = "label1";
            label1.Size = new Size(79, 15);
            label1.TabIndex = 0;
            label1.Text = "Mã khóa học:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(40, 95);
            label2.Name = "label2";
            label2.Size = new Size(80, 15);
            label2.TabIndex = 1;
            label2.Text = "Tên khóa học:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(40, 135);
            label3.Name = "label3";
            label3.Size = new Size(59, 15);
            label3.TabIndex = 2;
            label3.Text = "Số tín chỉ:";
            // 
            // txtMaKhoaHoc
            // 
            txtMaKhoaHoc.Location = new Point(150, 52);
            txtMaKhoaHoc.Name = "txtMaKhoaHoc";
            txtMaKhoaHoc.Size = new Size(329, 23);
            txtMaKhoaHoc.TabIndex = 3;
            // 
            // txtTenKhoaHoc
            // 
            txtTenKhoaHoc.Location = new Point(150, 92);
            txtTenKhoaHoc.Name = "txtTenKhoaHoc";
            txtTenKhoaHoc.Size = new Size(329, 23);
            txtTenKhoaHoc.TabIndex = 4;
            // 
            // nudSoTinChi
            // 
            nudSoTinChi.Location = new Point(150, 132);
            nudSoTinChi.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nudSoTinChi.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudSoTinChi.Name = "nudSoTinChi";
            nudSoTinChi.Size = new Size(120, 23);
            nudSoTinChi.TabIndex = 5;
            nudSoTinChi.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.Green;
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.ForeColor = Color.White;
            btnThem.Location = new Point(305, 125);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(100, 35);
            btnThem.TabIndex = 6;
            btnThem.Text = "➕ Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(40, 185);
            label4.Name = "label4";
            label4.Size = new Size(117, 15);
            label4.TabIndex = 7;
            label4.Text = "Danh sách khóa học:";
            // 
            // lstKhoaHoc
            // 
            lstKhoaHoc.FormattingEnabled = true;
            lstKhoaHoc.ItemHeight = 15;
            lstKhoaHoc.Location = new Point(40, 210);
            lstKhoaHoc.Name = "lstKhoaHoc";
            lstKhoaHoc.Size = new Size(420, 214);
            lstKhoaHoc.TabIndex = 8;
            // 
            // FormQuanLyKhoaHoc
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(577, 450);
            Controls.Add(lstKhoaHoc);
            Controls.Add(label4);
            Controls.Add(btnThem);
            Controls.Add(nudSoTinChi);
            Controls.Add(txtTenKhoaHoc);
            Controls.Add(txtMaKhoaHoc);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "FormQuanLyKhoaHoc";
            StartPosition = FormStartPosition.Manual;
            Text = "Quản lý Khóa học";
            ((System.ComponentModel.ISupportInitialize)nudSoTinChi).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtMaKhoaHoc;
        private TextBox txtTenKhoaHoc;
        private NumericUpDown nudSoTinChi;
        private Button btnThem;
        private Label label4;
        private ListBox lstKhoaHoc;
    }
}