using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Lab02_01
{
    public partial class Form1 : Form
    {
        // Danh sách lưu lịch sử
        private List<string> lichSu = new List<string>();

        public Form1()
        {
            InitializeComponent();
        }

        // Hàm dùng chung cho 4 nút phép tính
        private void btnPhepTinh_Click(object sender, EventArgs e)
        {
            // ==========================
            // Validate nhập liệu
            // ==========================

            if (string.IsNullOrWhiteSpace(txtSo1.Text))
            {
                MessageBox.Show(
                    "Vui lòng nhập đầy đủ 2 số!",
                    "Thiếu thông tin",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtSo1.Focus();
                return;
            }

            if (string.IsNullOrWhiteSpace(txtSo2.Text))
            {
                MessageBox.Show(
                    "Vui lòng nhập đầy đủ 2 số!",
                    "Thiếu thông tin",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtSo2.Focus();
                return;
            }

            if (!double.TryParse(txtSo1.Text, out double so1))
            {
                MessageBox.Show(
                    "Vui lòng nhập đúng định dạng số!",
                    "Lỗi nhập liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtSo1.Focus();
                txtSo1.SelectAll();
                return;
            }

            if (!double.TryParse(txtSo2.Text, out double so2))
            {
                MessageBox.Show(
                    "Vui lòng nhập đúng định dạng số!",
                    "Lỗi nhập liệu",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                txtSo2.Focus();
                txtSo2.SelectAll();
                return;
            }

            // ==========================
            // Xác định phép tính
            // ==========================

            Button btn = (Button)sender;
            string kyHieu = btn.Text;

            double ketQua = 0;

            switch (kyHieu)
            {
                case "+":
                    ketQua = so1 + so2;
                    break;

                case "-":
                case "−":
                    ketQua = so1 - so2;
                    break;

                case "×":
                case "x":
                case "*":
                    ketQua = so1 * so2;
                    break;

                case "÷":
                case "/":
                    if (so2 == 0)
                    {
                        MessageBox.Show(
                            "Không thể chia cho 0!",
                            "Lỗi tính toán",
                            MessageBoxButtons.OK,
                            MessageBoxIcon.Error);

                        txtSo2.Focus();
                        txtSo2.SelectAll();
                        return;
                    }

                    ketQua = so1 / so2;
                    break;
            }

            // ==========================
            // Hiển thị kết quả
            // ==========================

            string dong = $"{so1} {kyHieu} {so2} = {ketQua}";

            lblKetQua.Text = "Kết quả: " + dong;

            // Lưu lịch sử
            lichSu.Add(dong);

            // Thêm lên đầu ListBox
            lstLichSu.Items.Insert(0, dong);
        }

        // Xóa lịch sử
        private void btnXoaLichSu_Click(object sender, EventArgs e)
        {
            if (lichSu.Count == 0)
            {
                MessageBox.Show(
                    "Chưa có lịch sử để xóa!",
                    "Thông báo",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            DialogResult ketQuaXacNhan = MessageBox.Show(
                "Bạn có chắc muốn xóa toàn bộ lịch sử tính toán?",
                "Xác nhận xóa",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (ketQuaXacNhan == DialogResult.Yes)
            {
                lichSu.Clear();
                lstLichSu.Items.Clear();
            }
        }

    }
}