namespace Lab05
{
    partial class frmStudent
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.pnlTop = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblFilter = new System.Windows.Forms.Label();
            this.cmbFaculty = new System.Windows.Forms.ComboBox();
            this.chkUnregisterMajor = new System.Windows.Forms.CheckBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.lblSearch = new System.Windows.Forms.Label();
            this.btnOpenRegister = new System.Windows.Forms.Button();
            this.pnlGrid = new System.Windows.Forms.Panel();
            this.dgvStudent = new System.Windows.Forms.DataGridView();
            this.colStudentID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colFaculty = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMajor = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlForm = new System.Windows.Forms.Panel();
            this.lblFormTitle = new System.Windows.Forms.Label();
            this.lblStudentID = new System.Windows.Forms.Label();
            this.txtStudentID = new System.Windows.Forms.TextBox();
            this.lblFullName = new System.Windows.Forms.Label();
            this.txtFullName = new System.Windows.Forms.TextBox();
            this.lblFacultyEdit = new System.Windows.Forms.Label();
            this.cmbFacultyEdit = new System.Windows.Forms.ComboBox();
            this.lblScore = new System.Windows.Forms.Label();
            this.txtScore = new System.Windows.Forms.TextBox();
            this.lblAvatar = new System.Windows.Forms.Label();
            this.picAvatar = new System.Windows.Forms.PictureBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.pnlButtons = new System.Windows.Forms.Panel();
            this.btnAdd = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();

