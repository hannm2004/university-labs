using System.Reflection.PortableExecutable;

namespace QuanLyBanHang.GUI
{
    partial class FormCreateOrder
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
            pnlHeader = new Panel();
            lblTitle = new Label();
            grpCustomer = new GroupBox();
            lblCustomer = new Label();
            cboCustomer = new ComboBox();
            grpProduct = new GroupBox();
            lblProduct = new Label();
            cboProduct = new ComboBox();
            lblQuantity = new Label();
            nudQuantity = new NumericUpDown();
            btnAdd = new Button();
            grpCart = new GroupBox();
            dgvCart = new DataGridView();
            lblTongTienTitle = new Label();
            lblTongTien = new Label();
            btnRemove = new Button();
            btnOrder = new Button();
            btnClose = new Button();
            pnlHeader.SuspendLayout();
            grpCustomer.SuspendLayout();
            grpProduct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)nudQuantity).BeginInit();
            grpCart.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCart).BeginInit();
            SuspendLayout();
            // 
            // pnlHeader
            // 
            pnlHeader.BackColor = Color.RoyalBlue;
            pnlHeader.Controls.Add(lblTitle);
            pnlHeader.Dock = DockStyle.Top;
            pnlHeader.Location = new Point(0, 0);
            pnlHeader.Name = "pnlHeader";
            pnlHeader.Size = new Size(1100, 60);
            pnlHeader.TabIndex = 3;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lblTitle.ForeColor = Color.White;
            lblTitle.Location = new Point(390, 15);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(204, 32);
            lblTitle.TabIndex = 0;
            lblTitle.Text = "TẠO ĐƠN HÀNG";
            // 
            // grpCustomer
            // 
            grpCustomer.Controls.Add(lblCustomer);
            grpCustomer.Controls.Add(cboCustomer);
            grpCustomer.Location = new Point(20, 75);
            grpCustomer.Name = "grpCustomer";
            grpCustomer.Size = new Size(1050, 80);
            grpCustomer.TabIndex = 2;
            grpCustomer.TabStop = false;
            grpCustomer.Text = "Khách hàng";
            // 
            // lblCustomer
            // 
            lblCustomer.AutoSize = true;
            lblCustomer.Location = new Point(20, 35);
            lblCustomer.Name = "lblCustomer";
            lblCustomer.Size = new Size(70, 15);
            lblCustomer.TabIndex = 0;
            lblCustomer.Text = "Khách hàng";
            // 
            // cboCustomer
            // 
            cboCustomer.DropDownStyle = ComboBoxStyle.DropDownList;
            cboCustomer.Location = new Point(110, 30);
            cboCustomer.Name = "cboCustomer";
            cboCustomer.Size = new Size(350, 23);
            cboCustomer.TabIndex = 1;
            // 
            // grpProduct
            // 
            grpProduct.Controls.Add(lblProduct);
            grpProduct.Controls.Add(cboProduct);
            grpProduct.Controls.Add(lblQuantity);
            grpProduct.Controls.Add(nudQuantity);
            grpProduct.Controls.Add(btnAdd);
            grpProduct.Location = new Point(20, 170);
            grpProduct.Name = "grpProduct";
            grpProduct.Size = new Size(1050, 100);
            grpProduct.TabIndex = 1;
            grpProduct.TabStop = false;
            grpProduct.Text = "Chọn sản phẩm";
            // 
            // lblProduct
            // 
            lblProduct.AutoSize = true;
            lblProduct.Location = new Point(20, 42);
            lblProduct.Name = "lblProduct";
            lblProduct.Size = new Size(60, 15);
            lblProduct.TabIndex = 0;
            lblProduct.Text = "Sản phẩm";
            // 
            // cboProduct
            // 
            cboProduct.DropDownStyle = ComboBoxStyle.DropDownList;
            cboProduct.Location = new Point(100, 38);
            cboProduct.Name = "cboProduct";
            cboProduct.Size = new Size(300, 23);
            cboProduct.TabIndex = 1;
            // 
            // lblQuantity
            // 
            lblQuantity.AutoSize = true;
            lblQuantity.Location = new Point(430, 42);
            lblQuantity.Name = "lblQuantity";
            lblQuantity.Size = new Size(54, 15);
            lblQuantity.TabIndex = 2;
            lblQuantity.Text = "Số lượng";
            // 
            // nudQuantity
            // 
            nudQuantity.Location = new Point(500, 38);
            nudQuantity.Maximum = new decimal(new int[] { 1000, 0, 0, 0 });
            nudQuantity.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            nudQuantity.Name = "nudQuantity";
            nudQuantity.Size = new Size(80, 23);
            nudQuantity.TabIndex = 3;
            nudQuantity.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // btnAdd
            // 
            btnAdd.BackColor = SystemColors.MenuHighlight;
            btnAdd.FlatStyle = FlatStyle.Flat;
            btnAdd.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(620, 28);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(150, 40);
            btnAdd.TabIndex = 4;
            btnAdd.Text = "Thêm vào giỏ";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // grpCart
            // 
            grpCart.Controls.Add(dgvCart);
            grpCart.Controls.Add(lblTongTienTitle);
            grpCart.Controls.Add(lblTongTien);
            grpCart.Controls.Add(btnRemove);
            grpCart.Controls.Add(btnOrder);
            grpCart.Controls.Add(btnClose);
            grpCart.Location = new Point(20, 285);
            grpCart.Name = "grpCart";
            grpCart.Size = new Size(1050, 368);
            grpCart.TabIndex = 0;
            grpCart.TabStop = false;
            grpCart.Text = "Giỏ hàng";
            // 
            // dgvCart
            // 
            dgvCart.AllowUserToAddRows = false;
            dgvCart.AllowUserToDeleteRows = false;
            dgvCart.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvCart.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCart.Location = new Point(20, 30);
            dgvCart.MultiSelect = false;
            dgvCart.Name = "dgvCart";
            dgvCart.ReadOnly = true;
            dgvCart.RowHeadersVisible = false;
            dgvCart.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvCart.Size = new Size(1010, 200);
            dgvCart.TabIndex = 0;
            // 
            // lblTongTienTitle
            // 
            lblTongTienTitle.AutoSize = true;
            lblTongTienTitle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTongTienTitle.Location = new Point(720, 266);
            lblTongTienTitle.Name = "lblTongTienTitle";
            lblTongTienTitle.Size = new Size(76, 19);
            lblTongTienTitle.TabIndex = 1;
            lblTongTienTitle.Text = "Tổng tiền:";
            // 
            // lblTongTien
            // 
            lblTongTien.AutoSize = true;
            lblTongTien.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTongTien.ForeColor = Color.Red;
            lblTongTien.Location = new Point(811, 266);
            lblTongTien.Name = "lblTongTien";
            lblTongTien.Size = new Size(59, 21);
            lblTongTien.TabIndex = 2;
            lblTongTien.Text = "0 VNĐ";
            // 
            // btnRemove
            // 
            btnRemove.BackColor = Color.Crimson;
            btnRemove.FlatStyle = FlatStyle.Flat;
            btnRemove.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnRemove.ForeColor = Color.White;
            btnRemove.Location = new Point(20, 255);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(140, 40);
            btnRemove.TabIndex = 3;
            btnRemove.Text = "Xóa khỏi giỏ";
            btnRemove.UseVisualStyleBackColor = false;
            btnRemove.Click += btnRemove_Click;
            // 
            // btnOrder
            // 
            btnOrder.BackColor = Color.SeaGreen;
            btnOrder.FlatStyle = FlatStyle.Flat;
            btnOrder.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnOrder.ForeColor = Color.White;
            btnOrder.Location = new Point(700, 301);
            btnOrder.Name = "btnOrder";
            btnOrder.Size = new Size(150, 40);
            btnOrder.TabIndex = 4;
            btnOrder.Text = "Đặt hàng";
            btnOrder.UseVisualStyleBackColor = false;
            btnOrder.Click += btnOrder_Click;
            // 
            // btnClose
            // 
            btnClose.BackColor = Color.Gray;
            btnClose.FlatStyle = FlatStyle.Flat;
            btnClose.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            btnClose.ForeColor = Color.White;
            btnClose.Location = new Point(880, 301);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(150, 40);
            btnClose.TabIndex = 5;
            btnClose.Text = "Đóng";
            btnClose.UseVisualStyleBackColor = false;
            btnClose.Click += btnClose_Click;
            // 
            // FormCreateOrder
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1100, 665);
            Controls.Add(grpCart);
            Controls.Add(grpProduct);
            Controls.Add(grpCustomer);
            Controls.Add(pnlHeader);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormCreateOrder";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tạo đơn hàng";
            Load += FormCreateOrder_Load;
            pnlHeader.ResumeLayout(false);
            pnlHeader.PerformLayout();
            grpCustomer.ResumeLayout(false);
            grpCustomer.PerformLayout();
            grpProduct.ResumeLayout(false);
            grpProduct.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)nudQuantity).EndInit();
            grpCart.ResumeLayout(false);
            grpCart.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCart).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlHeader;
        private Label lblTitle;

        private GroupBox grpCustomer;
        private Label lblCustomer;
        private ComboBox cboCustomer;

        private GroupBox grpProduct;
        private Label lblProduct;
        private ComboBox cboProduct;
        private Label lblQuantity;
        private NumericUpDown nudQuantity;
        private Button btnAdd;

        private GroupBox grpCart;
        private DataGridView dgvCart;

        private DataGridViewTextBoxColumn colMaSP;
        private DataGridViewTextBoxColumn colTenSP;
        private DataGridViewTextBoxColumn colDonGia;
        private DataGridViewTextBoxColumn colSoLuong;
        private DataGridViewTextBoxColumn colThanhTien;

        private Label lblTongTienTitle;
        private Label lblTongTien;

        private Button btnRemove;
        private Button btnOrder;
        private Button btnClose;
    }
}
