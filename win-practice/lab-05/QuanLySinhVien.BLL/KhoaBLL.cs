using QuanLySinhVien.DAL;
using QuanLySinhVien.DAL.Models;

namespace QuanLySinhVien.BLL
{
    public class KhoaBLL
    {
        private readonly KhoaDAL khoaDAL = new KhoaDAL();

        public List<Khoa> LayDanhSach()
        {
            return khoaDAL.LayDanhSach();
        }

        public Khoa? LayTheoId(int id)
        {
            return khoaDAL.LayTheoId(id);
        }

        private void ValidateDuLieu(
            string tenKhoa,
            int? namThanhLap,
            int? tongSoGiangVien)
        {
            if (string.IsNullOrWhiteSpace(tenKhoa))
                throw new Exception("Tên khoa không được để trống.");

            if (namThanhLap.HasValue)
            {
                if (namThanhLap < 1900 ||
                    namThanhLap > DateTime.Now.Year)
                {
                    throw new Exception("Năm thành lập không hợp lệ.");
                }
            }

            if (tongSoGiangVien.HasValue)
            {
                if (tongSoGiangVien < 0)
                    throw new Exception("Tổng số giảng viên không được âm.");
            }
        }

        public void ThemMoi(
            string tenKhoa,
            int? namThanhLap,
            int? tongSoGiangVien)
        {
            ValidateDuLieu(
                tenKhoa,
                namThanhLap,
                tongSoGiangVien);

            tenKhoa = tenKhoa.Trim();

            if (khoaDAL.KiemTraTrungTen(tenKhoa))
                throw new Exception("Tên khoa đã tồn tại.");

            Khoa khoa = new Khoa
            {
                TenKhoa = tenKhoa,
                NamThanhLap = namThanhLap,
                TongSoGiangVien = tongSoGiangVien
            };

            khoaDAL.ThemMoi(khoa);
        }

        public void CapNhat(
            int id,
            string tenKhoa,
            int? namThanhLap,
            int? tongSoGiangVien)
        {
            ValidateDuLieu(
                tenKhoa,
                namThanhLap,
                tongSoGiangVien);

            tenKhoa = tenKhoa.Trim();

            if (khoaDAL.KiemTraTrungTen(tenKhoa, id))
                throw new Exception("Tên khoa đã tồn tại.");

            Khoa khoa = new Khoa
            {
                Id = id,
                TenKhoa = tenKhoa,
                NamThanhLap = namThanhLap,
                TongSoGiangVien = tongSoGiangVien
            };

            khoaDAL.CapNhat(khoa);
        }

        public void Xoa(int id)
        {
            int soSinhVien = khoaDAL.DemSoSinhVienThuocKhoa(id);

            if (soSinhVien > 0)
            {
                throw new Exception(
                    $"Không thể xóa khoa vì còn {soSinhVien} sinh viên thuộc khoa này.");
            }

            khoaDAL.Xoa(id);
        }
    }
}