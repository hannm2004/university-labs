using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab04_01.Models
{
    public class SinhVien
    {
        public int Id { get; set; }

        [DisplayName("Mã SV")]
        public string MaSV { get; set; } = "";

        [DisplayName("Họ tên")]
        public string HoTen { get; set; } = "";

        [DisplayName("Ngày sinh")]
        public DateTime NgaySinh { get; set; }

        [DisplayName("Giới tính")]
        public string GioiTinh { get; set; } = "";

        [DisplayName("Điểm TB")]
        public double? DiemTB { get; set; }

        [Browsable(false)]
        public int KhoaId { get; set; }

        [Browsable(false)]
        public Khoa? Khoa { get; set; }

        [DisplayName("Tên Khoa")]
        public string TenKhoa
        {
            get
            {
                return Khoa == null ? "" : Khoa.TenKhoa;
            }
        }
    }
}