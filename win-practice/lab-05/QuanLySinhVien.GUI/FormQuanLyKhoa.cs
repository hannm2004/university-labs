using QuanLySinhVien.BLL;
using QuanLySinhVien.DAL.Models;

namespace QuanLySinhVien.GUI
{
    public partial class FormQuanLyKhoa : Form
    {
        private readonly KhoaBLL khoaBLL = new KhoaBLL();

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
                var ds = khoaBLL.LayDanhSach();

                dgvKhoa.DataSource = null;
                dgvKhoa.DataSource = ds;

                lblTongKhoa.Text = $"Tổng số khoa: {ds.Count}";
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

        private void dgvKhoa_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            Khoa? khoa =
                dgvKhoa.Rows[e.RowIndex].DataBoundItem as Khoa;

            if (khoa == null)
                return;

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

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                khoaBLL.ThemMoi(
                    txtTenKhoa.Text,
                    chkNamThanhLap.Checked
                        ? null
                        : (int?)nudNamThanhLap.Value,
                    chkTongGV.Checked
                        ? null
                        : (int?)nudTongGV.Value);

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

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (idDangSua == null)
            {
                MessageBox.Show(
                    "Vui lòng chọn khoa cần sửa.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            try
            {
                khoaBLL.CapNhat(
                    idDangSua.Value,
                    txtTenKhoa.Text,
                    chkNamThanhLap.Checked
                        ? null
                        : (int?)nudNamThanhLap.Value,
                    chkTongGV.Checked
                        ? null
                        : (int?)nudTongGV.Value);

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
                MessageBox.Show(
                    "Vui lòng chọn khoa cần xóa.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            if (MessageBox.Show(
                "Bạn có chắc muốn xóa khoa này?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question)
                == DialogResult.No)
                return;

            try
            {
                khoaBLL.Xoa(idDangSua.Value);

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