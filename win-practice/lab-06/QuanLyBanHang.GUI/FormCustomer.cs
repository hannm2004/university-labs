using Microsoft.EntityFrameworkCore;
using QuanLyBanHang.BLL;
using QuanLyBanHang.DAL;
using QuanLyBanHang.DAL.Entities;

namespace QuanLyBanHang.GUI
{
    public partial class FormCustomer : Form
    {
        private Customer? _selectedCustomer;

        private readonly CustomerBLL _customerBLL = new CustomerBLL();

        public FormCustomer()
        {
            InitializeComponent();
        }

        private void FormCustomer_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            dgvCustomer.DataSource = null;
            dgvCustomer.DataSource = _customerBLL.GetAll();
            dgvCustomer.Columns["Orders"].Visible = false;
            lblTongKH.Text = $"Tổng số khách hàng: {dgvCustomer.Rows.Count}";
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtHoTen.Text))
            {
                MessageBox.Show("Vui lòng nhập họ tên.");
                txtHoTen.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtSoDienThoai.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại.");
                txtSoDienThoai.Focus();
                return false;
            }

            if (!txtSoDienThoai.Text.All(char.IsDigit))
            {
                MessageBox.Show("Số điện thoại chỉ được chứa số.");
                txtSoDienThoai.Focus();
                return false;
            }

            if (txtSoDienThoai.Text.Length != 10)
            {
                MessageBox.Show("Số điện thoại phải có đúng 10 chữ số.");
                txtSoDienThoai.Focus();
                return false;
            }

            return true;
        }

        private void ClearInput()
        {
            txtHoTen.Clear();
            txtSoDienThoai.Clear();

            dgvCustomer.ClearSelection();

            _selectedCustomer = null;

            txtHoTen.Focus();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            try
            {
                Customer customer = new Customer
                {
                    HoTen = txtHoTen.Text.Trim(),
                    SoDienThoai = txtSoDienThoai.Text.Trim()
                };

                _customerBLL.Add(customer);

                MessageBox.Show("Thêm khách hàng thành công.");

                LoadData();

                ClearInput();
            }
            catch (DbUpdateException)
            {
                MessageBox.Show(
                    "Không thể thêm khách hàng.",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Có lỗi xảy ra:\n{ex.Message}",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void dgvCustomer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            _selectedCustomer = dgvCustomer.Rows[e.RowIndex].DataBoundItem as Customer;

            if (_selectedCustomer == null)
                return;

            txtHoTen.Text = _selectedCustomer.HoTen;
            txtSoDienThoai.Text = _selectedCustomer.SoDienThoai;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (_selectedCustomer == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng.");
                return;
            }

            if (!ValidateInput())
                return;

            try
            {
                _selectedCustomer.HoTen = txtHoTen.Text.Trim();
                _selectedCustomer.SoDienThoai = txtSoDienThoai.Text.Trim();

                _customerBLL.Update(_selectedCustomer);

                MessageBox.Show("Cập nhật thành công.");

                LoadData();

                ClearInput();
            }
            catch (DbUpdateException)
            {
                MessageBox.Show(
                    "Không thể cập nhật khách hàng.",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Có lỗi xảy ra:\n{ex.Message}",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (_selectedCustomer == null)
            {
                MessageBox.Show("Vui lòng chọn khách hàng.");
                return;
            }

            DialogResult rs = MessageBox.Show(
                "Bạn có chắc muốn xóa khách hàng này?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (rs == DialogResult.No)
                return;

            try
            {
                _customerBLL.Delete(_selectedCustomer);

                MessageBox.Show("Đã xóa.");

                LoadData();

                ClearInput();
            }
            catch (DbUpdateException)
            {
                MessageBox.Show(
                    "Không thể xóa khách hàng.\n\nKhách hàng đang có đơn hàng.",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Có lỗi xảy ra:\n{ex.Message}",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearInput();
        }
    }
}