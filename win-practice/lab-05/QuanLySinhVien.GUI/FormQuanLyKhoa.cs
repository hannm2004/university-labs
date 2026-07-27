using Microsoft.EntityFrameworkCore;
using QuanLySinhVien.DAL;
using QuanLySinhVien.DAL.Models;
using System;
namespace QuanLySinhVien.GUI
{
    public partial class FormQuanLyKhoa : Form
    {
        private int? idDangSua = null;

        public FormQuanLyKhoa()
        {
            InitializeComponent();
        }

        private void FormQuanLyKhoa_Load(object sender, EventArgs e)
        {
            LayDanhSachKhoa();
            LamMoiForm();
        }

        private void LayDanhSachKhoa()
        {
            try
            {
                using var db = new QuanLySinhVienDbContext();

                dgvKhoa.DataSource = db.Khoas.ToList();

                lblTongKhoa.Text = $"Tổng số khoa: {db.Khoas.Count()}";
                lblTrangThai.Text = "Sẵn sàng";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Không thể kết nối CSDL!\n{ex.Message}",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                lblTrangThai.Text = "Lỗi";
            }
        }

        private void LamMoiForm()
        {
            txtTenKhoa.Clear();

            chkNamThanhLap.Checked = true;
            chkTongGV.Checked = true;

            nudNamThanhLap.Value = 1900;
            nudTongGV.Value = 0;

            nudNamThanhLap.Enabled = false;
            nudTongGV.Enabled = false;

            idDangSua = null;

            dgvKhoa.ClearSelection();

            txtTenKhoa.Focus();
        }

        private void chkNamThanhLap_CheckedChanged(object sender, EventArgs e)
        {
            nudNamThanhLap.Enabled = !chkNamThanhLap.Checked;
        }

        private void chkTongGV_CheckedChanged(object sender, EventArgs e)
        {
            nudTongGV.Enabled = !chkTongGV.Checked;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenKhoa.Text))
            {
                MessageBox.Show(
                    "Vui lòng nhập tên khoa!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtTenKhoa.Focus();
                return;
            }

            try
            {
                using var db = new QuanLySinhVienDbContext();

                if (db.Khoas.Any(k => k.TenKhoa == txtTenKhoa.Text.Trim()))
                {
                    MessageBox.Show(
                        "Tên khoa đã tồn tại!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                db.Khoas.Add(new Khoa
                {
                    TenKhoa = txtTenKhoa.Text.Trim(),
                    NamThanhLap = chkNamThanhLap.Checked ? null : (int?)nudNamThanhLap.Value,
                    TongSoGiangVien = chkTongGV.Checked ? null : (int?)nudTongGV.Value
                });

                db.SaveChanges();

                MessageBox.Show(
                    "Thêm khoa thành công!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LamMoiForm();
                LayDanhSachKhoa();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void dgvKhoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            Khoa? khoa = dgvKhoa.Rows[e.RowIndex].DataBoundItem as Khoa;

            if (khoa == null) return;

            idDangSua = khoa.Id;

            txtTenKhoa.Text = khoa.TenKhoa;

            if (khoa.NamThanhLap.HasValue)
            {
                chkNamThanhLap.Checked = false;
                nudNamThanhLap.Value = khoa.NamThanhLap.Value;
            }
            else
            {
                chkNamThanhLap.Checked = true;
            }

            if (khoa.TongSoGiangVien.HasValue)
            {
                chkTongGV.Checked = false;
                nudTongGV.Value = khoa.TongSoGiangVien.Value;
            }
            else
            {
                chkTongGV.Checked = true;
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (idDangSua == null)
            {
                MessageBox.Show("Hãy chọn khoa cần sửa!");
                return;
            }

            try
            {
                using var db = new QuanLySinhVienDbContext();

                var khoa = db.Khoas.Find(idDangSua);

                if (khoa == null)
                    return;

                if (db.Khoas.Any(k => k.Id != idDangSua &&
                                      k.TenKhoa == txtTenKhoa.Text.Trim()))
                {
                    MessageBox.Show(
                        "Tên khoa đã tồn tại!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                khoa.TenKhoa = txtTenKhoa.Text.Trim();
                khoa.NamThanhLap = chkNamThanhLap.Checked ? null : (int?)nudNamThanhLap.Value;
                khoa.TongSoGiangVien = chkTongGV.Checked ? null : (int?)nudTongGV.Value;

                db.SaveChanges();

                MessageBox.Show(
                    "Cập nhật thành công!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LamMoiForm();
                LayDanhSachKhoa();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (idDangSua == null)
            {
                MessageBox.Show("Hãy chọn khoa cần xóa!");
                return;
            }

            if (MessageBox.Show(
                "Bạn có chắc muốn xóa khoa này?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.No)
                return;

            try
            {
                using var db = new QuanLySinhVienDbContext();

                var khoa = db.Khoas.Find(idDangSua);

                if (khoa == null)
                    return;

                if (db.SinhViens.Any(sv => sv.KhoaId == khoa.Id))
                {
                    MessageBox.Show(
                        "Không thể xóa khoa vì vẫn còn sinh viên thuộc khoa này!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                db.Khoas.Remove(khoa);

                db.SaveChanges();

                MessageBox.Show(
                    "Xóa thành công!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LamMoiForm();
                LayDanhSachKhoa();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoiForm();
        }
    }
}