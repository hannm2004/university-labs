using lab04_01.Models;
using Microsoft.EntityFrameworkCore;

namespace lab04_01
{
    public partial class Form1 : Form
    {
        private int? idDangSua = null;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LayDanhSachKhoa();
            LamMoiForm();
            LayDanhSachSinhVien();
        }

        private void LayDanhSachKhoa()
        {
            try
            {
                using var db = new QuanLySinhVienDbContext();

                cboKhoa.DataSource = db.Khoas.ToList();
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
                using var db = new QuanLySinhVienDbContext();

                dgvSinhVien.DataSource = db.SinhViens
                                           .Include(sv => sv.Khoa)
                                           .ToList();

                lblTongSo.Text = $"Tổng số sinh viên: {db.SinhViens.Count()}";
                lblTrangThai.Text = "Sẵn sàng";
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Không thể kết nối cơ sở dữ liệu:\n{ex.Message}\n\n" +
                    "Kiểm tra: đã chạy Update-Database chưa? SQL Server có đang chạy không?",
                    "Lỗi kết nối",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                lblTrangThai.Text = "Lỗi kết nối CSDL";
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
            FormThemKhoa formThemKhoa = new FormThemKhoa();

            if (formThemKhoa.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    using var db = new QuanLySinhVienDbContext();

                    if (db.Khoas.Any(k => k.TenKhoa == formThemKhoa.TenKhoaMoi))
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
                        TenKhoa = formThemKhoa.TenKhoaMoi!
                    });

                    db.SaveChanges();

                    LayDanhSachKhoa();

                    MessageBox.Show(
                        "Thêm khoa mới thành công!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(
                        $"Lưu thất bại:\n{ex.Message}",
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string maSV = txtMaSV.Text.Trim();
            string hoTen = txtHoTen.Text.Trim();

            if (string.IsNullOrWhiteSpace(maSV) ||
                string.IsNullOrWhiteSpace(hoTen))
            {
                MessageBox.Show(
                    "Vui lòng nhập đầy đủ Mã SV và Họ tên!",
                    "Thiếu thông tin",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            double? diemTB = null;

            if (!string.IsNullOrWhiteSpace(txtDiemTB.Text))
            {
                if (!double.TryParse(txtDiemTB.Text, out double diem))
                {
                    MessageBox.Show(
                        "Điểm TB phải là số hợp lệ!",
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                if (diem < 0 || diem > 10)
                {
                    MessageBox.Show(
                        "Điểm TB phải từ 0 đến 10!",
                        "Lỗi",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                diemTB = diem;
            }

            try
            {
                using var db = new QuanLySinhVienDbContext();

                if (db.SinhViens.Any(sv => sv.MaSV == maSV))
                {
                    MessageBox.Show(
                        "Mã sinh viên đã tồn tại!",
                        "Thông báo",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                    return;
                }

                db.SinhViens.Add(new SinhVien
                {
                    MaSV = maSV,
                    HoTen = hoTen,
                    NgaySinh = dtpNgaySinh.Value,
                    GioiTinh = rdoNam.Checked ? "Nam" : "Nữ",
                    KhoaId = (cboKhoa.SelectedItem as Khoa)!.Id,
                    DiemTB = diemTB
                });

                db.SaveChanges();

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
                    $"Lưu thất bại:\n{ex.Message}",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void dgvSinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            SinhVien? sv = dgvSinhVien.Rows[e.RowIndex].DataBoundItem as SinhVien;

            if (sv == null) return;

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
                MessageBox.Show("Hãy chọn sinh viên cần sửa!");
                return;
            }

            try
            {
                using var db = new QuanLySinhVienDbContext();

                var sv = db.SinhViens.Find(idDangSua);

                if (sv == null)
                    return;

                sv.HoTen = txtHoTen.Text.Trim();
                sv.NgaySinh = dtpNgaySinh.Value;
                sv.GioiTinh = rdoNam.Checked ? "Nam" : "Nữ";
                sv.KhoaId = (cboKhoa.SelectedItem as Khoa)!.Id;

                if (string.IsNullOrWhiteSpace(txtDiemTB.Text))
                    sv.DiemTB = null;
                else
                    sv.DiemTB = Convert.ToDouble(txtDiemTB.Text);

                db.SaveChanges();

                MessageBox.Show("Sửa thành công!");

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
                MessageBox.Show("Hãy chọn sinh viên cần xóa!");
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
                using var db = new QuanLySinhVienDbContext();

                var sv = db.SinhViens.Find(idDangSua);

                if (sv == null)
                    return;

                db.SinhViens.Remove(sv);

                db.SaveChanges();

                MessageBox.Show("Xóa thành công!");

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

        private void dgvSinhVien_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void quanLyKhoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormQuanLyKhoa frm = new FormQuanLyKhoa();

            frm.ShowDialog();

            LayDanhSachKhoa();
        }
    }
}