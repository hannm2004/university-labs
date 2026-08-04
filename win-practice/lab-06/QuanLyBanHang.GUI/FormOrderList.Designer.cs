namespace QuanLyBanHang.GUI
{
    partial class FormOrderList
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
            lblTitle = new Label();
            pnlHeader = new Panel();
            grpOrder = new GroupBox();
            dgvOrder = new DataGridView();
            lblTongDon = new Label();
            grpDetail = new GroupBox();
            dgvDetail = new DataGridView();
            btnHuyDon = new Button();
            btnDong = new Button();

            pnlHeader.SuspendLayout();
            grpOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvOrder).BeginInit();
            grpDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvDetail).BeginInit();
            SuspendLayout();

            // lblTitle
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(310, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(356, 32);
            lblTitle.Text = "DANH SÁCH ĐƠN HÀNG";

            // pnlHeader
            pnlHeader.BackColor = Color.RoyalBlue;
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1100, 60);

            // grpOrder
            grpOrder.Controls.Add(lblTongDon);
            grpOrder.Controls.Add(dgvOrder);
            grpOrder.Location = new Point(12, 75);
            grpOrder.Name = "grpOrder";
            grpOrder.Size = new Size(450, 470);
            grpOrder.TabStop = false;
            grpOrder.Text = "Danh sách đơn hàng";

            // lblTongDon
            lblTongDon.AutoSize = true;
            lblTongDon.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            lblTongDon.Location = new Point(18, 28);
            lblTongDon.Name = "lblTongDon";
            lblTongDon.Size = new Size(119, 15);
            lblTongDon.Text = "Tổng đơn hàng : 0";

            // dgvOrder
            dgvOrder.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvOrder.Location = new Point(18, 55);
            dgvOrder.Name = "dgvOrder";
            dgvOrder.Size = new Size(415, 395);
            dgvOrder.TabIndex = 0;

            // grpDetail
            grpDetail.Controls.Add(dgvDetail);
            grpDetail.Location = new Point(475, 75);
            grpDetail.Name = "grpDetail";
            grpDetail.Size = new Size(610, 470);
            grpDetail.TabStop = false;
            grpDetail.Text = "Chi tiết đơn hàng";

            // dgvDetail
            dgvDetail.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDetail.Location = new Point(18, 28);
            dgvDetail.Name = "dgvDetail";
            dgvDetail.Size = new Size(575, 422);
            dgvDetail.TabIndex = 0;

            // btnHuyDon
            btnHuyDon.BackColor = Color.Crimson;
            btnHuyDon.FlatStyle = FlatStyle.Flat;
            btnHuyDon.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnHuyDon.ForeColor = Color.White;
            btnHuyDon.Location = new Point(760, 560);
            btnHuyDon.Name = "btnHuyDon";
            btnHuyDon.Size = new Size(140, 42);
            btnHuyDon.TabIndex = 3;
            btnHuyDon.Text = "Hủy đơn hàng";
            btnHuyDon.UseVisualStyleBackColor = false;

            // btnDong
            btnDong.BackColor = Color.Gray;
            btnDong.FlatStyle = FlatStyle.Flat;
            btnDong.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnDong.ForeColor = Color.White;
            btnDong.Location = new Point(925, 560);
            btnDong.Name = "btnDong";
            btnDong.Size = new Size(140, 42);
            btnDong.TabIndex = 4;
            btnDong.Text = "Đóng";
            btnDong.UseVisualStyleBackColor = false;

            // FormOrderList
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 620);
            Controls.Add(btnDong);
            Controls.Add(btnHuyDon);
            Controls.Add(grpDetail);
            Controls.Add(grpOrder);
            Controls.Add(pnlHeader);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormOrderList";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Danh sách đơn hàng";

            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();

            grpOrder.ResumeLayout(false);
            grpOrder.PerformLayout();

            ((System.ComponentModel.ISupportInitialize)dgvOrder).EndInit();

            grpDetail.ResumeLayout(false);

            ((System.ComponentModel.ISupportInitialize)dgvDetail).EndInit();

            ResumeLayout(false);
        }

        #endregion
        private Label lblTitle;
        private Panel pnlHeader;

        private GroupBox grpOrder;
        private DataGridView dgvOrder;
        private Label lblTongDon;

        private GroupBox grpDetail;
        private DataGridView dgvDetail;

        private Button btnHuyDon;
        private Button btnDong;
    }
}