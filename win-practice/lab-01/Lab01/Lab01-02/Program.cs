using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab01_02
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.InputEncoding = System.Text.Encoding.UTF8;
            List<Student> studentList = new List<Student>();
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("=== MENU ===");
                Console.WriteLine("1. Thêm sinh viên");
                Console.WriteLine("2. Hiển thị danh sách sinh viên");
                Console.WriteLine("3. Xuất ra thông tin của các SV đều thuộc khoa CNTT");
                Console.WriteLine("4. Xuất ra thông tin sinh viên có điểm TB >= 5");
                Console.WriteLine("5. Xuất ra danh sách sinh viên sắp xếp theo điểm TB tăng dần");
                Console.WriteLine("6. Xuất ra danh sách sinh viên có điểm TB >= 5 và thuộc khoa CNTT");
                Console.WriteLine("7. Xuất ra điểm TB cao nhất của SV khoa CNTT");
                Console.WriteLine("8. Cho biết số lượng của từng xếp loại trong danh sách");
                Console.WriteLine("0. Thoát");
                Console.Write("Chọn chức năng (0-8): ");
                string choice = Console.ReadLine();
                switch (choice)
                {
                    case "1":
                        AddStudent(studentList);
                        break;
                    case "2":
                        DisplayStudentList(studentList);
                        break;
                    case "3":
                        DisplayStudentsByFaculty(studentList, "CNTT");
                        break;
                    case "4":
                        DisplayStudentsWithHighAverageScore(studentList, 5);
                        break;
                    case "5":
                        SortStudentsByAverageScore(studentList);
                        break;
                    case "6":
                        DisplayStudentsByFacultyAndScore(studentList, "CNTT", 5);
                        break;
                    case "7":
                        DisplayStudentsWithHighestAverageScoreByFaculty(studentList, "CNTT");
                        break;
                    case "8":
                        CountStudentsByGrade(studentList);
                        break;
                    case "0":
                        exit = true;
                        Console.WriteLine("Kết thúc chương trình");
                        break;
                    default:
                        Console.WriteLine("Tùy chọn không hợp lệ. Vui lòng chọn lại.");
                        break;
                }
                Console.WriteLine();
            }
        }

        static void AddStudent(List<Student> studentList)
        {
            Console.WriteLine("=== Nhập thông tin sinh viên ===");
            Student student = new Student();
            student.Input(); studentList.Add(student);
            Console.WriteLine("Thêm sinh viên thành công!");
        }

        static void DisplayStudentList(List<Student> studentList)
        {
            Console.WriteLine("=== Danh sách chi tiết thông tin sinh viên ===");
            foreach (Student student in studentList)
            {
                student.Show();
            }
        }

        //case 3- DS Sinh viên khoa CNTT
        static void DisplayStudentsByFaculty(List<Student> studentList, string faculty)
        {
            Console.WriteLine("=== Danh sách sinh viên thuộc khoa {0} ===", faculty);
            var students = studentList.Where(s => s.Faculty.Equals(faculty, StringComparison.OrdinalIgnoreCase)).ToList();
            DisplayStudentList(students);
        }

        //case 4: Xuất ra thông tin sinh viên có điểm TB lớn hơn bằng 5.
        static void DisplayStudentsWithHighAverageScore(List<Student> studentList, float minDTB)
        {
            Console.WriteLine("=== Danh sách sinh viên có điểm TB >= {0} ===", minDTB);
            var students = studentList.Where(s => s.AverageScore >= minDTB).ToList();
            DisplayStudentList(students);
        }

        //case 5: Xuất ra danh sách sinh viên được sắp xếp theo điểm trung bình tăng dần
        static void SortStudentsByAverageScore(List<Student> studentList)
        {
            Console.WriteLine("=== Danh sách sinh viên được sắp xếp theo điểm trung bình tăng dần ===");
            var sortedStudents = studentList.OrderBy(s => s.AverageScore).ToList();
            DisplayStudentList(sortedStudents);
        }

        //case 6: DS sinh vien co DTB >=5 va thuoc khoa CNTT
        static void DisplayStudentsByFacultyAndScore(List<Student> studentList, string faculty, float minDTB)
        {
            Console.WriteLine("=== Danh sách sinh viên có điểm TB >= {0} và thuộc khoa {1} ===", minDTB, faculty);
            var students = studentList.Where(s => s.AverageScore >= minDTB
                                      && s.Faculty.Equals(faculty, StringComparison.OrdinalIgnoreCase)).ToList();
            DisplayStudentList(students);
        }

        //case 7: Xuất ra danh sách sinh viên có điểm TB cao nhất thuộc khoa CNTT
        static void DisplayStudentsWithHighestAverageScoreByFaculty(List<Student> studentList, string faculty)
        {
            Console.WriteLine("=== Danh sách sinh viên có điểm trung bình cao nhất khoa {0} ===", faculty);
            var facultyStudents = studentList.Where(s => s.Faculty.Equals(faculty, StringComparison.OrdinalIgnoreCase)).ToList();
            if (facultyStudents.Any())
            {
                float maxScore = facultyStudents.Max(s => s.AverageScore);
                var maxScoreStudents = facultyStudents.Where(s => s.AverageScore == maxScore).ToList();
                DisplayStudentList(maxScoreStudents);
            }
            else
            {
                Console.WriteLine("Không có sinh viên nào thuộc khoa " + faculty);
            }
        }

        //case 8: Phân loại theo điểm môn học
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