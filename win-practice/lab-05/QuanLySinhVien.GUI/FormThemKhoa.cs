using QuanLySinhVien.BLL;

namespace QuanLySinhVien.GUI
{
    public partial class FormThemKhoa : Form
    {
        private readonly KhoaBLL khoaBLL = new KhoaBLL();

        public FormThemKhoa()
        {
            InitializeComponent();
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            try
            {
                khoaBLL.ThemMoi(
                    txtTenKhoa.Text,
                    null,
                    null);

                MessageBox.Show(
                    "Thêm khoa thành công!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

                DialogResult = DialogResult.OK;
                Close();
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

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}