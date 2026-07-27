namespace QuanLySinhVien.GUI
{
    partial class FormQuanLyKhoa
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
            grpThongTinKhoa = new GroupBox();
            chkTongGV = new CheckBox();
            chkNamThanhLap = new CheckBox();
            btnLamMoi = new Button();
            btnXoa = new Button();
            btnSua = new Button();
            btnThem = new Button();
            nudNamThanhLap = new NumericUpDown();
            nudTongGV = new NumericUpDown();
            txtTenKhoa = new TextBox();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            pnlTitle = new Panel();
            label1 = new Label();
            dgvKhoa = new DataGridView();
            statusStrip1 = new StatusStrip();
            lblTrangThai = new ToolStripStatusLabel();
            lblTongKhoa = new ToolStripStatusLabel();
            grpThongTinKhoa.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudNamThanhLap).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudTongGV).BeginInit();
            pnlTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKhoa).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // grpThongTinKhoa
            // 
            grpThongTinKhoa.Controls.Add(chkTongGV);
            grpThongTinKhoa.Controls.Add(chkNamThanhLap);
            grpThongTinKhoa.Controls.Add(btnLamMoi);
            grpThongTinKhoa.Controls.Add(btnXoa);
            grpThongTinKhoa.Controls.Add(btnSua);
            grpThongTinKhoa.Controls.Add(btnThem);
            grpThongTinKhoa.Controls.Add(nudNamThanhLap);
            grpThongTinKhoa.Controls.Add(nudTongGV);
            grpThongTinKhoa.Controls.Add(txtTenKhoa);
            grpThongTinKhoa.Controls.Add(label5);
            grpThongTinKhoa.Controls.Add(label4);
            grpThongTinKhoa.Controls.Add(label3);
            grpThongTinKhoa.Controls.Add(label2);
            grpThongTinKhoa.Location = new Point(10, 80);
            grpThongTinKhoa.Name = "grpThongTinKhoa";
            grpThongTinKhoa.Size = new Size(260, 420);
            grpThongTinKhoa.TabIndex = 0;
            grpThongTinKhoa.TabStop = false;
            grpThongTinKhoa.Text = "Thông Tin Khoa";
            // 
            // chkTongGV
            // 
            chkTongGV.AutoSize = true;
            chkTongGV.Checked = true;
            chkTongGV.CheckState = CheckState.Checked;
            chkTongGV.Location = new Point(141, 189);
            chkTongGV.Name = "chkTongGV";
            chkTongGV.Size = new Size(68, 19);
            chkTongGV.TabIndex = 5;
            chkTongGV.Text = "Chưa rõ";
            chkTongGV.UseVisualStyleBackColor = true;
            chkTongGV.CheckedChanged += chkTongGV_CheckedChanged;
            // 
            // chkNamThanhLap
            // 
            chkNamThanhLap.AutoSize = true;
            chkNamThanhLap.Checked = true;
            chkNamThanhLap.CheckState = CheckState.Checked;
            chkNamThanhLap.Location = new Point(141, 116);
            chkNamThanhLap.Name = "chkNamThanhLap";
            chkNamThanhLap.Size = new Size(68, 19);
            chkNamThanhLap.TabIndex = 5;
            chkNamThanhLap.Text = "Chưa rõ";
            chkNamThanhLap.UseVisualStyleBackColor = true;
            chkNamThanhLap.CheckedChanged += chkNamThanhLap_CheckedChanged;
            // 
            // btnLamMoi
            // 
            btnLamMoi.BackColor = Color.SlateGray;
            btnLamMoi.FlatStyle = FlatStyle.Flat;
            btnLamMoi.ForeColor = Color.White;
            btnLamMoi.Location = new Point(130, 300);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(90, 38);
            btnLamMoi.TabIndex = 10;
            btnLamMoi.Text = "↻ Làm mới";
            btnLamMoi.UseVisualStyleBackColor = false;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.Crimson;
            btnXoa.FlatStyle = FlatStyle.Flat;
            btnXoa.ForeColor = Color.White;
            btnXoa.Location = new Point(20, 300);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(90, 38);
            btnXoa.TabIndex = 9;
            btnXoa.Text = "❌ Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;
            // 
            // btnSua
            // 
            btnSua.BackColor = Color.DodgerBlue;
            btnSua.FlatStyle = FlatStyle.Flat;
            btnSua.ForeColor = Color.White;
            btnSua.Location = new Point(130, 241);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(90, 38);
            btnSua.TabIndex = 8;
            btnSua.Text = "✏ Sửa";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;
            // 
            // btnThem
            // 
            btnThem.BackColor = Color.SeaGreen;
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.ForeColor = Color.White;
            btnThem.Location = new Point(20, 241);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(90, 38);
            btnThem.TabIndex = 7;
            btnThem.Text = "➕ Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;
            // 
            // nudNamThanhLap
            // 
            nudNamThanhLap.Location = new Point(6, 112);
            nudNamThanhLap.Maximum = new decimal(new int[] { 3000, 0, 0, 0 });
            nudNamThanhLap.Minimum = new decimal(new int[] { 1900, 0, 0, 0 });
            nudNamThanhLap.Name = "nudNamThanhLap";
            nudNamThanhLap.Size = new Size(89, 23);
            nudNamThanhLap.TabIndex = 6;
            nudNamThanhLap.Value = new decimal(new int[] { 1900, 0, 0, 0 });
            // 
            // nudTongGV
            // 
            nudTongGV.Location = new Point(6, 185);
            nudTongGV.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            nudTongGV.Name = "nudTongGV";
            nudTongGV.Size = new Size(89, 23);
            nudTongGV.TabIndex = 5;
            // 
            // txtTenKhoa
            // 
            txtTenKhoa.Location = new Point(6, 49);
            txtTenKhoa.Name = "txtTenKhoa";
            txtTenKhoa.Size = new Size(248, 23);
            txtTenKhoa.TabIndex = 4;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(119, 211);
            label5.Name = "label5";
            label5.Size = new Size(0, 15);
            label5.TabIndex = 3;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(6, 161);
            label4.Name = "label4";
            label4.Size = new Size(111, 15);
            label4.TabIndex = 2;
            label4.Text = "Tổng số Giảng viên:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(6, 85);
            label3.Name = "label3";
            label3.Size = new Size(89, 15);
            label3.TabIndex = 1;
            label3.Text = "Năm thành lập:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(6, 31);
            label2.Name = "label2";
            label2.Size = new Size(58, 15);
            label2.TabIndex = 0;
            label2.Text = "Tên Khoa:";
            // 
            // pnlTitle
            // 
            pnlTitle.BackColor = Color.AliceBlue;
            pnlTitle.Controls.Add(label1);
            pnlTitle.Dock = DockStyle.Top;
            pnlTitle.Location = new Point(0, 0);
            pnlTitle.Name = "pnlTitle";
            pnlTitle.Size = new Size(984, 70);
            pnlTitle.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.RoyalBlue;
            label1.Location = new Point(300, 20);
            label1.Name = "label1";
            label1.Size = new Size(235, 32);
            label1.TabIndex = 0;
            label1.Text = "🏛 QUẢN LÝ KHOA";
            // 
            // dgvKhoa
            // 
            dgvKhoa.AllowUserToAddRows = false;
            dgvKhoa.AllowUserToDeleteRows = false;
            dgvKhoa.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvKhoa.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvKhoa.BackgroundColor = Color.White;
            dgvKhoa.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvKhoa.Location = new Point(285, 80);
            dgvKhoa.MultiSelect = false;
            dgvKhoa.Name = "dgvKhoa";
            dgvKhoa.ReadOnly = true;
            dgvKhoa.RowHeadersVisible = false;
            dgvKhoa.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvKhoa.Size = new Size(657, 420);
            dgvKhoa.TabIndex = 2;
            dgvKhoa.CellClick += dgvKhoa_CellClick;
            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblTrangThai, lblTongKhoa });
            statusStrip1.Location = new Point(0, 539);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(984, 22);
            statusStrip1.TabIndex = 3;
            statusStrip1.Text = "statusStrip1";
            // 
            // lblTrangThai
            // 
            lblTrangThai.Name = "lblTrangThai";
            lblTrangThai.Size = new Size(484, 17);
            lblTrangThai.Spring = true;
            lblTrangThai.Text = "Sẵn sàng";
            lblTrangThai.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTongKhoa
            // 
            lblTongKhoa.Name = "lblTongKhoa";
            lblTongKhoa.Size = new Size(484, 17);
            lblTongKhoa.Spring = true;
            lblTongKhoa.Text = "Tổng số khoa: 0";
            lblTongKhoa.TextAlign = ContentAlignment.MiddleRight;
            // 
            // FormQuanLyKhoa
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 561);
            Controls.Add(statusStrip1);
            Controls.Add(dgvKhoa);
            Controls.Add(pnlTitle);
            Controls.Add(grpThongTinKhoa);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            KeyPreview = true;
            MaximizeBox = false;
            MinimumSize = new Size(1000, 600);
            Name = "FormQuanLyKhoa";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý Khoa";
            Load += FormQuanLyKhoa_Load;
            grpThongTinKhoa.ResumeLayout(false);
            grpThongTinKhoa.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudNamThanhLap).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudTongGV).EndInit();
            pnlTitle.ResumeLayout(false);
            pnlTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvKhoa).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox grpThongTinKhoa;
        private Panel pnlTitle;
        private NumericUpDown nudNamThanhLap;
        private NumericUpDown nudTongGV;
        private TextBox txtTenKhoa;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private CheckBox chkTongGV;
        private CheckBox chkNamThanhLap;
        private Button btnLamMoi;
        private Button btnXoa;
        private Button btnSua;
        private Button btnThem;
        private DataGridView dgvKhoa;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblTrangThai;
        private ToolStripStatusLabel lblTongKhoa;
    }
}