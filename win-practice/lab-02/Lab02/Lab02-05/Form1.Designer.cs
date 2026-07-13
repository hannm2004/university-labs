namespace Lab02_05
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
            label2 = new Label();
            label1 = new Label();
            txtTieuDe = new TextBox();
            cboUuTien = new ComboBox();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            btnThem = new Button();
            panelCanLam = new Panel();
            flpCanLam = new FlowLayoutPanel();
            lblCanLam = new Label();
            panelDangLam = new Panel();
            lblDangLam = new Label();
            flpDangLam = new FlowLayoutPanel();
            panelHoanThanh = new Panel();
            flpHoanThanh = new FlowLayoutPanel();
            lblHoanThanh = new Label();
            panelCanLam.SuspendLayout();
            panelDangLam.SuspendLayout();
            panelHoanThanh.SuspendLayout();
            SuspendLayout();
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(374, 47);
            label2.Name = "label2";
            label2.Size = new Size(48, 15);
            label2.TabIndex = 1;
            label2.Text = "Ưu tiên:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(33, 47);
            label1.Name = "label1";
            label1.Size = new Size(48, 15);
            label1.TabIndex = 2;
            label1.Text = "Tiêu đề:";
            // 
            // txtTieuDe
            // 
            txtTieuDe.Location = new Point(103, 40);
            txtTieuDe.Name = "txtTieuDe";
            txtTieuDe.Size = new Size(200, 23);
            txtTieuDe.TabIndex = 3;
            // 
            // cboUuTien
            // 
            cboUuTien.DropDownStyle = ComboBoxStyle.DropDownList;
            cboUuTien.FormattingEnabled = true;
            cboUuTien.Items.AddRange(new object[] { "Thấp", "Bình thường", "Cao" });
            cboUuTien.Location = new Point(440, 39);
            cboUuTien.Name = "cboUuTien";
            cboUuTien.Size = new Size(158, 23);
            cboUuTien.TabIndex = 4;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(635, 43);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(130, 23);
            btnThem.TabIndex = 6;
            btnThem.Text = "+ Thêm công việc";
            btnThem.UseVisualStyleBackColor = true;
            // 
            // panelCanLam
            // 
            panelCanLam.Controls.Add(flpCanLam);
            panelCanLam.Controls.Add(lblCanLam);
            panelCanLam.Location = new Point(33, 86);
            panelCanLam.Name = "panelCanLam";
            panelCanLam.Size = new Size(230, 500);
            panelCanLam.TabIndex = 7;
            // 
            // flpCanLam
            // 
            flpCanLam.AutoScroll = true;
            flpCanLam.Dock = DockStyle.Fill;
            flpCanLam.FlowDirection = FlowDirection.TopDown;
            flpCanLam.Location = new Point(0, 15);
            flpCanLam.Name = "flpCanLam";
            flpCanLam.Size = new Size(230, 485);
            flpCanLam.TabIndex = 1;
            flpCanLam.WrapContents = false;
            // 
            // lblCanLam
            // 
            lblCanLam.AllowDrop = true;
            lblCanLam.AutoSize = true;
            lblCanLam.BackColor = Color.Gray;
            lblCanLam.Dock = DockStyle.Top;
            lblCanLam.ForeColor = Color.White;
            lblCanLam.Location = new Point(0, 0);
            lblCanLam.Name = "lblCanLam";
            lblCanLam.Size = new Size(68, 15);
            lblCanLam.TabIndex = 0;
            lblCanLam.Text = "Cần làm (0)";
            // 
            // panelDangLam
            // 
            panelDangLam.Controls.Add(lblDangLam);
            panelDangLam.Controls.Add(flpDangLam);
            panelDangLam.Location = new Point(285, 86);
            panelDangLam.Name = "panelDangLam";
            panelDangLam.Size = new Size(230, 500);
            panelDangLam.TabIndex = 8;
            // 
            // lblDangLam
            // 
            lblDangLam.AutoSize = true;
            lblDangLam.BackColor = Color.DodgerBlue;
            lblDangLam.Dock = DockStyle.Top;
            lblDangLam.ForeColor = Color.White;
            lblDangLam.Location = new Point(0, 0);
            lblDangLam.Name = "lblDangLam";
            lblDangLam.Size = new Size(75, 15);
            lblDangLam.TabIndex = 0;
            lblDangLam.Text = "Đang làm (0)";
            // 
            // flpDangLam
            // 
            flpDangLam.AllowDrop = true;
            flpDangLam.AutoScroll = true;
            flpDangLam.Dock = DockStyle.Fill;
            flpDangLam.FlowDirection = FlowDirection.TopDown;
            flpDangLam.Location = new Point(0, 0);
            flpDangLam.Name = "flpDangLam";
            flpDangLam.Size = new Size(230, 500);
            flpDangLam.TabIndex = 2;
            flpDangLam.WrapContents = false;
            // 
            // panelHoanThanh
            // 
            panelHoanThanh.Controls.Add(flpHoanThanh);
            panelHoanThanh.Controls.Add(lblHoanThanh);
            panelHoanThanh.Location = new Point(535, 86);
            panelHoanThanh.Name = "panelHoanThanh";
            panelHoanThanh.Size = new Size(230, 500);
            panelHoanThanh.TabIndex = 9;
            // 
            // flpHoanThanh
            // 
            flpHoanThanh.AllowDrop = true;
            flpHoanThanh.AutoScroll = true;
            flpHoanThanh.Dock = DockStyle.Fill;
            flpHoanThanh.FlowDirection = FlowDirection.TopDown;
            flpHoanThanh.Location = new Point(0, 15);
            flpHoanThanh.Name = "flpHoanThanh";
            flpHoanThanh.Size = new Size(230, 485);
            flpHoanThanh.TabIndex = 2;
            flpHoanThanh.WrapContents = false;
            // 
            // lblHoanThanh
            // 
            lblHoanThanh.AutoSize = true;
            lblHoanThanh.BackColor = Color.ForestGreen;
            lblHoanThanh.Dock = DockStyle.Top;
            lblHoanThanh.ForeColor = Color.White;
            lblHoanThanh.Location = new Point(0, 0);
            lblHoanThanh.Name = "lblHoanThanh";
            lblHoanThanh.Size = new Size(87, 15);
            lblHoanThanh.TabIndex = 0;
            lblHoanThanh.Text = "Hoàn thành (0)";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 618);
            Controls.Add(panelHoanThanh);
            Controls.Add(panelDangLam);
            Controls.Add(panelCanLam);
            Controls.Add(btnThem);
            Controls.Add(cboUuTien);
            Controls.Add(txtTieuDe);
            Controls.Add(label1);
            Controls.Add(label2);
            Name = "Form1";
            Text = "Bảng Công Việc KanBan";
            Load += Form1_Load;
            panelCanLam.ResumeLayout(false);
            panelCanLam.PerformLayout();
            panelDangLam.ResumeLayout(false);
            panelDangLam.PerformLayout();
            panelHoanThanh.ResumeLayout(false);
            panelHoanThanh.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        #endregion
        private Label label2;
        private Label label1;
        private TextBox txtTieuDe;
        private ComboBox cboUuTien;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Button btnThem;
        private Panel panelCanLam;
        private Panel panelDangLam;
        private Panel panelHoanThanh;
        private FlowLayoutPanel flpCanLam;
        private FlowLayoutPanel flpDangLam;
        private FlowLayoutPanel flpHoanThanh;
        private Label lblCanLam;
        private Label lblDangLam;
        private Label lblHoanThanh;
    }
}
