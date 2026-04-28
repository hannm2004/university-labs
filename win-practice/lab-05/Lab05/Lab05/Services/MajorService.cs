using System;
using System.Collections.Generic;
using System.Linq;
using Lab05.Model;

namespace Lab05.Services
{
    public class MajorService
    {
        private readonly Model1 db = new Model1();

        public List<Major> GetAll()
        {
            return db.Major.OrderBy(m => m.Name).ToList();
        }

        public List<Major> GetAllByFaculty(int facultyID)
        {
            return db.Major
                     .Where(m => m.FacultyID == facultyID)
                     .OrderBy(m => m.Name)
                     .ToList();
        }

        public bool Register(string studentID, int majorID, string note)
        {
            try
            {
                // Cập nhật MajorID trực tiếp cho sinh viên
                var student = db.Student.Find(studentID);
                if (student == null) return false;

                student.MajorID = majorID;

                // Lưu lịch sử đăng ký vào bảng StudentMajor
                var registration = new StudentMajor
                {
                    StudentID = studentID,
                    MajorID = majorID,
                    RegistrationDate = DateTime.Now,
                    Note = note
                };
                db.StudentMajor.Add(registration);
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
