namespace Lab02_03
{
    partial class Form1
    {
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
            this.panelSoDoGhe = new System.Windows.Forms.Panel();
            this.cboPhim = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lblGheDaChon = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblTongTien = new System.Windows.Forms.Label();
            this.btnXacNhan = new System.Windows.Forms.Button();
            this.btnHuyChon = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // panelSoDoGhe
            // 
            this.panelSoDoGhe.Location = new System.Drawing.Point(75, 74);
            this.panelSoDoGhe.Name = "panelSoDoGhe";
            this.panelSoDoGhe.Size = new System.Drawing.Size(450, 300);
            this.panelSoDoGhe.TabIndex = 7;
            // 
            // cboPhim
            // 
            this.cboPhim.FormattingEnabled = true;
            this.cboPhim.Items.AddRange(new object[] {
            "Avatar: Dòng Chảy Của Cát",
            "Avengers: Endgame",
            "Spider-Man",
            "Lật Mặt 8"});
            this.cboPhim.Location = new System.Drawing.Point(111, 21);
            this.cboPhim.Name = "cboPhim";
            this.cboPhim.Size = new System.Drawing.Size(414, 21);
            this.cboPhim.TabIndex = 8;
            this.cboPhim.SelectedIndexChanged += new System.EventHandler(this.cboPhim_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(72, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(33, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Phim:";
            // 
            // lblGheDaChon
            // 
            this.lblGheDaChon.AutoSize = true;
            this.lblGheDaChon.Location = new System.Drawing.Point(674, 110);
            this.lblGheDaChon.Name = "lblGheDaChon";
            this.lblGheDaChon.Size = new System.Drawing.Size(35, 13);
            this.lblGheDaChon.TabIndex = 10;
            this.lblGheDaChon.Text = "label2";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(674, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 13);
            this.label2.TabIndex = 11;
            this.label2.Text = "Ghế đã chọn:";
            // 
            // lblTongTien
            // 
            this.lblTongTien.AutoSize = true;
            this.lblTongTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongTien.ForeColor = System.Drawing.Color.Red;
            this.lblTongTien.Location = new System.Drawing.Point(672, 215);
            this.lblTongTien.Name = "lblTongTien";
            this.lblTongTien.Size = new System.Drawing.Size(38, 25);
            this.lblTongTien.TabIndex = 12;
            this.lblTongTien.Text = "0đ";
            // 
            // btnXacNhan
            // 
            this.btnXacNhan.BackColor = System.Drawing.Color.ForestGreen;
            this.btnXacNhan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXacNhan.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXacNhan.ForeColor = System.Drawing.SystemColors.Window;
            this.btnXacNhan.Location = new System.Drawing.Point(643, 331);
            this.btnXacNhan.Name = "btnXacNhan";
            this.btnXacNhan.Size = new System.Drawing.Size(195, 43);
            this.btnXacNhan.TabIndex = 14;
            this.btnXacNhan.Text = "Xác nhận đặt vé";
            this.btnXacNhan.UseVisualStyleBackColor = false;
            this.btnXacNhan.Click += new System.EventHandler(this.btnXacNhan_Click);
            // 
            // btnHuyChon
            // 
            this.btnHuyChon.BackColor = System.Drawing.Color.Gray;
            this.btnHuyChon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuyChon.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnHuyChon.ForeColor = System.Drawing.Color.White;
            this.btnHuyChon.Location = new System.Drawing.Point(643, 402);
            this.btnHuyChon.Name = "btnHuyChon";
            this.btnHuyChon.Size = new System.Drawing.Size(195, 43);
            this.btnHuyChon.TabIndex = 15;
            this.btnHuyChon.Text = "Hủy chọn ghế";
            this.btnHuyChon.UseVisualStyleBackColor = false;
            this.btnHuyChon.Click += new System.EventHandler(this.btnHuyChon_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(675, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Tổng tiền:";
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(75, 468);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(35, 35);
            this.panel1.TabIndex = 17;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gold;
            this.panel2.Location = new System.Drawing.Point(252, 468);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(35, 35);
            this.panel2.TabIndex = 18;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.Firebrick;
            this.panel3.Location = new System.Drawing.Point(432, 468);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(35, 35);
            this.panel3.TabIndex = 19;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(133, 490);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(35, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Trống";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(309, 490);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Đang chọn";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(483, 490);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 22;
            this.label6.Text = "Đã bán";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 540);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnHuyChon);
            this.Controls.Add(this.btnXacNhan);
            this.Controls.Add(this.lblTongTien);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblGheDaChon);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cboPhim);
            this.Controls.Add(this.panelSoDoGhe);
            this.Name = "Form1";
            this.Text = "BÁN VÉ RẠP CHIẾU PHIM";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panelSoDoGhe;
        private System.Windows.Forms.ComboBox cboPhim;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblGheDaChon;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTongTien;
        private System.Windows.Forms.Button btnXacNhan;
        private System.Windows.Forms.Button btnHuyChon;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
    }
}
