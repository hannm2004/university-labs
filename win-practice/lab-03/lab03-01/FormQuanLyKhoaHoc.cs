using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace lab03_01
{
    public partial class FormQuanLyKhoaHoc : Form
    {
        // Danh sách khóa học
        private List<KhoaHoc> dsKhoaHoc = new List<KhoaHoc>();

        public FormQuanLyKhoaHoc()
        {
            InitializeComponent();
        }

        // Nút Thêm
        private void btnThem_Click(object sender, EventArgs e)
        {
            string ma = txtMaKhoaHoc.Text.Trim();
            string ten = txtTenKhoaHoc.Text.Trim();
            int soTinChi = (int)nudSoTinChi.Value;

            // Kiểm tra mã
            if (string.IsNullOrWhiteSpace(ma))
            {
                MessageBox.Show(
                    "Vui lòng nhập mã khóa học!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtMaKhoaHoc.Focus();
                return;
            }

            // Kiểm tra tên
            if (string.IsNullOrWhiteSpace(ten))
            {
                MessageBox.Show(
                    "Vui lòng nhập tên khóa học!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtTenKhoaHoc.Focus();
                return;
            }

            // Kiểm tra trùng mã
            if (dsKhoaHoc.Any(x => x.MaKhoaHoc.Equals(ma, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show(
                    "Mã khóa học đã tồn tại!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtMaKhoaHoc.Focus();
                txtMaKhoaHoc.SelectAll();
                return;
            }

            // Tạo đối tượng
            KhoaHoc khoaHoc = new KhoaHoc
            {
                MaKhoaHoc = ma,
                TenKhoaHoc = ten,
                SoTinChi = soTinChi
            };

            // Lưu danh sách
            dsKhoaHoc.Add(khoaHoc);

            // Hiển thị ListBox
            lstKhoaHoc.Items.Add(khoaHoc);

            // Thêm tên khoa vào dữ liệu dùng chung
            if (!DuLieuDungChung.DanhSachKhoa.Contains(ten))
            {
                DuLieuDungChung.DanhSachKhoa.Add(ten);
            }

            MessageBox.Show(
                "Thêm khóa học thành công!",
                "Thông báo",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            LamMoi();
        }

        // Làm mới dữ liệu nhập
        private void LamMoi()
        {
            txtMaKhoaHoc.Clear();
            txtTenKhoaHoc.Clear();

            nudSoTinChi.Value = 1;

            txtMaKhoaHoc.Focus();
        }

        // Nếu cần tải lại ListBox
        private void HienThiDanhSach()
        {
            lstKhoaHoc.Items.Clear();

            foreach (KhoaHoc kh in dsKhoaHoc)
            {
                lstKhoaHoc.Items.Add(kh);
            }
        }
    }
}