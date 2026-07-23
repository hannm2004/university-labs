using QuanLySinhVien.BLL;
using QuanLySinhVien.DAL.Models;
using System;
using Microsoft.EntityFrameworkCore;
namespace QuanLySinhVien.GUI
{
    public partial class FormChinh : Form
    {
        private readonly SinhVienBLL sinhVienBLL = new SinhVienBLL();
        private readonly KhoaBLL khoaBLL = new KhoaBLL();

        private int? idDangSua = null;

        public FormChinh()
        {
            InitializeComponent();
        }

        private void FormChinh_Load(object sender, EventArgs e)
        {
            LayDanhSachKhoa();
            LamMoiForm();
            LayDanhSachSinhVien();
        }

        private void LayDanhSachKhoa()
        {
            try
            {
                cboKhoa.DataSource = khoaBLL.LayDanhSach();
                cboKhoa.DisplayMember = "TenKhoa";
                cboKhoa.ValueMember = "Id";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Không thể tải danh sách khoa!\n{ex.Message}",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void LayDanhSachSinhVien()
        {
            try
            {
                var ds = sinhVienBLL.LayDanhSach();

                dgvSinhVien.DataSource = ds;

                lblTongSo.Text = $"Tổng số sinh viên: {ds.Count}";

                lblTrangThai.Text = "Sẵn sàng";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    ex.Message,
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                lblTrangThai.Text = "Lỗi";
            }
        }

        private void LamMoiForm()
        {
            txtMaSV.Clear();
            txtHoTen.Clear();
            txtDiemTB.Clear();

            dtpNgaySinh.Value = new DateTime(2000, 1, 1);

            rdoNam.Checked = true;

            if (cboKhoa.Items.Count > 0)
                cboKhoa.SelectedIndex = 0;

            txtMaSV.Enabled = true;

            idDangSua = null;

            dgvSinhVien.ClearSelection();
        }
        private void btnThemKhoa_Click(object sender, EventArgs e)
        {
            FormThemKhoa frm = new FormThemKhoa();

            if (frm.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    khoaBLL.ThemMoi(
                        frm.TenKhoaMoi!,
                        null,
                        null);

                    LayDanhSachKhoa();

                    MessageBox.Show(
                        "Thêm khoa thành công!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
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
        }
        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                sinhVienBLL.ThemMoi(
                    txtMaSV.Text,
                    txtHoTen.Text,
                    dtpNgaySinh.Value,
                    rdoNam.Checked ? "Nam" : "Nữ",
                    ((Khoa)cboKhoa.SelectedItem!).Id,
                    txtDiemTB.Text);

                MessageBox.Show(
                    "Thêm sinh viên thành công!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LamMoiForm();
                LayDanhSachSinhVien();
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
        private void dgvSinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            SinhVien? sv =
                dgvSinhVien.Rows[e.RowIndex].DataBoundItem as SinhVien;

            if (sv == null)
                return;

            txtMaSV.Text = sv.MaSV;
            txtHoTen.Text = sv.HoTen;
            dtpNgaySinh.Value = sv.NgaySinh;

            rdoNam.Checked = sv.GioiTinh == "Nam";
            rdoNu.Checked = sv.GioiTinh == "Nữ";

            cboKhoa.SelectedItem = sv.Khoa;

            txtDiemTB.Text = sv.DiemTB?.ToString() ?? "";

            idDangSua = sv.Id;

            txtMaSV.Enabled = false;
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            if (idDangSua == null)
            {
                MessageBox.Show(
                    "Hãy chọn sinh viên cần sửa!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            try
            {
                sinhVienBLL.CapNhat(
                    idDangSua.Value,
                    txtMaSV.Text,
                    txtHoTen.Text,
                    dtpNgaySinh.Value,
                    rdoNam.Checked ? "Nam" : "Nữ",
                    ((Khoa)cboKhoa.SelectedItem!).Id,
                    txtDiemTB.Text);

                MessageBox.Show(
                    "Cập nhật thành công!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LamMoiForm();
                LayDanhSachSinhVien();
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
                MessageBox.Show(
                    "Hãy chọn sinh viên cần xóa!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (MessageBox.Show(
                "Bạn có chắc muốn xóa sinh viên này?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.No)
                return;

            try
            {
                sinhVienBLL.Xoa(idDangSua.Value);

                MessageBox.Show(
                    "Xóa thành công!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                LamMoiForm();
                LayDanhSachSinhVien();
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
        private void quanLyKhoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormQuanLyKhoa frm = new FormQuanLyKhoa();

            frm.ShowDialog();

            LayDanhSachKhoa();
        }
        private void tìmKiếmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTraCuuSinhVien frm = new FormTraCuuSinhVien();

            frm.ShowDialog();
        }
    }
}