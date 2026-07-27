using System;
using QuanLySinhVien.BLL;
using QuanLySinhVien.DAL.Models;
using System.Windows.Forms;

namespace QuanLySinhVien.GUI
{
    public partial class FormChinh : Form
    {
        private readonly SinhVienBLL sinhVienBLL = new();
        private readonly KhoaBLL khoaBLL = new();

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
                var ds = khoaBLL.LayDanhSach();

                cboKhoa.DataSource = ds;
                cboKhoa.DisplayMember = "TenKhoa";
                cboKhoa.ValueMember = "Id";

                cboKhoa.SelectedIndex = -1;
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

            cboKhoa.SelectedIndex = -1;

            rdoNam.Checked = true;

            dtpNgaySinh.Value = DateTime.Now;

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
                    (int)cboKhoa.SelectedValue,
                    txtDiemTB.Text);

                MessageBox.Show("Thêm thành công.");

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

            SinhVien sv =
                dgvSinhVien.Rows[e.RowIndex].DataBoundItem
                as SinhVien;

            if (sv == null)
                return;

            idDangSua = sv.Id;

            txtMaSV.Text = sv.MaSV;
            txtHoTen.Text = sv.HoTen;

            dtpNgaySinh.Value = sv.NgaySinh;

            cboKhoa.SelectedValue = sv.KhoaId;

            txtDiemTB.Text =
                sv.DiemTB?.ToString() ?? "";

            rdoNam.Checked =
                sv.GioiTinh == "Nam";

            rdoNu.Checked =
                sv.GioiTinh == "Nữ";
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (idDangSua == null)
            {
                MessageBox.Show("Chọn sinh viên.");

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

                    (int)cboKhoa.SelectedValue,

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
                MessageBox.Show("Chọn sinh viên.");

                return;
            }

            if (MessageBox.Show(
                "Bạn chắc chắn muốn xóa?",
                "Xác nhận",
                MessageBoxButtons.YesNo)
                == DialogResult.No)
                return;

            try
            {
                sinhVienBLL.Xoa(idDangSua.Value);

                MessageBox.Show("Đã xóa.");

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
            FormQuanLyKhoa frm = new FormQuanLyKhoa();

            frm.ShowDialog();

            LayDanhSachKhoa();
        }

        private void tìmKiếmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormTraCuuSinhVien frm = new FormTraCuuSinhVien();
            frm.ShowDialog();
        }

        private void menuQuanLyChuyenNganh_Click(object sender, EventArgs e)
        {
            FormQuanLyChuyenNganh frm = new FormQuanLyChuyenNganh();

            frm.ShowDialog();
        }

        private void btnThemKhoa_Click(object sender, EventArgs e)
        {
            using (FormThemKhoa frm = new FormThemKhoa())
            {
                if (frm.ShowDialog() == DialogResult.OK)
                {
                    LayDanhSachKhoa();
                }
            }
        }
    }
}