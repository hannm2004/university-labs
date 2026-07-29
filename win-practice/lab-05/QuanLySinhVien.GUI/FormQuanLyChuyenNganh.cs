using QuanLySinhVien.BLL;
using QuanLySinhVien.DAL.Models;

namespace QuanLySinhVien.GUI
{
    public partial class FormQuanLyChuyenNganh : Form
    {
        private readonly ChuyenNganhBLL chuyenNganhBLL = new();
        private readonly KhoaBLL khoaBLL = new();

        private int? idDangSua = null;

        public FormQuanLyChuyenNganh()
        {
            InitializeComponent();
        }

        private void FormQuanLyChuyenNganh_Load(object sender, EventArgs e)
        {
            LayDanhSachKhoa();
            LayDanhSachChuyenNganh();
            LamMoiForm();
        }

        private void LayDanhSachKhoa()
        {
            cboChuyenNganh.DataSource = khoaBLL.LayDanhSach();
            cboChuyenNganh.DisplayMember = "TenKhoa";
            cboChuyenNganh.ValueMember = "Id";
            cboChuyenNganh.SelectedIndex = -1;
        }

        private void LayDanhSachChuyenNganh()
        {
            var ds = chuyenNganhBLL.LayDanhSach();

            dgvChuyenNganh.DataSource = null;
            dgvChuyenNganh.DataSource = ds;

            lblTongSo.Text = $"Tổng số chuyên ngành: {ds.Count}";
        }

        private void LamMoiForm()
        {
            txtTenChuyenNganh.Clear();

            cboChuyenNganh.SelectedIndex = -1;

            idDangSua = null;

            dgvChuyenNganh.ClearSelection();

            txtTenChuyenNganh.Focus();
        }

        private void dgvChuyenNganh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            ChuyenNganh? cn =
                dgvChuyenNganh.Rows[e.RowIndex].DataBoundItem as ChuyenNganh;

            if (cn == null)
                return;

            idDangSua = cn.Id;

            txtTenChuyenNganh.Text = cn.TenChuyenNganh;

            cboChuyenNganh.SelectedValue = cn.KhoaId;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                chuyenNganhBLL.ThemMoi(
                    txtTenChuyenNganh.Text,
                    (int)cboChuyenNganh.SelectedValue);

                MessageBox.Show("Thêm thành công.");

                LayDanhSachChuyenNganh();

                LamMoiForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (idDangSua == null)
            {
                MessageBox.Show("Hãy chọn chuyên ngành.");

                return;
            }

            try
            {
                chuyenNganhBLL.CapNhat(
                    idDangSua.Value,
                    txtTenChuyenNganh.Text,
                    (int)cboChuyenNganh.SelectedValue);

                MessageBox.Show("Cập nhật thành công.");

                LayDanhSachChuyenNganh();

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
                MessageBox.Show("Hãy chọn chuyên ngành.");

                return;
            }

            if (MessageBox.Show(
                "Bạn chắc chắn muốn xóa?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question)
                == DialogResult.No)
                return;

            try
            {
                chuyenNganhBLL.Xoa(idDangSua.Value);

                MessageBox.Show("Đã xóa.");

                LayDanhSachChuyenNganh();

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
    }
}