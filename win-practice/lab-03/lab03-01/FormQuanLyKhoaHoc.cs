using System;
using System.Collections.Generic;
using System.Linq;
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


        private void btnThem_Click(object sender, EventArgs e)
        {
            string ma = txtMaKhoaHoc.Text.Trim();
            string ten = txtTenKhoaHoc.Text.Trim();
            int soTinChi = (int)nudSoTinChi.Value;


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


            KhoaHoc khoaHoc = new KhoaHoc
            {
                MaKhoaHoc = ma,
                TenKhoaHoc = ten,
                SoTinChi = soTinChi
            };


            dsKhoaHoc.Add(khoaHoc);

            lstKhoaHoc.Items.Add(khoaHoc);


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

        private void LamMoi()
        {
            txtMaKhoaHoc.Clear();
            txtTenKhoaHoc.Clear();

            nudSoTinChi.Value = 1;

            txtMaKhoaHoc.Focus();
        }


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