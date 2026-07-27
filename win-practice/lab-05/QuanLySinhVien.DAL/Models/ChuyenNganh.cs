using System.ComponentModel;

namespace QuanLySinhVien.DAL.Models
{
    public class ChuyenNganh
    {
        public int Id { get; set; }

        [DisplayName("Chuyên ngành")]
        public string TenChuyenNganh { get; set; } = "";

        [Browsable(false)]
        public int? KhoaId { get; set; }

        [Browsable(false)]
        public Khoa? Khoa { get; set; }

        [Browsable(false)]
        public List<SinhVien> SinhViens { get; set; } = new();

        [DisplayName("Khoa")]
        public string TenKhoa
        {
            get
            {
                return Khoa == null ? "" : Khoa.TenKhoa;
            }
        }

        public override string ToString()
        {
            return TenChuyenNganh;
        }
    }
}