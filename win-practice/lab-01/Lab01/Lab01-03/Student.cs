using System;
using System.Globalization;

namespace Lab01_03
{
    class Student : Person
    {
        public float AverageScore { get; set; }
        public string Faculty { get; set; }

        public Student() : base() { }

        public Student(string id, string fullName, float averageScore, string faculty) : base(id, fullName)
        {
            AverageScore = averageScore;
            Faculty = faculty;
        }

        public override void Input()
        {
            base.Input(); // Nhập ID và FullName từ lớp Person
            
            while (true)
            {
                Console.Write("Nhập điểm trung bình: ");
                string scoreStr = Console.ReadLine();
                if (scoreStr != null) scoreStr = scoreStr.Replace(',', '.');

                if (float.TryParse(scoreStr, NumberStyles.Any, CultureInfo.InvariantCulture, out float score))
                {
                    AverageScore = score;
                    break;
                }
                Console.WriteLine("Lỗi: Điểm trung bình phải là một con số, vui lòng nhập lại!");
            }

            Console.Write("Nhập khoa: ");
            Faculty = Console.ReadLine();
        }

        public override void Show()
        {
            base.Show(); // Xuất ID và FullName
            Console.WriteLine(", Khoa: {0}, ĐiểmTB: {1}", Faculty, AverageScore);
        }
    }
}
