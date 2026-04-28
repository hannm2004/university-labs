using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Lab05.Model;
using Lab05.Services;

namespace Lab05
{
    public partial class frmStudent : Form
    {
        private readonly StudentService studentService = new StudentService();
        private readonly FacultyService facultyService = new FacultyService();
        private string currentAvatar = null;

        public frmStudent()
        {
            InitializeComponent();
        }

        // ===================== LOAD =====================
        private void frmStudent_Load(object sender, EventArgs e)
        {
            try
            {
                SetGridViewStyle(dgvStudent);
                LoadFacultyFilter();
                LoadStudents();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===================== LOAD DATA =====================
        private void LoadFacultyFilter()
        {
            var list = facultyService.GetAll();
            list.Insert(0, new Faculty { FacultyID = 0, FacultyName = "-- Tất cả khoa --" });
            cmbFaculty.DataSource = list;
            cmbFaculty.DisplayMember = "FacultyName";
            cmbFaculty.ValueMember = "FacultyID";

            // Combobox trong form nhập liệu (không có mục "Tất cả")
            var listEdit = facultyService.GetAll();
            cmbFacultyEdit.DataSource = listEdit;
            cmbFacultyEdit.DisplayMember = "FacultyName";
            cmbFacultyEdit.ValueMember = "FacultyID";
        }

        private void LoadStudents()
        {
            var list = studentService.GetAll();
            BindGrid(list);
        }

        private void BindGrid(List<Student> listStudent)
        {
            dgvStudent.Rows.Clear();
            foreach (var item in listStudent)
            {
                int index = dgvStudent.Rows.Add();
                dgvStudent.Rows[index].Cells[0].Value = item.StudentID;
                dgvStudent.Rows[index].Cells[1].Value = item.FullName;
                if (item.Faculty != null)
                    dgvStudent.Rows[index].Cells[2].Value = item.Faculty.FacultyName;
                dgvStudent.Rows[index].Cells[3].Value = item.AverageScore + "";
                if (item.MajorID != null)
                    dgvStudent.Rows[index].Cells[4].Value = item.Major != null ? item.Major.Name : "";
            }
        }

        // ===================== GRID CLICK =====================
        private void dgvStudent_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;
            var row = dgvStudent.Rows[e.RowIndex];
            string studentID = row.Cells[0].Value?.ToString();
            if (string.IsNullOrEmpty(studentID)) return;

            var student = studentService.GetByID(studentID);
            if (student == null) return;

            txtStudentID.Text = student.StudentID;
            txtFullName.Text = student.FullName;
            txtScore.Text = student.AverageScore?.ToString("F2") ?? "";

            // Set faculty combobox
            if (student.FacultyID.HasValue)
                cmbFacultyEdit.SelectedValue = student.FacultyID.Value;

            currentAvatar = student.Avatar;
            ShowAvatar(student.Avatar);

            txtStudentID.ReadOnly = true; // Khi sửa không cho đổi ID
        }

        // ===================== AVATAR =====================
        private void ShowAvatar(string imageName)
        {
            if (string.IsNullOrEmpty(imageName))
            {
                picAvatar.Image = null;
                return;
            }
            try
            {
                string dir = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
                string path = Path.Combine(dir, "Images", imageName);
                if (File.Exists(path))
                    picAvatar.Image = Image.FromFile(path);
                else
                    picAvatar.Image = null;
            }
            catch
            {
                picAvatar.Image = null;
            }
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                dlg.Title = "Chọn ảnh sinh viên";
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    // Copy ảnh vào thư mục Images của dự án
                    string dir = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName;
                    string imgDir = Path.Combine(dir, "Images");
                    if (!Directory.Exists(imgDir)) Directory.CreateDirectory(imgDir);

                    string fileName = Path.GetFileName(dlg.FileName);
                    string dest = Path.Combine(imgDir, fileName);
                    File.Copy(dlg.FileName, dest, true);

                    currentAvatar = fileName;
                    picAvatar.Image = Image.FromFile(dest);
                }
            }
        }

        // ===================== FILTER =====================
        private void cmbFaculty_SelectedIndexChanged(object sender, EventArgs e)
        {
            FilterStudents();
        }

        private void chkUnregisterMajor_CheckedChanged(object sender, EventArgs e)
        {
            FilterStudents();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            FilterStudents();
        }

