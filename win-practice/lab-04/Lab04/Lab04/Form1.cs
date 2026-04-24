using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lab04.Model;

namespace Lab04
{
    public partial class Form1 : Form
    {
        DbStudentContent dbStudent = new DbStudentContent();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            List<Student> listStudent = dbStudent.Student.ToList();
            List<Faculty> listFaculty = dbStudent.Faculty.ToList();
            FillDataCBB(listFaculty);
            FillDataDGV(listStudent);
        }

        private void FillDataDGV(List<Student> listStudent)
        {
            dgvDSSV.Rows.Clear();
            foreach (var student in listStudent)
            {
                int RowNew = dgvDSSV.Rows.Add();
                dgvDSSV.Rows[RowNew].Cells[0].Value = student.StudentID;
                dgvDSSV.Rows[RowNew].Cells[1].Value = student.FullName;
                dgvDSSV.Rows[RowNew].Cells[2].Value = student.AverageScore;
                dgvDSSV.Rows[RowNew].Cells[3].Value = student.Faculty.FacultyName;

            }
        }

        private void FillDataCBB(List<Faculty> listFaculty)
        {
            cbbKhoa.DataSource = listFaculty;
            cbbKhoa.DisplayMember = "FacultyName";
            cbbKhoa.ValueMember = "FacultyID";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (CheckDataInput())
            {
                if (CheckIdSinhVien(txtMaSV.Text) == -1)
                {
                    Student newStudent = new Student();
                    newStudent.StudentID = txtMaSV.Text;
                    newStudent.FullName = txtHoTen.Text;
                    newStudent.AverageScore = Convert.ToDouble(txtDiemTB.Text);
                    newStudent.FacultyID = Convert.ToInt32(cbbKhoa.SelectedValue.ToString());
                    dbStudent.Student.AddOrUpdate(newStudent);
                    dbStudent.SaveChanges();
                    loadDGV();
                    loadForm();
                    MessageBox.Show($"Thêm sinh viên {newStudent.FullName} vào danh sách thành công!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show($"Sinh viên có mã số đã tồn tại!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private void loadForm()
        {
            txtMaSV.Clear();
            txtHoTen.Clear();
            txtDiemTB.Clear();
            if (cbbKhoa.Items.Count > 0)
                cbbKhoa.SelectedIndex = 0;
            txtMaSV.Focus();
        }

        private void loadDGV()
        {
            List<Student> listStudent = dbStudent.Student.ToList();
            FillDataDGV(listStudent);
        }

        private bool CheckDataInput()
        {
            if (txtMaSV.Text == "" || txtHoTen.Text == "" || txtDiemTB.Text == "")
            {
                MessageBox.Show("Bạn nhập chưa đúng thông tin!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else if (txtMaSV.TextLength < 5)
            {
                MessageBox.Show("Mã số sinh viên chưa đúng!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }
            else
            {
                float kq = 0;
                bool ketQua = float.TryParse(txtDiemTB.Text, out kq);
                if (!ketQua)
                {
                    MessageBox.Show("Điểm sinh viên chưa đúng!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            return true;
        }

        private int CheckIdSinhVien(string idNewStudent)
        {
            int length = dgvDSSV.Rows.Count;
            for (int i = 0; i < length; i++)
            {
                if (dgvDSSV.Rows[i].Cells[0].Value != null)
                    if (dgvDSSV.Rows[i].Cells[0].Value.ToString() == idNewStudent)
                        return i;
            }
            return -1;
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (CheckDataInput())
            {
                string studentId = txtMaSV.Text;
                Student student = dbStudent.Student.FirstOrDefault(s => s.StudentID == studentId);
                if (student != null)
                {
                    student.FullName = txtHoTen.Text;
                    student.AverageScore = Convert.ToDouble(txtDiemTB.Text);
                    student.FacultyID = Convert.ToInt32(cbbKhoa.SelectedValue.ToString());
                    dbStudent.Student.AddOrUpdate(student);
                    dbStudent.SaveChanges();
                    loadDGV();
                    loadForm();
                    MessageBox.Show($"Cập nhật sinh viên {student.FullName} thành công!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Không tìm thấy sinh viên để sửa!",
                        "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvDSSV.SelectedRows.Count > 0)
            {
                var result = MessageBox.Show("Bạn có chắc chắn muốn xóa sinh viên này?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // Lấy StudentID từ dòng được chọn
                    string studentId = dgvDSSV.SelectedRows[0].Cells[0].Value?.ToString();
                    if (!string.IsNullOrEmpty(studentId))
                    {
                        Student student = dbStudent.Student.FirstOrDefault(s => s.StudentID == studentId);
                        if (student != null)
                        {
                            dbStudent.Student.Remove(student);
                            dbStudent.SaveChanges();
                            loadDGV();
                            loadForm();
                            MessageBox.Show($"Đã xóa sinh viên {student.FullName} thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy sinh viên để xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnKhoa_Click(object sender, EventArgs e)
        {
            frmFalculty formFaculty = new frmFalculty();
            formFaculty.ShowDialog();
        }

        private void quảnLýKhoaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmFalculty formFaculty = new frmFalculty();
            formFaculty.ShowDialog();
        }

        private void btnTimKiem_Click_1(object sender, EventArgs e)
        {
            frmSearch frm = new frmSearch();
            frm.ShowDialog();
        }

        private void tìmKiếmToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            frmSearch frm = new frmSearch();
            frm.ShowDialog();
        }

        
    }
}
