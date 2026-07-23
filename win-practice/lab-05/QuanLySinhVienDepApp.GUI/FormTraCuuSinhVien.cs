using lab04_01.Models;
using Microsoft.EntityFrameworkCore;

namespace lab04_01
{
    public partial class FormTraCuuSinhVien : Form
    {
        public FormTraCuuSinhVien()
        {
            InitializeComponent();
        }

        private void FormTraCuuSinhVien_Load(object sender, EventArgs e)
        {
            LayDanhSachKhoa();
            TimKiemSinhVien();
        }

        private void LayDanhSachKhoa()
        {
            try
            {
                using var db = new QuanLySinhVienDbContext();

                cboKhoa.Items.Clear();

                cboKhoa.Items.Add("-- Tất cả Khoa --");

                foreach (var khoa in db.Khoas.ToList())
                {
                    cboKhoa.Items.Add(khoa);
                }

                cboKhoa.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void TimKiemSinhVien()
        {
            try
            {
                using var db = new QuanLySinhVienDbContext();

                var query = db.SinhViens
                              .Include(x => x.Khoa)
                              .AsQueryable();

                string tuKhoa = txtTuKhoa.Text.Trim();

                if (!string.IsNullOrWhiteSpace(tuKhoa))
                {
                    query = query.Where(x =>
                        x.MaSV.Contains(tuKhoa) ||
                        x.HoTen.Contains(tuKhoa));
                }

                if (cboKhoa.SelectedIndex > 0)
                {
                    Khoa khoa = (Khoa)cboKhoa.SelectedItem!;
                    query = query.Where(x => x.KhoaId == khoa.Id);
                }

                double diemTu = (double)nudTu.Value;
                double diemDen = (double)nudDen.Value;

                if (chkBaoGomChuaCoDiem.Checked)
                {
                    query = query.Where(x =>
                        !x.DiemTB.HasValue ||
                        (x.DiemTB >= diemTu && x.DiemTB <= diemDen));
                }
                else
                {
                    query = query.Where(x =>
                        x.DiemTB.HasValue &&
                        x.DiemTB >= diemTu &&
                        x.DiemTB <= diemDen);
                }

                dgvSinhVien.DataSource = query.ToList();

                lblKetQua.Text = $"Tìm thấy: {query.Count()} sinh viên";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void txtTuKhoa_TextChanged(object sender, EventArgs e)
        {
            TimKiemSinhVien();
        }

        private void cboKhoa_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboKhoa.SelectedIndex >= 0)
                TimKiemSinhVien();
        }

        private void nudTu_ValueChanged(object sender, EventArgs e)
        {
            TimKiemSinhVien();
        }

        private void nudDen_ValueChanged(object sender, EventArgs e)
        {
            TimKiemSinhVien();
        }

        private void chkBaoGomChuaCoDiem_CheckedChanged(object sender, EventArgs e)
        {
            TimKiemSinhVien();
        }

        private void btnXoaBoLoc_Click(object sender, EventArgs e)
        {
            txtTuKhoa.Clear();

            cboKhoa.SelectedIndex = 0;

            nudTu.Value = 0;

            nudDen.Value = 10;

            chkBaoGomChuaCoDiem.Checked = true;

            TimKiemSinhVien();
        }


    }
}