        private void FilterStudents()
        {
            try
            {
                var selectedFaculty = cmbFaculty.SelectedItem as Faculty;
                string keyword = txtSearch.Text.Trim();
                List<Student> list;

                if (!string.IsNullOrEmpty(keyword))
                {
                    list = studentService.Search(keyword);
                }
                else if (selectedFaculty != null && selectedFaculty.FacultyID != 0)
                {
                    list = chkUnregisterMajor.Checked
                        ? studentService.GetAllHasNoMajor(selectedFaculty.FacultyID)
                        : studentService.GetAll(selectedFaculty.FacultyID);
                }
                else
                {
                    list = chkUnregisterMajor.Checked
                        ? studentService.GetAllHasNoMajor()
                        : studentService.GetAll();
                }

                BindGrid(list);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi lọc dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // ===================== CRUD =====================
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;
            try
            {
                var student = BuildStudentFromForm();
                bool ok = studentService.Add(student);
                if (ok)
                {
                    MessageBox.Show("Thêm sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadStudents();
                    ClearForm();
                }
                else
                    MessageBox.Show("Mã sinh viên đã tồn tại!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi thêm sinh viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (!ValidateInput()) return;
            try
            {
                var student = BuildStudentFromForm();
                bool ok = studentService.Update(student);
                if (ok)
                {
                    MessageBox.Show("Cập nhật sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadStudents();
                    ClearForm();
                }
                else
                    MessageBox.Show("Không tìm thấy sinh viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi cập nhật sinh viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtStudentID.Text))
            {
                MessageBox.Show("Vui lòng chọn sinh viên cần xóa!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            var confirm = MessageBox.Show($"Bạn có chắc muốn xóa sinh viên '{txtStudentID.Text}'?",
                "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            try
            {
                bool ok = studentService.Delete(txtStudentID.Text.Trim());
                if (ok)
                {
                    MessageBox.Show("Xóa sinh viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    LoadStudents();
                    ClearForm();
                }
                else
                    MessageBox.Show("Không tìm thấy sinh viên!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi xóa sinh viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void btnOpenRegister_Click(object sender, EventArgs e)
        {
            var frm = new frmRegister();
            frm.FormClosed += (s, args) => LoadStudents();
            frm.ShowDialog();
        }

        // ===================== HELPERS =====================
        private Student BuildStudentFromForm()
        {
            var faculty = cmbFacultyEdit.SelectedItem as Faculty;
            double? score = null;
            if (double.TryParse(txtScore.Text, out double d)) score = d;

            return new Student
            {
                StudentID = txtStudentID.Text.Trim(),
                FullName = txtFullName.Text.Trim(),
                AverageScore = score,
                FacultyID = faculty?.FacultyID,
                Avatar = currentAvatar
            };
        }

        private bool ValidateInput()
        {
            if (string.IsNullOrWhiteSpace(txtStudentID.Text))
            {
                MessageBox.Show("Vui lòng nhập Mã sinh viên!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtStudentID.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtFullName.Text))
            {
                MessageBox.Show("Vui lòng nhập Họ tên sinh viên!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtFullName.Focus();
                return false;
            }
            if (!string.IsNullOrWhiteSpace(txtScore.Text))
            {
                if (!double.TryParse(txtScore.Text, out double score) || score < 0 || score > 10)
                {
                    MessageBox.Show("Điểm trung bình phải là số từ 0 đến 10!", "Thiếu thông tin", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    txtScore.Focus();
                    return false;
                }
            }
            return true;
        }

        private void ClearForm()
        {
            txtStudentID.Text = "";
            txtFullName.Text = "";
            txtScore.Text = "";
            txtSearch.Text = "";
            picAvatar.Image = null;
            currentAvatar = null;
            txtStudentID.ReadOnly = false;
            if (cmbFacultyEdit.Items.Count > 0) cmbFacultyEdit.SelectedIndex = 0;
        }

        // ===================== STYLE =====================
        public void SetGridViewStyle(DataGridView dgview)
        {
            dgview.BorderStyle = BorderStyle.None;
            dgview.DefaultCellStyle.SelectionBackColor = Color.DarkTurquoise;
            dgview.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dgview.BackgroundColor = Color.White;
            dgview.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }
    }
}
