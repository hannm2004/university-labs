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
    public partial class FormQuanLyKhoaHoc : Form
    {
        private List<KhoaHoc> dsKhoaHoc = new List<KhoaHoc>();

        public FormQuanLyKhoaHoc()
        {
            InitializeComponent();
        }

        private void BtnThem_Click(object sender, EventArgs e)
        {
            string ma = txtMaKhoaHoc.Text.Trim();
            string ten = txtTenKhoaHoc.Text.Trim();
            int soTinChi = (int)nudSoTinChi.Value;

            // Kiểm tra rỗng
            if (string.IsNullOrEmpty(ma))
            {
                MessageBox.Show("Vui lòng nhập mã khóa học!");
                txtMaKhoaHoc.Focus();
                return;
            }

            if (string.IsNullOrEmpty(ten))
            {
                MessageBox.Show("Vui lòng nhập tên khóa học!");
                txtTenKhoaHoc.Focus();
                return;
            }

            // Kiểm tra trùng mã
            if (dsKhoaHoc.Any(x => x.MaKhoaHoc == ma))
            {
                MessageBox.Show("Mã khóa học đã tồn tại!");
                txtMaKhoaHoc.Focus();
                return;
            }

            // Tạo khóa học
            KhoaHoc kh = new KhoaHoc()
            {
                MaKhoaHoc = ma,
                TenKhoaHoc = ten,
                SoTinChi = soTinChi
            };

            dsKhoaHoc.Add(kh);

            // Hiển thị ListBox
            lstKhoaHoc.Items.Add(kh);

            MessageBox.Show("Thêm khóa học thành công!");

            // Xóa dữ liệu
            txtMaKhoaHoc.Clear();
            txtTenKhoaHoc.Clear();
            nudSoTinChi.Value = 1;

            txtMaKhoaHoc.Focus();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string ma = txtMaKhoaHoc.Text.Trim();
            string ten = txtTenKhoaHoc.Text.Trim();
            int soTinChi = (int)nudSoTinChi.Value;

            // Kiểm tra dữ liệu
            if (string.IsNullOrWhiteSpace(ma))
            {
                MessageBox.Show("Vui lòng nhập mã khóa học!");
                txtMaKhoaHoc.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(ten))
            {
                MessageBox.Show("Vui lòng nhập tên khóa học!");
                txtTenKhoaHoc.Focus();
                return;
            }

            // Kiểm tra trùng mã
            foreach (KhoaHoc kh in dsKhoaHoc)
            {
                if (kh.MaKhoaHoc.Equals(ma, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Mã khóa học đã tồn tại!");
                    txtMaKhoaHoc.Focus();
                    return;
                }
            }

            // Tạo khóa học mới
            KhoaHoc khoaHoc = new KhoaHoc
            {
                MaKhoaHoc = ma,
                TenKhoaHoc = ten,
                SoTinChi = soTinChi
            };

            // Thêm vào danh sách
            dsKhoaHoc.Add(khoaHoc);

            // Hiển thị lên ListBox
            lstKhoaHoc.Items.Add(khoaHoc);

            MessageBox.Show("Thêm khóa học thành công!");

            // Xóa dữ liệu nhập
            txtMaKhoaHoc.Clear();
            txtTenKhoaHoc.Clear();
            nudSoTinChi.Value = 1;
            txtMaKhoaHoc.Focus();
        }
    }
}
