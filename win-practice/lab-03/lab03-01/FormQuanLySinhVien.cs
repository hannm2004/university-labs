using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab03_01
{
    public partial class FormQuanLySinhVien : Form
    {
        private List<SinhVien> danhSachSinhVien = new List<SinhVien>();
        private int dongDangChon = -1;

        public FormQuanLySinhVien()
        {
            InitializeComponent();
        }

        private void FormQuanLySinhVien_Load(object sender, EventArgs e)
        {
            dgvSinhVien.Columns.Clear();

            dgvSinhVien.Columns.Add("MaSV", "Mã SV");
            dgvSinhVien.Columns.Add("HoTen", "Họ tên");
            dgvSinhVien.Columns.Add("NgaySinh", "Ngày sinh");
            dgvSinhVien.Columns.Add("GioiTinh", "Giới tính");
            dgvSinhVien.Columns.Add("Khoa", "Khoa");
            dgvSinhVien.Columns.Add("DiemTB", "Điểm TB");

            radNam.Checked = true;

            lblTongSV.Text = "Tổng số sinh viên: 0";
        }

        private void HienThiDanhSach(List<SinhVien> ds = null)
        {
            dgvSinhVien.Rows.Clear();

            var data = ds ?? danhSachSinhVien;

            foreach (SinhVien sv in data)
            {
                dgvSinhVien.Rows.Add(
                    sv.MaSV,
                    sv.HoTen,
                    sv.NgaySinh.ToShortDateString(),
                    sv.GioiTinh,
                    sv.Khoa,
                    sv.DiemTB);
            }

            lblTongSV.Text = $"Tổng số sinh viên: {data.Count()}";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtMaSV.Text.Trim() == "")
            {
                MessageBox.Show("Nhập mã sinh viên");
                txtMaSV.Focus();
                return;
            }

            if (txtHoTen.Text.Trim() == "")
            {
                MessageBox.Show("Nhập họ tên");
                txtHoTen.Focus();
                return;
            }

            if (cboKhoa.SelectedIndex == -1)
            {
                MessageBox.Show("Chọn khoa");
                return;
            }

            if (!double.TryParse(txtDiemTB.Text, out double diem))
            {
                MessageBox.Show("Điểm không hợp lệ");
                txtDiemTB.Focus();
                return;
            }

            if (danhSachSinhVien.Any(x => x.MaSV == txtMaSV.Text))
            {
                MessageBox.Show("Mã sinh viên đã tồn tại");
                return;
            }

            SinhVien sv = new SinhVien();

            sv.MaSV = txtMaSV.Text;
            sv.HoTen = txtHoTen.Text;
            sv.NgaySinh = dtpNgaySinh.Value;
            sv.GioiTinh = radNam.Checked ? "Nam" : "Nữ";
            sv.Khoa = cboKhoa.Text;
            sv.DiemTB = diem;

            danhSachSinhVien.Add(sv);

            HienThiDanhSach();

            LamMoi();
        }

        private void LamMoi()
        {
            txtMaSV.Clear();
            txtHoTen.Clear();
            txtDiemTB.Clear();

            cboKhoa.SelectedIndex = -1;

            radNam.Checked = true;

            dtpNgaySinh.Value = DateTime.Now;

            dongDangChon = -1;

            txtMaSV.Focus();
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoi();
        }

        private void dgvSinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            dongDangChon = e.RowIndex;

            SinhVien sv = danhSachSinhVien[e.RowIndex];

            txtMaSV.Text = sv.MaSV;
            txtHoTen.Text = sv.HoTen;
            dtpNgaySinh.Value = sv.NgaySinh;

            if (sv.GioiTinh == "Nam")
                radNam.Checked = true;
            else
                radNu.Checked = true;

            cboKhoa.Text = sv.Khoa;
            txtDiemTB.Text = sv.DiemTB.ToString();
        }

        private void btnCapNhat_Click(object sender, EventArgs e)
        {
            if (dongDangChon == -1)
            {
                MessageBox.Show("Hãy chọn sinh viên cần cập nhật");
                return;
            }

            if (!double.TryParse(txtDiemTB.Text, out double diem))
            {
                MessageBox.Show("Điểm không hợp lệ");
                return;
            }

            SinhVien sv = danhSachSinhVien[dongDangChon];

            sv.MaSV = txtMaSV.Text;
            sv.HoTen = txtHoTen.Text;
            sv.NgaySinh = dtpNgaySinh.Value;
            sv.GioiTinh = radNam.Checked ? "Nam" : "Nữ";
            sv.Khoa = cboKhoa.Text;
            sv.DiemTB = diem;

            HienThiDanhSach();

            LamMoi();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dongDangChon == -1)
            {
                MessageBox.Show("Chọn sinh viên cần xóa");
                return;
            }

            DialogResult kq = MessageBox.Show(
                "Bạn có chắc muốn xóa?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (kq == DialogResult.Yes)
            {
                danhSachSinhVien.RemoveAt(dongDangChon);

                HienThiDanhSach();

                LamMoi();
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            string tuKhoa = txtTimKiem.Text.ToLower();

            var ketQua = danhSachSinhVien.Where(x =>
                x.MaSV.ToLower().Contains(tuKhoa) ||
                x.HoTen.ToLower().Contains(tuKhoa))
                .ToList();

            HienThiDanhSach(ketQua);
        }
    }
}
