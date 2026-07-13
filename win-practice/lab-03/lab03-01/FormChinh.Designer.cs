namespace lab03_01
{
    partial class FormChinh
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
            menuStripChinh = new MenuStrip();
            mnuHeThong = new ToolStripMenuItem();
            quảnLýKhóaHọcToolStripMenuItem = new ToolStripMenuItem();
            mnuQuanLySinhVien = new ToolStripMenuItem();
            mnuThoat = new ToolStripMenuItem();
            mnuCuaSo = new ToolStripMenuItem();
            mnuSapXepTang = new ToolStripMenuItem();
            mnuSapXepNgang = new ToolStripMenuItem();
            mnuSapXepDoc = new ToolStripMenuItem();
            mnuDongTatCa = new ToolStripMenuItem();
            menuStripChinh.SuspendLayout();
            SuspendLayout();
            // 
            // menuStripChinh
            // 
            menuStripChinh.Items.AddRange(new ToolStripItem[] { mnuHeThong, mnuCuaSo });
            menuStripChinh.Location = new Point(0, 0);
            menuStripChinh.MdiWindowListItem = mnuCuaSo;
            menuStripChinh.Name = "menuStripChinh";
            menuStripChinh.Size = new Size(800, 24);
            menuStripChinh.TabIndex = 1;
            menuStripChinh.Text = "menuStrip1";
            // 
            // mnuHeThong
            // 
            mnuHeThong.DropDownItems.AddRange(new ToolStripItem[] { quảnLýKhóaHọcToolStripMenuItem, mnuQuanLySinhVien, mnuThoat });
            mnuHeThong.Name = "mnuHeThong";
            mnuHeThong.Size = new Size(69, 20);
            mnuHeThong.Text = "Hệ thống";
            // 
            // quảnLýKhóaHọcToolStripMenuItem
            // 
            quảnLýKhóaHọcToolStripMenuItem.Name = "quảnLýKhóaHọcToolStripMenuItem";
            quảnLýKhóaHọcToolStripMenuItem.Size = new Size(180, 22);
            quảnLýKhóaHọcToolStripMenuItem.Text = "Quản lý khóa học";
//            quảnLýKhóaHọcToolStripMenuItem.Click += this.quảnLýKhóaHọcToolStripMenuItem_Click;
            // 
            // mnuQuanLySinhVien
            // 
            mnuQuanLySinhVien.Name = "mnuQuanLySinhVien";
            mnuQuanLySinhVien.Size = new Size(180, 22);
            mnuQuanLySinhVien.Text = "Quản lý sinh viên";
            // 
            // mnuThoat
            // 
            mnuThoat.Name = "mnuThoat";
            mnuThoat.Size = new Size(180, 22);
            mnuThoat.Text = "Thoát";
            // 
            // mnuCuaSo
            // 
            mnuCuaSo.DropDownItems.AddRange(new ToolStripItem[] { mnuSapXepTang, mnuSapXepNgang, mnuSapXepDoc, mnuDongTatCa });
            mnuCuaSo.Name = "mnuCuaSo";
            mnuCuaSo.Size = new Size(55, 20);
            mnuCuaSo.Text = "Cửa sổ";
            // 
            // mnuSapXepTang
            // 
            mnuSapXepTang.Name = "mnuSapXepTang";
            mnuSapXepTang.Size = new Size(152, 22);
            mnuSapXepTang.Text = "Sắp xếp tầng";
            // 
            // mnuSapXepNgang
            // 
            mnuSapXepNgang.Name = "mnuSapXepNgang";
            mnuSapXepNgang.Size = new Size(152, 22);
            mnuSapXepNgang.Text = "Sắp xếp ngang";
            // 
            // mnuSapXepDoc
            // 
            mnuSapXepDoc.Name = "mnuSapXepDoc";
            mnuSapXepDoc.Size = new Size(152, 22);
            mnuSapXepDoc.Text = "Sắp xếp dọc";
            // 
            // mnuDongTatCa
            // 
            mnuDongTatCa.Name = "mnuDongTatCa";
            mnuDongTatCa.Size = new Size(152, 22);
            mnuDongTatCa.Text = "Đóng tất cả";
            // 
            // FormChinh
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(menuStripChinh);
            IsMdiContainer = true;
            MainMenuStrip = menuStripChinh;
            Name = "FormChinh";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hệ Thống Quản Lý - HUTECH";
            WindowState = FormWindowState.Maximized;
            menuStripChinh.ResumeLayout(false);
            menuStripChinh.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStripChinh;
        private ToolStripMenuItem mnuHeThong;
        private ToolStripMenuItem quảnLýKhóaHọcToolStripMenuItem;
        private ToolStripMenuItem mnuQuanLySinhVien;
        private ToolStripMenuItem mnuThoat;
        private ToolStripMenuItem mnuCuaSo;
        private ToolStripMenuItem mnuSapXepTang;
        private ToolStripMenuItem mnuSapXepNgang;
        private ToolStripMenuItem mnuSapXepDoc;
        private ToolStripMenuItem mnuDongTatCa;
    }
}
