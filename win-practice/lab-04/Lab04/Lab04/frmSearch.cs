using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab04
{
    public partial class frmSearch: Form
    {
        public frmSearch()
        {
            InitializeComponent();
        }

        private void btntimKiem_Click(object sender, EventArgs e)
        {
            using (var db = new Model.DbStudentContent())
            {
                string maSV = txtMaSV.Text.Trim();
                string hoTen = txtHoTen.Text.Trim();

                var query = db.Student.AsQueryable();

                if (!string.IsNullOrEmpty(maSV))
                    query = query.Where(s => s.StudentID.Contains(maSV));
                if (!string.IsNullOrEmpty(hoTen))
                    query = query.Where(s => s.FullName.Contains(hoTen));

                var result = query
                    .Select(s => new
                    {
                        s.StudentID,
                        s.FullName,
                        s.AverageScore,
                        FacultyName = s.Faculty.FacultyName
                    })
                    .ToList();

                dgvDSSV.DataSource = result;
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Xóa sinh viên được chọn trong DataGridView và database
            if (dgvDSSV.SelectedRows.Count > 0)
            {
                var result = MessageBox.Show("Bạn có chắc chắn muốn xóa sinh viên này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    string studentId = dgvDSSV.SelectedRows[0].Cells[0].Value?.ToString();
                    if (!string.IsNullOrEmpty(studentId))
                    {
                        using (var db = new Model.DbStudentContent())
                        {
                            var student = db.Student.FirstOrDefault(s => s.StudentID == studentId);
                            if (student != null)
                            {
                                db.Student.Remove(student);
                                db.SaveChanges();
                                // Sau khi xóa, làm mới lại kết quả tìm kiếm
                                btntimKiem_Click(null, null);
                                MessageBox.Show("Đã xóa sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnTroVe_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textKetQua_TextChanged(object sender, EventArgs e)
        {
            textKetQua.Text = dgvDSSV.Rows.Count.ToString();
        }
    }
}
