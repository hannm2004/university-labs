using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace lab03_02
{
    public partial class FormChiTietSinhVien : Form
    {
        public SinhVien SinhVienMoi { get; private set; }

        private List<string> dsMaSV;

        public FormChiTietSinhVien(List<string> danhSachMa)
        {
            InitializeComponent();

            dsMaSV = danhSachMa;

            this.Load += FormChiTietSinhVien_Load;
        }

        public FormChiTietSinhVien(SinhVien sv, List<string> danhSachMa)
        {
            InitializeComponent();

            dsMaSV = danhSachMa;

            this.Load += FormChiTietSinhVien_Load;

            txtMaSV.Text = sv.MaSV;
            txtMaSV.Enabled = false;

            txtHoTen.Text = sv.HoTen;

            dtNgaySinh.Value = sv.NgaySinh;

            if (sv.GioiTinh)
                radNam.Checked = true;
            else
                radNu.Checked = true;

            cboKhoa.Text = sv.Khoa;

            txtDiemTB.Text = sv.DiemTB?.ToString();
        }

        private void FormChiTietSinhVien_Load(object sender, EventArgs e)
        {
            cboKhoa.Items.Clear();

            cboKhoa.Items.Add("Công nghệ thông tin");
            cboKhoa.Items.Add("Quản trị kinh doanh");
            cboKhoa.Items.Add("Kỹ thuật Công trình");

            if (cboKhoa.Items.Count > 0 && cboKhoa.SelectedIndex == -1)
                cboKhoa.SelectedIndex = 0;
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaSV.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập Mã sinh viên!");

                txtMaSV.Focus();

                return;
            }

            if (txtHoTen.Text.Trim() == "")
            {
                MessageBox.Show("Vui lòng nhập Họ tên!");

                txtHoTen.Focus();

                return;
            }

            if (txtMaSV.Enabled)
            {
                if (dsMaSV.Contains(txtMaSV.Text.Trim()))
                {
                    MessageBox.Show("Mã sinh viên đã tồn tại!");

                    txtMaSV.Focus();

                    return;
                }
            }

            double? diem = null;

            if (txtDiemTB.Text.Trim() != "")
            {
                double d;

                if (!double.TryParse(txtDiemTB.Text, out d))
                {
                    MessageBox.Show("Điểm phải là số!");

                    txtDiemTB.Focus();

                    return;
                }

                if (d < 0 || d > 10)
                {
                    MessageBox.Show("Điểm phải từ 0 đến 10!");

                    txtDiemTB.Focus();

                    return;
                }

                diem = d;
            }

            SinhVienMoi = new SinhVien()
            {
                MaSV = txtMaSV.Text.Trim(),
                HoTen = txtHoTen.Text.Trim(),
                NgaySinh = dtNgaySinh.Value,
                GioiTinh = radNam.Checked,
                Khoa = cboKhoa.Text,
                DiemTB = diem
            };

            DialogResult = DialogResult.OK;

            Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;

            Close();
        }
    }
}