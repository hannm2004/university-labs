namespace QuanLyBanHang.GUI
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }
        private void mnuSanPham_Click(object sender, EventArgs e)
        {
            using FormProduct f = new FormProduct();

            f.ShowDialog();
        }
        private void mnuKhachHang_Click(object sender, EventArgs e)
        {
            using FormCustomer f = new FormCustomer();

            f.ShowDialog();
        }
        private void mnuTaoDonHang_Click(object sender, EventArgs e)
        {
            using FormCreateOrder f = new FormCreateOrder();

            if (f.ShowDialog() == DialogResult.OK)
            {
                // Có thể reload dữ liệu nếu cần
            }
        }
        private void mnuDanhSachDonHang_Click(object sender, EventArgs e)
        {
            using FormOrderList f = new FormOrderList();

            f.ShowDialog();
        }
        private void mnuThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
