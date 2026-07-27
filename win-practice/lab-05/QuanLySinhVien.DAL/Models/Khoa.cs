using System.ComponentModel;

namespace QuanLySinhVien.DAL.Models
{
    public class Khoa
    {
        public int Id { get; set; }

        [DisplayName("Tên khoa")]
        public string TenKhoa { get; set; } = "";

        [DisplayName("Năm thành lập")]
        public int? NamThanhLap { get; set; }

        [DisplayName("Tổng GV")]
        public int? TongSoGiangVien { get; set; }

        [Browsable(false)]
        public List<ChuyenNganh> ChuyenNganhs { get; set; } = new();

        public override string ToString()
        {
            return TenKhoa;
        }
    }
}