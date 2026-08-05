using QuanLyBanHang.BLL;
using QuanLyBanHang.DAL.Entities;

namespace QuanLyBanHang.GUI
{
    public partial class FormOrderList : Form
    {
        private readonly OrderBLL _orderBLL = new OrderBLL();
        private Order? _selectedOrder;

        public FormOrderList()
        {
            InitializeComponent();
        }

        private void FormOrderList_Load(object sender, EventArgs e)
        {
            LoadOrder();
        }

        private void LoadOrder()
        {
            dgvOrder.AutoGenerateColumns = true;

            dgvOrder.DataSource = null;
            dgvOrder.DataSource = _orderBLL.GetAll();

            if (dgvOrder.Columns["OrderDetails"] != null)
                dgvOrder.Columns["OrderDetails"].Visible = false;

            if (dgvOrder.Columns["Customer"] != null)
                dgvOrder.Columns["Customer"].Visible = false;

            lblTongDon.Text = $"Tổng đơn hàng: {_orderBLL.GetAll().Count}";

            dgvDetail.DataSource = null;

            _selectedOrder = null;
        }

        private void dgvOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            _selectedOrder =
                dgvOrder.Rows[e.RowIndex].DataBoundItem as Order;

            if (_selectedOrder == null)
                return;

            dgvDetail.AutoGenerateColumns = true;
            dgvDetail.DataSource = null;
            dgvDetail.DataSource = _selectedOrder.OrderDetails.ToList();

            if (dgvDetail.Columns["Order"] != null)
                dgvDetail.Columns["Order"].Visible = false;

            if (dgvDetail.Columns["Product"] != null)
                dgvDetail.Columns["Product"].Visible = false;
        }

        private void btnCancelOrder_Click(object sender, EventArgs e)
        {
            if (_selectedOrder == null)
            {
                MessageBox.Show("Vui lòng chọn đơn hàng.");
                return;
            }

            DialogResult rs = MessageBox.Show(
                "Bạn có chắc muốn hủy đơn hàng này?",
                "Xác nhận",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (rs == DialogResult.No)
                return;

            try
            {
                _orderBLL.CancelOrder(_selectedOrder.Id);

                MessageBox.Show("Hủy đơn hàng thành công.");

                LoadOrder();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}