using QuanLySinhVien.BLL;
using QuanLySinhVien.DAL.Models;

namespace QuanLySinhVien.GUI
{
    public partial class FormChinh : Form
    {
        private readonly SinhVienBLL sinhVienBLL = new();
        private readonly KhoaBLL khoaBLL = new();
        private readonly ChuyenNganhBLL chuyenNganhBLL = new();

        private int? idDangSua = null;

        public FormChinh()
        {
            InitializeComponent();
        }

        private void FormChinh_Load(object sender, EventArgs e)
        {
            LayDanhSachChuyenNganh();
            LayDanhSachSinhVien();
            LamMoiForm();
        }

        private void LayDanhSachChuyenNganh()
        {
            try
            {
                var ds = chuyenNganhBLL.LayDanhSach();

                cboChuyenNganh.DataSource = ds;
                cboChuyenNganh.DisplayMember = "TenChuyenNganh";
                cboChuyenNganh.ValueMember = "Id";
                cboChuyenNganh.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LayDanhSachSinhVien()
        {
            try
            {
                var ds = sinhVienBLL.LayDanhSach();

                dgvSinhVien.DataSource = null;
                dgvSinhVien.DataSource = ds;

                lblTongSo.Text = $"Tổng số sinh viên: {ds.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void LamMoiForm()
        {
            txtMaSV.Clear();
            txtHoTen.Clear();
            txtDiemTB.Clear();

            cboChuyenNganh.SelectedIndex = -1;

            dtpNgaySinh.Value = DateTime.Now;

            rdoNam.Checked = true;

            idDangSua = null;

            dgvSinhVien.ClearSelection();
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
                    (int)cboChuyenNganh.SelectedValue,
                    txtDiemTB.Text);

                MessageBox.Show("Thêm sinh viên thành công.");

                LayDanhSachSinhVien();

                LamMoiForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvSinhVien_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            SinhVien? sv = dgvSinhVien.Rows[e.RowIndex].DataBoundItem as SinhVien;

            if (sv == null)
                return;

            idDangSua = sv.Id;

            txtMaSV.Text = sv.MaSV;
            txtHoTen.Text = sv.HoTen;

            dtpNgaySinh.Value = sv.NgaySinh;

            txtDiemTB.Text = sv.DiemTB?.ToString() ?? "";

            cboChuyenNganh.SelectedValue = sv.ChuyenNganhId;

            rdoNam.Checked = sv.GioiTinh == "Nam";
            rdoNu.Checked = sv.GioiTinh == "Nữ";
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (idDangSua == null)
            {
                MessageBox.Show("Vui lòng chọn sinh viên.");
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
                    (int)cboChuyenNganh.SelectedValue,
                    txtDiemTB.Text);

                MessageBox.Show("Cập nhật thành công.");

                LayDanhSachSinhVien();

                LamMoiForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (idDangSua == null)
            {
                MessageBox.Show("Vui lòng chọn sinh viên.");
                return;
            }

            if (MessageBox.Show(
                "Bạn chắc chắn muốn xóa?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.No)
                return;

            try
            {
                sinhVienBLL.Xoa(idDangSua.Value);

                MessageBox.Show("Xóa thành công.");

                LayDanhSachSinhVien();

                LamMoiForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            LamMoiForm();
        }

        private void quanLyKhoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormQuanLyKhoa frm = new();

            frm.ShowDialog();

            LayDanhSachChuyenNganh();
        }

        private void tìmKiếmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTraCuuSinhVien frm = new();

            frm.ShowDialog();
        }

        private void menuQuanLyChuyenNganh_Click(object sender, EventArgs e)
        {
            FormQuanLyChuyenNganh frm = new();

            frm.ShowDialog();

            LayDanhSachChuyenNganh();
        }

        private void btnThemChuyenNganh_Click(object sender, EventArgs e)
        {
            FormQuanLyChuyenNganh frm = new();

            frm.ShowDialog();

            LayDanhSachChuyenNganh();
        }

        private void quảnLýChuyênNgànhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormQuanLyChuyenNganh frm = new FormQuanLyChuyenNganh();
            frm.ShowDialog();
        }

        private void đăngKýChuyênNgànhToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormDangKyChuyenNganh frm = new FormDangKyChuyenNganh();
            frm.ShowDialog();
        }
    }
}