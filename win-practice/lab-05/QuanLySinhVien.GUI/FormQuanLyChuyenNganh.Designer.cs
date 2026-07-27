namespace QuanLySinhVien.GUI
{
    partial class FormQuanLyChuyenNganh
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            grpThongTin = new GroupBox();
            cboKhoa = new ComboBox();
            txtTenChuyenNganh = new TextBox();
            label2 = new Label();
            label1 = new Label();
            btnThem = new Button();
            btnSua = new Button();
            btnXoa = new Button();
            btnLamMoi = new Button();
            pnlTitle = new Panel();
            lblTitle = new Label();
            dgvChuyenNganh = new DataGridView();
            statusStrip1 = new StatusStrip();
            lblTongSo = new ToolStripStatusLabel();

            grpThongTin.SuspendLayout();
            pnlTitle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChuyenNganh).BeginInit();
            statusStrip1.SuspendLayout();
            SuspendLayout();

            // 
            // grpThongTin
            // 
            grpThongTin.Controls.Add(cboKhoa);
            grpThongTin.Controls.Add(txtTenChuyenNganh);
            grpThongTin.Controls.Add(label2);
            grpThongTin.Controls.Add(label1);
            grpThongTin.Controls.Add(btnThem);
            grpThongTin.Controls.Add(btnSua);
            grpThongTin.Controls.Add(btnXoa);
            grpThongTin.Controls.Add(btnLamMoi);
            grpThongTin.Location = new Point(12, 82);
            grpThongTin.Name = "grpThongTin";
            grpThongTin.Size = new Size(250, 360);
            grpThongTin.TabIndex = 0;
            grpThongTin.TabStop = false;
            grpThongTin.Text = "Thông tin Chuyên ngành";

            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(15, 35);
            label1.Name = "label1";
            label1.Size = new Size(108, 15);
            label1.TabIndex = 0;
            label1.Text = "Tên chuyên ngành:";

            // 
            // txtTenChuyenNganh
            // 
            txtTenChuyenNganh.Location = new Point(15, 55);
            txtTenChuyenNganh.Name = "txtTenChuyenNganh";
            txtTenChuyenNganh.Size = new Size(215, 23);
            txtTenChuyenNganh.TabIndex = 1;

            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(15, 100);
            label2.Name = "label2";
            label2.Size = new Size(40, 15);
            label2.TabIndex = 2;
            label2.Text = "Khoa:";

            // 
            // cboKhoa
            // 
            cboKhoa.DropDownStyle = ComboBoxStyle.DropDownList;
            cboKhoa.FormattingEnabled = true;
            cboKhoa.Location = new Point(15, 120);
            cboKhoa.Name = "cboKhoa";
            cboKhoa.Size = new Size(215, 23);
            cboKhoa.TabIndex = 3;

            // 
            // btnThem
            // 
            btnThem.BackColor = Color.SeaGreen;
            btnThem.FlatStyle = FlatStyle.Flat;
            btnThem.ForeColor = Color.White;
            btnThem.Location = new Point(15, 180);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(95, 38);
            btnThem.TabIndex = 4;
            btnThem.Text = "➕ Thêm";
            btnThem.UseVisualStyleBackColor = false;
            btnThem.Click += btnThem_Click;

            // 
            // btnSua
            // 
            btnSua.BackColor = Color.DodgerBlue;
            btnSua.FlatStyle = FlatStyle.Flat;
            btnSua.ForeColor = Color.White;
            btnSua.Location = new Point(135, 180);
            btnSua.Name = "btnSua";
            btnSua.Size = new Size(95, 38);
            btnSua.TabIndex = 5;
            btnSua.Text = "✏ Sửa";
            btnSua.UseVisualStyleBackColor = false;
            btnSua.Click += btnSua_Click;

            // 
            // btnXoa
            // 
            btnXoa.BackColor = Color.Crimson;
            btnXoa.FlatStyle = FlatStyle.Flat;
            btnXoa.ForeColor = Color.White;
            btnXoa.Location = new Point(15, 235);
            btnXoa.Name = "btnXoa";
            btnXoa.Size = new Size(95, 38);
            btnXoa.TabIndex = 6;
            btnXoa.Text = "❌ Xóa";
            btnXoa.UseVisualStyleBackColor = false;
            btnXoa.Click += btnXoa_Click;

            // 
            // btnLamMoi
            // 
            btnLamMoi.BackColor = Color.Gray;
            btnLamMoi.FlatStyle = FlatStyle.Flat;
            btnLamMoi.ForeColor = Color.White;
            btnLamMoi.Location = new Point(135, 235);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(95, 38);
            btnLamMoi.TabIndex = 7;
            btnLamMoi.Text = "↻ Làm mới";
            btnLamMoi.UseVisualStyleBackColor = false;
            btnLamMoi.Click += btnLamMoi_Click;

            // 
            // pnlTitle
            // 
            pnlTitle.BackColor = Color.AliceBlue;
            pnlTitle.Controls.Add(lblTitle);
            pnlTitle.Dock = DockStyle.Top;
            pnlTitle.Location = new Point(0, 0);
            pnlTitle.Name = "pnlTitle";
            pnlTitle.Size = new Size(900, 70);
            pnlTitle.TabIndex = 1;

            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            // Corrected Font initialization
            lblTitle.Font = new Font(new FontFamily("Segoe UI"), 18F, FontStyle.Bold, GraphicsUnit.Point);
            lblTitle.ForeColor = Color.RoyalBlue;
            lblTitle.Location = new Point(250, 18);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(366, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "🎯 QUẢN LÝ CHUYÊN NGÀNH";

            // 
            // dgvChuyenNganh
            // 
            dgvChuyenNganh.AllowUserToAddRows = false;
            dgvChuyenNganh.AllowUserToDeleteRows = false;
            dgvChuyenNganh.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvChuyenNganh.BackgroundColor = Color.White;
            dgvChuyenNganh.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvChuyenNganh.Location = new Point(280, 82);
            dgvChuyenNganh.MultiSelect = false;
            dgvChuyenNganh.Name = "dgvChuyenNganh";
            dgvChuyenNganh.ReadOnly = true;
            dgvChuyenNganh.RowHeadersVisible = false;
            dgvChuyenNganh.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvChuyenNganh.Size = new Size(600, 360);
            dgvChuyenNganh.TabIndex = 2;
            dgvChuyenNganh.CellClick += dgvChuyenNganh_CellClick;

            // 
            // statusStrip1
            // 
            statusStrip1.Items.AddRange(new ToolStripItem[] { lblTongSo });
            statusStrip1.Location = new Point(0, 458);
            statusStrip1.Name = "statusStrip1";
            statusStrip1.Size = new Size(900, 22);
            statusStrip1.TabIndex = 3;

            // 
            // lblTongSo
            // 
            lblTongSo.Name = "lblTongSo";
            lblTongSo.Size = new Size(885, 17);
            lblTongSo.Spring = true;
            lblTongSo.Text = "Tổng số chuyên ngành: 0";
            lblTongSo.TextAlign = ContentAlignment.MiddleRight;

            // 
            // FormQuanLyChuyenNganh
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(900, 480);
            Controls.Add(statusStrip1);
            Controls.Add(dgvChuyenNganh);
            Controls.Add(pnlTitle);
            Controls.Add(grpThongTin);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "FormQuanLyChuyenNganh";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Quản lý Chuyên ngành";
            Load += FormQuanLyChuyenNganh_Load;

            grpThongTin.ResumeLayout(false);
            grpThongTin.PerformLayout();
            pnlTitle.ResumeLayout(false);
            pnlTitle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvChuyenNganh).EndInit();
            statusStrip1.ResumeLayout(false);
            statusStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private GroupBox grpThongTin;
        private TextBox txtTenChuyenNganh;
        private ComboBox cboKhoa;
        private Label label1;
        private Label label2;
        private Button btnThem;
        private Button btnSua;
        private Button btnXoa;
        private Button btnLamMoi;
        private Panel pnlTitle;
        private Label lblTitle;
        private DataGridView dgvChuyenNganh;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel lblTongSo;
    }
}