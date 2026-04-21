using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Lab03_03
{
    public partial class Form2 : Form
    {
        public Student NewStudent { get; private set; }
        private List<Student> existingStudents;

        public Form2(List<Student> studentsList)
        {
            InitializeComponent();
            existingStudents = studentsList;
            cmbKhoa.SelectedIndex = 0; // Chọn dòng đầu tiên mặc định
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            // Kiểm tra rỗng
            if (string.IsNullOrWhiteSpace(txtMaSV.Text) || 
                string.IsNullOrWhiteSpace(txtTenSV.Text) || 
                string.IsNullOrWhiteSpace(txtDiemTB.Text))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ các thông tin bắt buộc (Mã số, Tên Sinh Viên, Điểm)", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra trùng Mã SV
            if (existingStudents.Any(s => s.StudentID.Equals(txtMaSV.Text.Trim(), StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("Mã số sinh viên này đã tồn tại, vui lòng nhập mã khác!", "Lỗi xác thực", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra khoảng điểm hợp lệ (0-10)
            if (!float.TryParse(txtDiemTB.Text.Trim(), out float diem) || diem < 0 || diem > 10)
            {
                MessageBox.Show("Điểm trung bình phải là một số thực nằm trong khoảng từ 0 đến 10.", "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Hợp lệ, tạo đối tượng sinh viên mới
            NewStudent = new Student
            {
                StudentID = txtMaSV.Text.Trim(),
                FullName = txtTenSV.Text.Trim(),
                Faculty = cmbKhoa.SelectedItem.ToString(),
                AverageScore = diem
            };

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
