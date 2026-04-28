using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Lab05.Model;

namespace Lab05.Services
{
    public class StudentService
    {
        private readonly Model1 db = new Model1();

        /// <summary>Lấy tất cả sinh viên kèm Faculty và Major</summary>
        public List<Student> GetAll()
        {
            return db.Student
                     .Include(s => s.Faculty)
                     .Include(s => s.Major)
                     .OrderBy(s => s.StudentID)
                     .ToList();
        }

        /// <summary>Lấy sinh viên theo Khoa</summary>
        public List<Student> GetAll(int facultyID)
        {
            return db.Student
                     .Include(s => s.Faculty)
                     .Include(s => s.Major)
                     .Where(s => s.FacultyID == facultyID)
                     .OrderBy(s => s.StudentID)
                     .ToList();
        }

        /// <summary>Lấy tất cả sinh viên chưa có chuyên ngành</summary>
        public List<Student> GetAllHasNoMajor()
        {
            return db.Student
                     .Include(s => s.Faculty)
                     .Include(s => s.Major)
                     .Where(s => s.MajorID == null)
                     .OrderBy(s => s.StudentID)
                     .ToList();
        }

        /// <summary>Lấy sinh viên chưa có chuyên ngành theo Khoa</summary>
        public List<Student> GetAllHasNoMajor(int facultyID)
        {
            return db.Student
                     .Include(s => s.Faculty)
                     .Include(s => s.Major)
                     .Where(s => s.MajorID == null && s.FacultyID == facultyID)
                     .OrderBy(s => s.StudentID)
                     .ToList();
        }

        /// <summary>Tìm sinh viên theo ID</summary>
        public Student GetByID(string studentID)
        {
            return db.Student
                     .Include(s => s.Faculty)
                     .Include(s => s.Major)
                     .FirstOrDefault(s => s.StudentID == studentID);
        }

        /// <summary>Tìm kiếm sinh viên theo tên hoặc ID</summary>
        public List<Student> Search(string keyword)
        {
            string kw = keyword.Trim().ToLower();
            return db.Student
                     .Include(s => s.Faculty)
                     .Include(s => s.Major)
                     .Where(s => s.StudentID.ToLower().Contains(kw) ||
                                 s.FullName.ToLower().Contains(kw))
                     .OrderBy(s => s.StudentID)
                     .ToList();
        }

        /// <summary>Thêm sinh viên mới</summary>
        public bool Add(Student student)
        {
            try
            {
                if (db.Student.Find(student.StudentID) != null)
                    return false; // đã tồn tại
                db.Student.Add(student);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>Cập nhật thông tin sinh viên</summary>
        public bool Update(Student student)
        {
            try
            {
                var existing = db.Student.Find(student.StudentID);
                if (existing == null) return false;

                existing.FullName = student.FullName;
                existing.AverageScore = student.AverageScore;
                existing.FacultyID = student.FacultyID;
                existing.MajorID = student.MajorID;
                existing.Avatar = student.Avatar;

                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>Xóa sinh viên theo ID</summary>
        public bool Delete(string studentID)
        {
            try
            {
                var student = db.Student.Find(studentID);
                if (student == null) return false;

                // Xóa các bản ghi StudentMajor liên quan
                var registrations = db.StudentMajor
                                      .Where(sm => sm.StudentID == studentID)
                                      .ToList();
                db.StudentMajor.RemoveRange(registrations);

                db.Student.Remove(student);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
