namespace lab03_03
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
            panelTool = new Panel();
            btnLuu = new Button();
            btnXoaTatCa = new Button();
            lblDoDay = new Label();
            trkDoDay = new TrackBar();
            label3 = new Label();
            btnChonMau = new Button();
            pnlMauDangChon = new Panel();
            label1 = new Label();
            btnCucTay = new Button();
            btnHinhTron = new Button();
            btnChuNhat = new Button();
            btnDuongThang = new Button();
            btnButVe = new Button();
            picCanvas = new PictureBox();
            panelTool.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)trkDoDay).BeginInit();
            ((System.ComponentModel.ISupportInitialize)picCanvas).BeginInit();
            SuspendLayout();
            // 
            // panelTool
            // 
            panelTool.BackColor = Color.Gainsboro;
            panelTool.Controls.Add(btnLuu);
            panelTool.Controls.Add(btnXoaTatCa);
            panelTool.Controls.Add(lblDoDay);
            panelTool.Controls.Add(trkDoDay);
            panelTool.Controls.Add(label3);
            panelTool.Controls.Add(btnChonMau);
            panelTool.Controls.Add(pnlMauDangChon);
            panelTool.Controls.Add(label1);
            panelTool.Controls.Add(btnCucTay);
            panelTool.Controls.Add(btnHinhTron);
            panelTool.Controls.Add(btnChuNhat);
            panelTool.Controls.Add(btnDuongThang);
            panelTool.Controls.Add(btnButVe);
            panelTool.Dock = DockStyle.Left;
            panelTool.Location = new Point(0, 0);
            panelTool.Name = "panelTool";
            panelTool.Size = new Size(170, 611);
            panelTool.TabIndex = 0;
            // 
            // btnLuu
            // 
            btnLuu.BackColor = Color.Green;
            btnLuu.FlatStyle = FlatStyle.Flat;
            btnLuu.ForeColor = Color.White;
            btnLuu.Location = new Point(20, 560);
            btnLuu.Name = "btnLuu";
            btnLuu.Size = new Size(120, 40);
            btnLuu.TabIndex = 14;
            btnLuu.Text = "Lưu ảnh";
            btnLuu.UseVisualStyleBackColor = false;
            // 
            // btnXoaTatCa
            // 
            btnXoaTatCa.BackColor = Color.Red;
            btnXoaTatCa.FlatStyle = FlatStyle.Flat;
            btnXoaTatCa.ForeColor = Color.White;
            btnXoaTatCa.Location = new Point(20, 510);
            btnXoaTatCa.Name = "btnXoaTatCa";
            btnXoaTatCa.Size = new Size(120, 40);
            btnXoaTatCa.TabIndex = 13;
            btnXoaTatCa.Text = "Xóa tất cả";
            btnXoaTatCa.UseVisualStyleBackColor = false;
            // 
            // lblDoDay
            // 
            lblDoDay.AutoSize = true;
            lblDoDay.BackColor = Color.White;
            lblDoDay.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDoDay.Location = new Point(20, 469);
            lblDoDay.Name = "lblDoDay";
            lblDoDay.Size = new Size(58, 15);
            lblDoDay.TabIndex = 12;
            lblDoDay.Text = "Độ dày: 3";
            // 
            // trkDoDay
            // 
            trkDoDay.Location = new Point(20, 410);
            trkDoDay.Maximum = 20;
            trkDoDay.Minimum = 1;
            trkDoDay.Name = "trkDoDay";
            trkDoDay.Size = new Size(120, 45);
            trkDoDay.TabIndex = 10;
            trkDoDay.Value = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.White;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(20, 380);
            label3.Name = "label3";
            label3.Size = new Size(70, 15);
            label3.TabIndex = 9;
            label3.Text = "Độ dày nét:";
            // 
            // btnChonMau
            // 
            btnChonMau.Location = new Point(70, 320);
            btnChonMau.Name = "btnChonMau";
            btnChonMau.Size = new Size(70, 40);
            btnChonMau.TabIndex = 0;
            btnChonMau.Text = "Chọn...";
            btnChonMau.UseVisualStyleBackColor = true;
            // 
            // pnlMauDangChon
            // 
            pnlMauDangChon.BackColor = Color.Black;
            pnlMauDangChon.BorderStyle = BorderStyle.FixedSingle;
            pnlMauDangChon.Location = new Point(20, 320);
            pnlMauDangChon.Name = "pnlMauDangChon";
            pnlMauDangChon.Size = new Size(40, 40);
            pnlMauDangChon.TabIndex = 7;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(20, 290);
            label1.Name = "label1";
            label1.Size = new Size(51, 15);
            label1.TabIndex = 6;
            label1.Text = "Màu vẽ:";
            // 
            // btnCucTay
            // 
            btnCucTay.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCucTay.Location = new Point(20, 220);
            btnCucTay.Name = "btnCucTay";
            btnCucTay.Size = new Size(120, 40);
            btnCucTay.TabIndex = 5;
            btnCucTay.Text = "\U0001f9fd Cục tẩy";
            btnCucTay.UseVisualStyleBackColor = true;
            // 
            // btnHinhTron
            // 
            btnHinhTron.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnHinhTron.Location = new Point(20, 170);
            btnHinhTron.Name = "btnHinhTron";
            btnHinhTron.Size = new Size(120, 40);
            btnHinhTron.TabIndex = 4;
            btnHinhTron.Text = "○ Hình tròn";
            btnHinhTron.UseVisualStyleBackColor = true;
            // 
            // btnChuNhat
            // 
            btnChuNhat.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnChuNhat.Location = new Point(20, 120);
            btnChuNhat.Name = "btnChuNhat";
            btnChuNhat.Size = new Size(120, 40);
            btnChuNhat.TabIndex = 3;
            btnChuNhat.Text = "▭ Chữ nhật";
            btnChuNhat.UseVisualStyleBackColor = true;
            // 
            // btnDuongThang
            // 
            btnDuongThang.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDuongThang.Location = new Point(20, 70);
            btnDuongThang.Name = "btnDuongThang";
            btnDuongThang.Size = new Size(120, 40);
            btnDuongThang.TabIndex = 2;
            btnDuongThang.Text = "╱ Đường thẳng";
            btnDuongThang.UseVisualStyleBackColor = true;
            // 
            // btnButVe
            // 
            btnButVe.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnButVe.Location = new Point(20, 20);
            btnButVe.Name = "btnButVe";
            btnButVe.Size = new Size(120, 40);
            btnButVe.TabIndex = 1;
            btnButVe.Text = "✏ Bút vẽ";
            btnButVe.UseVisualStyleBackColor = true;
            // 
            // picCanvas
            // 
            picCanvas.BackColor = Color.White;
            picCanvas.BorderStyle = BorderStyle.FixedSingle;
            picCanvas.Dock = DockStyle.Fill;
            picCanvas.Location = new Point(170, 0);
            picCanvas.Name = "picCanvas";
            picCanvas.Size = new Size(814, 611);
            picCanvas.TabIndex = 0;
            picCanvas.TabStop = false;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(984, 611);
            Controls.Add(picCanvas);
            Controls.Add(panelTool);
            MinimumSize = new Size(900, 600);
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Ứng dụng vẽ tranh mini";
            panelTool.ResumeLayout(false);
            panelTool.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)trkDoDay).EndInit();
            ((System.ComponentModel.ISupportInitialize)picCanvas).EndInit();
            ResumeLayout(false);

            Load += Form1_Load;

            btnButVe.Click += btnButVe_Click;
            btnDuongThang.Click += btnDuongThang_Click;
            btnChuNhat.Click += btnChuNhat_Click;
            btnHinhTron.Click += btnHinhTron_Click;
            btnCucTay.Click += btnCucTay_Click;

            btnChonMau.Click += btnChonMau_Click;
            btnXoaTatCa.Click += btnXoa_Click;
            btnLuu.Click += btnLuu_Click;

            trkDoDay.Scroll += trkDoDay_Scroll;

            picCanvas.MouseDown += picCanvas_MouseDown;
            picCanvas.MouseMove += picCanvas_MouseMove;
            picCanvas.MouseUp += picCanvas_MouseUp;
            picCanvas.Paint += picCanvas_Paint;
            picCanvas.MouseLeave += picCanvas_MouseLeave;
        }


        #endregion

        private Panel panelTool;
        private PictureBox picCanvas;
        private Button btnCucTay;
        private Button btnHinhTron;
        private Button btnChuNhat;
        private Button btnDuongThang;
        private Button btnButVe;
        private Label label3;
        private Button btnChonMau;
        private Panel pnlMauDangChon;
        private Label label1;
        private Button btnLuu;
        private Button btnXoaTatCa;
        private Label lblDoDay;
        private TrackBar trkDoDay;
    }
}
