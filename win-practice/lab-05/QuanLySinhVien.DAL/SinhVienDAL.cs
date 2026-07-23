using Microsoft.EntityFrameworkCore;
using QuanLySinhVien.DAL.Models;

namespace QuanLySinhVien.DAL
{
    public class SinhVienDAL
    {
        public List<SinhVien> LayDanhSach()
        {
            using var db = new QuanLySinhVienDbContext();

            return db.SinhViens
                .Include(s => s.Khoa)
                .OrderBy(s => s.MaSV)
                .ToList();
        }

        public SinhVien? LayTheoId(int id)
        {
            using var db = new QuanLySinhVienDbContext();

            return db.SinhViens
                .Include(s => s.Khoa)
                .FirstOrDefault(s => s.Id == id);
        }

        public bool KiemTraTrungMa(string maSV)
        {
            using var db = new QuanLySinhVienDbContext();

            return db.SinhViens.Any(s => s.MaSV == maSV);
        }

        public void ThemMoi(SinhVien sv)
        {
            using var db = new QuanLySinhVienDbContext();

            db.SinhViens.Add(sv);
            db.SaveChanges();
        }

        public void CapNhat(SinhVien sv)
        {
            using var db = new QuanLySinhVienDbContext();

            SinhVien? svTrongDb = db.SinhViens.FirstOrDefault(x => x.Id == sv.Id);

            if (svTrongDb == null)
                throw new Exception("Không tìm thấy sinh viên.");

            svTrongDb.HoTen = sv.HoTen;
            svTrongDb.NgaySinh = sv.NgaySinh;
            svTrongDb.GioiTinh = sv.GioiTinh;
            svTrongDb.KhoaId = sv.KhoaId;
            svTrongDb.DiemTB = sv.DiemTB;

            db.SaveChanges();
        }

        public void Xoa(int id)
        {
            using var db = new QuanLySinhVienDbContext();

            SinhVien? sv = db.SinhViens.FirstOrDefault(x => x.Id == id);

            if (sv == null)
                throw new Exception("Không tìm thấy sinh viên.");

            db.SinhViens.Remove(sv);
            db.SaveChanges();
        }

        public List<SinhVien> TimKiem(
            string? tuKhoaVanBan,
            int? khoaId,
            double diemTu,
            double diemDen,
            bool baoGomChuaCoDiem)
        {
            using var db = new QuanLySinhVienDbContext();

            IQueryable<SinhVien> truyVan = db.SinhViens
                .Include(s => s.Khoa)
                .AsQueryable();

            if (!string.IsNullOrWhiteSpace(tuKhoaVanBan))
            {
                string tuKhoa = tuKhoaVanBan.Trim().ToLower();

                truyVan = truyVan.Where(s =>
                    s.MaSV.ToLower().Contains(tuKhoa) ||
                    s.HoTen.ToLower().Contains(tuKhoa));
            }

            if (khoaId.HasValue)
            {
                truyVan = truyVan.Where(s => s.KhoaId == khoaId);
            }

            List<SinhVien> ds = truyVan.ToList();

            ds = ds.Where(s =>
            {
                if (s.DiemTB == null)
                    return baoGomChuaCoDiem;

                return s.DiemTB >= diemTu &&
                       s.DiemTB <= diemDen;
            }).ToList();

            return ds;
        }
    }
}