using System.Data;
using QuanLySinhVien.BLL;
using QuanLySinhVien.DAL.Models;
namespace QuanLySinhVien.GUI
{
    public partial class FormTraCuuSinhVien : Form
    {
        private readonly SinhVienBLL sinhVienBLL = new SinhVienBLL();
        private readonly KhoaBLL khoaBLL = new KhoaBLL();
        public FormTraCuuSinhVien()
        {
            InitializeComponent();
        }

        private void FormTraCuuSinhVien_Load(object sender, EventArgs e)
        {
            LoadKhoa();
            nudTu.Value = 0;
            nudDen.Value = 10;
            chkBaoGomChuaCoDiem.Checked = true;
        }

        private void LoadKhoa()
        {
            try
            {
                var ds = khoaBLL.LayDanhSach();

                cboChuyenNganh.DataSource = ds;
                cboChuyenNganh.DisplayMember = "TenKhoa";
                cboChuyenNganh.ValueMember = "Id";

                cboChuyenNganh.SelectedIndex = -1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                int? khoaId = null;

                if (cboChuyenNganh.SelectedIndex >= 0)
                {
                    khoaId = (int)cboChuyenNganh.SelectedValue;
                }

                var ketQua = sinhVienBLL.TimKiem(
                    txtTuKhoa.Text,
                    khoaId,
                    (double)nudTu.Value,
                    (double)nudDen.Value,
                    chkBaoGomChuaCoDiem.Checked);

                dgvSinhVien.DataSource = null;
                dgvSinhVien.DataSource = ketQua;

                lblKetQua.Text = $"Tìm thấy {ketQua.Count} sinh viên";
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

        private void TimKiemSinhVien()
        {
            try
            {
                int? khoaId = null;

                if (cboChuyenNganh.SelectedIndex >= 0 && cboChuyenNganh.SelectedValue != null)
                {
                    khoaId = (int)cboChuyenNganh.SelectedValue;
                }

                var ketQua = sinhVienBLL.TimKiem(
                    txtTuKhoa.Text,
                    khoaId,
                    (double)nudTu.Value,
                    (double)nudDen.Value,
                    chkBaoGomChuaCoDiem.Checked);

                dgvSinhVien.DataSource = null;
                dgvSinhVien.DataSource = ketQua;

                lblKetQua.Text = $"Tìm thấy {ketQua.Count} sinh viên";
            }
            catch
            {
                // Không hiện MessageBox khi đang nhập liệu để tránh bị popup liên tục
            }
        }

        private void txtTuKhoa_TextChanged(object sender, EventArgs e)
        {
            TimKiemSinhVien();
        }

        private void cboChuyenNganh_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboChuyenNganh.SelectedIndex >= 0)
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

            cboChuyenNganh.SelectedIndex = -1;

            nudTu.Value = 0;

            nudDen.Value = 10;

            chkBaoGomChuaCoDiem.Checked = true;

            dgvSinhVien.DataSource = null;

            lblKetQua.Text = "Tìm thấy 0 sinh viên";
        }


    }
}