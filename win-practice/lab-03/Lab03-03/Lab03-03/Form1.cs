using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Lab03_03
{
    public partial class Form1 : Form
    {
        private List<Student> students;

        public Form1()
        {
            InitializeComponent();
            students = new List<Student>();
            
            // Add some sample data if desired
            students.Add(new Student { StudentID = "1", FullName = "Nguyễn Văn Bảo", Faculty = "Công nghệ thông tin", AverageScore = 5.6f });
            students.Add(new Student { StudentID = "BH030343", FullName = "Phạm Chí Bình", Faculty = "Công nghệ thông tin", AverageScore = 8.9f });

            UpdateGridView();
        }

        private void UpdateGridView(string keyword = "")
        {
            dgvDanhSach.Rows.Clear();
            int stt = 1;
            keyword = keyword.ToLower().Trim();

            foreach (var s in students)
            {
                if (string.IsNullOrEmpty(keyword) || s.FullName.ToLower().Contains(keyword))
                {
                    dgvDanhSach.Rows.Add(stt++, s.StudentID, s.FullName, s.Faculty, s.AverageScore);
                }
            }
        }

        private void MoFormThemMoi()
        {
            Form2 f2 = new Form2(students);
            if (f2.ShowDialog() == DialogResult.OK)
            {
                students.Add(f2.NewStudent);
                UpdateGridView(txtTimKiem.Text); // Update with active search filter
            }
        }

        private void menuThemMoi_Click(object sender, EventArgs e)
        {
            MoFormThemMoi();
        }

        private void btnThemMoi_Click(object sender, EventArgs e)
        {
            MoFormThemMoi();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            UpdateGridView(txtTimKiem.Text);
        }

        private void menuThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
