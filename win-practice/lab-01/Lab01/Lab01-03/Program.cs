using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab01_03
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;
            List<Student> studentList = new List<Student>();
            List<Teacher> teacherList = new List<Teacher>();
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("=== MENU BAÌ TẬP 3 (KẾ THỪA) ===");
                Console.WriteLine("1. Thêm sinh viên");
                Console.WriteLine("2. Thêm giáo viên");
                Console.WriteLine("3. Xuất danh sách sinh viên");
                Console.WriteLine("4. Xuất danh sách giáo viên");
                Console.WriteLine("5. Số lượng từng danh sách (tổng số sinh viên, tổng số giáo viên)");
                Console.WriteLine("6. Xuất danh sách Sinh Viên thuộc khoa CNTT");
                Console.WriteLine("7. Xuất danh sách giáo viên có địa chỉ chứa \"Quận 9\"");
                Console.WriteLine("8. Xuất danh sách sinh viên có điểm TB cao nhất và thuộc khoa CNTT");
                Console.WriteLine("9. Cho biết số lượng của từng xếp loại trong danh sách");
                Console.WriteLine("0. Thoát");
                Console.Write("Chọn chức năng (0-9): ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": AddStudent(studentList); break;
                    case "2": AddTeacher(teacherList); break;
                    case "3": DisplayStudentList(studentList); break;
                    case "4": DisplayTeacherList(teacherList); break;
                    case "5": DisplayCounts(studentList, teacherList); break;
                    case "6": DisplayCNTTStudents(studentList); break;
                    case "7": DisplayDistrict9Teachers(teacherList); break;
                    case "8": DisplayHighestScoreCNTTStudents(studentList); break;
                    case "9": CountStudentsByGrade(studentList); break;
                    case "0": exit = true; Console.WriteLine("Kết thúc chương trình"); break;
                    default: Console.WriteLine("Tùy chọn không hợp lệ."); break;
                }
                Console.WriteLine();
            }
        }

        static void AddStudent(List<Student> studentList)
        {
            Console.WriteLine("=== Nhập thông tin sinh viên ===");
            Student student = new Student();
            student.Input();
            studentList.Add(student);
            Console.WriteLine("Thêm sinh viên thành công!");
        }

        static void AddTeacher(List<Teacher> teacherList)
        {
            Console.WriteLine("=== Nhập thông tin giáo viên ===");
            Teacher teacher = new Teacher();
            teacher.Input();
            teacherList.Add(teacher);
            Console.WriteLine("Thêm giáo viên thành công!");
        }

        static void DisplayStudentList(List<Student> studentList)
        {
            Console.WriteLine("=== Danh sách sinh viên ===");
            foreach (var s in studentList)
            {
                s.Show();
            }
        }

        static void DisplayTeacherList(List<Teacher> teacherList)
        {
            Console.WriteLine("=== Danh sách giáo viên ===");
            foreach (var t in teacherList)
            {
                t.Show();
            }
        }

        static void DisplayCounts(List<Student> studentList, List<Teacher> teacherList)
        {
            Console.WriteLine("=== Số lượng thành viên ===");
            Console.WriteLine($"Tổng số sinh viên: {studentList.Count}");
            Console.WriteLine($"Tổng số giáo viên: {teacherList.Count}");
        }

        static void DisplayCNTTStudents(List<Student> studentList)
        {
            Console.WriteLine("=== Danh sách sinh viên thuộc khoa CNTT ===");
            var cnttStudents = studentList.Where(s => s.Faculty.Equals("CNTT", StringComparison.OrdinalIgnoreCase)).ToList();
            foreach (var s in cnttStudents)
            {
                s.Show();
            }
            if (!cnttStudents.Any()) Console.WriteLine("Không có sinh viên khoa CNTT");
        }

        static void DisplayDistrict9Teachers(List<Teacher> teacherList)
        {
            Console.WriteLine("=== Danh sách giáo viên ở Quận 9 ===");
            var d9Teachers = teacherList.Where(t => t.Address.IndexOf("Quận 9", StringComparison.OrdinalIgnoreCase) >= 0).ToList();
            if (d9Teachers.Any())
            {
                foreach (var t in d9Teachers)
                {
                    t.Show();
                }
            }
            else
            {
                Console.WriteLine("Không tìm thấy giáo viên nào có địa chỉ ở Quận 9.");
            }
        }

        static void DisplayHighestScoreCNTTStudents(List<Student> studentList)
        {
            Console.WriteLine("=== Sinh viên điểm cao nhất khoa CNTT ===");
            var cnttStudents = studentList.Where(s => s.Faculty.Equals("CNTT", StringComparison.OrdinalIgnoreCase)).ToList();
            if (cnttStudents.Any())
            {
                float maxScore = cnttStudents.Max(s => s.AverageScore);
                var maxScoreStudents = cnttStudents.Where(s => s.AverageScore == maxScore).ToList();
                foreach (var s in maxScoreStudents)
                {
                    s.Show();
                }
            }
            else
            {
                Console.WriteLine("Không có sinh viên nào thuộc khoa CNTT.");
            }
        }

        static void CountStudentsByGrade(List<Student> studentList)
        {
            Console.WriteLine("=== Số lượng từng xếp loại trong danh sách ===");
            int xuatSac = studentList.Count(s => s.AverageScore >= 9.0f && s.AverageScore <= 10.0f);
            int gioi = studentList.Count(s => s.AverageScore >= 8.0f && s.AverageScore < 9.0f);
            int kha = studentList.Count(s => s.AverageScore >= 7.0f && s.AverageScore < 8.0f);
            int trungBinh = studentList.Count(s => s.AverageScore >= 5.0f && s.AverageScore < 7.0f);
            int yeu = studentList.Count(s => s.AverageScore >= 4.0f && s.AverageScore < 5.0f);
            int kem = studentList.Count(s => s.AverageScore < 4.0f);

            Console.WriteLine("Xuất sắc (9.0 -> 10.0) : {0} sinh viên", xuatSac);
            Console.WriteLine("Giỏi     (8.0 -> <9.0) : {0} sinh viên", gioi);
            Console.WriteLine("Khá      (7.0 -> <8.0) : {0} sinh viên", kha);
            Console.WriteLine("T.Bình   (5.0 -> <7.0) : {0} sinh viên", trungBinh);
            Console.WriteLine("Yếu      (4.0 -> <5.0) : {0} sinh viên", yeu);
            Console.WriteLine("Kém      (Dưới 4.0)    : {0} sinh viên", kem);
        }
    }
}