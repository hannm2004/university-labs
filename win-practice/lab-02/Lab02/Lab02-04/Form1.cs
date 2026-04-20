using System;
using System.Windows.Forms;

namespace Lab02_04
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // -------------------------------------------------------
        // Tính tổng tiền trong ListView và hiển thị vào txtTotal
        // -------------------------------------------------------
        private void CalculateTotal()
        {
            long total = 0;
            foreach (ListViewItem item in lvAccounts.Items)
            {
                long amount = 0;
                if (long.TryParse(item.SubItems[4].Text, out amount))
                    total += amount;
            }
            txtTotal.Text = total.ToString("N0") + " VNĐ";
        }

        // -------------------------------------------------------
        // Cập nhật lại số thứ tự STT sau mỗi lần thêm/xóa
        // -------------------------------------------------------
        private void UpdateSTT()
        {
            for (int i = 0; i < lvAccounts.Items.Count; i++)
                lvAccounts.Items[i].SubItems[0].Text = (i + 1).ToString();
        }

        // -------------------------------------------------------
        // Tìm kiếm số tài khoản trong ListView, trả về index (-1 nếu không tìm thấy)
        // -------------------------------------------------------
        private int FindAccountIndex(string accountNumber)
        {
            for (int i = 0; i < lvAccounts.Items.Count; i++)
            {
                if (lvAccounts.Items[i].SubItems[1].Text.Trim() == accountNumber.Trim())
                    return i;
            }
            return -1;
        }

        // -------------------------------------------------------
        // Nút Thêm / Cập Nhật
        // -------------------------------------------------------
        private void btnAddUpdate_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu đầu vào bắt buộc
            if (string.IsNullOrWhiteSpace(txtAccount.Text) ||
                string.IsNullOrWhiteSpace(txtName.Text) ||
                string.IsNullOrWhiteSpace(txtAddress.Text) ||
                string.IsNullOrWhiteSpace(txtBalance.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra số tiền phải là số hợp lệ
            long balance;
            if (!long.TryParse(txtBalance.Text.Trim(), out balance) || balance < 0)
            {
                MessageBox.Show("Số tiền trong tài khoản phải là số nguyên không âm!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtBalance.Focus();
                return;
            }

            string accountNumber = txtAccount.Text.Trim();
            int index = FindAccountIndex(accountNumber);

            if (index == -1)
            {
                // Chưa tồn tại → Thêm mới
                ListViewItem item = new ListViewItem((lvAccounts.Items.Count + 1).ToString());
                item.SubItems.Add(accountNumber);
                item.SubItems.Add(txtName.Text.Trim());
                item.SubItems.Add(txtAddress.Text.Trim());
                item.SubItems.Add(balance.ToString());
                lvAccounts.Items.Add(item);

                CalculateTotal();
                MessageBox.Show("Thêm mới dữ liệu thành công!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                // Đã tồn tại → Cập nhật
                lvAccounts.Items[index].SubItems[1].Text = accountNumber;
                lvAccounts.Items[index].SubItems[2].Text = txtName.Text.Trim();
                lvAccounts.Items[index].SubItems[3].Text = txtAddress.Text.Trim();
                lvAccounts.Items[index].SubItems[4].Text = balance.ToString();

                CalculateTotal();
                MessageBox.Show("Cập nhật dữ liệu thành công!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            // Xóa trắng các ô nhập liệu sau khi xử lý
            ClearInputFields();
        }

        // -------------------------------------------------------
        // Nút Xóa
        // -------------------------------------------------------
        private void btnDelete_Click(object sender, EventArgs e)
        {
            string accountNumber = txtAccount.Text.Trim();

            if (string.IsNullOrWhiteSpace(accountNumber))
            {
                MessageBox.Show("Vui lòng nhập số tài khoản cần xóa!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int index = FindAccountIndex(accountNumber);

            if (index == -1)
            {
                MessageBox.Show("Không tìm thấy số tài khoản cần xóa!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Xác nhận YES/NO
            DialogResult result = MessageBox.Show(
                $"Bạn có chắc chắn muốn xóa tài khoản \"{accountNumber}\" không?",
                "Cảnh Báo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                lvAccounts.Items.RemoveAt(index);
                UpdateSTT();
                CalculateTotal();
                ClearInputFields();
                MessageBox.Show("Xóa tài khoản thành công!", "Thông Báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // -------------------------------------------------------
        // Nút Thoát
        // -------------------------------------------------------
        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
                "Bạn có chắc chắn muốn thoát không?",
                "Cảnh Báo",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
                this.Close();
        }

        // -------------------------------------------------------
        // Sự kiện chọn 1 dòng trong ListView → hiển thị ngược lại vào ô nhập liệu
        // -------------------------------------------------------
        private void lvAccounts_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvAccounts.SelectedItems.Count == 0)
                return;

            ListViewItem selected = lvAccounts.SelectedItems[0];
            txtAccount.Text = selected.SubItems[1].Text;
            txtName.Text    = selected.SubItems[2].Text;
            txtAddress.Text = selected.SubItems[3].Text;
            txtBalance.Text = selected.SubItems[4].Text;
        }

        // -------------------------------------------------------
        // Hàm tiện ích: xóa trắng các TextBox nhập liệu
        // -------------------------------------------------------
        private void ClearInputFields()
        {
            txtAccount.Clear();
            txtName.Clear();
            txtAddress.Clear();
            txtBalance.Clear();
            txtAccount.Focus();
        }
    }
}
