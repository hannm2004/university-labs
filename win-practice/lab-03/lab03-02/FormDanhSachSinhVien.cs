using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace lab03_02
{
    public partial class FormDanhSachSinhVien : Form
    {
        List<SinhVien> dsSinhVien = new List<SinhVien>();

        public FormDanhSachSinhVien()
        {
            InitializeComponent();

            this.Load += FormDanhSachSinhVien_Load;
            dgvSinhVien.CellFormatting += dgvSinhVien_CellFormatting;
        }

        private void FormDanhSachSinhVien_Load(object sender, EventArgs e)
        {
            dsSinhVien.Add(new SinhVien()
            {
                MaSV = "SV001",
                HoTen = "Nguyễn Văn An",
                NgaySinh = new DateTime(2003, 5, 12),
                GioiTinh = true,
                Khoa = "Công nghệ thông tin",
                DiemTB = 8.2
            });

            dsSinhVien.Add(new SinhVien()
            {
                MaSV = "SV002",
                HoTen = "Trần Thị Bích",
                NgaySinh = new DateTime(2003, 8, 20),
                GioiTinh = false,
                Khoa = "Quản trị kinh doanh",
                DiemTB = 7.5
            });

            dsSinhVien.Add(new SinhVien()
            {
                MaSV = "SV003",
                HoTen = "Lê Văn Cường",
                NgaySinh = new DateTime(2004, 1, 15),
                GioiTinh = true,
                Khoa = "Kỹ thuật Công trình",
                DiemTB = null
            });

            LoadData();
        }

        private void LoadData()
        {
            dgvSinhVien.Rows.Clear();

            foreach (SinhVien sv in dsSinhVien)
            {
                dgvSinhVien.Rows.Add(
                    sv.MaSV,
                    sv.HoTen,
                    sv.NgaySinh.ToString("dd/MM/yyyy"),
                    sv.GioiTinh ? "Nam" : "Nữ",
                    sv.Khoa,
                    sv.DiemTB
                );
            }

            lblTong.Text = "Tổng số sinh viên: " + dsSinhVien.Count;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            List<string> dsMa =
                dsSinhVien.Select(x => x.MaSV).ToList();

            FormChiTietSinhVien frm =
                new FormChiTietSinhVien(dsMa);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                dsSinhVien.Add(frm.SinhVienMoi);

                LoadData();
            }
        }


        private void btnSua_Click(object sender, EventArgs e)
        {
            if (dgvSinhVien.CurrentRow == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn sinh viên cần sửa!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            int index = dgvSinhVien.CurrentRow.Index;

            SinhVien sv = dsSinhVien[index];

            List<string> dsMa =
                dsSinhVien
                .Where(x => x.MaSV != sv.MaSV)
                .Select(x => x.MaSV)
                .ToList();

            FormChiTietSinhVien frm =
                new FormChiTietSinhVien(sv, dsMa);

            if (frm.ShowDialog() == DialogResult.OK)
            {
                dsSinhVien[index] = frm.SinhVienMoi;

                LoadData();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvSinhVien.CurrentRow == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn sinh viên cần xóa!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            DialogResult result = MessageBox.Show(
                "Bạn có chắc muốn xóa sinh viên này?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                int index = dgvSinhVien.CurrentRow.Index;

                dsSinhVien.RemoveAt(index);

                LoadData();
            }
        }

        private void dgvSinhVien_CellFormatting(
            object sender,
            DataGridViewCellFormattingEventArgs e)
        {
            if (dgvSinhVien.Columns[e.ColumnIndex].Name == "DiemTB")
            {
                if (e.Value == null)
                {
                    e.Value = "Chưa có";
                    e.FormattingApplied = true;
                }
            }
        }
    }
}