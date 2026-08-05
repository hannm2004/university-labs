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
            FormProduct f = new FormProduct();
            f.MdiParent = this;
            f.Show();
        }

        private void mnuKhachHang_Click(object sender, EventArgs e)
        {
            FormCustomer f = new FormCustomer();
            f.MdiParent = this;
            f.Show();
        }

        private void mnuTaoDonHang_Click(object sender, EventArgs e)
        {
            FormCreateOrder f = new FormCreateOrder();
            f.MdiParent = this;
            f.Show();
        }

        private void mnuDanhSachDonHang_Click(object sender, EventArgs e)
        {
            FormOrderList f = new FormOrderList();
            f.MdiParent = this;
            f.Show();
        }

        private void mnuThoat_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}