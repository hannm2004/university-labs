using System;
using System.Windows.Forms;

namespace lab04_01
{
    public partial class FormThemKhoa : Form
    {
        public FormThemKhoa()
        {
            InitializeComponent();
        }

        public string? TenKhoaMoi
        {
            get
            {
                return txtTenKhoa.Text.Trim();
            }
        }

        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTenKhoa.Text))
            {
                MessageBox.Show(
                    "Vui lòng nhập tên khoa!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtTenKhoa.Focus();
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}