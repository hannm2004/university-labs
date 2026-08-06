using Microsoft.EntityFrameworkCore;
using QuanLyBanHang.BLL;
using QuanLyBanHang.DAL;
using QuanLyBanHang.DAL.Entities;

namespace QuanLyBanHang.GUI
{
    public partial class FormProduct : Form
    {
        private readonly ProductBLL _productBLL;
        private Product? _selectedProduct;

        public FormProduct()
        {
            InitializeComponent();

            _productBLL = new ProductBLL();
        }

        private void FormProduct_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            dgvProduct.DataSource = null;
            dgvProduct.DataSource = _productBLL.GetAll();
            dgvProduct.Columns["OrderDetails"].Visible = false;
            lblTongSP.Text = $"Tổng số sản phẩm: {dgvProduct.Rows.Count}";
        }
        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtMaSP.Text))
            {
                MessageBox.Show("Chưa nhập mã sản phẩm.");
                txtMaSP.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtTenSP.Text))
            {
                MessageBox.Show("Chưa nhập tên sản phẩm.");
                txtTenSP.Focus();
                return false;
            }

            if (!decimal.TryParse(txtDonGia.Text, out decimal donGia))
            {
                MessageBox.Show("Đơn giá không hợp lệ.");
                txtDonGia.Focus();
                return false;
            }

            if (donGia <= 0)
            {
                MessageBox.Show("Đơn giá phải lớn hơn 0.");
                txtDonGia.Focus();
                return false;
            }

            if (!int.TryParse(txtSoLuongTon.Text, out int soLuongTon))
            {
                MessageBox.Show("Số lượng tồn không hợp lệ.");
                txtSoLuongTon.Focus();
                return false;
            }

            if (soLuongTon < 0)
            {
                MessageBox.Show("Số lượng tồn không được nhỏ hơn 0.");
                txtSoLuongTon.Focus();
                return false;
            }

            return true;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (!ValidateInput())
                return;

            try
            {
                Product product = new Product
                {
                    MaSP = txtMaSP.Text.Trim(),
                    TenSP = txtTenSP.Text.Trim(),
                    DonGia = decimal.Parse(txtDonGia.Text),
                    SoLuongTon = int.Parse(txtSoLuongTon.Text)
                };

                _productBLL.Add(product);

                MessageBox.Show("Thêm thành công.");

                LoadData();

                ClearInput();
            }
            catch (DbUpdateException)
            {
                MessageBox.Show(
                    "Không thể thêm sản phẩm.\n\nKiểm tra lại mã sản phẩm hoặc dữ liệu nhập.",
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

        private void ClearInput()
        {
            txtMaSP.Clear();
            txtTenSP.Clear();
            txtDonGia.Clear();
            txtSoLuongTon.Clear();

            dgvProduct.ClearSelection();

            _selectedProduct = null;

            txtMaSP.Focus();
        }

        private void dgvProduct_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            _selectedProduct = dgvProduct.Rows[e.RowIndex].DataBoundItem as Product;

            if (_selectedProduct == null)
                return;

            txtMaSP.Text = _selectedProduct.MaSP;
            txtTenSP.Text = _selectedProduct.TenSP;
            txtDonGia.Text = _selectedProduct.DonGia.ToString();
            txtSoLuongTon.Text = _selectedProduct.SoLuongTon.ToString();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (_selectedProduct == null)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm.");
                return;
            }

            if (!ValidateInput())
                return;

            try
            {
                _selectedProduct.MaSP = txtMaSP.Text.Trim();
                _selectedProduct.TenSP = txtTenSP.Text.Trim();
                _selectedProduct.DonGia = decimal.Parse(txtDonGia.Text);
                _selectedProduct.SoLuongTon = int.Parse(txtSoLuongTon.Text);

                _productBLL.Update(_selectedProduct);

                MessageBox.Show("Cập nhật thành công.");

                LoadData();

                ClearInput();
            }
            catch (DbUpdateException)
            {
                MessageBox.Show(
                    "Không thể cập nhật sản phẩm.",
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
            if (_selectedProduct == null)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm.");
                return;
            }

            DialogResult rs = MessageBox.Show(
                "Bạn có chắc muốn xóa sản phẩm này?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (rs == DialogResult.No)
                return;

            try
            {
                _productBLL.Delete(_selectedProduct);

                MessageBox.Show("Đã xóa.");

                LoadData();

                ClearInput();
            }
            catch (DbUpdateException)
            {
                MessageBox.Show(
                    "Không thể xóa sản phẩm.\n\nSản phẩm có thể đang được sử dụng trong đơn hàng.",
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