using System.ComponentModel;

namespace QuanLySinhVien.DAL.Models
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

        // ===== Quan hệ mới =====

        [Browsable(false)]
        public int? ChuyenNganhId { get; set; }

        [Browsable(false)]
        public ChuyenNganh? ChuyenNganh { get; set; }

        // Hiển thị trên DataGridView
        [DisplayName("Chuyên ngành")]
        public string TenChuyenNganh
        {
            get
            {
                return ChuyenNganh == null
                    ? ""
                    : ChuyenNganh.TenChuyenNganh;
            }
        }

        [DisplayName("Khoa")]
        public string TenKhoa
        {
            get
            {
                return ChuyenNganh?.Khoa == null
                    ? ""
                    : ChuyenNganh.Khoa.TenKhoa;
            }
        }
    }
}