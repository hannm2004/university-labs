using Microsoft.EntityFrameworkCore;
using QuanLyBanHang.BLL;
using QuanLyBanHang.DAL;
using QuanLyBanHang.DAL.Entities;
using QuanLyBanHang.GUI.Models;

namespace QuanLyBanHang.GUI
{
    public partial class FormCreateOrder: Form
    {
        private readonly ProductBLL _productBLL;

        private readonly CustomerBLL _customerBLL;

        private readonly OrderBLL _orderBLL;

        private List<CartItem> _cart = new();

        private List<Product> _products = new();
        public FormCreateOrder()
        {
            InitializeComponent();

            _productBLL = new ProductBLL();
            _customerBLL = new CustomerBLL();
            _orderBLL = new OrderBLL();

        }
        private void FormCreateOrder_Load(object sender, EventArgs e)
        {
            LoadCustomer();

            LoadProduct();

            LoadCart();
        }
        private void LoadCustomer()
        {
            cboCustomer.DataSource = _customerBLL.GetAll();

            cboCustomer.DisplayMember = "HoTen";

            cboCustomer.ValueMember = "Id";

            cboCustomer.SelectedIndex = -1;
        }
        private void LoadProduct()
        {
            _products = _productBLL.GetAll();

            cboProduct.DataSource = _products;

            cboProduct.DisplayMember = "TenSP";

            cboProduct.ValueMember = "Id";

            cboProduct.SelectedIndex = -1;
        }
        private void LoadCart()
        {
            dgvCart.DataSource = null;

            dgvCart.DataSource = _cart;

            lblTongTien.Text = _cart.Sum(x => x.ThanhTien).ToString("N0") + " VNĐ";
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (cboProduct.SelectedIndex == -1)
            {
                MessageBox.Show("Vui lòng chọn sản phẩm.");
                return;
            }

            Product product = (Product)cboProduct.SelectedItem;

            int quantity = (int)nudQuantity.Value;

            // Kiểm tra tồn kho
            if (quantity > product.SoLuongTon)
            {
                MessageBox.Show("Số lượng tồn không đủ.");
                return;
            }

            // Kiểm tra đã có trong giỏ chưa
            CartItem? item = _cart.FirstOrDefault(x => x.ProductId == product.Id);

            if (item != null)
            {
                if (item.SoLuong + quantity > product.SoLuongTon)
                {
                    MessageBox.Show("Số lượng vượt quá tồn kho.");
                    return;
                }

                item.SoLuong += quantity;
            }
            else
            {
                _cart.Add(new CartItem
                {
                    ProductId = product.Id,
                    MaSP = product.MaSP,
                    TenSP = product.TenSP,
                    DonGiaLucBan = product.DonGia,
                    SoLuong = quantity
                });
            }

            LoadCart();

            nudQuantity.Value = 1;
        }
        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvCart.CurrentRow == null)
            {
                MessageBox.Show("Chọn sản phẩm cần xóa.");
                return;
            }

            CartItem item = (CartItem)dgvCart.CurrentRow.DataBoundItem;

            _cart.Remove(item);

            LoadCart();
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            if (_cart.Count > 0)
            {
                DialogResult rs = MessageBox.Show(
                    "Giỏ hàng chưa được lưu. Bạn có muốn đóng?",
                    "Xác nhận",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (rs == DialogResult.No)
                    return;
            }

            Close();
        }
        private void btnOrder_Click(object sender, EventArgs e)
        {
            if (cboCustomer.SelectedIndex == -1)
            {
                MessageBox.Show("Chưa chọn khách hàng.");
                return;
            }

            if (_cart.Count == 0)
            {
                MessageBox.Show("Giỏ hàng đang trống.");
                return;
            }

            DialogResult rs = MessageBox.Show(
                "Xác nhận đặt hàng?",
                "Thông báo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (rs == DialogResult.No)
                return;

            try
            {
                Order order = new Order();

                order.CustomerId = (int)cboCustomer.SelectedValue;

                order.NgayDat = DateTime.Now;

                order.OrderDetails = new List<OrderDetail>();

                foreach (var item in _cart)
                {
                    order.OrderDetails.Add(new OrderDetail
                    {
                        ProductId = item.ProductId,
                        SoLuong = item.SoLuong,
                        DonGiaLucBan = item.DonGiaLucBan
                    });
                }

                _orderBLL.CreateOrder(order);

                MessageBox.Show(
                    "Đặt hàng thành công.",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;

                Close();
            }
            catch (DbUpdateException)
            {
                MessageBox.Show(
                    "Không thể tạo đơn hàng.",
                    "Lỗi",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
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
}
