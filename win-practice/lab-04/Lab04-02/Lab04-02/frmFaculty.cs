using System;
using System.Linq;
using System.Windows.Forms;
using Lab04_01.Model;

namespace Lab04_01
{
    public partial class frmFaculty : Form
    {
        // ===== KẾT NỐI DB =====
        DbStudentContent db = new DbStudentContent();

        public frmFaculty()
        {
            InitializeComponent();
        }

        // ================= LOAD =================
        private void frmFaculty_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        void LoadData()
        {
            dgvFaculty.Rows.Clear();

            var list = db.Faculty.ToList();

            foreach (var f in list)
            {
                int row = dgvFaculty.Rows.Add();

                dgvFaculty.Rows[row].Cells["dgvMaKhoa"].Value = f.FacultyID;
                dgvFaculty.Rows[row].Cells["dgvTenKhoa"].Value = f.FacultyName;
                dgvFaculty.Rows[row].Cells["dgvTongGS"].Value = f.TotalProfessor;
            }
        }

        // ================= LƯU (THÊM + SỬA) =================
        private void btnLuu_Click(object sender, EventArgs e)
        {
            if (txtMaKhoa.Text == "" || txtTenKhoa.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin!");
                return;
            }

            if (!int.TryParse(txtMaKhoa.Text, out int id))
            {
                MessageBox.Show("Mã khoa phải là số!");
                return;
            }

            // xử lý TotalProfessor an toàn
            int? tongGS = int.TryParse(txtTongGS.Text, out int kq) ? kq : (int?)null;

            var faculty = db.Faculty.FirstOrDefault(f => f.FacultyID == id);

            if (faculty == null)
            {
                // ===== THÊM =====
                Faculty newF = new Faculty()
                {
                    FacultyID = id,
                    FacultyName = txtTenKhoa.Text,
                    TotalProfessor = tongGS
                };

                db.Faculty.Add(newF);
                MessageBox.Show("Thêm thành công!");
            }
            else
            {
                // ===== SỬA =====
                faculty.FacultyName = txtTenKhoa.Text;
                faculty.TotalProfessor = tongGS;

                MessageBox.Show("Cập nhật thành công!");
            }

            db.SaveChanges();
            LoadData();
            ClearForm();
        }

        // ================= XÓA =================
        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (!int.TryParse(txtMaKhoa.Text, out int id))
            {
                MessageBox.Show("Chọn khoa cần xóa!");
                return;
            }

            var faculty = db.Faculty.FirstOrDefault(f => f.FacultyID == id);

            if (faculty != null)
            {
                var confirm = MessageBox.Show("Bạn có chắc muốn xóa?",
                    "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (confirm == DialogResult.Yes)
                {
                    db.Faculty.Remove(faculty);
                    db.SaveChanges();

                    LoadData();
                    ClearForm();

                    MessageBox.Show("Xóa thành công!");
                }
            }
            else
            {
                MessageBox.Show("Không tìm thấy khoa!");
            }
        }

        // ================= CLICK DGV =================
        private void dgvFaculty_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvFaculty.Rows[e.RowIndex];

                txtMaKhoa.Text = row.Cells["dgvMaKhoa"].Value?.ToString();
                txtTenKhoa.Text = row.Cells["dgvTenKhoa"].Value?.ToString();
                txtTongGS.Text = row.Cells["dgvTongGS"].Value?.ToString();
            }
        }

        // ================= ĐÓNG =================
        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        // ================= CLEAR =================
        void ClearForm()
        {
            txtMaKhoa.Clear();
            txtTenKhoa.Clear();
            txtTongGS.Clear();
            txtMaKhoa.Focus();
        }
    }
}