            this.pnlTop.SuspendLayout();
            this.pnlGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudent)).BeginInit();
            this.pnlForm.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).BeginInit();
            this.pnlButtons.SuspendLayout();
            this.SuspendLayout();

            // ── pnlTop ──────────────────────────────────────────────
            this.pnlTop.BackColor = System.Drawing.Color.FromArgb(33, 150, 243);
            this.pnlTop.Controls.Add(this.lblTitle);
            this.pnlTop.Controls.Add(this.lblFilter);
            this.pnlTop.Controls.Add(this.cmbFaculty);
            this.pnlTop.Controls.Add(this.chkUnregisterMajor);
            this.pnlTop.Controls.Add(this.lblSearch);
            this.pnlTop.Controls.Add(this.txtSearch);
            this.pnlTop.Controls.Add(this.btnOpenRegister);
            this.pnlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTop.Location = new System.Drawing.Point(0, 0);
            this.pnlTop.Size = new System.Drawing.Size(1100, 65);

            // lblTitle
            this.lblTitle.AutoSize = true;
            this.lblTitle.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTitle.ForeColor = System.Drawing.Color.White;
            this.lblTitle.Location = new System.Drawing.Point(15, 18);
            this.lblTitle.Text = "QUẢN LÝ SINH VIÊN";

            // lblFilter
            this.lblFilter.AutoSize = true;
            this.lblFilter.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFilter.ForeColor = System.Drawing.Color.White;
            this.lblFilter.Location = new System.Drawing.Point(255, 22);
            this.lblFilter.Text = "Khoa:";

            // cmbFaculty
            this.cmbFaculty.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFaculty.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.cmbFaculty.Location = new System.Drawing.Point(300, 18);
            this.cmbFaculty.Size = new System.Drawing.Size(200, 27);
            this.cmbFaculty.SelectedIndexChanged += new System.EventHandler(this.cmbFaculty_SelectedIndexChanged);

            // chkUnregisterMajor
            this.chkUnregisterMajor.AutoSize = true;
            this.chkUnregisterMajor.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.chkUnregisterMajor.ForeColor = System.Drawing.Color.White;
            this.chkUnregisterMajor.Location = new System.Drawing.Point(515, 22);
            this.chkUnregisterMajor.Text = "Chưa có chuyên ngành";
            this.chkUnregisterMajor.CheckedChanged += new System.EventHandler(this.chkUnregisterMajor_CheckedChanged);

            // lblSearch
            this.lblSearch.AutoSize = true;
            this.lblSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblSearch.ForeColor = System.Drawing.Color.White;
            this.lblSearch.Location = new System.Drawing.Point(690, 22);
            this.lblSearch.Text = "Tìm kiếm:";

            // txtSearch
            this.txtSearch.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.txtSearch.Location = new System.Drawing.Point(760, 18);
            this.txtSearch.Size = new System.Drawing.Size(175, 27);
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);

            // btnOpenRegister
            this.btnOpenRegister.BackColor = System.Drawing.Color.FromArgb(255, 152, 0);
            this.btnOpenRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOpenRegister.FlatAppearance.BorderSize = 0;
            this.btnOpenRegister.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnOpenRegister.ForeColor = System.Drawing.Color.White;
            this.btnOpenRegister.Location = new System.Drawing.Point(960, 15);
            this.btnOpenRegister.Size = new System.Drawing.Size(120, 35);
            this.btnOpenRegister.Text = "Đăng ký CN";
            this.btnOpenRegister.Click += new System.EventHandler(this.btnOpenRegister_Click);

            // ── pnlGrid ─────────────────────────────────────────────
            this.pnlGrid.Controls.Add(this.dgvStudent);
            this.pnlGrid.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlGrid.Location = new System.Drawing.Point(0, 65);
            this.pnlGrid.Padding = new System.Windows.Forms.Padding(10);
            this.pnlGrid.Size = new System.Drawing.Size(760, 580);

            // dgvStudent
            this.dgvStudent.AllowUserToAddRows = false;
            this.dgvStudent.AllowUserToDeleteRows = false;
            this.dgvStudent.AllowUserToResizeRows = false;
            this.dgvStudent.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvStudent.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvStudent.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
                this.colStudentID,
                this.colFullName,
                this.colFaculty,
                this.colScore,
                this.colMajor });
            this.dgvStudent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvStudent.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.dgvStudent.GridColor = System.Drawing.Color.LightGray;
            this.dgvStudent.ReadOnly = true;
            this.dgvStudent.RowHeadersWidth = 30;
            this.dgvStudent.RowTemplate.Height = 32;
            this.dgvStudent.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvStudent_CellClick);

            // colStudentID
            this.colStudentID.HeaderText = "Mã SV";
            this.colStudentID.Name = "colStudentID";
            this.colStudentID.FillWeight = 15F;

            // colFullName
            this.colFullName.HeaderText = "Họ và tên";
            this.colFullName.Name = "colFullName";
            this.colFullName.FillWeight = 30F;

            // colFaculty
            this.colFaculty.HeaderText = "Khoa";
            this.colFaculty.Name = "colFaculty";
            this.colFaculty.FillWeight = 25F;

            // colScore
            this.colScore.HeaderText = "Điểm TB";
            this.colScore.Name = "colScore";
            this.colScore.FillWeight = 15F;

            // colMajor
            this.colMajor.HeaderText = "Chuyên ngành";
            this.colMajor.Name = "colMajor";
            this.colMajor.FillWeight = 25F;

            // ── pnlForm ─────────────────────────────────────────────
            this.pnlForm.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);
            this.pnlForm.Controls.Add(this.lblFormTitle);
            this.pnlForm.Controls.Add(this.lblStudentID);
            this.pnlForm.Controls.Add(this.txtStudentID);
            this.pnlForm.Controls.Add(this.lblFullName);
            this.pnlForm.Controls.Add(this.txtFullName);
            this.pnlForm.Controls.Add(this.lblFacultyEdit);
            this.pnlForm.Controls.Add(this.cmbFacultyEdit);
            this.pnlForm.Controls.Add(this.lblScore);
            this.pnlForm.Controls.Add(this.txtScore);
            this.pnlForm.Controls.Add(this.lblAvatar);
            this.pnlForm.Controls.Add(this.picAvatar);
            this.pnlForm.Controls.Add(this.btnBrowse);
            this.pnlForm.Controls.Add(this.pnlButtons);
            this.pnlForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlForm.Padding = new System.Windows.Forms.Padding(15);

            // lblFormTitle
            this.lblFormTitle.AutoSize = false;
            this.lblFormTitle.BackColor = System.Drawing.Color.FromArgb(33, 150, 243);
            this.lblFormTitle.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblFormTitle.ForeColor = System.Drawing.Color.White;
            this.lblFormTitle.Location = new System.Drawing.Point(0, 0);
            this.lblFormTitle.Size = new System.Drawing.Size(340, 40);
            this.lblFormTitle.Text = "  Thông tin sinh viên";
            this.lblFormTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

            // lblStudentID
            this.lblStudentID.AutoSize = true;
            this.lblStudentID.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblStudentID.Location = new System.Drawing.Point(15, 55);
            this.lblStudentID.Text = "Mã sinh viên (*)";

            // txtStudentID
            this.txtStudentID.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtStudentID.Location = new System.Drawing.Point(15, 75);
            this.txtStudentID.Size = new System.Drawing.Size(310, 27);
            this.txtStudentID.MaxLength = 20;

            // lblFullName
            this.lblFullName.AutoSize = true;
            this.lblFullName.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFullName.Location = new System.Drawing.Point(15, 115);
            this.lblFullName.Text = "Họ và tên (*)";

            // txtFullName
            this.txtFullName.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtFullName.Location = new System.Drawing.Point(15, 135);
            this.txtFullName.Size = new System.Drawing.Size(310, 27);
            this.txtFullName.MaxLength = 200;

            // lblFacultyEdit
            this.lblFacultyEdit.AutoSize = true;
            this.lblFacultyEdit.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblFacultyEdit.Location = new System.Drawing.Point(15, 175);
            this.lblFacultyEdit.Text = "Khoa";

            // cmbFacultyEdit
            this.cmbFacultyEdit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFacultyEdit.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.cmbFacultyEdit.Location = new System.Drawing.Point(15, 195);
            this.cmbFacultyEdit.Size = new System.Drawing.Size(310, 27);

            // lblScore
            this.lblScore.AutoSize = true;
            this.lblScore.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblScore.Location = new System.Drawing.Point(15, 235);
            this.lblScore.Text = "Điểm trung bình";

            // txtScore
            this.txtScore.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.txtScore.Location = new System.Drawing.Point(15, 255);
            this.txtScore.Size = new System.Drawing.Size(310, 27);

            // lblAvatar
            this.lblAvatar.AutoSize = true;
            this.lblAvatar.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.lblAvatar.Location = new System.Drawing.Point(15, 295);
            this.lblAvatar.Text = "Ảnh đại diện";

            // picAvatar
            this.picAvatar.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picAvatar.Location = new System.Drawing.Point(15, 315);
            this.picAvatar.Size = new System.Drawing.Size(200, 160);
            this.picAvatar.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;

            // btnBrowse
            this.btnBrowse.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.btnBrowse.Location = new System.Drawing.Point(225, 315);
            this.btnBrowse.Size = new System.Drawing.Size(100, 35);
            this.btnBrowse.Text = "Chọn ảnh";
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);

            // ── pnlButtons ──────────────────────────────────────────
            this.pnlButtons.Controls.Add(this.btnAdd);
            this.pnlButtons.Controls.Add(this.btnEdit);
            this.pnlButtons.Controls.Add(this.btnDelete);
            this.pnlButtons.Controls.Add(this.btnClear);
            this.pnlButtons.Location = new System.Drawing.Point(0, 495);
            this.pnlButtons.Size = new System.Drawing.Size(340, 50);
            this.pnlButtons.BackColor = System.Drawing.Color.FromArgb(245, 245, 245);

            // btnAdd
            this.btnAdd.BackColor = System.Drawing.Color.FromArgb(76, 175, 80);
            this.btnAdd.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAdd.FlatAppearance.BorderSize = 0;
            this.btnAdd.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnAdd.ForeColor = System.Drawing.Color.White;
            this.btnAdd.Location = new System.Drawing.Point(5, 8);
            this.btnAdd.Size = new System.Drawing.Size(75, 34);
            this.btnAdd.Text = "Thêm";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            // btnEdit
            this.btnEdit.BackColor = System.Drawing.Color.FromArgb(33, 150, 243);
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnEdit.ForeColor = System.Drawing.Color.White;
            this.btnEdit.Location = new System.Drawing.Point(85, 8);
            this.btnEdit.Size = new System.Drawing.Size(75, 34);
            this.btnEdit.Text = "Sửa";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);

            // btnDelete
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(244, 67, 54);
            this.btnDelete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnDelete.ForeColor = System.Drawing.Color.White;
            this.btnDelete.Location = new System.Drawing.Point(165, 8);
            this.btnDelete.Size = new System.Drawing.Size(75, 34);
            this.btnDelete.Text = "Xóa";
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // btnClear
            this.btnClear.BackColor = System.Drawing.Color.FromArgb(158, 158, 158);
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnClear.FlatAppearance.BorderSize = 0;
            this.btnClear.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            this.btnClear.ForeColor = System.Drawing.Color.White;
            this.btnClear.Location = new System.Drawing.Point(245, 8);
            this.btnClear.Size = new System.Drawing.Size(75, 34);
            this.btnClear.Text = "Làm mới";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);

            // ── frmStudent ──────────────────────────────────────────
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1100, 645);
            this.Controls.Add(this.pnlForm);
            this.Controls.Add(this.pnlGrid);
            this.Controls.Add(this.pnlTop);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.MinimumSize = new System.Drawing.Size(1100, 690);
            this.Name = "frmStudent";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quản Lý Sinh Viên";
            this.Load += new System.EventHandler(this.frmStudent_Load);

            this.pnlTop.ResumeLayout(false);
            this.pnlTop.PerformLayout();
            this.pnlGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvStudent)).EndInit();
            this.pnlForm.ResumeLayout(false);
            this.pnlForm.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAvatar)).EndInit();
            this.pnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel pnlTop;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblFilter;
        private System.Windows.Forms.ComboBox cmbFaculty;
        private System.Windows.Forms.CheckBox chkUnregisterMajor;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label lblSearch;
        private System.Windows.Forms.Button btnOpenRegister;
        private System.Windows.Forms.Panel pnlGrid;
        private System.Windows.Forms.DataGridView dgvStudent;
        private System.Windows.Forms.DataGridViewTextBoxColumn colStudentID;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFullName;
        private System.Windows.Forms.DataGridViewTextBoxColumn colFaculty;
        private System.Windows.Forms.DataGridViewTextBoxColumn colScore;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMajor;
        private System.Windows.Forms.Panel pnlForm;
        private System.Windows.Forms.Label lblFormTitle;
        private System.Windows.Forms.Label lblStudentID;
        private System.Windows.Forms.TextBox txtStudentID;
        private System.Windows.Forms.Label lblFullName;
        private System.Windows.Forms.TextBox txtFullName;
        private System.Windows.Forms.Label lblFacultyEdit;
        private System.Windows.Forms.ComboBox cmbFacultyEdit;
        private System.Windows.Forms.Label lblScore;
        private System.Windows.Forms.TextBox txtScore;
        private System.Windows.Forms.Label lblAvatar;
        private System.Windows.Forms.PictureBox picAvatar;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.Panel pnlButtons;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnClear;
    }
}
