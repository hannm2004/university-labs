using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace lab04_01.Models
{
    public class Khoa
    {
        public int Id { get; set; }

        public string TenKhoa { get; set; } = "";

        public int? NamThanhLap { get; set; }

        public int? TongSoGiangVien { get; set; }

        [Browsable(false)]
        public List<SinhVien> SinhViens { get; set; } = new();

        public override string ToString()
        {
            return TenKhoa;
        }
    }
}
