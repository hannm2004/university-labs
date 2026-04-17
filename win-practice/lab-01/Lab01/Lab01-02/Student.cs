using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Lab01_02
{
    class Student
    {
        private string studentID;
        private string fullName;
        private float averageScore;
        private string faculty;

        public string StudentID
        {
            get => studentID;
            set => studentID = value;
        }
        public string FullName
        {
            get => fullName;
            set => fullName = value;
        }
        public float AverageScore
        {
            get => averageScore;
            set => averageScore = value;
        }
        public string Faculty
        {
            get => faculty;
            set => faculty = value;
        }

        public Student()
        {
        }
        public Student(string studentID, string fullName, float averageScore, string faculty)
        {
            this.studentID = studentID;
            this.fullName = fullName;
            this.averageScore = averageScore;
            this.faculty = faculty;
        }

        public void Input()
        {
            Console.Write("Nhập mã sinh viên: ");
            StudentID = Console.ReadLine();
            Console.Write("Nhập họ và tên: ");
            FullName = Console.ReadLine();

            while (true)
            {
                Console.Write("Nhập điểm trung bình: ");
                string scoreStr = Console.ReadLine();
                // Thay thế dấu phẩy thành dấu chấm đề phòng người dùng nhập 9,5, sau đó ép kiểu tĩnh InvariantCulture
                if (scoreStr != null) scoreStr = scoreStr.Replace(',', '.');

                if (float.TryParse(scoreStr, System.Globalization.NumberStyles.Any, System.Globalization.CultureInfo.InvariantCulture, out float score))
                {
                    AverageScore = score;
                    break;
                }
                Console.WriteLine("Lỗi: Điểm trung bình phải là một con số, vui lòng nhập lại!");
            }

            Console.Write("Nhập khoa: ");
            Faculty = Console.ReadLine();
        }

        public void Show()
        {
            Console.WriteLine("MSSV: {0}, Họ Tên: {1}, Khoa: {2}, ĐiểmTB: {3}", this.StudentID,
                this.fullName, this.Faculty, this.AverageScore);
        }
    }
}
