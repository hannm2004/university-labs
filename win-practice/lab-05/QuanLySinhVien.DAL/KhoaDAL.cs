using Microsoft.EntityFrameworkCore;
using QuanLySinhVien.DAL.Models;

namespace QuanLySinhVien.DAL
{
    public class KhoaDAL
    {
        public List<Khoa> LayDanhSach()
        {
            using var db = new QuanLySinhVienDbContext();

            return db.Khoas
                     .Include(k => k.ChuyenNganhs)
                     .OrderBy(k => k.TenKhoa)
                     .ToList();
        }

        public Khoa? LayTheoId(int id)
        {
            using var db = new QuanLySinhVienDbContext();

            return db.Khoas
                     .Include(k => k.ChuyenNganhs)
                     .FirstOrDefault(k => k.Id == id);
        }

        public bool KiemTraTrungTen(string tenKhoa)
        {
            using var db = new QuanLySinhVienDbContext();

            return db.Khoas.Any(k => k.TenKhoa == tenKhoa);
        }

        public bool KiemTraTrungTen(string tenKhoa, int idLoaiTru)
        {
            using var db = new QuanLySinhVienDbContext();

            return db.Khoas.Any(k =>
                k.TenKhoa == tenKhoa &&
                k.Id != idLoaiTru);
        }

        public void ThemMoi(Khoa khoa)
        {
            using var db = new QuanLySinhVienDbContext();

            db.Khoas.Add(khoa);

            db.SaveChanges();
        }

        public void CapNhat(Khoa khoa)
        {
            using var db = new QuanLySinhVienDbContext();

            Khoa? khoaTrongDb = db.Khoas
                                  .FirstOrDefault(k => k.Id == khoa.Id);

            if (khoaTrongDb == null)
                throw new Exception("Không tìm thấy khoa.");

            khoaTrongDb.TenKhoa = khoa.TenKhoa;
            khoaTrongDb.NamThanhLap = khoa.NamThanhLap;
            khoaTrongDb.TongSoGiangVien = khoa.TongSoGiangVien;

            db.SaveChanges();
        }

        public void Xoa(int id)
        {
            using var db = new QuanLySinhVienDbContext();

            Khoa? khoa = db.Khoas.FirstOrDefault(k => k.Id == id);

            if (khoa == null)
                throw new Exception("Không tìm thấy khoa.");

            db.Khoas.Remove(khoa);

            db.SaveChanges();
        }

        public int DemSoSinhVienThuocKhoa(int khoaId)
        {
            using var db = new QuanLySinhVienDbContext();

            return db.SinhViens
                     .Include(s => s.ChuyenNganh)
                     .Count(s =>
                         s.ChuyenNganh != null &&
                         s.ChuyenNganh.KhoaId == khoaId);
        }
    }
}